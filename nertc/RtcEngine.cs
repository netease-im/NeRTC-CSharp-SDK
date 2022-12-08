using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Linq;

namespace nertc
{
    /**
     * @if English
     * RtcEngine class provides main interface-related methods for applications to call.
     * and you can activate the communication feature the NERTC SDK provides.
     * @endif
     * @if Chinese
     * RtcEngine 类提供了供 App 调用的主要接口方法。
     * @endif
     */
    public abstract class IRtcEngine : IRtcEngineNative
    {
        /**
        * @if English
        * All Engine Events.
        * @endif
        * @if Chinese
        * 所有的Engine事件
        * @endif
        */
        #region Engine Events
        public OnError OnError;
        public OnWarning OnWarning;
        public OnReleasedHwResources OnReleasedHwResources;
        public OnJoinChannel OnJoinChannel;
        public OnReconnectingStart OnReconnectingStart;
        public OnConnectionStateChange OnConnectionStateChange;
        public OnNetworkTypeChanged OnNetworkTypeChanged;
        public OnRejoinChannel OnRejoinChannel;
        public OnLeaveChannel OnLeaveChannel;
        public OnDisconnect OnDisconnect;
        public OnClientRoleChanged OnClientRoleChanged;
        public OnUserJoined OnUserJoined;
        public OnUserLeft OnUserLeft;
        public OnUserAudioStart OnUserAudioStart;
        public OnUserAudioStop OnUserAudioStop;
        public OnUserVideoStart OnUserVideoStart;
        public OnUserVideoStop OnUserVideoStop;
        public OnUserSubStreamVideoStart OnUserSubStreamVideoStart;
        public OnUserSubStreamVideoStop OnUserSubStreamVideoStop;
        public OnScreenCaptureStatusChanged OnScreenCaptureStatusChanged;
        public OnUserVideoProfileUpdate OnUserVideoProfileUpdate;
        public OnUserAudioMute OnUserAudioMute;
        public OnUserVideoMute OnUserVideoMute;
        public OnAudioDeviceRoutingDidChange OnAudioDeviceRoutingDidChange;
        public OnAudioDeviceStateChanged OnAudioDeviceStateChanged;
        public OnAudioDefaultDeviceChanged OnAudioDefaultDeviceChanged;
        public OnVideoDeviceStateChanged OnVideoDeviceStateChanged;
        public OnCameraFocusChanged OnCameraFocusChanged;
        public OnCameraExposureChanged OnCameraExposureChanged;
        public OnFirstAudioDataReceived OnFirstAudioDataReceived;
        public OnFirstVideoDataReceived OnFirstVideoDataReceived;
        public OnFirstAudioFrameDecoded OnFirstAudioFrameDecoded;
        public OnFirstVideoFrameDecoded OnFirstVideoFrameDecoded;
        public OnCaptureVideoFrame OnCaptureVideoFrame;
        public OnAudioMixingStateChanged OnAudioMixingStateChanged;
        public OnAudioMixingTimestampUpdate OnAudioMixingTimestampUpdate;
        public OnAudioEffectFinished OnAudioEffectFinished;
        public OnLocalAudioVolumeIndication OnLocalAudioVolumeIndication;
        public OnRemoteAudioVolumeIndication OnRemoteAudioVolumeIndication;
        public OnAddLiveStreamTask OnAddLiveStreamTask;
        public OnUpdateLiveStreamTask OnUpdateLiveStreamTask;
        public OnRemoveLiveStreamTask OnRemoveLiveStreamTask;
        public OnLiveStreamStateChanged OnLiveStreamStateChanged;
        public OnAudioHowling OnAudioHowling;
        public OnRecvSEIMessage OnRecvSEIMessage;
        public OnAudioRecording OnAudioRecording;
        public OnMediaRelayStateChanged OnMediaRelayStateChanged;
        public OnMediaRelayEvent OnMediaRelayEvent;
        public OnPublishFallbackToAudioOnly OnPublishFallbackToAudioOnly;
        public OnSubscribeFallbackToAudioOnly OnSubscribeFallbackToAudioOnly;
        public OnLastmileQuality OnLastmileQuality;
        public OnLastmileProbeResult OnLastmileProbeResult;
        public OnAvatarUserJoined OnAvatarUserJoined;
        public OnAvatarUserLeft OnAvatarUserLeft;
        public OnAvatarStatus OnAvatarStatus;
        #endregion

        /**
        * @if English
        * Retrieves the IRtcEngine static object.
        * @return The IRtcEngine Object
        * @endif
        * @if Chinese
        * 获取IRtcEngine单例对象
        * 该方法在加入房间前后都能调用。
        * @return IRtcEngine对象
        * @endif
        */
        public static IRtcEngine GetInstance()
        {
            return RtcEngine.GetRtcEngine();
        }
        /**
        * @if English
        * Retrieves the audio device manager object.
        * @return The IAudioDeviceManager Object
        * @endif
        * @if Chinese
        * 获取音频设备管理对象
        * 该方法在加入房间前后都能调用。
        * @return 音频设备管理对象
        * @endif
        */
        public abstract IAudioDeviceManager AudioDeviceManager { get; }
        /**
        * @if English
        * Get the audio device manager object.
        * @return The IAudioDeviceManager Object
        * @endif
        * @if Chinese
        * 获取音频设备管理对象
        * 该方法在加入房间前后都能调用。
        * @return 音频设备管理对象
        * @endif
        */
        public abstract IVideoDeviceManager VideoDeviceManager { get; }
        /**
        * @if English
        * Initializes the NERTC SDK service.
        * <br>You must call the method to initialize before calling other methods.
        * After successfully initializing, the audio and video call mode is enabled by default.
        * @warning
        * - Callers must use the same AppKey to make audio or video calls.
        * - One IRtcEngine instance object must share the same App Key. If you need to change the AppKey, you must first call \ref
        * IRtcEngine::Release "Release" to destroy the current instance, and then call the method to create a new instance.
        * @param[in] param The passed \ref RtcEngineContext object.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 初始化 NERTC SDK 服务。
        * <br>你必须先调用该方法进行初始化，才能使用其他方法。初始化成功后，默认处于音视频通话模式。
        * @warning
        * - 必须使用同一个 App Key 才能进行通话。
        * - 一个 IRtcEngine 实例对象只能使用一个 App Key。如需更换 App Key，必须先调用 \ref IRtcEngine::Release "Release"
        * 方法销毁当前实例，再调用本方法重新创建实例。
        * @param[in] param 传入的 \ref RtcEngineContext 对象.
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int Initialize(RtcEngineContext param);
        /**
        * @if English
        *  Destroys an NERtc engine instance to release resources.
        * <br>This method releases all resources used by the NERTC SDK. In some cases, real-time audio and video communication is
        * only needed upon your demands. If no RTC calls are required, you can call this method to release resources. <br>After you
        * call the release method, other methods and callbacks supported by the SDK become unavailable. 
        * @note If you need to use IRtcEngine instance again ,you need to initialize after release.
        * @param[in] sync The value is true by default, which can only be set to true. The default setting indicates synchronization
        * call of the instance. You must return before you release the resources and return the IRtcEngine object resources. <br>App
        * cannot call the interface in the callbacks returned by the SDK. If not, deadlock occurs and the SDK can only retrieve
        * related object resources before the callback is returned.  The SDK automatically detects the deadlock, and changes the
        * deadlock to asynchronous call. However, the asynchronous call consumes extra time.
        * @endif
        * @if Chinese
        * 销毁 NERtc engine 实例，释放资源。
        * <br>该方法释放 NERTC SDK 使用的所有资源。有些 App
        * 只在用户需要时才进行实时音视频通信，不需要时则将资源释放出来用于其他操作，该方法适用于此类情况。 <br>调用 \ref IRtcEngine::Release "Release"
        * 方法后，您将无法再使用 SDK 的其它方法和回调。
        * @note 如果需要重新使用 IRtcEngine ，需要再次调用初始化接口。
        * @param[in] sync 默认为 true 且只能设置为 true，表示同步调用，等待 IRtcEngine 对象资源释放后再返回。<br>App 不应该在 SDK
        * 产生的回调中调用该接口，否则由于 SDK 要等待回调返回才能回收相关的对象资源，会造成死锁。SDK
        * 会自动检测这种死锁并转为异步调用，但是检测本身会消耗额外的时间。
        * @endif
        */
        public abstract void Release(bool sync);
        /**
        * @if English
        * Sets the role of a user in live streaming.
        * <br>The method sets the role to host or audience. The permissions of a host and a viewer are different.
        * - A host has the permissions to open or close a camera, publish streams, call methods related to publishing streams in
        * interactive live streaming. The status of the host is visible to the users in the room when the host joins or leaves the
        * room.
        * - The audience has no permissions to open or close a camera, call methods related to publishing streams in interactive live
        * streaming, and is invisible to other users in the room when the user that has the audience role joins or leaves the room.
        * @note
        * - By default, a user joins a room as a host.
        * - Before a user joins a room, the user can call this method to change the client role to audience. Users can switch the
        * role of a user through the interface after joining the room.
        * - If the user switches the role to audience, the SDK automatically closes the audio and video devices.
        * @param[in] role The role of a user. #RtcClientRole.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 在直播场景中设置用户角色。
        * <br>用户角色支持设置为主播或观众，主播和观众的权限不同。
        * - 主播：可以开关摄像头等设备、可以发布流、可以操作互动直播推流相关接口、上下线对其他房间内用户可见。
        * - 观众：不可以开关摄像头等设备、不可以发布流、不可以操作互动直播推流相关接口、上下线对其他房间内用户不可见。
        * @note
        * - 默认情况下用户以主播角色加入房间。
        * - 在加入房间前，用户可以调用本接口切换本端角色为观众。在加入房间后，用户也可以通过本接口切换用户角色。
        * - 用户切换为观众角色时，SDK 会自动关闭音视频设备。
        * @param[in] role 用户角色。 #RtcClientRole
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetClientRole(RtcClientRole role);
        /**
        * @if English
        * Sets a room scene.
        * <br>You can set a room scene for a call or live event. Different QoS policies are applied to different scenes.
        * @note You must set the profile after joining a call. The setting is invalid after the call ends.
        * @param[in] profile Sets the room scene. For more information, see #RtcChannelProfileType .
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置房间场景。
        * <br>房间场景可设置为通话或直播场景，不同的场景中 QoS 策略不同。
        * @note 必须在加入通话前设置，开始通话后设置无效，结束通话后保留之前的设置。
        * @param[in] profile 设置房间场景。详细信息请参考 #RtcChannelProfileType 。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetChannelProfile(RtcChannelProfileType profile);
        /**
        * @if English
        *  Joins a channel of audio and video call.
        * <br>If the specified room does not exist when you join the room, a room with the specified name is automatically created in
        * the server provided by CommsEase.
        * - After you join a room by calling the relevant method supported by the SDK, users in the same room can make audio or video
        * calls. Users that join the same room can start a group chat. Apps that use different AppKeys cannot communicate with each
        * other.
        * - After the method is called successfully, the \ref nertc::OnJoinChannel "OnJoinChannel" callback is locally triggered, 
        * and the \ref nertc::OnUserJoined "OnUserJoined" callback is remotely triggered.
        * - If you join a room, you subscribe to the audio streams from other users in the same room by default. In this case, the
        data usage is billed. To unsubscribe, you can call the \ref IRtcEngine::SetParameters "SetParameters" method.
        * - In live streaming, audiences can switch channels by calling \ref IRtcEngine::SwitchChannel "SwitchChannel" .
        * @note The ID of each user must be unique.
        * @param[in] token The certification signature used in authentication (NERTC Token). Valid values:
        *           - Null. You can set the value to null in the debugging mode. This poses a security risk. We recommend that
        * you contact your business manager to change to the default safe mode before your product is officially launched.
        *           - NERTC Token acquired. In safe mode, the acquired token must be specified. If the specified token is
        * invalid, users are unable to join a room. We recommend that you use the safe mode.
        * @param[in] channelName The name of the room. Users that use the same name can join the same room. The name must be of
        * STRING type and must be 1 to 64 characters in length. The following 89 characters are supported: a-z, A-Z, 0-9, space,
        * !#$%&()+-:;≤.,>? @[]^_{|}~”.
        * @param[in] uid  The unique identifier of a user. The uid of each user in a room must be unique.
        * <br> uid is optional. The default value is 0. If the uid is not specified (set to 0), the SDK automatically
        * assigns a random uid and returns the uid in the callback of \ref nertc::OnJoinChannel "OnJoinChannel"l. The application layer must keep and maintain the
        * return value. The SDK does not maintain the return value.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 加入音视频房间。
        * <br>加入音视频房间时，如果指定房间尚未创建，云信服务器内部会自动创建一个同名房间。
        * - SDK 加入房间后，同一个房间内的用户可以互相通话，多个用户加入同一个房间，可以群聊。使用不同 App Key 的 App 之间不能互通。
        * - 成功调用该方加入房间后，本地会触发 \ref nertc::OnJoinChannel "OnJoinChannel" 回调，远端会触发 \ref nertc::OnUserJoined "OnUserJoined"回调。
        * 用户成功加入房间后，默认订阅房间内所有其他用户的音频流，可能会因此产生用量并影响计费。如果想取消自动订阅，可以在通话前通过调用 \ref IRtcEngine::SetParameters "SetParameters" 方法实现。
        * - 直播场景中的观众角色可以通过 \ref IRtcEngine::SwitchChannel "SwitchChannel" 快速切换房间。
        * @note 房间内每个用户的用户 ID 必须是唯一的。
        * @param[in] token         安全认证签名（NERTC Token）。可设置为：
        *           - null。调试模式下可设置为
        * null。安全性不高，建议在产品正式上线前在云信控制台中将鉴权方式恢复为默认的安全模式。
        *           - 已获取的NERTC Token。安全模式下必须设置为获取到的 Token 。若未传入正确的 Token
        * 将无法进入房间。推荐使用安全模式。
        * @param[in] channelName 房间名称，设置相同房间名称的用户会进入同一个通话房间。字符串格式，长度为1~ 64
        * 字节。支持以下89个字符：a-z, A-Z, 0-9, space, !#$%&()+-:;≤.,>? @[]^_{|}~”
        * @param[in] uid  用户的唯一标识 id，房间内每个用户的 uid 必须是唯一的。
        *       <br>uid 可选，默认为 0。如果不指定（即设为 0），SDK 会自动分配一个随机 uid，并在 \ref nertc::OnJoinChannel "OnJoinChannel" 
        * 回调方法中返回，App 层必须记住该返回值并维护，SDK 不对该返回值进行维护。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int JoinChannel(string token, string channelName, ulong uid);
        /**
        * @if English
        * Switches to a room of audio and video call.
        * <br>In live streaming, the audience can call this method to switch from the current room to another room.
        * <br>After you switch to another room by calling the method, the local first receive the \ref nertc::OnLeaveChannel "OnLeaveChannel" 
        * callback that the user leaves the room, and then receives the
        * <br>\ref nertc::OnJoinChannel "OnJoinChannel" callback that the user joins the new room. Remote clients receive the return from \ref nertc::OnUserLeft "OnUserLeft" and
        * \ref nertc::OnUserJoined "OnUserJoined".
        * @note
        * - The method applies to only the live streaming. The role is the audience in the RTC room. The room scene is set to live
        * streaming by calling the \ref IRtcEngine::SetChannelProfile "SetChannelProfile" method, and the role of room members is set to audience by calling the
        * \ref IRtcEngine::SetClientRole "SetClientRole" method.
        * - By default, after a room member switches to another room, the room member subscribes to audio streams from other members
        * of the new room. In this case, data usage is charged and billing is updated. If you want to unsubscribe to the previous audio
        * stream, you can call the \ref IRtcEngine::SubscribeRemoteAudioStream "SubscribeRemoteAudioStream"  method with a value of false passed in.
        * @param[in] token The certification signature used in authentication (NERTC Token). Valid values:
        *       - Null. You can set the value to null in the debugging mode. We recommend you change to the default safe
        * mode before your product is officially launched.
        *       - NERTC Token acquired. In safe mode, the acquired token must be specified. If the specified token is
        * invalid, users are unable to join a channel. We recommend that you use the safe mode.
        * @param[in] channelName  The room name that a user wants to switch to.
        * 
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 快速切换音视频房间。
        * <br>房间场景为直播场景时，房间中角色为观众的成员可以调用该方法从当前房间快速切换至另一个房间。
        * <br>成功调用该方切换房间后，本端会先收到离开房间的回调 \ref nertc::OnLeaveChannel "OnLeaveChannel" ，再收到成功加入新房间的回调
        * \ref nertc::OnJoinChannel "OnJoinChannel" 。远端用户会收到 \ref nertc::OnUserLeft "OnUserLeft" 和 \ref nertc::OnUserJoined "OnUserJoined" 的回调。
        * @note
        * - 该方法仅适用于直播场景中，角色为观众的音视频房间成员。即已通过接口 \ref IRtcEngine::SetChannelProfile "SetChannelProfile" 
        * 设置房间场景为直播，通过 \ref IRtcEngine::SetClientRole "SetClientRole" 设置房间成员的角色为观众。
        * - 房间成员成功切换房间后，默认订阅房间内所有其他成员的音频流，因此产生用量并影响计费。如果想取消订阅，可以通过调用相应的
        * \ref IRtcEngine::SubscribeRemoteAudioStream "SubscribeRemoteAudioStream" 方法传入 false 实现。
        * @param[in] token 安全认证签名（NERTC Token）。可设置为：
        *       - null。调试模式下可设置为 null。建议在产品正式上线前在云信控制台中将鉴权方式恢复为默认的安全模式。
        *       - 已获取的NERTC Token。安全模式下必须设置为获取到的 Token 。若未传入正确的 Token
        * 将无法进入房间。推荐使用安全模式。
        * @param[in] channelName 期望切换到的目标房间名称。
        * 
        * @return
        * -0: 方法调用成功
        * -其他：方法调用失败
        * @endif
        */
        public abstract int SwitchChannel(string token, string channelName);
        /**
        * @if English
        * Leaves the room.
        * <br>Leaves a room for hang up or calls ended.
        * <br>A user can call the leaveChannel method to end the call before the user makes another call.
        * <br>After the method is called successfully, the \ref nertc::OnLeaveChannel "OnLeaveChannel" callback is locally triggered, and the \ref nertc::OnUserLeft "OnUserLeft" callback
        * is remotely triggered.
        * @note
        * - The method is asynchronous call. Users cannot exit the room when the method is called and returned. After users exit the
        * room, the SDK triggers the \ref nertc::OnLeaveChannel "OnLeaveChannel" callback.
        * - If you call leaveChannel method and instantly call release method, the SDK cannot trigger \ref nertc::OnLeaveChannel "OnLeaveChannel" callback.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 离开房间。
        * <br>离开房间，即挂断或退出通话。
        * <br>结束通话时，必须调用leaveChannel结束通话，否则无法开始下一次通话。
        * <br>成功调用该方法离开房间后，本地会触发\ref nertc::OnLeaveChannel "OnLeaveChannel"回调，远端会触发\ref nertc::OnUserLeft "OnUserLeft"回调。
        * @note
        * - 该方法是异步操作，调用返回时并没有真正退出房间。在真正退出房间后，SDK 会触发\ref nertc::OnLeaveChannel "OnLeaveChannel"回调。
        * - 如果您调用了leaveChannel后立即调用release，SDK 将无法触发\ref nertc::OnLeaveChannel "OnLeaveChannel"回调。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int LeaveChannel();
        /**
        * @if English
        * Enables or disables local audio capture.
        * <br>The method can enable the local audio again to start local audio capture and processing.
        * <br>The method does not affect receiving or playing remote audio and audio streams.
        * @note The method is different from \ref IRtcEngine::MuteLocalAudioStream "MuteLocalAudioStream" in:.
        * - \ref IRtcEngine::EnableLocalAudio "EnableLocalAudio": Enables local audio capture and processing.
        * - \ref IRtcEngine::MuteLocalAudioStream "MuteLocalAudioStream": Stops or continues publishing local audio streams.
        * @note The method enables the internal engine, which is still valid after you call \ref IRtcEngine::LeaveChannel "LeaveChannel".
        * @param[in] enabled
        * - true: Enables local audio feature again. You can enable local audio capture or processing by default.
        * - false: Disables local audio feature again. You can stop local audio capture or processing.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 开启/关闭本地音频采集
        * <br>该方法可以重新开启本地语音功能，重新开始本地音频采集及处理。
        * <br>该方法不影响接收或播放远端音频流。
        * @note 该方法与 \ref IRtcEngine::MuteLocalAudioStream "MuteLocalAudioStream" 的区别在于:
        * - \ref IRtcEngine::EnableLocalAudio "EnableLocalAudio": 开启本地语音采集及处理
        * - \ref IRtcEngine::MuteLocalAudioStream "MuteLocalAudioStream": 停止或继续发送本地音频流
        * @note 该方法设置内部引擎为启用状态，在 \ref IRtcEngine::LeaveChannel "LeaveChannel" 后仍然有效。
        * @param[in] enabled
        * - true: 重新开启本地语音功能，即开启本地语音采集或处理（默认）
        * - false: 关闭本地语音功能，即停止本地语音采集或处理
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int EnableLocalAudio(bool enabled);
        /**
        * @if English
        * Sets local views.
        * <br>This method is used to set the display information about the local video. The method is applicable for only local
        * users. Remote users are not affected. <br>Apps can call this API operation to associate with the view that plays local
        * video streams. During application development, in most cases, before joining a room, you must first call this method to set
        * the local video view after the SDK is initialized.
        * @note  If you use external rendering on the Mac platform, you must set the rendering before the SDK is initialized.
        * @param[in] canvas The video canvas information.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置本地视图。
        * <br>该方法设置本地视频显示信息。只影响本地用户看到的视频画面，不影响远端。
        * <br>App 通过调用此接口绑定本地视频流的显示视窗(view)。 在 App
        * 开发中，通常在初始化后调用该方法进行本地视频设置，然后再加入房间。
        * @note mac端若使用外部渲染，必须在 SDK 初始化时设置。
        * @param[in] canvas 视频画布信息
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetupLocalVideoCanvas(RtcVideoCanvas canvas);
        /**
        * @if English
        *  Sets views for remote users.
        * <br>This method is used to associate remote users with display views and configure the rendering mode and mirror mode for
        * remote views that are displayed locally. The method affects only video display viewed by local users.
        * @note
        * - You need to specify the uid of remote video when the interface is called. In general cases, the uid can be set before
        * users join the room.
        * - If the user ID is not retrieved, the App calls this method after the \ref nertc::OnUserJoined "OnUserJoined" event is triggered. To disassociate a
        * specified user from a view, you can leave the canvas parameter empty.
        * - After a user leaves the room, the association between a remote user and the view is cleared.
        * @param[in] uid       The ID of a remote user.
        * @param[in] canvas    The video canvas information.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置远端用户视图。
        * <br>该方法绑定远端用户和显示视图，并设置远端用户视图在本地显示时的渲染模式和镜像模式，只影响本地用户看到的视频画面。
        * @note
        * - 调用该接口时需要指定远端视频的 uid，一般可以在用户加入后设置好。
        * - 如果 App 无法事先知道对方的用户 ID，可以在 APP 收到 \ref nertc::OnUserJoined "OnUserJoined" 事件时设置。- 解除某个用户的绑定视图可以把 canvas
        * 设置为空。
        * - 退出房间后，SDK 会清除远程用户和视图的绑定关系。
        * @param[in] uid       远端用户 ID。
        * @param[in] canvas    视频画布信息
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetupRemoteVideoCanvas(ulong uid, RtcVideoCanvas canvas);
        /**
        * @if English
        * Enables or disables local audio capture and rendering.
        * <br>The method enables local video capture.
        * @note
        * - You can call this method before or after you join a room.
        * - The method enables the internal engine, which is still valid after you call \ref IRtcEngine::LeaveChannel "LeaveChannel".
        * - After local video capture is successfully enabled or disabled,  the \ref nertc::OnUserVideoStop "OnUserVideoStop" or \ref nertc::OnUserVideoStart "OnUserVideoStart" callback is
        * remotely triggered.
        * @param[in] enabled Whether to enable local video capture and rendering.
        * - true: Enables the local video capture and rendering.
        * - false: Disables the local camera device. After local video capture is disabled, remote users cannot receive video streams
        * from local users. However, local users can still receive video streams from remote users. If the setting is false, the
        * local camera is not required to call the method.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 开启或关闭本地视频采集和渲染。
        * <br>该方法启用本地视频采集功能。
        * @note
        * - 该方法在加入房间前和加入房间后均可调用。
        * - 该方法设置内部引擎为启用状态，在 \ref IRtcEngine::LeaveChannel "LeaveChannel" 后仍然有效。
        * - 成功启用或禁用本地视频采集和渲染后，远端会触发 \ref nertc::OnUserVideoStop "OnUserVideoStop" 或 \ref nertc::OnUserVideoStart "OnUserVideoStart"  回调。
        * @param[in] enabled 是否启用本地视频采集和渲染:
        * - true: 开启本地视频采集和渲染 (默认)；
        * - false: 关闭使用本地摄像头设备。关闭后，远端用户会接收不到本地用户的视频流；但本地用户依然可以接收远端用户的视频流。设置为
        * false 时，该方法不需要本地有摄像头。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int EnableLocalVideo(bool enabled);
        /**
        * @if English
        * Subscribes or unsubscribes video streams from specified remote users.
        * - After a user joins a room, the video streams from remote users are not subscribed by default. If you want to view video
        * streams from specified remote users, you can call this method to subscribe to the video streams from the user when the user
        * joins the room or publishes the video streams.
        * - This method can be called only if a user joins a room.
        * @param[in] uid       The user ID.
        * @param[in] type      The type of the subscribed video streams. #RtcRemoteVideoStreamType .
        * @param[in] subscribe
        * - true: Subscribes to specified video streams. This is the default value.
        * - false: Not subscribing to specified video streams.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 订阅或取消订阅指定远端用户的视频流。
        * -
        * 用户加入房间之后，默认不订阅远端用户的视频流，如果希望看到指定远端用户的视频，可以在监听到对方加入房间或发布视频流之后，通过此方法订阅该用户的视频流。
        * - 该方法需要在加入房间后调用。
        * @param[in] uid       指定用户的用户 ID。
        * @param[in] type      订阅的视频流类型。 #RtcRemoteVideoStreamType
        * @param[in] subscribe
        * - true: （默认）订阅指定视频流。
        * - false: 不订阅指定视频流。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SubscribeRemoteVideoStream(ulong uid, RtcRemoteVideoStreamType type, bool subscribe);
        /**
        * @if English
        * Switches between the front and rear cameras.
        * <br>Make sure that you call this method after the camera starts. For example, you can call this method after you call
        * \ref IRtcEngine::StartVideoPreview "StartVideoPreview" or \ref IRtcEngine::JoinChannel "JoinChannel".
        * @note The audio-only SDK disables this API. If you need to use the API, you can download the standard SDK from the official
        * website of CommsEase and replace the audio-only SDK.
        * @return The value returned. A value of 0 indicates that the operation is successful.
        * @endif
        * @if Chinese
        * 切换前置/后置摄像头。
        * <br>该方法需要在相机启动后调用，例如调用 \ref IRtcEngine::StartVideoPreview "StartVideoPreview" 或 \ref IRtcEngine::JoinChannel "JoinChannel" 后。
        * @note 纯音频 SDK 禁用该接口，如需使用请前往云信官网下载并替换成视频 SDK。
        * @return 操作返回值，成功则返回 0
        * @endif
        */
        public abstract int SwitchCamera();
        /**
        * @if English
        * Create an IRtcChannel object.
        * @param[in] channelName      The name of the room. Users that use the same name can join the same room. The name must be of
        * STRING type and must be 1 to 64 characters in length. The following 89 characters are supported: a-z, A-Z, 0-9, space,
        * !#$%&()+-:;≤.,>? @[]^_{|}~”.
        * @return IRtcChannel object
        * - null: failure.
        * @endif
        * @if Chinese
        * 创建一个 IRtcChannel 对象
        * @param[in] channelName      房间名。设置相同房间名称的用户会进入同一个通话房间。字符串格式，长度为1~ 64
        * 字节。支持以下89个字符：a-z, A-Z, 0-9, space, !#$%&()+-:;≤.,>? @[]^_{|}~”
        * @return 返回 IRtcChannel 对象
        * - null: 方法调用失败。
        * @endif
        */
        public abstract IRtcChannel CreateChannel(string channelName);

        /**
        * @if English
        * Get an IRtcChannel object.
        * @param[in] channelName      The name of the room. Users that use the same name can join the same room. The name must be of
        * STRING type and must be 1 to 64 characters in length. The following 89 characters are supported: a-z, A-Z, 0-9, space,
        * !#$%&()+-:;≤.,>? @[]^_{|}~”.
        * @return IRtcChannel object
        * - null: failure.
        * @endif
        * @if Chinese
        * 获取一个 IRtcChannel 对象
        * @param[in] channelName      房间名。设置相同房间名称的用户会进入同一个通话房间。字符串格式，长度为1~ 64
        * 字节。支持以下89个字符：a-z, A-Z, 0-9, space, !#$%&()+-:;≤.,>? @[]^_{|}~”
        * @return 返回 IRtcChannel 对象
        * - null: 方法调用失败。
        * @endif
        */
        public abstract IRtcChannel GetChannel(string channelName);

        /**
        * @if English
        * Gets the current connection status.
        * @return Returns the current network status. #RtcConnectionStateType .
        * @endif
        * @if Chinese
        * 获取当前网络状态。
        * @return 当前网络状态。 #RtcConnectionStateType .
        * @endif
        */
        public abstract RtcConnectionStateType GetConnectionState();

        /**
        * @if English
        * Enables or disabling publishing the local audio stream. The method is used to enable or disable publishing the local audio
        * stream.
        * @note
        * - This method does not change the state of the audio-recording device because the audio-recording devices are not disabled.
        * - The mute state is reset to unmuted after the call ends.
        * @param[in] mute       Mute or Unmute.
        * - true: Mutes the local audio stream.
        * - false: Unmutes the local audio stream (Default).
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 开关本地音频发送。该方法用于允许或禁止向网络发送本地音频流。
        * @note
        * - 该方法不影响录音状态，因为并没有禁用录音设备。
        * - 静音状态会在通话结束后被重置为非静音
        * @param[in] mute      静音/取消静音:
        * - true: 静音本地音频
        * - false: 取消静音本地音频（默认）
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int MuteLocalAudioStream(bool mute);
        /**
        * @if English
        * Sets the audio encoding profile.
        * @note
        * - Sets the method before calling the \ref IRtcEngine::JoinChannel "JoinChannel". Otherwise, the setting is invalid after
        * \ref IRtcEngine::JoinChannel "JoinChannel".
        * - In music scenarios, we recommend you to set the profile as \ref RtcAudioProfileType::kNERtcAudioProfileHighQuality "kNERtcAudioProfileHighQuality".
        * @param[in] profile       Sets the sample rate, bitrate, encoding mode, and the number of channels. #RtcAudioProfileType .
        * @param[in] scenario      Sets the type of an audio application scenario. #RtcAudioScenarioType .
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置音频编码属性。
        * @note
        * - 该方法需要在 \ref IRtcEngine::JoinChannel "JoinChannel" 之前设置好， \ref IRtcEngine::JoinChannel "JoinChannel"
        * 之后设置不生效。
        * - 音乐场景下，建议将 profile 设置为 \ref RtcAudioProfileType::kNERtcAudioProfileHighQuality "kNERtcAudioProfileHighQuality"。
        * @param[in]  profile      设置采样率，码率，编码模式和声道数: #RtcAudioProfileType 。
        * @param[in]  scenario     设置音频应用场景: #RtcAudioScenarioType 。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetAudioProfile(RtcAudioProfileType profile, RtcAudioScenarioType scenario);
        /**
        * @if English
        * Sets the voice changer effect for the SDK-preset voice.
        * The method can add multiple preset audio effects to original human voices and change audio profiles.
        * @note
        * - You can call this method either before or after joining a room. By default, the audio effect is disabled after the call
        * ends.
        * - The method conflicts with \ref IRtcEngine::SetLocalVoicePitch "SetLocalVoicePitch" . After you call this method, the voice pitch is reset to the default
        * value 1.0.
        * @param[in] type      The preset voice changer effect. By default, the audio effect is disabled. For more information, see
        * #RtcVoiceChangerType.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置 SDK 预设的人声的变声音效。
        * 设置变声音效可以将人声原因调整为多种特殊效果，改变声音特性。
        *  @note
        * - 此方法在加入房间前后都能调用，通话结束后重置为默认关闭状态。
        * - 此方法和 \ref IRtcEngine::SetLocalVoicePitch "SetLocalVoicePitch" 互斥，调用此方法后，本地语音语调会恢复为默认值 1.0。
        * @param[in] type      预设的变声音效。默认关闭变声音效。详细信息请参考 #RtcVoiceChangerType 。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetAudioEffectPreset(RtcVoiceChangerType type);
        /**
        * @if English
        * Sets an SDK-preset voice beautifier effect.
        * The method can set a SDK-preset voice beautifier effect for a local user who sends an audio stream.
        * @note By default, the method is reset as disabled after the call ends.
        * @param[in] type      The present voice beautifier effect. By default, the voice beautifier effect is disabled. For more
        * information, see #RtcVoiceBeautifierType.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置 SDK 预设的美声效果。
        * 调用该方法可以为本地发流用户设置 SDK 预设的人声美声效果。
        * @note 通话结束后重置为默认关闭
        * @param[in] type      预设的美声效果模式。默认关闭美声效果。详细信息请参考 #RtcVoiceBeautifierType 。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetVoiceBeautifierPreset(RtcVoiceBeautifierType type);
        /**
        * @if English
        * Sets the voice pitch of a local voice.
        * The method changes the voice pitch of the local speaker.
        * @note
        * - After the call ends, the setting changes back to the default value 1.0.
        * - The method conflicts with \ref IRtcEngine::SetAudioEffectPreset "SetAudioEffectPreset". After you call this method, the preset voice beautifier effect will be
        * removed.
        * @param[in] pitch         The voice frequency. Valid values: 0.5 to 2.0. Smaller values have lower pitches. The default
        * value is 1, which That the pitch is not changed.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置本地语音音调。
        * 该方法改变本地说话人声音的音调。
        * @note
        * - 通话结束后该设置会重置，默认为 1.0。
        * - 此方法与 \ref IRtcEngine::SetAudioEffectPreset "SetAudioEffectPreset" 互斥，调用此方法后，已设置的变声效果会被取消。
        * @param[in] pitch         语音频率。可以在 [0.5, 2.0] 范围内设置。取值越小，则音调越低。默认值为 1.0，表示不需要修改音调。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetLocalVoicePitch(double pitch);
        /**
        * @if English
        * Sets the local voice equalization effect. You can customize the center frequencies of the local voice effects.
        * @note You can call this method either before or after joining a room. By default, the audio effect is disabled after the
        * call ends.
        * @param[in] bandFrequency    Sets the band frequency. Value range: 0 to 9. Those numbers represent the respective 10-band
        * center frequencies of the voice effects, including 31, 62, 125, 250, 500, 1k, 2k, 4k, 8k, and 16k Hz.
        * @param[in] bandGain         Sets the gain of each band (dB). Value range: -15 to 15. The default value is 0.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置本地语音音效均衡，即自定义设置本地人声均衡波段的中心频率。
        * @note 该方法在加入房间前后都能调用，通话结束后重置为默认关闭状态。
        * @param[in] bandFrequency    频谱子带索引，取值范围是 [0-9]，分别代表 10 个频带，对应的中心频率是
        * [31，62，125，250，500，1k，2k，4k，8k，16k] Hz。
        * @param[in] bandGain         每个 band 的增益，单位是 dB，每一个值的范围是 [-15，15]，默认值为 0。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetLocalVoiceEqualization(RtcVoiceEqualizationBand bandFrequency, int bandGain);
        /**
        * @if English
        * Unsubscribes from or subscribes to audio streams from specified remote users.
        * <br>After a user joins a channel, audio streams from all remote users are subscribed by default. You can call this method
        * to unsubscribe from or subscribe to audio streams from all remote users.
        * @note  When \ref RtcConstants::kNERtcKeyAutoSubscribeAudio "kNERtcKeyAutoSubscribeAudio" is enabled by default, users cannot manually modify the state of audio
        * subscription.
        * @param[in] uid           The user ID.
        * @param[in] subscribe
        * - true: Subscribes to specified audio streams (default).
        * - false: Unsubscribes from specified audio streams.
        *  @return
        * - 0: Success.
        * - 30005: State exception that is caused by the invalid interface if users enable the automatic subscription.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 取消或恢复订阅指定远端用户音频流。
        * <br>加入房间时，默认订阅所有远端用户的音频流，您可以通过此方法取消或恢复订阅指定远端用户的音频流。
        * @note 当 \ref RtcConstants::kNERtcKeyAutoSubscribeAudio "kNERtcKeyAutoSubscribeAudio" 默认打开时，用户不能手动修改音频订阅状态
        * @param[in] uid           指定用户的 ID。
        * @param[in] subscribe     是否订阅远端用户音频流。
        * - true: 订阅指定音频流（默认）。
        * - false: 取消订阅指定音频流。
        * @return
        * - 0: 方法调用成功。
        * - 30005: 状态异常，可能是自动订阅打开，导致该接口无效。
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SubscribeRemoteAudioStream(ulong uid, bool subscribe);
        /**
        * @if English
        * Sets permissions of the SDK over Audio Session.
        * <br>This method is only applicable to the iOS platform.
        * <br>This method controls the permissions of the SDK over Audio Session. By default, the SDK and the app have control over the
        * Audio Session. However, in some cases, the app wants to restrict the SDK's permissions over Audio Session and uses other
        * applications or third-party components to control Audio Session. The app can adjust the permissions of the SDK by calling
        * this method. <br>You can call this method only before you join the room.
        * @note If you call this method to restrict the SDK's permissions over Audio Session, the SDK cannot set Audio Session. You
        * need to manage Audio Session or use a third-party component to operate Audio Session.
        * @param restriction The restriction applied to the SDK for Audio Session. For more information, see 
        * {@link RtcAudioSessionOperationRestriction}.
        * @return The value returned. A value of 0 indicates that the operation is successful.
        * @endif
        * @if Chinese
        * 设置 SDK 对 Audio Session 的控制权限。
        * <br>该方法仅适用于 iOS 平台。
        * <br>该方法限制  SDK 对 Audio Session 的操作权限。在默认情况下，SDK 和 App 对 Audio Session 都有控制权，但某些场景下，App
        * 会希望限制  SDK 对 Audio Session 的控制权限，而使用其他应用或第三方组件对 Audio Session 进行操控。调用该方法可以实现该功能。
        * <br>该接口只能在入会之前调用。
        * @note 一旦调用该方法限制了 SDK 对 Audio Session 的控制权限， SDK 将无法对 Audio Session
        * 进行相关设置，而需要用户自己或第三方组件进行维护。
        * @param restriction SDK 对 Audio Session 的控制权限。详细信息请参考 {@link RtcAudioSessionOperationRestriction}。
        * @return 操作返回值，成功则返回 0
        * @endif
        */
        public abstract int SetSudioSessionOperationRestriction(RtcAudioSessionOperationRestriction restriction);
        /**
        * @if English
        * Mutes or unmutes the audio playback device.
        * @param muted The option whether to mute the playback device. By default, the setting is unmuted.
        * @return The value returned. A value of 0 indicates that the operation is successful.
        * @endif
        * @if Chinese
        * 设置是否静音音频播放设备。
        * @param muted 是否静音播放设备。默认为不静音状态。
        * @return 操作返回值，成功则返回 0
        * @endif
        */
        public abstract int SetPlayoutDeviceMute(bool muted);
        /**
        * @if English
        * Gets the mute status of the audio playback device.
        * @param muted The option whether the device is muted.
        * @return The value returned. A value of 0 indicates that the operation is successful.
        * @endif
        * @if Chinese
        * 获取音频播放设备的静音状态。
        * @param muted 是否静音。
        * @return 操作返回值，成功则返回 0
        * @endif
        */
        public abstract int GetPlayoutDeviceMute(ref bool muted);
        /**
        * @if English
        * Mutes or unmutes the audio capture device.
        * @param muted The option whether to mute the audio capture device. The default setting is unmuted.
        * @return The value returned. A value of 0 indicates that the operation is successful.
        * @endif
        * @if Chinese
        * 设置是否静音音频采集设备。
        * @param muted 是否静音音频采集设备。默认为不静音。
        * @return 操作返回值，成功则返回 0
        * @endif
        */
        public abstract int SetRecordDeviceMute(bool muted);
        /**
        * @if English
        * Checks whether the audio capture device is muted.
        * @param muted The option whether the device is muted.
        * @return The value returned. A value of 0 indicates that the operation is successful.
        * @endif
        * @if Chinese
        * 查询当前音频采集设备是否静音。
        * @param muted 是否静音。
        * @return 操作返回值，成功则返回 0
        * @endif
        */
        public abstract int GetRecordDeviceMute(ref bool muted);
        /**
        * @if English
        * Checks whether the camera zooming feature is supported.
        * <br>Make sure that you call this method after the camera starts. For example, you can call this method after you call
        *  \ref IRtcEngine::StartVideoPreview "StartVideoPreview" or  \ref IRtcEngine::JoinChannel "JoinChannel" .
        * @note The audio-only SDK disables this API. If you need to use the API, you can download the standard SDK from the official
        * website of CommsEase and replace the audio-only SDK.
        * @return YES: The camera zooming feature is supported. NO: The camera zooming feature is not supported.
        * @endif
        * @if Chinese
        * 检测设备当前使用的摄像头是否支持缩放功能。
        * <br>该方法需要在相机启动后调用，例如调用 \ref IRtcEngine::StartVideoPreview "StartVideoPreview" 或  \ref IRtcEngine::JoinChannel "JoinChannel" 后。
        * @note 纯音频 SDK 禁用该接口，如需使用请前往云信官网下载并替换成视频 SDK。
        * @return YES 表示支持，NO 表示支持。
        * @endif
        */
        public abstract bool IsCameraZoomSupported();
        /**
        * @if English
        * Checks whether the camera flash feature is supported.
        * @note
        * - In most cases, the app opens the front camera by default. If the front camera does not support the flash feature and you
        * call the method, a value of NO is returned. If you want to check whether the rear camera supports the flash feature, before
        * you call this method, you must first call \ref IRtcEngine::SwitchCamera "SwitchCamera" to switch the camera.
        * - Make sure that you call this method after the camera starts. For example, you can call this method after you call
        * \ref IRtcEngine::StartVideoPreview "StartVideoPreview" or \ref IRtcEngine::JoinChannel "JoinChannel" .
        * - The audio-only SDK disables this API. If you need to use the API, you can download the standard SDK from the official
        * website of CommsEase and replace the audio-only SDK.
        * @return YES: The camera flash feature is supported. NO: The camera flash feature is not supported.
        * @endif
        * @if Chinese
        * 检测设备是否支持闪光灯常亮。
        * @note
        * - 一般情况下，App 默认开启前置摄像头，因此如果设备前置摄像头不支持闪光灯，直接使用该方法会返回
        * NO。如果需要检查后置摄像头是否支持闪光灯，需要先使用 \ref IRtcEngine::SwitchCamera "SwitchCamera" 切换摄像头，再使用该方法。
        * - 该方法需要在相机启动后调用，例如调用 \ref IRtcEngine::StartVideoPreview "StartVideoPreview" 或 \ref IRtcEngine::JoinChannel "JoinChannel" 后。
        * - 纯音频 SDK 禁用该接口，如需使用请前往云信官网下载并替换成视频 SDK。
        * @return YES 表示支持，NO 表示不支持。
        * @endif
        */
        public abstract bool IsCameraTorchSupported();
        /**
        * @if English
        * Checks whether the camera manual focus feature is supported.
        * @note
        * - Make sure that you call this method after the camera starts. For example, you can call this method after you call
        * \ref IRtcEngine::StartVideoPreview "StartVideoPreview" or \ref IRtcEngine::JoinChannel "JoinChannel".
        * - The audio-only SDK disables this API. If you need to use the API, you can download the standard SDK from the official
        * website of CommsEase and replace the audio-only SDK.
        * @return YES: The camera manual focus feature is supported. NO: The camera manual focus feature is not supported.
        * @endif
        * @if Chinese
        * 检测设备是否支持手动对焦功能。
        * @note
        * - 该方法需要在相机启动后调用，例如调用 \ref IRtcEngine::StartVideoPreview "StartVideoPreview" 或 \ref IRtcEngine::JoinChannel "JoinChannel" 后。
        * - 纯音频 SDK 禁用该接口，如需使用请前往云信官网下载并替换成视频 SDK。
        * @return YES 表示支持，NO 表示不支持。
        * @endif
        */
        public abstract bool IsCameraFocusSupported();
        /**
        * @if English
        * Checks whether the camera exposure feature is supported.
        * @note
        * - Make sure that you call this method after the camera starts. For example, you can call this method after you call
        * \ref IRtcEngine::StartVideoPreview "StartVideoPreview" or \ref IRtcEngine::JoinChannel "JoinChannel".
        * - The audio-only SDK disables this API. If you need to use the API, you can download the standard SDK from the official
        * website of CommsEase and replace the audio-only SDK.
        * @return YES: The camera exposure feature is supported. NO: The camera exposure feature is not supported.
        * @endif
        * @if Chinese
        * 检测设备是否支持手动曝光功能。
        * @note
        * - 该方法需要在相机启动后调用，例如调用 \ref IRtcEngine::StartVideoPreview "StartVideoPreview" 或 \ref IRtcEngine::JoinChannel "JoinChannel" 后。
        * - 纯音频 SDK 禁用该接口，如需使用请前往云信官网下载并替换成视频 SDK。
        * @return YES 表示支持，NO 表示不支持。
        * @endif
        */
        public abstract bool IsCameraExposurePositionSupported();
        /**
        * @if English
        * Sets the camera exposure position.
        * <br>After you call the method, the \ref nertc::OnCameraExposureChanged "OnCameraExposureChanged"  callback is triggered on the local client.
        * @note
        * - Make sure that you call this method after the camera starts. For example, you can call this method after you call
        * \ref IRtcEngine::StartVideoPreview "StartVideoPreview" or \ref IRtcEngine::JoinChannel "JoinChannel".
        * - The audio-only SDK disables this API. If you need to use the API, you can download the standard SDK from the official
        * website of CommsEase and replace the audio-only SDK.
        * @param pointX The x-axis value of the exposure position .
        * @param pointY The y-axis value of exposure position .
        * @return The value returned. A value of 0 indicates that the operation is successful.
        * @endif
        * @if Chinese
        * 设置当前摄像头手动曝光位置。
        * <br>成功调用该方法后，本地会触发 \ref nertc::OnCameraExposureChanged "OnCameraExposureChanged" 回调。
        * @note
        * - 该方法需要在相机启动后调用，例如调用 \ref IRtcEngine::StartVideoPreview "StartVideoPreview" 或 \ref IRtcEngine::JoinChannel "JoinChannel" 后。
        * - 纯音频 SDK 禁用该接口，如需使用请前往云信官网下载并替换成视频 SDK。
        * @param pointX 曝光位置点X坐标。
        * @param pointY 曝光位置点Y坐标。
        * @return 操作返回值，成功则返回 0
        * @endif
        */
        public abstract int SetCameraExposurePosition(float pointX, float pointY);
        /**
        * @if English
        * Enables or disables the camera flash feature.
        * @note
        * - Make sure that you call this method after the camera starts. For example, you can call this method after you call
        * \ref IRtcEngine::StartVideoPreview "StartVideoPreview" or \ref IRtcEngine::JoinChannel "JoinChannel".
        * - The audio-only SDK disables this API. If you need to use the API, you can download the standard SDK from the official
        * website of CommsEase and replace the audio-only SDK.
        * @param on YES: turn on. NO: turn off.
        * @return The value returned. A value of 0 indicates that the operation is successful.
        * @endif
        * @if Chinese
        * 设置是否打开闪光灯。
        * @note
        * - 该方法需要在相机启动后调用，例如调用 \ref IRtcEngine::StartVideoPreview "StartVideoPreview" 或 \ref IRtcEngine::JoinChannel "JoinChannel" 后。
        * - 纯音频 SDK 禁用该接口，如需使用请前往云信官网下载并替换成视频 SDK。
        * @param on YES 表示开启；NO 表示关闭。
        * @return 操作返回值，成功则返回 0
        * @endif
        */
        public abstract int SetCameraTorchOn(bool on);
        /**
        * @if English
        * Check whether the flash is turned on on the device.
        * @note The audio-only SDK disables this API. If you need to use the API, you can download the standard SDK from the official
        * website of CommsEase and replace the audio-only SDK.
        * @return YES: turned on; NO: turned off.
        * @endif
        * @if Chinese
        * 查询设备是否开启了闪光灯。
        * @note 纯音频 SDK 禁用该接口，如需使用请前往云信官网下载并替换成视频 SDK。
        * @return YES 表示开启；NO 表示关闭。
        * @endif
        */
        public abstract bool IsCameraTorchOn();
        /**
        * @if English
        * Sets the current camera zoom ratio.
        * @note
        * - Make sure that you call this method after the camera starts. For example, you can call this method after you call
        * \ref IRtcEngine::StartVideoPreview "StartVideoPreview" or \ref IRtcEngine::JoinChannel "JoinChannel".
        * - Before you call this method, we recommend that you view the maximum zoom ratio supported by the camera by calling
        * \ref IRtcEngine::MaxCameraZoomScale "MaxCameraZoomScale" and set a zooming ratio as required.
        * - The audio-only SDK disables this API. If you need to use the API, you can download the standard SDK from the official
        * website of CommsEase and replace the audio-only SDK.
        * @param factor The zoom ratio supported by the camera.
        * @return The value returned. A value of 0 indicates that the operation is successful.
        * @endif
        * @if Chinese
        * 设置当前摄像头缩放比例。
        * @note
        * - 该方法需要在相机启动后调用，例如调用 \ref IRtcEngine::StartVideoPreview "StartVideoPreview" 或 \ref IRtcEngine::JoinChannel "JoinChannel" 后。
        * - 建议在调用本接口前，先通过 \ref IRtcEngine::MaxCameraZoomScale "MaxCameraZoomScale" 查看摄像头支持的最大缩放比例，并根据实际需求合理设置需要的缩放比例。
        * - 纯音频 SDK 禁用该接口，如需使用请前往云信官网下载并替换成视频 SDK。
        * @param factor 摄像头缩放比例。
        * @return 操作返回值，成功则返回 0
        * @endif
        */
        public abstract int SetCameraZoomFactor(float factor);
        /**
        * @if English
        * Gets maximum zoom ratio supported by the camera.
        * @note
        * - Make sure that you call this method after the camera starts. For example, you can call this method after you call
        * \ref IRtcEngine::StartVideoPreview "StartVideoPreview" or \ref IRtcEngine::JoinChannel "JoinChannel".
        * - The audio-only SDK disables this API. If you need to use the API, you can download the standard SDK from the official
        * website of CommsEase and replace the audio-only SDK.
        * @return The maximum zoom ratio is returned.
        * @endif
        * @if Chinese
        * 获取摄像头支持最大缩放比例。
        * @note
        * - 该方法需要在相机启动后调用，例如调用 \ref IRtcEngine::StartVideoPreview "StartVideoPreview" 或 \ref IRtcEngine::JoinChannel "JoinChannel" 后。
        * - 纯音频 SDK 禁用该接口，如需使用请前往云信官网下载并替换成视频 SDK。
        * @return 最大缩放比例。
        * @endif
        */
        public abstract float MaxCameraZoomScale();
        /**
        * @if English
        * Sets the camera manual focus position.
        * <br>After you call the method, the \ref nertc::OnCameraFocusChanged "OnCameraFocusChanged" callback is triggered on the local client.
        * @note
        * - Make sure that you call this method after the camera starts. For example, you can call this method after you call
        * \ref IRtcEngine::StartVideoPreview "StartVideoPreview" or \ref IRtcEngine::JoinChannel "JoinChannel".
        * - The audio-only SDK disables this API. If you need to use the API, you can download the standard SDK from the official
        * website of CommsEase and replace the audio-only SDK.
        * @param x The horizontal coordinate of the touch point in the view. Value range: 0 to 1.
        * @param y The vertical coordinate of the touch point in the view. Value range: 0 to 1.
        * @return The value returned. A value of 0 indicates that the operation is successful.
        * @endif
        * @if Chinese
        * 设置手动对焦位置。
        * <br>成功调用该方法后，本地会触发  \ref nertc::OnCameraFocusChanged "OnCameraFocusChanged" 回调。
        * @note
        * - 该方法需要在相机启动后调用，例如调用 \ref IRtcEngine::StartVideoPreview "StartVideoPreview" 或 \ref IRtcEngine::JoinChannel "JoinChannel" 后。
        * - 纯音频 SDK 禁用该接口，如需使用请前往云信官网下载并替换成视频 SDK。
        * @param x 触摸点相对于视图的横坐标，范围为 0~1。
        * @param y 触摸点相对于视图的纵坐标，范围为 0~1。
        * @return 操作返回值，成功则返回 0
        * @endif
        */
        public abstract int SetCameraFocusPosition(float x, float y);
        /**
        * @if English
        * Sets the camera capturer configuration.
        * <br>For a video call or live streaming, generally the SDK controls the camera output parameters. By default, the SDK
        * matches the most appropriate resolution based on the user's \ref IRtcEngine::SetVideoConfig "SetVideoConfig" configuration. When the default camera capture
        * settings do not meet special requirements, we recommend using this method to set the camera capturer configuration:
        * - If you want better quality for the local video preview, we recommend setting config as \ref RtcCameraPreference::kNERtcCameraOutputQuality "kNERtcCameraOutputQuality" . The SDK
        * sets the camera output parameters with higher picture quality.
        * - To customize the width and height of the video image captured by the local camera, set the camera capture configuration
        * as \ref RtcCameraPreference::kNERtcCameraOutputManual "kNERtcCameraOutputManual" .
        * @note
        * - Call this method before or after joining the channel. The setting takes effect immediately without restarting the camera.
        * - Higher collection parameters means higher performance consumption, such as CPU and memory usage, especially when video
        * pre-processing is enabled.
        * @since V4.5.0
        * @param[in] config    Capture preference and resolution of video cameras.
        * @return {@code 0} A value of 0 returned indicates that the method call is successful. Otherwise, the method call fails.
        * @endif
        * @if Chinese
        * 设置本地摄像头的采集偏好等配置。
        * <br>在视频通话或直播中，SDK 自动控制摄像头的输出参数。默认情况下，SDK 根据用户的 \ref IRtcEngine::SetVideoConfig "SetVideoConfig" 
        * 配置匹配最合适的分辨率进行采集。但是在部分业务场景中，如果采集画面质量无法满足实际需求，可以调用该接口调整摄像头的采集配置。
        * - 需要采集并预览高清画质时，可以将采集偏好设置为 \ref RtcCameraPreference::kNERtcCameraOutputQuality "kNERtcCameraOutputQuality" ，此时 SDK
        * 会自动设置较高的摄像头输出参数，本地采集与预览画面比编码参数更加清晰。
        * - 需要自定义设置摄像头采集的视频尺寸时，请通过参数 preference 将采集偏好设为 \ref RtcCameraPreference::kNERtcCameraOutputManual "kNERtcCameraOutputManual"，并通过
        * \ref RtcCameraCaptureConfig "RtcCameraCaptureConfig" 中的 \ref RtcCameraCaptureConfig::captureWidth "captureWidth" 和 \ref RtcCameraCaptureConfig::captureHeight "captureHeight" 自定义设置本地摄像头采集的视频宽高。
        * @note
        * - 该方法可以在加入房间前后动态调用，设置成功后立即生效，无需重启摄像头。
        * - 设置更高的采集参数会导致更大的性能消耗，例如 CPU 和内存占用等，尤其是在开启视频前处理的场景下。
        * @since V4.5.0
        * @param[in] config    摄像头采集偏好配置。详细说明请参考 \ref RtcCameraCaptureConfig "RtcCameraCaptureConfig" 。
        * @return {@code 0} 方法调用成功，其他调用失败
        * @endif
        */
        public abstract int SetCameraCaptureConfig(RtcCameraCaptureConfig config);
        /**
        * @if English
        * Unsubscribes or subscribes to audio streams from all remote users.
        * @note
        * - When joins a room, local user subscribe audio streams from all remote users by default. Under the circumstances, do not
        * call \ref IRtcEngine::SubscribeAllRemoteAudioStream "SubscribeAllRemoteAudioStream" to subscribe audio streams again.
        * - You can call this method before joining a channel.
        * @since V4.5.0
        * @param subscribe Whether to unsubscribe audio streams from all remote users.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 取消或恢复订阅所有远端用户音频流。
        * @note
        * - 加入房间时，默认订阅所有远端用户的音频，此时请勿调用 \ref IRtcEngine::SubscribeAllRemoteAudioStream "SubscribeAllRemoteAudioStream" 重复订阅所有远端用户的音频流。
        * - 该方法需要在加入房间后调用，对后续加入的用户也同样生效。
        * @since V4.5.0
        * @param subscribe 是否取消订阅所有远端用户的音频流。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SubscribeAllRemoteAudioStream(bool subscribe);
        /**
        * @if English
        * Sets local video parameters.
        * @note
        * - You can call this method before or after you join the room.
        * - After the setting is configured, the setting takes effect the next time local video is enabled.
        * - Each profile has a set of video parameters, such as resolution, frame rate, and bitrate. All the specified values of the
        * parameters are the maximum values in optimal conditions. If the video engine cannot use the maximum value of resolution,
        * due to poor network performance, the value closest to the maximum value is taken.
        * @param[in] config        Sets the video encoding parameters. For more information, see {@link RtcVideoConfig}.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置本地视频的编码属性。
        * 可以在加入房间前或加入房间后调用。设置成功后，下一次开启本端视频时生效。
        * @note
        * - 每个属性对应一套视频参数，例如分辨率、帧率、码率等。
        * 所有设置的参数均为理想情况下的最大值。当视频引擎因网络环境等原因无法达到设置的分辨率的最大值时，会取最接近最大值的那个值。
        * - setVideoConfig 为全量参数配置接口，重复调用此接口时，SDK
        * 会刷新此前的所有参数配置，以最新的传参为准。所以每次修改配置时都需要设置所有参数，未设置的参数将取默认值。
        * @param[in] config        视频编码属性配置，详细信息请参考 {@link RtcVideoConfig}。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetVideoConfig(RtcVideoConfig config);
        /**
        * @if English
        * Specifies whether to enable or disable the dual stream mode.
        * <br>The method sets the single-stream mode or dual-stream mode. If the dual-stream mode is enabled, the receiver can choose
        * to receive the high-quality stream or low-quality stream video. The high-quality stream has a high resolution and high
        * bitrate. The low-quality stream has a low resolution and low bitrate.
        * @note
        * - The method applies to camera data only. Video streams from external input and screen sharing are not affected.
        * - You can call this method before or after you join a room. After the method is set, it can take effect after restarting
        * the camera.
        * @param[in] enable        Whether to enable dual-stream mode.
        * - true: Enables the dual-stream mode. This is the default value.
        * - false: Disables the dual-stream mode.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置是否开启视频大小流模式。
        * <br>该方法设置单流或者双流模式。发送端开启双流模式后，接收端可以选择接收大流还是小流。其中，大流指高分辨率、高码率的视频流，小流指低分辨率、低码率的视频流。
        * @note
        * - 该方法只对摄像头数据生效，自定义输入、屏幕共享等视频流无效。
        * - 该方法在加入房间前后都能调用。设置后，会在摄像头重启后生效。
        * @param[in] enable        指定是否开启双流模式。
        * - true: （默认）开启双流模式。
        * - false: 关闭双流模式。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int EnableDualStreamMode(bool enable);
        /**
        * @if English
        * Sets a remote substream canvas.
        * - This method is used to set the display information about the local secondary stream video. The app associates with the
        * video view of local secondary stream by calling this method.
        * - During application development, in most cases, before joining a room, you must first call this method to set the local
        * video view after the SDK is initialized.
        * @param[in] canvas        The video canvas information.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        *
        * @endif
        * @if Chinese
        * 设置本地辅流视频画布。
        * - 该方法设置本地辅流视频显示信息。App 通过调用此接口绑定本地辅流的显示视窗（view）。
        * - 在 App 开发中，通常在初始化后调用该方法进行本地视频设置，然后再加入房间。
        * @param[in] canvas        视频画布信息。
        * @return
        * - 0: 方法调用成功。
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetupLocalSubstreamVideoCanvas(RtcVideoCanvas canvas);
        /**
        * @if English
        * Sets the local view display mode.
        * <br>This method is used to set the display mode about the local view. The application can repeatedly call the method to
        * change the display mode.
        * @note You must set local secondary canvas before enabling screen sharing.
        * @param[in] scalingMode  The video display mode #RtcVideoScalingMode .
        * @return
        * - 0: Success.
        * - Other values: Failure.
        *
        * @endif
        * @if Chinese
        * 设置本端的屏幕共享辅流视频显示模式。
        * <br>该方法设置本地视图显示模式。 App 可以多次调用此方法更改显示模式。
        * @note 调用此方法前，必须先通过 \ref IRtcEngine::SetupLocalSubstreamVideoCanvas "SetupLocalSubstreamVideoCanvas" 设置本地辅流画布。
        * @param[in] scalingMode  视频显示模式 #RtcVideoScalingMode 。
        * @return
        * - 0: 方法调用成功。
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetLocalSubstreamRenderMode(RtcVideoScalingMode scalingMode);
        /**
        * @if English
        * Sets the display mode for local substreams video of screen sharing.
        * This method is used to set the display mode about the local view. The application can repeatedly call the method to change
        * the display mode.
        * @note You must set the local canvas for local substreams through \ref IRtcEngine::SetupLocalSubstreamVideoCanvas "SetupLocalSubstreamVideoCanvas" .
        * @param[in] scalingMode      The video display mode. #RtcVideoScalingMode .
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置本地视图显示模式。
        * 该方法设置本地视图显示模式。 App 可以多次调用此方法更改显示模式。
        * @note 在打开屏幕共享前必须通过 \ref IRtcEngine::SetupLocalSubstreamVideoCanvas "SetupLocalSubstreamVideoCanvas" 设置本地辅流画布。
        * @param[in] scalingMode      视频显示模式: #RtcVideoScalingMode
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetLocalRenderMode(RtcVideoScalingMode scalingMode);
        /**
        * @if English
        * Sets the mirror mode of the local video.
        * The method is used to set whether to enable the mirror mode for the local video. The mirror code determines whether to flip
        * the screen view right or left. Mirror mode for local videos only affects what local users view. The views of remote users
        * are not affected. App can repeatedly call this method to modify the mirror mode.
        * @param[in] mirrorMode       The video mirror mode. For more information, see {@link RtcVideoMirrorMode}.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置本地视频镜像模式。
        * 该方法用于设置本地视频是否开启镜像模式，即画面是否左右翻转。
        * 本地的视频镜像模式仅影响本地用户所见，不影响远端用户所见。App 可以多次调用此方法更改镜像模式。
        *  @param[in] mirrorMode      视频镜像模式。详细信息请参考 {@link RtcVideoMirrorMode}。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetLocalVideoMirrorMode(RtcVideoMirrorMode mirrorMode);
        /**
        * @if English
        * Sets display mode for remote views.
        * This method is used to set the display mode for the remote view. App can repeatedly call this method to modify the display
        * mode.
        * @param[in] uid           The ID of a remote user.
        * @param[in] scalingMode  The video display mode. #RtcVideoScalingMode.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置远端视图显示模式。
        * 该方法设置远端视图显示模式。App 可以多次调用此方法更改显示模式。
        * @param[in] uid           远端用户 ID。
        * @param[in] scalingMode  视频显示模式: #RtcVideoScalingMode
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetRemoteRenderMode(ulong uid, RtcVideoScalingMode scalingMode);
        /**
        * @if English
        * Sets a remote substream video canvas.
        * <br>The method associates a remote user with a substream view. You can assign a specified uid to use a corresponding
        * canvas.
        * @note
        * - If the uid is not retrieved, you can set the user ID after the app receives a message delivered when the 
        * \ref nertc::OnUserJoined "OnUserJoined" is triggered.
        * - After a user leaves the room, the association between a remote user and the view is cleared.
        * - After a user leaves the room, the association between a remote user and the canvas is cleared. The setting is
        * automatically invalid.
        * @param[in] uid       The ID of a remote user.
        * @param[in] canvas    The video canvas settings.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        *
        * @endif
        * @if Chinese
        * 设置远端的辅流视频画布。
        * <br>该方法绑定远端用户和辅流显示视图，即指定某个 uid 使用对应的画布显示。
        * @note
        * - 如果 App 无法事先知道对方的 uid，可以在 APP 收到 \ref nertc::OnUserJoined "OnUserJoined" 事件时设置。
        * - 退出房间后，SDK 会清除远端用户和画布的的绑定关系，该设置自动失效。
        * @param[in] uid       远端用户 ID。
        * @param[in] canvas    视频画布设置
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetupRemoteSubstreamVideoCanvas(ulong uid,RtcVideoCanvas canvas);
        /**
        * @if English
        * Subscribes to or unsubscribes from remote substream video from screen sharing. You can receive the substream video data
        * only after you subscribe to remote substream video stream.
        * @note
        * - You must call the method after joining a room.
        * - You must first set a remote substream canvas.
        * @param[in] uid           The user ID.
        * @param[in] subscribe
        * - true: Subscribes to or unsubscribes from video streams from specified remote users.
        * - false: Unsubscribes from video streams of specified remote users.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        *
        * @endif
        * @if Chinese
        * 订阅或取消订阅远端的屏幕共享辅流视频，订阅之后才能接收远端的辅流视频数据。
        * @note
        * - 必须在远端加入房间后调用。
        * - 调用此接口前，必须先通过 \ref IRtcEngine::SetupRemoteSubstreamVideoCanvas "SetupRemoteSubstreamVideoCanvas" 设置远端辅流画布。
        * @param[in] uid           指定用户的用户 ID。
        * @param[in] subscribe
        * - true: 订阅指定远端用户的视频流。
        * - false: 取消订阅指定远端用户的视频流。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SubscribeRemoteVideoSubstream(ulong uid, bool subscribe);
        /**
        * @if English
        * Sets substream video display modes for remote screen sharing.
        * <br>You can use the method when screen sharing is enabled in substreams on the remote side. The application can repeatedly
        * call the method to change the display mode.
        * @param[in] uid           The ID of a remote user.
        * @param[in] scalingMode  The video display mode. #RtcVideoScalingMode.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        *
        * @endif
        * @if Chinese
        * 设置远端的屏幕共享辅流视频显示模式。
        * <br>在远端开启辅流形式的屏幕共享时使用。App 可以多次调用此方法更改显示模式。
        * @param[in] uid           远端用户 ID。
        * @param[in] scalingMode  视频显示模式。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetRemoteSubsteamRenderMode(ulong uid, RtcVideoScalingMode scalingMode);
        /**
        * @if English
        * Enables video preview.
        * <br>The method is used to enable local video preview before you join a room. Prerequisites for calling the API:
        * - Calls \ref IRtcEngine::SetupLocalVideoCanvas "SetupLocalVideoCanvas" to set preview window.
        * @note After the local video preview is enabled, you must first disable the local preview and call \ref
        * IRtcEngine::StopVideoPreview "stopVideoPreview" before joining the room.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 开启视频预览。
        * <br>该方法用于在进入房间前启动本地视频预览。调用该 API 前，必须:
        * - 调用 \ref IRtcEngine::SetupLocalVideoCanvas "SetupLocalVideoCanvas" 设置预览窗口；
        * @note 启用了本地视频预览后，在进入房间前，本地预览必须先关闭，需要先调用 \ref IRtcEngine::StopVideoPreview
        * "StopVideoPreview" 。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int StartVideoPreview();
        /**
        * @if English
        * Stops video preview.
        * @note This method needs to be called before a user joins a room.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 停止视频预览。
        * @note 该方法需要在加入房间前调用。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int StopVideoPreview();
        /**
        * @if English
        * Enables or disables publishing the local video stream.
        * <br>If the method is called Successfully, \ref nertc::OnUserVideoMute "OnUserVideoMute" is triggered remotely.
        * @note
        * - When you call the method to disable video streams,  the SDK doesn’t send local video streams but the camera is still
        * working.
        * - The method can be called before or after a user joins a room.
        * - If you stop publishing the local video stream by calling this method, the option is reset to the default state that
        * allows the app to publish the local video stream.
        * - \ref nertc::IRtcEngine::EnableLocalVideo "EnableLocalVideo" (false) is different from \ref
        * nertc::IRtcEngine::EnableLocalVideo "EnableLocalVideo" (false). The \ref IRtcEngine::EnableLocalVideo "EnableLocalVideo" (false) method turns off local camera
        * devices. The \ref nertc::IRtcEngine::MuteLocalVideoStream "MuteLocalVideoStream" method does not affect local video capture, or disable cameras, and responds faster.
        * @param[in] mute
        * - true: Not publishing local video streams.
        * - false: Publishing local video streams (default).
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 取消或恢复发布本地视频流。
        * <br>成功调用该方法后，远端会触发 \ref nertc::OnUserVideoMute "OnUserVideoMute" 回调。
        * @note
        * - 调用该方法禁视频流时，SDK 不再发送本地视频流，但摄像头仍然处于工作状态。
        * - 该方法在加入房间前后均可调用。
        * - 若调用该方法取消发布本地视频流，通话结束后会被重置为默认状态，即默认发布本地视频流。
        * - 该方法与 \ref IRtcEngine::EnableLocalVideo "EnableLocalVideo" (false) 的区别在于， \ref
        *  IRtcEngine::EnableLocalVideo "EnableLocalVideo" (false)
        * 会关闭本地摄像头设备，\ref nertc::IRtcEngine::MuteLocalVideoStream "MuteLocalVideoStream" 不影响本地视频流采集，不禁用摄像头，且响应速度更快。
        * @param[in] mute
        * - true: 不发送本地视频流
        * - false: 发送本地视频流（默认）
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int MuteLocalVideoStream(bool mute);
        /**
        * @if English
        * Sets the priority of media streams from a local user.
        * <br>If a user has a high priority, the media stream from the user also has a high priority. In unreliable network
        connections, the SDK guarantees the quality the media stream from users with a high priority.
        * @note
        * - You must call the method before you call \ref IRtcEngine::JoinChannel "JoinChannel".
        * - After switching channels, media priority changes to the default value of normal priority.
        * - An RTC room has only one user that has a high priority. We recommend that only one user in a room call the
        * \ref IRtcEngine::SetLocalMediaPriority "SetLocalMediaPriority" method to set the local media stream a high priority. Otherwise, you need to enable the preempt mode to
        * ensure the high priority of the local media stream.
        * @param priority      The priority of the local media stream. The default value is \ref RtcMediaPriorityType::kNERtcMediaPriorityNormal "kNERtcMediaPriorityNormal" . For more
        * information, see #RtcMediaPriorityType.
        * @param isPreemptive specifies whether to enable the preempt mode. The default value is false, which indicates that the
        * preempt mode is disabled.
        *       - If the preempt mode is enabled, the local media stream preempts the high priority over other users.
        * The priority of the media stream whose priority is taken becomes normal. After the user whose priority is taken leaves the
        * room, other users still keep the normal priority.
        *       - If the preempt mode is disabled, and a user in the room has a high priority. After that, the high
        * priority of the local client remains invalid and is still normal.
        * @return
        *   - 0: Success.
        *   - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置本地用户的媒体流优先级。
        * <br>如果某个用户的优先级为高，那么该用户媒体流的优先级就会高于其他用户，弱网环境下 SDK
        会优先保证其他用户收到的、高优先级用户的媒体流的质量。
        * @note
        * - 请在加入房间（\ref IRtcEngine::JoinChannel "JoinChannel"）前调用此方法。
        * - 快速切换房间 （ \ref IRtcEngine::SwitchChannel "SwitchChannel" ） 后，媒体优先级会恢复为默认值，即普通优先级。
        * - 一个音视频房间中只有一个高优先级的用户。建议房间中只有一位用户调用 \ref IRtcEngine::SetLocalMediaPriority "SetLocalMediaPriority" 
        将本端媒体流设为高优先级，否则需要开启抢占模式，保证本地用户的高优先级设置生效。
        * @param priority      本地用户的媒体流优先级，默认为 \ref RtcMediaPriorityType::kNERtcMediaPriorityNormal "kNERtcMediaPriorityNormal" 。详细信息请参考 #RtcMediaPriorityType 。
        * @param isPreemptive 是否开启抢占模式。默认为 false，即不开启。
        *       - 抢占模式开启后，本地用户可以抢占其他用户的高优先级，被抢占的用户的媒体优先级变为普通优先级，在抢占者退出房间后，其他用户的优先级仍旧维持普通优先级。
        *       - 抢占模式关闭时，如果房间中已有高优先级用户，则本地用户的高优先级设置不生效，仍旧为普通优先级。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetLocalMediaPriority(int priority, bool isPreemptive);
        /**
        * @if English
        * Sets parameters for audio and video calls. You can configure the SDK through JSON to provide features like technology
        * review and special customization. Publicizes JSON options in a standardized way.
        * @param[in] parameters  Related parameters for audio and video calls whose format is the JSON string.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置音视频通话的相关参数。通过 JSON 配置 SDK 提供技术预览或特别定制功能。以标准化方式公开 JSON 选项。
        * @param[in] parameters 音视频通话的相关参数。  JSON 字符串形式。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetParameters(string parameters);
        /**
        * @if English
        * Sets the audio recording format.
        * <br>The method is used to set audio recording format of \ref IAudioFrameObserver::OnAudioFrameDidRecord
        * "OnAudioFrameDidRecord" callback.
        * @note
        * - The method can be called before or after a user joins a room.
        * - Stops listening and sets the value as empty.
        * @param format The sample rate and channels of data returned in the   \ref IAudioFrameObserver::OnAudioFrameDidRecord "OnAudioFrameDidRecord" . A value of NULL is allowed.
        * The default value is NULL.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置录制的声音格式。
        * <br>该方法设置 \ref IAudioFrameObserver::OnAudioFrameDidRecord "OnAudioFrameDidRecord" 回调的录制声音格式。
        * @note
        * - 该方法在加入房间前后均可设置或修改。
        * - 取消监听，重置为空。
        * @param format 指定 \ref IAudioFrameObserver::OnAudioFrameDidRecord "OnAudioFrameDidRecord"  中返回数据的采样率和数据的通道数。允许传入 NULL，默认为 NULL。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetRecordingAudioFrameParameters(RtcAudioFrameRequestFormat format);
        /**
        * @if English
        * Sets the audio playback format.
        * <br>The method is used to set audio recording format of \ref IAudioFrameObserver::OnAudioFrameWillPlayback
        * "OnAudioFrameWillPlayback" callback.
        * @note
        * - The method can be called or modified before or after a user joins a room.
        * - Stops listening and sets the value as empty.
        * @param format The sample rate and channels of data returned in the  \ref IAudioFrameObserver::OnAudioFrameWillPlayback "OnAudioFrameWillPlayback". A value of NULL is allowed.
        * The default value is NULL.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置播放的声音格式。
        * <br>该方法设置 \ref IAudioFrameObserver::OnAudioFrameWillPlayback "OnAudioFrameWillPlayback"
        * 回调的播放声音格式。
        * @note
        * - 该方法在加入房间前后均可设置或修改。
        * - 取消监听，重置为空。
        * @param format 指定  \ref IAudioFrameObserver::OnAudioFrameWillPlayback "OnAudioFrameWillPlayback" 中返回数据的采样率和数据的通道数。允许传入 NULL，默认为 NULL。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetPlaybackAudioFrameParameters(RtcAudioFrameRequestFormat format);
        /**
        * @if English
        * Sets the sample rate of audio mixing stream after the audio is recording and playback.
        * <br>The method is used to set audio recording format of \ref IAudioFrameObserver::OnMixedAudioFrame "OnMixedAudioFrame" .
        * @note
        * - The method can be called before or after a user joins a room.
        * - Currently supports setting the sample rate only.
        * - If you do not call the interface to set the data format, the sample rate in the callback return the default value set by
        * the SDK.
        * @param sampleRate   The sample rate of data returned in  \ref IAudioFrameObserver::OnMixedAudioFrame "OnMixedAudioFrame" . Only 8000, 16000, 32000, 44100, and 48000
        * are supported.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置录制和播放声音混音后的采样率。
        * <br>该方法设置 \ref IAudioFrameObserver::OnMixedAudioFrame "OnMixedAudioFrame" 回调的声音格式。
        * @note
        * - 该方法在加入房间前后均可设置或修改。
        * - 目前只支持设置采样率。
        * - 未调用该接口设置数据格式时，回调中的采样率返回 SDK 默认值。
        * @param sampleRate   指定 \ref IAudioFrameObserver::OnMixedAudioFrame "OnMixedAudioFrame" 中返回数据的采样率。仅支持 8000， 16000， 32000， 44100或48000。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetMixedAudioFrameParameters(int sampleRate);
        /**
        * @if English
        * Registers the audio observer object.
        * <br>The method is used to set audio capture or play PCM data callbacks. You can use the method to process audios. You need
        * to register callbacks with this method when engine needs to trigger callbacks of \ref
        * IAudioFrameObserver::OnAudioFrameDidRecord "OnAudioFrameDidRecord" or \ref
        * IAudioFrameObserver::OnAudioFrameWillPlayback "OnAudioFrameWillPlayback".
        * @param observer  The object instance. If you pass in NULL, you cancel the registration and clear the settings of
        * \ref RtcAudioFrameRequestFormat.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 注册语音观测器对象。
        * <br>该方法用于设置音频采集和播放PCM回调，可用于声音处理等操作。当需要引擎给出 \ref
        * IAudioFrameObserver::OnAudioFrameDidRecord "OnAudioFrameDidRecord" 或 \ref
        * IAudioFrameObserver::OnAudioFrameWillPlayback "OnAudioFrameWillPlayback" 回调时，需要使用该方法注册回调。
        * @param observer  接口对象实例。如果传入 NULL，则取消注册，同时会清理 \ref RtcAudioFrameRequestFormat 相关设置。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetAudioFrameObserver(IAudioFrameObserver observer);
        /**
        * @if English
        * Starts recording an audio dump file. Audio dump files can be used to analyze audio issues.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 开始记录音频 dump。 音频 dump 可用于分析音频问题。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int StartAudioDump();
        /**
        * @if English
        * Finishes recording an audio dump file.
        * @return
        - 0: Success.
        - Other values: Failure.
        * @endif
        * @if Chinese
        * 结束音频dump。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int StopAudioDump();
        /**
        * @if English
        Set the speaker mode（for iOS and Android）

        @param enable Whether to enable the speaker mode
        @return The return value. 0 is returned for success        
        * @endif
        * @if Chinese
        设置音频播放扬声器模式（仅iOS/Android有效）

        @param enable 是否使用扬声器模式
        @return 操作返回值，成功则返回 0
        * @endif
        */
        public abstract int SetLoudSpeakerMode(bool enable);
        /**
        * @if English
        Get the current speaker mode（for iOS and Android）

        @param enabled Whether to enable the speaker mode
        * @return
        - 0: success.
        - Other values: failure.    
        * @endif
        * @if Chinese
        获取目前是否使用扬声器模式（仅iOS/Android有效）

        @param enabled 是否正在使用扬声器模式
        @return
        - 0: 方法调用成功；
        - 其他: 方法调用失败。
        * @endif
        */
        public abstract int GetLoudSpeakerMode(ref bool enabled);
        /**
        * @if English
        * Starts playing a music file.
        * <br>This method mixes the specified local or online audio file with the audio stream captured by the audio devices.
        * - Supported audio formats: MP3, M4A, AAC, 3GP, WMA, and WAV. Files that are stored in local or online URLs are supported.
        * - After you successfully call the method, if the playback status is changed, the local triggers 
        *\ref nertc::OnAudioMixingStateChanged "OnAudioMixingStateChanged" 
        * callbacks.
        * @note
        * - You can call this method after joining a room.
        * - Since V4.3.0, if you call this method to play a music file during a call, and manually set the playback volume of the
        * audio mixing and the sent volume, the setting is used when you call the method again during the current call.
        * @param[in] option        Options of creating audio mixing configurations that include types, full path or URL. For more
        * information, see {@link RtcCreateAudioMixingOption} .
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 开始播放音乐文件。
        * <br>该方法指定本地或在线音频文件来和录音设备采集的音频流进行混音。
        * - 支持的音乐文件类型包括 MP3、M4A、AAC、3GP、WMA 和 WAV 格式，支持本地文件或在线 URL。
        * - 成功调用该方法后，如果播放状态改变，本地会触发 \ref nertc::OnAudioMixingStateChanged "OnAudioMixingStateChanged" 
        * 回调。
        * @note
        * - 请在加入房间后调用该方法。
        * - 从 V4.3.0 版本开始，
        * 若您在通话中途调用此接口播放音乐文件时，手动设置了伴音播放音量或发送音量，则当前通话中再次调用时默认沿用此设置。
        * - 在 V4.4.0 版本中，开启或关闭本地音频采集的操作不影响音乐文件在远端的播放，即 #EnableLocalAudio (false)
        * 后仍旧可以发送伴音。在其他版本中，必须开启音频采集才能发送伴音。
        * @param[in] option        创建混音任务配置的选项，包括混音任务类型、混音文件全路径或URL等。详细信息请参考 {@link RtcCreateAudioMixingOption} 。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int StartAudioMixing(RtcCreateAudioMixingOption option);
        /**
        * @if English
        * Stops playing music files or audio mixing.
        * <br>The method stops playing the audio mixing. You can call the method when you are in a room.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 停止播放音乐文件及混音。
        * <br>该方法停止播放伴奏。请在房间内调用该方法。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int StopAudioMixing();
        /**
        * @if English
        * Stops playing music files or audio mixing.
        * <br>The method pauses playing audio mixing. You can call the method when you are in a room.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 暂停播放音乐文件及混音。
        * <br>该方法暂停播放伴奏。请在房间内调用该方法。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int PauseAudioMixing();
        /**
        * @if English
        * Resumes playing the audio mixing.
        * <br>The method resumes audio mixing, and continues playing the audio mixing. You can call the method when you are in a
        * room.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 恢复播放伴奏。
        * <br>该方法恢复混音，继续播放伴奏。请在房间内调用该方法。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int ResumeAudioMixing();
        /**
        * @if English
        * Adjusts the audio mixing volume for publishing.
        * <br>The method adjusts the volume for publishing of the audio mixing in the audio mixing. You can call the method when you
        * are in a room.
        * @param[in] volume    The audio mixing volume for publishing. Valid values: 0 to 100. The default value of 100 represents
        * the original volume.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 调节伴奏发送音量。
        * <br>该方法调节混音里伴奏的发送音量大小。请在房间内调用该方法。
        * @param[in] volume    伴奏发送音量。取值范围为 0~100。默认 100 为原始文件音量。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetAudioMixingSendVolume(uint volume);
        /**
        * @if English
        * Gets the volume for publishing of audio mixing.
        * <br>The method gets the volume for publishing of the audio mixing in the audio mixing. You can call the method when you are
        * in a room.
        * @param[out] volume   The volume for publishing of the audio mixing.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 获取伴奏发送音量。
        * <br>该方法获取混音里伴奏的发送音量大小。请在房间内调用该方法。
        * @param[out] volume   伴奏发送音量。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int GetAudioMixingSendVolume(ref uint volume);
        /**
        * @if English
        * Adjusts the playback volume of the audio mixing.
        * <br>The method adjusts the playback volume of the audio mixing in the audio mixing. You can call the method when you are in
        * a room.
        * @param[in] volume    The volume range of the audio mixing is 0 to 100. The default value of 100 represents the original
        * volume.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 调节伴奏播放音量。
        * <br>该方法调节混音里伴奏的播放音量大小。请在房间内调用该方法。
        * @param[in] volume    伴奏音量范围为 0~100。默认 100 为原始文件音量。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetAudioMixingPlaybackVolume(uint volume);
        /**
        * @if English
        * Gets the playback volume of the audio mixing.
        * <br>The method gets the playback volume of the audio mixing in the audio mixing. You can call the method when you are in a
        * room.
        * @param[out] volume   The volume of the audio mixing.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 获取伴奏播放音量。
        * <br>该方法获取混音里伴奏的播放音量大小。请在房间内调用该方法。
        * @param[out] volume   伴奏播放音量。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int GetAudioMixingPlaybackVolume(ref uint volume);
        /**
        * @if English
        * Gets the duration of the audio mixing.
        * <br>The method gets the duration of the audio mixing. Unit: milliseconds. You can call the method when you are in a room.
        * @param[out] duration     The duration of the audio mixing. Unit: milliseconds.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 获取伴奏时长。
        * <br>该方法获取伴奏时长，单位为毫秒。请在房间内调用该方法。
        * @param[out] duration     伴奏时长，单位为毫秒。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int GetAudioMixingDuration(ref ulong duration);
        /**
        * @if English
        * Gets the playback position of the music file.
        * <br>The method gets the playback position of the music file. Unit: milliseconds. You can call the method when you are in a
        * room.
        * @param[out] position     The playback position of the audio mixing file. Unit: milliseconds.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 获取音乐文件的播放进度。
        * <br>该方法获取当前伴奏播放进度，单位为毫秒。请在房间内调用该方法。
        * @param[out] position     伴奏播放进度，单位为毫秒。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int GetAudioMixingCurrentPosition(ref ulong position);
        /**
        * @if English
        * Sets the playback position of the music file to a different starting position.
        * <br>The method sets the playback position of the music file to a different starting position. The method allows you to play
        * the music file from the position based on your requirements rather than from the beginning of the music file.
        * @param[in] seekPosition     The playback position of the music file. Unit: milliseconds.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置音乐文件的播放位置。
        * <br>该方法可以设置音频文件的播放位置，这样你可以根据实际情况播放文件，而非从头到尾播放整个文件。
        * @param[in] seekPosition     进度条位置，单位为毫秒。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetAudioMixingPosition(ulong seekPosition);
        /**
        * @if English
        * Plays a specified audio effect file.
        * - After the method is successfully called, if the playback ends, the \ref nertc::OnAudioEffectFinished "OnAudioEffectFinished" callback is triggered.
        * - Supported audio formats: MP3, M4A, AAC, 3GP, WMA, and WAV. Files that are stored in local or online URLs are supported.
        * @note
        * - You can call this method after joining a room.
        * - You can call the method for multiple times. You can play multiple audio effect files simultaneously by passing in
        * different effectIds and options. Various audio effects are mixed. To gain optimal user experience, we recommend you to
        * play no more than three audio effect files at the same time.
        * @param[in] effectId         The ID of the specified audio effect. Each audio effect has a unique ID.
        * @param[in] option            The options of creating audio effect files configurations including types, full path or URL of
        * audio mixing files. For more information, see {@link RtcCreateAudioEffectOption} .
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 播放指定音效文件。
        * - 成功调用该方法后，如果播放结束，本地会触发 \ref nertc::OnAudioEffectFinished "OnAudioEffectFinished" 回调。
        * - 支持的音效文件类型包括 MP3、M4A、AAC、3GP、WMA 和 WAV 格式，支持本地文件和在线 URL。
        * @note
        * - 请在加入房间后调用该方法。
        * - 您可以多次调用该方法，通过传入不同的音效文件的effectId 和 option
        * ，同时播放多个音效文件，实现音效叠加。为获得最佳用户体验，建议同时播放的音效文件不超过 3 个。
        * @param[in] effectId         指定音效的 ID。每个音效均有唯一的 ID。
        * @param[in] option            创建音效任务配置的选项，包括混音任务类型、混音文件全路径或 URL 等。详细说明请参考 {@link RtcCreateAudioEffectOption} 。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int PlayEffect(uint effectId, RtcCreateAudioEffectOption option);
        /**
        * @if English
        * Stops playing a specified audio effect file.
        * <br>You can call the method when you are in a room.
        * @param[in] effectId         The ID of the specified audio effect. Each audio effect has a unique ID.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 停止播放指定音效文件。
        * <br>请在房间内调用该方法。
        * @param[in] effectId         指定音效的 ID。每个音效均有唯一的 ID。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int StopEffect(uint effectId);
        /**
        * @if English
        * Stops playing all audio effects.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 停止播放所有音效文件。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int StopAllEffects();
        /**
        * @if English
        * Pauses playing all audio effects.
        * <br>You can call the method when you are in a room.
        * @param[in] effectId     The ID of the specified audio effect. Each audio effect has a unique ID.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 暂停音效文件播放。
        * <br>请在房间内调用该方法。
        * @param[in] effectId     指定音效的 ID。每个音效均有唯一的 ID。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int PauseEffect(uint effectId);
        /**
        * @if English
        * Resumes playing a specified audio effect.
        * <br>You can call the method when you are in a room.
        * @param[in] effectId     The ID of the specified audio effect. Each audio effect has a unique ID.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 恢复播放指定音效文件。
        * <br>请在房间内调用该方法。
        * @param[in] effectId     指定音效的 ID。每个音效均有唯一的 ID。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int ResumeEffect(uint effectId);
        /**
        * @if English
        * Pauses all audio effect files.
        * <br>You can call the method when you are in a room.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 暂停所有音效文件播放。
        * <br>请在房间内调用该方法。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int PauseAllEffects();
        /**
        * @if English
        * Resumes playing all audio effects files.
        * <br>You can call the method when you are in a room.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 恢复播放所有音效文件。
        * <br>请在房间内调用该方法。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int ResumeAllEffects();
        /**
        * @if English
        * Adjusts the audio effect volume for publishing.
        * The method adjusts the audio effect volume for publishing. You can call the method when you are in a room.
        * @param[in] effectId         The ID of the specified audio effect. Each audio effect has a unique ID.
        * @param[in] volume            The audio effect volume. Value range: 0 to 100. The default value of 100 represents the
        * original volume.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 调节音效发送音量。
        * 该方法调节音效的发送音量大小。请在房间内调用该方法。
        * @param[in] effectId         指定音效的 ID。每个音效均有唯一的 ID。
        * @param[in] volume            音效音量范围为 0~100。默认 100 为原始文件音量。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetEffectSendVolume(uint effectId, uint volume);
        /**
        * @if English
        * Gets the audio effect volume for publishing.
        * The method gets the audio effect volume for publishing. You can call the method when you are in a room.
        * @param[in] effectId         The ID of the specified audio effect. Each audio effect has a unique ID.
        * @param[out] volume           The audio effect volume for publishing.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 获取音效发送音量。
        * 该方法获取音效的发送音量大小。请在房间内调用该方法。
        * @param[in] effectId         指定音效的 ID。每个音效均有唯一的 ID。
        * @param[out] volume           音效发送音量。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int GetEffectSendVolume(uint effectId, ref uint volume);
        /**
        * @if English
        * Sets the playback volume of an audio effect file.
        * You can call this method after joining a room.
        * @param[in] effectId         The ID of the specified audio effect. Each audio effect has a unique ID.
        * @param[in] volume            The audio effect volume for publishing. Valid values: 0 to 100. The default value is 100.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置音效文件播放音量。
        * 请在加入房间后调用该方法。
        * @param[in] effectId         指定音效的 ID。每个音效均有唯一的 ID。
        * @param[in] volume            音效播放音量。范围为0~100，默认为100。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetEffectPlaybackVolume(uint effectId, uint volume);
        /**
        * @if English
        * Gets the playback volume of the audio effects files.
        * <br>You can call this method after joining a room.
        * @param[in] effectId         The ID of the specified audio effect. Each audio effect has a unique ID.
        * @param[out] volume           The audio effect playback volume.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 获取音效文件播放音量。
        * <br>请在加入房间后调用该方法。
        * @param[in] effectId         指定音效的 ID。每个音效均有唯一的 ID。
        * @param[out] volume           音效播放音量。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int GetEffectPlaybackVolume(uint effectId, ref uint volume);
        /**
        * @if English
        * Enables or disables in-ear monitoring.
        * @note
        * - You can call the method when you are in a room.
        * - After in-ear monitoring is enabled, you must wear a headset or earpieces to use the in-ear monitoring feature. We
        * recommend that you listen for changes of playback devices through  \ref nertc::OnAudioDeviceStateChanged "OnAudioDeviceStateChanged" 
        * and  \ref nertc::OnAudioDefaultDeviceChanged  "OnAudioDefaultDeviceChanged".
        * Only when the device changes to headset, you can enable in-ear monitoring.
        * @param[in] enabled   Enabled or disabled.
        * @param[in] volume    The volume of ear-monitoring.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 开启或关闭耳返。
        * @note
        * - 请在房间内调用该方法。
        * - 开启耳返功能后，必须连接上耳机或耳麦，才能正常使用耳返功能。建议通过 \ref nertc::OnAudioDeviceStateChanged  "OnAudioDeviceStateChanged" 及 
        *  \ref nertc::OnAudioDefaultDeviceChanged  "OnAudioDefaultDeviceChanged" 
        * 监听播放设备的变化，当监听到播放设备切换为耳机时才开启耳返。
        * @param[in] enabled   开启或关闭。
        * @param[in] volume    耳返音量。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int EnableEarback(bool enabled, uint volume);
        /**
        * @if English
        * Sets the volume for in-ear monitoring.
        * You can call the method when you are in a room.
        * @param[in] volume    The volume of ear-monitoring. Valid values: to 100. The default value is 100.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置耳返音量。
        * 请在房间内调用该方法。
        * @param[in] volume    耳返音量。可设置为 0~100，默认为 100。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetEarbackVolume(uint volume);
        /**
        * @if English
        * Enables or disables local audio capture through the sound card.
        * @since V4.4.0
        * After the feature is enabled, the audio played by the sound card is integrated into local video streams. In this way, you
        can publish the audio to the remote side.
        * @note
        * - The method applies to only macOS and Windows.
        * - The capture feature is not supported on the macOS by default. If you need to enable the feature, the app needs to enable
        a virtual sound card and name the sound card as deviceName to pass in the SDK. We recommend that you can use Soundflower as
        virtual sound card to deliver better audio effect.
        * - You can call this method before or after you join a room.
        * @param[in] enabled       Specifies whether to enable the capture feature through the sound card.
                                - true: Enables audio capture through the sound card.
                                - false: Disables audio capture through the sound card (default).
        * @param[in] deviceName   The device name of the sound card. The name is set as NULL by default, which indicates capturing
        through the current sound card. <br>The parameter applies to macOS platform only. <br>If users use virtual sound cards such
        as “Soundflower”, you can set the sound card name of virtual card as parameter. In this way, the SDK finds the corresponding
        device of virtual sound cards and starts capturing.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 开启或关闭声卡采集。
        * @since V4.4.0
        * 启用声卡采集功能后，声卡播放的声音会被合到本地音频流中，从而可以发送到远端。
        * @note
        * - 该方法仅适用于 macOS 和 Windows 平台。
        * - macOS 系统默认声卡不支持采集功能，如需开启此功能需要 App 自己启用一个虚拟声卡，并将该虚拟声卡的名字作为 deviceName 传入
        SDK。 网易云信建议使用 Soundflower 作为虚拟声卡，以获得更好的音频效果。
        * - 该方法在加入房间前后都能调用。
        * @param[in] enabled       是否开启声卡采集功能。
                                - true: 开启声卡采集。
                                - false: （默认）关闭声卡采集。
        * @param[in] deviceName   声卡的设备名。默认设为 NULL，即使用当前声卡采集。<br>该参数仅适用于 macOS
        平台。<br>如果用户使用虚拟声卡，如 “Soundflower”，可以将虚拟声卡名称 “Soundflower” 作为参数，SDK
        会找到对应的虚拟声卡设备，并开始采集。
        * @return
        * - 0: 方法调用成功
        * - 其他: 方法调用失败
        * @endif
        */
        public abstract int EnableLoopbackRecording(bool enabled, string deviceName);
        /**
        * @if English
        * Adjusts the volume of captured signals of sound cards.
        * @since V4.4.0
        * After calling sound card capturing by calling \ref nertc::IRtcEngine::EnableLoopbackRecording "EnableLoopbackRecording",
        * you can call the method to adjust the volume of captured signals of sound cards.
        * @param[in] volume        The captured signals volume through sound cards. Value range: 0 to 100. The default value of 100
        * represents the original volume.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 调节声卡采集信号音量。
        * @since V4.4.0
        * 调用 \ref nertc::IRtcEngine::EnableLoopbackRecording "EnableLoopbackRecording"
        * 开启声卡采集后，你可以调用该方法调节声卡采集的信号音量。
        * @param[in] volume        声卡采集信号音量。取值范围为 [0,100]。默认值为 100，表示原始音量。
        * @return
        * - 0: 方法调用成功
        * - 其他: 方法调用失败
        * @endif
        */
        public abstract int AdjustLoopbackRecordingSignalVolume(uint volume);
        /**
        * @if English
        * Registers a stats observer.
        * @param[in] observer      The stats observer.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 注册统计信息观测器。
        * @param[in] observer      统计信息观测器
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetStatsObserver(IMediaStatsObserver observer);
        /**
        * @if English
        * Enables volume indication for the speaker.
        * <br>The method allows the SDK to report to the app the information about the volume of the user that pushes local streams
        * and the remote user (up to three users) that has the highest instantaneous volume. The information about the current
        * speaker and the volume is reported. <br>If this method is enabled, when a user joins a room and pushes streams, the SDK
        * triggers \ref nertc::OnRemoteAudioVolumeIndication "OnRemoteAudioVolumeIndication" based on the preset
        * time intervals.
        * @param enable        Whether to prompt the speaker volume.
        * @param interval      The time interval at which volume prompt is displayed. Unit: milliseconds. The value must be the
        * multiples of 100 milliseconds.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 启用说话者音量提示。
        * <br>该方法允许 SDK 定期向 App 反馈本地发流用户和瞬时音量最高的远端用户（最多 3
        * 位）的音量相关信息，即当前谁在说话以及说话者的音量。 <br>启用该方法后，只要房间内有发流用户，无论是否有人说话，SDK
        * 都会在加入房间后根据预设的时间间隔触发\ref nertc::OnRemoteAudioVolumeIndication
        * "OnRemoteAudioVolumeIndication"回调。
        * @param enable        是否启用说话者音量提示。
        * @param interval      指定音量提示的时间间隔，单位为毫秒。必须设置为 100 毫秒的整数倍值。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int EnableAudioVolumeIndication(bool enable, ulong interval);
        /**
        * @if English
        * Shares screens through specifying regions. Shares a certain screen or part of region of a screen. Users need to specify the
        * screen region they wants to share in the method. <br>When calling the method, you need to specify the screen region to be
        * shared, and share the overall frame of the screen or designated regions. <br>If you join a room and successfully call this
        * method to enable the substream, the \ref nertc::OnUserSubStreamVideoStart "OnUserSubStreamVideoStart" and \ref IRtcEngine::SetExcludeWindowList "SetExcludeWindowList" callback is remotely triggered.
        * @note
        * - The method applies to Windows only.
        * - The method enables video substreams.
        * @param  screenRect      The relative position of the screen to virtual screens that is shared.
        * @param  regionRect      The relative position of shared screen to the full screen. If you set the shared region beyond the
        * frame of the screen, only content within the screen is shared. If you set the value of width or height as 0, the full
        * screen is shared.
        * @param  captureParams   The configurations of screen sharing.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        *
        * @endif
        * @if Chinese
        * 开启屏幕共享，共享范围为指定屏幕的指定区域。
        * <br>调用该方法时，可以选择共享整个虚拟屏、指定屏幕，或虚拟屏、整个屏幕的某些区域范围。
        * <br>此方法调用成功后，远端触发 \ref nertc::OnUserSubStreamVideoStart "OnUserSubStreamVideoStart" 和 \ref IRtcEngine::SetExcludeWindowList "SetExcludeWindowList" 回调。
        *  @note
        * - 该方法仅适用于 Windows。macOS 平台请使用方法 \ref IRtcEngine::StartScreenCaptureByDisplayId "StartScreenCaptureByDisplayId" 。
        * - 该方法需要在加入房间后调用。
        * @param  screenRect      指定待共享的屏幕相对于虚拟屏的位置。
        * @param  regionRect
        * 指定待共享区域相对于整个屏幕屏幕的位置。如果设置的共享区域超出了屏幕的边界，则只共享屏幕内的内容；如果将 width 或 height
        * 设为 0, 则共享整个屏幕。
        * @param  captureParams   屏幕共享的编码参数配置。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int StartScreenCaptureByScreenRect(RtcRectangle screenRect,RtcRectangle regionRect,RtcScreenCaptureParameters captureParams);
        /**
        * @if English
        * Enables screen sharing by specifying the ID of the screen. The content of screen sharing is sent by substreams.
        * <br>If you join a room and call this method to enable the substream, the \ref nertc::OnUserSubStreamVideoStart "OnUserSubStreamVideoStart" and
        onScreenCaptureStatus callback is remotely triggered.
        * @note
        * - The method applies to only macOS.
        * - The method enables video substreams.
        * @param  displayId       The ID of the screen to be shared. Developers need to specify the screen they share through the
        parameters.
        * @param  regionRect      The relative position of shared screen to the full screen.
        * @param  captureParams   The configurations of screen sharing.
        * @return
        * - 0: Success.
        * - Other values: Failure.

        *  @endif
        *  @if Chinese
        * 通过指定屏幕 ID 开启屏幕共享，屏幕共享内容以辅流形式发送。
        * <br>此方法调用成功后，远端触发 \ref nertc::OnUserSubStreamVideoStart "OnUserSubStreamVideoStart" 回调。
        * @note
        * - 该方法仅适用于 macOS。Windows 平台请使用方法 \ref IRtcEngine::StartScreenCaptureByScreenRect "StartScreenCaptureByScreenRect" 。
        * - 该方法需要在加入房间后设置。
        * @param  displayId       指定待共享的屏幕 ID。开发者需要自行实现枚举屏幕 ID 的方法，并通过该参数指定需要共享的屏幕。
        * @param  regionRect
        指定待共享的区域相对于整个窗口的位置。如果设置的共享区域超出了窗口的边界，则只共享窗口内的内容；如果宽或高为
        0，则共享整个窗口。
        * @param  captureParams   屏幕共享的参数配置，包括码率、帧率、编码策略、屏蔽窗口列表等。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int StartScreenCaptureByDisplayId(ulong displayId,RtcRectangle regionRect,RtcScreenCaptureParameters captureParams);
        /**
        * @if English
        * Enables screen sharing by specifying the ID of the window. The content of screen sharing is sent by substreams.
        * <br>If you join a room and call this method to enable the substream, the \ref nertc::OnUserSubStreamVideoStart "OnUserSubStreamVideoStart" 
        * and \ref IRtcEngine::SetExcludeWindowList "SetExcludeWindowList" callback is remotely triggered.
        * @note
        * - The method applies to Windows only and macOS.
        * - The method enables video substreams.
        * @param  windowId        The ID of the window to be shared.
        * @param  regionRect      The relative position of shared screen to the full screen.
        * @param  captureParams   The configurations of screen sharing.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        *
        * @endif
        * @if Chinese
        * 通过指定窗口 ID 开启屏幕共享，屏幕共享内容以辅流形式发送。
        * <br>调用该方法时需要指定待共享的屏幕 ID，共享该屏幕的整体画面或指定区域。
        * <br>此方法调用成功后：
        * - Windows 平台远端触发 \ref nertc::OnUserSubStreamVideoStop "OnUserSubStreamVideoStop" 和 \ref nertc::OnScreenCaptureStatusChanged "OnScreenCaptureStatusChanged" 回调。
        * - macOS 平台远端触发 \ref nertc::OnUserSubStreamVideoStop "OnUserSubStreamVideoStop" 回调。
        * @note
        * - 该方法适用于 Windows 和 macOS。
        * - 该方法需要在加入房间后调用。
        * @param  windowId        指定待共享的窗口 ID。
        * @param  regionRect
        * 指定待共享的区域相对于整个窗口的位置。如果设置的共享区域超出了窗口的边界，则只共享指定区域中窗口内的内容；如果宽或高为
        * 0，则共享整个窗口。
        * @param  captureParams   屏幕共享的参数配置，包括码率、帧率、编码策略、屏蔽窗口列表等。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int StartScreenCaptureByWindowId(IntPtr windowId,RtcRectangle regionRect,RtcScreenCaptureParameters captureParams);
        /**
        * @if English
        Start screen capture from external video sources.
        @note
        - Get the external video source using #PushSubstreamExternalVideoFrame .
        - The method enables the substream for external video input.
        - The substream does not support #UpdateScreenCaptureRegion #PauseScreenCapture #ResumeScreenCapture and #SetExcludeWindowList.
        - The substream does not support \ref nertc::OnScreenCaptureStatusChanged "OnScreenCaptureStatusChanged" .

        @param captureParams encoding parameters. Screen capture parameters becomes invalid.
        @param externalCapturer whether capture from external.
        * @return
        * - 0: Success.
        * - Other values: Failure.

        * @endif
        * @if Chinese        
        通过外部输入视频源的方式开启辅流功能。
        @note
        - 该方法需要通过 #PushSubstreamExternalVideoFrame 输入外部视频数据。
        - 该方法打开视频外部输入的辅流。
        - 该方法启动的辅流，不支持 #UpdateScreenCaptureRegion #PauseScreenCapture #ResumeScreenCapture #SetExcludeWindowList 等方法。
        - 该方法启动的辅流，不支持 \ref nertc::OnScreenCaptureStatusChanged "OnScreenCaptureStatusChanged" .

        @param captureParams 屏幕共享的编码参数配置，屏幕捕获相关的参数失效。
        @param externalCapturer 是否是外部采集。
        @return
        - 0: 方法调用成功；
        - 其他: 方法调用失败。
        * @endif
        */
        public abstract int StartScreenCapture(RtcScreenCaptureParameters captureParams, bool externalCapturer);
        /**
        * @if English
        * When sharing a screen or window, updates the shared region.
        * @param  regionRect      The relative position of shared screen to the full screen. If you set the shared region beyond the
        * frame of the screen, only content within the screen is shared. If you set width or height as 0, the full screen is shared.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        *
        * @endif
        * @if Chinese
        * 在共享屏幕或窗口时，更新共享的区域。
        * <br>在 Windows 平台中，远端会触发 \ref nertc::OnScreenCaptureStatusChanged "OnScreenCaptureStatusChanged" 回调。
        * @param  regionRect
        * 指定待共享的区域相对于整个窗口或屏幕的位置。如果设置的共享区域超出了边界，则只共享指定区域中，窗口或屏幕内的内容；如果宽或高为
        * 0，则共享整个窗口或屏幕。
        * @return
        * - 0: 方法调用成功。
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int UpdateScreenCaptureRegion(RtcRectangle regionRect);
        /**
        * @if English
        * Stops screen sharing.
        * <br>If you use the method to disable the substream after joining a room, the \ref nertc::OnUserSubStreamVideoStop "OnUserSubStreamVideoStop" callback is remotely
        * triggered.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        *
        * @endif
        * @if Chinese
        * 停止屏幕共享。
        * <br>此方法调用成功后：
        * - Windows 平台远端触发 \ref nertc::OnUserSubStreamVideoStop "OnUserSubStreamVideoStop" 和 \ref nertc::OnScreenCaptureStatusChanged "OnScreenCaptureStatusChanged" 回调。
        * - macOS 平台远端触发 \ref nertc::OnUserSubStreamVideoStop "OnUserSubStreamVideoStop" 回调。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int StopScreenCapture();
        /**
        * @if English
        * Pauses screen sharing.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        *
        * @endif
        * @if Chinese
        * 暂停屏幕共享。
        * - 暂停屏幕共享后，共享区域内会持续显示暂停前的最后一帧画面，直至通过 #ResumeScreenCapture 恢复屏幕共享。
        * - 在 Windows 平台中，远端会触发 \ref nertc::OnScreenCaptureStatusChanged "OnScreenCaptureStatusChanged" 回调。
        * @return
        * - 0: 方法调用成功
        * - 其他: 方法调用失败
        * @endif
        */
        public abstract int PauseScreenCapture();
        /**
        * @if English
        * Resumes screen sharing.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 恢复屏幕共享。
        * <br>在 Windows 平台中，远端会触发 \ref nertc::OnScreenCaptureStatusChanged "OnScreenCaptureStatusChanged" 回调。
        * @return
        * - 0: 方法调用成功
        * - 其他: 方法调用失败
        * @endif
        */
        public abstract int ResumeScreenCapture();
        /**
        * @if English
        * Sets the window list that need to be blocked in capturing screens. The method can be dynamically called in the capturing.
        * @since V4.2.0
        * @param  windowList      The ID of the screen to be blocked.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        *
        * @endif
        * @if Chinese
        * 设置共享整个屏幕或屏幕指定区域时，需要屏蔽的窗口列表。
        * <br>开启屏幕共享时，可以通过 \ref RtcScreenCaptureParameters 设置需要屏蔽的窗口列表；在 Windows
        * 平台中，开发者可以在开启屏幕共享后，通过此方法动态调整需要屏蔽的窗口列表。被屏蔽的窗口不会显示在屏幕共享区域中。
        * @note
        * - 在 Windows 平台中，该接口在屏幕共享过程中可动态调用；在 macOS 平台中，该接口需要在开启屏幕共享之前，即
        *  #StartScreenCaptureByDisplayId 之前调用。
        * - 在 Windows 平台中，某些窗口在被屏蔽之后，如果被置于图层最上层，此窗口图像可能会黑屏。此时会触发
        * onScreenCaptureStatus中 \ref RtcScreenCaptureStatus::kNERtcScreenCaptureStatusCovered "kNERtcScreenCaptureStatusCovered" 回调，建议应用层在触发此回调时提醒用户将待分享的窗口置于最上层。
        * @since V4.2.0
        * @param  windowList      需要屏蔽的窗口 ID 列表。
        * @return
        * - 0: 方法调用成功
        * - 其他: 方法调用失败
        * @endif
        */
        public abstract int SetExcludeWindowList(IntPtr[] windowList);
        /**
        * @if English
        * Enables or disables the external video source.
        * <br>When you enable the external video source through the method, you need to set kNERtcExternalVideoDeviceID as the ID of
        * external video source with  \ref IVideoDeviceManager::SetDevice "SetDevice" \ref RtcConstants::kNERtcExternalVideoDeviceID "kNERtcExternalVideoDeviceID" method.
        * @note The method enables the internal engine, which is still valid after you call \ref IRtcEngine::LeaveChannel "LeaveChannel".
        * @param[in] enabled       Specifies whether input external video source data.
        * - true: Enables external video source.
        * - false: Disables the external video source (default).
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 开启或关闭外部视频源数据输入。
        * <br>通过该方法启用外部视频数据输入功能时，需要通过 \ref IVideoDeviceManager::SetDevice "SetDevice" 设置 \ref RtcConstants::kNERtcExternalVideoDeviceID "kNERtcExternalVideoDeviceID"
        * 为外部视频输入源 ID。
        * @note 该方法设置内部引擎为启用状态，在 \ref IRtcEngine::LeaveChannel "LeaveChannel" 后仍然有效。
        * @param[in] enabled       是否外部视频源数据输入:
        * - true: 开启外部视频源数据输入；
        * - false: 关闭外部视频源数据输入 (默认)。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetExternalVideoSource(bool enabled);
        /**
        * @if English
        * Pushes the external video frames.
        * <br>The method actively pushes the data of video frames that are encapsulated with the \ref RtcExternalVideoFrame class to the SDK.
        * Make sure that you have already called #SetExternalVideoSource with a value of true before you call this method. Otherwise,
        * an error message is repeatedly prompted if you call the method.
        * @note The method enables the internal engine, which is invalid after you call \ref IRtcEngine::LeaveChannel "LeaveChannel".
        * @param[in] frame         The video frame data.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 推送辅流的外部视频帧。
        * <br>该方法主动将视频帧数据用 \ref RtcExternalVideoFrame 类封装后传递给 SDK。 请确保在你调用本方法前已调用
        * #SetExternalVideoSource ，并将参数设为 true，否则调用本方法后会一直报错。
        * @note 该方法设置内部引擎为启用状态，在 \ref IRtcEngine::LeaveChannel "LeaveChannel" 后不再有效。
        * @param[in] frame         视频帧数据。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int PushExternalVideoFrame(RtcExternalVideoFrame frame);
        /**
        * @if English
        * Pushes the external video frames.
        * <br>The method actively pushes the data of video frames that are encapsulated with the \ref RtcExternalVideoFrame class to the SDK.
        * Make sure that you have already called #StartScreenCapture with a value of true before you call this method. Otherwise,
        * an error message is repeatedly prompted if you call the method.
        * @note The method enables the internal engine, which is invalid after you call \ref IRtcEngine::LeaveChannel "LeaveChannel".
        * @param[in] videoFrame         The video frame data.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 推送辅流的外部视频帧。
        * <br>该方法主动将视频帧数据用 \ref RtcExternalVideoFrame 类封装后传递给 SDK。 请确保在你调用本方法前已调用
        * #StartScreenCapture ，并将参数设为 true，否则调用本方法后会一直报错。
        * @note 该方法设置内部引擎为启用状态，在 \ref IRtcEngine::LeaveChannel "LeaveChannel" 后不再有效。
        * @param[in] videoFrame         视频帧数据。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int PushSubstreamExternalVideoFrame(RtcExternalVideoFrame videoFrame);
        /**
        * @if English
        * Enables or disables the external audio stream source.
        * <br>After you call the method, the setting becomes invalid if you choose audio input device or a sudden restart occurs.
        * After the method is called, you can call #PushExternalAudioFrame to send the pulse-code modulation (PCM) data.
        * @note
        * - You can call this method before joining a room.
        * - The method enables the internal engine. After enabled, the virtual component works instead of the physical microphones.
        * The setting remains unchanged after the leaveChannel method is called. If you want to disable the feature, you must disable
        * the setting before next call starts.
        * - After you enable the external audio data input, some functionalities of the speakerphone supported by the SDK are
        * replaced by the external audio source. Settings that are applied to the microphones become invalid or do not take effect in
        * calls. For example, you can hear the external data input when you use loopback for testing.
        * @param[in] enabled       Specifies whether to input external data.
        * - true: Enables external data input.
        * - false: Disables the external data input(default).
        * @param[in] sampleRate   The sample rate of data. You need to input following data in the same sample rate.  Note: If you
        * call the method to disable the functionality, you can pass in a random valid value. In this case, the setting does not take
        * effect.
        * @param[in] channels      The number of channels. You need to input following data in the same number of channels. Note: If
        * you call the method to disable the functionality, you can pass in a random valid value. In this case, the setting does not
        * take effect. Valid values:
        * - 1: Mono sound.
        * - 2: Stereo sound.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 开启或关闭外部音频源数据输入。
        * <br>当该方法调用成功后，音频输入设备选择和异常重启会失效。调用成功后可以使用 #PushExternalAudioFrame 接口发送音频 PCM 数据。
        * @note
        * - 请在加入房间前调用该方法。
        * -
        * 该方法设置内部引擎为启用状态，启动时将用虚拟设备代替麦克风工作，在 \ref IRtcEngine::LeaveChannel "LeaveChannel" 后仍然有效。如果需要关闭该功能，需要在下次通话前调用接口关闭外部音频数据输入功能。
        * - 启用外部音频数据输入功能后，SDK 内部实现部分麦克风由外部输入数据代替，麦克风相关的设置会失败或不在通话中生效。例如进行
        * loopback 检测时，会听到输入的外部数据。
        * @param[in] enabled       是否外部数据输入:
        * - true: 开启外部数据输入；
        * - false: 关闭外部数据输入 (默认)。
        * @param[in] sampleRate   数据采样率，后续数据传入需要按该格式传入。
        * 注意：调用接口关闭功能时可传入任意合法值，此时设置不会生效。
        * @param[in] channels 数据声道数，后续数据传入需要按该格式传入。注意：调用接口关闭功能时可传入任意合法值，此时设置不会生效。
        * 可设置为：
        * - 1：单声道。
        *  2：双声道。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetExternalAudioSource(bool enabled, int sampleRate, int channels);
        /**
        * @if English
        * Pushes the external audio data input.
        * <br>Pushes the audio frame data captured from the external audio source to the internal audio engine. If you enable the
        * external audio data source by calling  #SetExternalAudioSource , you can use #PushExternalAudioFrame to send audio PCM data.
        * @note
        * - This method can be called only if a user joins a room.
        * - We recommend that you set the duration of data frames to match a cycle of 10 ms.
        * - External input data frame consists of the data duration and call duration.
        * - The method becomes invalid if the audio input device is turned off. For example, disable local audio, end calls, and shut
        * off the microphone test before calls.
        * @param[in] frame         The data of frame cannot exceed 7680 bytes in length.
        * - External input data frame consists of the data duration and call duration.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 推送外部音频数据输入。
        * <br>将外部音频数据帧推送给内部引擎。 通过 #SetExternalAudioSource 启用外部音频数据输入功能成功后，可以使用
        * #PushExternalAudioFrame 接口发送音频 PCM 数据。
        * @note
        * - 该方法需要在加入房间后调用。
        * - 数据帧时长建议匹配 10ms 周期。
        * - 外部输入数据帧，数据时长和调用周期时长一致。
        * - 该方法在音频输入设备关闭后不再生效。例如关闭本地音频、通话结束、通话前麦克风设备测试关闭等情况下，该设置不再生效。
        * @param[in] frame         帧数据，数据长度不能超过7680:
        * - 外部输入数据帧，数据时长和调用周期时长一致。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int PushExternalAudioFrame(RtcAudioFrame frame);
        /**
        * @if English
        * Sets external audio rendering.
        * <br>The method is suitable for scenarios that require personalized audio rendering. By default, the setting is disabled. If
        * you choose an audio playback device or a sudden restart occurs, the setting becomes invalid. After you call the method, you
        * can use #PullExternalAudioFrame to get audio PCM data.
        * @note
        * - You can call this method before joining a room.
        * - The method enables the internal engine. The virtual component works instead of the physical speaker. The setting remains
        * valid after you call the #LeaveChannel method. If you want to disable the functionality, you must disable the functionality
        * before the next call starts.
        * - After you enable the external audio rendering, some functionalities of the speakerphone supported by the SDK are replaced
        * by the external audio source. Settings that are applied to the speakerphone become invalid or do not take effect in calls.
        * For example, external rendering is required to play the external audio when you use loopback for testing.
        * @param[in] enabled       Specifies whether to output external data.
        * - true: Enables external data rendering.
        * - false: Disables the external data rendering (default).
        * @param[in] sampleRate    The sample rate of data. You need to input following data in the same sample rate.
        * Note: If you call the method to disable the functionality, you can pass in a random valid value. In this case, the setting
        * does not take effect.
        * @param[in] channels       The number of data channels. You need to return following data in the same number of channels.
        * Note: If you call the method to disable the functionality, you can pass in a random valid value. In this case, the setting
        * does not take effect. Valid values:
        * - 1: Mono sound.
        * - 2: Stereo sound.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置外部音频渲染。
        * <br>该方法适用于需要自行渲染音频的场景。默认为关闭状态。当该方法调用成功后，音频播放设备选择和异常重启失效。
        * 调用成功后可以使用 #PullExternalAudioFrame 接口获取音频 PCM 数据。
        * @note
        * - 请在加入房间前调用该方法。
        * -
        * 该方法设置内部引擎为启用状态，启动时将用虚拟设备代替扬声器工作，在 #LeaveChannel 后仍然有效。如果需要关闭该功能，需要在下次通话前调用接口关闭外部音频数据渲染功能。
        * - 启用外部音频渲染功能后，SDK 内部实现部分扬声器由外部输入数据代替，扬声器相关的设置会失败或不在通话中生效。例如进行
        * loopback 检测时，需要由外部渲染播放。
        * @param[in] enabled           是否外部数据输出:
        * - true: 开启外部数据渲染；
        * - false: 关闭外部数据渲染 (默认)。
        * @param[in] sampleRate       数据采样率，后续数据按该格式返回。
        * 注意：调用接口关闭功能时可传入任意合法值，此时设置不会生效。
        * @param[in] channels          数据声道数，后续数据按该格式返回。
        * 注意：调用接口关闭功能时可传入任意合法值，此时设置不会生效。
        * 可设置为：
        * - 1：单声道。
        * - 2：双声道。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetExternalAudioRender(bool enabled, int sampleRate, int channels);
        /**
        * @if English
        * Pulls the external audio data.
        * <br>The method pulls the audio data from the internal audio engine. After you enable the external audio data rendering
        * functionality by calling #SetExternalAudioRender, you can use #PullExternalAudioFrame to get the audio PCM data.
        * @note
        * - This method can be called only if a user joins a room.
        * - We recommend that you set the duration of data frames to match a cycle of 10 ms.
        * - The method becomes invalid if the audio rendering device is turned off. In this case, no data is returned. For example,
        * calls end, and the speakerphone is shut off before calls.
        * @param[out] data         Data pointer. The SDK internally copies data into data.
        * @param[in] length           The size of the audio data that are pulled. Unit: bytes.
        * - We recommend that the duration of the audio data at least last 10 ms, and the data size cannot exceed 7,680 bytes.
        * - Formula: len = sampleRate/1000 × 2 × channels × duration of the audio data in milliseconds.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 拉取外部音频数据。
        * <br>该方法将从内部引擎拉取音频数据。 通过 #SetExternalAudioRender 启用外部音频数据渲染功能成功后，可以使用
        * #PullExternalAudioFrame 接口获取音频 PCM 数据。
        * @note
        * - 该方法需要在加入房间后调用。
        * - 数据帧时长建议匹配 10ms 周期。
        * - 该方法在音频渲染设备关闭后不再生效，此时会返回空数据。例如通话结束、通话前扬声器设备测试关闭等情况下，该设置不再生效。
        * @param[out] data         数据指针，SDK内部会将数据拷贝到data中。
        * @param[in] length           待拉取音频数据的字节数，单位为 byte。
        * - 建议音频数据的时长至少为 10 毫秒，数据长度不能超过 7680字节。
        * - 计算公式为： len = sampleRate/1000 × 2 × channels × 音频数据时长（毫秒）。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int PullExternalAudioFrame(byte[] data, int length);

        /**
        * @if English
        * Query the SDK version number.
        * - You can call this method before or after you join a room.
        * @return The version of the current SDK, whose format is string such as 1.0.0.
        * @endif
        * @if Chinese
        * 查询 SDK 版本号。
        * 该方法在加入房间前后都能调用。
        * @return 当前的 SDK 版本号，格式为字符串，如1.0.0.
        * @endif
        */
        public abstract string GetVersion();
        /**
        * @if English
        * Check the error description of specified error codes.
        * @note The method is currently invalid. Returns the value of empty only. Please check returned error codes and specific
        * error descriptions in the \ref nertc::OnError "OnError" .
        * @param[in] errorCode        #RtcErrorCode .
        * @return Detailed descriptions of error codes.
        * @endif
        * @if Chinese
        * 查看指定错误码的错误描述。
        * @note 目前该方法无效，只返回空值。请在 \ref nertc::OnError "OnError" 中查看返回的错误码及具体的错误描述。
        * @param[in] errorCode        #RtcErrorCode 。
        * @return 详细错误码描述
        * @endif
        */
        public abstract string GetErrorDescription(RtcErrorCode errorCode);
        /**
        * @if English
        * Uploads the SDK information.
        * <br>You can call the method only after joining a room.
        * <br>The data that is published contains the log file and the audio dump file.
        * @return void
        * @endif
        * @if Chinese
        * 上传 SDK 信息。
        * <br>只能在加入房间后调用。
        * <br>上传的信息包括 log 和 Audio dump 等文件。
        * @return void
        * @endif
        */
        public abstract int UploadSdkInfo();
        /**
        * @if English
        * After the method is successfully called, the current user can receive the notification about the status of the live stream.
        * @note
        * - The method is applicable to only live streaming.
        * - You can call the method in a room. The method is valid in calls.
        * - Only one address for the relayed stream is added in each call. You need to call the method for multiple times if you want
        * to push many streams. An RTC room with the same channel id can create three different streaming tasks.
        * - After the method is successfully called, the current user will receive related-status notifications of the live stream.
        * @param[in] info indicates information of live task. For more information, see \ref RtcLiveStreamTaskInfo .
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 添加房间推流任务，成功添加后当前用户可以收到该直播流的状态通知。
        * @note
        * - 该方法仅适用直播场景。
        * - 请在房间内调用该方法，该方法在通话中有效。
        * - 该方法每次只能增加一路旁路推流地址。如需推送多路流，则需多次调用该方法。同一个音视频房间（ 即同一个 channel id ）可以创建 3
        * 个不同的推流任务。
        * - 成功添加推流任务后，当前用户会收到该直播流的相关状态通知。
        * @param[in] info 直播任务信息。详细信息请参考 \ref RtcLiveStreamTaskInfo 。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int AddLiveStreamTask(RtcLiveStreamTaskInfo info);
        /**
        * @if English
        * Updates and modifies a push task in a room.
        * @note
        * - The method is applicable to only live streaming.
        * - You can call the method in a room. The method is valid in calls.
        * @param[in] info indicates information of live task. For more information, see \ref RtcLiveStreamTaskInfo .
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 更新修改房间推流任务。
        * @note
        * - 该方法仅适用直播场景。
        * - 请在房间内调用该方法，该方法在通话中有效。
        * @param[in] info 直播任务信息。详细信息请参考 \ref RtcLiveStreamTaskInfo 。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int UpdateLiveStreamTask(RtcLiveStreamTaskInfo info);
        /**
        * @if English
        * Deletes a push task.
        * @note
        * - The method is applicable to only live streaming.
        * - You can call the method in a room. The method is valid in calls.
        * - When calls stop and all members in the room leave the room, the SDK automatically deletes the streaming task. If some
        * users are still in the room, users who create the streaming task need to delete the streaming task.
        * @param[in] taskId  The ID of a live streaming task.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 删除房间推流任务。
        * @note
        * - 该方法仅适用直播场景。
        * - 请在房间内调用该方法，该方法在通话中有效。
        * - 通话结束，房间成员全部离开房间后，推流任务会自动删除。如果房间内还有用户存在，则需要创建推流任务的用户删除推流任务。
        * @param[in] taskId  直播任务 ID。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int RemoveLiveStreamTask(string taskId);
        /**
        * @if English
        * Sends SEI messages.
        * <br>While the local video stream is pushed, SEI data is also sent to sync some additional information. After SEI data is
        * sent, the receiver can retrieve the content by listening on \ref nertc::OnRecvSEIMessage "OnRecvSEIMessage" callback.
        * - Condition: After the video stream (mainstream) is enabled, the function can be invoked.
        * - Data size limits: The SEI data can contain a maximum of 4,096 bytes in size. Sending an SEI message fails if the data
        * exceeds the size limit. If a large amount of data is sent, the video bitrate rises. This degrades the video quality or
        * causes broken video frames.
        * - Frequency limit: we recommend that the maximum video frame rate does not exceed 10 fps.
        * - Time to take effect: After the method is called, the SEI data is sent from the next frame in the fastest fashion or after
        * the next 5 frames at the slowest pace.
        * @note
        * - The SEI data is transmitted together with the video stream. Frame loss may occur in poor network connection. The SEI data
        * will also get lost. We recommend that you send the data many times within the transmission frequency limits. In this way,
        * the receiver can get the data.
        * - By default, the SEI is transmitted by using the mainstream channel.
        * @param data      The custom SEI frame data.The custom SEI data size whose maximum value does not exceed 4096 bytes.
        * @param type      The type of the stream channel with which the SEI data is transmitted. For more information, see
        * #RtcVideoStreamType.
        * @return The value returned. A value of 0 That the operation is successful.
        * - Success: Successfully joins the queue to be sent. The data are sent after the closest video frame.
        * - failure: Date are limitedly sent for the high sent frequency and the overloaded queue. Or, the maximum data size exceeds
        * 4k.
        * @endif
        * @if Chinese
        * 发送媒体补充增强信息（SEI）。
        * <br>在本端推流传输视频流数据同时，发送流媒体补充增强信息来同步一些其他附加信息。当推流方发送 SEI 后，拉流方可通过监听 \ref
        * nertc::OnRecvSEIMessage "OnRecvSEIMessage" 的回调获取 SEI 内容。
        * - 调用时机：视频流（主流）开启后，可调用此函数。
        * - 数据长度限制： SEI 最大数据长度为 4096
        * 字节，超限会发送失败。如果频繁发送大量数据会导致视频码率增大，可能会导致视频画质下降甚至卡顿。
        * - 发送频率限制：最高为视频发送的帧率，建议不超过 10 次/秒。
        * - 生效时间：调用本接口之后，最快在下一帧视频数据帧之后发送 SEI 数据，最慢在接下来的 5 帧视频之后发送。
        * @note
        * - SEI 数据跟随视频帧发送，由于在弱网环境下可能丢帧，SEI
        * 数据也可能随之丢失，所以建议在发送频率限制之内多次发送，保证接收端收到的概率。
        * - 调用本接口时，默认使用主流通道发送 SEI。
        * @param data      自定义 SEI 数据。自定义数据最大长度不能超过4096字节。
        * @param type      发送 SEI 时，使用的流通道类型。详细信息请参考 #RtcVideoStreamType 。
        * @return 操作返回值，成功则返回 0
        * - 成功:  成功进入待发送队列，会在最近的视频帧之后发送该数据
        * - 失败:  数据被限制发送，可能发送的频率太高，队列已经满了，或者数据大小超过最大值 4k
        * @endif
        */
        public abstract int SendSEIMsg(byte[] data, RtcVideoStreamType type);
        /**
        * @if English
        * Adds a watermark image to the local video.
        * @note
        * - The setLocalCanvasWatermarkConfigs method applies to the local video canvas and does not affect the video stream. If the
        * canvas is removed, the watermark will be automatically deleted.
        * - Before you set a watermark, you must first set the canvas by calling related methods.
        * - Watermark-related methods are currently unsupported on the macOS platform.
        * @param type      The type of video streams. You can set the value to mainstream or substream. For more information, see
        * #RtcVideoStreamType.
        * @param config    The configuration of the watermark for the canvas. You can set text watermark, image watermark, and
        * timestamp watermark. A value of null is set to remove the watermark. For more information, see \ref RtcCanvasWatermarkConfig .
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 添加本地视频画布水印。
        * @note
        * - \ref IRtcEngine::SetLocalCanvasWatermarkConfigs "SetLocalCanvasWatermarkConfigs" 方法作用于本地视频画布，不影响视频流。画布被移除时，水印也会自动移除。
        * - 设置水印之前，需要先通过画布相关方法设置画布。
        * - macOS 暂不支持水印相关方法。
        * @param type      视频流类型。支持设置为主流或辅流。详细信息请参考 #RtcVideoStreamType 。
        * @param config    画布水印设置。支持设置文字水印、图片水印和时间戳水印，设置为 null 表示清除水印。
        * 详细信息请参考 \ref RtcCanvasWatermarkConfig 。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetLocalCanvasWatermarkConfigs(RtcVideoStreamType type, RtcCanvasWatermarkConfig config);
        /**
        * @if English
        * Adds a watermark to the remote video canvas.
        * @note
        * - \ref IRtcEngine::SetRemoteCanvasWatermarkConfigs "SetRemoteCanvasWatermarkConfigs" method applies to the local video canvas and does not affect the video stream. If the canvas
        is removed, the watermark will be automatically deleted.
        * - Before you set a watermark, you must first set the canvas by calling related methods.
        * - Watermark-related methods are currently unsupported on the macOS platform.
        * @param uid       The ID of a remote user.
        * @param type      The type of video streams. You can set the value to mainstream or substream. For more information, see
        #RtcVideoStreamType.
        * @param config    The configuration of the watermark for the canvas. You can set text watermark, image watermark, and
        timestamp watermark. A value of null is set to remove the watermark.
        * For more information, see \ref RtcCanvasWatermarkConfig.
        * @return
        - 0: Success.
        - Other values: Failure.
        * @endif
        * @if Chinese
        * 添加远端视频画布水印。
        * @note
        * - \ref IRtcEngine::SetRemoteCanvasWatermarkConfigs "SetRemoteCanvasWatermarkConfigs" 方法作用于远端视频画布，不影响视频流。画布被移除时，水印也会自动移除。
        * - 设置水印之前，需要先通过画布相关方法设置画布。
        * - macOS 暂不支持水印相关方法。
        * @param uid       远端用户 ID。
        * @param type      视频流类型。支持设置为主流或辅流。详细信息请参考 #RtcVideoStreamType 。
        * @param config    画布水印设置。支持设置文字水印、图片水印和时间戳水印，设置为 null 表示清除水印。
        * 详细信息请参考 \ref RtcCanvasWatermarkConfig 。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int SetRemoteCanvasWatermarkConfigs(ulong uid, RtcVideoStreamType type, RtcCanvasWatermarkConfig config);
        /**
        * @if English
        * Takes a local video snapshot.
        * <br>The takeLocalSnapshot method takes a local video snapshot on the local substream or local mainstream, and call 
        * \ref nertc::RtcTakeSnapshotCallback "RtcTakeSnapshotCallback" callback to return data of snapshot screen.
        * @note
        * - Before you call the method to capture the snapshot from the mainstream, you must first call \ref IRtcEngine::StartVideoPreview "StartVideoPreview" ,or
        * \ref IRtcEngine::EnableLocalVideo "EnableLocalVideo" and \ref IRtcEngine::JoinChannel "JoinChannel".
        * - Before you call the method to capture the snapshot from the substream, you must first \ref IRtcEngine::JoinChannel "JoinChannel",and start screen sharing.
        * - You can set text, timestamp, and image watermarks at the same time. If different types of watermarks overlap, the layers
        * override previous layers following image, text, and timestamp.
        * @param streamType       The video stream type of the snapshot. You can set the value to mainstream or substream. For more
        * information, see #RtcVideoStreamType.
        * @param callback          The snapshot callback. For information, see \ref nertc::RtcTakeSnapshotCallback "RtcTakeSnapshotCallback".
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 本地视频画面截图。
        * <br>调用 \ref IRtcEngine::TakeLocalSnapshot "TakeLocalSnapshot" 截取本地主流或本地辅流的视频画面，并通过 \ref RtcTakeSnapshotCallback
        * "RtcTakeSnapshotCallback" 回调返回截图画面的数据。
        * @note
        * - 本地主流截图，需要在 \ref IRtcEngine::StartVideoPreview "StartVideoPreview"之后 或者 \ref IRtcEngine::EnableLocalVideo "EnableLocalVideo" 并 \ref IRtcEngine::JoinChannel "JoinChannel" 成功之后调用。
        * - 本地辅流截图，需要在 \ref IRtcEngine::JoinChannel "JoinChannel" 并开启屏幕共享成功之后调用。
        * - 同时设置文字、时间戳或图片水印时，如果不同类型的水印位置有重叠，会按照图片、文本、时间戳的顺序进行图层覆盖。
        * @param streamType       截图的视频流类型。支持设置为主流或辅流。详细信息请参考 #RtcVideoStreamType 。
        * @param callback          截图回调。详细信息请参考 \ref RtcTakeSnapshotCallback 。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int TakeLocalSnapshot(RtcVideoStreamType streamType, RtcTakeSnapshotCallback callback);
        /**
        * @if English
        * Takes a snapshot of a remote video.
        * <br>You can call takeRemoteSnapshot to specify the uid of video screen of remote mainstreams and substreams, and returns
        * screenshot data of \ref nertc::RtcTakeSnapshotCallback "RtcTakeSnapshotCallback" callback.
        * @note
        * - You need to call \ref IRtcEngine::TakeRemoteSnapshot "TakeRemoteSnapshot" after receiving callbacks of \ref nertc::OnUserVideoStart "OnUserVideoStart" and \ref nertc::OnUserSubStreamVideoStart "OnUserSubStreamVideoStart".
        * - You can set text, timestamp, and image watermarks at the same time. If different types of watermarks overlap, the layers
        * override previous layers following image, text, and timestamp.
        * @param uid           The ID of a remote user.
        * @param streamType   The video stream type of the snapshot. You can set the value to mainstream or substream. For more
        * information, see #RtcVideoStreamType.
        * @param callback      The snapshot callback. For information, see \ref nertc::RtcTakeSnapshotCallback "RtcTakeSnapshotCallback" .
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 远端视频画面截图。
        * <br>调用 \ref IRtcEngine::TakeRemoteSnapshot "TakeRemoteSnapshot" 截取指定 uid 远端主流和远端辅流的视频画面，并通过 \ref nertc::RtcTakeSnapshotCallback
        * "RtcTakeSnapshotCallback" 回调返回截图画面的数据。
        * @note
        * - \ref IRtcEngine::TakeRemoteSnapshot "TakeRemoteSnapshot" 需要在收到 \ref nertc::OnUserVideoStart "OnUserVideoStart" 与 \ref nertc::OnUserSubStreamVideoStart "OnUserSubStreamVideoStart" 回调之后调用。
        * - 同时设置文字、时间戳或图片水印时，如果不同类型的水印位置有重叠，会按照图片、文本、时间戳的顺序进行图层覆盖。
        * @param uid           远端用户 ID。
        * @param streamType   截图的视频流类型。支持设置为主流或辅流。详细信息请参考 #RtcVideoStreamType 。
        * @param callback      截图回调。详细信息请参考 \ref nertc::RtcTakeSnapshotCallback "RtcTakeSnapshotCallback" 。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int TakeRemoteSnapshot(ulong uid,RtcVideoStreamType streamType, RtcTakeSnapshotCallback callback);
        /**
        * @if English
        * Starts an audio recording on a client.
        * <br>After calling the method, the client records the audio streams that are mixed by all users, and stores the streams in a
        * local file. The \ref nertc::OnAudioRecording "OnAudioRecording" callback is triggered when the recording starts or ends.
        * <br>If you specify a type of audio quality, the recording file is saved in different formats.
        * - WAV file is large with high quality.
        * - AAC file is small with low quality.
        * @note
        * - You must call the method after calling the method after joining a room.
        * - A client can only run a recording task. If you repeatedly call the \ref IRtcEngine::StartAudioRecording "StartAudioRecording" method, the current recording task
        * stops and a new recording task starts.
        * - If the current user leaves the room, the audio recording automatically stops. You can call the method to manually stop recording during calls.
        * @param filePath The absolute path where the recording file is saved. The file name and format must be accurate. For
        * example, sdcard/xxx/audio.aac.
        *        - Make sure that the specified path is valid and has the write permission.
        *        - Only WAV or AAC files are supported.
        * @param sampleRate The audio sample rate (Hz). Valid values: 16000, 32000, 44100, and 48000. The default value is 32000.
        * @param quality     The audio quality. The parameter is valid only the audio file is in AAC format. For more information,
        see #RtcAudioRecordingQuality .
        *  @return
        *  - 0: Success.
        *  - Other values: Failure.
        * @endif
        * @if Chinese
        * 开始客户端录音。
        * <br>调用该方法后，客户端会录制房间内所有用户混音后的音频流，并将其保存在本地一个录音文件中。录制开始或结束时，自动触发
        * \ref nertc::OnAudioRecording "OnAudioRecording" 回调。
        * <br>指定的录音音质不同，录音文件会保存为不同格式：
        * - WAV：音质保真度高，文件大。
        * - AAC：音质保真度低，文件小。
        * @note
        * - 请在加入房间后调用此方法。
        * - 客户端只能同时运行一个录音任务，正在录音时，如果重复调用此方法，会结束当前录制任务，并重新开始新的录音任务。
        * - 当前用户离开房间时，自动停止录音。您也可以在通话中随时调用 \ref IRtcEngine::StopAudioRecording "StopAudioRecording" 手动停止录音。
        * @param filePath 录音文件在本地保存的绝对路径，需要精确到文件名及格式。例如：sdcard/xxx/audio.aac。
        *       - 请确保指定的路径存在并且可写。
        *       - 目前仅支持 WAV 或 AAC 文件格式。
        * @param sampleRate 录音采样率（Hz），可以设为 16000、32000（默认）、44100 或 48000。
        * @param quality   录音音质，只在 AAC 格式下有效。详细说明请参考 #RtcAudioRecordingQuality 。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int StartAudioRecording(string filePath, int sampleRate, RtcAudioRecordingQuality quality);
        /**
        * @if English
        * Stops the audio recording on the client.
        * <br>If the local client leaves the room, audio recording automatically stops. You can call the \ref IRtcEngine::StopAudioRecording "StopAudioRecording" method to
        * manually stop recording during calls at any time.
        * @note You must call this method before you call \ref IRtcEngine::LeaveChannel "LeaveChannel" .
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 停止客户端录音。
        * <br>本端离开房间时自动停止录音，您也可以在通话中随时调用 \ref IRtcEngine::StopAudioRecording "StopAudioRecording" 手动停止录音。
        * @note 该接口需要在 leaveChannel 之前调用。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int StopAudioRecording();
        /**
        * @if English
        * Adjusts the volume of captured signals.
        * @note The method only adjusts the volume of captured signals in the application programs without modifying the volumes of the
        * device. If you need to modify the volume of the device, see related interfaces of device management.
        * @param[in] volume indicates the volume of the captured recording. Valid values: 0 to 400. Where:
        * - 0: Mute.
        * - 100: The original volume.
        * - 400: The maximum value can be four times the original volume. The limit value is protected.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 调节采集信号音量。
        * @note 该方法仅调节应用程序中的采集信号音量，不修改设备音量。如果需要修改设备音量，请查看设备管理相关接口。
        * @param[in] volume 采集录音音量，取值范围为 [0, 400]。其中：
        * - 0: 静音；
        * - 100: 原始音量；
        * - 400: 最大可为原始音量的 4 倍（自带溢出保护）。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int AdjustRecordingSignalVolume(int volume);
        /**
        * @if English
        * Adjusts the volume of the audio local playback.
        * @note The method only adjusts the volume of captured signals in the application programs without modifying the volumes of the
        * device. If you need to modify the volume of the device, see related interfaces of device management.
        * @param[in] volume indicates the playback volume. Valid range: 0 to 400. Where:
        * - 0: Mute.
        * - 100: The original volume.
        * - 400: The maximum value can be four times the original volume. The limit value is protected.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 调节本地播放音量。
        * @note 该方法仅调节应用程序中音量，不修改设备音量。如果需要修改设备音量，请查看设备管理相关接口。
        * @param[in] volume 播放音量。取值范围为 [0, 400]。其中：
        * - 0:  静音；
        * - 100: 原始音量；
        * - 400: 最大可为原始音量的 4 倍（自带溢出保护）。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int AdjustPlaybackSignalVolume(int volume);
        /**
        * @if English
        * Adjusts the volume of local signal playback from a specified remote user.
        * <br>After you join the room, you can call the method to adjust the volume of local audio playback from different remote
        * users or repeatedly adjust the volume of audio playback from a specified remote user.
        * @note
        * - You can call this method after joining a room.
        * - The method is valid in the current call. If a remote user exits the room and rejoins the room again, the setting is still
        * valid until the call ends.
        * - The method adjusts the volume of the mixing audio published by a specified remote user. The volume of one remote user can
        be adjusted. If you want to adjust multiple remote users, you need to call the method for the required times.
        * @param uid    The ID of a remote user.
        * @param volume Playback volume: 0 to 100.
        * - 0: Mute.
        * - 100: The original volume.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 调节本地播放的指定远端用户的信号音量。
        * <br>加入房间后，您可以多次调用该方法设置本地播放的不同远端用户的音量；也可以反复调节本地播放的某个远端用户的音量。
        *  @note
        * - 请在成功加入房间后调用该方法。
        * - 该方法在本次通话中有效。如果远端用户中途退出房间，则再次加入此房间时仍旧维持该设置，通话结束后设置失效。
        * -
        该方法调节的是本地播放的指定远端用户混音后的音量，且每次只能调整一位远端用户。若需调整多位远端用户在本地播放的音量，则需多次调用该方法。
        * @param uid    远端用户 ID。
        * @param volume 播放音量，取值范围为 [0,100]。
        * - 0：静音。
        * - 100：原始音量。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int AdjustUserPlaybackSignalVolume(ulong uid, int volume);
        /**
        * @if English
        * Starts to relay media streams across rooms.
        * - The method can invite co-hosts across rooms. Media streams from up to four rooms can be relayed. A room can receive
        * multiple relayed media streams.
        * - After you call this method, the SDK triggers \ref nertc::OnMediaRelayStateChanged "OnMediaRelayStateChanged" and \ref nertc::OnMediaRelayEvent "OnMediaRelayEvent". 
        * The return reports the status and events about the current relayed media streams across rooms.
        * @note - You can call this method after joining a room. Before you call the method, you must set the destination room in the
        * {@link RtcChannelMediaRelayConfig} parameter in `destInfos`.
        * - The method is applicable only to the host in live streaming.
        * - If you want to call the method again, you must first call the \ref IRtcEngine::StopChannelMediaRelay "StopChannelMediaRelay" method to exit the current relaying
        * status.
        * - If you succeed in relaying the media stream across rooms, and want to change the destination room, for example, add or
        * remove the destination room, you can call \ref IRtcEngine::UpdateChannelMediaRelay "UpdateChannelMediaRelay" to update the information about the destination room.
        * @since V4.3.0
        * @param config specifies the configuration for the media stream relay across rooms. For more information, see 
        * {@link RtcChannelMediaRelayInfo}。
        * @return {@code 0} A value of 0 returned indicates that the method call is successful. Otherwise, the method call fails.
        * @endif
        * @if Chinese
        * 开始跨房间媒体流转发。
        * - 该方法可用于实现跨房间连麦等场景。支持同时转发到 4 个房间，同一个房间可以有多个转发进来的媒体流。
        * - 成功调用该方法后，SDK 会触发 \ref nertc::OnMediaRelayStateChanged "OnMediaRelayStateChanged" 和  \ref nertc::OnMediaRelayEvent "OnMediaRelayEvent"
        * 回调，并在回调中报告当前的跨房间媒体流转发状态和事件。
        * @note
        * - 请在成功加入房间后调用该方法。调用此方法前需要通过 {@link RtcChannelMediaRelayConfig} 中的 `destInfos` 设置目标房间。
        * - 该方法仅对直播场景下的主播角色有效。
        * - 成功调用该方法后，若您想再次调用该方法，必须先调用 \ref IRtcEngine::StopChannelMediaRelay "StopChannelMediaRelay" 方法退出当前的转发状态。
        * - 成功开始跨房间转发媒体流后，如果您需要修改目标房间，例如添加或删减目标房间等，可以调用方法 \ref IRtcEngine::UpdateChannelMediaRelay "UpdateChannelMediaRelay"
        * 更新目标房间信息。
        * @since V4.3.0
        * @param config 跨房间媒体流转发参数配置信息。
        * @return 成功返回0，其他则失败
        * @endif
        */
        public abstract int StartChannelMediaRelay(RtcChannelMediaRelayConfig config);
        /**
        * @if English
        * Updates the information of the destination room for the media stream relay.
        * <br>You can call this method to relay the media stream to multiple rooms or exit the current room.
        * - You can call this method to change the destination room, for example, add or remove the destination room.
        * - After you call this method, the SDK triggers \ref nertc::OnMediaRelayStateChanged "OnMediaRelayStateChanged"
        * and  \ref nertc::OnMediaRelayEvent "OnMediaRelayEvent". The return reports the
        * status and events about the current relayed media streams across rooms.
        * @note Before you call the method, you must join the room and call \ref IRtcEngine::StartChannelMediaRelay "StartChannelMediaRelay" to relay the media stream across
        * rooms. Before you call the method, you must set the destination room in the {@link RtcChannelMediaRelayConfig} parameter
        * in `dest_infos`.
        * @since V4.3.0
        * @param config The configuration for destination rooms.
        * @return A value of 0 returned indicates that the method call is successful. Otherwise, the method call fails.
        * @endif
        * @if Chinese
        * 更新媒体流转发的目标房间。
        * <br>成功开始跨房间转发媒体流后，如果你希望将流转发到多个目标房间，或退出当前的转发房间，可以调用该方法。
        * - 成功开始跨房间转发媒体流后，如果您需要修改目标房间，例如添加或删减目标房间等，可以调用此方法。
        * - 成功调用该方法后，SDK 会触发 \ref nertc::OnMediaRelayStateChanged "OnMediaRelayStateChanged" 和  \ref nertc::OnMediaRelayEvent "OnMediaRelayEvent"
        * 回调，并在回调中报告当前的跨房间媒体流转发状态和事件。
        * @note 请在加入房间并成功调用 \ref IRtcEngine::StartChannelMediaRelay "StartChannelMediaRelay" 开始跨房间媒体流转发后，调用此方法。调用此方法前需要通过
        * {@link RtcChannelMediaRelayConfig} 中的 `destInfos` 设置目标房间。
        * @since V4.3.0
        * @param config 目标房间配置信息
        * @return 成功返回0，其他则失败
        * @endif
        */
        public abstract int UpdateChannelMediaRelay(RtcChannelMediaRelayConfig config);
        /**
        * @if English
        * Stops relaying media streams.
        * <br>If the host leaves the room, media stream replay across rooms automatically stops. You can also call
        * \ref IRtcEngine::StopChannelMediaRelay "StopChannelMediaRelay". In this case, the host exits all destination rooms.
        * - If you call this method, the SDK triggers the \ref nertc::OnMediaRelayStateChanged "OnMediaRelayStateChanged" callback. If \ref RtcChannelMediaRelayState::kNERtcChannelMediaRelayStateIdle "kNERtcChannelMediaRelayStateIdle" is
        * returned, the media stream relay stops.
        * - If the method call failed, the SDK triggers the \ref nertc::OnMediaRelayStateChanged "OnMediaRelayStateChanged" callback that returns the status code
        * \ref RtcChannelMediaRelayState::kNERtcChannelMediaRelayStateFailure "kNERtcChannelMediaRelayStateFailure".
        * @since V4.3.0
        * @return A value of 0 returned indicates that the method call is successful. Otherwise, the method call fails.
        * @endif
        * @if Chinese
        * 停止跨房间媒体流转发。
        * <br>主播离开房间时，跨房间媒体流转发自动停止，您也可以在需要的时候随时调用 \ref IRtcEngine::StopChannelMediaRelay "StopChannelMediaRelay"
        * 方法，此时主播会退出所有目标房间。
        * - 成功调用该方法后，SDK 会触发 \ref nertc::OnMediaRelayStateChanged "OnMediaRelayStateChanged" 回调。如果报告
        * \ref RtcChannelMediaRelayState::kNERtcChannelMediaRelayStateIdle "kNERtcChannelMediaRelayStateIdle"，则表示已停止转发媒体流。
        * - 如果该方法调用不成功，SDK 会触发 \ref nertc::OnMediaRelayStateChanged "OnMediaRelayStateChanged" 回调，并报告状态码 \ref RtcChannelMediaRelayState::kNERtcChannelMediaRelayStateFailure "kNERtcChannelMediaRelayStateFailure"。
        * @since V4.3.0
        * @return 成功返回0，其他则失败
        * @endif
        */
        public abstract int StopChannelMediaRelay();
        /**
        * @if English
        * Sets the fallback option for the published local video stream based on the network conditions.
        * <br>The quality of the published local audio and video streams is degraded with poor quality network connections. After
        * calling this method and setting the option to \ref RtcStreamFallbackOption::kNERtcStreamFallbackAudioOnly "kNERtcStreamFallbackAudioOnly":
        * - With unreliable upstream network connections and the quality of audio and video streams is downgraded, the SDK
        * automatically disables video stream or stops receiving video streams. In this way, the communication quality is guaranteed.
        * - The SDK monitors the network performance and recover audio and video streams if the network quality improves.
        * - If the locally published audio and video stream falls back to audio stream, or recovers to audio and video stream, the
        * SDK triggers the \ref nertc::OnPublishFallbackToAudioOnly "OnPublishFallbackToAudioOnly" callback.
        * @note You must call the method before you call \ref IRtcEngine::JoinChannel "JoinChannel".
        * @since V4.3.0
        * @param option The fallback option of publishing audio and video streams. The fallback \ref RtcStreamFallbackOption::kNERtcStreamFallbackAudioOnly "kNERtcStreamFallbackAudioOnly" is
        * disabled by default. For more information, see #RtcStreamFallbackOption .
        * @return {@code 0} A value of 0 returned indicates that the method call is successful. Otherwise, the method call fails.
        * @endif
        * @if Chinese
        * 设置弱网条件下发布的音视频流回退选项。
        * <br>在网络不理想的环境下，发布的音视频质量都会下降。使用该接口并将 option 设置为 \ref RtcStreamFallbackOption::kNERtcStreamFallbackAudioOnly "kNERtcStreamFallbackAudioOnly" 后：
        * - SDK 会在上行弱网且音视频质量严重受影响时，自动关断视频流，尽量保证音频质量。
        * - 同时 SDK 会持续监控网络质量，并在网络质量改善时恢复音视频流。
        * - 当本地发布的音视频流回退为音频流时，或由音频流恢复为音视频流时，SDK 会触发本地发布的媒体流已回退为音频流
        * \ref nertc::OnPublishFallbackToAudioOnly "OnPublishFallbackToAudioOnly" 回调。
        * @note 请在加入房间（\ref IRtcEngine::JoinChannel "JoinChannel"）前调用此方法。
        * @since V4.3.0
        * @param option 发布音视频流的回退选项，默认为不开启回退 \ref RtcStreamFallbackOption::kNERtcStreamFallbackAudioOnly "kNERtcStreamFallbackAudioOnly"。详细信息请参考
        * #RtcStreamFallbackOption 。
        * @return {@code 0} 方法调用成功，其他调用失败
        * @endif
        */
        public abstract int SetLocalPublishFallbackOption(RtcStreamFallbackOption option);
        /**
        * @if English
        * Sets the fallback option for the subscribed remote audio and video stream with poor network connections.
        * <br>The quality of the subscribed audio and video streams is degraded with unreliable network connections. You can use the
        * interface to set the option as \ref RtcStreamFallbackOption::kNERtcStreamFallbackVideoStreamLow "kNERtcStreamFallbackVideoStreamLow" or \ref RtcStreamFallbackOption::kNERtcStreamFallbackAudioOnly "kNERtcStreamFallbackAudioOnly".
        * - In unreliable downstream network connections, the SDK switches to receive a low-quality video stream or stops receiving
        * video streams. In this way, the communication quality is maintained or improved.
        * - The SDK monitors the network quality and resumes the video stream when the network condition improves.
        * - If the subscribed remote video stream falls back to audio only, or the audio-only stream switches back to the video
        * stream, the SDK triggers the \ref nertc::OnSubscribeFallbackToAudioOnly "OnSubscribeFallbackToAudioOnly" callback.
        * @note You must call the method before you call \ref IRtcEngine::JoinChannel "JoinChannel".
        * @since V4.3.0
        * @param option    The fallback option for the subscribed remote audio and video stream. With unreliable network connections,
        * the stream falls back to a low-quality video stream of \ref RtcStreamFallbackOption::kNERtcStreamFallbackVideoStreamLow "kNERtcStreamFallbackVideoStreamLow". For more information, see
        * nertc::NERTCStreamFallbackOption .
        * @return {@code 0} A value of 0 returned indicates that the method call is successful. Otherwise, the method call fails.
        * @endif
        * @if Chinese
        * 设置弱网条件下订阅的音视频流回退选项。
        * <br>弱网环境下，订阅的音视频质量会下降。使用该接口并将 option 设置为 \ref RtcStreamFallbackOption::kNERtcStreamFallbackVideoStreamLow "kNERtcStreamFallbackVideoStreamLow" 或者
        * \ref RtcStreamFallbackOption::kNERtcStreamFallbackAudioOnly "kNERtcStreamFallbackAudioOnly" 后：
        * - SDK 会在下行弱网且音视频质量严重受影响时，将视频流切换为小流，或关断视频流，从而保证或提高通信质量。
        * - SDK 会持续监控网络质量，并在网络质量改善时自动恢复音视频流。
        * - 当远端订阅流回退为音频流时，或由音频流恢复为音视频流时，SDK 会触发远端订阅流已回退为音频流
        * \ref nertc::OnSubscribeFallbackToAudioOnly "OnSubscribeFallbackToAudioOnly" 回调。
        * @note 请在加入房间（\ref IRtcEngine::JoinChannel "JoinChannel"）前调用此方法。
        * @since V4.3.0
        * @param option    订阅音视频流的回退选项，默认为弱网时回退到视频小流 \ref RtcStreamFallbackOption::kNERtcStreamFallbackVideoStreamLow "kNERtcStreamFallbackVideoStreamLow"。详细信息请参考
        * #RtcStreamFallbackOption 。
        * @return {@code 0} 方法调用成功，其他调用失败
        * @endif
        */
        public abstract int SetRemoteSubscribeFallbackOption(RtcStreamFallbackOption option);
        /**
        * @if English
        * Enables or disables AI super resolution.
        * @since V4.4.0
        * @note
        * - Please contact our technical support to enable AI super resolution before you perform the feature.
        * - AI super resolution is only valid when you enable the following types of video streams:
        * - Video streams that are received from local 360P.
        * - High stream video of mainstream that are captured by the camera. AI super resolution is currently unsupported to resume
        * low streams or substreams of screen sharing.
        * @param enable     Whether to enable AI super resolution. By default, the setting is disabled.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 启用或停止 AI 超分。
        * @since V4.4.0
        * @note
        * - 使用 AI 超分功能之前，请联系技术支持开通 AI 超分功能。
        * - AI 超分仅对以下类型的视频流有效：
        *      - 必须为本端接收到第一路 360P 的视频流。
        *      - 必须为摄像头采集到的主流大流视频。AI 超分功能暂不支持复原重建小流和屏幕共享辅流。
        * @param enable        是否启用 AI 超分。默认为关闭状态。
        * @return
        * - 0: 方法调用成功
        * - 其他: 调用失败
        * @endif
        */
        public abstract int EnableSuperResolution(bool enable);
        /**
        * @if English
        * Enables or disables media stream encryption.
        * @since V4.4.0
        * In scenes where high safety is required such as financial sectors, you can set encryption modes of media streams with the
        * method before joining the room.
        * @note
        * - Please calls the method before you join the room. The encryption mode and private key cannot be changed after you join
        * the room. The SDK will automatically disable encryption after users leave the room. If you need to enable encryption again,
        * users need to call the method before joining the room.
        * - In the same room, all users who enable media stream encryption must share the same encryption mode and private keys. If
        * not, members who use different private keys will report \ref RtcErrorCode::kNERtcErrEncryptNotSuitable "kNERtcErrEncryptNotSuitable" (30113).
        * - For safety, we recommend that you use a new private key every time you enable media stream encryption.
        * @param enable    whether to enable media stream encryption.
        *                  - true: Enabled.
        *                  - false: Disabled. This is the default value.
        * @param config    specifies encryption plan for media streams. For more information, see {@link RtcEncryptionConfig}.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 开启或关闭媒体流加密。
        * @since V4.4.0
        * 在金融行业等安全性要求较高的场景下，您可以在加入房间前通过此方法设置媒体流加密模式。
        * @note
        * - 请在加入房间前调用该方法，加入房间后无法修改加密模式与密钥。用户离开房间后，SDK
        * 会自动关闭加密。如需重新开启加密，需要在用户再次加入房间前调用此方法。
        * - 同一房间内，所有开启媒体流加密的用户必须使用相同的加密模式和密钥，否则使用不同密钥的成员加入房间时会报错
        * \ref RtcErrorCode::kNERtcErrEncryptNotSuitable "kNERtcErrEncryptNotSuitable"（30113）。
        * - 安全起见，建议每次启用媒体流加密时都更换新的密钥。
        * @param enable    是否开启媒体流加密。
        *                  - true: 开启
        *                  - false:（默认）关闭
        * @param config    媒体流加密方案。详细信息请参考 {@link RtcEncryptionConfig}。
        * @return
        * - 0: 方法调用成功
        * - 其他: 调用失败
        * @endif
        */
        public abstract int EnableEncryption(bool enable, RtcEncryptionConfig config);
        /**
        * @if English
        * Starts the last-mile network probe test.
        * <br>This method starts the last-mile network probe test before joining a channel to get the uplink and downlink last mile
        * network statistics, including the bandwidth, packet loss, jitter, and round-trip time (RTT).This method is used to detect
        * network quality before a call. Before a user joins a room, you can use this method to estimate the subjective experience
        * and objective network status of a local user during an audio and video call. Once this method is enabled, the SDK returns
        * the following callbacks:
        * - \ref nertc::OnLastmileQuality "OnLastmileQuality": the SDK triggers this callback within five seconds depending on the network conditions. This
        * callback rates the network conditions with a score and is more closely linked to the user experience.
        * - \ref nertc::OnLastmileProbeResult "OnLastmileProbeResult"`: the SDK triggers this callback within 30 seconds depending on the network conditions. This
        * callback returns the real-time statistics of the network conditions and is more objective.
        * @note
        * - You can call this method before joining a channel(\ref IRtcEngine::JoinChannel "JoinChannel").
        * - Do not call other methods before receiving the \ref nertc::OnLastmileQuality "OnLastmileQuality" and \ref nertc::OnLastmileProbeResult "OnLastmileProbeResult" callbacks. Otherwise, the
        * callbacks may be interrupted.
        * @since V4.5.0
        * @param config    Sets the configurations of the last-mile network probe test.
        * @endif
        * @if Chinese
        * 开始通话前网络质量探测。
        * <br>启用该方法后，SDK
        * 会通过回调方式反馈上下行网络的质量状态与质量探测报告，包括带宽、丢包率、网络抖动和往返时延等数据。一般用于通话前的网络质量探测场景，用户加入房间之前可以通过该方法预估音视频通话中本地用户的主观体验和客观网络状态。
        * <br>相关回调如下：
        * - \ref nertc::OnLastmileQuality "OnLastmileQuality"：网络质量状态回调，以打分形式描述上下行网络质量的主观体验。该回调视网络情况在约 5 秒内返回。
        * - \ref nertc::OnLastmileProbeResult "OnLastmileProbeResult"：网络质量探测报告回调，报告中通过客观数据反馈上下行网络质量。该回调视网络情况在约 30 秒内返回。
        * @note
        * - 请在加入房间（\ref IRtcEngine::JoinChannel "JoinChannel"）前调用此方法。
        * - 调用该方法后，在收到 \ref nertc::OnLastmileQuality "OnLastmileQuality" 和 \ref nertc::OnLastmileProbeResult "OnLastmileProbeResult" 回调之前请不要调用其他方法，否则可能会由于 API
        * 操作过于频繁导致此方法无法执行。
        * @since V4.5.0
        * @param config    Last mile 网络探测配置。
        * @return
        * - 0: 方法调用成功
        * - 其他: 调用失败
        * @endif
        */
        public abstract int StartLastmileProbeTest(RtcLastmileProbeConfig config);
        /**
        * @if English
        * Stops the last-mile network probe test.
        * @since V4.5.0
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 停止通话前网络质量探测。
        * @since V4.5.0
        * @return
        * - 0: 方法调用成功
        * - 其他: 调用失败
        * @endif
        */
        public abstract int StopLastmileProbeTest();

        /**
         * @if English
         * Set the audio range in the spatializer
         * @note with enableSpatializer enabled. Call the method before calling
         * @param audibleDistance The distance for listeners to hear speakers and receive text messages. [0,1000] Default value 32。
         * @param conversationalDistance control speaker audio within the original volume. If the volume exceeds the range, the voice starts to fade out.
         * 默认值为 1。
         * @param rollOff: Distance attenuation mode #RtcDistanceRolloffModel. Default value: \ref RtcDistanceRolloffModel::kNERtcDistanceRolloffNone "kNERtcDistanceRolloffNone"
         * @return
         * - 0: success.
         * - Other values: failure.       
         * @endif
         * @if Chinese
         * 引擎3D音效算法距离范围设置
         * @note 依赖enableSpatializer接口开启，通话前调用
         * @param audibleDistance 监听器能够听到扬声器并接收其文本消息的距离扬声器的最大距离。[0,1000] 默认值为 32。
         * @param conversationalDistance 控制扬声器音频保持其原始音量的范围，超出该范围时，语音聊天的响度在被听到时开始淡出。
         * 默认值为 1。
         * @param rollOff 距离衰减模式 #RtcDistanceRolloffModel ，默认值 \ref RtcDistanceRolloffModel::kNERtcDistanceRolloffNone "kNERtcDistanceRolloffNone"
         * @return
         * - 0: 方法调用成功
         * - 其他: 调用失败
         * @endif
         */
        public abstract int UpdateSpatializerAudioRecvRange(int audibleDistance,int conversationalDistance, RtcDistanceRolloffModel rollOff);

        /**
         * @if English
         * Update the position of the current user in spatializer
         * @note with \ref IRtcEngine::EnableSpatializer "EnableSpatializer" enabled. Reset the setting if \ref IRtcEngine::EnableSpatializer "EnableSpatializer" is disabled.
         * @param info location info, For more information,see {@link RtcSpatializerPositionInfo}.
         * @return
         * - 0: success.
         * - Other values: failure.     
         * @endif
         * @if Chinese
         * 引擎3D音效算法中本人坐标方位更新接口
         * @note 依赖 \ref IRtcEngine::EnableSpatializer "EnableSpatializer" 接口开启，\ref IRtcEngine::EnableSpatializer "EnableSpatializer" 接口关闭后重置设置
         * @param info 位置信息，详细信息参看 {@link RtcSpatializerPositionInfo}.
         * @return
         * - 0: 方法调用成功
         * - 其他: 调用失败
         * @endif
         */
        public abstract int UpdateSpatializerSelfPosition(RtcSpatializerPositionInfo info);

        /**
         * @if English
         * Enable or disable the room effects in the spatializer.
         * @note with \ref IRtcEngine::EnableSpatializer "EnableSpatializer" enabled
         * @param enable reverb effect. the default value is disabled
         * @return
         * - 0: success.
         * - Other values: failure.       
         * @endif
         * @if Chinese
         * 引擎3D音效算法中房间混响效果开关
         * @note 依赖 \ref IRtcEngine::EnableSpatializer "EnableSpatializer" 接口开启
         * @param enable 混响效果开关，默认值关闭
         * @return
         * - 0: 方法调用成功
         * - 其他: 调用失败
         * @endif
         */
        public abstract int EnableSpatializerRoomEffects(bool enable);
        /**
         * @if English
         * Set the room reverberation property in the spatializer
         * @note with \ref IRtcEngine::EnableSpatializer "EnableSpatializer" enabled
         * @param roomProperty Room property {@link RtcSpatializerRoomProperty}
         * @return
         * - 0: success.
         * - Other values: failure.      
         * @endif
         * @if Chinese
         * 引擎3D音效算法中房间混响属性
         * @note 依赖 \ref IRtcEngine::EnableSpatializer "EnableSpatializer" 接口开启
         * @param roomProperty 房间属性 {@link RtcSpatializerRoomProperty}
         * @return
         * - 0: 方法调用成功
         * - 其他: 调用失败
         * @endif
         */
        public abstract int SetSpatializerRoomProperty(RtcSpatializerRoomProperty roomProperty);

        /**
         * @if English
         * Set the rendering mode of the spatializer
         * @note with \ref IRtcEngine::EnableSpatializer "EnableSpatializer" enabled
         * @param mode Rendering mode #RtcSpatializerRenderMode ，Default value: \ref RtcSpatializerRenderMode::kNERtcSpatializerRenderBinauralHighQuality "kNERtcSpatializerRenderBinauralHighQuality"
         * @return
         * - 0: success.
         * - Other values: failure.       
         * @endif
         * @if Chinese
         * 引擎3D音效算法中渲染模式
         * @note 依赖 \ref IRtcEngine::EnableSpatializer "EnableSpatializer" 接口开启
         * @param mode 渲染模式 #RtcSpatializerRenderMode ，默认值 \ref RtcSpatializerRenderMode::kNERtcSpatializerRenderBinauralHighQuality "kNERtcSpatializerRenderBinauralHighQuality"
         * @return
         * - 0: 方法调用成功
         * - 其他: 调用失败
         * @endif
         */
        public abstract int SetSpatializerRenderMode(RtcSpatializerRenderMode mode);

        /**
         * @if English
         * Enable or disable the spatializer
         * @note Call the method before calling, the configuration will not be reset after the call ends
         * @param enable Whether to enable the spatializer
         * @return
         * - 0: success.
         * - Other values: failure.
         * @endif
         * @if Chinese
         * 引擎3D音效算法开关
         * @note 通话前调用，通话结束后不重置
         * @param enable 是否打开3D音效算法功能
         * @return
         * - 0: 方法调用成功
         * - 其他: 调用失败
         * @endif
         */
        public abstract int EnableSpatializer(bool enable);

        /**
         * @if English
         * Enable or disable a digital avatar.
         * @note
         * - Call the method after the call starts. The server cleans up the setting only after the call ends.
         * - Disable the digital avatar if a user leaves the room. The server reserves the setting when the user rejoin the room of the same cid using the same uid.
         * @param enable Whether to enable a digital avatar.
         * @return
         * - 0: success.
         * - Other values: failure.       
         * @endif
         * @if Chinese
         * 虚拟人开关
         * @note
         * - 通话发起后设置，服务器只在整个通话结束后清理发起状态。
         * - 如果单人离会建议关闭，不然重新相同uid，回到同一个cid的通话后服务器保留状态。
         * @param enable 是否开启虚拟人
         * @return
         * - 0: 方法调用成功
         * - 其他: 调用失败
         * @endif
         */
        public abstract int EnableAvatar(bool enable);
    }
    internal sealed partial class RtcEngine : IRtcEngine
    {
        //observer
        private IAudioFrameObserver _audioFrameObserver = null;
        private IMediaStatsObserver _mediaStatsObserver = null;

        //manager
        private AudioDeviceManager _audioDeviceManager = null;
        private VideoDeviceManager _videoDeviceManager = null;
        private VideoRawDataManager _videoRawDataManager = null;

        //native
        private IntPtr _nativeRtcEngine = IntPtr.Zero;
        private string _parameters = null;

        //channels
        private Dictionary<string, IRtcChannel> _channels = new Dictionary<string, IRtcChannel>();
        public VideoRawDataManager VideoRawDataManager => _videoRawDataManager;

        #region Override Methods
        public override IAudioDeviceManager AudioDeviceManager => _audioDeviceManager;
        public override IVideoDeviceManager VideoDeviceManager => _videoDeviceManager;
        public override int Initialize(RtcEngineContext param)
        {
            if(_nativeRtcEngine != IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcNoError;
            }

            _nativeRtcEngine = IRtcEngineNative.createNERtcEngine();
            if(_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            SetParameters(_parameters);

#if UNITY_ANDROID && !UNITY_EDITOR
            UnityEngine.Debug.Log($"Initialize  --> Android Context : {param.context}");
            using (var clz = new UnityEngine.AndroidJavaClass("com.netease.yunxin.lite.unity.UnityUtility"))
            {
                clz.CallStatic("initialize", new object[1] { param.context });
            }
#endif

            var context = new NativeEngineContext();
            context.app_key = param.appKey;
            context.log_dir_path = param.logPath;
            context.log_level = (int)param.logLevel;
            context.log_file_max_size_kbytes = param.logFileMaxSize;
            context.events = BindEvent(_nativeRtcEngine);

            int result = IRtcEngineNative.initialize(_nativeRtcEngine, ref context);
            if(result == (int)RtcErrorCode.kNERtcNoError)
            {
                IntPtr nativeAudioDevice = IRtcEngineNative.queryInterface(_nativeRtcEngine, (int)RtcInterfaceIdType.kNERtcIIDAudioDeviceManager);
                IntPtr nativeVideoDevice = IRtcEngineNative.queryInterface(_nativeRtcEngine, (int)RtcInterfaceIdType.kNERtcIIDVideoDeviceManager);
                _audioDeviceManager = new AudioDeviceManager(this, nativeAudioDevice);
                _videoDeviceManager = new VideoDeviceManager(this, nativeVideoDevice);
                _videoRawDataManager = new VideoRawDataManager(this, _nativeRtcEngine);

                _rwLock.EnterWriteLock();
                _rtcEngines[_nativeRtcEngine] = this;
                _rwLock.ExitWriteLock();

                SetParameters(_parameters);
                _parameters = null;
            }
            return result;
        }
        public override void Release(bool sync)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return;
            }

            //release channels
            var channels = _channels.Values.ToArray();
            _channels.Clear();
            foreach (var channel in channels)
            {
                channel.Destroy();
            }

            IRtcEngineNative.release(_nativeRtcEngine, sync);
            IRtcEngine.destroyNERtcEngine(_nativeRtcEngine);

            _rwLock.EnterWriteLock();
            _rtcEngines.Remove(_nativeRtcEngine);
            _rwLock.ExitWriteLock();

            _nativeRtcEngine = IntPtr.Zero;
            _audioDeviceManager = null;
            _videoDeviceManager = null;
            _videoRawDataManager?.RemoveAllCanvas();
            _videoRawDataManager = null;
            _audioFrameObserver = null;
            _mediaStatsObserver = null;

        }
        public override int SetClientRole(RtcClientRole role)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setClientRole(_nativeRtcEngine, (int)role);
        }
        public override int SetChannelProfile(RtcChannelProfileType profile)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setChannelProfile(_nativeRtcEngine, (int)profile);
        }
        public override int JoinChannel(string token, string channelName, ulong uid)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.joinChannel(_nativeRtcEngine, token??string.Empty,channelName??string.Empty,uid);
        }
        public override int SwitchChannel(string token, string channelName)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.switchChannel(_nativeRtcEngine, token ?? string.Empty, channelName ?? string.Empty);
        }
        public override int LeaveChannel()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            _videoRawDataManager?.RemoveAllRemoteCanvas();
            return IRtcEngineNative.leaveChannel(_nativeRtcEngine);
        }
        public override int EnableLocalAudio(bool enabled)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.enableLocalAudio(_nativeRtcEngine, enabled);
        }
        public override int SetupLocalVideoCanvas(RtcVideoCanvas canvas)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            var nativeCanvas = (NativeVideoCanvas?)_videoRawDataManager.CreateNativeVideoCanvas(0, canvas, RtcVideoStreamType.kNERTCVideoStreamMain);
            _videoRawDataManager.SetupVideoCanvas(0, canvas, RtcVideoStreamType.kNERTCVideoStreamMain);

            IntPtr native = IntPtr.Zero;
            if (nativeCanvas != null)
            {
                native = Marshal.AllocHGlobal(Marshal.SizeOf<NativeVideoCanvas>());
                Marshal.StructureToPtr(nativeCanvas ?? default, native, false);
            }

            int result = IRtcEngineNative.setupLocalVideoCanvas(_nativeRtcEngine, native);
            if (native != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(native);
                native = IntPtr.Zero;
            }
            return result;
        }
        public override int SetupRemoteVideoCanvas(ulong uid, RtcVideoCanvas canvas)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            var nativeCanvas = (NativeVideoCanvas?)_videoRawDataManager.CreateNativeVideoCanvas(uid, canvas, RtcVideoStreamType.kNERTCVideoStreamMain);
            _videoRawDataManager.SetupVideoCanvas(uid, canvas, RtcVideoStreamType.kNERTCVideoStreamMain);

            IntPtr native = IntPtr.Zero;
            if (nativeCanvas != null)
            {
                native = Marshal.AllocHGlobal(Marshal.SizeOf<NativeVideoCanvas>());
                Marshal.StructureToPtr(nativeCanvas ?? default, native, false);
            }

            int result = IRtcEngineNative.setupRemoteVideoCanvas(_nativeRtcEngine,uid, native);
            if (native != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(native);
                native = IntPtr.Zero;
            }
            return result;
        }
        public override int EnableLocalVideo(bool enabled)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }
            return IRtcEngineNative.enableLocalVideo(_nativeRtcEngine, enabled);
        }
        public override int SubscribeRemoteVideoStream(ulong uid, RtcRemoteVideoStreamType type, bool subscribe)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }
            return IRtcEngineNative.subscribeRemoteVideoStream(_nativeRtcEngine, uid,(int)type,subscribe);
        }
        public override int SwitchCamera()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.switchCamera(_nativeRtcEngine);
        }
        public override IRtcChannel CreateChannel(string channelName)
        {
            if (_channels.ContainsKey(channelName))
            {
                return _channels[channelName];
            }

            IntPtr nativeChannel = IRtcEngineNative.createChannel(_nativeRtcEngine, channelName);
            if(nativeChannel == IntPtr.Zero)
            {
                return null;
            }

            var channel = new RtcChannel(this, channelName, nativeChannel);
            _channels[channelName] = channel;
            return channel;
        }

        public override IRtcChannel GetChannel(string channelName)
        {
            if(!_channels.ContainsKey(channelName))
            {
                return null;
            }

            return _channels[channelName];
        }
        public override RtcConnectionStateType GetConnectionState()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return RtcConnectionStateType.kNERtcConnectionStateDisconnected;
            }

            return (RtcConnectionStateType)IRtcEngineNative.getConnectionState(_nativeRtcEngine);
        }
        public override int MuteLocalAudioStream(bool mute)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.muteLocalAudioStream(_nativeRtcEngine, mute);
        }
        public override int SetAudioProfile(RtcAudioProfileType profile, RtcAudioScenarioType scenario)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setAudioProfile(_nativeRtcEngine, (int)profile, (int)scenario);
        }
        public override int SetAudioEffectPreset(RtcVoiceChangerType type)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setAudioEffectPreset(_nativeRtcEngine, (int)type);
        }
        public override int SetVoiceBeautifierPreset(RtcVoiceBeautifierType type)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setVoiceBeautifierPreset(_nativeRtcEngine, (int)type);
        }
        public override int SetLocalVoicePitch(double pitch)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setLocalVoicePitch(_nativeRtcEngine, pitch);
        }
        public override int SetLocalVoiceEqualization(RtcVoiceEqualizationBand bandFrequency, int bandGain)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setLocalVoiceEqualization(_nativeRtcEngine, (int)bandFrequency, bandGain);
        }
        public override int SubscribeRemoteAudioStream(ulong uid, bool subscribe)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.subscribeRemoteAudioStream(_nativeRtcEngine, uid, subscribe);
        }
        public override int SetSudioSessionOperationRestriction(RtcAudioSessionOperationRestriction restriction)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setSudioSessionOperationRestriction(_nativeRtcEngine, (int)restriction);
        }
        public override int SetPlayoutDeviceMute(bool muted)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setPlayoutDeviceMute(_nativeRtcEngine, muted);
        }
        public override int GetPlayoutDeviceMute(ref bool muted)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.getPlayoutDeviceMute(_nativeRtcEngine, ref muted);
        }
        public override int SetRecordDeviceMute(bool muted)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setRecordDeviceMute(_nativeRtcEngine, muted);
        }
        public override int GetRecordDeviceMute(ref bool muted)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.getRecordDeviceMute(_nativeRtcEngine, ref muted);
        }
        public override bool IsCameraZoomSupported()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return false;
            }

            return IRtcEngineNative.isCameraZoomSupported(_nativeRtcEngine);
        }
        public override bool IsCameraTorchSupported()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return false;
            }

            return IRtcEngineNative.isCameraTorchSupported(_nativeRtcEngine);
        }
        public override bool IsCameraFocusSupported()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return false;
            }

            return IRtcEngineNative.isCameraFocusSupported(_nativeRtcEngine);
        }
        public override bool IsCameraExposurePositionSupported()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return false;
            }

            return IRtcEngineNative.isCameraExposurePositionSupported(_nativeRtcEngine);
        }
        public override int SetCameraExposurePosition(float pointX, float pointY)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setCameraExposurePosition(_nativeRtcEngine, pointX, pointY);
        }
        public override int SetCameraTorchOn(bool on)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setCameraTorchOn(_nativeRtcEngine, on);
        }
        public override bool IsCameraTorchOn()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return false;
            }

            return IRtcEngineNative.isCameraTorchOn(_nativeRtcEngine);
        }
        public override int SetCameraZoomFactor(float factor)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setCameraZoomFactor(_nativeRtcEngine, factor);
        }
        public override float MaxCameraZoomScale()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.maxCameraZoomScale(_nativeRtcEngine);
        }
        public override int SetCameraFocusPosition(float x, float y)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setCameraFocusPosition(_nativeRtcEngine, x, y);
        }
        public override int SetCameraCaptureConfig(RtcCameraCaptureConfig config)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setCameraCaptureConfig(_nativeRtcEngine,ref config);
        }
        public override int SubscribeAllRemoteAudioStream(bool subscribe)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.subscribeAllRemoteAudioStream(_nativeRtcEngine, subscribe);
        }
        public override int SetVideoConfig(RtcVideoConfig config)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setVideoConfig(_nativeRtcEngine, ref config);
        }
        public override int EnableDualStreamMode(bool enable)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.enableDualStreamMode(_nativeRtcEngine, enable);
        }
        public override int SetupLocalSubstreamVideoCanvas(RtcVideoCanvas canvas)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }
            var nativeCanvas = (NativeVideoCanvas?)_videoRawDataManager.CreateNativeVideoCanvas(0, canvas, RtcVideoStreamType.kNERTCVideoStreamSub);
            _videoRawDataManager.SetupVideoCanvas(0, canvas, RtcVideoStreamType.kNERTCVideoStreamSub);

            IntPtr native = IntPtr.Zero;
            if (nativeCanvas != null)
            {
                native = Marshal.AllocHGlobal(Marshal.SizeOf<NativeVideoCanvas>());
                Marshal.StructureToPtr(nativeCanvas??default, native, false);
            }

            int result = IRtcEngineNative.setupLocalSubstreamVideoCanvas(_nativeRtcEngine, native);
            if (native != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(native);
                native = IntPtr.Zero;
            }
            return result;
        }
        public override int SetLocalSubstreamRenderMode(RtcVideoScalingMode scalingMode)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }
            return IRtcEngineNative.setLocalSubstreamRenderMode(_nativeRtcEngine, (int)scalingMode);
        }
        public override int SetLocalRenderMode(RtcVideoScalingMode scalingMode)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setLocalRenderMode(_nativeRtcEngine, (int)scalingMode);
        }
        public override int SetLocalVideoMirrorMode(RtcVideoMirrorMode mirrorMode)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setLocalVideoMirrorMode(_nativeRtcEngine, (int)mirrorMode);
        }
        public override int SetRemoteRenderMode(ulong uid, RtcVideoScalingMode scalingMode)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setRemoteRenderMode(_nativeRtcEngine, uid, (int)scalingMode);
        }
        public override int SetupRemoteSubstreamVideoCanvas(ulong uid, RtcVideoCanvas canvas)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            var nativeCanvas = (NativeVideoCanvas?)_videoRawDataManager.CreateNativeVideoCanvas(uid, canvas, RtcVideoStreamType.kNERTCVideoStreamSub);
            _videoRawDataManager.SetupVideoCanvas(uid, canvas, RtcVideoStreamType.kNERTCVideoStreamSub);

            IntPtr native = IntPtr.Zero;
            if (nativeCanvas != null)
            {
                native = Marshal.AllocHGlobal(Marshal.SizeOf<NativeVideoCanvas>());
                Marshal.StructureToPtr(nativeCanvas ?? default, native, false);
            }

            int result = IRtcEngineNative.setupRemoteSubstreamVideoCanvas(_nativeRtcEngine, uid, native);
            if (native != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(native);
                native = IntPtr.Zero;
            }
            return result;
        }
        public override int SubscribeRemoteVideoSubstream(ulong uid, bool subscribe)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.subscribeRemoteVideoSubstream(_nativeRtcEngine, uid, subscribe);
        }
        public override int SetRemoteSubsteamRenderMode(ulong uid, RtcVideoScalingMode scalingMode)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setRemoteSubsteamRenderMode(_nativeRtcEngine, uid, (int)scalingMode);
        }
        public override int StartVideoPreview()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.startVideoPreview(_nativeRtcEngine);
        }
        public override int StopVideoPreview()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.stopVideoPreview(_nativeRtcEngine);
        }
        public override int MuteLocalVideoStream(bool mute)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.muteLocalVideoStream(_nativeRtcEngine, mute);
        }
        public override int SetLocalMediaPriority(int priority, bool isPreemptive)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setLocalMediaPriority(_nativeRtcEngine, priority,isPreemptive);
        }
        public override int SetParameters(string parameters)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                _parameters = parameters;
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setParameters(_nativeRtcEngine, parameters??string.Empty);
        }
        public override int SetRecordingAudioFrameParameters(RtcAudioFrameRequestFormat format)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setRecordingAudioFrameParameters(_nativeRtcEngine, ref format);
        }
        public override int SetPlaybackAudioFrameParameters(RtcAudioFrameRequestFormat format)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setPlaybackAudioFrameParameters(_nativeRtcEngine, ref format);
        }
        public override int SetMixedAudioFrameParameters(int sampleRate)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setMixedAudioFrameParameters(_nativeRtcEngine, sampleRate);
        }
        public override int SetAudioFrameObserver(IAudioFrameObserver observer)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }
            IntPtr native = IntPtr.Zero;
            _audioFrameObserver = observer;
            if (observer != null)
            {
                native = Marshal.AllocHGlobal(Marshal.SizeOf<NativeAudioFrameObserver>());
                var nativeObserver = BindAudioFrameObserverEvent(_nativeRtcEngine);
                Marshal.StructureToPtr(nativeObserver, native, false);
            }

            int result = IRtcEngineNative.setAudioFrameObserver(_nativeRtcEngine, native);
            if (native != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(native);
                native = IntPtr.Zero;
            }
            return result;
        }
        public override int StartAudioDump()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.startAudioDump(_nativeRtcEngine);
        }
        public override int StopAudioDump()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.stopAudioDump(_nativeRtcEngine);
        }
        public override int SetLoudSpeakerMode(bool enable)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }
            return IRtcEngineNative.setLoudSpeakerMode(_nativeRtcEngine, enable);
        }
        public override int GetLoudSpeakerMode(ref bool enabled)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.getLoudSpeakerMode(_nativeRtcEngine, ref enabled);
        }
        public override int StartAudioMixing(RtcCreateAudioMixingOption option)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.startAudioMixing(_nativeRtcEngine, ref option);
        }
        public override int StopAudioMixing()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.stopAudioMixing(_nativeRtcEngine);
        }
        public override int PauseAudioMixing()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.pauseAudioMixing(_nativeRtcEngine);
        }
        public override int ResumeAudioMixing()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.resumeAudioMixing(_nativeRtcEngine);
        }
        public override int SetAudioMixingSendVolume(uint volume)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setAudioMixingSendVolume(_nativeRtcEngine, volume);
        }
        public override int GetAudioMixingSendVolume(ref uint volume)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.getAudioMixingSendVolume(_nativeRtcEngine, ref volume);
        }
        public override int SetAudioMixingPlaybackVolume(uint volume)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setAudioMixingPlaybackVolume(_nativeRtcEngine, volume);
        }
        public override int GetAudioMixingPlaybackVolume(ref uint volume)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.getAudioMixingPlaybackVolume(_nativeRtcEngine, ref volume);
        }
        public override int GetAudioMixingDuration(ref ulong duration)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.getAudioMixingDuration(_nativeRtcEngine, ref duration);
        }
        public override int GetAudioMixingCurrentPosition(ref ulong position)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.getAudioMixingCurrentPosition(_nativeRtcEngine, ref position);
        }
        public override int SetAudioMixingPosition(ulong seekPosition)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setAudioMixingPosition(_nativeRtcEngine, seekPosition);
        }
        public override int PlayEffect(uint effectId, RtcCreateAudioEffectOption option)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.playEffect(_nativeRtcEngine, effectId,ref option);
        }
        public override int StopEffect(uint effectId)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.stopEffect(_nativeRtcEngine, effectId);
        }
        public override int StopAllEffects()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.stopAllEffects(_nativeRtcEngine);
        }
        public override int PauseEffect(uint effectId)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }
            return IRtcEngineNative.pauseEffect(_nativeRtcEngine, effectId);
        }
        public override int ResumeEffect(uint effectId)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }
            return IRtcEngineNative.resumeEffect(_nativeRtcEngine, effectId);
        }
        public override int PauseAllEffects()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }
            return IRtcEngineNative.pauseAllEffects(_nativeRtcEngine);
        }
        public override int ResumeAllEffects()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }
            return IRtcEngineNative.resumeAllEffects(_nativeRtcEngine);
        }
        public override int SetEffectSendVolume(uint effectId, uint volume)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setEffectSendVolume(_nativeRtcEngine, effectId, volume);
        }
        public override int GetEffectSendVolume(uint effectId, ref uint volume)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.getEffectSendVolume(_nativeRtcEngine, effectId, ref volume);
        }
        public override int SetEffectPlaybackVolume(uint effectId, uint volume)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setEffectPlaybackVolume(_nativeRtcEngine, effectId, volume);
        }
        public override int GetEffectPlaybackVolume(uint effectId, ref uint volume)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.getEffectPlaybackVolume(_nativeRtcEngine, effectId, ref volume);
        }
        public override int EnableEarback(bool enabled, uint volume)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.enableEarback(_nativeRtcEngine, enabled, volume);
        }
        public override int SetEarbackVolume(uint volume)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setEarbackVolume(_nativeRtcEngine, volume);
        }
        public override int EnableLoopbackRecording(bool enabled, string deviceName)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.enableLoopbackRecording(_nativeRtcEngine, enabled, deviceName??string.Empty);
        }
        public override int AdjustLoopbackRecordingSignalVolume(uint volume)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.adjustLoopbackRecordingSignalVolume(_nativeRtcEngine, volume);
        }
        public override int SetStatsObserver(IMediaStatsObserver observer)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            IntPtr native = IntPtr.Zero;
            _mediaStatsObserver = observer;
            if(observer != null)
            {
                native = Marshal.AllocHGlobal(Marshal.SizeOf<NativeMediaStatsObserver>());
                var nativeObserver = BindMediaStatsEvent(_nativeRtcEngine);
                Marshal.StructureToPtr(nativeObserver, native, false);
            }
            
            IRtcEngineNative.setStatsObserver(_nativeRtcEngine, native);

            if(native != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(native);
                native = IntPtr.Zero;
            }

            return (int)RtcErrorCode.kNERtcNoError;
        }
        public override int EnableAudioVolumeIndication(bool enable, ulong interval)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.enableAudioVolumeIndication(_nativeRtcEngine, enable, interval);
        }
        public override int StartScreenCaptureByScreenRect(RtcRectangle screenRect, RtcRectangle regionRect, RtcScreenCaptureParameters captureParams)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            var nativeParameters = ConvertToNative(captureParams);
            int result = IRtcEngineNative.startScreenCaptureByScreenRect(_nativeRtcEngine, ref screenRect, ref regionRect ,ref nativeParameters);
            if(nativeParameters.excluded_window_list != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeParameters.excluded_window_list);
            }
            return result;
        }
        public override int StartScreenCaptureByDisplayId(ulong displayId, RtcRectangle regionRect, RtcScreenCaptureParameters captureParams)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }
            var nativeParameters = ConvertToNative(captureParams);
            int result = IRtcEngineNative.startScreenCaptureByDisplayId(_nativeRtcEngine, displayId, ref regionRect, ref nativeParameters);
            if (nativeParameters.excluded_window_list != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeParameters.excluded_window_list);
            }
            return result;
        }
        public override int StartScreenCaptureByWindowId(IntPtr windowId, RtcRectangle regionRect, RtcScreenCaptureParameters captureParams)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            var nativeParameters = ConvertToNative(captureParams);
            int result = IRtcEngineNative.startScreenCaptureByWindowId(_nativeRtcEngine, windowId, ref regionRect, ref nativeParameters);
            if (nativeParameters.excluded_window_list != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeParameters.excluded_window_list);
            }
            return result;
        }
        public override int StartScreenCapture(RtcScreenCaptureParameters captureParams, bool externalCapturer)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            var nativeParameters = ConvertToNative(captureParams);
            int result = IRtcEngineNative.startScreenCapture(_nativeRtcEngine, ref nativeParameters, externalCapturer);
            if (nativeParameters.excluded_window_list != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeParameters.excluded_window_list);
            }
            return result;
        }
        public override int UpdateScreenCaptureRegion(RtcRectangle regionRect)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }
            return IRtcEngineNative.updateScreenCaptureRegion(_nativeRtcEngine, ref regionRect);
        }
        public override int StopScreenCapture()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.stopScreenCapture(_nativeRtcEngine);
        }
        public override int PauseScreenCapture()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }
            return IRtcEngineNative.pauseScreenCapture(_nativeRtcEngine);
        }
        public override int ResumeScreenCapture()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.resumeScreenCapture(_nativeRtcEngine);
        }
        public override int SetExcludeWindowList(IntPtr[] windowList)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setExcludeWindowList(_nativeRtcEngine,windowList, windowList?.Length??0);
        }
        public override int SetExternalVideoSource(bool enabled)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setExternalVideoSource(_nativeRtcEngine, enabled);
        }
        public override int PushExternalVideoFrame(RtcExternalVideoFrame frame)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.pushExternalVideoFrame(_nativeRtcEngine, ref frame);
        }
        public override int PushSubstreamExternalVideoFrame(RtcExternalVideoFrame videoFrame)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.pushSubstreamExternalVideoFrame(_nativeRtcEngine, ref videoFrame);
        }
        public override int SetExternalAudioSource(bool enabled, int sampleRate, int channels)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setExternalAudioSource(_nativeRtcEngine, enabled, sampleRate, channels);
        }
        public override int PushExternalAudioFrame(RtcAudioFrame frame)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.pushExternalAudioFrame(_nativeRtcEngine, ref frame);
        }
        public override int SetExternalAudioRender(bool enabled, int sampleRate, int channels)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setExternalAudioRender(_nativeRtcEngine, enabled, sampleRate, channels);
        }
        public override int PullExternalAudioFrame(byte[] data, int length)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.pullExternalAudioFrame(_nativeRtcEngine, data, length);
        }
        public override string GetVersion()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return string.Empty;
            }
            IntPtr version = IRtcEngineNative.getVersion(_nativeRtcEngine);
            return Marshal.PtrToStringAnsi(version);
        }
        public override string GetErrorDescription(RtcErrorCode errorCode)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return string.Empty;
            }
            IntPtr errorDescription = IRtcEngineNative.getErrorDescription(_nativeRtcEngine, (int)errorCode);
            return Marshal.PtrToStringAnsi(errorDescription);

        }
        public override int UploadSdkInfo()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.uploadSdkInfo(_nativeRtcEngine);
        }
        public override int AddLiveStreamTask(RtcLiveStreamTaskInfo info)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            if(info == null)
            {
                return (int)RtcErrorCode.kNERtcErrInvalidParam; ;
            }

            var nativeTaskInfo = ConvertToNative(info);
            int result = IRtcEngineNative.addLiveStreamTask(_nativeRtcEngine,ref nativeTaskInfo);

            if(nativeTaskInfo.layout.users != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeTaskInfo.layout.users);
            }

            if (nativeTaskInfo.layout.bg_image != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeTaskInfo.layout.bg_image);
            }
            return result;
        }
        public override int UpdateLiveStreamTask(RtcLiveStreamTaskInfo info)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            if (info == null)
            {
                return (int)RtcErrorCode.kNERtcErrInvalidParam; ;
            }

            var nativeTaskInfo = ConvertToNative(info);
            int result = IRtcEngineNative.updateLiveStreamTask(_nativeRtcEngine, ref nativeTaskInfo);

            if (nativeTaskInfo.layout.users != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeTaskInfo.layout.users);
            }

            if (nativeTaskInfo.layout.bg_image != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeTaskInfo.layout.bg_image);
            }
            return result;
        }
        public override int RemoveLiveStreamTask(string taskId)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.removeLiveStreamTask(_nativeRtcEngine, taskId??string.Empty);
        }
        public override int SendSEIMsg(byte[] data, RtcVideoStreamType type)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.sendSEIMsg(_nativeRtcEngine, data, data.Length, (int)type);
        }
        public override int SetLocalCanvasWatermarkConfigs(RtcVideoStreamType type, RtcCanvasWatermarkConfig config)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            if (config == null)
            {
                return (int)RtcErrorCode.kNERtcErrInvalidParam; ;
            }

            var nativeConfig = ConvertToNative(config);
            int result = IRtcEngineNative.setLocalCanvasWatermarkConfigs(_nativeRtcEngine, (int)type,ref nativeConfig);

            if (nativeConfig.image_watermarks != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeConfig.image_watermarks);
            }

            if (nativeConfig.text_watermarks != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeConfig.text_watermarks);
            }

            if (nativeConfig.timestamp_watermark != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeConfig.timestamp_watermark);
            }

            return result;
        }
        public override int SetRemoteCanvasWatermarkConfigs(ulong uid, RtcVideoStreamType type, RtcCanvasWatermarkConfig config)
        {
             if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }
            if (config == null)
            {
                return (int)RtcErrorCode.kNERtcErrInvalidParam; ;
            }

            var nativeConfig = ConvertToNative(config);
            int result = IRtcEngineNative.setRemoteCanvasWatermarkConfigs(_nativeRtcEngine, uid, (int)type, ref nativeConfig);

            if (nativeConfig.image_watermarks != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeConfig.image_watermarks);
            }

            if (nativeConfig.text_watermarks != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeConfig.text_watermarks);
            }

            if (nativeConfig.timestamp_watermark != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeConfig.timestamp_watermark);
            }

            return result;
        }
        public override int TakeLocalSnapshot(RtcVideoStreamType streamType, RtcTakeSnapshotCallback callback)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return (int)RtcErrorCode.kNERtcErrNotSupported;
        }

        public override int TakeRemoteSnapshot(ulong uid, RtcVideoStreamType streamType, RtcTakeSnapshotCallback callback)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return (int)RtcErrorCode.kNERtcErrNotSupported;
        }

        public override int StartAudioRecording(string filePath, int sampleRate, RtcAudioRecordingQuality quality)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.startAudioRecording(_nativeRtcEngine, filePath??string.Empty, sampleRate, (int)quality);
        }
        public override int StopAudioRecording()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.stopAudioRecording(_nativeRtcEngine);
        }
        public override int AdjustRecordingSignalVolume(int volume)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.adjustRecordingSignalVolume(_nativeRtcEngine, volume);
        }
        public override int AdjustPlaybackSignalVolume(int volume)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.adjustPlaybackSignalVolume(_nativeRtcEngine, volume);
        }
        public override int AdjustUserPlaybackSignalVolume(ulong uid, int volume)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.adjustUserPlaybackSignalVolume(_nativeRtcEngine, uid, volume);
        }
        public override int StartChannelMediaRelay(RtcChannelMediaRelayConfig config)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            if(config.destInfos == null)
            {
                return (int)RtcErrorCode.kNERtcErrInvalidParam;
            }

            var nativeConfig = ConvertToNative(config);

            int result = IRtcEngineNative.startChannelMediaRelay(_nativeRtcEngine, ref nativeConfig);

            if(nativeConfig.src_infos != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeConfig.src_infos);
            }

            if (nativeConfig.dest_infos != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeConfig.dest_infos);
            }

            return result;

        }
        public override int UpdateChannelMediaRelay(RtcChannelMediaRelayConfig config)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            if (config.destInfos == null)
            {
                return (int)RtcErrorCode.kNERtcErrInvalidParam;
            }

            var nativeConfig = ConvertToNative(config);

            int result = IRtcEngineNative.updateChannelMediaRelay(_nativeRtcEngine, ref nativeConfig);

            if (nativeConfig.src_infos != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeConfig.src_infos);
            }

            if (nativeConfig.dest_infos != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeConfig.dest_infos);
            }

            return result;
        }
        public override int StopChannelMediaRelay()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.stopChannelMediaRelay(_nativeRtcEngine);
        }
        public override int SetLocalPublishFallbackOption(RtcStreamFallbackOption option)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setLocalPublishFallbackOption(_nativeRtcEngine,(int)option);
        }
        public override int SetRemoteSubscribeFallbackOption(RtcStreamFallbackOption option)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setRemoteSubscribeFallbackOption(_nativeRtcEngine, (int)option);
        }
        public override int EnableSuperResolution(bool enable)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.enableSuperResolution(_nativeRtcEngine, enable);
        }
        public override int EnableEncryption(bool enable, RtcEncryptionConfig config)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.enableEncryption(_nativeRtcEngine, enable, ref config);
        }
        public override int StartLastmileProbeTest(RtcLastmileProbeConfig config)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.startLastmileProbeTest(_nativeRtcEngine, ref config);
        }
        public override int StopLastmileProbeTest()
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.stopLastmileProbeTest(_nativeRtcEngine);
        }
        public override int UpdateSpatializerAudioRecvRange(int audibleDistance, int conversationalDistance, RtcDistanceRolloffModel rollOff)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.updateSpatializerAudioRecvRange(_nativeRtcEngine, audibleDistance,conversationalDistance,(int)rollOff);
        }
        public override int UpdateSpatializerSelfPosition(RtcSpatializerPositionInfo info)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.updateSpatializerSelfPosition(_nativeRtcEngine,ref info);
        }
        public override int EnableSpatializerRoomEffects(bool enable)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.enableSpatializerRoomEffects(_nativeRtcEngine, enable);
        }
        public override int SetSpatializerRoomProperty(RtcSpatializerRoomProperty roomProperty)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setSpatializerRoomProperty(_nativeRtcEngine,ref roomProperty);
        }
        public override int SetSpatializerRenderMode(RtcSpatializerRenderMode mode)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.setSpatializerRenderMode(_nativeRtcEngine,(int)mode);
        }
        public override int EnableSpatializer(bool enable)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.enableSpatializer(_nativeRtcEngine, enable);
        }
        public override int EnableAvatar(bool enable)
        {
            if (_nativeRtcEngine == IntPtr.Zero)
            {
                return (int)RtcErrorCode.kNERtcErrFatal;
            }

            return IRtcEngineNative.enableAvatar(_nativeRtcEngine, enable);
        }
        #endregion

        #region private methods

        private static ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();
        private static Dictionary<IntPtr, RtcEngine> _rtcEngines = new Dictionary<IntPtr, RtcEngine>();
        static RtcEngine _instance = null;
        private RtcEngine(){}
        internal static RtcEngine GetRtcEngine()
        {
            if (_instance == null)
            {
                _instance = new RtcEngine();
            }

            return _instance;
        }
        internal static RtcEngine GetEngineFromNative(IntPtr nativeRtcEngine)
        {
            _rwLock.EnterReadLock();
            RtcEngine rtcEngine = null;
            _rtcEngines.TryGetValue(nativeRtcEngine, out rtcEngine);
            _rwLock.ExitReadLock();
            return rtcEngine;
        }

        internal void ReleaseChannel(string channelName)
        {
            if (string.IsNullOrEmpty(channelName))
            {
                return;
            }
            _channels.Remove(channelName);
        }
        #endregion
    }

}
