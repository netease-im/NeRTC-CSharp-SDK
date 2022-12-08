using System;
using System.Runtime.InteropServices;

namespace nertc
{
    #region Channel Events
    /**
     * @if English
     * Occurs when the error occurs.
     * <br>The callback is triggered to report an error related to network or media during SDK runtime. In most cases, the SDK
     * cannot fix the issue and resume running. The SDK requires the app to take action or informs the user of the issue.
     * @param channel   The current IRtcChannel object
     * @param errorCode    The error code. For more information, see #RtcErrorCode.
     * @param msg           Error description.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 发生错误回调。
     * <br>该回调方法表示 SDK 运行时出现了（网络或媒体相关的）错误。通常情况下，SDK上报的错误意味着SDK无法自动恢复，需要 App
     * 干预或提示用户。
     * @param channel   当前 IRtcChannel 对象
     * @param errorCode    错误码。详细信息请参考 #RtcErrorCode
     * @param msg           错误描述。
     * @endif
     */
    public delegate void ChannelOnError(IRtcChannel channel,int errorCode, string msg);
    /**
     * @if English
     * Occurs when a warning occurs.
     * <br>The callback is triggered to report a warning related to network or media during SDK runtime. In most cases, the app
     * ignores the warning message and the SDK resumes running.
     * @param channel   The current IRtcChannel object
     * @param warnCode     The warning code. For more information, see {@link RtcWarnCode}.
     * @param msg           The warning description.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 发生警告回调。
     * <br>该回调方法表示 SDK 运行时出现了（网络或媒体相关的）警告。通常情况下，SDK 上报的警告信息 App 可以忽略，SDK 会自动恢复。
     * @param channel   当前 IRtcChannel 对象
     * @param warnCode     警告码。详细信息请参考 {@link RtcWarnCode}。
     * @param msg           警告描述。
     * @endif
     */
    public delegate void ChannelOnWarning(IRtcChannel channel, int warnCode, string msg);
    /**
    * @if English
    * Occurs when the hardware resources are released.
    * <br>The SDK prompts whether hardware resources are successfully released.
    * @param channel   The current IRtcChannel object
    * @param result    The result.
    * @endif
    * @if Chinese
    * 释放硬件资源的回调。
    * <br>SDK提示释放硬件资源是否成功。
    * @param channel   当前 IRtcChannel 对象
    * @param result    返回结果。
    * @endif
    */
    public delegate void ChannelOnReleasedHwResources(IRtcChannel channel, RtcErrorCode result);
    /**
    * @if English
    * Allows a user to join a room. The callback indicates that the client has already signed in.
    * @param cid     The ID of the room that the client joins.
    * @param uid     Specifies the ID of a user. If you specify the uid in the joinChannel method, a specificed ID is returned at
    * the time. If not, the  ID automatically assigned by the CommsEase’s server is returned.
    * @param channel   The current IRtcChannel object
    * @param result  Indicates the result.
    * @param elapsed The time elapsed from calling the joinChannel method to the occurrence of this event. Unit: milliseconds.
    * @endif
    * @if Chinese
    * 加入房间回调，表示客户端已经登入服务器。
    * @param channel   当前 IRtcChannel 对象
    * @param cid     客户端加入的房间 ID。
    * @param uid     用户 ID。 如果在 \ref IRtcChannel::JoinChannel 方法中指定了 uid，此处会返回指定的 ID; 如果未指定
    * uid，此处将返回云信服务器自动分配的 ID。
    * @param result  返回结果。
    * @param elapsed 从 \ref IRtcChannel::JoinChannel 开始到发生此事件过去的时间，单位为毫秒。
    * @endif
    */
    public delegate void ChannelOnJoinChannel(IRtcChannel channel, ulong cid, ulong uid, RtcErrorCode result, ulong elapsed);
    /**
     * @if English
     * Triggers reconnection.
     * <br>In some cases, a client may be disconnected from the server, the SDK starts reconnecting. The callback is triggered
     * when the reconnection starts.
     * @param channel   The current IRtcChannel object
     * @param cid Specifies the ID of a room.
     * @param uid Specifies the ID of a user.
     * @endif
     * @if Chinese
     * 触发重连。
     * <br>有时候由于网络原因，客户端可能会和服务器失去连接，SDK会进行自动重连，开始自动重连后触发此回调。
     * @param channel   当前 IRtcChannel 对象
     * @param cid  房间 ID。
     * @param uid  用户 ID。
     * @endif
     */
    public delegate void ChannelOnReconnectingStart(IRtcChannel channel, ulong cid, ulong uid);
    /**
     * @if English
     * Occurs when the state of network connection is changed.
     * <br>The callback is triggered when the state of network connection is changed. The callback returns the current state of
     * network connection and the reason why the network state changes.
     * @param channel   The current IRtcChannel object
     * @param state     The state of current network connection.
     * @param reason    The reason why the network state changes.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 网络连接状态已改变回调。
     * <br>该回调在网络连接状态发生改变的时候触发，并告知用户当前的网络连接状态和引起网络状态改变的原因。
     * @param channel   当前 IRtcChannel 对象
     * @param state     当前的网络连接状态。
     * @param reason    引起当前网络连接状态发生改变的原因。
     * @endif
     */
    public delegate void ChannelOnConnectionStateChange(IRtcChannel channel, RtcConnectionStateType state, RtcReasonConnectionChangedType reason);
    /**
     * @if English
     * Occurs when a user rejoins a room.
     * <br>If a client is disconnected from the server due to poor network quality, the SDK starts reconnecting. If the client and
     * server are reconnected, the callback is triggered.
     * @param channel   The current IRtcChannel object
     * @param cid       The ID of the room that the client joins.
     * @param uid       The ID of a user.
     * @param result    The result.
     * @param elapsed   The time elapsed from reconnection to the occurrence of this event. Unit: milliseconds.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 重新加入房间回调。
     * <br>在弱网环境下，若客户端和服务器失去连接，SDK会自动重连。自动重连成功后触发此回调方法。
     * @param channel   当前 IRtcChannel 对象
     * @param cid       客户端加入的房间 ID。
     * @param uid       用户 ID。
     * @param result    返回结果。
     * @param elapsed   从开始重连到发生此事件过去的时间，单位为毫秒。
     * @endif
     */
    public delegate void ChannelOnRejoinChannel(IRtcChannel channel, ulong cid, ulong uid, RtcErrorCode result, ulong elapsed);
    /**
     * @if English
     * Occurs when a user leaves a room.
     * <br>After an app invokes the \ref IRtcChannel::LeaveChannel method, SDK prompts whether the app successfully leaves the room.
     * @param channel   The current IRtcChannel object
     * @param result    The result.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 退出房间回调。
     * <br>App 调用 \ref IRtcChannel::LeaveChannel 方法后，SDK 提示 App 退出房间是否成功。
     * @param channel   当前 IRtcChannel 对象
     * @param result    返回结果。
     * @endif
     */
    public delegate void ChannelOnLeaveChannel(IRtcChannel channel, RtcErrorCode result);
    /**
     * @if English
     * Network connection interruption.
     * @note
     * - The callback is triggered if the SDK fails to connect to the server three consecutive times after you successfully call
     * the \ref IRtcChannel::JoinChannel method.
     * - A client may be disconnected from the server in poor network connection. At this time,  the SDK needs not automatically
     * reconnecting until the SDK triggers the callback method.
     * @param channel   The current IRtcChannel object
     * @param reason    The reason why the network is disconnected.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 网络连接中断
     * @note
     * - SDK 在调用 \ref IRtcChannel::JoinChannel 加入房间成功后，如果和服务器失去连接且连续 3 次重连失败，就会触发该回调。
     * - 由于非网络原因，客户端可能会和服务器失去连接，此时SDK无需自动重连，直接触发此回调方法。
     * @param channel   当前 IRtcChannel 对象
     * @param reason    网络连接中断原因。
     * @endif
     */
    public delegate void ChannelOnDisconnect(IRtcChannel channel, RtcErrorCode reason);
    /**
     * @if English
     * Occurs when a user changes the role in live streaming.
     * <br>After the local user joins a room, the user can call the \ref IRtcChannel::SetClientRole to change the
     * role. Then, the callback is triggered. For example, you can switch the role from host to audience, or from audience to
     * host.
     * @note In live streaming, if you join a room and successfully call this method to change the role, the following callbacks
     * are triggered.
     * - If the role changes from host to audience, the \ref nertc::ChannelOnClientRoleChanged "ChannelOnClientRoleChanged" is locally triggered, and the 
     * \ref nertc::ChannelOnUserLeft "ChannelOnUserLeft" is remotely triggered.
     * - If the role is changed from audience to host, the \ref nertc::ChannelOnClientRoleChanged "ChannelOnClientRoleChanged" callback is locally triggered, and the
     * \ref nertc::ChannelOnUserJoined "ChannelOnUserJoined" is remotely triggered.
     * @param channel   The current IRtcChannel object
     * @param oldRole  The role before the user changes the role.
     * @param newRole  The role after the change.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 直播场景下用户角色已切换回调。
     * <br>本地用户加入房间后，通过 \ref IRtcChannel::SetClientRole 切换用户角色后会触发此回调。例如主播切换为观众、从观众切换为主播。
     * @note 直播场景下，如果您在加入房间后调用该方法切换用户角色，调用成功后，会触发以下回调：
     * - 主播切观众，本端触发 \ref nertc::ChannelOnClientRoleChanged "ChannelOnClientRoleChanged" 回调，远端触发 \ref nertc::ChannelOnUserLeft "ChannelOnUserLeft" 回调。
     * - 观众切主播，本端触发 \ref nertc::ChannelOnClientRoleChanged "ChannelOnClientRoleChanged" 回调，远端触发 \ref nertc::ChannelOnUserJoined "ChannelOnUserJoined" 回调。
     * @param channel   当前 IRtcChannel 对象
     * @param oldRole  切换前的角色。
     * @param newRole  切换后的角色。
     * @endif
     */
    public delegate void ChannelOnClientRoleChanged(IRtcChannel channel, RtcClientRole oldRole, RtcClientRole newRole);
    /**
     * @if English
     * Occurs when a remote user joins the current room.
     * <br>The callback prompts that a remote user joins the room and returns the ID of the user that joins the room. If the user
     * ID already exists, the remote user also receives a message that the user already joins the room, which is returned by the
     * callback.
     * @param channel   The current IRtcChannel object
     * @param uid           The ID of the user that joins the room.
     * @param userName     The name of the remote user who joins the room.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 远端用户加入当前房间回调。
     * <br>该回调提示有远端用户加入了房间，并返回新加入用户的
     * ID；如果加入之前，已经有其他用户在房间中了，新加入的用户也会收到这些已有用户加入房间的回调。
     * @param channel   当前 IRtcChannel 对象
     * @param uid           新加入房间的远端用户 ID。
     * @param userName     新加入房间的远端用户名。
     * @endif
     */
    public delegate void ChannelOnUserJoined(IRtcChannel channel, ulong uid, string userName);
    /**
     * @if English
     * Occurs when a remote user leaves a room.
     * <br>A message is returned indicates that a remote user leaves the room or becomes disconnected. In most cases, a user
     * leaves a room due to the following reasons: The user exit the room or connections time out.
     * - When a user leaves a room, remote users will receive callback notifications that users leave the room. In this way, users
     * can be specified to leave the room.
     * - If the connection times out, and the user does not receive data packets for a time period of 40 to 50 seconds, then the
     * user becomes disconnected.
     * @param channel   The current IRtcChannel object
     * @param uid           The ID of the user that leaves the room.
     * @param reason        The reason why remote user leaves.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 远端用户离开当前房间的回调。
     * <br>提示有远端用户离开了房间（或掉线）。通常情况下，用户离开房间有两个原因，即正常离开和超时掉线：
     * - 正常离开的时候，远端用户会收到正常离开房间的回调提醒，判断用户离开房间。
     * - 超时掉线的依据是，在一定时间内（40~50s），用户没有收到对方的任何数据包，则判定为对方掉线。
     * @param channel   当前 IRtcChannel 对象
     * @param uid           离开房间的远端用户 ID。
     * @param reason        远端用户离开原因。
     * @endif
     */
    public delegate void ChannelOnUserLeft(IRtcChannel channel, ulong uid, RtcSessionLeaveReason reason);
    /**
     * @if English
     * Occurs when a remote user enables audio.
     * @param channel   The current IRtcChannel object
     * @param uid       The ID of a remote user.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 远端用户开启音频的回调。
     * @param channel   当前 IRtcChannel 对象
     * @param uid       远端用户ID。
     * @endif
     */
    public delegate void ChannelOnUserAudioStart(IRtcChannel channel, ulong uid);
    /**
     * @if English
     * Occurs when a remote user disables audio.
     * @param channel   The current IRtcChannel object
     * @param uid       The ID of a remote user.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 远端用户停用音频的回调。
     * @param channel   当前 IRtcChannel 对象
     * @param uid       远端用户ID。
     * @endif
     */
    public delegate void ChannelOnUserAudioStop(IRtcChannel channel, ulong uid);
    /**
     * @if English
     * Callbacks that specify whether to mute remote users.
     * @param channel   The current IRtcChannel object
     * @param uid       The ID of a remote user.
     * @param mute      Whether to unmute the remote user.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 远端用户是否静音的回调。
     * @param channel   当前 IRtcChannel 对象
     * @param uid       远端用户ID。
     * @param mute      是否静音。
     * @endif
     */
    public delegate void ChannelOnUserAudioMute(IRtcChannel channel, ulong uid, bool mute);
    /**
   * @if English
   * Occurs when a remote user enables video.
   * @param channel   The current IRtcChannel object
   * @param uid               The ID of a remote user.
   * @param maxProfile       The resolution of video encoding measures the encoding quality.
   * @since V4.5.0
   * @endif
   * @if Chinese
   * 远端用户开启视频的回调。
   * @param channel   当前 IRtcChannel 对象
   * @param uid               远端用户ID。
   * @param maxProfile       视频编码的分辨率，用于衡量编码质量。
   * @endif
   */
    public delegate void ChannelOnUserVideoStart(IRtcChannel channel, ulong uid, RtcVideoProfileType maxProfile);
    /**
     * @if English
     * Occurs when a remote user disables video.
     * @param channel   The current IRtcChannel object
     * @param uid       The ID of a remote user.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 远端用户停用视频的回调。
     * @param channel   当前 IRtcChannel 对象
     * @param uid       远端用户ID。
     * @endif
     */
    public delegate void ChannelOnUserVideoStop(IRtcChannel channel, ulong uid);
    /**
     * @if English
     * Occurs when a remote user stops or resumes sending video streams.
     * @param channel   The current IRtcChannel object
     * @param uid       The ID of a remote user.
     * @param mute      Whether to disable video streams.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 远端用户暂停或恢复发送视频流的回调。
     * @param channel   当前 IRtcChannel 对象
     * @param uid       远端用户ID。
     * @param mute      是否禁视频流。
     * @endif
     */
    public delegate void ChannelOnUserVideoMute(IRtcChannel channel, ulong uid, bool mute);
    /**
     * @if English
     * Occurs when a remote user enables screen sharing by using the substream.
     * @param channel   The current IRtcChannel object
     * @param uid           The ID of a remote user.
     * @param maxProfile   The largest resolution of the remote video.
     *
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 远端用户开启屏幕共享辅流通道的回调。
     * @param channel   当前 IRtcChannel 对象
     * @param uid           远端用户 ID。
     * @param maxProfile   最大分辨率。
     * @endif
     */
    public delegate void ChannelOnUserSubStreamVideoStart(IRtcChannel channel, ulong uid, RtcVideoProfileType maxProfile);
    /**
     * @if English
     * Occurs when a remote user stops screen sharing by using the substream.
     * @param channel   The current IRtcChannel object
     * @param uid           The ID of a remote user.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 远端用户停止屏幕共享辅流通道的回调。
     * @param channel   当前 IRtcChannel 对象
     * @param uid           远端用户ID。
     * @endif
     */
    public delegate void ChannelOnUserSubStreamVideoStop(IRtcChannel channel, ulong uid);
    /**
     * @if English
     * Occurs when screen sharing is paused/resumed/started/ended.
     * <br>The method applies to Windows only.
     * @param channel   The current IRtcChannel object
     * @param status The current state of screen sharing.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 屏幕共享状态变化回调。
     * <br>该方法仅适用于 Windows 平台。
     * @param channel   当前 IRtcChannel 对象
     * @param status  当前的屏幕共享状态
     * @since V4.5.0
     * @endif
     */
    public delegate void ChannelOnScreenCaptureStatusChanged(IRtcChannel channel, RtcScreenCaptureStatus status);
    /**
     * @if English
     * Occurs when the first audio frame from a remote user is received.
     * @param channel   The current IRtcChannel object
     * @param uid       The ID of a remote user whose audio streams are sent.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 已接收到远端音频首帧的回调。
     * @param channel   当前 IRtcChannel 对象
     * @param uid       远端用户 ID，指定是哪个用户的音频流。
     * @endif
     */
    public delegate void ChannelOnFirstAudioDataReceived(IRtcChannel channel, ulong uid);
    /**
     * @if English
     * Occurs when the first video frame from a remote user is displayed.
     * <br>If the first video frame from a remote user is displayed in the view, the callback is triggered.
     * @param channel   The current IRtcChannel object
     * @param uid       The ID of a user whose audio streams are sent.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 已显示首帧远端视频的回调。
     * 第一帧远端视频显示在视图上时，触发此调用。
     * @param channel   当前 IRtcChannel 对象
     * @param uid       用户 ID，指定是哪个用户的视频流。
     * @endif
     */
    public delegate void ChannelOnFirstVideoDataReceived(IRtcChannel channel, ulong uid);
    /**
     * @if English
     * Occurs when the first audio frame from a remote user is decoded.
     * @param channel   The current IRtcChannel object
     * @param uid       The ID of a remote user whose audio streams are sent.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 已解码远端音频首帧的回调。
     * @param channel   当前 IRtcChannel 对象
     * @param uid       远端用户 ID，指定是哪个用户的音频流。
     * @endif
     */
    public delegate void ChannelOnFirstAudioFrameDecoded(IRtcChannel channel, ulong uid);
    /**
     * @if English
     * Occurs when the remote video is received and decoded.
     * <br>If the engine receives the first frame of remote video streams, the callback is triggered.
     * @param channel   The current IRtcChannel object
     * @param uid       The ID of a user whose audio streams are sent.
     * @param width     The width of video streams (px).
     * @param height    The height of video streams(px).
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 已接收到远端视频并完成解码的回调。
     * <br>引擎收到第一帧远端视频流并解码成功时，触发此调用。
     * @param channel   当前 IRtcChannel 对象
     * @param uid       用户 ID，指定是哪个用户的视频流。
     * @param width     视频流宽（px）。
     * @param height    视频流高（px）。
     * @endif
     */
    public delegate void ChannelOnFirstVideoFrameDecoded(IRtcChannel channel, ulong uid, uint width, uint height);
    /**
     * @if English
     * Occurs when the system prompts current local audio volume.
     * - This callback is disabled by default. You can enable the callback by calling the \ref
     * IRtcEngine::EnableAudioVolumeIndication "EnableAudioVolumeIndication" method.
     * - After the callback is enabled, if a local user speaks, the SDK triggers the callback based on the time interval specified
     * in the \ref IRtcEngine::EnableAudioVolumeIndication "EnableAudioVolumeIndication" method.
     * - If a local user sets a mute by calling \ref IRtcChannel::MuteLocalAudioStream "MuteLocalAudioStream", the SDK sets the
     * value of volume as 0, and calls back to the application layer.
     * @param channel   The current IRtcChannel object
     * @param volume        The volume of audio mixing. Value range: 0 to 100.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 提示房间内本地用户瞬时音量的回调。
     * - 该回调默认禁用。可以通过 \ref IRtcEngine::EnableAudioVolumeIndication "EnableAudioVolumeIndication" 方法开启。
     * - 开启后，本地用户说话，SDK 会按  \ref IRtcEngine::EnableAudioVolumeIndication "EnableAudioVolumeIndication"
     * 方法中设置的时间间隔触发该回调。
     * - 如果本地用户将自己静音（调用了 \ref IRtcChannel::MuteLocalAudioStream "MuteLocalAudioStream"），SDK 将音量设置为 0
     * 后回调给应用层。
     * @param channel   当前 IRtcChannel 对象
     * @param volume        （混音后的）音量，取值范围为 [0,100]。
     * @endif
     */
    public delegate void ChannelOnLocalAudioVolumeIndication(IRtcChannel channel, int volume);
    /**
     * @if English
     * Occurs when the system prompts the active speaker and the audio volume.
     * <br>By default, the callback is disabled. You can enable the callback by calling the \ref IRtcEngine::EnableAudioVolumeIndication "EnableAudioVolumeIndication" method.
     * After the callback is enabled, if a local user speaks, the SDK triggers the callback based on the time interval specified
     * in the \ref IRtcEngine::EnableAudioVolumeIndication "EnableAudioVolumeIndication" method. <br>In the array of speakers returned:
     * - If a uid is contained in the array returned in the last response but not in the array returned in the current response.
     * The remote user with the uid does not speak by default.
     * - If the volume is 0, the user does not speak.
     * - If the array is empty, the remote user does not speak.
     * @param channel   The current IRtcChannel object
     * @param speakers              The array that contains the information about user IDs and volumes is {@link RtcAudioVolumeInfo}.
     * @param totalVolume          The total volume (after audio mixing). Value range: 0 to 100.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 提示房间内谁正在说话及说话者瞬时音量的回调。
     * <br>该回调默认为关闭状态。可以通过 \ref IRtcEngine::EnableAudioVolumeIndication "EnableAudioVolumeIndication" 方法开启。开启后，无论房间内是否有人说话，SDK 都会按
     * \ref IRtcEngine::EnableAudioVolumeIndication "EnableAudioVolumeIndication" 方法中设置的时间间隔触发该回调。 <br>在返回的 speakers 数组中:
     * - 如果有 uid 出现在上次返回的数组中，但不在本次返回的数组中，则默认该 uid 对应的远端用户没有说话。
     * - 如果volume 为 0，表示该用户没有说话。
     *  - 如果speakers 数组为空，则表示此时远端没有人说话。
     * @param channel   当前 IRtcChannel 对象
     * @param speakers              每个说话者的用户 ID 和音量信息的数组: {@link RtcAudioVolumeInfo}
     * @param totalVolume          （混音后的）总音量，取值范围为 [0,100]。
     * @endif
     */
    public delegate void ChannelOnRemoteAudioVolumeIndication(IRtcChannel channel, RtcAudioVolumeInfo[] speakers, int totalVolume);
    /**
     * @if English
     * Notifies to add the result of live stream.
     * <br>The callback asynchronously returns the callback result of \ref IRtcChannel::AddLiveStreamTask .
     * For information about actual pushing state, see \ref nertc::ChannelOnLiveStreamStateChanged "ChannelOnLiveStreamStateChanged".
     * @param channel   The current IRtcChannel object
     * @param taskId           The ID of a stream-push task.
     * @param url               Task ID.
     * @param errorCode        The result.
     * - 0: Success.
     * - Other values: Failure.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 通知添加直播任务结果。
     * <br>该回调异步返回 \ref IRtcChannel::AddLiveStreamTask 接口的调用结果；实际推流状态参考 
     * \ref nertc::ChannelOnLiveStreamStateChanged "ChannelOnLiveStreamStateChanged"
     * @param channel   当前 IRtcChannel 对象
     * @param taskId           任务id
     * @param url               推流地址
     * @param errorCode        结果
     * - 0: 调用成功；
     * - 其他: 调用失败。
     * @endif
     */
    public delegate void ChannelOnAddLiveStreamTask(IRtcChannel channel, string taskId, string url, int errorCode);
    /**
     * @if English
     * Notifies to Updates the result of live stream.
     * <br>The callback asynchronously returns the callback result of ref IRtcChannel::UpdateLiveStreamTask . For
     * information about actual pushing state, see \ref nertc::ChannelOnLiveStreamStateChanged "ChannelOnLiveStreamStateChanged".
     * @param channel   The current IRtcChannel object
     * @param taskId       The ID of a stream-push task.
     * @param url           The URL for the streaming task.
     * @param errorCode    The result.
     * - 0: Success.
     * - Other values: Failure.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 通知更新直播任务结果。
     * 该回调异步返回 \ref IRtcChannel::UpdateLiveStreamTask 接口的调用结果；实际推流状态参考
     *  \ref nertc::ChannelOnLiveStreamStateChanged "ChannelOnLiveStreamStateChanged"
     * @param channel   当前 IRtcChannel 对象
     * @param taskId       任务id
     * @param url           推流地址
     * @param errorCode    结果
     * - 0: 调用成功；
     * - 其他: 调用失败。
     * @endif
     */
    public delegate void ChannelOnUpdateLiveStreamTask(IRtcChannel channel, string taskId, string url, int errorCode);
    /**
     * @if English
     * Notifies to delete the result of live stream.
     * <br>The callback asynchronously returns the callback result of ref IRtcChannel::RemoveLiveStreamTask . For
     * information about actual pushing state, see \ref nertc::ChannelOnLiveStreamStateChanged "ChannelOnLiveStreamStateChanged" .
     * @param channel   The current IRtcChannel object
     * @param taskId       The ID of a task.
     * @param errorCode    The result.
     * - 0: Success.
     * - Other values: Failure.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 通知删除直播任务结果。
     * <br>该回调异步返回 \ref IRtcChannel::RemoveLiveStreamTask 接口的调用结果；实际推流状态参考
     * \ref nertc::ChannelOnLiveStreamStateChanged "ChannelOnLiveStreamStateChanged"
     * @param channel   当前 IRtcChannel 对象
     *  @param taskId      任务id
     * @param errorCode    结果
     * - 0: 调用成功；
     * - 其他: 调用失败。
     * @endif
     */
    public delegate void ChannelOnRemoveLiveStreamTask(IRtcChannel channel, string taskId, int errorCode);
    /**
     * @if English
     * Notifies the status in live stream-pushing.
     * @note The callback is valid in a call.
     * @param channel   The current IRtcChannel object
     * @param taskId       The ID of a task.
     * @param url           The URL for the streaming task.
     * @param state         #RtcLiveStreamStateCode The state of live stream-pushing.
     * - 505: Pushing.
     * - 506: Pushing fails.
     * - 511: Pushing ends.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 通知直播推流状态
     * @note                该回调在通话中有效。
     * @param channel   当前 IRtcChannel 对象
     * @param taskId       任务id
     * @param url           推流地址
     * @param state         #RtcLiveStreamStateCode, 直播推流状态
     * - 505: 推流中；
     * - 506: 推流失败；
     * - 511: 推流结束；
     * @endif
     */
    public delegate void ChannelOnLiveStreamStateChanged(IRtcChannel channel, string taskId, string url, RtcLiveStreamStateCode state);
    /**
     * @if English
     * Occurs when the content of remote SEI is received.
     * <br>After a remote client successfully sends SEI, the local client receives a message returned by the callback.
     * @param channel   The current IRtcChannel object
     * @param[in] uid       The ID of the user who sends the SEI.
     * @param[in] data      The received SEI data.
     * @param[in] dataSize  The size of received SEI data.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 收到远端流的 SEI 内容回调。
     * <br>当远端成功发送 SEI 后，本端会收到此回调。
     * @param channel   当前 IRtcChannel 对象
     * @param[in] uid       发送该 sei 的用户 id
     * @param[in] data      接收到的 sei 数据
     * @param[in] dataSize  接收到 sei 数据的大小
     * @endif
     */
    public delegate void ChannelOnRecvSEIMessage(IRtcChannel channel, ulong uid, byte[] data, uint dataSize);
    /**
     * @if English
     * Occurs when the state of the media stream is relayed.
     * @since V4.5.0
     * @param channel   The current IRtcChannel object
     * @param state         The state of the media stream.
     * @param channelName  The name of the destination room where the media streams are relayed.
     * @endif
     * @if Chinese
     * 跨房间媒体流转发状态发生改变回调。
     * @since V4.5.0
     * @param channel   当前 IRtcChannel 对象
     * @param state         当前跨房间媒体流转发状态。详细信息请参考 #RtcChannelMediaRelayState
     * @param channelName  媒体流转发的目标房间名。
     * @endif
     */
    public delegate void ChannelOnMediaRelayStateChanged(IRtcChannel channel, RtcChannelMediaRelayState state, string channelName);
    /**
     * @if English
     * Occurs when events related to media stream relay are triggered.
     * @since V4.5.0
     * @param channel   The current IRtcChannel object
     * @param evt         The media stream relay event.
     * @param channelName  The name of the destination room where the media streams are relayed.
     * @param error         Specific error codes.
     * @endif
     * @if Chinese
     * 媒体流相关转发事件回调。
     * @since V4.5.0
     * @param channel   当前 IRtcChannel 对象
     * @param evt         当前媒体流转发事件。详细信息请参考 #RtcChannelMediaRelayEvent 。
     * @param channelName  转发的目标房间名。
     * @param error         相关错误码。详细信息请参考 #RtcErrorCode 。
     * @endif
     */
    public delegate void ChannelOnMediaRelayEvent(IRtcChannel channel, RtcChannelMediaRelayEvent evt, string channelName, RtcErrorCode error);
    /**
     * @if English
     * Occurs when the published local media stream falls back to an audio-only stream due to poor network conditions or switches
     * back to audio and video stream after the network conditions improve. <br>If you call \ref IRtcChannel::SetLocalPublishFallbackOption and set
     * option to \ref RtcStreamFallbackOption::kNERtcStreamFallbackAudioOnly "kNERtcStreamFallbackAudioOnly" , this callback is triggered when the locally published stream falls back to
     * audio-only mode due to poor uplink network conditions, or when the audio stream switches back to the audio and video stream
     * after the uplink network conditions improve.
     * @since V4.5.0
     * @param channel   The current IRtcChannel object
     * @param isFallback   The locally published stream falls back to audio-only mode or switches back to audio and video stream.
     * - true: The published stream from a local client falls back to audio-only mode due to poor uplink network conditions.
     * - false: The audio stream switches back to the audio and video stream after the upstream network condition improves.
     * @param streamType   The type of the video stream, such as mainstream and substream.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 本地发布流已回退为音频流、或已恢复为音视频流回调。
     * <br>如果您调用了设置本地推流回退选项 \ref IRtcChannel::SetLocalPublishFallbackOption 接口，并将 option 设置为 \ref RtcStreamFallbackOption::kNERtcStreamFallbackAudioOnly "kNERtcStreamFallbackAudioOnly" 
     * 后，当上行网络环境不理想、本地发布的媒体流回退为音频流时，或当上行网络改善、媒体流恢复为音视频流时，会触发该回调。
     * @since V4.5.0
     * @param channel   当前 IRtcChannel 对象
     * @param isFallback   本地发布流已回退或已恢复。
     * - true： 由于网络环境不理想，发布的媒体流已回退为音频流。
     * - false：由于网络环境改善，从音频流恢复为音视频流。
     * @param streamType   对应的视频流类型，即主流或辅流。
     * @endif
     */
    public delegate void ChannelOnPublishFallbackToAudioOnly(IRtcChannel channel, bool isFallback, RtcVideoStreamType streamType);
    /**
     * @if English
     * Occurs when the subscribed remote media stream falls back to an audio-only stream due to poor network conditions or
     * switches back to the audio and video stream after the network condition improves. <br>If you call
     * setLocalPublishFallbackOption and set option to \ref RtcStreamFallbackOption::kNERtcStreamFallbackAudioOnly "kNERtcStreamFallbackAudioOnly" , this callback is triggered when the locally
     * published stream falls back to audio-only mode due to poor uplink network conditions, or when the audio stream switches
     * back to the audio and video stream after the uplink network condition improves.
     * @since V4.5.0
     * @param channel   The current IRtcChannel object
     * @param uid           The ID of a remote user.
     * @param isFallback   The subscribed remote media stream falls back to audio-only mode or switches back to the audio and
     * video stream.
     * - true: The subscribed remote media stream falls back to audio-only mode due to poor downstream network conditions.
     * - false: The subscribed remote media stream switches back to the audio and video stream after the downstream network
     * condition improves.
     * @param streamType   The type of the video stream, such as mainstream and substream.
     * @since V4.5.0
     * @endif
     * @if Chinese
     * 订阅的远端流已回退为音频流、或已恢复为音视频流回调。
     * <br>如果你调用了设置远端订阅流回退选项 \ref IRtcChannel::SetRemoteSubscribeFallbackOption 接口并将 option 设置 \ref RtcStreamFallbackOption::kNERtcStreamFallbackAudioOnly "kNERtcStreamFallbackAudioOnly"
     * 后，当下行网络环境不理想、仅接收远端音频流时，或当下行网络改善、恢复订阅音视频流时，会触发该回调。
     * @since V4.5.0
     * @param channel   当前 IRtcChannel 对象
     * @param uid          远端用户的 ID。
     * @param isFallback  远端订阅流已回退或恢复：
     * - true： 由于网络环境不理想，订阅的远端流已回退为音频流。
     * - false：由于网络环境改善，订阅的远端流从音频流恢复为音视频流。
     * @param streamType  对应的视频流类型，即主流或辅流。
     * @endif
     */
    public delegate void ChannelOnSubscribeFallbackToAudioOnly(IRtcChannel channel, ulong uid, bool isFallback, RtcVideoStreamType streamType);
    /**
     * @if English
     * Called when a digital avatar joins the current room.
     * 
     * @note
     * - The callback prompts that the remote digital avatar joins the current room and return the ID of the digital avatar.
     * - If users want to use digital avatars without enabling the visual avatar, a digital avatar will join the current room.
     * @param channel   The current IRtcChannel object
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
     * @param channel   当前 IRtcChannel 对象
     * @param srcUid 离开房间的远端虚拟人对应的真实用户 ID。自己的虚拟人srcUid为0。
     * @param uid 新加入房间的远端虚拟人 ID。
     * @param userName 新加入频道的远端虚拟人用户名。
     * @endif
     */
    public delegate void ChannelOnAvatarUserJoined(IRtcChannel channel, ulong srcUid, ulong uid, string userName);
    /**
     * @if English
     * Called when a digital avatar leaves the current room.
     * 
     * The remote digital avatar leaves the room (or goes offline).
     * @param channel   The current IRtcChannel object
     * @param srcUid ID of a source user of the remote digital avatar leaving the room. The digital avatar of the current user srcUid is 0.
     * @param uid ID of the digital avatar leaving the room.
     * @param reason reason for leaving the room.  
     * @endif
     * @if Chinese
     * 虚拟人离开当前房间的回调。
     * 提示有远端虚拟人离开了房间（或掉线）。
     * @param channel   当前 IRtcChannel 对象
     * @param srcUid 离开房间的远端虚拟人对应的真实用户 ID。自己的虚拟人srcUid为0。
     * @param uid 离开房间的远端虚拟人 ID。
     * @param reason 远端用户离开原因。
     * @endif
     */
    public delegate void ChannelOnAvatarUserLeft(IRtcChannel channel, ulong srcUid, ulong uid, RtcSessionLeaveReason reason);
    /**
     * @if English
     * Called when the result of starting a digital avatar is returned.
     * @note
     * - call \ref IRtcChannel::EnableAvatar to get the result.
     * @param channel   The current IRtcChannel object
     * @param enable Start or stop a digital avatar.
     * @param errorCode result.  
     * @endif
     * @if Chinese
     * 虚拟人启动结果通知。
     * @note
     * - 调用 \ref IRtcChannel::EnableAvatar 的异步结果返回。
     * @param channel   当前 IRtcChannel 对象
     * @param enable 启动或者结束虚拟人操作。
     * @param errorCode 操作结果。
     * @endif
     */
    public delegate void ChannelOnAvatarStatus(IRtcChannel channel, bool enable, RtcErrorCode errorCode);
    #endregion
    internal partial class RtcChannel
    {
        #region bind events
        private NativeChannelEnvent BindEvent(IntPtr nativeChannel)
        {
            return new NativeChannelEnvent
            {
                self = nativeChannel,
                onError = _channelOnErrorHandler,
                onWarning = _channelOnWarningHandler,
                onReleasedHwResources = _channelOnReleasedHwResourcesHandler,
                onJoinChannel = _channelOnJoinChannelHandler,
                onReconnectingStart = _channelOnReconnectingStartHandler,
                onConnectionStateChange = _channelOnConnectionStateChangeHandler,
                onRejoinChannel = _channelOnRejoinChannelHandler,
                onLeaveChannel = _channelOnLeaveChannelHandler,
                onDisconnect = _channelOnDisconnectHandler,
                onClientRoleChanged = _channelOnClientRoleChangedHandler,
                onUserJoined = _channelOnUserJoinedHandler,
                onUserLeft = _channelOnUserLeftHandler,
                onUserAudioStart = _channelOnUserAudioStartHandler,
                onUserAudioStop = _channelOnUserAudioStopHandler,
                onUserAudioMute = _channelOnUserAudioMuteHandler,
                onUserVideoStart = _channelOnUserVideoStartHandler,
                onUserVideoStop = _channelOnUserVideoStopHandler,
                onUserVideoMute = _channelOnUserVideoMuteHandler,
                onUserSubStreamVideoStart = _channelOnUserSubStreamVideoStartHandler,
                onUserSubStreamVideoStop = _channelOnUserSubStreamVideoStopHandler,
                onScreenCaptureStatusChanged = _channelOnScreenCaptureStatusChangedHandler,
                onFirstAudioDataReceived = _channelOnFirstAudioDataReceivedHandler,
                onFirstVideoDataReceived = _channelOnFirstVideoDataReceivedHandler,
                onFirstAudioFrameDecoded = _channelOnFirstAudioFrameDecodedHandler,
                onFirstVideoFrameDecoded = _channelOnFirstVideoFrameDecodedHandler,
                onLocalAudioVolumeIndication = _channelOnLocalAudioVolumeIndicationHandler,
                onRemoteAudioVolumeIndication = _channelOnRemoteAudioVolumeIndicationHandler,
                onAddLiveStreamTask = _channelOnAddLiveStreamTaskHandler,
                onUpdateLiveStreamTask = _channelOnUpdateLiveStreamTaskHandler,
                onRemoveLiveStreamTask = _channelOnRemoveLiveStreamTaskHandler,
                onLiveStreamStateChanged = _channelOnLiveStreamStateChangedHandler,
                onRecvSEIMessage = _channelOnRecvSEIMessageHandler,
                onMediaRelayStateChanged = _channelOnMediaRelayStateChangedHandler,
                onMediaRelayEvent = _channelOnMediaRelayEventHandler,
                onPublishFallbackToAudioOnly = _channelOnPublishFallbackToAudioOnlyHandler,
                onSubscribeFallbackToAudioOnly = _channelOnSubscribeFallbackToAudioOnlyHandler,
                onAvatarUserJoined = _channelOnAvatarUserJoinedHandler,
                onAvatarUserLeft = _channelOnAvatarUserLeftHandler,
                onAvatarStatus = _channelOnAvatarStatusHandler,
            };
        }

        #endregion
        #region Channel Events
        static onError _channelOnErrorHandler = ChannelOnErrorHandler;
        [MonoPInvokeCallback(typeof(onError))]
        static void ChannelOnErrorHandler(IntPtr self, int error_code, string msg)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnError?.Invoke(rtcChannel,error_code, msg);
        }
        static onWarning _channelOnWarningHandler = ChannelOnWarningHandler;
        [MonoPInvokeCallback(typeof(onWarning))]
        static void ChannelOnWarningHandler(IntPtr self, int warn_code, string msg)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnWarning?.Invoke(rtcChannel,warn_code, msg);
        }

        static onReleasedHwResources _channelOnReleasedHwResourcesHandler = ChannelOnReleasedHwResourcesHandler;
        [MonoPInvokeCallback(typeof(onReleasedHwResources))]
        static void ChannelOnReleasedHwResourcesHandler(IntPtr self, int result)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnReleasedHwResources?.Invoke(rtcChannel,(RtcErrorCode)result);
        }

        static onJoinChannel _channelOnJoinChannelHandler = ChannelOnJoinChannelHandler;
        [MonoPInvokeCallback(typeof(onJoinChannel))]
        static void ChannelOnJoinChannelHandler(IntPtr self, ulong cid, ulong uid, int result, ulong elapsed)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnJoinChannel?.Invoke(rtcChannel,cid, uid, (RtcErrorCode)result, elapsed);
        }

        static onReconnectingStart _channelOnReconnectingStartHandler = ChannelOnReconnectingStartHandler;
        [MonoPInvokeCallback(typeof(onReconnectingStart))]
        static void ChannelOnReconnectingStartHandler(IntPtr self, ulong cid, ulong uid)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnReconnectingStart?.Invoke(rtcChannel,cid, uid);
        }

        static onConnectionStateChange _channelOnConnectionStateChangeHandler = ChannelOnConnectionStateChangeHandler;
        [MonoPInvokeCallback(typeof(onConnectionStateChange))]
        static void ChannelOnConnectionStateChangeHandler(IntPtr self, int state, int reason)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnConnectionStateChange?.Invoke(rtcChannel,(RtcConnectionStateType)state, (RtcReasonConnectionChangedType)reason);
        }

        static onRejoinChannel _channelOnRejoinChannelHandler = ChannelOnRejoinChannelHandler;
        [MonoPInvokeCallback(typeof(onRejoinChannel))]
        static void ChannelOnRejoinChannelHandler(IntPtr self, ulong cid, ulong uid, int result, ulong elapsed)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnRejoinChannel?.Invoke(rtcChannel,cid, uid, (RtcErrorCode)result, elapsed);
        }

        static onLeaveChannel _channelOnLeaveChannelHandler = ChannelOnLeaveChannelHandler;
        [MonoPInvokeCallback(typeof(onLeaveChannel))]
        static void ChannelOnLeaveChannelHandler(IntPtr self, int result)
        {
            var rtcChannel = GetChannelFromNative(self);

            rtcChannel?.ChannelOnLeaveChannel?.Invoke(rtcChannel,(RtcErrorCode)result);
            rtcChannel?.VideoRawDataManager?.RemoveAllRemoteCanvas();
        }

        static onDisconnect _channelOnDisconnectHandler = ChannelOnDisconnectHandler;
        [MonoPInvokeCallback(typeof(onDisconnect))]
        static void ChannelOnDisconnectHandler(IntPtr self, int reason)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnDisconnect?.Invoke(rtcChannel,(RtcErrorCode)reason);
            rtcChannel?.VideoRawDataManager?.RemoveAllRemoteCanvas();
        }

        static onClientRoleChanged _channelOnClientRoleChangedHandler = ChannelOnClientRoleChangedHandler;
        [MonoPInvokeCallback(typeof(onClientRoleChanged))]
        static void ChannelOnClientRoleChangedHandler(IntPtr self, int oldRole, int newRole)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnClientRoleChanged?.Invoke(rtcChannel,(RtcClientRole)oldRole, (RtcClientRole)newRole);
        }

        static onUserJoined _channelOnUserJoinedHandler = ChannelOnUserJoinedHandler;
        [MonoPInvokeCallback(typeof(onUserJoined))]
        static void ChannelOnUserJoinedHandler(IntPtr self, ulong uid, string user_name)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnUserJoined?.Invoke(rtcChannel,uid, user_name);
        }

        static onUserLeft _channelOnUserLeftHandler = ChannelOnUserLeftHandler;
        [MonoPInvokeCallback(typeof(onUserLeft))]
        static void ChannelOnUserLeftHandler(IntPtr self, ulong uid, int reason)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnUserLeft?.Invoke(rtcChannel,uid, (RtcSessionLeaveReason)reason);
        }

        static onUserAudioStart _channelOnUserAudioStartHandler = ChannelOnUserAudioStartHandler;
        [MonoPInvokeCallback(typeof(onUserAudioStart))]
        static void ChannelOnUserAudioStartHandler(IntPtr self, ulong uid)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnUserAudioStart?.Invoke(rtcChannel,uid);
        }

        static onUserAudioStop _channelOnUserAudioStopHandler = ChannelOnUserAudioStopHandler;
        [MonoPInvokeCallback(typeof(onUserAudioStop))]
        static void ChannelOnUserAudioStopHandler(IntPtr self, ulong uid)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnUserAudioStop?.Invoke(rtcChannel,uid);
        }

        static onUserAudioMute _channelOnUserAudioMuteHandler = ChannelOnUserAudioMuteHandler;
        [MonoPInvokeCallback(typeof(onUserAudioMute))]
        static void ChannelOnUserAudioMuteHandler(IntPtr self, ulong uid, bool mute)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnUserAudioMute?.Invoke(rtcChannel,uid, mute);
        }

        static onUserVideoStart _channelOnUserVideoStartHandler = ChannelOnUserVideoStartHandler;
        [MonoPInvokeCallback(typeof(onUserVideoStart))]
        static void ChannelOnUserVideoStartHandler(IntPtr self, ulong uid, int max_profile)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnUserVideoStart?.Invoke(rtcChannel,uid, (RtcVideoProfileType)max_profile);
        }

        static onUserVideoStop _channelOnUserVideoStopHandler = ChannelOnUserVideoStopHandler;
        [MonoPInvokeCallback(typeof(onUserVideoStop))]
        static void ChannelOnUserVideoStopHandler(IntPtr self, ulong uid)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnUserVideoStop?.Invoke(rtcChannel,uid);
        }

        static onUserVideoMute _channelOnUserVideoMuteHandler = ChannelOnUserVideoMuteHandler;
        [MonoPInvokeCallback(typeof(onUserVideoMute))]
        static void ChannelOnUserVideoMuteHandler(IntPtr self, ulong uid, bool mute)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnUserVideoMute?.Invoke(rtcChannel,uid, mute);
        }

        static onUserSubStreamVideoStart _channelOnUserSubStreamVideoStartHandler = ChannelOnUserSubStreamVideoStartHandler;
        [MonoPInvokeCallback(typeof(onUserSubStreamVideoStart))]
        static void ChannelOnUserSubStreamVideoStartHandler(IntPtr self, ulong uid, int max_profile)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnUserSubStreamVideoStart?.Invoke(rtcChannel,uid, (RtcVideoProfileType)max_profile);
        }

        static onUserSubStreamVideoStop _channelOnUserSubStreamVideoStopHandler = ChannelOnUserSubStreamVideoStopHandler;
        [MonoPInvokeCallback(typeof(onUserSubStreamVideoStop))]
        static void ChannelOnUserSubStreamVideoStopHandler(IntPtr self, ulong uid)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnUserSubStreamVideoStop?.Invoke(rtcChannel,uid);
        }

        static onScreenCaptureStatusChanged _channelOnScreenCaptureStatusChangedHandler = ChannelOnScreenCaptureStatusChangedHandler;
        [MonoPInvokeCallback(typeof(onScreenCaptureStatusChanged))]
        static void ChannelOnScreenCaptureStatusChangedHandler(IntPtr self, int status)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnScreenCaptureStatusChanged?.Invoke(rtcChannel,(RtcScreenCaptureStatus)status);
        }

        static onFirstAudioDataReceived _channelOnFirstAudioDataReceivedHandler = ChannelOnFirstAudioDataReceivedHandler;
        [MonoPInvokeCallback(typeof(onFirstAudioDataReceived))]
        static void ChannelOnFirstAudioDataReceivedHandler(IntPtr self, ulong uid)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnFirstAudioDataReceived?.Invoke(rtcChannel,uid);
        }

        static onFirstVideoDataReceived _channelOnFirstVideoDataReceivedHandler = ChannelOnFirstVideoDataReceivedHandler;
        [MonoPInvokeCallback(typeof(onFirstVideoDataReceived))]
        static void ChannelOnFirstVideoDataReceivedHandler(IntPtr self, ulong uid)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnFirstVideoDataReceived?.Invoke(rtcChannel,uid);
        }

        static onFirstAudioFrameDecoded _channelOnFirstAudioFrameDecodedHandler = ChannelOnFirstAudioFrameDecodedHandler;
        [MonoPInvokeCallback(typeof(onFirstAudioFrameDecoded))]
        static void ChannelOnFirstAudioFrameDecodedHandler(IntPtr self, ulong uid)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnFirstAudioFrameDecoded?.Invoke(rtcChannel,uid);
        }

        static onFirstVideoFrameDecoded _channelOnFirstVideoFrameDecodedHandler = ChannelOnFirstVideoFrameDecodedHandler;
        [MonoPInvokeCallback(typeof(onFirstVideoFrameDecoded))]
        static void ChannelOnFirstVideoFrameDecodedHandler(IntPtr self, ulong uid, uint width, uint height)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnFirstVideoFrameDecoded?.Invoke(rtcChannel,uid, width, height);
        }

        static onLocalAudioVolumeIndication _channelOnLocalAudioVolumeIndicationHandler = ChannelOnLocalAudioVolumeIndicationHandler;
        [MonoPInvokeCallback(typeof(onLocalAudioVolumeIndication))]
        static void ChannelOnLocalAudioVolumeIndicationHandler(IntPtr self, int volume)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnLocalAudioVolumeIndication?.Invoke(rtcChannel,volume);
        }

        static onRemoteAudioVolumeIndication _channelOnRemoteAudioVolumeIndicationHandler = ChannelOnRemoteAudioVolumeIndicationHandler;
        [MonoPInvokeCallback(typeof(onRemoteAudioVolumeIndication))]
        static void ChannelOnRemoteAudioVolumeIndicationHandler(IntPtr self, IntPtr speakers, uint speaker_number, int total_volume)
        {
            var rtcChannel = GetChannelFromNative(self);

            var rtcSpeakers = MarshalExtension.PtrToStructureArray<RtcAudioVolumeInfo>(speakers, speaker_number);
            rtcChannel?.ChannelOnRemoteAudioVolumeIndication?.Invoke(rtcChannel,rtcSpeakers, total_volume);
        }

        static onAddLiveStreamTask _channelOnAddLiveStreamTaskHandler = ChannelOnAddLiveStreamTaskHandler;
        [MonoPInvokeCallback(typeof(onAddLiveStreamTask))]
        static void ChannelOnAddLiveStreamTaskHandler(IntPtr self, string task_id, string url, int error_code)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnAddLiveStreamTask?.Invoke(rtcChannel,task_id, url, error_code);
        }

        static onUpdateLiveStreamTask _channelOnUpdateLiveStreamTaskHandler = ChannelOnUpdateLiveStreamTaskHandler;
        [MonoPInvokeCallback(typeof(onUpdateLiveStreamTask))]
        static void ChannelOnUpdateLiveStreamTaskHandler(IntPtr self, string task_id, string url, int error_code)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnUpdateLiveStreamTask?.Invoke(rtcChannel,task_id, url, error_code);
        }

        static onRemoveLiveStreamTask _channelOnRemoveLiveStreamTaskHandler = ChannelOnRemoveLiveStreamTaskHandler;
        [MonoPInvokeCallback(typeof(onRemoveLiveStreamTask))]
        static void ChannelOnRemoveLiveStreamTaskHandler(IntPtr self, string task_id, int error_code)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnRemoveLiveStreamTask?.Invoke(rtcChannel,task_id, error_code);
        }

        static onLiveStreamStateChanged _channelOnLiveStreamStateChangedHandler = ChannelOnLiveStreamStateChangedHandler;
        [MonoPInvokeCallback(typeof(onLiveStreamStateChanged))]
        static void ChannelOnLiveStreamStateChangedHandler(IntPtr self, string task_id, string url, int state)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnLiveStreamStateChanged?.Invoke(rtcChannel,task_id, url, (RtcLiveStreamStateCode)state);
        }

        static onRecvSEIMessage _channelOnRecvSEIMessageHandler = ChannelOnRecvSEIMessageHandler;
        [MonoPInvokeCallback(typeof(onRecvSEIMessage))]
        static void ChannelOnRecvSEIMessageHandler(IntPtr self, ulong uid, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]byte[] data, uint dataSize)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnRecvSEIMessage?.Invoke(rtcChannel,uid, data, dataSize);
        }

        static onMediaRelayStateChanged _channelOnMediaRelayStateChangedHandler = ChannelOnMediaRelayStateChangedHandler;
        [MonoPInvokeCallback(typeof(onMediaRelayStateChanged))]
        static void ChannelOnMediaRelayStateChangedHandler(IntPtr self, int state, string channel_name)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnMediaRelayStateChanged?.Invoke(rtcChannel,(RtcChannelMediaRelayState)state, channel_name);
        }

        static onMediaRelayEvent _channelOnMediaRelayEventHandler = ChannelOnMediaRelayEventHandler;
        [MonoPInvokeCallback(typeof(onMediaRelayEvent))]
        static void ChannelOnMediaRelayEventHandler(IntPtr self, int evt, string channel_name, int error)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnMediaRelayEvent?.Invoke(rtcChannel,(RtcChannelMediaRelayEvent)evt, channel_name, (RtcErrorCode)error);
        }

        static onPublishFallbackToAudioOnly _channelOnPublishFallbackToAudioOnlyHandler = ChannelOnPublishFallbackToAudioOnlyHandler;
        [MonoPInvokeCallback(typeof(onPublishFallbackToAudioOnly))]
        static void ChannelOnPublishFallbackToAudioOnlyHandler(IntPtr self, bool is_fallback, int stream_type)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnPublishFallbackToAudioOnly?.Invoke(rtcChannel,is_fallback, (RtcVideoStreamType)stream_type);
        }

        static onSubscribeFallbackToAudioOnly _channelOnSubscribeFallbackToAudioOnlyHandler = ChannelOnSubscribeFallbackToAudioOnlyHandler;
        [MonoPInvokeCallback(typeof(onSubscribeFallbackToAudioOnly))]
        static void ChannelOnSubscribeFallbackToAudioOnlyHandler(IntPtr self, ulong uid, bool is_fallback, int stream_type)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnSubscribeFallbackToAudioOnly?.Invoke(rtcChannel,uid, is_fallback, (RtcVideoStreamType)stream_type);
        }

        static onAvatarUserJoined _channelOnAvatarUserJoinedHandler = ChannelOnAvatarUserJoinedHandler;
        [MonoPInvokeCallback(typeof(onAvatarUserJoined))]
        static void ChannelOnAvatarUserJoinedHandler(IntPtr self, ulong src_uid, ulong uid, string user_name)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnAvatarUserJoined?.Invoke(rtcChannel, src_uid, uid, user_name);
        }

        static onAvatarUserLeft _channelOnAvatarUserLeftHandler = ChannelOnAvatarUserLeftHandler;
        [MonoPInvokeCallback(typeof(onAvatarUserLeft))]
        static void ChannelOnAvatarUserLeftHandler(IntPtr self, ulong src_uid, ulong uid, int reason)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnAvatarUserLeft?.Invoke(rtcChannel, src_uid, uid, (RtcSessionLeaveReason)reason);
        }

        static onAvatarStatus _channelOnAvatarStatusHandler = ChannelOnAvatarStatusHandler;
        [MonoPInvokeCallback(typeof(onAvatarStatus))]
        static void ChannelOnAvatarStatusHandler(IntPtr self, bool enable, int error_code)
        {
            var rtcChannel = GetChannelFromNative(self);
            rtcChannel?.ChannelOnAvatarStatus?.Invoke(rtcChannel, enable, (RtcErrorCode)error_code);
        }
        #endregion
    }
}
