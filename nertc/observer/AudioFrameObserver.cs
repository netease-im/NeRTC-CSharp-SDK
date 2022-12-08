using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace nertc
{
    /**
    * @if English
    * The voice observer object.
    * <br>Some APIs allow you to modify the content that data points to in the frame. However, you cannot modify the format.
    * If you need to modify the format, you must call the corresponding setting interface.
    * @endif
    * @if Chinese
    * 语音观测器对象。
    * <br>部分接口允许修改 frame 里 data 所指向的内容，但不允许修改 format。如果对 format 有要求，需调用相应设置接口。
    * @endif
    */
    public interface IAudioFrameObserver
    {
        /**
        * @if English
        * Callback called when audio data is captured.
        * @note
        * - Captured audio data supports read/write
        * - Callback is triggered when local audio data is captured
        * @param frame Audio frame.
        * @endif
        * @if Chinese 
        * 采集音频数据回调。
        * @note
        * - 返回音频数据支持读/写
        * - 有本地音频数据驱动就会回调
        * @param frame 音频帧。
        * @endif
        */
        void OnAudioFrameDidRecord(RtcAudioFrame frame);
        /**
        * @if English
        * Callback called when audio data is playing.    
        * @note
        * - Captured audio data supports read/write
        * - Callback is triggered when local audio data is captured
        * @param frame Audio frame.     
        * @endif
        * @if Chinese 
        * 播放音频数据回调。    
        * @note
        * - 返回音频数据支持读/写
        * - 有本地音频数据驱动就会回调
        * @param frame 音频帧。
        * @endif
        */
        void OnAudioFrameWillPlayback(RtcAudioFrame frame);
        /**
        * @if English
        * Callback called when captured audio data is mixed.
        * @note
        * - Captured audio data supports read-only
        * - Callback is triggered when local audio data is captured
        * @param frame Audio frame.
        * @endif
        * @if Chinese 
        * 混合采集后的音频数据回调。
        * @note
        * - 返回音频数据只读
        * - 有本地音频数据驱动就会回调
        * @param frame 音频帧。
        * @endif
        */
        void OnMixedAudioFrame(RtcAudioFrame frame);
        /**
        * @if English
        * Gets the raw audio data of a specified remote user before audio mixing.
        * <br>After the audio observer is registered, if the remote audio is subscribed by default and the remote user
        * enables the audio, the SDK triggers this callback when the audio data before audio mixing is captured, and the
        * audio data is returned to the user.
        * @note The returned audio data is read-only.
        * @since V4.5.0
        * @param userId    The ID of a remote user.
        * @param frame     The audio frame.
        * @param cid       The ID of the channel. In multi-channel scenarios, channelId is used to identify different channels.
        * @endif
        * @if Chinese
        * 获取单个远端用户混音前的音频数据。
        * <br>成功注册音频观测器后，如果订阅了远端音频（默认订阅）且远端用户开启音频后，SDK会在捕捉到混音前的音频数据时，触发该回调，将音频数据回调给用户。
        * @note 返回的音频数据只读。
        * @since V4.5.0
        * @param userID    用户 ID。
        * @param frame     音频帧。
        * @param cid       房间 ID。在多房间场景下，cid 用于识别不同的房间。
        * @endif
        */
        void OnPlaybackAudioFrameBeforeMixing(ulong userId, RtcAudioFrame frame, ulong cid);
    }

    internal partial class RtcEngine
    {
        #region Bind AudioFrame Observer 
        private NativeAudioFrameObserver BindAudioFrameObserverEvent(IntPtr nativeEngine)
        {
            return new NativeAudioFrameObserver
            {
                self = nativeEngine,
                onAudioFrameDidRecord = _onAudioFrameDidRecordHandler,
                onAudioFrameWillPlayback = _onAudioFrameWillPlaybackHandler,
                onMixedAudioFrame = _onMixedAudioFrameHandler,
                onPlaybackAudioFrameBeforeMixing = _onPlaybackAudioFrameBeforeMixingHandler,
            };
        }
        #endregion
        #region AudioFrameObserver
        static onAudioFrameDidRecord _onAudioFrameDidRecordHandler = OnAudioFrameDidRecordHandler;
        [MonoPInvokeCallback(typeof(onAudioFrameDidRecord))]
        static void OnAudioFrameDidRecordHandler(IntPtr self, IntPtr frame)
        {
            var rtcEngine = GetEngineFromNative(self);
            var audioFrame = Marshal.PtrToStructure<RtcAudioFrame>(frame);
            rtcEngine?._audioFrameObserver?.OnAudioFrameDidRecord(audioFrame);
        }

        static onAudioFrameWillPlayback _onAudioFrameWillPlaybackHandler = OnAudioFrameWillPlaybackHandler;
        [MonoPInvokeCallback(typeof(onAudioFrameWillPlayback))]
        static void OnAudioFrameWillPlaybackHandler(IntPtr self, IntPtr frame)
        {
            var rtcEngine = GetEngineFromNative(self);
            var audioFrame = Marshal.PtrToStructure<RtcAudioFrame>(frame);
            rtcEngine?._audioFrameObserver?.OnAudioFrameWillPlayback(audioFrame);
        }

        static onMixedAudioFrame _onMixedAudioFrameHandler = OnMixedAudioFrameHandler;
        [MonoPInvokeCallback(typeof(onMixedAudioFrame))]
        static void OnMixedAudioFrameHandler(IntPtr self, IntPtr frame)
        {
            var rtcEngine = GetEngineFromNative(self);
            var audioFrame = Marshal.PtrToStructure<RtcAudioFrame>(frame);
            rtcEngine?._audioFrameObserver?.OnMixedAudioFrame(audioFrame);
        }

        static onPlaybackAudioFrameBeforeMixing _onPlaybackAudioFrameBeforeMixingHandler = OnPlaybackAudioFrameBeforeMixingHandler;
        [MonoPInvokeCallback(typeof(onPlaybackAudioFrameBeforeMixing))]
        static void OnPlaybackAudioFrameBeforeMixingHandler(IntPtr self, ulong user_id, IntPtr frame, ulong cid)
        {
            var rtcEngine = GetEngineFromNative(self);
            var audioFrame = Marshal.PtrToStructure<RtcAudioFrame>(frame);
            rtcEngine?._audioFrameObserver?.OnPlaybackAudioFrameBeforeMixing(user_id, audioFrame,cid);
        }

        #endregion
    }

}
