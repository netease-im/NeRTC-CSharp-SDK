using System;
using System.Runtime.InteropServices;

namespace nertc
{
    /**
    * @if English
    * The SDK reports stats to the application through IRtcMediaStatsObserver expansion callback interface class.
    * <br>All methods in this interface class have their (empty) default implementations, and the application can inherit only some
    * of the required events instead of all of them. When calling a callback method, the application must not implement
    * time-consuming operations or call blocking-triggered APIs. For example, if you want to enable audio and video, the SDK may be
    * affected in the runtime.
    * @endif
    * @if Chinese
    * IRtcMediaStatsObserver 回调扩展接口类用于 SDK 向 App 上报统计信息。
    * <br>接口类的所有方法都有缺省（空）实现，App 可以根据需要只继承关心的事件。在回调方法中，App
    * 不应该做耗时或者调用可能会引起阻塞的 API（如开启音频或视频等），否则可能影响 SDK 的运行。
    * @endif
    */
    public interface IMediaStatsObserver
    {
        /**
        * @if English
        * Callback for stats of the current call.
        * SDK regularly reports the statistics of the current call to the app every 2 seconds.
        * @param channelOrEngine The curren IRtcChannel object or IRtcEngine object.
        * @param stats NERTC Engine statistics: nertc_stats
        * @endif
        * @if Chinese 
        * 当前通话统计回调。
        * SDK 定期向 App 报告当前通话的统计信息，每 2 秒触发一次。
        * @param channelOrEngine 当前的 IRtcChannel 对象或 IRtcEngine 对象。
        * @param stats NERTC 引擎统计数据: nertc_stats
        * @endif
        */
        void OnRtcStats(object channelOrEngine, RtcStats stats);

        /**
        * @if English
        * Callback for stats of the local audio stream.
        * The callback returns stats of the local publishing audio stream every 2 seconds.
        * @param channelOrEngine The curren IRtcChannel object or IRtcEngine object.
        * @param stats Local audio stream stats. See nertc_audio_send_stats.
        * @endif
        * @if Chinese 
        * 本地音频流统计信息回调。
        * 该回调描述本地设备发送音频流的统计信息，每 2 秒触发一次。
        * @param channelOrEngine 当前的 IRtcChannel 对象或 IRtcEngine 对象。
        * @param stats 本地音频流统计信息。详见 nertc_audio_send_stats.
        * @endif
        */
        void OnLocalAudioStats(object channelOrEngine, RtcAudioSendStats stats);

        /**
        * @if English
        * Callback for stats of remote audio stream in the call。
        * The callback returns the stats of the remote audio stream in the call every 2 seconds.
        * @param channelOrEngine The curren IRtcChannel object or IRtcEngine object.
        * @param stats array containing audio stream stats of each remote user. See nertc_audio_recv_stats.
        * @endif
        * @if Chinese 
        * 通话中远端音频流的统计信息回调。
        * 该回调描述远端用户在通话中端到端的音频流统计信息，每 2 秒触发一次。
        * @param channelOrEngine 当前的 IRtcChannel 对象或 IRtcEngine 对象。
        * @param stats 每个远端用户音频统计信息的数组。详见 nertc_audio_recv_stats.
        * @endif
        */
        void OnRemoteAudioStats(object channelOrEngine, RtcAudioRecvStats[] stats);

        /**
        * @if English
        * Callback for the stats of the local video stream.
        *
        * The callback returns stats of the local publishing video stream every 2 seconds.
        * @param channelOrEngine The curren IRtcChannel object or IRtcEngine object.
        * @param stats Local video stream stats.See nertc_video_send_stats.
        * @endif
        * @if Chinese 
        * 本地视频流统计信息回调。
        *
        * 该回调描述本地设备发送视频流的统计信息，每 2 秒触发一次。
        * @param channelOrEngine 当前的 IRtcChannel 对象或 IRtcEngine 对象。
        * @param stats 本地视频流统计信息。详见 nertc_video_send_stats.
        * @endif
        */
        void OnLocalVideoStats(object channelOrEngine, RtcVideoSendStats stats);

        /**
        * @if English
        * Callback for stats of remote video stream in the call。
        * The callback returns the stats of the remote video stream in the call every 2 seconds.
        * @param channelOrEngine The curren IRtcChannel object or IRtcEngine object.
        * @param stats array containing video stream stats of each remote user.See nertc_video_recv_stats.
        * @endif
        * @if Chinese 
        * 通话中远端视频流的统计信息回调。
        *
        * 该回调描述远端用户在通话中端到端的视频流统计信息，每 2 秒触发一次。
        * @param channelOrEngine 当前的 IRtcChannel 对象或 IRtcEngine 对象。
        * @param stats 每个远端用户视频统计信息的数组。详见 nertc_video_recv_stats.
        * @endif
        */
        void OnRemoteVideoStats(object channelOrEngine, RtcVideoRecvStats[] stats);

        /**
        * @if English
        * Callback for the network quality of each user.
        * The callback returns the network status of each user in the call every 2 seconds, and only reports the members whose network status has changed.
        * @param channelOrEngine The curren IRtcChannel object or IRtcEngine object.
        * @param infos The array of each user ID and network upstream and downstream quality information: nertc_network_quality_info
        * @endif
        * @if Chinese 
        * 通话中每个用户的网络上下行质量报告回调。
        * 该回调描述每个用户在通话中的网络状态，每 2 秒触发一次，只上报状态有变更的成员。
        * @param channelOrEngine 当前的 IRtcChannel 对象或 IRtcEngine 对象。
        * @param infos 每个用户 ID 和网络上下行质量信息的数组: nertc_network_quality_info
        * @endif
        */
        void OnNetworkQuality(object channelOrEngine, RtcNetworkQualityInfo[] infos);
    }

    internal partial class RtcEngine
    {
        #region Bind Event
        private NativeMediaStatsObserver BindMediaStatsEvent(IntPtr nativeEngine)
        {
            return new NativeMediaStatsObserver
            {
                self = nativeEngine,
                onRtcStats = _onRtcStatsHandler,
                onLocalAudioStats = _onLocalAudioStatsHandler,
                onRemoteAudioStats = _onRemoteAudioStatsHandler,
                onLocalVideoStats = _onLocalVideoStatsHandler,
                onRemoteVideoStats = _onRemoteVideoStatsHandler,
                onNetworkQuality = _onNetworkQualityHandler,
            };
        }
        #endregion
        #region Media Stats Events
        static onRtcStats _onRtcStatsHandler = OnRtcStatsHandler;
        [MonoPInvokeCallback(typeof(onRtcStats))]
        static void OnRtcStatsHandler(IntPtr self, IntPtr stats)
        {
            var rtcEngine = GetEngineFromNative(self);
            var rtcStats = Marshal.PtrToStructure<RtcStats>(stats);
            rtcEngine?._mediaStatsObserver?.OnRtcStats(rtcEngine, rtcStats);
        }

        static onLocalAudioStats _onLocalAudioStatsHandler = OnLocalAudioStatsHandler;
        [MonoPInvokeCallback(typeof(onLocalAudioStats))]
        static void OnLocalAudioStatsHandler(IntPtr self, IntPtr stats)
        {
            var rtcEngine = GetEngineFromNative(self);
            var rtcStats = Marshal.PtrToStructure<RtcAudioSendStats>(stats);
            rtcEngine?._mediaStatsObserver?.OnLocalAudioStats(rtcEngine, rtcStats);
        }

        static onRemoteAudioStats _onRemoteAudioStatsHandler = OnRemoteAudioStatsHandler;
        [MonoPInvokeCallback(typeof(onRemoteAudioStats))]
        static void OnRemoteAudioStatsHandler(IntPtr self, IntPtr stats, uint user_count)
        {
            var rtcEngine = GetEngineFromNative(self);
            var rtcStats = MarshalExtension.PtrToStructureArray<RtcAudioRecvStats>(stats, user_count);
            rtcEngine?._mediaStatsObserver?.OnRemoteAudioStats(rtcEngine, rtcStats);
        }

        static onLocalVideoStats _onLocalVideoStatsHandler = OnLocalVideoStatsHandler;
        [MonoPInvokeCallback(typeof(onLocalVideoStats))]
        static void OnLocalVideoStatsHandler(IntPtr self, ref NativeVideoSendStats stats)
        {
            var rtcEngine = GetEngineFromNative(self);
            var rtcStats = new RtcVideoSendStats();
            rtcStats.videoLayersList = MarshalExtension.PtrToStructureArray<RtcVideoLayerSendStats>(stats.videoLayersList, (uint)stats.videoLayersCount);
            rtcEngine?._mediaStatsObserver?.OnLocalVideoStats(rtcEngine, rtcStats);
        }

        static onRemoteVideoStats _onRemoteVideoStatsHandler = OnRemoteVideoStatsHandler;
        [MonoPInvokeCallback(typeof(onRemoteVideoStats))]
        static void OnRemoteVideoStatsHandler(IntPtr self, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]NativeVideoRecvStats[] stats, uint user_count)
        {
            var rtcEngine = GetEngineFromNative(self);
            RtcVideoRecvStats[] rtcStats = null;
            if (user_count > 0)
            {
                rtcStats = new RtcVideoRecvStats[user_count];
                for (int idx = 0; idx < user_count; idx++)
                {
                    rtcStats[idx].uid = stats[idx].uid;
                    rtcStats[idx].videoLayersList = MarshalExtension.PtrToStructureArray<RtcVideoLayerRecvStats>(stats[idx].videoLayersList, (uint)stats[idx].videoLayersCount);
                }
            }
            rtcEngine?._mediaStatsObserver?.OnRemoteVideoStats(rtcEngine, rtcStats);
        }

        static onNetworkQuality _onNetworkQualityHandler = OnNetworkQualityHandler;
        [MonoPInvokeCallback(typeof(onNetworkQuality))]
        static void OnNetworkQualityHandler(IntPtr self, IntPtr infos, uint user_count)
        {
            var rtcEngine = GetEngineFromNative(self);
            var rtcStats = MarshalExtension.PtrToStructureArray<RtcNetworkQualityInfo>(infos, user_count);
            rtcEngine?._mediaStatsObserver?.OnNetworkQuality(rtcEngine, rtcStats);
        }

        #endregion
    }
    internal partial class RtcChannel
    {
        #region Bind Event
        private NativeMediaStatsObserver BindMediaStatsEvent(IntPtr nativeEngine)
        {
            return new NativeMediaStatsObserver
            {
                self = nativeEngine,
                onRtcStats = _onRtcStatsHandler,
                onLocalAudioStats = _onLocalAudioStatsHandler,
                onRemoteAudioStats = _onRemoteAudioStatsHandler,
                onLocalVideoStats = _onLocalVideoStatsHandler,
                onRemoteVideoStats = _onRemoteVideoStatsHandler,
                onNetworkQuality = _onNetworkQualityHandler,
            };
        }
        #endregion

        internal static RtcChannel GetChannelFromNative(IntPtr self)
        {
            IntPtr nativeEngine = IRtcChannelNative.getEngine(self);
            IntPtr name = IRtcChannelNative.getChannelName(self);
            string channelName = Marshal.PtrToStringAnsi(name);

            var rtcEngine = RtcEngine.GetEngineFromNative(nativeEngine);
            return rtcEngine.GetChannel(channelName) as RtcChannel;
        }
        #region Media Stats Events
        static onRtcStats _onRtcStatsHandler = OnRtcStatsHandler;
        [MonoPInvokeCallback(typeof(onRtcStats))]
        static void OnRtcStatsHandler(IntPtr self, IntPtr stats)
        {
            var rtcChannel = GetChannelFromNative(self);
            var rtcStats = Marshal.PtrToStructure<RtcStats>(stats);
            rtcChannel?._mediaStatsObserver?.OnRtcStats(rtcChannel, rtcStats);
        }

        static onLocalAudioStats _onLocalAudioStatsHandler = OnLocalAudioStatsHandler;
        [MonoPInvokeCallback(typeof(onLocalAudioStats))]
        static void OnLocalAudioStatsHandler(IntPtr self, IntPtr stats)
        {
            var rtcChannel = GetChannelFromNative(self);
            var rtcStats = Marshal.PtrToStructure<RtcAudioSendStats>(stats);
            rtcChannel?._mediaStatsObserver?.OnLocalAudioStats(rtcChannel, rtcStats);
        }

        static onRemoteAudioStats _onRemoteAudioStatsHandler = OnRemoteAudioStatsHandler;
        [MonoPInvokeCallback(typeof(onRemoteAudioStats))]
        static void OnRemoteAudioStatsHandler(IntPtr self, IntPtr stats, uint user_count)
        {
            var rtcChannel = GetChannelFromNative(self);
            var rtcStats = MarshalExtension.PtrToStructureArray<RtcAudioRecvStats>(stats, user_count);
            rtcChannel?._mediaStatsObserver?.OnRemoteAudioStats(rtcChannel, rtcStats);
        }

        static onLocalVideoStats _onLocalVideoStatsHandler = OnLocalVideoStatsHandler;
        [MonoPInvokeCallback(typeof(onLocalVideoStats))]
        static void OnLocalVideoStatsHandler(IntPtr self, ref NativeVideoSendStats stats)
        {
            var rtcChannel = GetChannelFromNative(self);
            var rtcStats = new RtcVideoSendStats();
            rtcStats.videoLayersList = MarshalExtension.PtrToStructureArray<RtcVideoLayerSendStats>(stats.videoLayersList, (uint)stats.videoLayersCount);
            rtcChannel?._mediaStatsObserver?.OnLocalVideoStats(rtcChannel, rtcStats);
        }

        static onRemoteVideoStats _onRemoteVideoStatsHandler = OnRemoteVideoStatsHandler;
        [MonoPInvokeCallback(typeof(onRemoteVideoStats))]
        static void OnRemoteVideoStatsHandler(IntPtr self, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]NativeVideoRecvStats[] stats, uint user_count)
        {
            var rtcChannel = GetChannelFromNative(self);
            RtcVideoRecvStats[] rtcStats = null;
            if (user_count > 0)
            {
                rtcStats = new RtcVideoRecvStats[user_count];
                for (int idx = 0; idx < user_count; idx++)
                {
                    rtcStats[idx].uid = stats[idx].uid;
                    rtcStats[idx].videoLayersList = MarshalExtension.PtrToStructureArray<RtcVideoLayerRecvStats>(stats[idx].videoLayersList, (uint)stats[idx].videoLayersCount);
                }
            }
            rtcChannel?._mediaStatsObserver?.OnRemoteVideoStats(rtcChannel, rtcStats);
        }

        static onNetworkQuality _onNetworkQualityHandler = OnNetworkQualityHandler;
        [MonoPInvokeCallback(typeof(onNetworkQuality))]
        static void OnNetworkQualityHandler(IntPtr self, IntPtr infos, uint user_count)
        {
            var rtcChannel = GetChannelFromNative(self);
            var rtcStats = MarshalExtension.PtrToStructureArray<RtcNetworkQualityInfo>(infos, user_count);
            rtcChannel?._mediaStatsObserver?.OnNetworkQuality(rtcChannel, rtcStats);
        }

        #endregion
    }

}
