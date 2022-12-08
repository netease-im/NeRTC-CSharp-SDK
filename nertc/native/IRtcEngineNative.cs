using System;
using System.Runtime.InteropServices;
using System.Text;

namespace nertc
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MonoPInvokeCallbackAttribute : Attribute
    {
        public MonoPInvokeCallbackAttribute(Type type) { }
    }
    
    public class NativeLib
    {
#if UNITY_IOS && !UNITY_EDITOR && !UNITY_STANDALONE
        public const string Name = "__Internal";
#else
        public const string Name = "nertc-c-sdk";
#endif
    }
    public class IVideoFrameCallbackNative
    {
        [StructLayout(LayoutKind.Sequential)]
        protected struct NativeVideoCanvas
        {
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onFrameDataCallback callback;
            public IntPtr userData;
            public IntPtr window;
            public int scalingMode;
        }

        #region video frame data event
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onFrameDataCallback(ulong uid, IntPtr data, uint type, uint width, uint height, uint count, IntPtr offset, IntPtr stride, uint rotation, IntPtr user_data);
        #endregion
    }
    public class IRtcNative : IVideoFrameCallbackNative
    {
        #region MediaStatsObserver
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onRtcStats(IntPtr self, IntPtr stats);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onLocalAudioStats(IntPtr self, IntPtr stats);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onRemoteAudioStats(IntPtr self, IntPtr stats, uint user_count);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onLocalVideoStats(IntPtr self, ref NativeVideoSendStats stats);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onRemoteVideoStats(IntPtr self, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]NativeVideoRecvStats[] stats, uint user_count);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onNetworkQuality(IntPtr self, IntPtr infos, uint user_count);
        #endregion

        #region Native Structs
        protected struct NativeChannelMediaRelayConfig
        {
            public IntPtr src_infos;
            public IntPtr dest_infos;
            public int dest_count;
        };
        protected struct NativeCanvasWatermarkConfig
        {
            public IntPtr image_watermarks;
            public int image_count;
            public IntPtr text_watermarks;
            public int text_count;
            public IntPtr timestamp_watermark;
        };

        [StructLayout(LayoutKind.Sequential)]
        protected struct NativeMediaStatsObserver
        {
            public IntPtr self;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onRtcStats onRtcStats;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onLocalAudioStats onLocalAudioStats;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onRemoteAudioStats onRemoteAudioStats;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onLocalVideoStats onLocalVideoStats;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onRemoteVideoStats onRemoteVideoStats;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onNetworkQuality onNetworkQuality;
        }

        [StructLayout(LayoutKind.Sequential)]
        protected struct NativeVideoSendStats
        {
            public IntPtr videoLayersList;
            public int videoLayersCount;
        }
        [StructLayout(LayoutKind.Sequential)]
        protected struct NativeVideoRecvStats
        {
            public ulong uid;
            public IntPtr videoLayersList;
            public int videoLayersCount;
        }
        [StructLayout(LayoutKind.Sequential)]
        protected struct NativeLiveStreamLayout
        {
            public int width;
            public int height;
            public uint background_color;
            public uint user_count;
            public IntPtr users;
            public IntPtr bg_image;
        }
        [StructLayout(LayoutKind.Sequential)]
        protected struct NativeLiveStreamTaskInfo
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string task_id;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string stream_url;
            [MarshalAs(UnmanagedType.I1)]
            public bool server_record_enabled;
            public RtcLiveStreamMode ls_mode;
            [MarshalAs(UnmanagedType.Struct)]
            public NativeLiveStreamLayout layout;
            [MarshalAs(UnmanagedType.Struct)]
            public RtcLiveStreamConfig config;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4096)]
            public string extra_info;
        }
        [StructLayout(LayoutKind.Sequential)]
        protected struct NativeScreenCaptureParameters
        {
            public int profile;
            [MarshalAs(UnmanagedType.Struct)]
            public RtcVideoDimensions dimensions;
            public int frameRate;
            public int bitrate;
            [MarshalAs(UnmanagedType.I1)]
            public bool capture_mouse_cursor;
            [MarshalAs(UnmanagedType.I1)]
            public bool window_focus;
            public IntPtr excluded_window_list;
            public int excluded_window_count;
            public int prefer;
        }

        #endregion

        #region Convert

        protected NativeLiveStreamTaskInfo ConvertToNative(RtcLiveStreamTaskInfo info)
        {
            IntPtr users = IntPtr.Zero;
            IntPtr bgImage = IntPtr.Zero;

            int userCount = info.layout.users?.Length ?? 0;
            if (userCount > 0)
            {
                users = Marshal.AllocHGlobal(userCount * Marshal.SizeOf<RtcLiveStreamUserTranscoding>());
                info.layout.users.StructureArrayToPtr(users);
            }

            if (info.layout.bgImage != null)
            {
                bgImage = Marshal.AllocHGlobal(Marshal.SizeOf<RtcLiveStreamImageInfo>());
                Marshal.StructureToPtr(info.layout.bgImage ?? default, bgImage, false);
            }

            var nativeTaskInfo = new NativeLiveStreamTaskInfo
            {
                task_id = info.taskId ?? string.Empty,
                stream_url = info.streamUrl ?? string.Empty,
                server_record_enabled = info.serverRecordEnabled,
                ls_mode = info.lsMode,
                layout = new NativeLiveStreamLayout
                {
                    width = info.layout.width,
                    height = info.layout.height,
                    background_color = info.layout.backgroundColor,
                    user_count = (uint)userCount,
                    users = users,
                    bg_image = bgImage,
                },
                config = info.config,
                extra_info = info.extraInfo ?? string.Empty
            };

            return nativeTaskInfo;
        }

        protected NativeCanvasWatermarkConfig ConvertToNative(RtcCanvasWatermarkConfig config)
        {
            IntPtr imageWatermarks = IntPtr.Zero;
            IntPtr textWatermarks = IntPtr.Zero;
            IntPtr timestampWatermark = IntPtr.Zero;

            int imageCount = config.imageWatermarks?.Length ?? 0;
            if (imageCount > 0)
            {
                imageWatermarks = Marshal.AllocHGlobal(imageCount * Marshal.SizeOf<RtcImageWatermarkConfig>());
                config.imageWatermarks.StructureArrayToPtr(imageWatermarks);
            }
            int textCount = config.textWatermarks?.Length ?? 0;
            if (textCount > 0)
            {
                textWatermarks = Marshal.AllocHGlobal(textCount * Marshal.SizeOf<RtcTextWatermarkConfig>());
                config.textWatermarks.StructureArrayToPtr(textWatermarks);
            }

            if (config.timestampWatermark != null)
            {
                timestampWatermark = Marshal.AllocHGlobal(Marshal.SizeOf<RtcTimestampWatermarkConfig>());
                Marshal.StructureToPtr(config.timestampWatermark ?? default, timestampWatermark, false);
            }

            var nativeConfig = new NativeCanvasWatermarkConfig
            {
                image_watermarks = imageWatermarks,
                image_count = imageCount,
                text_watermarks = textWatermarks,
                text_count = textCount,
                timestamp_watermark = timestampWatermark,
            };

            return nativeConfig;
        }

        protected NativeChannelMediaRelayConfig ConvertToNative(RtcChannelMediaRelayConfig config)
        {
            var src_infos = Marshal.AllocHGlobal(Marshal.SizeOf<RtcChannelMediaRelayInfo>());
            Marshal.StructureToPtr(config.srcInfos, src_infos, false);

            var dest_infos = Marshal.AllocHGlobal(config.destInfos.Length * Marshal.SizeOf<RtcChannelMediaRelayInfo>());
            config.destInfos.StructureArrayToPtr(dest_infos);

            var native = new NativeChannelMediaRelayConfig
            {
                src_infos = src_infos,
                dest_infos = dest_infos,
                dest_count = config.destInfos.Length,
            };

            return native;
        }

        protected NativeScreenCaptureParameters ConvertToNative(RtcScreenCaptureParameters screenParameters)
        {
            IntPtr excludedWindowList = IntPtr.Zero;
            int excluded_window_count = screenParameters.excludedWindowList?.Length ?? 0;
            if (excluded_window_count > 0)
            {
                excludedWindowList = Marshal.AllocHGlobal(Marshal.SizeOf<long>() * excluded_window_count);
                Marshal.Copy(screenParameters.excludedWindowList, 0, excludedWindowList, excluded_window_count);
            }
            var screen_parameters = new NativeScreenCaptureParameters
            {
               profile = (int)screenParameters.profile,
                dimensions = screenParameters.dimensions,
                frameRate = screenParameters.frameRate,
                bitrate = screenParameters.bitrate,
                capture_mouse_cursor = screenParameters.captureMouseCursor,
                window_focus = screenParameters.windowFocus,
                excluded_window_list = excludedWindowList,
                excluded_window_count = excluded_window_count,
                prefer = (int)screenParameters.prefer,
            };
            return screen_parameters;
        }
        #endregion
    }
    public class IRtcEngineNative : IRtcNative
    {
        #region Engine Events
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onError(IntPtr self, int error_code, string msg);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onWarning(IntPtr self, int warn_code, string msg);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onReleasedHwResources(IntPtr self, int result);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onJoinChannel(IntPtr self, ulong cid, ulong uid, int result, ulong elapsed);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onReconnectingStart(IntPtr self, ulong cid, ulong uid);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onConnectionStateChange(IntPtr self, int state, int reason);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onNetworkTypeChanged(IntPtr self, int new_type);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onRejoinChannel(IntPtr self, ulong cid, ulong uid, int result, ulong elapsed);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onLeaveChannel(IntPtr self, int result);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onDisconnect(IntPtr self, int reason);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onClientRoleChanged(IntPtr self, int oldRole, int newRole);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserJoined(IntPtr self, ulong uid, string user_name);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserLeft(IntPtr self, ulong uid, int reason);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserAudioStart(IntPtr self, ulong uid);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserAudioStop(IntPtr self, ulong uid);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserVideoStart(IntPtr self, ulong uid, int max_profile);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserVideoStop(IntPtr self, ulong uid);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserSubStreamVideoStart(IntPtr self, ulong uid, int max_profile);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserSubStreamVideoStop(IntPtr self, ulong uid);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onScreenCaptureStatusChanged(IntPtr self, int status);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserVideoProfileUpdate(IntPtr self, ulong uid, int max_profile);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserAudioMute(IntPtr self, ulong uid, bool mute);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserVideoMute(IntPtr self, ulong uid, bool mute);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onAudioDeviceRoutingDidChange(IntPtr self, int routing);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onAudioDeviceStateChanged(IntPtr self, string device_id, int device_type, int device_state);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onAudioDefaultDeviceChanged(IntPtr self, string device_id, int device_type);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onVideoDeviceStateChanged(IntPtr self, string device_id, int device_type, int device_state);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onCameraFocusChanged(IntPtr self, IntPtr info);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onCameraExposureChanged(IntPtr self, IntPtr info);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onFirstAudioDataReceived(IntPtr self, ulong uid);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onFirstVideoDataReceived(IntPtr self, ulong uid);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onFirstAudioFrameDecoded(IntPtr self, ulong uid);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onFirstVideoFrameDecoded(IntPtr self, ulong uid, uint width, uint height);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onCaptureVideoFrame(IntPtr self, IntPtr data, int type, uint width, uint height, uint count, IntPtr offset, IntPtr stride, int rotation);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onAudioMixingStateChanged(IntPtr self, int state, int error_code);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onAudioMixingTimestampUpdate(IntPtr self, ulong timestamp_ms);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onAudioEffectFinished(IntPtr self, uint effect_id);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onLocalAudioVolumeIndication(IntPtr self, int volume);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onRemoteAudioVolumeIndication(IntPtr self, IntPtr speakers, uint speaker_number, int total_volume);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onAddLiveStreamTask(IntPtr self, string task_id, string url, int error_code);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUpdateLiveStreamTask(IntPtr self, string task_id, string url, int error_code);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onRemoveLiveStreamTask(IntPtr self, string task_id, int error_code);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onLiveStreamStateChanged(IntPtr self, string task_id, string url, int state);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onAudioHowling(IntPtr self, bool howling);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onRecvSEIMessage(IntPtr self, ulong uid, [MarshalAs(UnmanagedType.LPArray,SizeParamIndex = 3)]byte[] data, uint dataSize);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onAudioRecording(IntPtr self, int code, string file_path);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onMediaRelayStateChanged(IntPtr self, int state, string channel_name);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onMediaRelayEvent(IntPtr self, int evt, string channel_name, int error);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onPublishFallbackToAudioOnly(IntPtr self, bool is_fallback, int stream_type);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onSubscribeFallbackToAudioOnly(IntPtr self, ulong uid, bool is_fallback, int stream_type);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onLastmileQuality(IntPtr self, int quality);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onLastmileProbeResult(IntPtr self, IntPtr result);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onAvatarUserJoined(IntPtr self, ulong src_uid, ulong uid, string user_name);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onAvatarUserLeft(IntPtr self, ulong src_uid, ulong uid, int reason);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onAvatarStatus(IntPtr self, bool enable, int error_code);
        #endregion

        #region AudioFrameObserver
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onAudioFrameDidRecord(IntPtr self,IntPtr frame);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onAudioFrameWillPlayback(IntPtr self, IntPtr frame);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onMixedAudioFrame(IntPtr self, IntPtr frame);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onPlaybackAudioFrameBeforeMixing(IntPtr self, ulong user_id, IntPtr frame, ulong cid);
        #endregion

        #region Native Structs
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        protected struct NativeEngineContext
        {
            public string app_key;
            public string log_dir_path;
            public int log_level;
            public uint log_file_max_size_kbytes;
            [MarshalAs(UnmanagedType.Struct)]
            public NativeEngineEnvent events;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        protected struct NativeEngineEnvent
        {
            public IntPtr self;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onError onError;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onWarning onWarning;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onReleasedHwResources onReleasedHwResources;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onJoinChannel onJoinChannel;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onReconnectingStart onReconnectingStart;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onConnectionStateChange onConnectionStateChange;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onNetworkTypeChanged onNetworkTypeChanged;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onRejoinChannel onRejoinChannel;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onLeaveChannel onLeaveChannel;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onDisconnect onDisconnect;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onClientRoleChanged onClientRoleChanged;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserJoined onUserJoined;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserLeft onUserLeft;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserAudioStart onUserAudioStart;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserAudioStop onUserAudioStop;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserVideoStart onUserVideoStart;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserVideoStop onUserVideoStop;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserSubStreamVideoStart onUserSubStreamVideoStart;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserSubStreamVideoStop onUserSubStreamVideoStop;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onScreenCaptureStatusChanged onScreenCaptureStatusChanged;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserVideoProfileUpdate onUserVideoProfileUpdate;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserAudioMute onUserAudioMute;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserVideoMute onUserVideoMute;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onAudioDeviceRoutingDidChange onAudioDeviceRoutingDidChange;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onAudioDeviceStateChanged onAudioDeviceStateChanged;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onAudioDefaultDeviceChanged onAudioDefaultDeviceChanged;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onVideoDeviceStateChanged onVideoDeviceStateChanged;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onCameraFocusChanged onCameraFocusChanged;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onCameraExposureChanged onCameraExposureChanged;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onFirstAudioDataReceived onFirstAudioDataReceived;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onFirstVideoDataReceived onFirstVideoDataReceived;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onFirstAudioFrameDecoded onFirstAudioFrameDecoded;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onFirstVideoFrameDecoded onFirstVideoFrameDecoded;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onCaptureVideoFrame onCaptureVideoFrame;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onAudioMixingStateChanged onAudioMixingStateChanged;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onAudioMixingTimestampUpdate onAudioMixingTimestampUpdate;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onAudioEffectFinished onAudioEffectFinished;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onLocalAudioVolumeIndication onLocalAudioVolumeIndication;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onRemoteAudioVolumeIndication onRemoteAudioVolumeIndication;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onAddLiveStreamTask onAddLiveStreamTask;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUpdateLiveStreamTask onUpdateLiveStreamTask;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onRemoveLiveStreamTask onRemoveLiveStreamTask;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onLiveStreamStateChanged onLiveStreamStateChanged;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onAudioHowling onAudioHowling;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onRecvSEIMessage onRecvSEIMessage;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onAudioRecording onAudioRecording;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onMediaRelayStateChanged onMediaRelayStateChanged;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onMediaRelayEvent onMediaRelayEvent;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onPublishFallbackToAudioOnly onPublishFallbackToAudioOnly;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onSubscribeFallbackToAudioOnly onSubscribeFallbackToAudioOnly;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onLastmileQuality onLastmileQuality;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onLastmileProbeResult onLastmileProbeResult;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onAvatarUserJoined onAvatarUserJoined;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onAvatarUserLeft onAvatarUserLeft;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onAvatarStatus onAvatarStatus;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        protected struct NativeAudioFrameObserver
        {
            public IntPtr self;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onAudioFrameDidRecord onAudioFrameDidRecord;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onAudioFrameWillPlayback onAudioFrameWillPlayback;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onMixedAudioFrame onMixedAudioFrame;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onPlaybackAudioFrameBeforeMixing onPlaybackAudioFrameBeforeMixing;
        }

        #endregion

        #region Engine API
        [DllImport(NativeLib.Name, EntryPoint = "create_nertc_engine", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern  IntPtr createNERtcEngine();
        [DllImport(NativeLib.Name, EntryPoint = "destroy_nertc_engine", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern  void destroyNERtcEngine(IntPtr engine);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_init", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern  int initialize(IntPtr self, ref NativeEngineContext param);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_release", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern  void release(IntPtr self, bool sync);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_client_role", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern  int setClientRole(IntPtr self, int role);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_channel_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern  int setChannelProfile(IntPtr self, int profile);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_join_channel", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern  int joinChannel(IntPtr self,string token,string channel_name, ulong uid);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_switch_channel", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern  int switchChannel(IntPtr self, string token, string channel_name);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_leave_channel", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern  int leaveChannel(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_query_interface", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern  IntPtr queryInterface(IntPtr self,int iid);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_enable_local_audio", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern  int enableLocalAudio(IntPtr self, bool enabled);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_setup_local_video_canvas", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern  int setupLocalVideoCanvas(IntPtr self, IntPtr canvas);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_setup_remote_video_canvas", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern  int setupRemoteVideoCanvas(IntPtr self,ulong uid,IntPtr canvas);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_enable_local_video", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern  int enableLocalVideo(IntPtr self, bool enabled);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_subscribe_remote_video_stream", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern  int subscribeRemoteVideoStream(IntPtr self,ulong uid, int type,bool subscribe);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_switch_camera", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern  int switchCamera(IntPtr self);
        
        #endregion

        #region Engine API Ex
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_create_channel", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern IntPtr createChannel(IntPtr self,string channel_name);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_get_connection_state", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int getConnectionState(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_mute_local_audio_stream", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int muteLocalAudioStream(IntPtr self, bool mute);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_audio_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setAudioProfile(IntPtr self,int profile, int scenario);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_audio_effect_preset", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setAudioEffectPreset(IntPtr self, int type);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_voice_beautifier_preset", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setVoiceBeautifierPreset(IntPtr self,int type);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_local_voice_pitch", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setLocalVoicePitch(IntPtr self, double pitch);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_local_voice_equalization", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setLocalVoiceEqualization(IntPtr self,int band_frequency,int band_gain);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_subscribe_remote_audio_stream", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int subscribeRemoteAudioStream(IntPtr self, ulong uid, bool subscribe);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_audio_session_operation_restriction", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setSudioSessionOperationRestriction(IntPtr self, int restriction);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_playout_device_mute", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setPlayoutDeviceMute(IntPtr self, bool muted);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_get_playout_device_mute", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int getPlayoutDeviceMute(IntPtr self, ref bool muted);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_record_device_mute", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setRecordDeviceMute(IntPtr self, bool muted);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_get_record_device_mute", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int getRecordDeviceMute(IntPtr self, ref bool muted);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_is_camera_zoom_supported", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool isCameraZoomSupported(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_is_camera_torch_supported", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool isCameraTorchSupported(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_is_camera_focus_supported", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool isCameraFocusSupported(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_is_camera_exposure_position_supported", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool isCameraExposurePositionSupported(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_camera_exposure_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setCameraExposurePosition(IntPtr self,float pointX,float pointY);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_camera_torch_on", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setCameraTorchOn(IntPtr self, bool on);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_is_camera_torch_on", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool isCameraTorchOn(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_camera_zoom_factor", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setCameraZoomFactor(IntPtr self,float factor);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_max_camera_zoom_scale", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern float maxCameraZoomScale(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_camera_focus_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setCameraFocusPosition(IntPtr self,float x, float y);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_camera_capture_config", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setCameraCaptureConfig(IntPtr self,ref RtcCameraCaptureConfig config);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_subscribe_all_remote_audio_stream", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int subscribeAllRemoteAudioStream(IntPtr self, bool subscribe);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_video_config", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setVideoConfig(IntPtr self, ref RtcVideoConfig config);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_enable_dual_stream_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int enableDualStreamMode(IntPtr self, bool enable);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_setup_local_sub_stream_video_canvas", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setupLocalSubstreamVideoCanvas(IntPtr self,IntPtr canvas);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_local_sub_stream_render_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setLocalSubstreamRenderMode(IntPtr self,int scaling_mode);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_local_render_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setLocalRenderMode(IntPtr self, int scaling_mode);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_local_video_mirror_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setLocalVideoMirrorMode(IntPtr self,int mirror_mode);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_remote_render_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setRemoteRenderMode(IntPtr self,ulong uid, int scaling_mode);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_setup_remote_sub_stream_video_canvas", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setupRemoteSubstreamVideoCanvas(IntPtr self,ulong uid,IntPtr canvas);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_subscribe_remote_video_sub_stream", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int subscribeRemoteVideoSubstream(IntPtr self,ulong uid,bool subscribe);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_remote_sub_stream_render_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setRemoteSubsteamRenderMode(IntPtr self,ulong uid, int scaling_mode);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_start_video_preview", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int startVideoPreview(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_stop_video_preview", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int stopVideoPreview(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_mute_local_video_stream", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int muteLocalVideoStream(IntPtr self, bool mute);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_local_media_priority", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setLocalMediaPriority(IntPtr self,int priority,bool is_preemptive);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_parameters", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setParameters(IntPtr self, string parameters);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_recording_audio_frame_parameters", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setRecordingAudioFrameParameters(IntPtr self,ref RtcAudioFrameRequestFormat format);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_playback_audio_frame_parameters", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setPlaybackAudioFrameParameters(IntPtr self,ref RtcAudioFrameRequestFormat format);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_mixed_audio_frame_parameters", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setMixedAudioFrameParameters(IntPtr self, int sample_rate);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_audio_frame_observer", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setAudioFrameObserver(IntPtr self,IntPtr observer);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_start_audio_dump", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int startAudioDump(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_stop_audio_dump", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int stopAudioDump(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_loudspeaker_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setLoudSpeakerMode(IntPtr self, bool enable);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_get_loudspeaker_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int getLoudSpeakerMode(IntPtr self, ref bool enabled);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_start_audio_mixing", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int startAudioMixing(IntPtr self, ref RtcCreateAudioMixingOption option);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_stop_audio_mixing", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int stopAudioMixing(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_pause_audio_mixing", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int pauseAudioMixing(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_resume_audio_mixing", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int resumeAudioMixing(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_audio_mixing_send_volume", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setAudioMixingSendVolume(IntPtr self, uint volume);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_get_audio_mixing_send_volume", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int getAudioMixingSendVolume(IntPtr self, ref uint volume);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_audio_mixing_playback_volume", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setAudioMixingPlaybackVolume(IntPtr self, uint volume);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_get_audio_mixing_playback_volume", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int getAudioMixingPlaybackVolume(IntPtr self, ref uint volume);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_get_audio_mixing_duration", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int getAudioMixingDuration(IntPtr self, ref ulong duration);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_get_audio_mixing_current_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int getAudioMixingCurrentPosition(IntPtr self, ref ulong position);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_audio_mixing_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setAudioMixingPosition(IntPtr self, ulong seek_position);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_play_effect", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int playEffect(IntPtr self,uint effect_id,ref RtcCreateAudioEffectOption option);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_stop_effect", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int stopEffect(IntPtr self, uint effect_id);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_stop_all_effects", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int stopAllEffects(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_pause_effect", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int pauseEffect(IntPtr self, uint effect_id);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_resume_effect", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int resumeEffect(IntPtr self, uint effect_id);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_pause_all_effects", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int pauseAllEffects(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_resume_all_effects", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int resumeAllEffects(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_effect_send_volume", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setEffectSendVolume(IntPtr self, uint effect_id, uint volume);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_get_effect_send_volume", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int getEffectSendVolume(IntPtr self, uint effect_id, ref uint volume);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_effect_playback_volume", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setEffectPlaybackVolume(IntPtr self,uint effect_id, uint volume);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_get_effect_playback_volume", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int getEffectPlaybackVolume(IntPtr self,uint effect_id, ref uint volume);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_enable_earback", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int enableEarback(IntPtr self, bool enabled, uint volume);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_earback_volume", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setEarbackVolume(IntPtr self, uint volume);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_enable_loopback_recording", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int enableLoopbackRecording(IntPtr self,bool enabled,string device_name);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_adjust_loopback_recording_signal_volume", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int adjustLoopbackRecordingSignalVolume(IntPtr self, uint volume);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_stats_observer", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern void setStatsObserver(IntPtr self, IntPtr observer);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_enable_audio_volume_indication", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int enableAudioVolumeIndication(IntPtr self, bool enable, ulong interval);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_start_screen_capture_by_screen_rect", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int startScreenCaptureByScreenRect(IntPtr self,
                                                    ref RtcRectangle screen_rect,
                                                    ref RtcRectangle region_rect,
                                                    ref NativeScreenCaptureParameters capture_params);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_start_screen_capture_by_display_id", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int startScreenCaptureByDisplayId(IntPtr self,
                                                ulong display_id,
                                                ref RtcRectangle region_rect,
                                                ref NativeScreenCaptureParameters capture_params);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_start_screen_capture_by_window_id", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int startScreenCaptureByWindowId(IntPtr self,
                                                IntPtr window_id,
                                                ref RtcRectangle region_rect,
                                                ref NativeScreenCaptureParameters capture_params);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_start_screen_capture", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int startScreenCapture(IntPtr self,ref NativeScreenCaptureParameters capture_params,bool external_capturer);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_update_screen_capture_region", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int updateScreenCaptureRegion(IntPtr self,ref RtcRectangle region_rect);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_stop_screen_capture", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int stopScreenCapture(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_pause_screen_capture", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int pauseScreenCapture(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_resume_screen_capture", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int resumeScreenCapture(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_exclude_window_list", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setExcludeWindowList(IntPtr self,[MarshalAs(UnmanagedType.LPArray,SizeParamIndex = 2)]IntPtr[] window_list, int count);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_external_video_source", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setExternalVideoSource(IntPtr self, bool enabled);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_push_external_video_frame", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int pushExternalVideoFrame(IntPtr self, ref RtcExternalVideoFrame frame);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_push_substream_external_video_frame", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int pushSubstreamExternalVideoFrame(IntPtr self,ref RtcExternalVideoFrame video_frame);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_external_audio_source", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setExternalAudioSource(IntPtr self,bool enabled,int sample_rate,int channels);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_push_external_audio_frame", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int pushExternalAudioFrame(IntPtr self, ref RtcAudioFrame frame);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_external_audio_render", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setExternalAudioRender(IntPtr self,bool enabled,int sample_rate,int channels);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_pull_external_audio_frame", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int pullExternalAudioFrame(IntPtr self, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] data, int length);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_get_version", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern IntPtr getVersion(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_get_error_description", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern IntPtr getErrorDescription(IntPtr self, int error_code);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_upload_sdk_info", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int uploadSdkInfo(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_add_live_stream_task", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int addLiveStreamTask(IntPtr self,ref NativeLiveStreamTaskInfo info);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_update_live_stream_task", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int updateLiveStreamTask(IntPtr self,ref NativeLiveStreamTaskInfo info);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_remove_live_stream_task", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int removeLiveStreamTask(IntPtr self, string task_id);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_send_sei_msg", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int sendSEIMsg(IntPtr self, [MarshalAs(UnmanagedType.LPArray,SizeParamIndex = 2)] byte[] data,int length,int type);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_local_canvas_watermark_configs", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setLocalCanvasWatermarkConfigs(IntPtr self,int type, ref NativeCanvasWatermarkConfig config);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_remote_canvas_watermark_configs", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setRemoteCanvasWatermarkConfigs(IntPtr self,ulong uid,int type,ref NativeCanvasWatermarkConfig config);
        //[DllImport(NativeLib.Name, EntryPoint = "nertc_engine_take_local_snapshot", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        // protected static extern int takeLocalSnapshot(IntPtr self,
        //                                               int stream_type,
        //                                                NERtcTakeSnapshotCallback* callback);
        //[DllImport(NativeLib.Name, EntryPoint = "nertc_engine_take_remote_snapshot", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //protected static extern int takeRemoteSnapshot(IntPtr self,
        //                              ulong uid,
        //                              int stream_type,
        //                               NERtcTakeSnapshotCallback* callback);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_start_audio_recording", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int startAudioRecording(IntPtr self,string file_path,int sample_rate,int quality);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_stop_audio_recording", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int stopAudioRecording(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_adjust_recording_signal_volume", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int adjustRecordingSignalVolume(IntPtr self, int volume);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_adjust_playback_signal_volume", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int adjustPlaybackSignalVolume(IntPtr self, int volume);

        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_adjust_user_playback_signal_volume", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int adjustUserPlaybackSignalVolume(IntPtr self, ulong uid, int volume);

        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_start_channel_media_relay", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int startChannelMediaRelay(IntPtr self, ref NativeChannelMediaRelayConfig config);

        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_update_channel_media_relay", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int updateChannelMediaRelay(IntPtr self,ref NativeChannelMediaRelayConfig config);

        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_stop_channel_media_relay", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int stopChannelMediaRelay(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_local_publish_fallback_option", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setLocalPublishFallbackOption(IntPtr self,int option);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_remote_subscribe_fallback_option", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setRemoteSubscribeFallbackOption(IntPtr self,int option);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_enable_super_resolution", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int enableSuperResolution(IntPtr self, bool enable);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_enable_encryption", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int enableEncryption(IntPtr self, bool enable, ref RtcEncryptionConfig config);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_start_lastmile_probe_test", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int startLastmileProbeTest(IntPtr self,ref RtcLastmileProbeConfig config);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_stop_lastmile_probe_test", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int stopLastmileProbeTest(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_update_spatializer_audio_recv_range", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int updateSpatializerAudioRecvRange(IntPtr self,int audible_distance,int conversational_distance, int roll_off);

        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_update_spatializer_self_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int updateSpatializerSelfPosition(IntPtr self,ref RtcSpatializerPositionInfo info);

        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_enable_spatializer_room_effects", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int enableSpatializerRoomEffects(IntPtr self, bool enable);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_spatializer_room_property", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setSpatializerRoomProperty(IntPtr self, ref RtcSpatializerRoomProperty room_property);

        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_set_spatializer_render_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setSpatializerRenderMode(IntPtr self, int mode);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_enable_spatializer", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int enableSpatializer(IntPtr self, bool enable);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_enable_avatar", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int enableAvatar(IntPtr self, bool enable);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_convert_i420_to_rgba", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int convertI420ToRGBA(IntPtr src_y,int src_stride_y,IntPtr src_u,int src_stride_u,IntPtr src_v,int src_stride_v,IntPtr dst_rgba,int dst_stride_rgba,int width,int height);
        #endregion
    }
    public class IRtcChannelNative : IRtcNative
    {
        #region Channel Events
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onError(IntPtr self, int error_code, string msg);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onWarning(IntPtr self, int warn_code, string msg);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onReleasedHwResources(IntPtr self, int result);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onJoinChannel(IntPtr self, ulong cid, ulong uid, int result, ulong elapsed);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onReconnectingStart(IntPtr self, ulong cid, ulong uid);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onConnectionStateChange(IntPtr self, int state, int reason);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onRejoinChannel(IntPtr self, ulong cid, ulong uid, int result, ulong elapsed);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onLeaveChannel(IntPtr self, int result);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onDisconnect(IntPtr self, int reason);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onClientRoleChanged(IntPtr self, int oldRole, int newRole);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserJoined(IntPtr self, ulong uid, string user_name);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserLeft(IntPtr self, ulong uid, int reason);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserAudioStart(IntPtr self, ulong uid);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserAudioStop(IntPtr self, ulong uid);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserAudioMute(IntPtr self, ulong uid, bool mute);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserVideoStart(IntPtr self, ulong uid, int max_profile);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserVideoStop(IntPtr self, ulong uid);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserVideoMute(IntPtr self, ulong uid, bool mute);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserSubStreamVideoStart(IntPtr self, ulong uid, int max_profile);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUserSubStreamVideoStop(IntPtr self, ulong uid);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onScreenCaptureStatusChanged(IntPtr self, int status);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onFirstAudioDataReceived(IntPtr self, ulong uid);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onFirstVideoDataReceived(IntPtr self, ulong uid);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onFirstAudioFrameDecoded(IntPtr self, ulong uid);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onFirstVideoFrameDecoded(IntPtr self, ulong uid, uint width, uint height);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onLocalAudioVolumeIndication(IntPtr self, int volume);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onRemoteAudioVolumeIndication(IntPtr self, IntPtr speakers, uint speaker_number, int total_volume);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onAddLiveStreamTask(IntPtr self, string task_id, string url, int error_code);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onUpdateLiveStreamTask(IntPtr self, string task_id, string url, int error_code);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onRemoveLiveStreamTask(IntPtr self, string task_id, int error_code);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onLiveStreamStateChanged(IntPtr self, string task_id, string url, int state);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onRecvSEIMessage(IntPtr self, ulong uid, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]byte[] data, uint dataSize);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onMediaRelayStateChanged(IntPtr self, int state, string channel_name);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onMediaRelayEvent(IntPtr self, int evt, string channel_name, int error);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onPublishFallbackToAudioOnly(IntPtr self, bool is_fallback, int stream_type);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onSubscribeFallbackToAudioOnly(IntPtr self, ulong uid, bool is_fallback, int stream_type);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onAvatarUserJoined(IntPtr self, ulong src_uid, ulong uid, string user_name);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onAvatarUserLeft(IntPtr self, ulong src_uid, ulong uid, int reason);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate void onAvatarStatus(IntPtr self, bool enable, int error_code);
        #endregion

        #region Native Structs
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        protected struct NativeChannelEnvent
        {
            public IntPtr self;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onError onError;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onWarning onWarning;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onReleasedHwResources onReleasedHwResources;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onJoinChannel onJoinChannel;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onReconnectingStart onReconnectingStart;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onConnectionStateChange onConnectionStateChange;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onRejoinChannel onRejoinChannel;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onLeaveChannel onLeaveChannel;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onDisconnect onDisconnect;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onClientRoleChanged onClientRoleChanged;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserJoined onUserJoined;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserLeft onUserLeft;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserAudioStart onUserAudioStart;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserAudioStop onUserAudioStop;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserAudioMute onUserAudioMute;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserVideoStart onUserVideoStart;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserVideoStop onUserVideoStop;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserVideoMute onUserVideoMute;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserSubStreamVideoStart onUserSubStreamVideoStart;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUserSubStreamVideoStop onUserSubStreamVideoStop;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onScreenCaptureStatusChanged onScreenCaptureStatusChanged;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onFirstAudioDataReceived onFirstAudioDataReceived;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onFirstVideoDataReceived onFirstVideoDataReceived;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onFirstAudioFrameDecoded onFirstAudioFrameDecoded;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onFirstVideoFrameDecoded onFirstVideoFrameDecoded;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onLocalAudioVolumeIndication onLocalAudioVolumeIndication;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onRemoteAudioVolumeIndication onRemoteAudioVolumeIndication;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onAddLiveStreamTask onAddLiveStreamTask;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onUpdateLiveStreamTask onUpdateLiveStreamTask;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onRemoveLiveStreamTask onRemoveLiveStreamTask;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onLiveStreamStateChanged onLiveStreamStateChanged;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onRecvSEIMessage onRecvSEIMessage;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onMediaRelayStateChanged onMediaRelayStateChanged;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onMediaRelayEvent onMediaRelayEvent;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onPublishFallbackToAudioOnly onPublishFallbackToAudioOnly;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onSubscribeFallbackToAudioOnly onSubscribeFallbackToAudioOnly;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onAvatarUserJoined onAvatarUserJoined;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onAvatarUserLeft onAvatarUserLeft;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public onAvatarStatus onAvatarStatus;
        }
        #endregion

        #region Channel API
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_get_engine", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern IntPtr getEngine(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_destroy", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern void destroy(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_get_channel_name", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern IntPtr getChannelName(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_set_channel_event_handler", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setChannelEventHandler(IntPtr self, ref NativeChannelEnvent handler);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_join_channel", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int joinChannel(IntPtr self, string token, ulong uid);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_leave_channel", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int leaveChannel(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_set_stats_observer", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setStatsObserver(IntPtr self, IntPtr observer);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_enable_local_audio", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int enableLocalAudio(IntPtr self, bool enabled);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_mute_local_audio_stream", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int muteLocalAudioStream(IntPtr self, bool mute);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_enable_local_video", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int enableLocalVideo(IntPtr self, bool enabled);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_mute_local_video_stream", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int muteLocalVideoStream(IntPtr self, bool mute);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_start_screen_capture_by_screen_rect", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int startScreenCaptureByScreenRect(IntPtr self,
                                                    ref RtcRectangle screen_rect,
                                                    ref RtcRectangle region_rect,
                                                    ref NativeScreenCaptureParameters capture_params);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_start_screen_capture_by_display_id", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int startScreenCaptureByDisplayId(IntPtr self,
                                                ulong display_id,
                                                ref RtcRectangle region_rect,
                                                ref NativeScreenCaptureParameters capture_params);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_start_screen_capture_by_window_id", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int startScreenCaptureByWindowId(IntPtr self,
                                                IntPtr window_id,
                                                ref RtcRectangle region_rect,
                                                ref NativeScreenCaptureParameters capture_params);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_start_screen_capture", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int startScreenCapture(IntPtr self, ref NativeScreenCaptureParameters capture_params, bool external_capturer);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_update_screen_capture_region", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int updateScreenCaptureRegion(IntPtr self, ref RtcRectangle region_rect);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_stop_screen_capture", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int stopScreenCapture(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_pause_screen_capture", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int pauseScreenCapture(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_resume_screen_capture", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int resumeScreenCapture(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_set_exclude_window_list", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setExcludeWindowList(IntPtr self, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]IntPtr[] window_list, int count);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_setup_local_video_canvas", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setupLocalVideoCanvas(IntPtr self, IntPtr canvas);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_setup_local_sub_stream_video_canvas", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setupLocalSubstreamVideoCanvas(IntPtr self, IntPtr canvas);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_set_local_render_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setLocalRenderMode(IntPtr self, int scaling_mode);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_set_local_sub_stream_render_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setLocalSubstreamRenderMode(IntPtr self, int scaling_mode);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_set_local_video_mirror_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setLocalVideoMirrorMode(IntPtr self, int mirror_mode);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_setup_remote_video_canvas", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setupRemoteVideoCanvas(IntPtr self, ulong uid, IntPtr canvas);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_setup_remote_sub_stream_video_canvas", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setupRemoteSubstreamVideoCanvas(IntPtr self, ulong uid, IntPtr canvas);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_set_remote_render_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setRemoteRenderMode(IntPtr self, ulong uid, int scaling_mode);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_set_remote_sub_stream_render_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setRemoteSubsteamRenderMode(IntPtr self, ulong uid, int scaling_mode);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_set_client_role", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setClientRole(IntPtr self, int role);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_set_local_media_priority", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setLocalMediaPriority(IntPtr self, int priority, bool is_preemptive);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_get_connection_state", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int getConnectionState(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_set_camera_capture_config", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setCameraCaptureConfig(IntPtr self, ref RtcCameraCaptureConfig config);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_subscribe_all_remote_audio_stream", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int subscribeAllRemoteAudioStream(IntPtr self, bool subscribe);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_set_video_config", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setVideoConfig(IntPtr self, ref RtcVideoConfig config);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_enable_dual_stream_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int enableDualStreamMode(IntPtr self, bool enable);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_subscribe_remote_audio_stream", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int subscribeRemoteAudioStream(IntPtr self, ulong uid, bool subscribe);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_subscribe_remote_video_stream", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int subscribeRemoteVideoStream(IntPtr self, ulong uid, int type, bool subscribe);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_subscribe_remote_video_sub_stream", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int subscribeRemoteVideoSubstream(IntPtr self, ulong uid, bool subscribe);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_add_live_stream_task", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int addLiveStreamTask(IntPtr self, ref NativeLiveStreamTaskInfo info);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_update_live_stream_task", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int updateLiveStreamTask(IntPtr self, ref NativeLiveStreamTaskInfo info);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_remove_live_stream_task", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int removeLiveStreamTask(IntPtr self, string task_id);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_send_sei_msg", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int sendSEIMsg(IntPtr self, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] data, int length, int type);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_set_local_canvas_watermark_configs", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setLocalCanvasWatermarkConfigs(IntPtr self, int type, ref NativeCanvasWatermarkConfig config);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_set_remote_canvas_watermark_configs", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setRemoteCanvasWatermarkConfigs(IntPtr self, ulong uid, int type, ref NativeCanvasWatermarkConfig config);
        //[DllImport(NativeLib.Name, EntryPoint = "nertc_channel_take_local_snapshot", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        // protected static extern int takeLocalSnapshot(IntPtr self,NERtcVideoStreamType stream_type, NERtcTakeSnapshotCallback* callback);
        //[DllImport(NativeLib.Name, EntryPoint = "nertc_channel_take_remote_snapshot", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        // protected static extern int takeRemoteSnapshot(IntPtr self,ulong uid, NERtcVideoStreamType stream_type, NERtcTakeSnapshotCallback* callback);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_adjust_recording_signal_volume", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int adjustRecordingSignalVolume(IntPtr self, int volume);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_adjust_playback_signal_volume", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int adjustPlaybackSignalVolume(IntPtr self, int volume);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_adjust_user_playback_signal_volume", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int adjustUserPlaybackSignalVolume(IntPtr self, ulong uid, int volume);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_start_channel_media_relay", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int startChannelMediaRelay(IntPtr self, ref NativeChannelMediaRelayConfig config);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_update_channel_media_relay", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int updateChannelMediaRelay(IntPtr self, ref NativeChannelMediaRelayConfig config);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_stop_channel_media_relay", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int stopChannelMediaRelay(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_set_local_publish_fallback_option", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setLocalPublishFallbackOption(IntPtr self, int option);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_set_remote_subscribe_fallback_option", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setRemoteSubscribeFallbackOption(IntPtr self, int option);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_set_external_video_source", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setExternalVideoSource(IntPtr self, bool enabled);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_push_external_video_frame", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int pushExternalVideoFrame(IntPtr self, ref RtcExternalVideoFrame frame);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_push_substream_external_video_frame", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int pushSubstreamExternalVideoFrame(IntPtr self, ref RtcExternalVideoFrame video_frame);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_enable_spatializer", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int enableSpatializer(IntPtr self, bool enable);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_channel_enable_avatar", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int enableAvatar(IntPtr self, bool enable);

        #endregion

    }
    public class IDeviceCollectionNative
    {
        [DllImport(NativeLib.Name, EntryPoint = "nertc_device_collection_get_count", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern ushort getCount(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_device_collection_get_device", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int getDevice(IntPtr self, ushort index, [MarshalAs(UnmanagedType.LPStr, SizeConst = 256)]StringBuilder device_name, [MarshalAs(UnmanagedType.LPStr, SizeConst = 256)]StringBuilder device_id);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_device_collection_get_device_info", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int getDeviceInfo(IntPtr self, ushort index, ref RtcDeviceInfo device_info);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_device_collection_destroy", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern void destroy(IntPtr self);
    }
    public class IVideoDeviceNative
    {
        [DllImport(NativeLib.Name, EntryPoint = "nertc_video_device_manager_enumerate_capture_devices", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern IntPtr enumerateCaptureDevices(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_video_device_manager_set_device", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setDevice(IntPtr self, string device_id);

        [DllImport(NativeLib.Name, EntryPoint = "nertc_video_device_manager_get_device", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int getDevice(IntPtr self, [MarshalAs(UnmanagedType.LPStr, SizeConst = 256)]StringBuilder device_id);

    }
    public class IAudioDeviceNative
    {
        [DllImport(NativeLib.Name, EntryPoint = "nertc_audio_device_manager_enumerate_record_devices", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern IntPtr enumerateRecordDevices(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_audio_device_manager_set_record_device", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setRecordDevice(IntPtr self, string device_id);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_audio_device_manager_get_record_device", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int getRecordDevice(IntPtr self, [MarshalAs(UnmanagedType.LPStr, SizeConst = 256)]StringBuilder device_id);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_audio_device_manager_enumerate_playout_devices", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern IntPtr enumeratePlayoutDevices(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_audio_device_manager_set_playout_device", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setPlayoutDevice(IntPtr self, string device_id);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_audio_device_manager_get_playout_device", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int getPlayoutDevice(IntPtr self, [MarshalAs(UnmanagedType.LPStr, SizeConst = 256)]StringBuilder device_id);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_audio_device_manager_set_record_device_volume", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setRecordDeviceVolume(IntPtr self, uint volume);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_audio_device_manager_get_record_device_volume", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int getRecordDeviceVolume(IntPtr self, ref uint volume);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_audio_device_manager_set_playout_device_volume", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setPlayoutDeviceVolume(IntPtr self, uint volume);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_audio_device_manager_get_playout_device_volume", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int getPlayoutDeviceVolume(IntPtr self, ref uint volume);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_audio_device_manager_set_playout_device_mute", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setPlayoutDeviceMute(IntPtr self, bool mute);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_audio_device_manager_get_playout_device_mute", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int getPlayoutDeviceMute(IntPtr self, ref bool mute);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_audio_device_manager_set_record_device_mute", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int setRecordDeviceMute(IntPtr self, bool mute);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_audio_device_manager_get_record_device_mute", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int getRecordDeviceMute(IntPtr self, ref bool mute);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_audio_device_manager_start_record_device_test", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int startRecordDeviceTest(IntPtr self, ulong indication_interval);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_audio_device_manager_stop_record_device_test", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int stopRecordDeviceTest(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_audio_device_manager_start_playout_device_test", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int startPlayoutDeviceTest(IntPtr self, string test_audio_file_path);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_audio_device_manager_stop_playout_device_test", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int stopPlayoutDeviceTest(IntPtr self);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_audio_device_manager_start_audio_device_loopback_test", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int startAudioDeviceLoopbackTest(IntPtr self, ulong indication_interval);
        [DllImport(NativeLib.Name, EntryPoint = "nertc_audio_device_manager_stop_audio_device_loopback_test", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        protected static extern int stopAudioDeviceLoopbackTest(IntPtr self);
    }
    public class IYuvUtilNative
    {
        [DllImport(NativeLib.Name, EntryPoint = "nertc_engine_convert_i420_to_rgba", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int convertI420ToRgba(IntPtr src_y, int src_stride_y,IntPtr src_u, int src_stride_u,IntPtr src_v, int src_stride_v,IntPtr dst_rgba, int dst_stride_rgba,int width, int height);
    }
}
