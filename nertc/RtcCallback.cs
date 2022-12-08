using System;
using System.Runtime.InteropServices;

namespace nertc
{
    #region Engine Callbacks
    /**
    * @if English
    * Occurs when the error occurs.
    * <br>The callback is triggered to report an error related to network or media during SDK runtime. In most cases, the SDK
    * cannot fix the issue and resume running. The SDK requires the app to take action or informs the user of the issue.
    * @param errorCode        The error code. For more information, see #RtcErrorCode .
    * @param msg               Error description.
    * @endif
    * @if Chinese
    * 发生错误回调。
    * <br>该回调方法表示 SDK 运行时出现了（网络或媒体相关的）错误。通常情况下，SDK上报的错误意味着SDK无法自动恢复，需要 App
    * 干预或提示用户。
    * @param errorCode        错误码。详细信息请参考 #RtcErrorCode
    * @param msg 错误描述。
    * @endif
    */
    public delegate void OnError(int errorCode, string msg);
    /**
    * @if English
    * Occurs when a warning occurs.
    * <br>The callback is triggered to report a warning related to network or media during SDK runtime. In most cases, the app
    * ignores the warning message and the SDK resumes running.
    * @param warnCode     The warning code. For more information, see {@link RtcWarnCode}.
    * @param msg        The warning description.
    * @endif
    * @if Chinese
    * 发生警告回调。
    * <br>该回调方法表示 SDK 运行时出现了（网络或媒体相关的）警告。通常情况下，SDK 上报的警告信息 App 可以忽略，SDK 会自动恢复。
    * @param warnCode 警告码。详细信息请参考 {@link RtcWarnCode}。
    * @param msg 警告描述。
    * @endif
    */
    public delegate void OnWarning(int warnCode, string msg);
    /**
    * @if English
    * Occurs when the hardware resources are released.
    * <br>The SDK prompts whether hardware resources are successfully released.
    * @param result    The result.
    * @endif
    * @if Chinese
    * 释放硬件资源的回调。
    * <br>SDK提示释放硬件资源是否成功。
    * @param result    返回结果。
    * @endif
    */
    public delegate void OnReleasedHwResources(RtcErrorCode result);
    /**
    * @if English
    * Allows a user to join a room. The callback indicates that the client has already signed in.
    * @param cid     The ID of the room that the client joins.
    * @param uid     Specifies the ID of a user. If you specify the uid in the \ref IRtcEngine::JoinChannel method, a specified ID is returned at
    * the time. If not, the  ID automatically assigned by the CommsEase’s server is returned.
    * @param result  Indicates the result.
    * @param elapsed The time elapsed from calling the joinChannel method to the occurrence of this event. Unit: milliseconds.
    * @endif
    * @if Chinese
    * 加入房间回调，表示客户端已经登入服务器。
    * @param cid     客户端加入的房间 ID。
    * @param uid     用户 ID。 如果在 \ref IRtcEngine::JoinChannel 方法中指定了 uid，此处会返回指定的 ID; 如果未指定
    * uid，此处将返回云信服务器自动分配的 ID。
    * @param result  返回结果。
    * @param elapsed 从 \ref IRtcEngine::JoinChannel 开始到发生此事件过去的时间，单位为毫秒。
    * @endif
    */
    public delegate void OnJoinChannel(ulong cid, ulong uid, RtcErrorCode result, ulong elapsed);
    /**
    * @if English
    * Triggers reconnection.
    * <br>In some cases, a client may be disconnected from the server, the SDK starts reconnecting. The callback is triggered
    * when the reconnection starts.
    * @param cid Specifies the ID of a room.
    * @param uid Specifies the ID of a user.
    * @endif
    * @if Chinese
    * 触发重连。
    * <br>有时候由于网络原因，客户端可能会和服务器失去连接，SDK会进行自动重连，开始自动重连后触发此回调。
    * @param cid  房间 ID。
    * @param uid  用户 ID。
    * @endif
    */
    public delegate void OnReconnectingStart(ulong cid, ulong uid);
    /**
    * @if English
    * Occurs when the state of network connection is changed.
    * <br>The callback is triggered when the state of network connection is changed. The callback returns the current state of
    * network connection and the reason why the network state changes.
    * @param state  The state of current network connection.
    * @param reason The reason why the network state changes.
    * @endif
    * @if Chinese
    * 网络连接状态已改变回调。
    * <br>该回调在网络连接状态发生改变的时候触发，并告知用户当前的网络连接状态和引起网络状态改变的原因。
    * @param state  当前的网络连接状态。
    * @param reason  引起当前网络连接状态发生改变的原因。
    * @endif
    */
    public delegate void OnConnectionStateChange(RtcConnectionStateType state, RtcReasonConnectionChangedType reason);
    /**
    * @if English
    * Occurs when the network type is changed.
    * <br>The callback is triggered when network is changed. The callback returns the current network type.
    * @param newType  The new type of current network.
    * @endif
    * @if Chinese
    * 网络类型已经改变的回调。
    * <br>该回调在网络发生改变的时候触发，并告知用户当前的网络类型。
    * @param newType  当前的网络类型。
    * @endif
    */
    public delegate void OnNetworkTypeChanged(RtcNetworkType newType);
    /**
    * @if English
    * Occurs when a user rejoins a room.
    * <br>If a client is disconnected from the server due to poor network quality, the SDK starts reconnecting. If the client and
    * server are reconnected, the callback is triggered.
    * @param cid       The ID of the room that the client joins.
    * @param uid       The ID of a user.
    * @param result    The result.
    * @param elapsed   The time elapsed from reconnection to the occurrence of this event. Unit: milliseconds.
    * @endif
    * @if Chinese
    * 重新加入房间回调。
    * <br>在弱网环境下，若客户端和服务器失去连接，SDK会自动重连。自动重连成功后触发此回调方法。
    * @param cid       客户端加入的房间 ID。
    * @param uid       用户 ID。
    * @param result    返回结果。
    * @param elapsed   从开始重连到发生此事件过去的时间，单位为毫秒。
    * @endif
    */
    public delegate void OnRejoinChannel(ulong cid, ulong uid, RtcErrorCode result, ulong elapsed);
    /**
    * @if English
    * Occurs when a user leaves a room.
    * <br>After an app invokes the \ref IRtcEngine::LeaveChannel method, SDK prompts whether the app successfully leaves the room.
    * @param result    The result.
    * @endif
    * @if Chinese
    * 退出房间回调。
    * <br>App 调用 \ref IRtcEngine::LeaveChannel 方法后，SDK 提示 App 退出房间是否成功。
    * @param result    返回结果。
    * @endif
    */
    public delegate void OnLeaveChannel(RtcErrorCode result);
    /**
    * @if English
    * Network connection interruption.
    * @note
    * - The callback is triggered if the SDK fails to connect to the server three consecutive times after you successfully call
    * the \ref IRtcEngine::JoinChannel method.
    * - A client may be disconnected from the server in poor network connection. At this time,  the SDK needs not automatically
    * reconnecting until the SDK triggers the callback method.
    * @param reason    The reason why the network is disconnected.
    * @endif
    * @if Chinese
    * 网络连接中断
    * @note
    * - SDK 在调用 \ref IRtcEngine::JoinChannel 加入房间成功后，如果和服务器失去连接且连续 3 次重连失败，就会触发该回调。
    * - 由于非网络原因，客户端可能会和服务器失去连接，此时SDK无需自动重连，直接触发此回调方法。
    * @param reason    网络连接中断原因。
    * @endif
    */
    public delegate void OnDisconnect(RtcErrorCode reason);
    /**
    * @if English
    * Occurs when a user changes the role in live streaming.
    * <br>After the local user joins a room, the user can call the \ref IRtcEngine::SetClientRole to change the
    * role. Then, the callback is triggered. For example, you can switch the role from host to audience, or from audience to
    * host.
    * @note In live streaming, if you join a room and successfully call this method to change the role, the following callbacks
    * are triggered.
    * - If the role changes from host to audience, the \ref nertc::OnClientRoleChanged "OnClientRoleChanged" is locally triggered, and the
    *  \ref nertc::OnUserLeft "OnUserLeft" is remotely triggered.
    * - If the role is changed from audience to host, the \ref nertc::OnClientRoleChanged "OnClientRoleChanged" callback is locally triggered, and the 
    * \ref nertc::OnUserJoined "onUserJoined" is remotely triggered.
    * @param oldRole  The role before the user changes the role.
    * @param newRole  The role after the change.
    * @endif
    * @if Chinese
    * 直播场景下用户角色已切换回调。
    * <br>本地用户加入房间后，通过 \ref IRtcEngine::SetClientRole
    * 切换用户角色后会触发此回调。例如主播切换为观众、从观众切换为主播。
    * @note 直播场景下，如果您在加入房间后调用该方法切换用户角色，调用成功后，会触发以下回调：
    * - 主播切观众，本端触发 \ref nertc::OnClientRoleChanged "OnClientRoleChanged" 回调，远端触发 \ref nertc::OnUserLeft "OnUserLeft" 回调。
    * - 观众切主播，本端触发 \ref nertc::OnClientRoleChanged "OnClientRoleChanged" 回调，远端触发 \ref nertc::OnUserJoined "onUserJoined" 回调。
    * @param oldRole  切换前的角色。
    * @param newRole  切换后的角色。
    * @endif
    */
    public delegate void OnClientRoleChanged(RtcClientRole oldRole, RtcClientRole newRole);
    /**
    * @if English
    * Occurs when a remote user joins the current room.
    * <br>The callback prompts that a remote user joins the room and returns the ID of the user that joins the room. If the user
    * ID already exists, the remote user also receives a message that the user already joins the room, which is returned by the
    * callback.
    * @param uid           The ID of the user that joins the room.
    * @param userName     The name of the remote user who joins the room.
    * @endif
    * @if Chinese
    * 远端用户加入当前房间回调。
    * <br>该回调提示有远端用户加入了房间，并返回新加入用户的
    * ID；如果加入之前，已经有其他用户在房间中了，新加入的用户也会收到这些已有用户加入房间的回调。
    * @param uid           新加入房间的远端用户 ID。
    * @param userName     新加入房间的远端用户名。
    * @endif
    */
    public delegate void OnUserJoined(ulong uid, string userName);
    /**
    * @if English
    * Occurs when a remote user leaves a room.
    * <br>A message is returned indicates that a remote user leaves the room or becomes disconnected. In most cases, a user
    * leaves a room due to the following reasons: The user exit the room or connections time out.
    * - When a user leaves a room, remote users will receive callback notifications that users leave the room. In this way, users
    * can be specified to leave the room.
    * - If the connection times out, and the user does not receive data packets for a time period of 40 to 50 seconds, then the
    * user becomes disconnected.
    * @param uid           The ID of the user that leaves the room.
    * @param reason        The reason why remote user leaves.
    * @endif
    * @if Chinese
    * 远端用户离开当前房间的回调。
    * <br>提示有远端用户离开了房间（或掉线）。通常情况下，用户离开房间有两个原因，即正常离开和超时掉线：
    * - 正常离开的时候，远端用户会收到正常离开房间的回调提醒，判断用户离开房间。
    * - 超时掉线的依据是，在一定时间内（40~50s），用户没有收到对方的任何数据包，则判定为对方掉线。
    * @param uid           离开房间的远端用户 ID。
    * @param reason        远端用户离开原因。
    * @endif
    */
    public delegate void OnUserLeft(ulong uid, RtcSessionLeaveReason reason);
    /**
    * @if English
    * Occurs when a remote user enables audio.
    * @param uid           The ID of a remote user.
    * @endif
    * @if Chinese
    * 远端用户开启音频的回调。
    * @param uid           远端用户ID。
    * @endif
    */
    public delegate void OnUserAudioStart(ulong uid);
    /**
    * @if English
    * Occurs when a remote user disables audio.
    * @param uid           The ID of a remote user.
    * @endif
    * @if Chinese
    * 远端用户停用音频的回调。
    * @param uid           远端用户ID。
    * @endif
    */
    public delegate void OnUserAudioStop(ulong uid);
    /**
    * @if English
    * Occurs when a remote user enables video.
    * @param uid           The ID of a remote user.
    * @param maxProfile   The resolution of video encoding measures the encoding quality.
    * @endif
    * @if Chinese
    * 远端用户开启视频的回调。
    * @param uid           远端用户ID。
    * @param maxProfile   视频编码的分辨率，用于衡量编码质量。
    * @endif
    */
    public delegate void OnUserVideoStart(ulong uid, RtcVideoProfileType maxProfile);
    /**
    * @if English
    * Occurs when a remote user disables video.
    * @param uid           The ID of a remote user.
    * @endif
    * @if Chinese
    * 远端用户停用视频的回调。
    * @param uid           远端用户ID。
    * @endif
    */
    public delegate void OnUserVideoStop(ulong uid);
    /**
    * @if English
    * Occurs when a remote user enables screen sharing by using the substream.
    * @param uid           The ID of a remote user.
    * @param maxProfile   The largest resolution of the remote video.
    *
    * @endif
    * @if Chinese
    * 远端用户开启屏幕共享辅流通道的回调。
    * @param uid           远端用户 ID。
    * @param maxProfile   最大分辨率。
    * @endif
    */
    public delegate void OnUserSubStreamVideoStart(ulong uid, RtcVideoProfileType maxProfile);
    /**
    * @if English
    * Occurs when a remote user stops screen sharing by using the substream.
    * @param uid   The ID of a remote user.
    *
    * @endif
    * @if Chinese
    * 远端用户停止屏幕共享辅流通道的回调。
    * @param uid   远端用户ID。
    * @endif
    */
    public delegate void OnUserSubStreamVideoStop(ulong uid);
    /**
    * @if English
    * Occurs when screen sharing is paused/resumed/started/ended.
    * <br>The method applies to Windows only.
    * @since V4.2.0
    * @param status    Screen capture status. For more information, see  {@link RtcScreenCaptureStatus} .
    * @endif
    * @if Chinese
    * 屏幕共享状态变化回调。
    * <br>该方法仅适用于 Windows 平台。
    * @since V4.2.0
    * @param status    屏幕共享状态。详细信息请参考 {@link RtcScreenCaptureStatus} 。
    * @endif
    */
    public delegate void OnScreenCaptureStatusChanged(RtcScreenCaptureStatus status);
    /**
    * @if English
    * Occurs when video configurations of remote users are updated.
    * @param uid           The ID of a remote user.
    * @param maxProfile   The resolution of video encoding measures the encoding quality.
    * @endif
    * @if Chinese
    * @param uid           远端用户 ID。
    * @param maxProfile   视频编码的分辨率，用于衡量编码质量。
    * @endif
    */
    public delegate void OnUserVideoProfileUpdate(ulong uid, RtcVideoProfileType maxProfile);
    /**
    * @if English
    * Callbacks that specify whether to mute remote users.
    * @param uid       The ID of a remote user.
    * @param mute      indicates whether to unmute the remote user.
    * @endif
    * @if Chinese
    * 远端用户是否静音的回调。
    * @param uid       远端用户ID。
    * @param mute      是否静音。
    * @endif
    */
    public delegate void OnUserAudioMute(ulong uid, bool mute);
    /**
    * @if English
    * Occurs when a remote user stops or resumes sending video streams.
    * @param uid       The ID of a remote user.
    * @param mute      Whether to disable video streams.
    * @endif
    * @if Chinese
    * 远端用户暂停或恢复发送视频流的回调。
    * @param uid       远端用户ID。
    * @param mute      是否禁视频流。
    * @endif
    */
    public delegate void OnUserVideoMute(ulong uid, bool mute);
    /**
    * @if English
    * Occurs when the audio routing changes.
    * @param routing The current audio output routing.
    * @endif
    * @if Chinese
    * 音频路由变化回调。
    * @param routing 当前音频输出路由。
    * @endif
    */
    public delegate void OnAudioDeviceRoutingDidChange(RtcAudioOutputRouting routing);
    /**
    * @if English
    * Occurs when the state of the audio device changes.
    * @param deviceId    Device ID.
    * @param deviceType  The type of the device. For more information, see #RtcAudioDeviceType .
    * @param deviceState The state of the audio device.
    * @endif
    * @if Chinese
    * 音频设备状态更改的回调。
    * @param deviceId     设备ID。
    * @param deviceType   音频设备类型。详细信息请参考 #RtcAudioDeviceType 。
    * @param deviceState  音频设备状态。
    * @endif
    */
    public delegate void OnAudioDeviceStateChanged(string deviceId, RtcAudioDeviceType deviceType, RtcAudioDeviceState deviceState);
    /**
    * @if English
    * Occurs when the default audio devices changes.
    * @param deviceId     Device ID.
    * @param deviceType   The type of the device.
    * @endif
    * @if Chinese
    * 音频默认设备更改的回调。
    * @param deviceId     设备ID。
    * @param deviceType   音频设备类型。
    * @endif
    */
    public delegate void OnAudioDefaultDeviceChanged(string deviceId, RtcAudioDeviceType deviceType);
    /**
    * @if English
    * Occurs when the state of the video device is changed.
    * @param deviceId     Device ID.
    * @param deviceType   The type of the video device.
    * @param deviceState  The state of the video device.
    * @endif
    * @if Chinese
    * 视频设备状态已改变的回调。
    * @param deviceId     设备ID。
    * @param deviceType   视频设备类型。
    * @param deviceState  视频设备状态。
    * @endif
    */
    public delegate void OnVideoDeviceStateChanged(string deviceId, RtcVideoDeviceType deviceType, RtcVideoDeviceState deviceState);
    /**
    * @if English
    * Occurs when the camera focus position changes.
    * The callback indicates that the camera focus position changes.
    * The callback is triggered if a local user calls the \ref IRtcEngine::SetCameraFocusPosition method to change the focus position.
    * @note The audio-only SDK disables this API. If you need to use the API, you can download the standard SDK from the official
    * website of CommsEase and replace the audio-only SDK.
    * @param info The new focus position.
    * @endif
    * @if Chinese
    * 摄像头对焦区域已改变回调。
    * 该回调表示相机的对焦区域发生了改变。
    * 该回调是由本地用户调用 \ref IRtcEngine::SetCameraFocusPosition 方法改变对焦位置触发的。
    * @note 纯音频 SDK 禁用该接口，如需使用请前往云信官网下载并替换成视频 SDK。
    * @param info 新的对焦区域位置。
    * @endif
    */
    public delegate void OnCameraFocusChanged(RtcCameraFocusAndExposureInfo info);
    /**
    * @if English
    * Occurs when the camera exposure position changes.
    * The callback is triggered if a local user calls the \ref IRtcEngine::SetCameraExposurePosition method to change the exposure position.
    * @note The audio-only SDK disables this API. If you need to use the API, you can download the standard SDK from the official
    * website of CommsEase and replace the audio-only SDK.
    * @param info The new exposure position.
    * @endif
    * @if Chinese
    * 摄像头曝光区域已改变回调。
    * 该回调是由本地用户调用 \ref IRtcEngine::SetCameraExposurePosition 方法改变曝光位置触发的。
    * @note 纯音频 SDK 禁用该接口，如需使用请前往云信官网下载并替换成视频 SDK。
    * @param info 新的曝光区域位置信息。
    * @endif
    */
    public delegate void OnCameraExposureChanged(RtcCameraFocusAndExposureInfo info);
    /**
    * @if English
    * Occurs when the first audio frame from a remote user is received.
    * @param uid       The ID of a remote user whose audio streams are sent.
    * @endif
    * @if Chinese
    * 已接收到远端音频首帧的回调。
    * @param uid       远端用户 ID，指定是哪个用户的音频流。
    * @endif
    */
    public delegate void OnFirstAudioDataReceived(ulong uid);
    /**
    * @if English
    * Occurs when the first video frame from a remote user is displayed.
    * <br>If the first video frame from a remote user is displayed in the view, the callback is triggered.
    * @param uid       The ID of a user whose audio streams are sent.
    * @endif
    * @if Chinese
    * 已显示首帧远端视频的回调。
    * 第一帧远端视频显示在视图上时，触发此调用。
    * @param uid       用户 ID，指定是哪个用户的视频流。
    * @endif
    */
    public delegate void OnFirstVideoDataReceived(ulong uid);
    /**
    * @if English
    * Occurs when the first audio frame from a remote user is decoded.
    * @param uid       The ID of a remote user whose audio streams are sent.
    * @endif
    * @if Chinese
    * 已解码远端音频首帧的回调。
    * @param uid       远端用户 ID，指定是哪个用户的音频流。
    * @endif
    */
    public delegate void OnFirstAudioFrameDecoded(ulong uid);
    /**
    * @if English
    * Occurs when the remote video is received and decoded.
    * <br>If the engine receives the first frame of remote video streams, the callback is triggered.
    * @param uid       The ID of a user whose audio streams are sent.
    * @param width     The width of video streams (px).
    * @param height    The height of video streams(px).
    * @endif
    * @if Chinese
    * 已接收到远端视频并完成解码的回调。
    * <br>引擎收到第一帧远端视频流并解码成功时，触发此调用。
    * @param uid       用户 ID，指定是哪个用户的视频流。
    * @param width     视频流宽（px）。
    * @param height    视频流高（px）。
    * @endif
    */
    public delegate void OnFirstVideoFrameDecoded(ulong uid, uint width, uint height);
    /**
    * @if English
    * Occurs when video data are captured.
    * @param data      The video frame data.
    * @param type      The type of the video data.
    * @param width     The width of the video frame.
    * @param height    The height of the video frame.
    * @param count     Video plane count.
    * @param offset    Video offset.
    * @param stride    Video stride.
    * @param rotation  The video rotation angle.
    * @endif
    * @if Chinese
    * 采集视频数据回调。

    * @param data      采集视频数据。
    * @param type      视频类型。
    * @param width     视频宽度。
    * @param height    视频高度。
    * @param count     视频Plane Count。
    * @param offset    视频offset。
    * @param stride    视频stride。
    * @param rotation  视频旋转角度。
    * @endif
    */
    public delegate void OnCaptureVideoFrame(IntPtr data, RtcVideoType type, uint width, uint height, uint count, uint[] offset, uint[] stride, RtcVideoRotation rotation);
    /**
    * @if English
    * Occurs when the playback state of a local music file changes.
    * <br>If you call the startAudioMixing method to play a mixing music file and the playback state changes, the callback is
    * triggered.
    * - If the playback of the music file ends normally, the state parameter returned in the response contains the corresponding
    * status code \ref RtcAudioMixingState::kNERtcAudioMixingStateFinished "kNERtcAudioMixingStateFinished" , and the errorCode 
    * parameter contains \ref RtcAudioMixingErrorCode::kNERtcAudioMixingErrorOK "kNERtcAudioMixingErrorOK".
    * - If an error occurs in the playback, the \ref RtcAudioMixingState::kNERtcAudioMixingStateFailed "kNERtcAudioMixingStateFailed" status code is returned, and the errorCode
    * parameter returned contains the corresponding reason.
    * - If the local music file does not exist, the file format is not supported, or the URL of the online music file cannot be
    * accessed, the errorCode parameter returned contains \ref RtcAudioMixingErrorCode::kNERtcAudioMixingErrorCanNotOpen "kNERtcAudioMixingErrorCanNotOpen" .
    * @param state         The playback state of the music file. For more information, see #RtcAudioMixingState .
    * @param errorCode    The error code. For more information, see #RtcAudioMixingErrorCode .
    * @endif
    * @if Chinese
    * 本地用户的音乐文件播放状态改变回调。
    * <br>调用 startAudioMixing 播放混音音乐文件后，当音乐文件的播放状态发生改变时，会触发该回调。
    * - 如果播放音乐文件正常结束，state 会返回相应的状态码 \ref RtcAudioMixingState::kNERtcAudioMixingStateFinished "kNERtcAudioMixingStateFinished"，errorCode 返回
    * \ref RtcAudioMixingErrorCode::kNERtcAudioMixingErrorOK "kNERtcAudioMixingErrorOK"。
    * - 如果播放出错，则返回状态码 \ref RtcAudioMixingState::kNERtcAudioMixingStateFailed "kNERtcAudioMixingStateFailed"，errorCode 返回相应的出错原因。
    * - 如果本地音乐文件不存在、文件格式不支持、无法访问在线音乐文件 URL，errorCode都会返回 \ref RtcAudioMixingErrorCode::kNERtcAudioMixingErrorCanNotOpen "kNERtcAudioMixingErrorCanNotOpen"。
    * @param state         音乐文件播放状态，详见 #RtcAudioMixingState 。
    * @param errorCode    错误码，详见 #RtcAudioMixingErrorCode 。
    * @endif
    */
    public delegate void OnAudioMixingStateChanged(RtcAudioMixingState state, RtcAudioMixingErrorCode errorCode);
    /**
    * @if English
    * Occurs when the playback position of a local music file changes.
    * <br>If you call the \ref IRtcEngine::StartAudioMixing method to play a mixing music file and the position of the playing operation changes,
    * the callback is triggered.
    * @param timestampMS      The position of the music file playing. Unit: milliseconds.
    * @endif
    * @if Chinese
    * 本地用户的音乐文件播放进度回调。
    * <br>调用 \ref IRtcEngine::StartAudioMixing 播放混音音乐文件后，当音乐文件的播放进度改变时，会触发该回调。
    * @param timestampMS      音乐文件播放进度，单位为毫秒
    * @endif
    */
    public delegate void OnAudioMixingTimestampUpdate(ulong timestampMS);
    /**
    * @if English
    * Occurs when the playback of a music file ends.
    * <br>After the audio effect ends the playback, the callback is triggered.
    * @param effectId         The ID of the specified audio effect. Each audio effect has a unique ID.
    * @endif
    * @if Chinese
    * 本地音效文件播放已结束回调。
    * <br>当播放音效结束后，会触发该回调。
    * @param effectId         指定音效的 ID。每个音效均有唯一的 ID。
    * @endif
    */
    public delegate void OnAudioEffectFinished(uint effectId);
    /**
    * @if English
    * Occurs when the system prompts current local audio volume.
    * - This callback is disabled by default. You can enable the callback by calling the \ref
    * IRtcEngine::EnableAudioVolumeIndication method.
    * - After the callback is enabled, if a local user speaks, the SDK triggers the callback based on the time interval specified
    * in the \ref IRtcEngine::EnableAudioVolumeIndication method.
    * - If a local user sets a mute by calling \ref IRtcEngine::MuteLocalAudioStream , the SDK sets the
    * value of volume as 0, and calls back to the application layer.
    * @param volume    The volume of audio mixing. Value range: 0 to 100.
    * @endif
    * @if Chinese
    * 提示房间内本地用户瞬时音量的回调。
    * - 该回调默认禁用。可以通过 \ref IRtcEngine::EnableAudioVolumeIndication 方法开启。
    * - 开启后，本地用户说话，SDK 会按  \ref IRtcEngine::EnableAudioVolumeIndication 
    * 方法中设置的时间间隔触发该回调。
    * - 如果本地用户将自己静音（调用 \ref IRtcEngine::MuteLocalAudioStream ），SDK 将音量设置为 0
    * 后回调给应用层。
    * @param volume    （混音后的）音量，取值范围为 [0,100]。
    * @endif
    */
    public delegate void OnLocalAudioVolumeIndication(int volume);
    /**
    * @if English
    * Occurs when the system prompts the active speaker and the audio volume.
    * By default, the callback is disabled. You can enable the callback by calling the \ref IRtcEngine::EnableAudioVolumeIndication method. After
    * the callback is enabled, if a local user speaks, the SDK triggers the callback based on the time interval specified in the
    * \ref IRtcEngine::EnableAudioVolumeIndication method. In the array of speakers returned:
    * - If a uid is contained in the array returned in the last response but not in the array returned in the current response.
    * The remote user with the uid does not speak by default.
    * - If the volume is 0, the user does not speak.
    * - If the array is empty, the remote user does not speak.
    * @param speakers          The array that contains the information about user IDs and volumes is {@link RtcAudioVolumeInfo} .
    * @param totalVolume      The total volume (after audio mixing). Value range: 0 to 100.
    * @endif
    * @if Chinese
    * 提示房间内谁正在说话及说话者瞬时音量的回调。
    * <br>该回调默认为关闭状态。可以通过 \ref IRtcEngine::EnableAudioVolumeIndication 方法开启。开启后，无论房间内是否有人说话，SDK 都会按
    * \ref IRtcEngine::EnableAudioVolumeIndication 方法中设置的时间间隔触发该回调。 <br>在返回的 speakers 数组中:
    * - 如果有 uid 出现在上次返回的数组中，但不在本次返回的数组中，则默认该 uid 对应的远端用户没有说话。
    * - 如果volume 为 0，表示该用户没有说话。
    *  - 如果speakers 数组为空，则表示此时远端没有人说话。
    * @param speakers          每个说话者的用户 ID 和音量信息的数组: {@link RtcAudioVolumeInfo}
    * @param totalVolume      （混音后的）总音量，取值范围为 [0,100]。
    * @endif
    */
    public delegate void OnRemoteAudioVolumeIndication(RtcAudioVolumeInfo[] speakers, int totalVolume);
    /**
    * @if English
    * Notifies to add the result of live stream.
    * <br>The callback asynchronously returns the callback result of \ref IRtcEngine::AddLiveStreamTask .
    * For information about actual pushing state, see \ref nertc::OnLiveStreamStateChanged "OnLiveStreamStateChanged".
    * @param taskId       The ID of a stream-push task.
    * @param url           Task ID.
    * @param errorCode    The result.
    * - 0: Success.
    * - Other values: Failure.
    * @endif
    * @if Chinese
    * 通知添加直播任务结果。
    * <br>该回调异步返回 \ref IRtcEngine::AddLiveStreamTask 接口的调用结果；实际推流状态参考 
    * \ref nertc::OnLiveStreamStateChanged "OnLiveStreamStateChanged"
    * @param taskId       任务id
    * @param url           推流地址
    * @param errorCode    结果
    * - 0: 调用成功；
    * - 其他: 调用失败。
    * @endif
    */
    public delegate void OnAddLiveStreamTask(string taskId, string url, int errorCode);
    /**
    * @if English
    * Notifies to Updates the result of live stream.
    * <br>The callback asynchronously returns the callback result of ref IRtcEngine::UpdateLiveStreamTask . For
    * information about actual pushing state, see \ref nertc::OnLiveStreamStateChanged "OnLiveStreamStateChanged" .
    * @param taskId       The ID of a stream-push task.
    * @param url           The URL for the streaming task.
    * @param errorCode    The result.
    * - 0: Success.
    * - Other values: Failure.
    * @endif
    * @if Chinese
    * 通知更新直播任务结果。
    * 该回调异步返回 \ref IRtcEngine::UpdateLiveStreamTask 接口的调用结果；实际推流状态参考
    * \ref nertc::OnLiveStreamStateChanged "OnLiveStreamStateChanged"
    * @param taskId       任务id
    * @param url           推流地址
    * @param errorCode    结果
    * - 0: 调用成功；
    * - 其他: 调用失败。
    * @endif
    */
    public delegate void OnUpdateLiveStreamTask(string taskId, string url, int errorCode);
    /**
    * @if English
    * Notifies to delete the result of live stream.
    * <br>The callback asynchronously returns the callback result of ref IRtcEngine::RemoveLiveStreamTask . For
    * information about actual pushing state, see \ref nertc::OnLiveStreamStateChanged "OnLiveStreamStateChanged".
    * @param taskId       The ID of a task.
    * @param errorCode    The result.
    * - 0: Success.
    * - Other values: Failure.
    * @endif
    * @if Chinese
    * 通知删除直播任务结果。
    * <br>该回调异步返回 \ref IRtcEngine::RemoveLiveStreamTask 接口的调用结果；实际推流状态参考 
    * \ref nertc::OnLiveStreamStateChanged "OnLiveStreamStateChanged"
    *  @param taskId      任务id
    * @param errorCode    结果
    * - 0: 调用成功；
    * - 其他: 调用失败。
    * @endif
    */
    public delegate void OnRemoveLiveStreamTask(string taskId, int errorCode);
    /**
    * @if English
    * Notifies the status in live stream-pushing.
    * @note The callback is valid in a call.
    * @param taskId       The ID of a task.
    * @param url          The URL for the streaming task.
    * @param state        #RtcLiveStreamStateCode The state of live stream-pushing.
    * - 505: Pushing.
    * - 506: Pushing fails.
    * - 511: Pushing ends.
    * @endif
    * @if Chinese
    * 通知直播推流状态
    * @note 该回调在通话中有效。
    * @param taskId     任务id
    * @param url        推流地址
    * @param state      #RtcLiveStreamStateCode, 直播推流状态
    * - 505: 推流中。
    * - 506: 推流失败。
    * - 511: 推流结束。
    * @endif
    */
    public delegate void OnLiveStreamStateChanged(string taskId, string url, RtcLiveStreamStateCode state);
    /**
    * @if English
    * Occurs when howling is detected.
    * When the distance between the sound source and the PA equipment is too close, howling may occur. The NERTC SDK supports the
    * howling detection. When a howling signal is detected, the callback is automatically triggered until the howling stops. The
    * application layer can prompt the user to mute the microphone or directly mute the microphone when the app receives the
    * howling information returned by the callback.
    * @note
    * Howling detection is used in audio-only scenarios, such as audio chat rooms or online meetings. We recommend that you do
    * not use howling detection in entertainment scenes that include background music.
    * @param howling       Whether a howling occurs.
    * - true: Howling occurs.
    * - false: Normal state.
    * @endif
    * @if Chinese
    * 检测到啸叫回调。
    * <br>当声源与扩音设备之间因距离过近时，可能会产生啸叫。NERTC SDK
    * 支持啸叫检测，当检测到有啸叫信号产生的时候，自动触发该回调直至啸叫停止。App
    * 应用层可以在收到啸叫回调时，提示用户静音麦克风，或直接静音麦克风。
    * @note
    * 啸叫检测功能一般用于语音聊天室或在线会议等纯人声环境，不推荐在包含背景音乐的娱乐场景中使用。
    * @param howling       是否出现啸叫
    * - true: 啸叫。
    * - false: 正常。
    * @endif
    */
    public delegate void OnAudioHowling(bool howling);
    /**
    * @if English
    * Occurs when the content of remote SEI is received.
    * <br>After a remote client successfully sends SEI, the local client receives a message returned by the callback.
    * @param[in] uid       The ID of the user who sends the SEI.
    * @param[in] data      The received SEI data.
    * @param[in] dataSize  The size of received SEI data.
    * @endif
    * @if Chinese
    * 收到远端流的 SEI 内容回调。
    * <br>当远端成功发送 SEI 后，本端会收到此回调。
    * @param[in] uid       发送该 sei 的用户 id
    * @param[in] data      接收到的 sei 数据
    * @param[in] dataSize  接收到 sei 数据的大小
    * @endif
    */
    public delegate void OnRecvSEIMessage(ulong uid, byte[] data, uint dataSize);
    /**
    * @if English
    * Returns the audio recording state.
    *  @param code         The status code of the audio recording. For more information, see #RtcAudioRecordingCode .
    * @param filePath     The path based on which the recording file is stored.
    * @endif
    * @if Chinese
    * 音频录制状态回调。
    * @param code          音频录制状态码。详细信息请参考 #RtcAudioRecordingCode 。
    * @param filePath     音频录制文件保存路径。
    * @endif
    */
    public delegate void OnAudioRecording(RtcAudioRecordingCode code, string filePath);
    /**
    * @if English
    * Occurs when the state of the media stream is relayed.
    * @since V4.3.0
    * @param state         The state of the media stream.
    * @param channelName  The name of the destination room where the media streams are relayed.
    * @endif
    * @if Chinese
    * 跨房间媒体流转发状态发生改变回调。
    * @since V4.3.0
    * @param state         当前跨房间媒体流转发状态。详细信息请参考 #RtcChannelMediaRelayState
    * @param channelName  媒体流转发的目标房间名。
    * @endif
    */
    public delegate void OnMediaRelayStateChanged(RtcChannelMediaRelayState state, string channelName);
    /**
    * @if English
    * Occurs when events related to media stream relay are triggered.
    * @since V4.3.0
    * @param evt         The media stream relay event.
    * @param channelName  The name of the destination room where the media streams are relayed.
    * @param error         Specific error codes.
    * @endif
    * @if Chinese
    * 媒体流相关转发事件回调。
    * @since V4.3.0
    * @param evt         当前媒体流转发事件。详细信息请参考 #RtcChannelMediaRelayEvent 。
    * @param channelName  转发的目标房间名。
    * @param error         相关错误码。详细信息请参考 #RtcErrorCode 。
    * @endif
    */
    public delegate void OnMediaRelayEvent(RtcChannelMediaRelayEvent evt, string channelName, RtcErrorCode error);
    /**
    * @if English
    * Occurs when the published local media stream falls back to an audio-only stream due to poor network conditions or switches
    * back to audio and video stream after the network conditions improve. <br>If you call \ref IRtcEngine::SetLocalPublishFallbackOption and set
    * option to \ref RtcStreamFallbackOption::kNERtcStreamFallbackAudioOnly "kNERtcStreamFallbackAudioOnly", this callback is triggered when the locally published stream falls back to
    * audio-only mode due to poor uplink network conditions, or when the audio stream switches back to the audio and video stream
    * after the uplink network conditions improve.
    * @since V4.3.0
    * @param isFallback   The locally published stream falls back to audio-only mode or switches back to audio and video stream.
    * - true: The published stream from a local client falls back to audio-only mode due to poor uplink network conditions.
    * - false: The audio stream switches back to the audio and video stream after the upstream network condition improves.
    * @param streamType   The type of the video stream, such as mainstream and substream.
    * @endif
    * @if Chinese
    * 本地发布流已回退为音频流、或已恢复为音视频流回调。
    * <br>如果您调用了设置本地推流回退选项 \ref IRtcEngine::SetLocalPublishFallbackOption 接口，并将 option 设置为 \ref RtcStreamFallbackOption::kNERtcStreamFallbackAudioOnly "kNERtcStreamFallbackAudioOnly"
    * 后，当上行网络环境不理想、本地发布的媒体流回退为音频流时，或当上行网络改善、媒体流恢复为音视频流时，会触发该回调。
    * @since V4.3.0
    * @param isFallback   本地发布流已回退或已恢复。
    * - true： 由于网络环境不理想，发布的媒体流已回退为音频流。
    * - false：由于网络环境改善，从音频流恢复为音视频流。
    * @param streamType   对应的视频流类型，即主流或辅流。
    * @endif
    */
    public delegate void OnPublishFallbackToAudioOnly(bool isFallback, RtcVideoStreamType streamType);
    /**
    * @if English
    * Occurs when the subscribed remote media stream falls back to an audio-only stream due to poor network conditions or
    * switches back to the audio and video stream after the network condition improves. <br>If you call
    * \ref IRtcEngine::SetRemoteSubscribeFallbackOption and set option to \ref RtcStreamFallbackOption::kNERtcStreamFallbackAudioOnly "kNERtcStreamFallbackAudioOnly", 
    * this callback is triggered when the locally  published stream falls back to audio-only mode due to poor uplink network conditions, 
    * or when the audio stream switches back to the audio and video stream after the uplink network condition improves.
    * @since V4.3.0
    * @param uid           The ID of a remote user.
    * @param isFallback   The subscribed remote media stream falls back to audio-only mode or switches back to the audio and
    * video stream.
    * - true: The subscribed remote media stream falls back to audio-only mode due to poor downstream network conditions.
    * - false: The subscribed remote media stream switches back to the audio and video stream after the downstream network
    * condition improves.
    * @param streamType   The type of the video stream, such as mainstream and substream.
    * @endif
    * @if Chinese
    * 订阅的远端流已回退为音频流、或已恢复为音视频流回调。
    * <br>如果你调用了设置远端订阅流回退选项 \ref IRtcEngine::SetRemoteSubscribeFallbackOption 接口并将 option 设置 \ref RtcStreamFallbackOption::kNERtcStreamFallbackAudioOnly 
    * "kNERtcStreamFallbackAudioOnly"
    * 后，当下行网络环境不理想、仅接收远端音频流时，或当下行网络改善、恢复订阅音视频流时，会触发该回调。
    * @since V4.3.0
    * @param uid           远端用户的 ID。
    * @param isFallback   远端订阅流已回退或恢复：
    * - true： 由于网络环境不理想，订阅的远端流已回退为音频流。
    * - false：由于网络环境改善，订阅的远端流从音频流恢复为音视频流。
    * @param streamType   对应的视频流类型，即主流或辅流。
    * @endif
    */
    public delegate void OnSubscribeFallbackToAudioOnly(ulong uid, bool isFallback, RtcVideoStreamType streamType);
    /**
    * @if English
    * Reports the last mile network quality of the local user once every two seconds before the user joins the channel.
    * <br> After the application calls the \ref IRtcEngine::StartLastmileProbeTest method, this callback reports once every five seconds the
    * uplink and downlink last mile network conditions of the local user before the user joins the channel.
    * @since V4.5.0
    * @param quality       The last mile network quality.
    * @endif
    * @if Chinese
    * 通话前网络上下行 last mile 质量状态回调。
    * <br>该回调描述本地用户在加入房间前的 last mile
    * 网络探测的结果，以打分形式描述上下行网络质量的主观体验，您可以通过该回调预估本地用户在音视频通话中的网络体验。 <br>在调用
    * \ref IRtcEngine::StartLastmileProbeTest 之后，SDK 会在约 5 秒内返回该回调。
    * @since V4.5.0
    * @param quality       网络上下行质量，基于上下行网络的丢包率和抖动计算，探测结果主要反映上行网络的状态。
    * @endif
    */
    public delegate void OnLastmileQuality(RtcNetworkQualityType quality);
    /**
    * @if English
    * Reports the last-mile network probe result.
    * <br>This callback describes a detailed last-mile network detection report of a local user before joining a channel. The
    * report provides objective data about the upstream and downstream network quality, including network jitter and packet loss
    * rate.  You can use the report to objectively predict the network status of local users during an audio and video call.
    * <br>The SDK triggers this callback within 30 seconds after the app calls the \ref IRtcEngine::StartLastmileProbeTest method.
    * @since V4.5.0
    * @param result        The uplink and downlink last-mile network probe test result.
    * @endif
    * @if Chinese
    * 通话前网络上下行 Last mile 质量探测报告回调。
    * <br>该回调描述本地用户在加入房间前的 last mile
    * 网络探测详细报告，报告中通过客观数据反馈上下行网络质量，包括网络抖动、丢包率等数据。您可以通过该回调客观预测本地用户在音视频通话中的网络状态。
    * <br>在调用 \ref IRtcEngine::StartLastmileProbeTest 之后，SDK 会在约 30 秒内返回该回调。
    * @since V4.5.0
    * @param result        上下行 Last mile 质量探测结果。
    * @endif
    */
    public delegate void OnLastmileProbeResult(RtcLastmileProbeResult result);
    /**
    * @if English
    * Called when a digital avatar joins the current room.
    * 
    * @note
    * - The callback prompts that the remote digital avatar joins the current room and return the ID of the digital avatar.
    * - If users want to use digital avatars without enabling the visual avatar, a digital avatar will join the current room.
    * 
    * @param srcUid ID of a source user of the remote digital avatar leaving the room. The digital avatar of the current user srcUid is 0.
    * @param uid ID of the remote digital avatar joining the room。
    * @param userName User name of the remote digital avatar joining the room    
    * @endif
    * @if Chinese
    * 虚拟人加入当前房间回调。
    * 
    * @note
    * - 该回调提示有远端虚拟人加入了房间，并返回新加入虚拟人的ID。
    * - 真实用户需要使用虚拟人服务（哪怕没有当前开启虚拟人画面），就会有对应的虚拟人入会。
    * 
    * @param srcUid 离开房间的远端虚拟人对应的真实用户 ID。自己的虚拟人srcUid为0。
    * @param uid 新加入房间的远端虚拟人 ID。
    * @param userName 新加入频道的远端虚拟人用户名。
    * @endif
    */
    public delegate void OnAvatarUserJoined(ulong srcUid, ulong uid, string userName);
    /**
    * @if English
    * Called when a digital avatar leaves the current room.
    * 
    * The remote digital avatar leaves the room (or goes off-line).
    * 
    * @param srcUid ID of a source user of the remote digital avatar leaving the room. The digital avatar of the current user srcUid is 0.
    * @param uid ID of the digital avatar leaving the room.
    * @param reason reason for leaving the room.    
    * @endif
    * @if Chinese
    * 虚拟人离开当前房间的回调。
    * 
    * 提示有远端虚拟人离开了房间（或掉线）。
    * 
    * @param srcUid 离开房间的远端虚拟人对应的真实用户 ID。自己的虚拟人srcUid为0。
    * @param uid 离开房间的远端虚拟人 ID。
    * @param reason 远端用户离开原因。
    * @endif
    */
    public delegate void OnAvatarUserLeft(ulong srcUid, ulong uid, RtcSessionLeaveReason reason);
    /**
    * @if English
    * Called when the result of starting a digital avatar is returned.
    * @note
    * - call \ref IRtcEngine::EnableAvatar to get the result.
    * @param enable Start or stop a digital avatar.
    * @param errorCode result.    
    * @endif
    * @if Chinese
    * 虚拟人启动结果通知。
    * @note
    * - 调用 \ref IRtcEngine::EnableAvatar 的异步结果返回。
    * @param enable 启动或者结束虚拟人操作。
    * @param errorCode 操作结果。
    * @endif
    */
    public delegate void OnAvatarStatus(bool enable, RtcErrorCode errorCode);
    #endregion
    
    internal partial class RtcEngine
    {
        #region bind events
        private NativeEngineEnvent BindEvent(IntPtr nativeEngine)
        {
            return new NativeEngineEnvent{
                self = nativeEngine,
                onError = _onErrorHandler,
                onWarning = _onWarningHandler,
                onReleasedHwResources = _onReleasedHwResourcesHandler,
                onJoinChannel = _onJoinChannelHandler,
                onReconnectingStart = _onReconnectingStartHandler,
                onConnectionStateChange = _onConnectionStateChangeHandler,
                onNetworkTypeChanged = _onNetworkTypeChangedHandler,
                onRejoinChannel = _onRejoinChannelHandler,
                onLeaveChannel = _onLeaveChannelHandler,
                onDisconnect = _onDisconnectHandler,
                onClientRoleChanged = _onClientRoleChangedHandler,
                onUserJoined = _onUserJoinedHandler,
                onUserLeft = _onUserLeftHandler,
                onUserAudioStart = _onUserAudioStartHandler,
                onUserAudioStop = _onUserAudioStopHandler,
                onUserVideoStart = _onUserVideoStartHandler,
                onUserVideoStop = _onUserVideoStopHandler,
                onUserSubStreamVideoStart = _onUserSubStreamVideoStartHandler,
                onUserSubStreamVideoStop = _onUserSubStreamVideoStopHandler,
                onScreenCaptureStatusChanged = _onScreenCaptureStatusChangedHandler,
                onUserVideoProfileUpdate = _onUserVideoProfileUpdateHandler,
                onUserAudioMute = _onUserAudioMuteHandler,
                onUserVideoMute = _onUserVideoMuteHandler,
                onAudioDeviceRoutingDidChange = _onAudioDeviceRoutingDidChangeHandler,
                onAudioDeviceStateChanged = _onAudioDeviceStateChangedHandler,
                onAudioDefaultDeviceChanged = _onAudioDefaultDeviceChangedHandler,
                onVideoDeviceStateChanged = _onVideoDeviceStateChangedHandler,
                onCameraFocusChanged = _onCameraFocusChangedHandler,
                onCameraExposureChanged = _onCameraExposureChangedHandler,
                onFirstAudioDataReceived = _onFirstAudioDataReceivedHandler,
                onFirstVideoDataReceived = _onFirstVideoDataReceivedHandler,
                onFirstAudioFrameDecoded = _onFirstAudioFrameDecodedHandler,
                onFirstVideoFrameDecoded = _onFirstVideoFrameDecodedHandler,
                onCaptureVideoFrame = _onCaptureVideoFrameHandler,
                onAudioMixingStateChanged = _onAudioMixingStateChangedHandler,
                onAudioMixingTimestampUpdate = _onAudioMixingTimestampUpdateHandler,
                onAudioEffectFinished = _onAudioEffectFinishedHandler,
                onLocalAudioVolumeIndication = _onLocalAudioVolumeIndicationHandler,
                onRemoteAudioVolumeIndication = _onRemoteAudioVolumeIndicationHandler,
                onAddLiveStreamTask = _onAddLiveStreamTaskHandler,
                onUpdateLiveStreamTask = _onUpdateLiveStreamTaskHandler,
                onRemoveLiveStreamTask = _onRemoveLiveStreamTaskHandler,
                onLiveStreamStateChanged = _onLiveStreamStateChangedHandler,
                onAudioHowling = _onAudioHowlingHandler,
                onRecvSEIMessage = _onRecvSEIMessageHandler,
                onAudioRecording = _onAudioRecordingHandler,
                onMediaRelayStateChanged = _onMediaRelayStateChangedHandler,
                onMediaRelayEvent = _onMediaRelayEventHandler,
                onPublishFallbackToAudioOnly = _onPublishFallbackToAudioOnlyHandler,
                onSubscribeFallbackToAudioOnly = _onSubscribeFallbackToAudioOnlyHandler,
                onLastmileQuality = _onLastmileQualityHandler,
                onLastmileProbeResult = _onLastmileProbeResultHandler,
                onAvatarUserJoined = _onAvatarUserJoinedHandler,
                onAvatarUserLeft = _onAvatarUserLeftHandler,
                onAvatarStatus = _onAvatarStatusHandler,
            };
        }
        #endregion
        #region Engine Events

        static onError _onErrorHandler = OnErrorHandler;
        [MonoPInvokeCallback(typeof(onError))]
        static void OnErrorHandler(IntPtr self, int error_code, string msg)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnError?.Invoke(error_code, msg);
        }

        static onWarning _onWarningHandler = OnWarningHandler;
        [MonoPInvokeCallback(typeof(onWarning))]
        static void OnWarningHandler(IntPtr self, int warn_code, string msg)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnWarning?.Invoke(warn_code, msg);
        }

        static onReleasedHwResources _onReleasedHwResourcesHandler = OnReleasedHwResourcesHandler;
        [MonoPInvokeCallback(typeof(onReleasedHwResources))]
        static void OnReleasedHwResourcesHandler(IntPtr self, int result)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnReleasedHwResources?.Invoke((RtcErrorCode)result);
        }

        static onJoinChannel _onJoinChannelHandler = OnJoinChannelHandler;
        [MonoPInvokeCallback(typeof(onJoinChannel))]
        static void OnJoinChannelHandler(IntPtr self, ulong cid, ulong uid, int result, ulong elapsed)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnJoinChannel?.Invoke(cid,uid,(RtcErrorCode)result, elapsed);
        }

        static onReconnectingStart _onReconnectingStartHandler = OnReconnectingStartHandler;
        [MonoPInvokeCallback(typeof(onReconnectingStart))]
        static void OnReconnectingStartHandler(IntPtr self, ulong cid, ulong uid)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnReconnectingStart?.Invoke(cid, uid);
        }

        static onConnectionStateChange _onConnectionStateChangeHandler = OnConnectionStateChangeHandler;
        [MonoPInvokeCallback(typeof(onConnectionStateChange))]
        static void OnConnectionStateChangeHandler(IntPtr self, int state, int reason)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnConnectionStateChange?.Invoke((RtcConnectionStateType)state, (RtcReasonConnectionChangedType)reason);
        }

        static onNetworkTypeChanged _onNetworkTypeChangedHandler = OnNetworkTypeChangedHandler;
        [MonoPInvokeCallback(typeof(onNetworkTypeChanged))]
        static void OnNetworkTypeChangedHandler(IntPtr self, int new_type)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnNetworkTypeChanged?.Invoke((RtcNetworkType)new_type);
        }
        static onRejoinChannel _onRejoinChannelHandler = OnRejoinChannelHandler;

        [MonoPInvokeCallback(typeof(onRejoinChannel))]
        static void OnRejoinChannelHandler(IntPtr self, ulong cid, ulong uid, int result, ulong elapsed)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnRejoinChannel?.Invoke(cid, uid, (RtcErrorCode)result, elapsed);
        }

        static onLeaveChannel _onLeaveChannelHandler = OnLeaveChannelHandler;
        [MonoPInvokeCallback(typeof(onLeaveChannel))]
        static void OnLeaveChannelHandler(IntPtr self, int result)
        {
            var rtcEngine = GetEngineFromNative(self);

            rtcEngine?.OnLeaveChannel?.Invoke((RtcErrorCode)result);
            rtcEngine?.VideoRawDataManager?.RemoveAllRemoteCanvas();
        }

        static onDisconnect _onDisconnectHandler = OnDisconnectHandler;
        [MonoPInvokeCallback(typeof(onDisconnect))]
        static void OnDisconnectHandler(IntPtr self, int reason)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnDisconnect?.Invoke((RtcErrorCode)reason);
            rtcEngine?.VideoRawDataManager?.RemoveAllRemoteCanvas();
        }

        static onClientRoleChanged _onClientRoleChangedHandler = OnClientRoleChangedHandler;
        [MonoPInvokeCallback(typeof(onClientRoleChanged))]
        static void OnClientRoleChangedHandler(IntPtr self, int oldRole, int newRole)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnClientRoleChanged?.Invoke((RtcClientRole)oldRole, (RtcClientRole)newRole);
        }

        static onUserJoined _onUserJoinedHandler = OnUserJoinedHandler;
        [MonoPInvokeCallback(typeof(onUserJoined))]
        static void OnUserJoinedHandler(IntPtr self, ulong uid, string user_name)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnUserJoined?.Invoke(uid, user_name);
        }

        static onUserLeft _onUserLeftHandler = OnUserLeftHandler;
        [MonoPInvokeCallback(typeof(onUserLeft))]
        static void OnUserLeftHandler(IntPtr self, ulong uid, int reason)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnUserLeft?.Invoke(uid, (RtcSessionLeaveReason)reason);
        }

        static onUserAudioStart _onUserAudioStartHandler = OnUserAudioStartHandler;
        [MonoPInvokeCallback(typeof(onUserAudioStart))]
        static void OnUserAudioStartHandler(IntPtr self, ulong uid)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnUserAudioStart?.Invoke(uid);
        }

        static onUserAudioStop _onUserAudioStopHandler = OnUserAudioStopHandler;
        [MonoPInvokeCallback(typeof(onUserAudioStop))]
        static void OnUserAudioStopHandler(IntPtr self, ulong uid)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnUserAudioStop?.Invoke(uid);
        }

        static onUserVideoStart _onUserVideoStartHandler = OnUserVideoStartHandler;
        [MonoPInvokeCallback(typeof(onUserVideoStart))]
        static void OnUserVideoStartHandler(IntPtr self, ulong uid, int max_profile)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnUserVideoStart?.Invoke(uid, (RtcVideoProfileType)max_profile);
        }

        static onUserVideoStop _onUserVideoStopHandler = OnUserVideoStopHandler;
        [MonoPInvokeCallback(typeof(onUserVideoStop))]
        static void OnUserVideoStopHandler(IntPtr self, ulong uid)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnUserVideoStop?.Invoke(uid);
        }

        static onUserSubStreamVideoStart _onUserSubStreamVideoStartHandler = OnUserSubStreamVideoStartHandler;
        [MonoPInvokeCallback(typeof(onUserSubStreamVideoStart))]
        static void OnUserSubStreamVideoStartHandler(IntPtr self, ulong uid, int max_profile)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnUserSubStreamVideoStart?.Invoke(uid,(RtcVideoProfileType)max_profile);
        }

        static onUserSubStreamVideoStop _onUserSubStreamVideoStopHandler = OnUserSubStreamVideoStopHandler;
        [MonoPInvokeCallback(typeof(onUserSubStreamVideoStop))]
        static void OnUserSubStreamVideoStopHandler(IntPtr self, ulong uid)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnUserSubStreamVideoStop?.Invoke(uid);
        }

        static onScreenCaptureStatusChanged _onScreenCaptureStatusChangedHandler = OnScreenCaptureStatusChangedHandler;
        [MonoPInvokeCallback(typeof(onScreenCaptureStatusChanged))]
        static void OnScreenCaptureStatusChangedHandler(IntPtr self, int status)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnScreenCaptureStatusChanged?.Invoke((RtcScreenCaptureStatus)status);
        }

        static onUserVideoProfileUpdate _onUserVideoProfileUpdateHandler = OnUserVideoProfileUpdateHandler;
        [MonoPInvokeCallback(typeof(onUserVideoProfileUpdate))]
        static void OnUserVideoProfileUpdateHandler(IntPtr self, ulong uid, int max_profile)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnUserVideoProfileUpdate?.Invoke(uid, (RtcVideoProfileType)max_profile);
        }
        
        static onUserAudioMute _onUserAudioMuteHandler = OnUserAudioMuteHandler;
        [MonoPInvokeCallback(typeof(onUserAudioMute))]
        static void OnUserAudioMuteHandler(IntPtr self, ulong uid, bool mute)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnUserAudioMute?.Invoke(uid, mute);
        }


        static onUserVideoMute _onUserVideoMuteHandler = OnUserVideoMuteHandler;
        [MonoPInvokeCallback(typeof(onUserVideoMute))]
        static void OnUserVideoMuteHandler(IntPtr self, ulong uid, bool mute)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnUserVideoMute?.Invoke(uid, mute);
        }


        static onAudioDeviceRoutingDidChange _onAudioDeviceRoutingDidChangeHandler = OnAudioDeviceRoutingDidChangeHandler;
        [MonoPInvokeCallback(typeof(onAudioDeviceRoutingDidChange))]
        static void OnAudioDeviceRoutingDidChangeHandler(IntPtr self, int routing)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnAudioDeviceRoutingDidChange?.Invoke((RtcAudioOutputRouting)routing);
        }

        static onAudioDeviceStateChanged _onAudioDeviceStateChangedHandler = OnAudioDeviceStateChangedHandler;
        [MonoPInvokeCallback(typeof(onAudioDeviceStateChanged))]
        static void OnAudioDeviceStateChangedHandler(IntPtr self, string device_id, int device_type, int device_state)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnAudioDeviceStateChanged?.Invoke(device_id,(RtcAudioDeviceType)device_type,(RtcAudioDeviceState)device_state);
        }

        static onAudioDefaultDeviceChanged _onAudioDefaultDeviceChangedHandler = OnAudioDefaultDeviceChangedHandler;
        [MonoPInvokeCallback(typeof(onAudioDefaultDeviceChanged))]
        static void OnAudioDefaultDeviceChangedHandler(IntPtr self, string device_id, int device_type)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnAudioDefaultDeviceChanged?.Invoke(device_id, (RtcAudioDeviceType)device_type);
        }

        static onVideoDeviceStateChanged _onVideoDeviceStateChangedHandler = OnVideoDeviceStateChangedHandler;
        [MonoPInvokeCallback(typeof(onVideoDeviceStateChanged))]
        static void OnVideoDeviceStateChangedHandler(IntPtr self, string device_id, int device_type, int device_state)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnVideoDeviceStateChanged?.Invoke(device_id, (RtcVideoDeviceType)device_type, (RtcVideoDeviceState)device_state);
        }

        static onCameraFocusChanged _onCameraFocusChangedHandler = OnCameraFocusChangedHandler;
        [MonoPInvokeCallback(typeof(onCameraFocusChanged))]
        static void OnCameraFocusChangedHandler(IntPtr self, IntPtr info)
        {
            var rtcEngine = GetEngineFromNative(self);

            var rtcInfo = Marshal.PtrToStructure<RtcCameraFocusAndExposureInfo>(info);
            rtcEngine?.OnCameraFocusChanged?.Invoke(rtcInfo);
        }

        static onCameraExposureChanged _onCameraExposureChangedHandler = OnCameraExposureChangedHandler;
        [MonoPInvokeCallback(typeof(onCameraExposureChanged))]
        static void OnCameraExposureChangedHandler(IntPtr self, IntPtr info)
        {
            var rtcEngine = GetEngineFromNative(self);
            var rtcInfo = Marshal.PtrToStructure<RtcCameraFocusAndExposureInfo>(info);
            rtcEngine?.OnCameraExposureChanged?.Invoke(rtcInfo);
        }

        static onFirstAudioDataReceived _onFirstAudioDataReceivedHandler = OnFirstAudioDataReceivedHandler;
        [MonoPInvokeCallback(typeof(onFirstAudioDataReceived))]
        static void OnFirstAudioDataReceivedHandler(IntPtr self, ulong uid)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnFirstAudioDataReceived?.Invoke(uid);
        }

        static onFirstVideoDataReceived _onFirstVideoDataReceivedHandler = OnFirstVideoDataReceivedHandler;
        [MonoPInvokeCallback(typeof(onFirstVideoDataReceived))]
        static void OnFirstVideoDataReceivedHandler(IntPtr self, ulong uid)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnFirstVideoDataReceived?.Invoke(uid);
        }

        static onFirstAudioFrameDecoded _onFirstAudioFrameDecodedHandler = OnFirstAudioFrameDecodedHandler;
        [MonoPInvokeCallback(typeof(onFirstAudioFrameDecoded))]
        static void OnFirstAudioFrameDecodedHandler(IntPtr self, ulong uid)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnFirstAudioFrameDecoded?.Invoke(uid);
        }

        static onFirstVideoFrameDecoded _onFirstVideoFrameDecodedHandler = OnFirstVideoFrameDecodedHandler;
        [MonoPInvokeCallback(typeof(onFirstVideoFrameDecoded))]
        static void OnFirstVideoFrameDecodedHandler(IntPtr self, ulong uid, uint width, uint height)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnFirstVideoFrameDecoded?.Invoke(uid,width,height);
        }

        static onCaptureVideoFrame _onCaptureVideoFrameHandler = OnCaptureVideoFrameHandler;
        [MonoPInvokeCallback(typeof(onCaptureVideoFrame))]
        static void OnCaptureVideoFrameHandler(IntPtr self, IntPtr data, int type, uint width, uint height, uint count, IntPtr offset, IntPtr stride, int rotation)
        {
            var rtcEngine = GetEngineFromNative(self);
            uint[] offsets = null, strides = null;
            if(count > 0)
            {
                offsets = new uint[count];
                strides = new uint[count];

                Marshal.Copy(offset, (int[])(object)offsets, 0, (int)count);
                Marshal.Copy(stride, (int[])(object)strides, 0, (int)count);
            }
            rtcEngine?.OnCaptureVideoFrame?.Invoke(data, (RtcVideoType)type, width, height, count, offsets, strides, (RtcVideoRotation)rotation);
        }

        static onAudioMixingStateChanged _onAudioMixingStateChangedHandler = OnAudioMixingStateChangedHandler;
        [MonoPInvokeCallback(typeof(onAudioMixingStateChanged))]
        static void OnAudioMixingStateChangedHandler(IntPtr self, int state, int error_code)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnAudioMixingStateChanged?.Invoke((RtcAudioMixingState)state, (RtcAudioMixingErrorCode)error_code);
        }

        static onAudioMixingTimestampUpdate _onAudioMixingTimestampUpdateHandler = OnAudioMixingTimestampUpdateHandler;
        [MonoPInvokeCallback(typeof(onAudioMixingTimestampUpdate))]
        static void OnAudioMixingTimestampUpdateHandler(IntPtr self, ulong timestamp_ms)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnAudioMixingTimestampUpdate?.Invoke(timestamp_ms);
        }

        static onAudioEffectFinished _onAudioEffectFinishedHandler = OnAudioEffectFinishedHandler;
        [MonoPInvokeCallback(typeof(onAudioEffectFinished))]
        static void OnAudioEffectFinishedHandler(IntPtr self, uint effect_id)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnAudioEffectFinished?.Invoke(effect_id);
        }

        static onLocalAudioVolumeIndication _onLocalAudioVolumeIndicationHandler = OnLocalAudioVolumeIndicationHandler;
        [MonoPInvokeCallback(typeof(onLocalAudioVolumeIndication))]
        static void OnLocalAudioVolumeIndicationHandler(IntPtr self, int volume)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnLocalAudioVolumeIndication?.Invoke(volume);
        }

        static onRemoteAudioVolumeIndication _onRemoteAudioVolumeIndicationHandler = OnRemoteAudioVolumeIndicationHandler;
        [MonoPInvokeCallback(typeof(onRemoteAudioVolumeIndication))]
        static void OnRemoteAudioVolumeIndicationHandler(IntPtr self, IntPtr speakers, uint speaker_number, int total_volume)
        {
            var rtcEngine = GetEngineFromNative(self);

            var rtcSpeakers = MarshalExtension.PtrToStructureArray<RtcAudioVolumeInfo>(speakers, speaker_number);
            rtcEngine?.OnRemoteAudioVolumeIndication?.Invoke(rtcSpeakers, total_volume);
        }

        static onAddLiveStreamTask _onAddLiveStreamTaskHandler = OnAddLiveStreamTaskHandler;
        [MonoPInvokeCallback(typeof(onAddLiveStreamTask))]
        static void OnAddLiveStreamTaskHandler(IntPtr self, string task_id, string url, int error_code)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnAddLiveStreamTask?.Invoke(task_id, url,error_code);
        }

        static onUpdateLiveStreamTask _onUpdateLiveStreamTaskHandler = OnUpdateLiveStreamTaskHandler;
        [MonoPInvokeCallback(typeof(onUpdateLiveStreamTask))]
        static void OnUpdateLiveStreamTaskHandler(IntPtr self, string task_id, string url, int error_code)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnUpdateLiveStreamTask?.Invoke(task_id, url, error_code);
        }

        static onRemoveLiveStreamTask _onRemoveLiveStreamTaskHandler = OnRemoveLiveStreamTaskHandler;
        [MonoPInvokeCallback(typeof(onRemoveLiveStreamTask))]
        static void OnRemoveLiveStreamTaskHandler(IntPtr self, string task_id, int error_code)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnRemoveLiveStreamTask?.Invoke(task_id, error_code);
        }

        static onLiveStreamStateChanged _onLiveStreamStateChangedHandler = OnLiveStreamStateChangedHandler;
        [MonoPInvokeCallback(typeof(onLiveStreamStateChanged))]
        static void OnLiveStreamStateChangedHandler(IntPtr self, string task_id, string url, int state)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnLiveStreamStateChanged?.Invoke(task_id, url,(RtcLiveStreamStateCode)state);
        }

        static onAudioHowling _onAudioHowlingHandler = OnAudioHowlingHandler;
        [MonoPInvokeCallback(typeof(onAudioHowling))]
        static void OnAudioHowlingHandler(IntPtr self, bool howling)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnAudioHowling?.Invoke(howling);
        }

        static onRecvSEIMessage _onRecvSEIMessageHandler = OnRecvSEIMessageHandler;
        [MonoPInvokeCallback(typeof(onRecvSEIMessage))]
        static void OnRecvSEIMessageHandler(IntPtr self, ulong uid, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]byte[] data, uint dataSize)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnRecvSEIMessage?.Invoke(uid,data,dataSize);
        }

        static onAudioRecording _onAudioRecordingHandler = OnAudioRecordingHandler;
        [MonoPInvokeCallback(typeof(onAudioRecording))]
        static void OnAudioRecordingHandler(IntPtr self, int code, string file_path)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnAudioRecording?.Invoke((RtcAudioRecordingCode)code, file_path);
        }

        static onMediaRelayStateChanged _onMediaRelayStateChangedHandler = OnMediaRelayStateChangedHandler;
        [MonoPInvokeCallback(typeof(onMediaRelayStateChanged))]
        static void OnMediaRelayStateChangedHandler(IntPtr self, int state, string channel_name)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnMediaRelayStateChanged?.Invoke((RtcChannelMediaRelayState)state, channel_name);
        }

        static onMediaRelayEvent _onMediaRelayEventHandler = OnMediaRelayEventHandler;
        [MonoPInvokeCallback(typeof(onMediaRelayEvent))]
        static void OnMediaRelayEventHandler(IntPtr self, int evt, string channel_name, int error)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnMediaRelayEvent?.Invoke((RtcChannelMediaRelayEvent)evt, channel_name,(RtcErrorCode)error);
        }

        static onPublishFallbackToAudioOnly _onPublishFallbackToAudioOnlyHandler = OnPublishFallbackToAudioOnlyHandler;
        [MonoPInvokeCallback(typeof(onPublishFallbackToAudioOnly))]
        static void OnPublishFallbackToAudioOnlyHandler(IntPtr self, bool is_fallback, int stream_type)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnPublishFallbackToAudioOnly?.Invoke(is_fallback, (RtcVideoStreamType)stream_type);
        }

        static onSubscribeFallbackToAudioOnly _onSubscribeFallbackToAudioOnlyHandler = OnSubscribeFallbackToAudioOnlyHandler;
        [MonoPInvokeCallback(typeof(onSubscribeFallbackToAudioOnly))]
        static void OnSubscribeFallbackToAudioOnlyHandler(IntPtr self, ulong uid, bool is_fallback, int stream_type)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnSubscribeFallbackToAudioOnly?.Invoke(uid,is_fallback, (RtcVideoStreamType)stream_type);
        }

        static onLastmileQuality _onLastmileQualityHandler = OnLastmileQualityHandler;
        [MonoPInvokeCallback(typeof(onLastmileQuality))]
        static void OnLastmileQualityHandler(IntPtr self, int quality)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnLastmileQuality?.Invoke((RtcNetworkQualityType)quality);
        }

        static onLastmileProbeResult _onLastmileProbeResultHandler = OnLastmileProbeResultHandler;
        [MonoPInvokeCallback(typeof(onLastmileProbeResult))]
        static void OnLastmileProbeResultHandler(IntPtr self, IntPtr result)
        {
            var rtcEngine = GetEngineFromNative(self);

            var probeResult = Marshal.PtrToStructure<RtcLastmileProbeResult>(result);
            rtcEngine?.OnLastmileProbeResult?.Invoke(probeResult);
        }

        static onAvatarUserJoined _onAvatarUserJoinedHandler = OnAvatarUserJoinedHandler;
        [MonoPInvokeCallback(typeof(onAvatarUserJoined))]
        static void OnAvatarUserJoinedHandler(IntPtr self, ulong src_uid, ulong uid, string user_name)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnAvatarUserJoined?.Invoke(src_uid, uid, user_name);
        }

        static onAvatarUserLeft _onAvatarUserLeftHandler = OnAvatarUserLeftHandler;
        [MonoPInvokeCallback(typeof(onAvatarUserLeft))]
        static void OnAvatarUserLeftHandler(IntPtr self, ulong src_uid, ulong uid, int reason)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnAvatarUserLeft?.Invoke(src_uid, uid, (RtcSessionLeaveReason)reason);
        }

        static onAvatarStatus _onAvatarStatusHandler = OnAvatarStatusHandler;
        [MonoPInvokeCallback(typeof(onAvatarStatus))]
        static void OnAvatarStatusHandler(IntPtr self, bool enable, int error_code)
        {
            var rtcEngine = GetEngineFromNative(self);
            rtcEngine?.OnAvatarStatus?.Invoke(enable, (RtcErrorCode)error_code);
        }
        #endregion
    }
}
