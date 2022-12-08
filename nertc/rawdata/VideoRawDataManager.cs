using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace nertc
{
    /**
    * @if English
    * callback base class of the video frame data
    * @endif
    * @if Chinese
    * 视频数据回调基类
    * @endif
    */
    public interface IVideoFrameCallback
    {
        
    }
    /**
    * @if English
    * callback of the video frame raw data
    * @endif
    * @if Chinese
    * 原生视频数据回调
    * @endif
    */
    public interface IVideoFrameRawDataCallback : IVideoFrameCallback
    {
        /**
        * @if English
        * Video frame rate callback.
        * @param uid         The user ID
        * @param frame       The video frame object
        * @endif
        * @if Chinese
        * 视频帧数据回调
        * @param  uid          用户id
        * @param  frame        视频帧
        * @endif
        */
        void OnVideoFrameCallback(ulong uid, RtcVideoFrame frame);
    }

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_IOS || UNITY_ANDROID
    /**
    * @if English
    * callback of the video frame texture object
    * @endif
    * @if Chinese
    * 视频纹理对象回调
    * @endif
    */
    public interface IVideoFrameTextureCallback : IVideoFrameCallback
    {
        /**
        * @if English
        * Video frame rate callback.
        * @param uid         The user ID
        * @param texture     The UnityEngine Texture2D object
        * @param rotation    The rotation of the video frame
        * @endif
        * @if Chinese
        * 视频帧数据回调
        * @param  uid          用户id
        * @param texture       Texture2D纹理对象
        * @param  rotation     视频帧旋转角度
        * @endif
        */
        void OnVideoFrameCallback(ulong uid, UnityEngine.Texture2D texture, RtcVideoRotation rotation);
    }

#endif



    internal class VideoFrameProcessor : IDisposable
    {
#region private 
        private IntPtr _data = IntPtr.Zero;
        private int _width = 0;
        private int _height = 0;
        private RtcVideoRotation _rotation = 0;
        private volatile bool _busy = false;
        private volatile bool _hasFrame = false;
        private object _obj = new object();
        private IVideoFrameCallback _callback = null;

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_IOS || UNITY_ANDROID
        private UnityEngine.Texture2D _texture = null;
#endif

        private ulong _uid = 0;
#endregion

        public VideoFrameProcessor(ulong uid,IVideoFrameCallback callback)
        {
            _callback = callback;
            _uid = uid;

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_IOS || UNITY_ANDROID
            Dispatcher.Current.OnLateUpdate += OnLateUpdate;
#endif

        }
        public void SetCallback(IVideoFrameCallback callback)
        {
            _callback = callback;
        }
        public void NotifyFrame(ulong uid,RtcVideoFrame frame)
        {
            if(_callback == null)
            {
                return;
            }

            if(_callback is IVideoFrameRawDataCallback)
            {
                var callback = _callback as IVideoFrameRawDataCallback;
                callback?.OnVideoFrameCallback(uid, frame);
                return;
            }
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_IOS || UNITY_ANDROID
            if (_callback is IVideoFrameTextureCallback && frame.format == RtcVideoType.kNERtcVideoTypeI420)//only for I420
            {
                if (_busy || disposed)
                {
                    return;
                }

                lock (_obj)
                {
                    _busy = true;
                    if (processFrame(frame))
                    {
                        _hasFrame = true; ;
                    }
                    _busy = false;
                }
            }
#endif
        }

        #region private methods
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_IOS || UNITY_ANDROID
        private void OnLateUpdate()
        {
            if (!_hasFrame || _busy)
            {
                return;
            }
            lock (_obj)
            {
                _busy = true;
                if (drawFrame())
                {
                    _hasFrame = true;
                }
                _busy = false;
            }

            notityTextureCallback();
        }

        private bool drawFrame()
        {
            int bufferSize = _width * _height * 4;
            bool hasFrame = false;
            if (_data != IntPtr.Zero && bufferSize != 0 && _width != 0 && _height != 0)
            {
                if (_texture == null)
                {
                    _texture = new UnityEngine.Texture2D(_width, _height, UnityEngine.TextureFormat.RGBA32, false);
                }
                if (_texture.width != _width || _texture.height != _height)
                {
                    _texture.Resize(_width, _height);
                }
                _texture.LoadRawTextureData(_data, bufferSize);
                _texture.Apply();
                hasFrame = true;
            }
            return hasFrame;
        }

        private void notityTextureCallback()
        {
            var callback = _callback as IVideoFrameTextureCallback;
            callback?.OnVideoFrameCallback(_uid, _texture, _rotation);
        }
#endif


#endregion

#region IDisposable
        private volatile bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {

            // Check to see if Dispose has already been called.
            if (!disposed)
            {
                disposed = true;
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_IOS || UNITY_ANDROID
                Dispatcher.Current.OnLateUpdate -= OnLateUpdate;
#endif
                lock (_obj)
                {
                    if (_data != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(_data);
                        _data = IntPtr.Zero;
                        _width = _height = 0;
                    }
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_IOS || UNITY_ANDROID
                    if (_texture != null)
                    {
                        Dispatcher.QueueOnMainThread(() =>
                        {
                            UnityEngine.Texture2D.Destroy(_texture);
                        });
                    }


                    _texture = null;
#endif
                }
            }
        }
        ~VideoFrameProcessor()
        {
            Dispose(false);
        }

#endregion
    }

    internal sealed class VideoRawDataManager : IVideoFrameCallbackNative
    {
        private object _channelOrEngine = null;
        private IntPtr _nativeSelf = IntPtr.Zero;
        private static ulong localUserId = 0;

        class Key
        {
            ulong _uid = localUserId;
            RtcVideoStreamType _type = RtcVideoStreamType.kNERTCVideoStreamMain;
            string _uidType;
            public Key(ulong uid,RtcVideoStreamType type)
            {
                _uid = uid;
                _type = type;
                _uidType = $"{_uid}#{_type}";
            }
            
            public override bool Equals(object obj)
            {
                if (this == obj)
                {
                    return true;
                }
                var other = obj as Key;
                if (other == null)
                {
                    return false;
                }
                return _uid == other._uid && _type == other._type;
            }

            public override int GetHashCode()
            {
                return _uidType.GetHashCode();
            }
        }
        private Dictionary<Key, VideoFrameProcessor> _videoMaps = new Dictionary<Key, VideoFrameProcessor>();
        public VideoRawDataManager(object channelOrEngine, IntPtr nativeSelf)
        {
            _channelOrEngine = channelOrEngine;
            _nativeSelf = nativeSelf;
        }
        public object CreateNativeVideoCanvas(ulong uid,RtcVideoCanvas canvas,RtcVideoStreamType type)
        {
            NativeVideoCanvas? nativeCanvas = null;
            if(canvas != null)
            {
                nativeCanvas = new NativeVideoCanvas
                {
                    callback = BindEvent(type),
                    userData = _nativeSelf,
                    window = canvas.window,
                    scalingMode = (int)canvas.window,
                };
            }

            return nativeCanvas;
        }

        public object CreateChannelNativeVideoCanvas(ulong uid, RtcVideoCanvas canvas, RtcVideoStreamType type)
        {
            NativeVideoCanvas? nativeCanvas = null;
            if (canvas != null)
            {
                nativeCanvas = new NativeVideoCanvas
                {
                    callback = BindChannelEvent(type),
                    userData = _nativeSelf,
                    window = canvas.window,
                    scalingMode = (int)canvas.window,
                };
            }

            return nativeCanvas;
        }
        public void SetupVideoCanvas(ulong uid, RtcVideoCanvas canvas, RtcVideoStreamType type)
        {
            lock (_videoMaps)
            {
                var key = new Key(uid, type);
                VideoFrameProcessor processor;
                _videoMaps.TryGetValue(key, out processor);

                if (canvas?.callback == null)
                {
                    _videoMaps.Remove(key);
                    processor?.Dispose();
                    return;
                }

                if(processor == null)
                {
                    processor = new VideoFrameProcessor(uid, canvas.callback);
                    _videoMaps[key] = processor;
                    return;
                }

                processor.SetCallback(canvas.callback);
            }
        }
        public void RemoveAllCanvas()
        {
            List<VideoFrameProcessor> processors = null;
            lock (_videoMaps)
            {
                processors = _videoMaps.Select(kv => kv.Value).ToList();
                _videoMaps.Clear();
            }

            if(processors == null)
            {
                return;
            }

            foreach(var p in processors)
            {
                p.Dispose();
            }
        }
        public void RemoveAllRemoteCanvas()
        {
            var mainKey = new Key(localUserId, RtcVideoStreamType.kNERTCVideoStreamMain);
            var subKey = new Key(localUserId, RtcVideoStreamType.kNERTCVideoStreamSub);
            lock (_videoMaps)
            {
                var keys = _videoMaps.Select(kv => kv.Key).Where(v => !v.Equals(mainKey) && !v.Equals(subKey)).ToList();
                int count = keys?.Count() ?? 0;
                for (int idx = 0; idx < count; idx++)
                {
                    var key = keys[idx];
                    var processor = _videoMaps[key];
                    _videoMaps.Remove(key);
                    processor.Dispose();
                }
            }
        }
        private onFrameDataCallback BindEvent(RtcVideoStreamType type)
        {
            onFrameDataCallback callback = _onVideoFrameRawDataCallback;
            if (type == RtcVideoStreamType.kNERTCVideoStreamSub)
            {
                callback = _onSubstreamVideoFrameRawDataCallback;
            }

            return callback;
        }
        private onFrameDataCallback BindChannelEvent(RtcVideoStreamType type)
        {
            onFrameDataCallback callback = _channelOnVideoFrameRawDataCallback;
            if (type == RtcVideoStreamType.kNERTCVideoStreamSub)
            {
                callback = _channelOnSubstreamVideoFrameRawDataCallback;
            }

            return callback;
        }
        public void OnVideoFrameRawDataHandler(ulong uid, IntPtr data, uint type, uint width, uint height, uint count, IntPtr offset, IntPtr stride, uint rotation)
        {
            var key = new Key(uid, RtcVideoStreamType.kNERTCVideoStreamMain);
            VideoFrameProcessor processor = null;
            _videoMaps.TryGetValue(key, out processor);
            if (processor == null)
            {
                return;
            }
            uint[] offsets = null, strides = null;
            if (count > 0)
            {
                offsets = new uint[count];
                strides = new uint[count];

                Marshal.Copy(offset, (int[])(object)offsets, 0, (int)count);
                Marshal.Copy(stride, (int[])(object)strides, 0, (int)count);
            }

            var frame = new RtcVideoFrame
            {
                format = (RtcVideoType)type,
                buffer = data,
                width = width,
                height = height,
                rotation = (RtcVideoRotation)rotation,
                offsets = offsets,
                strides = strides,
            };

            processor.NotifyFrame(uid, frame);
        }
        public void OnSubstreamVideoFrameRawDataHandler(ulong uid, IntPtr data, uint type, uint width, uint height, uint count, IntPtr offset, IntPtr stride, uint rotation)
        {
            var key = new Key(uid, RtcVideoStreamType.kNERTCVideoStreamSub);
            VideoFrameProcessor processor = null;
            _videoMaps.TryGetValue(key, out processor);
            if (processor == null)
            {
                return;
            }
            uint[] offsets = null, strides = null;
            if (count > 0)
            {
                offsets = new uint[count];
                strides = new uint[count];

                Marshal.Copy(offset, (int[])(object)offsets, 0, (int)count);
                Marshal.Copy(stride, (int[])(object)strides, 0, (int)count);
            }

            var frame = new RtcVideoFrame
            {
                format = (RtcVideoType)type,
                buffer = data,
                width = width,
                height = height,
                rotation = (RtcVideoRotation)rotation,
                offsets = offsets,
                strides = strides,
            };

            processor.NotifyFrame(uid, frame);
        }
        #region Engine Event
        static onFrameDataCallback _onVideoFrameRawDataCallback = OnVideoFrameRawDataCallback;
        [MonoPInvokeCallback(typeof(onFrameDataCallback))]
        public static void OnVideoFrameRawDataCallback(ulong uid, IntPtr data, uint type, uint width, uint height, uint count, IntPtr offset, IntPtr stride, uint rotation, IntPtr user_data)
        {
            var rtcEngine = RtcEngine.GetEngineFromNative(user_data);
            rtcEngine?.VideoRawDataManager?.OnVideoFrameRawDataHandler(uid, data, type, width, height, count, offset, stride, rotation);
        }
        static onFrameDataCallback _onSubstreamVideoFrameRawDataCallback = OnSubstreamVideoFrameRawDataCallback;
        [MonoPInvokeCallback(typeof(onFrameDataCallback))]
        public static void OnSubstreamVideoFrameRawDataCallback(ulong uid, IntPtr data, uint type, uint width, uint height, uint count, IntPtr offset, IntPtr stride, uint rotation, IntPtr user_data)
        {
            var rtcEngine = RtcEngine.GetEngineFromNative(user_data);
            rtcEngine?.VideoRawDataManager?.OnSubstreamVideoFrameRawDataHandler(uid, data, type, width, height, count, offset, stride, rotation);
        }
        #endregion

        #region Channel Event
        static onFrameDataCallback _channelOnVideoFrameRawDataCallback = ChannelOnVideoFrameRawDataCallback;
        [MonoPInvokeCallback(typeof(onFrameDataCallback))]
        public static void ChannelOnVideoFrameRawDataCallback(ulong uid, IntPtr data, uint type, uint width, uint height, uint count, IntPtr offset, IntPtr stride, uint rotation, IntPtr user_data)
        {
            var rtcChannel = RtcChannel.GetChannelFromNative(user_data);
            rtcChannel?.VideoRawDataManager?.OnVideoFrameRawDataHandler(uid, data, type, width, height, count, offset, stride, rotation);
        }
        static onFrameDataCallback _channelOnSubstreamVideoFrameRawDataCallback = ChannelOnSubstreamVideoFrameRawDataCallback;
        [MonoPInvokeCallback(typeof(onFrameDataCallback))]
        public static void ChannelOnSubstreamVideoFrameRawDataCallback(ulong uid, IntPtr data, uint type, uint width, uint height, uint count, IntPtr offset, IntPtr stride, uint rotation, IntPtr user_data)
        {
            var rtcChannel = RtcChannel.GetChannelFromNative(user_data);
            rtcChannel?.VideoRawDataManager?.OnSubstreamVideoFrameRawDataHandler(uid, data, type, width, height, count, offset, stride, rotation);
        }
#endregion

    }
#region YUV helper
    public class YuvHelper : IYuvUtilNative
    {
        public static int ConvertI420ToRgba(IntPtr src_y, int src_stride_y, IntPtr src_u, int src_stride_u, IntPtr src_v, int src_stride_v, IntPtr dst_rgba, int dst_stride_rgba, int width, int height)
        {

            return IYuvUtilNative.convertI420ToRgba(src_y, src_stride_y,
                                                  src_u, src_stride_u,
                                                  src_v, src_stride_v,
                                                  dst_rgba, dst_stride_rgba,
                                                  width, height);
        }
    }
#endregion




}