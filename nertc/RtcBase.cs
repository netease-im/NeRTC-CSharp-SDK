using System;
using System.Runtime.InteropServices;

namespace nertc
{

    /**
    * @if English
    * Configure the SDK using a JSON file to provide technical preview or special custom functionalities. Standardize JSON options.
    * For more information, see setParameters. *
    * @endif
    * @if Chinese
    * 通过 JSON 配置 SDK 提供技术预览或特别定制功能。以标准化方式公开 JSON 选项。详见 API setParameters。
    * @endif
    */
    public static class RtcConstants
    {
        #region setParameters Keys
        /**
        * @if English
        * bool value. True: Record the presenter. False: Do not record the presenter. The setting is valid before the call.
        * @endif
        * @if Chinese
        * bool value. true: 录制主讲人, false: 不是录制主讲人。通话前设置有效。
        * @endif
        */
        public static readonly string kNERtcKeyRecordHostEnabled = "record_host_enabled";
        /**
        * @if English
        * bool value, which determines whether to enable server audio recording. The default value is false. The setting is valid
        * before the call.
        * @endif
        * @if Chinese
        * bool value，启用服务器音频录制。默认值 false。通话前设置有效。
        * @endif
        */
        public static readonly string kNERtcKeyRecordAudioEnabled = "record_audio_enabled";
        /**
        * @if English
        * bool value, which determines whether to enable server video recording. The default value is false. The setting is valid
        * before the call.
        * @endif
        * @if Chinese
        * bool value，启用服务器视频录制。默认值 false。通话前设置有效。
        * @endif
        */
        public static readonly string kNERtcKeyRecordVideoEnabled = "record_video_enabled";
        /**
        * @if English
        * int value, NERtcRecordType. The setting is valid before the call.
        * @endif
        * @if Chinese
        * int value, NERtcRecordType。通话前设置有效。
        * @endif
        */
        public static readonly string kNERtcKeyRecordType = "record_type";
        /**
        * @if English
        * bool value, which determines whether to automatically subscribe to the audio stream when other users open the audio. The
        * default value is true. The setting is valid before the call.
        * @endif
        * @if Chinese
        * bool value，其他用户打开音频时，自动订阅。默认值 true。通话前设置有效。
        * @endif
        */
        public static readonly string kNERtcKeyAutoSubscribeAudio = "auto_subscribe_audio";
        /**
        * @if English
        * bool value, which determines whether to manually subscribe to the audio stream when other users open the audio on ASL mode. The
        * default value is false. The setting is valid before the call.
        * @endif
        * @if Chinese
        * bool value，在ASL模式下手动订阅音频。默认值 false。通话前设置有效。
        * @endif
        */
        public static readonly string kNERtcKeyEnableAudioASLManualSubscribe = "enable_audio_asl_manual_subscribe";
        /**
        * @if English
        * bool value, which determines whether to enable CDN relayed streaming. The default value is true. The setting is valid before
        * the call.
        * @endif
        * @if Chinese
        * bool value，开启旁路直播。默认值 false。通话前设置有效。
        * @endif
        */
        public static readonly string kNERtcKeyPublishSelfStreamEnabled = "publish_self_stream_enabled";
        /**
        * @if English
        * int value, NERtcLogLevel, SDK outputs logs that are of less than or equal to this level. The default is kNERtcLogLevelInfo.
        * @endif
        * @if Chinese
        * int value, NERtcLogLevel，SDK 输出小于或等于该级别的 log，默认为 kNERtcLogLevelInfo。
        * @endif
        */
        public static readonly string kNERtcKeyLogLevel = "log_level";
        /**
        * @if English
        * bool value. Disable or enable AEC. The default value is true.
        * @endif
        * @if Chinese
        * bool value. AEC 开关，默认值 true。
        * @endif
        */
        public static readonly string kNERtcKeyAudioProcessingAECEnable = "audio_processing_aec_enable";
        /**
        * @if English
        * bool value. Enable or disable low level AEC. The default value is false, The option takes effect only of
        * kNERtcKeyAudioProcessingAECEnable is enabled.
        * @endif
        * @if Chinese
        * bool value. low level AEC 开关，默认值 false，需要 kNERtcKeyAudioProcessingAECEnable 打开才生效。
        * @endif
        */
        public static readonly string kNERtcKeyAudioAECLowLevelEnable = "audio_aec_low_level_enable";
        /**
        * @if English
        * bool value. Enable or disable AGC. The default value is true.
        * @endif
        * @if Chinese
        * bool value. AGC 开关，默认值 true。
        * @endif
        */
        public static readonly string kNERtcKeyAudioProcessingAGCEnable = "audio_processing_agc_enable";
        /**
        * @if English
        * bool value. Enable or disable NS. The default value is true.
        * @endif
        * @if Chinese
        * bool value. NS 开关，默认值 true。
        * @endif
        */
        public static readonly string kNERtcKeyAudioProcessingNSEnable = "audio_processing_ns_enable";
        /**
        * @if English
        * bool value. Enable or disable AI NS. We recommend that you modify this option before calls. The default value is false.
        * @endif
        * @if Chinese
        * bool value. AI NS 开关，建议通话前修改，默认值 false。
        * @endif
        */
        public static readonly string kNERtcKeyAudioProcessingAINSEnable = "audio_processing_ai_ns_enable";
        /**
        * @if English
        * bool value. Enable or disable the audio mixing. The default value is false.
        * @endif
        * @if Chinese
        * bool value. 输入混音开关，默认值 false。
        * @endif
        */
        public static readonly string kNERtcKeyAudioProcessingExternalAudioMixEnable = "audio_processing_external_audiomix_enable";
        /**
        * @if English
        * bool value, which determines whether to use an earphone. true: uses an earphone. false: does not use an earphone. The default
        * value is false.
        * @endif
        * @if Chinese
        * bool value. 通知 SDK 是否使用耳机， true: 使用耳机, false: 不使用耳机，默认值 false。
        * @endif
        */
        public static readonly string kNERtcKeyAudioProcessingEarphone = "audio_processing_earphone";
        /**
        * @if English
        * int value. NERtcSendOnPubType. Sets the video sending strategy, and sends the mainstream by calling kNERtcSendOnPubHigh by
        * default. The setting is valid before the call.
        * @endif
        * @if Chinese
        * int value. NERtcSendOnPubType；设置视频发送策略，默认发送大流 kNERtcSendOnPubHigh。通话前设置有效。
        * @endif
        */
        public static readonly string kNERtcKeyVideoSendOnPubType = "video_sendonpub_type";
        /**
        * @if English
        * bool value. Enable or disable the 1v1 mode. The default value is disabled. The setting is valid before the call.
        * @endif
        * @if Chinese
        * bool value. 1v1 模式开关，默认关闭。通话前设置有效。
        * @endif
        */
        public static readonly string kNERtcKeyChannel1V1ModeEnabled = "channel_1v1_mode_enabled";
        /**
        * @if English
        * string value. APP identification, used to identify the user's product name.
        * @endif
        * @if Chinese
        * string value. APP 标识，用于后台识别用户产品名称。
        * @endif
        */
        public static readonly string kNERtcKeyExtraInfo = "extra_info";
        /**
        * @if English
        * int value. Automatic audio device selection policy. The default value is 0.
        * - 0: Default device priority
        * - 1: Available device priority
        * @endif
        * @if Chinese
        * 音频设备自动选择策略。int 类型。默认值为 0。
        * - 0：优先选择默认设备。
        * - 1：优先选择可用设备。
        * @endif
        */
        public static readonly string kNERtcKeyAudioDeviceAutoSelectType = "audio_device_auto_select_type";
        /**
        * @if English
        * Whether to return original volume when the local user is muted.  Boolean value, default: false.
        * - true：Return the original volume in \ref nertc::OnLocalAudioVolumeIndication "OnLocalAudioVolumeIndication".
        * - false：Return the recording volume(0) in \ref nertc::OnLocalAudioVolumeIndication "OnLocalAudioVolumeIndication" .
        * @endif
        * @if Chinese
        * 本地用户静音时是否返回原始音量。 布尔值，默认值为 false。
        * - true：返回 \ref nertc::OnLocalAudioVolumeIndication "OnLocalAudioVolumeIndication" 中的原始音量。
        * - false：返回 \ref nertc::OnLocalAudioVolumeIndication "OnLocalAudioVolumeIndication" 中的录音音量，静音时为 0。
        * @endif
        */
        public static readonly string kNERtcKeyEnableReportVolumeWhenMute = "enable_report_volume_when_mute";
        /**
        * @if English
        *  BOOL - Specifies whether to enable the callback to return captured video data. This enables developers to get the raw video data. You can clear the video data by calling destroyEngine. The default value is NO.
        * @endif
        * @if Chinese
        * 是否需要开启视频数据采集回调，开启后开发者可以获取到原始视频数据。
        * <br>布尔值，默认值 NO。
        * <br>开启后如果需要关闭，需要通过调用 \ref IRtcEngine::Release "Release" 来清除。
        * @endif
        */
        public static readonly string kNERtcKeyEnableVideoCaptureObserver = "enable_video_capture_observer";
        /**
        * @if English
        *  BOOL - Specifies whether to prefer using hardware to encode video data. The default value is YES. We recommend that you set
        * this value before you call \ref IRtcEngine::Initialize to initialize the IRtcEngine instance through the \ref IRtcEngine::SetParameters method. Otherwise, the setting is applied
        * the next time.
        * @endif
        * @if Chinese
        * 是否优先使用硬件编码视频数据。
        * <br>布尔值，默认值 YES。
        * <br>请在初始化（ \ref IRtcEngine::Initialize ）之前 通过 \ref IRtcEngine::SetParameters 方法设置该参数，否则该参数会在下次初始化之后生效。
        * @endif
        */
        public static readonly string kNERtcKeyVideoPreferHWEncode = "video_prefer_hw_encode";
        /**
        * @if English
        *  BOOL - Specifies whether to prefer using hardware to decode video data. The default value is YES. We recommend that you set
        * this value before you call \ref IRtcEngine::Initialize to initialize the IRtcEngine instance through the \ref IRtcEngine::SetParameters method. Otherwise, the setting is applied
        * the next time.
        * @endif
        * @if Chinese
        * 是否优先使用硬件解码视频数据。
        * <br>布尔值，默认值 YES。
        * <br>请在初始化（ \ref IRtcEngine::Initialize ）之前通过 \ref IRtcEngine::SetParameters 设置该参数，否则该参数会在下次初始化之后生效。
        * @endif
        */
        public static readonly string kNERtcKeyVideoPreferHWDecode = "video_prefer_hw_decode";

        /**
         * @if English
         * Whether to use a dynamic token to join the call. Boolean value, the default value is false.
         * @note A dynamic token is not used by default, this method must be called before calling
         * - true：use a dynamic token.
         * - false：Do not use a dynamic token.
         * @endif
         * @if Chinese
         * 是否使用动态token加入通话。 布尔值，默认值为 false。
         * @note 默认不使用动态token，该功能需要在通话前调用
         * - true：使用动态token。
         * - false：不使用动态token。
         * @endif
         */
        public static readonly string kNERtcKeyEnableDynamicToken = "enable_dynamic_token";
        /**
         * @if English
         *  BOOL - Specifies whether to turn on the rear camera if the camera is enabled for the first time. The default value is false.
         * It's available only on iOS platform.
         * @endif
         * @if Chinese
         * 第一次开启摄像头时，是否使用后摄像头。仅iOS平台有效。
         * <br>布尔值，默认值 false，即不使用后置摄像头。
         * @endif
         */
        public static readonly string kNERtcKeyVideoStartWithBackCamera = "video_start_with_back_camera";
        /**
        * @if English
        *  BOOL - Specifies whether to use metal rendering first. Otherwise, OpenGL rendering is applied. The default value is
        * false. It's available only on iOS platform.
        * @endif
        * @if Chinese
        * 是否优先使用 Metal 渲染。
        * <br>布尔值，默认值 false，即使用OpenGL 渲染。仅iOS平台有效。
        * @endif
        */
        public static readonly string kNERtcKeyVideoPreferMetalRender = "video_prefer_metal_render";
        /**
        * @if English
        * BOOL -- Specifies whether to disable switching to the speakerphone when the system switches to the earpieces. The
        * default value is false. If the value is set to true, the SDK is not allowed to switch to the speakerphone when the system
        * switches to earpieces. Users need to handle the earpieces switching event.It's available only on iOS platform.
        * @endif
        * @if Chinese
        * 当系统切换听筒或扬声器时，SDK 是否以系统设置为准。仅iOS平台有效。
        * <br>布尔值，默认为 false。
        * - true： 以系统设置为准。例如当系统切换为听筒时，应用的音频播放则自动转为听筒，开发者需要自行处理该切换事件。
        * - false： 以 SDK 设置为准，SDK 不允许用户通过系统变更音频播放路由为听筒或扬声器。例如当 SDK
        * 设置为扬声器时，即使系统切换为听筒模式，SDK 也会自动将系统修改回扬声器模式。
        * @endif
        */
        public static readonly string kNERtcKeyDisableOverrideSpeakerOnReceiver = "disable_override_speaker_on_receiver";
        /**
        * @if English
        * BOOL - Specifies whether to use echo reduction when the system sets the headset. The default value is false. If the value is
        * set to YES, the SDK does not use the echo reduction in headset mode. The setting affects the audio quality of the headset
        * in some mobile models.It's available only on iOS platform.
        * @endif
        * @if Chinese
        * 设置耳机时不使用软件回声消除功能，默认值 false。如设置YES 则SDK在耳机模式下不使用软件回声消除功能，会对某些机型下
        * 耳机的音质效果有影响。仅iOS平台有效。
        * @endif
        */
        public static readonly string kNERtcKeyDisableSWAECOnHeadset = "disable_sw_aec_on_headset";
        /**
         * @if English
         * Whether to enable bluetooth SCO.The default value is true.It's available only on Android platform.
         * @endif
         * @if Chinese
         * 是否关闭蓝牙SCO.默认打开。仅Android平台有效。
         * @endif
         */
        public static readonly string kNERtcKeyEnableAudioBluetoothSCO = "enable_audio_bluetooth_sco";
        /**
        * @if English
        * Whether to preview the front camera with mirror mode. Default: true. The setting enables the mirror mode.It's available only on Android platform.
        * @endif
        * @if Chinese
        * 前置摄像头预览是否采用镜像模式。默认为 true，开启镜像模式。仅Android平台有效。
        * @endif
        */
        public static readonly string kNERtcKeyEnableVideoMirrorWithFrontCamera = "enable_video_mirror_with_front_camera";
        /**
         * @if English
         * Video camera type.The default value is 1.It's available only on Android platform.
         * @endif
         * @if Chinese
         * 摄像头类型。默认值为1.取值范围为0(unknown), 1, 2.仅Android平台有效。
         * @endif
         */
        public static readonly string kNERtcKeyVideoCameraType = "video_camera_type";

        #endregion
        #region Device Keys
        /**
         * @if English
         * Device ID of an external video input source. After you enable external input, you must set this device ID using setDevice(windows only).
         * @endif
         * @if Chinese
         * 外部视频输入源设备ID，开启外部输入之后，需要通过setDevice设置此设备ID(windows有效)。
         * @endif
         */
        public static readonly string kNERtcExternalVideoDeviceID = "nertc-video-external-device";
        /**
         * @if English
         * The audio device automatically selects the ID. When the ID is set as the device, the SDK will automatically select the
         * appropriate audio device based on the device management system settings(windows only).
         * @endif
         * @if Chinese
         * 音频设备自动选择ID，设置该ID为设备时，SDK会根据设备插拔系统设置等自动选择合适音频设备(windows有效)。
         * @endif
         */
        public static readonly string kNERtcAudioDeviceAutoID = "nertc-audio-device-auto";
        #endregion
    }
    /**
    * @if English
    * Error codes.
    * <br>Error codes are returned when a problem that cannot be recovered without app intervention has occurred.
    * @endif
    * @if Chinese
    * 错误代码。
    * <br>错误代码意味着 SDK 遇到不可恢复的错误，需要应用程序干预。
    * @endif
    */
    public enum RtcErrorCode : int
    {
        /**
         * @if English
         * No errors.
         * @endif
         * @if Chinese
         * 没有错误
         * @endif
         */
        kNERtcNoError = 0,
        /**
         * @if English
         * Authentication failed.
         * @endif
         * @if Chinese
         * 认证错误
         * @endif
         */
        kNERtcErrChannelReserveAuthFailed = 401,
        /**
         * @if English
         * No permissions. Possible reasons:
         * - Audio and Video Call is not enabled, whose trial period is overdue or fees are not renewed.
         * - Token is not specified in safe mode when joining a channel.
         * - Other permission-related problems.
         * @endif
         * @if Chinese
         * - 权限不足。原因包括：
         * - 未开通音视频通话 2.0 服务，或试用期已过、未及时续费等。
         * - 安全模式下加入房间时未设置 Token。
         * - 其他权限问题。
         * @endif
         */
        kNERtcErrChannelReservePermissionDenied = 403,
        /**
         * @if English
         * Room does not exist.
         * @endif
         * @if Chinese
         * 房间不存在
         * @endif
         */
        kNERtcErrChannelReserveChannelNotExist = 404,
        /**
         * @if English
         * Uid does not exist.
         * @endif
         * @if Chinese
         * 房间里的uid不存在 
         * @endif
         */
        kNERtcErrChannelReserveUserIdNotExist = 405,
        /**
         * @if English
         * Request timeouts.
         * @endif
         * @if Chinese
         * 请求超时
         * @endif
         */
        kNERtcErrChannelReserveTimeOut = 408,
        /**
         * @if English
         * Error codes are returned when parameters are requested in the server.
         * @endif
         * @if Chinese
         * 服务器请求参数错误
         * @endif
         */
        kNERtcErrChannelReserveErrorParam = 414,
        /**
         * @if English
         * Invalid AppKey.
         * @endif
         * @if Chinese
         * 非法的APP KEY 
         * @endif
         */
        kNERtcErrChannelReserveErrorAppKey = 417,
        /**
         * @if English
         * Unknown errors are returned when channels are assigned in the server.
         * @endif
         * @if Chinese
         * 分配房间服务器未知错误
         * @endif
         */
        kNERtcErrChannelReserveUnknownError = 500,
        /**
         * @if English
         * Only two users are supported in the same channel. If the third user wants to share the same channel name, assign another
         * channel.
         * @endif
         * @if Chinese
         * 只支持两个用户, 有第三个人试图使用相同的房间名分配房间
         * @endif
         */
        kNERtcErrChannelReserveMoreThanTwoUser = 600,
        /**
         * @if English
         * Server error while allocating rooms.
         * @endif
         * @if Chinese
         * 分配房间服务器出错 
         * @endif
         */
        kNERtcErrChannelReserveServerFail = 601,
        /**
         * @if English
         * Invalid permission that is replaced by following operations.
         * @endif
         * @if Chinese
         * task请求无效，被后续操作覆盖
         * @endif
         */
        kNERtcErrLsTaskRequestInvalid = 1301,
        /**
         * @if English
         * Parameter format error.
         * @endif
         * @if Chinese
         * task参数格式错误
         * @endif
         */
        kNERtcErrLsTaskIsInvaild = 1400,
        /**
         * @if English
         * Exited the channel.
         * @endif
         * @if Chinese
         * 房间已经退出
         * @endif
         */
        kNERtcErrLsTaskRoomExited = 1401,
        /**
         * @if English
         * Streaming tasks are over the limit.
         * @endif
         * @if Chinese
         * 推流任务超出上限
         * @endif
         */
        kNERtcErrLsTaskNumLimit = 1402,
        /**
         * @if English
         * Duplicates ID of streaming tasks.
         * @endif
         * @if Chinese
         * 推流ID重复
         * @endif
         */
        kNERtcErrLsTaskDuplicateId = 1403,
        /**
         * @if English
         * No ID task or no channels.
         * @endif
         * @if Chinese
         * taskId任务不存在，或房间不存在
         * @endif
         */
        kNERtcErrLsTaskNotFound = 1404,
        /**
         * @if English
         * Permission failures.
         * @endif
         * @if Chinese
         * 请求失败
         * @endif
         */
        kNERtcErrLsTaskRequestErr = 1417,
        /**
         * @if English
         * Internal errors in the server.
         * @endif
         * @if Chinese
         * 服务器内部错误
         * @endif
         */
        kNERtcErrLsTaskInternalServerErr = 1500,
        /**
         * @if English
         * Layout parameter errors.
         * @endif
         * @if Chinese
         * 布局参数错误
         * @endif
         */
        kNERtcErrLsTaskInvalidLayout = 1501,
        /**
         * @if English
         * Image errors of users.
         * @endif
         * @if Chinese
         * 用户图片错误
         * @endif
         */
        kNERtcErrLsTaskUserPicErr = 1512,
        /**
         * @if English
         * Common errors.
         * @endif
         * @if Chinese
         * 通用错误
         * @endif
         */
        kNERtcErrFatal = 30001,
        /**
         * @if English
         * Out of memory.
         * @endif
         * @if Chinese
         * 内存耗尽
         * @endif
         */
        kNERtcErrOutOfMemory = 30002,
        /**
         * @if English
         * Invalid parameters.
         * @endif
         * @if Chinese
         * 错误的参数
         * @endif
         */
        kNERtcErrInvalidParam = 30003,
        /**
         * @if English
         * Unsupported operation.
         * @endif
         * @if Chinese
         * 不支持的操作
         * @endif
         */
        kNERtcErrNotSupported = 30004,
        /**
         * @if English
         * Unsupported operations in the current state.
         * @endif
         * @if Chinese
         * 当前状态不支持的操作
         * @endif
         */
        kNERtcErrInvalidState = 30005,
        /**
         * @if English
         * Depleted resources.
         * @endif
         * @if Chinese
         * 资源耗尽
         * @endif
         */
        kNERtcErrLackOfResource = 30006,
        /**
         * @if English
         * Invalid index.
         * @endif
         * @if Chinese
         * 非法 index
         * @endif
         */
        kNERtcErrInvalidIndex = 30007,
        /**
         * @if English
         * Device is not found.
         * @endif
         * @if Chinese
         * 设备未找到
         * @endif
         */
        kNERtcErrDeviceNotFound = 30008,
        /**
         * @if English
         * Invalid device ID.
         * @endif
         * @if Chinese
         * 非法设备 ID
         * @endif
         */
        kNERtcErrInvalidDeviceSourceID = 30009,
        /**
         * @if English
         * Invalid profile type of video.
         * @endif
         * @if Chinese
         * 非法的视频 profile type
         * @endif
         */
        kNERtcErrInvalidVideoProfile = 30010,
        /**
         * @if English
         * Device creation errors.
         * @endif
         * @if Chinese
         * 设备创建错误
         * @endif
         */
        kNERtcErrCreateDeviceSourceFail = 30011,
        /**
         * @if English
         * Invalid rendering device.
         * @endif
         * @if Chinese
         * 非法的渲染容器
         * @endif
         */
        kNERtcErrInvalidRender = 30012,
        /**
         * @if English
         * Device is already enabled.
         * @endif
         * @if Chinese
         * 设备已经打开
         * @endif
         */
        kNERtcErrDevicePreviewAlreadyStarted = 30013,
        /**
         * @if English
         * Transmission error.
         * @endif
         * @if Chinese
         * 传输错误
         * @endif
         */
        kNERtcErrTransmitPendding = 30014,
        /**
         * @if English
         * Server connection error.
         * @endif
         * @if Chinese
         * 连接服务器错误
         * @endif
         */
        kNERtcErrConnectFail = 30015,
        /**
         * @if English
         * Fails to create Audio dump file.
         * @endif
         * @if Chinese
         * 创建Audio dump文件失败
         * @endif
         */
        kNERtcErrCreateDumpFileFail = 30016,
        /**
         * @if English
         * Fails to enable Audio dump file.
         * @endif
         * @if Chinese
         * 开启Audio dump失败
         * @endif
         */
        kNERtcErrStartDumpFail = 30017,
        /**
         * @if English
         * Fails to enable desktop screen recording if camera is started at the same time.
         * @endif
         * @if Chinese
         * 启动桌面录屏失败，不能与camera同时启动
         * @endif
         */
        kNERtcErrDesktopCaptureInvalidState = 30020,
        /**
         * @if English
         * Parameters are invalid when the desktop screen recording is implemented.
         * @endif
         * @if Chinese
         * 桌面录屏传入参数无效
         * @endif
         */
        kNERtcErrDesktopCaptureInvalidParam = 30021,
        /**
         * @if English
         * Desktop screen recording is not ready.
         * @endif
         * @if Chinese
         * 桌面录屏未就绪
         * @endif
         */
        kNERtcErrDesktopCaptureNotReady = 30022,
        /**
         * @if English
         * Repeatedly joins the channel.
         * @endif
         * @if Chinese
         * 重复加入房间
         * @endif
         */
        kNERtcErrChannelAlreadyJoined = 30100,
        /**
         * @if English
         * Does not join the channel.
         * @endif
         * @if Chinese
         * 尚未加入房间
         * @endif
         */
        kNERtcErrChannelNotJoined = 30101,
        /**
         * @if English
         * Repeatedly leaves the channel.
         * @endif
         * @if Chinese
         * 重复离开房间
         * @endif
         */
        kNERtcErrChannelRepleatedlyLeave = 30102,
        /**
         * @if English
         * Fails to join the channel.
         * @endif
         * @if Chinese
         * 加入房间操作失败
         * @endif
         */
        kNERtcErrRequestJoinChannelFail = 30103,
        /**
         * @if English
         * Session is not found.
         * @endif
         * @if Chinese
         * 会话未找到
         * @endif
         */
        kNERtcErrSessionNotFound = 30104,
        /**
         * @if English
         * The user is not found.
         * @endif
         * @if Chinese
         * 用户未找到
         * @endif
         */
        kNERtcErrUserNotFound = 30105,
        /**
         * @if English
         * Invalid user ID.
         * @endif
         * @if Chinese
         * 非法的用户 ID
         * @endif
         */
        kNERtcErrInvalidUserID = 30106,
        /**
         * @if English
         * Users do not connect the multi-media data.
         * @endif
         * @if Chinese
         * 用户多媒体数据未连接
         * @endif
         */
        kNERtcErrMediaNotStarted = 30107,
        /**
         * @if English
         * Source is not found.
         * @endif
         * @if Chinese
         * source 未找到
         * @endif
         */
        kNERtcErrSourceNotFound = 30108,
        /**
         * @if English
         * Invalid state of switching channels.
         * @endif
         * @if Chinese
         * 切换房间状态无效
         * @endif
         */
        kNERtcErrSwitchChannelInvalidState = 30109,
        /**
         * @if English
         * Invalid state of relaying media streams.
         * @endif
         * @if Chinese
         * 重复调用 startChannelMediaRelay。
         * @endif
         */
        kNERtcErrChannelMediaRelayInvalidState = 30110,
        /**
         * @if English
         * Invalid permissions of relaying streams. Check whether the mode is set as audience mode or 1v1 mode.
         * @endif
         * @if Chinese
         * 媒体流转发权限不足。例如调用 startChannelMediaRelay 的房间成员为主播角色、或房间为双人通话房间，不支持转发媒体流。
         * @endif
         */
        kNERtcErrChannelMediaRelayPermissionDenied = 30111,
        /**
         * @if English
         * If you fail to stop relaying media streams, check whether the media stream forwarding is enabled.
         * @endif
         * @if Chinese
         * 调用 stopChannelMediaRelay 前，未调用 startChannelMediaRelay。
         * @endif
         */
        kNERtcErrChannelMediaRelayStopFailed = 30112,
        /**
         * @if English
         * If you set the different encryption password of media streams from other members in the room, you fail to join the room.
         * Sets new encryption password thorough enableEncryption.
         * @endif
         * @if Chinese
         * 设置的媒体流加密密钥与房间中其他成员不一致，加入房间失败。请通过 enableEncryption 重新设置加密密钥。
         * @endif
         */
        kNERtcErrEncryptNotSuitable = 30113,
        /**
         * @if English
         * Connection is not found.
         * @endif
         * @if Chinese
         * 连接未找到
         * @endif
         */
        kNERtcErrConnectionNotFound = 30200,
        /**
         * @if English
         * Media streams are not found.
         * @endif
         * @if Chinese
         * 媒体流未找到
         * @endif
         */
        kNERtcErrStreamNotFound = 30201,
        /**
         * @if English
         * Fails to join the track.
         * @endif
         * @if Chinese
         * 加入 track 失败
         * @endif
         */
        kNERtcErrAddTrackFail = 30202,
        /**
         * @if English
         * Track is not found.
         * @endif
         * @if Chinese
         * track 未找到
         * @endif
         */
        kNERtcErrTrackNotFound = 30203,
        /**
         * @if English
         * Media disconnection.
         * @endif
         * @if Chinese
         * 媒体连接断开
         * @endif
         */
        kNERtcErrMediaConnectionDisconnected = 30204,
        /**
         * @if English
         * Signalling disconnection.
         * @endif
         * @if Chinese
         * 信令连接断开
         * @endif
         */
        kNERtcErrSignalDisconnected = 30205,
        /**
         * @if English
         * The user is removed from the room.
         * @endif
         * @if Chinese
         * 被踢出房间
         * @endif
         */
        kNERtcErrServerKicked = 30206,
        /**
         * @if English
         * Removed for the channel is already disabled.
         * @endif
         * @if Chinese
         * 因房间已关闭而被踢出
         * @endif
         */
        kNERtcErrKickedForRoomClosed = 30207,
        /**
         * @if English
         * Removed for the destination room is disabled.
         * @endif
         * @if Chinese
         * 因为切换房间的操作房间被关闭
         * @endif
         */
        kNERtcErrChannelLeaveBySwitchAction = 30208,
        /**
         * @if English
         * Duplicate uids.
         * @endif
         * @if Chinese
         * 房间被关闭因为有重复 uid 登录 
         * @endif
         */
        kNERtcErrChannelLeaveByDuplicateUidLogin = 30209,
        /**
         * @if English
         * Permission error.
         * @endif
         * @if Chinese
         * 操作系统权限问题 
         * @endif
         */
        kNERtcErrOSAuthorize = 30300,
        /**
         * @if English
         * SEI data exceeds maximum allowed buffer size.
         * @endif
         * @if Chinese
         * SEI 超过最大缓冲大小 
         * @endif
         */
        kNERtcErrSEIExceedMaxBufferSize = 30301,
        /**
         * @if English
         * SEI data exceeds maximum allowed data size.
         * @endif
         * @if Chinese
         * SEI 超过最大数据限制 
         * @endif
         */
        kNERtcErrSEIExceedMaxDataLimit = 30302,
        /**
         * @if English
         * No permission of audio devices.
         * @endif
         * @if Chinese
         * 没有音频设备权限
         * @endif
         */
        kNERtcRuntimeErrADMNoAuthorize = 40000,
        /**
         * @if English
         * Failed to initialize the audio capture device.
         * @endif
         * @if Chinese
         * 音频采集设备初始化失败 
         * @endif
         */
        kNERtcRuntimeErrADMInitRecordingFailed = 40001,
        /**
         * @if English
         * Failed to start the audio capture device.
         * @endif
         * @if Chinese
         * 音频采集设备开始失败 
         * @endif
         */
        kNERtcRuntimeErrADMStartRecordingFailed = 40002,
        /**
         * @if English
         * Failed to stop the audio capture device.
         * @endif
         * @if Chinese
         * 音频采集设备停止失败 
         * @endif
         */
        kNERtcRuntimeErrADMStopRecordingFailed = 40003,
        /**
         * @if English
         * Failed to initialize the audio playback device.
         * @endif
         * @if Chinese
         * 音频播放设备初始化失败 
         * @endif
         */
        kNERtcRuntimeErrADMInitPlayoutFailed = 40004,
        /**
         * @if English
         * Failed to start the audio playback device.
         * @endif
         * @if Chinese
         * 音频播放设备开始失败 
         * @endif
         */
        kNERtcRuntimeErrADMStartPlayoutFailed = 40005,
        /**
         * @if English
         * Failed to stop the audio playback device.
         * @endif
         * @if Chinese
         * 音频播放设备停止失败
         * @endif
         */
        kNERtcRuntimeErrADMStopPlayoutFailed = 40006,
        /**
         * @if English
         * pensL failed to register the player.
         * @endif
         * @if Chinese
         * opensL failed to register the player 
         * @endif
         */
        kNERtcRuntimeErrOpenSLRegisterPlayerFailed = 40007,
        /**
         * @if English
         * No permission of video devices.
         * @endif
         * @if Chinese
         * 没有视频设备权限
         * @endif
         */
        kNERtcRuntimeErrVDMNoAuthorize = 50000,
        /**
         * @if English
         * Substream for non screen sharing streaming.
         * @endif
         * @if Chinese
         * 非屏幕共享使用辅流 
         * @endif
         */
        kNERtcRuntimeErrVDMNotScreenUseSubStream = 50001,
        /**
         * @if English
         * Camera disconnected.
         * @endif
         * @if Chinese
         * 摄像头断开 
         * @endif
         */
        kNERtcRuntimeErrVDMCameraDisconnect = 50303,
        /**
         * @if English
         * Camera freezed.
         * @endif
         * @if Chinese
         * 摄像头死机
         * @endif
         */
        kNERtcRuntimeErrVDMCameraFreezed = 50304,
        /**
         * @if English
         * Camera unknown error.
         * @endif
         * @if Chinese
         * 未知摄像头错误 
         * @endif
         */
        kNERtcRuntimeErrVDMCameraUnknownError = 50305,
        /**
         * @if English
         * No frame from camera. Check the camera or switch the camera
         * @endif
         * @if Chinese
         * 摄像头无数据帧。请检查摄像头或者切换摄像头
         * @endif
         */
        kNERtcRuntimeErrVDMCameraNoFrame = 50306,
        /**
         * @if English
         * Failed to start the camera. Check the camera whether it is used by other apps
         * @endif
         * @if Chinese
         * 摄像头启动失败。请检查摄像头是否存在或被占用
         * @endif
         */
        kNERtcRuntimeErrVDMCameraCreateFail = 50307,
        /**
         * @if English
         * No permission of video recording.
         * @endif
         * @if Chinese
         * 没有录制视频权限
         * @endif
         */
        kNERtcRuntimeErrScreenCaptureNoAuthorize = 60000,
    }
    
    /**
     * @if English
     * @enum RtcAudioMixingErrorCode Mixing audio file error code。
     * @endif
     * @if Chinese
     * @enum RtcAudioMixingErrorCode 混音音乐文件错误码。
     * @endif
     */
    public enum RtcAudioMixingErrorCode : int
    {
        /**
         * @if English
         * No error.
         * @endif
         * @if Chinese
         * 没有错误。
         * @endif
         */
        kNERtcAudioMixingErrorOK = 0,
        /**
         * @if English
         * Common error.
         * @endif
         * @if Chinese
         * 通用错误。
         * @endif
         */
        kNERtcAudioMixingErrorFatal = 1,
        /**
         * @if English
         * Audio mixing is not enabled normally.
         * @endif
         * @if Chinese
         * 伴音不能正常打开
         * @endif
         */
        kNERtcAudioMixingErrorCanNotOpen,
        /**
         * @if English
         * Audio decoding error.
         * @endif
         * @if Chinese
         * 音频解码错误
         * @endif
         */
        kNERtcAudioMixingErrorDecode,
        /**
         * @if English
         * Interruption codes in the operation.
         * @endif
         * @if Chinese
         * 操作中断码
         * @endif
         */
        kNERtcAudioMixingErrorInterrupt,
        /**
         * @if English
         * 404 file not found，only for http / https.
         * @endif
         * @if Chinese
         * 404 file not found，only for http /
         * @endif
         */
        kNERtcAudioMixingErrorHttpNotFound,
        /**
         * @if English
         * Fails to enable streams/files.
         * @endif
         * @if Chinese
         * 打开流 / 文件失败
         * @endif
         */
        kNERtcAudioMixingErrorOpen,
        /**
         * @if English
         * Decoding information failures or timeouts.
         * @endif
         * @if Chinese
         * 获取解码信息失败 / 超时
         * @endif
         */
        kNERtcAudioMixingErrorNInfo,
        /**
         * @if English
         * No audio streams.
         * @endif
         * @if Chinese
         * 无音频流
         * @endif
         */
        kNERtcAudioMixingErrorNStream,
        /**
         * @if English
         * No decoder.
         * @endif
         * @if Chinese
         * 无解码器
         * @endif
         */
        kNERtcAudioMixingErrorNCodec,
        /**
         * @if English
         * No memory.
         * @endif
         * @if Chinese
         * 无内存
         * @endif
         */
        kNERtcAudioMixingErrorNMem,
        /**
         * @if English
         * Failures or timeouts of enabling decoders.
         * @endif
         * @if Chinese
         * 解码器打开失败 / 超时
         * @endif
         */
        kNERtcAudioMixingErrorCodecOpen,
        /**
         * @if English
         * Invalid audio parameters such as channels and sample rate.
         * @endif
         * @if Chinese
         * 无效音频参数（声道、采样率）
         * @endif
         */
        kNERtcAudioMixingErrorInvalidInfo,
        /**
         * @if English
         * Streams/files enabling timeouts.
         * @endif
         * @if Chinese
         * 打开流 / 文件超时
         * @endif
         */
        kNERtcAudioMixingErrorOpenTimeout,
        /**
         * @if English
         * Network io timeouts.
         * @endif
         * @if Chinese
         * 网络io超时
         * @endif
         */
        kNERtcAudioMixingErrorIoTimeout,
        /**
         * @if English
         * Network io errors.
         * @endif
         * @if Chinese
         * 网络io错误
         * @endif
         */
        kNERtcAudioMixingErrorIo,
    }

    /**
     * @if English
     * Warning code.
     * If the warning code occurs, the SDK reports an error that is likely to be solved. The warning code just informs you of the
     * SDK status. In most cases, the application programs can pass the warning code.
     * @endif
     * @if Chinese
     * 警告代码。
     * 警告代码意味着 SDK 遇到问题，但有可能恢复，警告代码仅起告知作用，一般情况下应用程序可以忽略警告代码。
     * @endif
     */
    public enum RtcWarnCode : int
    {
        /**
         * @if English
         * If the specified value of view is invalid, you must specify the value of view when you enable a video. If the view is still
         * not specified, the SDK returns the warning code.
         * @endif
         * @if Chinese
         * 指定的 view 无效，使用视频功能时需要指定 view，如果 view 尚未指定，则返回该警告。
         * @endif
         */
        kNERtcWarnInvalidView = 100,
        /**
         * @if English
         * The value indicates that you fail to initialize the video feature. The reason for the failure is that video resources are
         * occupied. Users cannot view  the video but the audio communication is not affected.
         * @endif
         * @if Chinese
         * 初始化视频功能失败。有可能是因视频资源被占用导致的。用户无法看到视频画面，但不影响语音通信。
         * @endif
         */
        kNERtcWarnInitVideo = 101,
        /**
         * @if English
         * The value indicates the request is in the pending status. In most cases, the request is delayed to be met for a certain
         * module is not well loaded.
         * @endif
         * @if Chinese
         * 请求处于待定状态。一般是由于某个模块还没准备好，请求被延迟处理。
         * @endif
         */
        kNERtcWarnPending = 102,
        /**
         * to be add
         */
        kNERtcWarnNoFrame = 103,
        /**
         * @if English
         * The Client has no capability of device encoding and  decoding to match that of the channel. For example, the device cannot
         * encode in VP8 and other formats. Therefore, you may cannot implement video encoding and decoding in the channel. The local
         * side may cannot display some remote video screens and the remote side may cannot display local screens.
         * @endif
         * @if Chinese
         * 当前客户端设备视频编解码能力与房间不匹配，例如设备不支持 VP8
         * 等编码类型。在此房间中可能无法成功进行视频编解码，即本端可能无法正常显示某些远端的视频画面，同样远端也可能无法显示本端画面。
         * @endif
         */
        kNERtcWarningChannelAbilityNotMatch = 406,
        // ADM module.
        /**
         * @if English
         * Audio Device Module: A warning occurs in the playback device.
         * @endif
         * @if Chinese
         * 音频设备模块：运行时播放设备出现警告。
         * @endif
         */
        kNERtcWarnADMRuntimePlayoutWarning = 1001,
        /**
         * @if English
         * Device Module: A warning occurs in the recording device.
         * @endif
         * @if Chinese
         * 音频设备模块：运行时录音设备出现警告。
         * @endif
         */
        kNERtcWarnADMRuntimeRecordingWarning = 1002,
        /**
         * @if English
         * Audio Device Module: No valid audio data is collected.
         * @endif
         * @if Chinese
         * 音频设备模块：没有采集到有效的声音数据。
         * @endif
         */
        kNERtcWarnADMRecordAudioSilence = 1003,
        /**
         * @if English
         * Audio Device Module: Malfunction occurs in the playback device.
         * @endif
         * @if Chinese
         * 音频设备模块：播放设备故障。
         * @endif
         */
        kNERtcWarnADMPlayoutMalfunction = 1004,
        /**
         * @if English
         * Audio Device Module: Malfunction occurs in the recording device.
         * @endif
         * @if Chinese
         * 音频设备模块：录音设备故障。
         * @endif
         */
        kNERtcWarnADMRecordMalfunction = 1005,
        /**
         * @if English
         * Audio Device Module: The volume of recorded audio is too low.
         * @endif
         * @if Chinese
         * 音频设备模块：录到的声音太低。
         * @endif
         */
        kNERtcWarnADMRecordAudioLowLevel = 1006,
        /**
         * @if English
         * Audio Device Module: The playback volume is too low.
         * @endif
         * @if Chinese
         * 音频设备模块：播放的声音太低。
         * @endif
         */
        kNERtcWarnADMPlayoutAudioLowLevel = 1007,
        /**
         * @if English
         * Audio Device Module: Howling is detected in the recording audio.
         * @endif
         * @if Chinese
         * 音频设备模块：录音声音监测到啸叫。
         * @endif
         */
        kNERtcWarnAPMHowling = 1008,
        /**
         * @if English
         * Audio Device Module: The freeze occurs in the audio playback.
         * @endif
         * @if Chinese
         * 音频设备模块：音频播放会卡顿。
         * @endif
         */
        kNERtcWarnADMGlitchState = 1009,
        /**
         * @if English
         * Audio Device Module: The setting of audio bottom layer is modified.
         * @endif
         * @if Chinese
         * 音频设备模块：音频底层设置被修改。
         * @endif
         */
        kNERtcWarnADMImproperSettings = 1010,
        /**
         * @if English
         * Audio Device Module: Error occurs in the audio drive. Solution: Disables and restarts audio device, enables the device, or
         * updates the sound card drive.
         * @endif
         * @if Chinese
         * 音频设备模块：音频驱动异常。解决方案：禁用并重新使能音频设备，或者重启机器，或者更新声卡驱动。
         * @endif
         */
        // The definition of warning code on the Windows platform.
        kNERtcWarnADMWinCoreNoDataReadyEvent = 2000,
        /**
         * @if English
         * Audio Device Module: The audio capture device is not available.
         * @endif
         * @if Chinese
         * 音频设备模块：无可用音频采集设备。
         * @endif
         */
        kNERtcWarnADMWinCoreNoRecordingDevice = 2001,
        /**
         * @if English
         * Audio Device Module: Audio playback device is not available. Solution: Swap the audio device.
         * @endif
         * @if Chinese
         * 音频设备模块：无可用音频播放设备。解决方案：插入音频设备。
         * @endif
         */
        kNERtcWarnADMWinCoreNoPlayoutDevice = 2002,
        /**
         * @if English
         * Audio Device Module: Audio capturing and releasing are wrongly implemented. Solution: Disables and restarts audio device,
         * enables the device, or updates the sound card drive.
         * @endif
         * @if Chinese
         * 音频设备模块：音频采集释放有误。解决方案：禁用并重新使能音频设备，或者重启机器，或者更新声卡驱动。
         * @endif
         */
        kNERtcWarnADMWinCoreImproperCaptureRelease = 2003,
        // The definition of warning code on the macOS platform. Starts from 30000.

        // The definition of warning code on the iOS platform. Starts from 40000.

        // The definition of warning code on theAndroid  platform. Starts from 50000.

    }

    /**
     * @if English
     * RtcEngineContext definition.
     * @endif
     * @if Chinese
     * RtcEngineContext 定义
     * @endif
     */
    public class RtcEngineContext
    {
        /**
         * @if English
         * Users register the APP key of CommsEase. If you have no APP key in your developer kit, please apply to register a new APP
         * key.
         * @endif
         * @if Chinese
         * 用户注册云信的APP Key。如果你的开发包里面缺少 APP Key，请申请注册一个新的 APP Key。
         * @endif
         */
        public string appKey { get; set; }
        /**
         * @if English
         * The full path of log content are encoded in UTF-8.
         * @endif
         * @if Chinese
         * 日志的完整文件夹路径，采用 UTF-8 编码。
         * @endif
         */
        public string logPath { get; set; }

        /**
         * @if English
         * The log level. The level is kNERtcLogLevelInfo by default.
         * @endif
         * @if Chinese
         * 日志级别，默认级别为 kNERtcLogLevelInfo。
         * @endif
         */
        public RtcLogLevel logLevel { get; set; } = RtcLogLevel.kNERtcLogLevelInfo;

        /**
        * @if English
        * The size of SDK-input log file. Unit: KB. If the value is set as 0, the size of log file is 20M by default.
        * @endif
        * @if Chinese
        * 指定 SDK 输出日志文件的大小上限，单位为 KB。如果设置为 0，则默认为 20 M。
        * @endif
        */
        public uint logFileMaxSize { get; set; }

        /**
        * @if English
        * The private server address. You need to set the value as empty by default. ** To use a private server, contact technical
        * support for details.
        * @endif
        * @if Chinese
        * 私有化服务器地址，默认需要置空。如需启用私有化功能，请联系技术支持获取详情。
        * @endif
        */
        //public RtcServerAddresses serverConfig { get; set; }

        /**
        * @if English
        * Specify Context object for Android
        * @endif
        * @if Chinese
        * 指定 Android Context对象
        * @endif
        */
        public object context { get; set; }
    };
    /**
    * @if English
    * Interface ID type.
    *
    * @endif
    * @if Chinese
    * 接口ID类型。
    * @endif
    */
    public enum RtcInterfaceIdType : int
    {
        /**
        * @if English
        * Get the interface ID of the audio device manager.
        * @endif
        * @if Chinese
        * 获取音频设备管理器的接口ID
        * @endif
        */
        kNERtcIIDAudioDeviceManager = 1,
        /**
        * @if English
        * Get the interface ID of the video device manager.
        * @endif
        * @if Chinese
        * 获取视频设备管理器的接口ID
        * @endif
        */
        kNERtcIIDVideoDeviceManager = 2,
    }

    /**
    * @if English
    * Participant role type.
    * @endif
    * @if Chinese
    * 参会者角色类型
    * @endif
    */
    public enum RtcClientRole : int
    {
        /**
        * @if English
        * The host role in live streaming. The host has the permissions to open or close audio and video devices, such as a camera,
        * publish streams, and configure streaming tasks in interactive live streaming. The status of the host is visible to the
        * users in the room when the host joins or leaves the room.
        * @endif
        * @if Chinese
        * （默认）直播模式中的主播，可以操作摄像头等音视频设备、发布流、配置互动直播推流任务、上下线对房间内其他用户可见。
        * @endif
        */
        kNERtcClientRoleBroadcaster = 0,
        /**
        * @if English
        * The audience role in live streaming. The audience can only receive audio and video streams, and cannot manage audio and
        * video devices, and configure streaming tasks in interactive live streaming. The status of an audience is invisible to the
        * users in the room when the audience joins or leaves the room.
        * @endif
        * @if Chinese
        * 直播模式中的观众，观众只能接收音视频流，不支持操作音视频设备、配置互动直播推流任务、上下线不通知其他用户。
        * @endif
        */
        kNERtcClientRoleAudience = 1,
    }

    /**
    * @if English
    * Scenario types.
    * @endif
    * @if Chinese
    * 场景模式。
    * @endif
    */
    public enum RtcChannelProfileType : int
    {
        /**
        * @if English
        * Communication mode。
        * @endif
        * @if Chinese
        * 通话场景
        * @endif
        */
        kNERtcChannelProfileCommunication = 0,
        /**
        * @if English
        * Live streaming mode.
        * @endif
        * @if Chinese
        * 直播推流场景
        * @endif
        */
        kNERtcChannelProfileLiveBroadcasting = 1,
    }

    /**
    * @if English
    * Media priority type.
    * @endif
    * @if Chinese
    * 媒体优先级类型。
    * @endif
    */
    public enum RtcMediaPriorityType : int
{
        /**
        * @if English
        * High priority
        * @endif
        * @if Chinese
        * 高优先级
        * @endif
        */
        kNERtcMediaPriorityHigh = 50,
        /**
        * @if English
        * Normal priority (default)
        * @endif
        * @if Chinese
        * （默认）普通优先级
        * @endif
        */
        kNERtcMediaPriorityNormal = 100,
    }

    /**
    * @if English
    * Co-hosting method.
    * @endif
    * @if Chinese
    * 连麦方式。
    * @endif
    */
    public enum RtcLiveStreamLayoutMode :int
    {
        /**
        * to be added
        */
        kNERtcLayoutFloatingRightVertical = 0,
        /**
        * to be added
        */
        kNERtcLayoutFloatingLeftVertical,
        /**
        * to be added
        */
        kNERtcLayoutSplitScreen,
        /**
        * to be added
        */
        kNERtcLayoutSplitScreenScaling,
        /**
        * to be added
        */
        kNERtcLayoutCustom,
        /**
        * to be added
        */
        kNERtcLayoutAudioOnly,
    }

    /**
    * @if English
    * Configuration of streaming tasks.
    * @endif
    * @if Chinese
    * 直播推流任务的配置项。
    * @endif
    */
    public struct RtcLiveStreamTaskOption
    {
        /**
        * @if English
        * Streaming task ID, which is the unique identifier of a streaming task. You can use the ID to create and delete streaming
        * tasks.
        * @endif
        * @if Chinese
        * 推流任务ID，为推流任务的唯一标识，用于过程中增删任务操作。
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst =64)]
        public string taskId;
        /**
        * @if English
        * Live streaming URL address.
        * @endif
        * @if Chinese
        * 直播推流地址。
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string streamUrl;
        /**
        * @if English
        * Enable or disable server recording. The default value is false.
        * @endif
        * @if Chinese
        * 服务器录制功能是否开启，默认值为 false。
        * @endif
        */
        [MarshalAs(UnmanagedType.I1)]
        public bool serverRecordEnabled;
        /**
        * @if English
        * Co-hosting method. The default value is kNERtcLayoutFloatingRightVertical.
        * @endif
        * @if Chinese
        * 连麦方式，默认值为 kNERtcLayoutFloatingRightVertical。
        * @endif
        */
        public RtcLiveStreamLayoutMode layoutMode;
        /**
        * @if English
        * Specify the main picture uid (optional).
        * @endif
        * @if Chinese
        * 指定大画面uid（选填）。
        * @endif
        */
        public ulong mainPictureAccountId;
        /**
        * @if English
        * Custom layout parameters in JSON format (optional). You need to set the layout parameters only when layoutMode is set to
        * kNERtcLayoutCustom or kNERtcLayoutAudioOnly.
        * @endif
        * @if Chinese
        * 自定义布局参数（选填），JSON 字符串格式, 只有当layoutMode为 kNERtcLayoutCustom 或 kNERtcLayoutAudioOnly时才需要设置。
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string layoutParameters;
    }

    /**
    * @if English
    * Streaming mode in live streaming.
    * @endif
    * @if Chinese
    * 直播推流模式
    * @endif
    */
    public enum RtcLiveStreamMode : int
    {
        /**
        * @if English
        * Publish the video stream.
        * @endif
        * @if Chinese
        * 推流带视频
        * @endif
        */
        kNERtcLsModeVideo = 0,
        /**
        * @if English
        * Publish audio-only stream.
        * @endif
        * @if Chinese
        * 推流纯音频
        * @endif
        */
        kNERtcLsModeAudio = 1,
    }

    /**
    * @if English
    * Video cropping mode in live streaming
    * @endif
    * @if Chinese
    * 直播推流视频裁剪模式
    * @endif
    */
    public enum RtcLiveStreamVideoScaleMode : int
    {
        /**
        * @if English
        * 0: Video dimensions are scaled proportionally. All video content is prioritized for display. If the video dimensions do not
        * match the display window, the unfilled area of the window will be filled with the background color.
        * @endif
        * @if Chinese
        * 0: 视频尺寸等比缩放。优先保证视频内容全部显示。因视频尺寸与显示视窗尺寸不一致造成的视窗未被填满的区域填充背景色。
        * @endif
        */
        kNERtcLsModeVideoScaleFit = 0,
        /**
        * @if English
        * 1: Video dimensions are scaled proportionally. The window is prioritized to be filled. The extra video due to the
        * inconsistency between the video size and the display window size will be cropped off.
        * @endif
        * @if Chinese
        * 1: 视频尺寸等比缩放。优先保证视窗被填满。因视频尺寸与显示视窗尺寸不一致而多出的视频将被截掉。
        * @endif
        */
        kNERtcLsModeVideoScaleCropFill = 1,
    }

    /**
    * @if English
    * The member layout in live streaming.
    * @endif
    * @if Chinese
    * 直播成员布局
    * @endif
    */
    public struct RtcLiveStreamUserTranscoding
    {
        /**
        * @if English
        * Pulls the video stream of the user with the specified uid into the live event. If you add multiple users, the uid must be
        * unique.
        * @endif
        * @if Chinese
        * 将指定uid对应用户的视频流拉入直播。如果添加多个 users，则 uid 不能重复。
        * @endif
        */
        public ulong uid;
        /**
        * @if English
        * Specifies whether to play back the specific video stream from the user to viewers in the live event. Valid values:
        * - true: plays the video stream.
        * - false: does not play the video stream.
        * The setting becomes invalid when the streaming mode is set to kNERtcLsModeAudio.
        * @endif
        * @if Chinese
        * 是否在直播中向观看者播放该用户的对应视频流。可设置为：
        * - true：在直播中播放该用户的视频流。
        * - false：在直播中不播放该用户的视频流。
        * 推流模式为 kNERtcLsModeAudio 时无效。
        * @endif
        */
        [MarshalAs(UnmanagedType.I1)]
        public bool videoPush;
        /**
        * @if English
        * Adjustment between the video and the canvas in live streaming. For more information, see #RtcLiveStreamVideoScaleMode.
        * @endif
        * @if Chinese
        * 直播推流视频和画布的调节属性。详细信息请参考 #RtcLiveStreamVideoScaleMode。
        * @endif
        */
        public RtcLiveStreamVideoScaleMode adaption;
        /**
        * @if English
        * The X parameter is used to set the horizontal coordinate value of the user image. You can specify a point in the canvas
        * with X and Y coordinates. This point is used as the anchor of the upper left corner of the user image.
        * - Value range: 0 to 1920. If the specified value is set to an odd value, the value is automatically rounded down to an even
        * number.
        * - If the user image exceeds the canvas, an error occurs when you call the method.
        * @endif
        * @if Chinese
        * x 参数用于设置用户图像的横轴坐标值。通过 x 和 y 指定画布坐标中的一个点，该点将作为用户图像的左上角。
        * - 取值范围为 0~1920，若设置为奇数值，会自动向下取偶。
        * - 用户图像范围如果超出超出画布，调用方法时会报错。
        * @endif
        */
        public int x;
        /**
        * @if English
        * The Y parameter is used to set the vertical coordinate value of the user image. You can specify a point in the canvas with
        * X and Y coordinates. This point is used as the anchor of the upper left corner of the user image.
        * - Value range: 0 to 1920. If the specified value is set to an odd value, the value is automatically rounded down to an even
        * number.
        * - If the user image exceeds the canvas, an error occurs when you call the method.
        * @endif
        * @if Chinese
        * y参数用于设置用户图像的纵轴坐标值。通过 x 和 y 指定画布坐标中的一个点，该点将作为用户图像的左上角。
        * - 取值范围为 0~1920，若设置为奇数值，会自动向下取偶。
        * - 用户图像范围如果超出超出画布，调用方法时会报错。
        * @endif
        */
        public int y;
        /**
        * @if English
        * The width of the user image in the canvas.
        * - Value range: 0 to 1920. The default value is 0. If the specified value is set to an odd value, the value is automatically
        * rounded down to an even number.
        * - If the user image exceeds the canvas, an error occurs when you call the method.
        * @endif
        * @if Chinese
        * 该用户图像在画布中的宽度。
        * - 取值范围为 0~1920，默认为0。若设置为奇数值，会自动向下取偶。
        * - 用户图像范围如果超出超出画布，调用方法时会报错。
        *
        * @endif
        */
        public int width;
        /**
        * @if English
        * The height of the user image in the canvas.
        * - The X parameter is used to set the horizontal coordinate value of the user image. You can specify a point in the canvas
        * with X and Y coordinates. This point is used as the anchor of the upper left corner of the user image. 0 to 1920. The
        * default value is 0. If the specified value is set to an odd value, the value is automatically rounded down to an even
        * number.
        * - Value range: 0 to 1920. If the specified value is set to an odd value, the value is automatically rounded down to an even
        * number.
        * @endif
        * @if Chinese
        * 该用户图像在画布中的高度。
        * - 取值范围为 0~1920，默认为0。若设置为奇数值，会自动向下取偶。
        * - 用户图像范围如果超出超出画布，调用方法时会报错。
        * @endif
        */
        public int height;
        /**
        * @if English
        * Specifies whether to mix the audio stream from the user in the live event. Valid values:
        * - true: mixes the audio streams from users in a live event.
        * - false: mutes the audio streams from users in a live event.
        * @endif
        * @if Chinese
        * 是否在直播中混流该用户的对应音频流。可设置为：
        * - true：在直播中混流该用户的对应音频流。
        * - false：在直播中将该用户设置为静音。
        * @endif
        */
        [MarshalAs(UnmanagedType.I1)]
        public bool audioPush;
        /**
        * @if English
        * The layer number that is used to determine the rendering level. Value range: 0 to 100. A value of 0 indicates the bottom
        * layer and 100 indicates the top layer. <br>The rendering area at the same level is overwritten based on the existing
        * overlay strategy. Rendering is performed in the order of the array, and the index increases in ascending order.
        * @endif
        * @if Chinese
        * 图层编号，用来决定渲染层级, 取值0-100，0位于最底层，100位于最顶层。
        * 相同层级的渲染区域按照现有的覆盖逻辑实现，即按照数组中顺序进行渲染，index 递增依次往上叠加。
        * @endif
        */
        public int zOrder;
    }

    /**
    * @if English
    * Picture layout.
    * @endif
    * @if Chinese
    * 图片布局
    * @endif
    */
    public struct RtcLiveStreamImageInfo
    {
        /**
        * @if English
        * The URL of the placeholder image.
        * @endif
        * @if Chinese
        * 占位图片的URL。
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string url;
        /**
        * @if English
        * The X parameter is used to set the horizontal coordinate value of the canvas.
        * You can specify a point in the canvas with X and Y coordinates. This point is used as the anchor of the upper left corner
        * of the placeholder image. Value range: 0 to 1920. If the specified value is set to an odd value, the value is automatically
        * rounded down to an even number.
        * @endif
        * @if Chinese
        * x 参数用于设置画布的横轴坐标值。
        * 通过 x 和 y 指定画布坐标中的一个点，该点将作为占位图片的左上角。
        * 取值范围为 0~1920，若设置为奇数值，会自动向下取偶。
        * @endif
        */
        public int x;
        /**
        * @if English
        * The Y parameter is used to set the vertical coordinate value of the canvas.
        * - You can specify a point in the canvas with X and Y coordinates. This point is used as the anchor of the upper left corner
        * of the placeholder image.
        * - Value range: 0 to 1920. If the specified value is set to an odd value, the value is automatically rounded down to an even
        * number.
        * @endif
        * @if Chinese
        * y 参数用于设置画布的纵轴坐标值。
        * - 通过 x 和 y 指定画布坐标中的一个点，该点将作为占位图片的左上角。
        * - 取值范围为 0~1920，若设置为奇数值，会自动向下取偶。
        * @endif
        */
        public int y;
        /**
        * @if English
        * The width of the placeholder image in the canvas.
        * <br>Value range: 0 to 1920. If the specified value is set to an odd value, the value is automatically rounded down to an
        * even number.
        * @endif
        * @if Chinese
        * 该占位图片在画布中的宽度。
        * <br>取值范围为 0~1920，若设置为奇数值，会自动向下取偶。
        * @endif
        */
        public int width;
        /**
        * @if English
        * The height of the placeholder image in the canvas.
        * <br>Value range: 0 to 1920. If the specified value is set to an odd value, the value is automatically rounded down to an
        * even number.
        * @endif
        * @if Chinese
        * 该占位图片在画布中的高度。
        * <br>取值范围为 0~1920，若设置为奇数值，会自动向下取偶。
        * @endif
        */
        public int height;
    }
    
    /**
    * @if English
    * The live streaming layout.
    * @endif
    * @if Chinese
    * 直播布局
    * @endif
    */
    public class RtcLiveStreamLayout
    {
        /**
        * @if English
        * The width of the overall canvas. Unit: px. Value range: 0 to 1920. If the specified value is set to an odd value, the value
        * is automatically rounded down to an even number.
        * @endif
        * @if Chinese
        * 整体画布的宽度，单位为 px。取值范围为 0~1920，若设置为奇数值，会自动向下取偶。
        * @endif
        */
        public int width { get; set; }
        /**
        * @if English
        * The height of the overall canvas. Unit: - true: 0 to 1920. If the specified value is set to an odd value, the value is
        * automatically rounded down to an even number.
        * @endif
        * @if Chinese
        * 整体画布的高度，单位为 px。取值范围为 0~1920，若设置为奇数值，会自动向下取偶。
        * @endif
        */
        public int height { get; set; }
        /**
        * @if English
        * The background color of the canvas. The value of the background color is the sum of 256 x 256 x R + 256 x G + B. Enter the
        * corresponding RGB values into this formula to calculate the value. If the value is unspecified, the default value is 0.
        * @endif
        * @if Chinese
        * 画面背景颜色，格式为 256 x 256 x R + 256 x G + B的和。请将对应 RGB 的值分别带入此公式计算即可。若未设置，则默认为0。
        * @endif
        */
        public uint backgroundColor { get; set; }
        /**
        * @if English
        * The member layout array.
        * @endif
        * @if Chinese
        * 成员布局数组。
        * @endif
        */
        public RtcLiveStreamUserTranscoding[] users { get; set; }
        /**
        * @if English
        * The background image.For more information, see {@link RtcLiveStreamImageInfo} .
        * @endif
        * @if Chinese
        * 背景图片。详细信息请参考 {@link RtcLiveStreamImageInfo} 。
        * @endif
        */
        public RtcLiveStreamImageInfo? bgImage { get; set; }
    }

    /**
    * @if English
    * Live streaming audio sample rate
    * @endif
    * @if Chinese
    * 直播推流音频采样率
    * @endif
    */
    public enum RtcLiveStreamAudioSampleRate : int
    {
        /**
        * @if English
        * The sample rate is 32 kHz.
        * @endif
        * @if Chinese
        * 采样率为 32 kHz。
        * @endif
        */
        kNERtcLiveStreamAudioSampleRate32000 = 32000,
        /**
        * @if English
        * The sample rate is 44.1 kHz.
        * @endif
        * @if Chinese
        * 采样率为 44.1 kHz。
        * @endif
        */
        kNERtcLiveStreamAudioSampleRate44100 = 44100,
        /**
        * @if English
        * (Default) The sample rate is 48 kHz.
        * @endif
        * @if Chinese
        * （默认）采样率为 48 kHz。
        * @endif
        */
        kNERtcLiveStreamAudioSampleRate48000 = 48000,
    }

    /**
    * @if English
    * Live streaming audio codec profile
    * @endif
    * @if Chinese
    * 直播推流音频编码规格
    * @endif
    */
    public enum RtcLiveStreamAudioCodecProfile : int
    {
        /**
        * @if English
        * (Default) LC- AAC, the basic audio encoding profile.
        * @endif
        * @if Chinese
        * （默认）LC-AAC 规格，表示基本音频编码规格。
        * @endif
        */
        kNERtcLiveStreamAudioCodecProfileLCAAC = 0,
        /**
        * @if English
        * HE-AAC, high-efficiency audio encoding profile.
        * @endif
        * @if Chinese
        * HE-AAC 规格，表示高效音频编码规格。
        * @endif
        */
        kNERtcLiveStreamAudioCodecProfileHEAAC = 1,
    }
    

    /**
    * @if English
    * Streaming configuration.
    * @endif
    * @if Chinese
    * 直播流配置
    * @endif
    */
    public struct RtcLiveStreamConfig
    {
        /**
        * @if English
        * Enables or disables single video pass-through. By default, the setting is disabled.
        * - If you enable video pass-through, and the room ingests only one video stream, then, the stream is not transcoded and does
        * not follow the transcoding flow. The video stream is directly published to a CDN.
        * - If multiple video streams from different room members are mixed into one video stream, this setting becomes invalid, and
        * will not be restored when the stream is restored to the single stream.
        * @endif
        * @if Chinese
        * 单路视频透传开关，默认为关闭状态。
        * - 开启后，如果房间中只有一路视频流输入， 则不对输入视频流进行转码，不遵循转码布局，直接推流 CDN。
        * - 如果有多个房间成员视频流混合为一路流，则该设置失效，并在恢复为一个成员画面（单路流）时也不会恢复。
        * @endif
        */
        [MarshalAs(UnmanagedType.I1)]
        public bool singleVideoPassthrough;
        /**
        * @if English
        * The bitrate of the audio stream.
        * - Unit: kbps. Valid values: 10 to 192.
        * - We recommend that you set the bitrate to 64 or higher for voice scenarios and set 128 or higher for music scenarios.
        * @endif
        * @if Chinese
        * 音频推流码率。
        * - 单位为 kbps，取值范围为 10~192。
        * - 语音场景建议设置为 64 及以上码率，音乐场景建议设置为 128 及以上码率。
        * @endif
        */
        public int audioBitrate;
        /**
        * @if English
        * The sample rate of the audio stream. Unit: Hz. The default value is kNERtcLiveStreamAudioSampleRate48000, which indicates
        * the sample rate of 48 kHz.
        * @endif
        * @if Chinese
        * 音频推流采样率。单位为Hz。默认为 kNERtcLiveStreamAudioSampleRate48000，即采样率为 48 kHz。
        * @endif
        */
        public RtcLiveStreamAudioSampleRate sampleRate;
        /**
        * @if English
        * The number of audio channels for publishing streams. The default value is 2, which represents the stereo sound.
        * @endif
        * @if Chinese
        * 音频推流声道数，默认值为 2 双声道。
        * @endif
        */
        public int channels;
        /**
        * @if English
        * The audio encoding profile. The default value is kNERtcLiveStreamAudioCodecProfileLCAAC, which is the basic encoding
        * profile.
        * - 0: LC-AAC, the basic encoding profile.
        * - 1: HE-AAC, the high-efficiency audio encoding profile.
        * @endif
        * @if Chinese
        * 音频编码规格。默认值 kNERtcLiveStreamAudioCodecProfileLCAAC，普通编码规格。
        * - 0: LC-AAC 规格，表示基本音频编码规格
        * - 1: HE-AAC 规格，表示高效音频编码规格。
        * @endif
        */
        public RtcLiveStreamAudioCodecProfile audioCodecProfile;
    }

    /**
    * @if English
    * Configuration of streaming tasks.
    * @endif
    * @if Chinese
    * 直播推流任务的配置项。
    * @endif
    */
    public class RtcLiveStreamTaskInfo
    {
        /**
        * @if English
        * The ID of a custom streaming task. The ID must be up to 64 characters in length and can contain letters, numbers, and
        * underscores. The ID must be unique.
        * @endif
        * @if Chinese
        * 自定义的推流任务 ID。字母、数字、下划线组成的 64 位以内的字符串。请保证此 ID 唯一。
        * @endif
        */
        public string taskId { get; set; }
        /**
        * @if English
        * The streaming URL, such as rtmp://test.url.
        * <br>The URL can be set to the value of the pushUrl response parameter of the server API used to create a room in NetEase
        * CommsEase live streaming.
        * @endif
        * @if Chinese
        * 推流地址，例如 rtmp://test.url。
        * <br>此处的推流地址可设置为网易云信直播产品中服务端 API创建房间的返回参数pushUrl。
        * @endif
        */
        public string streamUrl { get; set; }
        /**
        * @if English
        * Specifies whether to enable audio and video recording in the CDN relayed streaming. By default, the setting is disabled.
        * @endif
        * @if Chinese
        * 旁路推流是否需要进行音视频录制。默认为关闭状态。
        * @endif
        */
        public bool serverRecordEnabled { get; set; }
        /**
        * @if English
        * The live streaming mode.
        * @endif
        * @if Chinese
        * 直播推流模式。
        * @endif
        */
        public RtcLiveStreamMode lsMode { get; set; }
        /**
        * @if English
        * Set the canvas layout of Interactive Live Streaming. 
        * @endif
        * @if Chinese
        * 设置互动直播的画面布局。
        * @endif
        */
        public RtcLiveStreamLayout layout { get; set; }
        /**
        * @if English
        * Settings such as encoding parameters of the audio and video streams.
        * @endif
        * @if Chinese
        * 音视频流编码参数等设置。
        * @endif
        */
        public RtcLiveStreamConfig config { get; set; }
        /**
        * @if English
        * SEI message。The maximum length is 4096 bytes.
        * @endif
        * @if Chinese
        * SEI信息。最大长度为4096字节。
        * @endif
        */
        public string extraInfo { get; set; }
    }

    /**
    * @if English
    * Live streaming status code.
    * @endif
    * @if Chinese
    * 直播推流状态。
    * @endif
    */
    public enum RtcLiveStreamStateCode : int
    {
        /**
        * @if English
        * Publishing.
        * @endif
        * @if Chinese
        * 推流中
        * @endif
        */
        kNERtcLsStatePushing = 505,
        /**
        * @if English
        * Publishing fails.
        * @endif
        * @if Chinese
        * 互动直播推流失败
        * @endif
        */
        kNERtcLsStatePushFail = 506,
        /**
        * @if English
        * Publishing ends.
        * @endif
        * @if Chinese
        * 推流结束
        * @endif
        */
        kNERtcLsStatePushStopped = 511,
        /**
        * @if English
        * Background image setting error.
        * @endif
        * @if Chinese
        * 背景图片设置出错
        * @endif
        */
        kNERtcLsStateImageError = 512,
    }

    /**
    * @if English
    * System ategory.
    * @endif
    * @if Chinese
    * 系统分类。
    * @endif
    */
    public enum RtcOsCategory : int
    {
        /**
        * @if English
        * iOS universal device.
        * @endif
        * @if Chinese
        * iOS 通用设备
        * @endif
        */
        kNERtcOSiOS = 1,
        /**
        * @if English
        * Android universal device.
        * @endif
        * @if Chinese
        * Android 通用设备
        * @endif
        */
        kNERtcOSAndroid = 2,
        /**
        * @if English
        * PC设备
        * @endif
        * @if Chinese
        * PC device.
        * @endif
        */
        kNERtcOSPC = 3,
        /**
        * @if English
        * WebRTC.
        * @endif
        * @if Chinese
        * WebRTC
        * @endif
        */
        kNERtcOSWebRTC = 4,
    }
    
    /**
    * @if English
    * Audio profile. Audio sample rate, bitrate, encoding mode, and the number of channels.
    * @endif
    * @if Chinese
    * 音频属性。设置采样率，码率，编码模式和声道数。
    * @endif
    */
    public enum RtcAudioProfileType: int
    {
        /**
        * @if English
        * Default settings. kNERtcAudioProfileStandard in the speech scenarios. kNERtcAudioProfileHighQuality in the music scenarios.
        * @endif
        * @if Chinese
        * 0: 默认设置。Speech 场景下为 kNERtcAudioProfileStandardExtend，Music 场景下为 kNERtcAudioProfileHighQuality。
        * @endif
        */
        kNERtcAudioProfileDefault = 0,
        /**
        * @if English
        * 1: Standard-quality audio encoding, 16000Hz, 20kbps.
        * @endif
        * @if Chinese
        * 1: 普通质量的音频编码，16000Hz，20Kbps
        * @endif
        */
        kNERtcAudioProfileStandard = 1,
        /**
        * @if English
        * 2: Standard-quality audio encoding, 16000Hz, 32kbps.
        * @endif
        * @if Chinese
        * 2: 普通质量的音频编码，16000Hz，32Kbps
        * @endif
        */
        kNERtcAudioProfileStandardExtend = 2,
        /**
        * @if English
        * 3: Medium-quality audio encoding, 48000Hz, 32kbps.
        * @endif
        * @if Chinese
        * 3: 中等质量的音频编码，48000Hz，32Kbps
        * @endif
        */
        kNERtcAudioProfileMiddleQuality = 3,
        /**
        * @if English
        * 4: Medium-quality stereo encoding, 48000Hz * 2, 64kbps.
        * @endif
        * @if Chinese
        * 4: 中等质量的立体声编码，48000Hz * 2，64Kbps
        * @endif
        */
        kNERtcAudioProfileMiddleQualityStereo = 4,
        /**
        * @if English
        * 5: High-quality audio encoding, 48000Hz, 64kbps.
        * @endif
        * @if Chinese
        * 5: 高质量的音频编码，48000Hz，64Kbps
        * @endif
        */
        kNERtcAudioProfileHighQuality = 5,
        /**
        * @if English
        * 6: High-quality stereo encoding, 48000Hz * 2, 128kbps.
        * @endif
        * @if Chinese
        * 6: 高质量的立体声编码，48000Hz * 2，128Kbps
        * @endif
        */
        kNERtcAudioProfileHighQualityStereo = 6,
    }
    
    /**
    * @if English
    * Audio application scenarios. Different audio scenarios use different audio capture modes and playback modes.
    * @endif
    * @if Chinese
    *  音频应用场景。不同的场景设置对应不同的音频采集模式、播放模式。
    * @endif
    */
    public enum RtcAudioScenarioType : int
    {
        /**
        * @if English
        * 0: Default settings.
        * - kNERtcAudioScenarioSpeech in kNERtcChannelProfileCommunication.
        * - kNERtcAudioScenarioMusic in kNERtcChannelProfileLiveBroadcasting.
        * @endif
        * @if Chinese
        * 0: 默认设置
        * - kNERtcChannelProfileCommunication下为kNERtcAudioScenarioSpeech，
        * - kNERtcChannelProfileLiveBroadcasting下为kNERtcAudioScenarioMusic。
        * @endif
        */
        kNERtcAudioScenarioDefault = 0,
        /**
        * @if English
        * 1: Voice scenarios. Set NERtcAudioProfileType to kNERtcAudioProfileMiddleQuality or lower.
        * @endif
        * @if Chinese
        * 1: 语音场景. NERtcAudioProfileType 推荐使用 kNERtcAudioProfileMiddleQuality 及以下
        * @endif
        */
        kNERtcAudioScenarioSpeech = 1,
        /**
        * @if English
        * 2: Music scenarios. Set NERtcAudioProfileType to kNERtcAudioProfileMiddleQualityStereo or above.
        * @endif
        * @if Chinese
        * 2: 音乐场景。NERtcAudioProfileType 推荐使用 kNERtcAudioProfileMiddleQualityStereo 及以上
        * @endif
        */
        kNERtcAudioScenarioMusic = 2,
    }

    /**
    * @if English
    * The preset value of the voice changer.
    * @endif
    * @if Chinese
    * 变声 预设值
    * @endif
    */
    public enum RtcVoiceChangerType : int
    {
        /**
        * @if English
        * By default, the setting is disabled.
        * @endif
        * @if Chinese
        * 默认关闭
        * @endif
        */
        kNERtcVoiceChangerOff = 0,
        /**
        * @if English
        * A robot voice.
        * @endif
        * @if Chinese
        * 机器人
        * @endif
        */
        kNERtcVoiceChangerRobot = 1,
        /**
        * @if English
        * A giant voice.
        * @endif
        * @if Chinese
        * 巨人
        * @endif
        */
        kNERtcVoiceChangerGaint = 2,
        /**
        * @if English
        * A horror voice.
        * @endif
        * @if Chinese
        * 恐怖
        * @endif
        */
        kNERtcVoiceChangerHorror = 3,
        /**
        * @if English
        * A maturity voice.
        * @endif
        * @if Chinese
        * 成熟
        * @endif
        */
        kNERtcVoiceChangerMature = 4,
        /**
        * @if English
        * From a male voice to a female voice.
        * @endif
        * @if Chinese
        * 男变女
        * @endif
        */
        kNERtcVoiceChangerManToWoman = 5,
        /**
        * @if English
        * From a female voice to a male voice.
        * @endif
        * @if Chinese
        * 女变男
        * @endif
        */
        kNERtcVoiceChangerWomanToMan = 6,
        /**
        * @if English
        * From a male voice to a loli voice.
        * @endif
        * @if Chinese
        * 男变萝莉
        * @endif
        */
        kNERtcVoiceChangerManToLoli = 7,
        /**
        * @if English
        * From a female voice to a loli voice.
        * @endif
        * @if Chinese
        * 女变萝莉
        * @endif
        */
        kNERtcVoiceChangerWomanToLoli = 8,
    }

    /**
    * @if English
    * Preset voice beautifier effect.
    * @endif
    * @if Chinese
    * 预设的美声效果
    * @endif
    */
    public enum RtcVoiceBeautifierType : int
    {
        /**
        * @if English
        * By default, the setting is disabled.
        * @endif
        * @if Chinese
        * 默认关闭
        * @endif
        */
        kNERtcVoiceBeautifierOff = 0,
        /**
        * @if English
        * A muffled effect.
        * @endif
        * @if Chinese
        * 低沉
        * @endif
        */
        kNERtcVoiceBeautifierMuffled = 1,
        /**
        * @if English
        * A mellow effect.
        * @endif
        * @if Chinese
        * 圆润
        * @endif
        */
        kNERtcVoiceBeautifierMellow = 2,
        /**
        * @if English
        * A clear effect.
        * @endif
        * @if Chinese
        * 清澈
        * @endif
        */
        kNERtcVoiceBeautifierClear = 3,
        /**
        * @if English
        * A magnetic effect.
        * @endif
        * @if Chinese
        * 磁性
        * @endif
        */
        kNERtcVoiceBeautifierMagnetic = 4,
        /**
        * @if English
        * A recording studio effect.
        * @endif
        * @if Chinese
        * 录音棚
        * @endif
        */
        kNERtcVoiceBeautifierRecordingstudio = 5,
        /**
        * @if English
        * A nature effect.
        * @endif
        * @if Chinese
        * 天籁
        * @endif
        */
        kNERtcVoiceBeautifierNature = 6,
        /**
        * @if English
        * A KTV effect.
        * @endif
        * @if Chinese
        * KTV
        * @endif
        */
        kNERtcVoiceBeautifierKTV = 7,
        /**
        * @if English
        * A remote effect.
        * @endif
        * @if Chinese
        * 悠远
        * @endif
        */
        kNERtcVoiceBeautifierRemote = 8,
        /**
        * @if English
        * A church effect.
        * @endif
        * @if Chinese
        * 教堂
        * @endif
        */
        kNERtcVoiceBeautifierChurch = 9,
        /**
        * @if English
        * A bedroom effect.
        * @endif
        * @if Chinese
        * 卧室
        * @endif
        */
        kNERtcVoiceBeautifierBedroom = 10,
        /**
        * @if English
        * A live effect.
        * @endif
        * @if Chinese
        * Live
        * @endif
        */
        kNERtcVoiceBeautifierLive = 11,
    }

    /**
    * @if English
    * The center frequency of the sound equalization band.
    * @endif
    * @if Chinese
    * 音效均衡波段的中心频率
    * @endif
    */
    public enum RtcVoiceEqualizationBand : int
    {
        /**
        * @if English
        * 31 Hz
        * @endif
        * @if Chinese
        * 31 Hz
        * @endif
        */
        kNERtcVoiceEqualizationBand31 = 0,
        /**
        * @if English
        * 62 Hz.
        * @endif
        * @if Chinese
        * 62 Hz
        * @endif
        */
        kNERtcVoiceEqualizationBand62 = 1,
        /**
        * @if English
        * 125 Hz.
        * @endif
        * @if Chinese
        * 125 Hz
        * @endif
        */
        kNERtcVoiceEqualizationBand125 = 2,
        /**
        * @if English
        * 250 Hz.
        * @endif
        * @if Chinese
        * 250 Hz
        * @endif
        */
        kNERtcVoiceEqualizationBand250 = 3,
        /**
        * @if English
        * 500 Hz.
        * @endif
        * @if Chinese
        * 500 Hz
        * @endif
        */
        kNERtcVoiceEqualizationBand500 = 4,
        /**
        * @if English
        * 1 kHz.
        * @endif
        * @if Chinese
        * 1 kHz
        * @endif
        */
        kNERtcVoiceEqualizationBand1K = 5,
        /**
        * @if English
        * 2 kHz.
        * @endif
        * @if Chinese
        * 2 kHz
        * @endif
        */
        kNERtcVoiceEqualizationBand2K = 6,
        /**
        * @if English
        * 4 kHz.
        * @endif
        * @if Chinese
        * 4 kHz
        * @endif
        */
        kNERtcVoiceEqualizationBand4K = 7,
        /**
        * @if English
        * 8 kHz.
        * @endif
        * @if Chinese
        * 8 kHz
        * @endif
        */
        kNERtcVoiceEqualizationBand8K = 8,
        /**
        * @if English
        * 16 kHz.
        * @endif
        * @if Chinese
        * 16 kHz
        * @endif
        */
        kNERtcVoiceEqualizationBand16K = 9,
    }

    /**
    * @if English
    * The camera capture preference.
    * @endif
    * @if Chinese
    * 设置摄像头的采集偏好。
    * @endif
    */
    public enum RtcCameraPreference : int
    {
        /**
        * @if English
        * 0：(default) Prioritizes the system performance. The SDK chooses the dimension and frame rate of the local camera capture
        * closest to those set by setVideoConfig.
        * @endif
        * @if Chinese
        * （默认）优先保证设备性能。SDK 根据设备性能，参考用户在 setVideoConfig
        * 中设置编码器的分辨率和帧率，选择最接近的摄像头输出参数。在这种情况下，预览质量接近于编码器的输出质量。
        * @endif
        */
        kNERtcCameraOutputDefault = 0,
        /**
        * @if English
        * Prioritizes the local preview quality. The SDK chooses higher camera output parameters to improve the local video preview
        * quality. This option requires extra CPU and RAM usage for video pre-processing.
        * @endif
        * @if Chinese
        * 优先保证视频预览质量。SDK 自动设置画质较高的摄像头输出参数，提高预览画面质量。此时会消耗更多的 CPU 及内存做视频前处理。
        * @endif
        */
        kNERtcCameraOutputQuality = 1,
        /**
        * @if English
        * Allows you to customize the width and height of the video image captured by the local camera.
        * @endif
        * @if Chinese
        * 采用用户自定义设置的摄像头输出参数。此时用户可以通过 NERtcCameraCaptureConfig 中的 captureWidth 和 captureHeight
        * 设置本地摄像头采集的视频宽高。
        * @endif
        */
        kNERtcCameraOutputManual = 2,
    }

    /**
    * @if English
    * The camera capturer configuration.
    * @endif
    * @if Chinese
    * 摄像头采集配置。
    * @endif
    */
    public struct RtcCameraCaptureConfig
    {
        /**
        * @if English
        * The camera capture preference.
        * @endif
        * @if Chinese
        * 摄像头采集偏好。
        * @endif
        */
        public RtcCameraPreference preference;
        /**
        * @if English
        * The width (px) of the video image captured by the local camera.
        * <br>The video encoding resolution is expressed in width x height. It is used to set the video encoding resolution and
        * measure the encoding quality.
        * - captureWidth: the pixels of the video frame on the horizontal axis, that is, the custom width.
        * - captureHeight： the pixels of the video frame on the horizontal axis, that is, the custom height.
        * @note
        * - To customize the width of the video image, set preference as kNERtcCameraOutputManual first, and then use captureWidth
        * and captureHeight.
        * - In manual mode, if the specified collection size is smaller than the encoding size, the encoding parameters will be
        * aligned down to the collection size range.
        * @endif
        * @if Chinese
        * 本地采集的视频宽度，单位为 px。
        * <br>视频编码分辨率以宽 x 高表示，用于设置视频编码分辨率，以衡量编码质量。
        * - captureWidth 表示视频帧在横轴上的像素，即自定义宽。
        * - captureHeight 表示视频帧在横轴上的像素，即自定义高。
        * @note
        * - 如果您需要自定义本地采集的视频尺寸，请先将 preference 设为 kNERtcCameraOutputManual，再通过 captureWidth 和 captureHeight
        * 设置采集的视频宽度。
        * - 手动模式下，如果指定的采集宽高小于编码宽高，编码参数会被下调对齐到采集的尺寸范围内。
        * @endif
        */
        public int captureWidth;
        /**
        * @if English
        * The height (px) of the video image captured by the local camera.
        * <br>The video encoding resolution is expressed in width x height. It is used to set the video encoding resolution and
        * measure the encoding quality.
        * - captureWidth: the pixels of the video frame on the horizontal axis, that is, the custom width.
        * - captureHeight： the pixels of the video frame on the horizontal axis, that is, the custom height.
        * @note
        * - To customize the width of the video image, set preference as CAPTUREPREFERENCEMANUAL first, and then use captureWidth
        * and captureHeight.
        * - In manual mode, if the specified collection size is smaller than the encoding size, the encoding parameters will be
        * aligned down to the collection size range.
        * @endif
        * @if Chinese
        * 本地采集的视频高度，单位为 px。
        * <br>视频编码分辨率以宽 x 高表示，用于设置视频编码分辨率，以衡量编码质量。
        * - captureWidth 表示视频帧在横轴上的像素，即自定义宽。
        * - captureHeight 表示视频帧在横轴上的像素，即自定义高。
        * @note
        * - 如果您需要自定义本地采集的视频尺寸，请先将 preference 设为 kNERtcCameraOutputManual，再通过 captureWidth 和 captureHeight
        * 设置采集的视频宽度。
        * - 手动模式下，如果指定的采集宽高小于编码宽高，编码参数会被下调对齐到采集的尺寸范围内。
        * @endif
        */
        public int captureHeight;
    }

    /**
    * @if English
    * Video encoding configuration. The resolution used to measure encoding quality.
    * @note kNERtcVideoProfileFake:
    * - The peer sends a 16*16 fakeVideo (SEI delivered in audio-only streams), which is an internal behavior of the SDK. The view
    * is not displayed at this time (the client receives only black frames).
    * - Therefore, this setting is not actively applied. If you select the setting, the SDK applies the setting to the standard.
    * @endif
    * @if Chinese
    * 视频编码配置。用于衡量编码质量。
    * @note
    * kNERtcVideoProfileFake:
    * - 表示对端发送 16*16 的 fakeVideo，即纯音频下发送 SEI，属于 SDK 内部行为，此时收到的是黑色帧，不需要显示 view。
    * - 因此这个档位不主动使用，属于被动接受，如果主动使用，SDK 内部会按 standard 处理。
    * @endif
    */
    public enum RtcVideoProfileType : int
    {
        /**
        * @if English
        * LD160x90/120, 15fps
        * @endif
        * @if Chinese
        * 普清（160x90/120, 15fps）
        * @endif
        */
        kNERtcVideoProfileLowest = 0,
        /**
        * @if English
        * LD 320x180/240, 15fps
        * @endif
        * @if Chinese
        * 标清（320x180/240, 15fps）
        * @endif
        */
        kNERtcVideoProfileLow = 1,
        /**
        * @if English
        * SD 640x360/480, 30fps
        * @endif
        * @if Chinese
        * 高清（640x360/480, 30fps）
        * @endif
        */
        kNERtcVideoProfileStandard = 2,
        /**
        * @if English
        * HD (1280 x 720, 30 fps)
        * @endif
        * @if Chinese
        * 超清（1280x720, 30fps）
        * @endif
        */
        kNERtcVideoProfileHD720P = 3,
        /**
        * @if English
        * 1080p (1920x1080, 30fps)
        * @endif
        * @if Chinese
        * 1080P（1920x1080, 30fps）
        * @endif
        */
        kNERtcVideoProfileHD1080P = 4,
        /**
        * @if English
        * None
        * @endif
        * @if Chinese
        * 无效果。
        * @endif
        */
        kNERtcVideoProfileNone = 5,
        kNERtcVideoProfileMAX = kNERtcVideoProfileHD1080P,
        /**
        * @if English
        * FakeVideo logo, only displayed in the callback. Do not use the setting. Otherwise, the SDK applies the logo based on
        * kNERtcVideoProfileStandard. <br>When the remote client sends the SEI in the audio-only state, the local client receives the
        * message returned by the onUserVideoStart callback from the remote client. The maxProfile parameter is
        * kNERtcVideoProfileFake, which indicates that the remote client sends a 16*16 FakeVideo. At this time, if the local client
        * needs to receive the remote SEI, you only need to subscribe to the remote video, without setting the remote canvas.
        * @endif
        * @if Chinese
        * FakeVideo标识，仅在回调中显示。请勿主动设置，否则 SDK 会按照 STANDARD 处理。
        * <br>当远端在纯音频状态发送 SEI 时，本端将会收到远端的onUserVideoStart回调，其中 maxProfile 参数为 kNERtcVideoProfileFake
        * ， 表示对端发送 16*16 的 FakeVideo，此时如果本端需要接收远端的SEI信息，只需要订阅一下远端的视频即可，无须设置远端画布。
        * @endif
        */
        kNERtcVideoProfileFake = 6,
    }
    
    /**
    * @if English
    * The video stream type.
    * @endif
    * @if Chinese
    * 视频流类型。
    * @note 大流的分辨率及参数配置高，小流的分辨率及参数配置低。
    * @endif
    */
    public enum RtcRemoteVideoStreamType : int
    {
        /**
        * @if English
        * The default high-resolution stream.
        * @endif
        * @if Chinese
        *  默认大流
        * @endif
        */
        kNERtcRemoteVideoStreamTypeHigh = 0,
        /**
        * @if English
        * The low-resolution stream
        * @endif
        * @if Chinese
        * 小流
        * @endif
        */
        kNERtcRemoteVideoStreamTypeLow = 1,
        /**
        * @if English
        * Unsubscribed.
        * @endif
        * @if Chinese
        * 不订阅
        * @endif
        */
        kNERtcRemoteVideoStreamTypeNone = 2,
    }

    /**
    * @if English
    * Audio device type.
    * @endif
    * @if Chinese
    * 音频设备类型。
    * @endif
    */
    public enum RtcAudioDeviceType : int
    {
        /**
        * @if English
        * Unknown audio device.
        * @endif
        * @if Chinese
        * 未知音频设备
        * @endif
        */
        kNERtcAudioDeviceUnknown = 0,
        /**
        * @if English
        * Audio capture device.
        * @endif
        * @if Chinese
        * 音频采集设备
        * @endif
        */
        kNERtcAudioDeviceRecord,
        /**
        * @if English
        * Audio playback device.
        * @endif
        * @if Chinese
        * 音频播放设备
        * @endif
        */
        kNERtcAudioDevicePlayout,
    }
    
    /**
    * @if English
    * Audio device status types.
    * @endif
    * @if Chinese
    * 音频设备类型状态。
    * @endif
    */
    public enum RtcAudioDeviceState : int
    {
        /**
        * @if English
        * The audio device is activated.
        * @endif
        * @if Chinese
        * 音频设备已激活
        * @endif
        */
        kNERtcAudioDeviceActive = 0,
        /**
        * @if English
        * The audio device is not activated.
        * @endif
        * @if Chinese
        * 音频设备未激活
        * @endif
        */
        kNERtcAudioDeviceUnactive,
    }
    
    /**
    * @if English
    * Audio device types.
    *@endif
    *@if Chinese
    * 音频设备连接类型。
    * @endif
    */
    public enum RtcAudioDeviceTransportType : int
    {
        /**
        * @if English
        * Unknown device.
        * @endif
        * @if Chinese
        * 未知设备
        * @endif
        */
        kNERtcAudioDeviceTransportTypeUnknown = 0,
        /**
        * @if English
        * Bluetooth device.
        * @endif
        * @if Chinese
        * 蓝牙设备
        * @endif
        */
        kNERtcAudioDeviceTransportTypeBluetooth = 1,
        /**
        * @if English
        * Bluetooth stereo device.
        * @endif
        * @if Chinese
        * 蓝牙立体声设备
        * @endif
        */
        kNERtcAudioDeviceTransportTypeBluetoothA2DP = 2,
        /**
        * @if English
        * Bluetooth low energy device.
        * @endif
        * @if Chinese
        * 蓝牙低功耗设备
        * @endif
        */
        kNERtcAudioDeviceTransportTypeBluetoothLE = 3,
        /**
        * @if English
        * USB device.
        * @endif
        * @if Chinese
        * USB设备
        * @endif
        */
        kNERtcAudioDeviceTransportTypeUSB = 4,
        /**
        * @if English
        * HDMI device.
        * @endif
        * @if Chinese
        * HDMI设备
        * @endif
        */
        kNERtcAudioDeviceTransportTypeHDMI = 5,
        /**
        * @if English
        * Built-in device.
        * @endif
        * @if Chinese
        * 内置设备
        * @endif
        */
        kNERtcAudioDeviceTransportTypeBuiltIn = 6,
        /**
        * @if English
        * Thunderbolt interface device.
        * @endif
        * @if Chinese
        * 雷电接口设备
        * @endif
        */
        kNERtcAudioDeviceTransportTypeThunderbolt = 7,
        /**
        * @if English
        * AirPlay device.
        * @endif
        * @if Chinese
        * AirPlay设备
        * @endif
        */
        kNERtcAudioDeviceTransportTypeAirPlay = 8,
        /**
        * @if English
        * Virtual device.
        * @endif
        * @if Chinese
        * 虚拟设备
        * @endif
        */
        kNERtcAudioDeviceTransportTypeVirtual = 9,
        /**
        * @if English
        * Other devices.
        * @endif
        * @if Chinese
        * 其他设备
        * @endif
        */
        kNERtcAudioDeviceTransportTypeOther = 10,
    }
    

    /**
    * @if English
    * Camera device type.
    * @endif
    * @if Chinese
    * 摄像头设备链接类型。
    * @endif
    */
    public enum RtcVideoDeviceTransportType : int
    {
        /**
        * @if English
        * Unknown device.
        * @endif
        * @if Chinese
        * 未知设备
        * @endif
        */
        kNERtcVideoDeviceTransportTypeUnknown = 0,
        /**
        * @if English
        * USB设备
        * @endif
        * @if Chinese
        * USB device.
        * @endif
        */
        kNERtcVideoDeviceTransportTypeUSB = 1,
        /**
        * @if English
        * Virtual device.
        * @endif
        * @if Chinese
        * 虚拟设备
        * @endif
        */
        kNERtcVideoDeviceTransportTypeVirtual = 2,
        /**
        * @if English
        * Other device.
        * @endif
        * @if Chinese
        * 其他设备
        * @endif
        */
        kNERtcVideoDeviceTransportTypeOther = 3,
    }
    

    /**
    * @if English
    * Device details.
    * @endif
    * @if Chinese
    * 设备详细信息。
    * @endif
    */
    public struct RtcDeviceInfo
    {
        /**
        * @if English
        * Device ID
        * @endif
        * @if Chinese
        * 设备ID
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst =256)]
        public string deviceId;
        /**
        * @if English
        * Device name
        * @endif
        * @if Chinese
        * 设备名称
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string deviceName;
        /**
        * @if English
        * Device types, including #RtcAudioDeviceTransportType and #RtcVideoDeviceTransportType
        * @endif
        * @if Chinese
        * 设备链接类型，分别指向 #RtcAudioDeviceTransportType 及 #RtcVideoDeviceTransportType
        * @endif
        */
        public int transportType;
        /**
        * @if English
        * Determines whether it is a non-recommended device
        * @endif
        * @if Chinese
        * 是否是不推荐设备
        * @endif
        */
        [MarshalAs(UnmanagedType.I1)]
        public bool suspectedUnavailable;
        /**
        * @if English
        * Determines whether it is the system default device
        * @endif
        * @if Chinese
        * 是否是系统默认设备
        * @endif
        */
        [MarshalAs(UnmanagedType.I1)]
        public bool systemDefaultDevice;
    }

    /**
    * @if English
    * Video device types.
    * @endif
    * @if Chinese
    * 视频设备类型。
    * @endif
    */
    public enum RtcVideoDeviceType : int
    {
        /**
        * @if English
        * Unknown video device.
        * @endif
        * @if Chinese
        * Video capture device.
        * @endif
        */
        kNERtcVideoDeviceUnknown = 0,
        /**
        * @if English
        * Video capture device.
        * @endif
        * @if Chinese
        * 视频采集设备
        * @endif
        */
        kNERtcVideoDeviceCapture,
    }

    /**
    * @if English
    * Video device status types.
    * @endif
    * @if Chinese
    * 视频设备类型状态。
    * @endif
    */
    public enum RtcVideoDeviceState : int
    {
        /**
        * @if English
        * The video device is added.
        * @endif
        * @if Chinese
        * 视频设备已添加
        * @endif
        */
        kNERtcVideoDeviceAdded = 0,
        /**
        * @if English
        * The video device is removed.
        * @endif
        * @if Chinese
        * 视频设备已拔除
        * @endif
        */
        kNERtcVideoDeviceRemoved,
    }

    /**
    * @if English
    * @enum RtcVideoScalingMode Set the video scaling mode.
    * @endif
    * @if Chinese
    * @enum RtcVideoScalingMode 设置视频缩放模式。
    * @endif
    */
    public enum RtcVideoScalingMode : int
    {
        /**
        * @if English
        * 0: adaptive to the video. The video size is scaled proportionally. All video content is prioritized for display. If the
        * video size does not match the display window size, the unfilled area of the window is be filled with the background color.
        * @endif
        * @if Chinese
        * 0：适应视频，视频尺寸等比缩放。优先保证视频内容全部显示。若视频尺寸与显示视窗尺寸不一致，视窗未被填满的区域填充背景色。
        * @endif
        */
        kNERtcVideoScaleFit = 0,
        /**
        * @if English
        * 1: The video size is scaled non-proportionally. Ensure that all video content is displayed and the window is filled.
        * @endif
        * @if Chinese
        * 1：视频尺寸非等比缩放。保证视频内容全部显示，且填满视窗。
        * @endif
        */
        kNERtcVideoScaleFullFill = 1,
        /**
        * @if English
        * 2: adaptive to the area. The video size is scaled proportionally. Ensure that all areas are filled, and the extra part of
        * the video will be cropped.
        * @endif
        * @if Chinese
        * 2：适应区域，视频尺寸等比缩放。保证所有区域被填满，视频超出部分会被裁剪。
        * @endif
        */
        kNERtcVideoScaleCropFill = 2,
    }
    

    /**
    * @if English
    * @enum RtcVideoMirrorMode Video mirror mode.
    * @endif
    * @if Chinese
    * @enum RtcVideoMirrorMode 视频镜像模式。
    * @endif
    */
    public enum RtcVideoMirrorMode : int
    {
        /**
        * @if English
        * 0: The mirror mode is enabled in Windows and macOS SDKs.
        * @endif
        * @if Chinese
        * 0: Windows/macOS SDK 启用镜像模式。
        * @endif
        */
        kNERtcVideoMirrorModeAuto = 0,
        /**
        * @if English
        * 1: Enables mirror mode.
        * @endif
        * @if Chinese
        * 1: 启用镜像模式。
        * @endif
        */
        kNERtcVideoMirrorModeEnabled = 1,
        /**
        * @if English
        * 2: Disables mirroring mode (default).
        * @endif
        * @if Chinese
        * 2: （默认）关闭镜像模式。
        * @endif
        */
        kNERtcVideoMirrorModeDisabled = 2,
    }


    /**
    *  @if English
    * @enum RtcVideoOrientationMode The video orientation mode.
    * @endif
    * @if Chinese
    * @enum RtcVideoOrientationMode 视频旋转的方向模式。
    * @endif
    */
    public enum RtcVideoOrientationMode : int
    {
        /**
        * @if English
        * (default) The direction of the video output by the SDK in this mode is consistent with the direction of the captured video.
        * The receiver rotates the video based on the received video rotation information. <br>This mode is suitable for scenarios
        * where the receiver can adjust the video direction.
        * - If the captured video is in landscape mode, the output video is also in landscape mode.
        * - If the captured video is in portrait mode, the output video is also in portrait mode.
        * @endif
        * @if Chinese
        * （默认）该模式下 SDK 输出的视频方向与采集到的视频方向一致。接收端会根据收到的视频旋转信息对视频进行旋转。
        * <br>该模式适用于接收端可以调整视频方向的场景。
        * - 如果采集的视频是横屏模式，则输出的视频也是横屏模式。
        * - 如果采集的视频是竖屏模式，则输出的视频也是竖屏模式。
        * @endif
        */
        kNERtcVideoOutputOrientationModeAdaptative = 0,
        /**
        * @if English
        * In this mode, the SDK always outputs videos in landscape mode. If the captured video is in portrait mode, the video encoder
        * crops the video. <br>This mode is suitable for scenes where the receiver cannot adjust the video direction, such as CDN
        * relayed streaming.
        * @endif
        * @if Chinese
        * 该模式下 SDK 固定输出横屏模式的视频。如果采集到的视频是竖屏模式，则视频编码器会对其进行裁剪。
        * <br>该模式适用于接收端无法调整视频方向的场景，例如旁路推流。
        * @endif
        */
        kNERtcVideoOutputOrientationModeFixedLandscape = 1,
        /**
        * @if English
        * In this mode, the SDK always outputs videos in portrait mode. If the captured video is in landscape mode, the video encoder
        * crops the video. <br>This mode is suitable for scenes where the receiver cannot adjust the video direction, such as CDN
        * relayed streaming.
        * @endif
        * @if Chinese
        * 该模式下 SDK 固定输出竖屏模式的视频，如果采集到的视频是横屏模式，则视频编码器会对其进行裁剪。
        * <br>该模式适用于接收端无法调整视频方向的场景，例如旁路推流。
        * @endif
        */
        kNERtcVideoOutputOrientationModeFixedPortrait = 2,
    }
    
    /**
    * @if English
    * The state of network connection
    * @endif
    * @if Chinese
    * 连接状态
    * @endif
    */
    public enum RtcConnectionStateType : int
    {
        /**
        * @if English
        * The client is disconnected.
        * @endif
        * @if Chinese
        * 未加入房间。
        * @endif
        */
        kNERtcConnectionStateDisconnected = 1,
        /**
        * @if English
        * The client is connecting to the room server.
        * @endif
        * @if Chinese
        * 正在加入房间。
        * @endif
        */
        kNERtcConnectionStateConnecting = 2,
        /**
        * @if English
        * The client is connected to the room server.
        * @endif
        * @if Chinese
        * 加入房间成功。
        * @endif
        */
        kNERtcConnectionStateConnected = 3,
        /**
        * @if English
        * The client is reconnecting to the room server.
        * @endif
        * @if Chinese
        * 正在尝试重新加入房间。
        * @endif
        */
        kNERtcConnectionStateReconnecting = 4,
        /**
        * @if English
        * The client fails to connect to the room server.
        * @endif
        * @if Chinese
        * 加入房间失败。
        * @endif
        */
        kNERtcConnectionStateFailed = 5,
    }
    

    /**
    * @if English
    * The reason for the connection state change.
    * @endif
    * @if Chinese
    * 连接状态变更原因
    * @endif
    */
    public enum RtcReasonConnectionChangedType : int
    {
        /**
        * @if English
        * The client leaves the room.
        * @endif
        * @if Chinese
        * 离开房间
        * @endif
        */
        kNERtcReasonConnectionChangedLeaveChannel = 1,
        /**
        * @if English
        * The room is closed.
        * @endif
        * @if Chinese
        * 房间被关闭
        * @endif
        */
        kNERtcReasonConnectionChangedChannelClosed = 2,
        /**
        * @if English
        * The user is removed from the room.
        * @endif
        * @if Chinese
        * 用户被踢
        * @endif
        */
        kNERtcReasonConnectionChangedBeKicked = 3,
        /**
        * @if English
        * The service times out.
        * @endif
        * @if Chinese
        * 服务超时
        * @endif
        */
        kNERtcReasonConnectionChangedTimeOut = 4,
        /**
        * @if English
        * The user joins the room.
        * @endif
        * @if Chinese
        * 加入房间
        * @endif
        */
        kNERtcReasonConnectionChangedJoinChannel = 5,
        /**
        * @if English
        * The user has joined the room.
        * @endif
        * @if Chinese
        * 加入房间成功
        * @endif
        */
        kNERtcReasonConnectionChangedJoinSucceed = 6,
        /**
        * @if English
        * The user rejoins the room successfully (reconnection).
        * @endif
        * @if Chinese
        * 重新加入房间成功（重连）
        * @endif
        */
        kNERtcReasonConnectionChangedReJoinSucceed = 7,
        /**
        * @if English
        * The media stream gets disconnected.
        * @endif
        * @if Chinese
        * 媒体连接断开
        * @endif
        */
        kNERtcReasonConnectionChangedMediaConnectionDisconnected = 8,
        /**
        * @if English
        * The signaling channel gets disconnected.
        * @endif
        * @if Chinese
        * 信令连接断开
        * @endif
        */
        kNERtcReasonConnectionChangedSignalDisconnected = 9,
        /**
        * @if English
        * The request to join the room fails.
        * @endif
        * @if Chinese
        * 请求房间失败
        * @endif
        */
        kNERtcReasonConnectionChangedRequestChannelFailed = 10,
        /**
        * @if English
        * The user fails to join the room.
        * @endif
        * @if Chinese
        * 加入房间失败
        * @endif
        */
        kNERtcReasonConnectionChangedJoinChannelFailed = 11,
        /**
        * @if English
        * The server IP is reallocated.
        * @endif
        * @if Chinese
        * 重新分配了服务端IP
        * @endif
        */
        kNERtcReasonConnectionChangedReDispatch = 12,
    }

    /**
    * @if English
    * Audio volume information. An array that contains the user ID and volume information of each speaker.
    * @endif
    * @if Chinese
    * 声音音量信息。一个数组，包含每个说话者的用户 ID 和音量信息。
    * @endif
    */
    public struct RtcAudioVolumeInfo
    {
        /**
        * @if English
        * The user ID of the speaker. If the returned uid is 0, the user refers to the local user by default.
        * @endif
        * @if Chinese
        * 说话者的用户 ID。如果返回的 uid 为 0，则默认为本地用户。
        * @endif
        */
        public ulong uid;
        /**
        * @if English
        * The speaker's volume, the value range is from 0 (lowest) to 100 (highest).
        * @endif
        * @if Chinese
        * 说话者的音量，范围为 0（最低）- 100（最高）。
        * @endif
        */
        public uint volume;
    }

    /**
    * @if English
    * Stats related to calls.
    * @endif
    * @if Chinese
    * 通话相关的统计信息。
    * @endif
    */
    public struct RtcStats
    {
        /**
        * @if English
        * The CPU usage occupied by the app (%).
        * @endif
        * @if Chinese
        * 当前 App 的 CPU 使用率 (%)。
        * @endif
        */
        public uint cpuAppUsage;
        /**
        * @if English
        * The CPU idle rate of the current system (%).
        * @endif
        * @if Chinese
        * 当前系统的 CPU 空闲率 (%)。
        * @endif
        */
        public uint cpuIdleUsage;
        /**
        * @if English
        * The current system CPU usage (%).
        * @endif
        * @if Chinese
        * 当前系统的 CPU 使用率 (%)。
        * @endif
        */
        public uint cpuTotalUsage;
        /**
        * @if English
        * The current memory usage occupied by the app (%).
        * @endif
        * @if Chinese
        * 当前App的内存使用率 (%)。
        * @endif
        */
        public uint memoryAppUsage;
        /**
        * @if English
        * The current system memory usage (%).
        * @endif
        * @if Chinese
        * 当前系统的内存使用率 (%)。
        * @endif
        */
        public uint memoryTotalUsage;
        /**
        * @if English
        * The current memory used by the app (KB).
        * @endif
        * @if Chinese
        * 当前App的内存使用量 (KB)。
        * @endif
        */
        public uint memoryAppKbytes;
        /**
        * @if English
        * Call duration in seconds.
        * @endif
        * @if Chinese
        * 通话时长（秒）。
        * @endif
        */
        public int totalDuration;
        /**
        * @if English
        * The number of bytes sent. This is the cumulative value. (bytes)
        * @endif
        * @if Chinese
        * 发送字节数，累计值。(bytes)
        * @endif
        */
        public ulong txBytes;
        /**
        * @if English
        * The number of bytes received. This is the cumulative value. (bytes)
        * @endif
        * @if Chinese
        * 接收字节数，累计值。(bytes)
        * @endif
        */
        public ulong rxBytes;
        /**
        * @if English
        * The number of audio bytes sent. This is the cumulative value. (bytes)
        * @endif
        * @if Chinese
        * 音频发送字节数，累计值。(bytes)
        * @endif
        */
        public ulong txAudioBytes;
        /**
        * @if English
        * The number of video bytes sent. This is the cumulative value. (bytes)
        * @endif
        * @if Chinese
        * 视频发送字节数，累计值。(bytes)
        * @endif
        */
        public ulong txVideoBytes;
        /**
        * @if English
        * The number of audio bytes received. This is the cumulative value. (bytes)
        * @endif
        * @if Chinese
        * 音频接收字节数，累计值。(bytes)
        * @endif
        */
        public ulong rxAudioBytes;
        /**
        * @if English
        * The number of video bytes received. This is the cumulative value. (bytes)
        * @endif
        * @if Chinese
        * 视频接收字节数，累计值。(bytes)
        * @endif
        */
        public ulong rxVideoBytes;
        /**
        * @if English
        * Audio bitrate for publishing. (kbps)
        * @endif
        * @if Chinese
        * 音频发送码率。(kbps)
        * @endif
        */
        public int txAudioKbitrate;
        /**
        * @if English
        * Audio bitrate for subscribed streams. (kbps)
        * @endif
        * @if Chinese
        * 音频接收码率。(kbps)
        * @endif
        */
        public int rxAudioKbitrate;
        /**
        * @if English
        * Video bitrate for publishing. (kbps)
        * @endif
        * @if Chinese
        * 视频发送码率。(kbps)
        * @endif
        */
        public int txVideoKbitrate;
        /**
        * @if English
        * Video bitrate for subscribed streams. (kbps)
        * @endif
        * @if Chinese
        * 视频接收码率。(kbps)
        * @endif
        */
        public int rxVideoKbitrate;
        /**
        * @if English
        * Average uplink round trip time. (ms)
        * @endif
        * @if Chinese
        * 上行平均往返时延rtt(ms)
        * @endif
        */
        public int upRtt;
        /**
        * @if English
        * Average downlink round-trip time. (ms)
        * @endif
        * @if Chinese
        * 下行平均往返时延rtt(ms)
        * @endif
        */
        public int downRtt;
        /**
        * @if English
        * The actual uplink packet loss rate of the local audio stream. (%)
        * @endif
        * @if Chinese
        * 本地上行音频实际丢包率。(%)
        * @endif
        */
        public int txAudioPacketLossRate;
        /**
        * @if English
        * The actual uplink packet loss rate of the local video stream. (%)
        * @endif
        * @if Chinese
        * 本地上行视频实际丢包率。(%)
        * @endif
        */
        public int txVideoPacketLossRate;
        /**
        * @if English
        * The actual number of lost packets for local upstream audio.
        * @endif
        * @if Chinese
        * 本地上行音频实际丢包数。
        * @endif
        */
        public int txAudioPacketLossSum;
        /**
        * @if English
        * Actual number of lost packets for local upstream video.
        * @endif
        * @if Chinese
        * 本地上行视频实际丢包数。
        * @endif
        */
        public int txVideoPacketLossSum;
        /**
        * @if English
        * Local upstream audio jitter calculation. (ms)
        * @endif
        * @if Chinese
        * 本地上行音频抖动计算。(ms)
        * @endif
        */
        public int txAudioJitter;
        /**
        * @if English
        * Local uplink video jitter calculation. (ms)
        * @endif
        * @if Chinese
        * 本地上行视频抖动计算。(ms)
        * @endif
        */
        public int txVideoJitter;
        /**
        * @if English
        * Actual packet loss of local downlink audio stream. (%)
        * @endif
        * @if Chinese
        * 本地下行音频实际丢包率。(%)
        * @endif
        */
        public int rxAudioPacketLossRate;
        /**
        * @if English
        * Actual local downstream video packet loss rate. (%)
        * @endif
        * @if Chinese
        * 本地下行视频实际丢包率。(%)
        * @endif
        */
        public int rxVideoPacketLossRate;
        /**
        * @if English
        * Actual number of lost packets for local downstream audio.
        * @endif
        * @if Chinese
        * 本地下行音频实际丢包数。
        * @endif
        */
        public int rxAudioPacketLossSum;
        /**
        * @if English
        * Actual number of lost packets for local downstream video.
        * @endif
        * @if Chinese
        * 本地下行视频实际丢包数。
        * @endif
        */
        public int rxVideoPacketLossSum;
        /**
        * @if English
        * Local downstream audio jitter calculation. (ms)
        * @endif
        * @if Chinese
        * 本地下行音频抖动计算。(ms)
        * @endif
        */
        public int rxAudioJitter;
        /**
        * @if English
        *  Local downstream video jitter calculation. (ms)
        * @endif
        * @if Chinese
        * 本地下行视频抖动计算。(ms)
        * @endif
        */
        public int rxVideoJitter;
    }

    /**
    * @if English
    * Stats of each local video stream.
    * @endif
    * @if Chinese
    * 本地视频单条流上传统计信息。
    * @endif
    */
    public struct RtcVideoLayerSendStats
    {
        /**
        * @if English
        * Stream type: 1. mainstream. 2. substream.
        * @endif
        * @if Chinese
        * 流类型： 1、主流，2、辅流。
        * @endif
        */
        public int layerType;
        /**
        * @if English
        * Video stream width (pixels).
        * @endif
        * @if Chinese
        * 视频流宽（像素）。
        * @endif
        */
        public int width;
        /**
        * @if English
        * Video stream height (pixels).
        * @endif
        * @if Chinese
        * 视频流高（像素）。
        * @endif
        */
        public int height;
        /**
        * @if English
        * @endif
        * @if Chinese
        * 视频采集宽（像素）。
        * @endif
        */
        public int captureWidth;
        /**
        * @if English
        * @endif
        * @if Chinese
        * 视频采集高（像素）。
        * @endif
        */
        public int captureHeight;
        /**
        * @if English
        * Video capture frame rate.
        * @endif
        * @if Chinese
        * 视频采集帧率。
        * @endif
        */
        public int captureFrameRate;
        /**
        * @if English
        * Video rendering frame rate.
        * @endif
        * @if Chinese
        * 视频渲染帧率。
        * @endif
        */
        public int renderFrameRate;
        /**
        * @if English
        * Encoding frame rate.
        * @endif
        * @if Chinese
        * 编码帧率。
        * @endif
        */
        public int encoderFrameRate;
        /**
        * @if English
        * Publishing frame rate.
        * @endif
        * @if Chinese
        * 发送帧率。
        * @endif
        */
        public int sentFrameRate;
        /**
        * @if English
        * Publishing bitrate(kbps).
        * @endif
        * @if Chinese
        * 发送码率(Kbps)。
        * @endif
        */
        public int sentBitrate;
        /**
        * @if English
        * Encoder expected bitrate (kbps).
        * @endif
        * @if Chinese
        * 编码器目标码率(Kbps)。
        * @endif
        */
        public int targetBitrate;
        /**
        * @if English
        * Encoder actual bitrate (kbps).
        * @endif
        * @if Chinese
        * 编码器实际编码码率(Kbps)。
        * @endif
        */
        public int encoderBitrate;
        /**
        * @if English
        * The name of the video encoder.
        * @endif
        * @if Chinese
        * 视频编码器名字。
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst =256)]
        public string codecName;
    }

    /**
    * @if English
    * The stats of the uplink local video stream.
    * @endif
    * @if Chinese
    * 本地视频流上传统计信息。
    * @endif
    */
    public struct RtcVideoSendStats
    {
        /**
        * @if English
        * Video stream information array.
        * @endif
        * @if Chinese
        * 视频流信息数组。
        * @endif
        */
        public RtcVideoLayerSendStats[] videoLayersList;
    }

    /**
    * @if English
    * The stats of each remote video stream.
    * @endif
    * @if Chinese
    * 远端视频单条流的统计信息。
    * @endif
    */
    public struct RtcVideoLayerRecvStats
    {
        /**
        * @if English
        * Stream type: 1. mainstream. 2. substream.
        * @endif
        * @if Chinese
        * 流类型： 1、主流，2、辅流。
        * @endif
        */
        public int layerType;
        /**
        * @if English
        * Video stream width (pixels).
        * @endif
        * @if Chinese
        * 视频流宽（像素）。
        * @endif
        */
        public int width;
        /**
        * @if English
        * Video stream height (pixels).
        * @endif
        * @if Chinese
        * 视频流高（像素）。
        * @endif
        */
        public int height;
        /**
        * @if English
        * The bitrate of the received stream (kbps).
        * @endif
        * @if Chinese
        * 接收到的码率(Kbps)。
        * @endif
        */
        public int receivedBitrate;
        /**
        * @if English
        * The frame rate of the received stream (fps).
        * @endif
        * @if Chinese
        * 接收到的帧率 (fps)。
        * @endif
        */
        public int receivedFrameRate;
        /**
        * @if English
        * Decoding frame rate (fps).
        * @endif
        * @if Chinese
        * 解码帧率 (fps)。
        * @endif
        */
        public int decoderFrameRate;
        /**
        * @if English
        * Rendering frame rate (fps).
        * @endif
        * @if Chinese
        * 渲染帧率 (fps)。
        * @endif
        */
        public int renderFrameRate;
        /**
        * @if English
        * Downlink packet loss rate (%).
        * @endif
        * @if Chinese
        * 下行丢包率(%)。
        * @endif
        */
        public int packetLossRate;
        /**
        * @if English
        * The downlink video freeze cumulative time (ms).
        * @endif
        * @if Chinese
        * 用户的下行视频卡顿累计时长(ms)。
        * @endif
        */
        public int totalFrozenTime;
        /**
        * @if English
        * The average freeze rate of the user's downlink video stream (%).
        * @endif
        * @if Chinese
        * 用户的下行视频平均卡顿率(%)。
        * @endif
        */
        public int frozenRate;
        /**
        * @if English
        * The codec name.
        * @endif
        * @if Chinese
        * 视频解码器名字。
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string codecName;
    }

    /**
    * @if English
    * Remote video stream stats.
    * @endif
    * @if Chinese
    * 远端视频流的统计信息。
    * @endif
    */
    public struct RtcVideoRecvStats
    {
        /**
        * @if English
        * The user ID used to identify the video stream.
        * @endif
        * @if Chinese
        * 用户 ID，指定是哪个用户的视频流。
        * @endif
        */
        public ulong uid;
        /**
        * @if English
        * Video stream information array.
        * @endif
        * @if Chinese
        * 视频流信息数组。
        * @endif
        */
        public RtcVideoLayerRecvStats[] videoLayersList;
    }

    /**
    * @if English
    * The local audio stream stats.
    * @endif
    * @if Chinese
    * 本地音频流上传统计信息。
    * @endif
    */
    public struct RtcAudioSendStats
    {
        /**
        * @if English
        * The number of channels currently collected.
        * @endif
        * @if Chinese
        * 当前采集声道数。
        * @endif
        */
        public int numChannels;
        /**
        * @if English
        * The sample rate of local uplink audio stream.
        * @endif
        * @if Chinese
        * 本地上行音频采样率。
        * @endif
        */
        public int sentSampleRate;
        /**
        * @if English
        * Publishing bitrate after last report (kbps).
        * @endif
        * @if Chinese
        * （上次统计后）发送码率(Kbps)。
        * @endif
        */
        public int sentBitrate;
        /**
        * @if English
        * Audio packet loss rate in a specific time (%).
        * @endif
        * @if Chinese
        * 特定时间内的音频丢包率 (%)。
        * @endif
        */
        public int audioLossRate;
        /**
        * @if English
        * Round trip time.
        * @endif
        * @if Chinese
        * RTT。
        * @endif
        */
        public long rtt;
        /**
        * @if English
        * Volume range: 0 (lowest) to 100 (highest).
        * @endif
        * @if Chinese
        * 音量，范围为 0（最低）- 100（最高）。
        * @endif
        */
        public uint volume;
        /**
        * @if English
        * @endif
        * @if Chinese
        * 采集音量，范围为 0（最低）- 100（最高）。
        * @endif
        */
        public uint capVolume;
    }

    /**
    * @if English
    * The stats of the audio stream from a remote user.
    * @endif
    * @if Chinese
    * 远端用户的音频统计。
    * @endif
    */
    public struct RtcAudioRecvStats
    {
        /**
        * @if English
        * The user ID used to identify the audio stream.
        * @endif
        * @if Chinese
        * 用户 ID，指定是哪个用户的音频流。
        * @endif
        */
        public ulong uid;
        /**
        * @if English
        * The bitrate of the received audio stream after the last report (kbps).
        * @endif
        * @if Chinese
        * （上次统计后）接收到的码率(Kbps)。
        * @endif
        */
        public int receivedBitrate;
        /**
        * @if English
        * The user's downlink audio freeze cumulative time (ms).
        * @endif
        * @if Chinese
        * 用户的下行音频卡顿累计时长(ms)。
        * @endif
        */
        public int totalFrozenTime;
        /**
        * @if English
        * The user's downstream audio average freeze rate (%).
        * @endif
        * @if Chinese
        * 用户的下行音频平均卡顿率(%)。
        * @endif
        */
        public int frozenRate;
        /**
        * @if English
        * Audio packet loss rate in a specific time (%).
        * @endif
        * @if Chinese
        * 特定时间内的音频丢包率 (%)。
        * @endif
        */
        public int audioLossRate;
        /**
        * @if English
        * Volume range: 0 (lowest) to 100 (highest).
        * @endif
        * @if Chinese
        * 音量，范围为 0（最低）- 100（最高）。
        * @endif
        */
        public uint volume;
    }

    /**
    * @if English
    * @enum RtcNetworkQualityType Network quality type.
    * @endif
    * @if Chinese
    * @enum RtcNetworkQualityType 网络质量类型。
    * @endif
    */
    public enum RtcNetworkQualityType : int
    {
        /**
        * @if English
        * 0: Unknown network quality.
        * @endif
        * @if Chinese
        * 0: 网络质量未知。
        * @endif
        */
        kNERtcNetworkQualityUnknown = 0,
        /**
        * @if English
        * 1: Excellent network quality.
        * @endif
        * @if Chinese
        * 1: 网络质量极好。
        * @endif
        */
        kNERtcNetworkQualityExcellent = 1,
        /**
        * @if English
        * 2: Good network quality is close to the excellent level but has the bitrate is lower an excellent network.
        * @endif
        * @if Chinese
        * 2: 用户主观感觉和 `kNERtcNetworkQualityExcellent` 类似，但码率可能略低于 `kNERtcNetworkQualityExcellent`。
        * @endif
        */
        kNERtcNetworkQualityGood = 2,
        /**
        * @if English
        * 3: Poor network does not affect communication.
        * @endif
        * @if Chinese
        * 3: 用户主观感受有瑕疵但不影响沟通。
        * @endif
        */
        kNERtcNetworkQualityPoor = 3,
        /**
        * @if English
        * 4: Users can communicate with each other without smoothness.
        * @endif
        * @if Chinese
        * 4: 勉强能沟通但不顺畅。
        * @endif
        */
        kNERtcNetworkQualityBad = 4,
        /**
        * @if English
        * 5: The network quality is very poor. Basically users are unable to communicate.
        * @endif
        * @if Chinese
        * 5: 网络质量非常差，基本不能沟通。
        * @endif
        */
        kNERtcNetworkQualityVeryBad = 5,
        /**
        * @if English
        * 6: Users are unable to communicate with each other.
        * @endif
        * @if Chinese
        * 6: 完全无法沟通。
        * @endif
        */
        kNERtcNetworkQualityDown = 6,
    }

    /**
    * @if English
    * Network quality stats.
    * @endif
    * @if Chinese
    * 网络质量统计信息。
    * @endif
    */
    public struct RtcNetworkQualityInfo
    {
        /**
        * @if English
        * The user ID used to identify the network quality stats.
        * @endif
        * @if Chinese
        * 用户 ID，指定是哪个用户的网络质量统计。
        * @endif
        */
        public ulong uid;
        /**
        * @if English
        * The uplink network quality. For more information, see #RtcNetworkQualityType.
        * @endif
        * @if Chinese
        * 该用户的上行网络质量，详见 #RtcNetworkQualityType.
        * @endif
        */
        public RtcNetworkQualityType txQuality;
        /**
        * @if English
        * The downlink network quality. For more information, see #RtcNetworkQualityType.
        * @endif
        * @if Chinese
        * 该用户的下行网络质量，详见 #RtcNetworkQualityType.
        * @endif
        */
        public RtcNetworkQualityType rxQuality;
    }

    /**
    * @if English
    * @enum RtcVideoCropMode Video cropping mode.
    * @endif
    * @if Chinese
    * @enum RtcVideoCropMode 视频画面裁剪模式。
    * @endif
    */
    public enum RtcVideoCropMode : int
    {
        /**
        * @if English
        * Device Default
        * @endif
        * @if Chinese
        * 设备默认裁剪模式。
        * @endif
        */
        kNERtcVideoCropModeDefault = 0,
        /**
        * @if English
        * 16:9
        * @endif
        * @if Chinese
        * 16:9
        * @endif
        */
        kNERtcVideoCropMode16x9 = 1,
        /**
        * @if English
        * 4:3
        * @endif
        * @if Chinese
        * 4:3
        * @endif
        */
        kNERtcVideoCropMode4x3 = 2,
        /**
        * @if English
        * 1:1
        * @endif
        * @if Chinese
        * 1:1
        * @endif
        */
        kNERtcVideoCropMode1x1 = 3,
    }

    /**
    * @if English
    * @enum RtcVideoFramerateType Video frame rate.
    * @endif
    * @if Chinese
    * @enum RtcVideoFramerateType 视频帧率。
    * @endif
    */
    public enum RtcVideoFramerateType : int
    {
        /**
        * @if English
        * default frame rate
        * @endif
        * @if Chinese
        * 默认帧率
        * @endif
        */
        kNERtcVideoFramerateFpsDefault = 0,
        /**
        * @if English
        * 7 frames per second
        * @endif
        * @if Chinese
        * 7帧每秒
        * @endif
        */
        kNERtcVideoFramerateFps7 = 7,
        /**
        * @if English
        * 10 frames per second
        * @endif
        * @if Chinese
        * 10帧每秒
        * @endif
        */
        kNERtcVideoFramerateFps10 = 10,
        /**
        * @if English
        * 15 frames per second
        * @endif
        * @if Chinese
        * 15帧每秒
        * @endif
        */
        kNERtcVideoFramerateFps15 = 15,
        /**
        * @if English
        * 24 frames per second
        * @endif
        * @if Chinese
        * 24帧每秒
        * @endif
        */
        kNERtcVideoFramerateFps24 = 24,
        /**
        * @if English
        * 30 frames per second
        * @endif
        * @if Chinese
        * 30帧每秒
        * @endif
        */
        kNERtcVideoFramerateFps30 = 30,
        /**
        * @if English
        * 60 frames per second
        * @endif
        * @if Chinese
        * 60帧每秒
        * @endif
        */
        kNERtcVideoFramerateFps60 = 60,
    }

    /**
    * @if English
    * @enum RtcDegradationPreference Video encoding strategy.
    * @endif
    * @if Chinese
    * @enum RtcDegradationPreference 视频编码策略。
    * @endif
    */
    public enum RtcDegradationPreference : int
    {
        /**
        * @if English
        * - By default, adjust the adaptation preference based on scenarios.
        * - In communication scenes, select kNERtcDegradationBalanced mode to maintain a balance between the frame rate and video
        * quality.
        * - In live streaming scenes, select kNERtcDegradationMaintainQuality mode and reduce the frame rate to ensure video quality.
        * @endif
        * @if Chinese
        * - （默认）根据场景模式调整适应性偏好。
        * - 通信场景中，选择kNERtcDegradationBalanced 模式，在编码帧率和视频质量之间保持平衡。
        * - 直播场景中，选择kNERtcDegradationMaintainQuality 模式，降低编码帧率以保证视频质量。
        * @endif
        */
        kNERtcDegradationDefault = 0,
        /**
        * @if English
        * Smooth streams come first. Reduce video quality to ensure the frame rate. In a weak network environment, you can reduce the
        * video quality to ensure a smooth video playback. In this case, the image quality is reduced and the pictures become
        * blurred, but the video can be kept smooth.
        * @endif
        * @if Chinese
        * 流畅优先，降低视频质量以保证编码帧率。在弱网环境下，降低视频清晰度以保证视频流畅，此时画质降低，画面会变得模糊，但可以保持视频流畅。
        * @endif
        */
        kNERtcDegradationMaintainFramerate = 1,
        /**
        * @if English
        * Clarity is prioritized. Reduce the frame rate to ensure video quality. In a weak network environment, you can reduce the
        * video frame rate to ensure that the video is clear. In this case, a certain amount of freezes may occur at this time.
        * @endif
        * @if Chinese
        * 清晰优先，降低编码帧率以保证视频质量。在弱网环境下，降低视频帧率以保证视频清晰，此时可能会出现一定卡顿。
        * @endif
        */
        kNERtcDegradationMaintainQuality = 2,
        /**
        * @if English
        * Maintain a balance between the frame rate and video quality.
        * @endif
        * @if Chinese
        * 在编码帧率和视频质量之间保持平衡。
        * @endif
        */
        kNERtcDegradationBalanced = 3,
    }

    /**
    * @if English
    * The video encoding profile configuration.
    * @endif
    * @if Chinese
    * 视频编码属性配置。
    * @endif
    */
    public struct RtcVideoConfig
    {
        /**
        * @if English
        * The resolution of video encoding used to measure encoding quality. For more information, see #RtcVideoProfileType 
        * @endif
        * @if Chinese
        * 视频编码的分辨率，用于衡量编码质量。详细信息请参考 #RtcVideoProfileType 。
        * @endif
        */
        public RtcVideoProfileType maxProfile;
        /**
        * @if English
        * Video encoding resolution, an indicator of encoding quality, is represented by width x height. You can select this profile
        * or maxProfile. <br>The width represents the pixels of the video frame on the horizontal axis. You can enter a custom width.
        * - If you set the value to a negative number, the maxProfile setting is used.
        * - If you need to customize the resolution, set this profile, and maxProfile becomes invalid.
        * If the width and height of the custom video input are invalid, the width and height are automatically scaled based on
        * maxProfile.
        * @endif
        * @if Chinese
        * 视频编码分辨率，衡量编码质量，以宽x高表示。与maxProfile属性二选一。
        * <br>width表示视频帧在横轴上的像素，即自定义宽。
        * - 设置为负数时表示采用 maxProfile 档位。
        * - 如果需要自定义分辨率场景，则设置此属性，maxProfile属性失效。
        * 自定义视频输入width和height无效，会自动根据 maxProfile 缩放。
        * @endif
        */
        public uint width;
        /**
        * @if English
        * Video encoding resolution, an indicator of encoding quality, is represented by width x height. You can select this profile
        * or maxProfile. <br>The height represents the pixels of the video frame on the vertical axis. You can enter a custom height.
        * - If you set the value to a negative number, the maxProfile setting is used.
        * - If you need to customize the resolution, set this profile, and maxProfile becomes invalid.
        * If the width and height of the custom video input are invalid, the width and height are automatically scaled based on
        * maxProfile.
        * @endif
        * @if Chinese
        * 视频编码分辨率，衡量编码质量，以宽x高表示。与maxProfile属性二选一。
        * <br>height表示视频帧在纵轴上的像素，即自定义高。
        * - 设置为负数时表示采用 maxProfile 档位。
        * - 如果需要自定义分辨率场景，则设置此属性，maxProfile属性失效。
        * <br>自定义视频输入width和height无效，会自动根据 maxProfile 缩放。
        * @endif
        */
        public uint height;
        /**
        * @if English
        * Video crop mode, aspect ratio. The default value is kNERtcVideoCropModeDefault. For more information, see
        * NERtcVideoCropMode.
        * @endif
        * @if Chinese
        * 视频裁剪模式，宽高比。默认为 kNERtcVideoCropModeDefault。详细信息请参考 #RtcVideoCropMode 。
        * @endif
        */
        public RtcVideoCropMode cropMode;
        /**
        * @if English
        * The frame rate of the mainstream video encoding. For more information, see #RtcVideoFramerateType . By default, the frame
        * rate is determined based on maxProfile.
        * - maxProfile >= STANDARD. frameRate = FRAMERATEFPS30.
        * - maxProfile < STANDARD. frameRate = FRAMERATEFPS15.
        * @endif
        * @if Chinese
        * 主流的视频编码的帧率。详细信息请参考 #RtcVideoFramerateType 。默认根据设置的maxProfile决定帧率。
        * - maxProfile >= STANDARD，frameRate = FRAMERATEFPS30。
        * - maxProfile < STANDARD，frameRate = FRAMERATEFPS15。
        * @endif
        */
        public RtcVideoFramerateType framerate;
        /**
        * @if English
        * The minimum frame rate for video encoding. The default value is 0, which indicates that the minimum frame rate is used by
        * default
        * @endif
        * @if Chinese
        * 视频编码的最小帧率。默认为 0，表示使用默认最小帧率
        * @endif
        */
        public RtcVideoFramerateType minFramerate;
        /**
        * @if English
        * Video encoding bitrate (kbps), use the default value if the setting is set to 0.
        * @endif
        * @if Chinese
        * 视频编码码率kbps，取0时使用默认值
        * @endif
        */
        public uint bitrate;
        /**
        * @if English
        * The minimum bitrate of video encoding in kbps. You can manually set the required minimum bitrate based on your business
        * requirements. If the bitrate is set to 0, the SDK computes and processes automatically.
        * @endif
        * @if Chinese
        * 视频编码的最小码率，单位为 Kbps。您可以根据场景需要，手动设置想要的最小码率，若设置为0，SDK 将会自行计算处理。
        * @endif
        */
        public uint minBitrate;
        /**
        * @if English
        * Video encoding degradation preference when the bandwidth is limited. For more information, see #RtcDegradationPreference .
        * @endif
        * @if Chinese
        * 带宽受限时的视频编码降级偏好。详细信息请参考 #RtcDegradationPreference 。
        * @endif
        */
        public RtcDegradationPreference degradationPreference;
        /**
        * @if English
        * Set the mirror mode for the local video encoding. The mirror mode is used for publishing the local video stream. The
        * setting only affects the video picture seen by remote users.
        * @endif
        * @if Chinese
        * 设置本地视频编码的镜像模式，即本地发送视频的镜像模式，只影响远端用户看到的视频画面。
        * @endif
        */
        public RtcVideoMirrorMode mirrorMode;
        /**
        * @if English
        * Set the orientation mode of the local video encoding, The orientation mode is used for publishing the local video stream,
        * which only affects the video picture seen by remote users.
        * @endif
        * @if Chinese
        * 设置本地视频编码的方向模式，即本地发送视频的方向模式，只影响远端用户看到的视频画面。
        * @endif
        */
        public RtcVideoOrientationMode orientationMode;
    }

    /**
    * @if English
    * Video frame rate callback.
    * @param uid         The user ID
    * @param frame       The video frame object
    *
    * @endif
    * @if Chinese
    * 视频帧数据回调
    * @param  uid          用户id
    * @param  frame        视频帧
    * @endif
    */
//     public delegate void OnRawDataVideoFrameCallback(ulong uid, RtcVideoFrame frame);
//     public delegate void OnTexture2DVideoFrameCallback(ulong uid, UnityEngine.Texture2D texture, RtcVideoRotation rotation);

    /**
    * @if English
    * Configuration parameters for screen sharing encoding.
    * @endif
    * @if Chinese
    * 屏幕共享编码参数配置。
    * @endif
    */
    public enum RtcScreenProfileType
    {
        /**
        * @if English
        * 640x480, 5fps.
        * @endif
        * @if Chinese
        * 640x480, 5fps
        * @endif
        */
        kNERtcScreenProfile480P = 0,
        /**
        * @if English
        * 1280x720, 5fps.
        * @endif
        * @if Chinese
        * 1280x720, 5fps
        * @endif
        */
        kNERtcScreenProfileHD720P = 1,
        /**
        * @if English
        * 1920x1080, 5fps. This is the default value.
        * @endif
        * @if Chinese
        * 1920x1080, 5fps。默认
        * @endif
        */
        kNERtcScreenProfileHD1080P = 2,
        /**
        * @if English
        * Custom.
        * @endif
        * @if Chinese
        * 自定义
        * @endif
        */
        kNERtcScreenProfileCustom = 3,
        /**
        * @if English
        * None
        * @endif
        * @if Chinese
        * 无效果。
        * @endif
        */
        kNERtcScreenProfileNone = 4,
        /**
        * @if English
        * 1920x1080, 5fps. This is the default value.
        * @endif
        * @if Chinese
        * 1920x1080, 5fps。
        * @endif
        */
        kNERtcScreenProfileMAX = kNERtcScreenProfileHD1080P,
    }

    /**
    * @if English
    * Screen sharing status.
    * @endif
    * @if Chinese
    * 屏幕分享状态
    * @endif
    */
    public enum RtcScreenCaptureStatus
    {
        /**
        * @if English
        * Starts screen sharing.
        * @endif
        * @if Chinese
        * 开始屏幕共享。
        * @endif
        */
        kNERtcScreenCaptureStatusStart = 1,

        /**
        * @if English
        * Pauses screen sharing.
        * @endif
        * @if Chinese
        * 暂停屏幕共享。
        * @endif
        */
        kNERtcScreenCaptureStatusPause = 2,

        /**
        * @if English
        * Resumes screen sharing.
        * @endif
        * @if Chinese
        * 恢复屏幕共享。
        * @endif
        */
        kNERtcScreenCaptureStatusResume = 3,

        /**
        * @if English
        * Stops screen sharing.
        * @endif
        * @if Chinese
        * 停止屏幕共享。
        * @endif
        */
        kNERtcScreenCaptureStatusStop = 4,

        /**
        * @if English
        * The target window for screen sharing is covered.
        * @endif
        * @if Chinese
        * 屏幕分享的目标窗口被覆盖。
        * @note 在 Windows 平台中，某些窗口在被屏蔽之后，如果被置于图层最上层，此窗口图像可能会黑屏。此时会触发
        * onScreenCaptureStatus.kScreenCaptureStatusCovered 回调，建议应用层在触发此回调时提醒用户将待分享的窗口置于最上层。
        * @endif
        */
        kNERtcScreenCaptureStatusCovered = 5
    }

    /**
    * @if English
    * The position of the area to be shared with respect to the entire screen or window. If you leave the setting empty, the entire
    * screen or window is shared.
    * @endif
    * @if Chinese
    * 待共享区域相对于整个屏幕或窗口的位置，如不填，则表示共享整个屏幕或窗口。
    * @endif
    */
    public struct RtcRectangle
    {
        /**
        * @if English
        * The horizontal offset of the upper left corner.
        * @endif
        * @if Chinese
        * 左上角的横向偏移。
        * @endif
        */
        public int x;
        /**
        * @if English
        * The vertical offset of the upper left corner.
        * @endif
        * @if Chinese
        * 左上角的纵向偏移。
        * @endif
        */
        public int y;
        /**
        * @if English
        * The width of the area to be shared.
        * @endif
        * @if Chinese
        * 待共享区域的宽。
        * @endif
        */
        public int width;
        /**
        * @if English
        * The height of the area to be shared.
        * @endif
        * @if Chinese
        * 待共享区域的高。
        * @endif
        */
        public int height;
    }

    /**
    * @if English
    * Video dimensions.
    * @endif
    * @if Chinese
    * 视频尺寸。
    * @endif
    */
    public struct RtcVideoDimensions
    {
        /**
        * @if English
        * The width
        * @endif
        * @if Chinese
        * 宽度
        * @endif
        */
        public int width;
        /**
        * @if English
        * The height
        * @endif
        * @if Chinese
        * 高度
        * @endif
        */
        public int height;
    }

    /**
    * @if English
    * Encoding strategy preference for screen sharing.
    * - kNERtcSubStreamContentPreferMotion: The content type is animation. When the shared content is a video, movie, or game, We
    * recommend that you select this content type.If a user sets the content type to animation, the user-defined frame rate is
    * applied.
    * - kNERtcSubStreamContentPreferDetails: The content type is details. When the shared content is an image or text, We recommend
    * that you select this content type. When the user sets the content type to details, the user is allowed to set up to 10
    * frames. If the setting exceeds 10 frames, 10 frames are applied.
    * @endif
    * @if Chinese
    * 屏幕共享功能的编码策略倾向。
    * - kNERtcSubStreamContentPreferMotion:
    * 内容类型为动画。当共享的内容是视频、电影或游戏时，推荐选择该内容类型。当用户设置内容类型为动画时，按用户设置的帧率处理。
    * - kNERtcSubStreamContentPreferDetails:
    * 内容类型为细节。当共享的内容是图片或文字时，推荐选择该内容类型。当用户设置内容类型为细节时，最高允许用户设置到10帧，设置超过
    * 10 帧时，不生效，按 10 帧处理。
    * @endif
    */
    public enum RtcSubStreamContentPrefer
    {
        /**
        * @if English
        * The animation mode.
        * @endif
        * @if Chinese
        * 动画模式。
        * @endif
        */
        kNERtcSubStreamContentPreferMotion = 0,
        /**
        * @if English
        * The details mode.
        * @endif
        * @if Chinese
        * 细节模式。
        * @endif
        */
        kNERtcSubStreamContentPreferDetails = 1,
    }
    

    /**
    * @if English
    * Configuration parameters for screen sharing encoding. The setting is used to measure encoding quality.
    * @endif
    * @if Chinese
    * 屏幕共享编码参数配置。用于衡量编码质量。
    * @endif
    */
    public class RtcScreenCaptureParameters
    {
        /**
        * @if English
        * Configuration parameters for screen sharing encoding.
        * @endif
        * @if Chinese
        * 屏幕共享编码参数配置。
        * @endif
        */
        public RtcScreenProfileType profile { get; set; } = RtcScreenProfileType.kNERtcScreenProfileHD720P;
        /**
        * @if English
        * The maximum pixel value sent by screen sharing video. The value is valid in kNERtcScreenProfileCustom.
        * @endif
        * @if Chinese
        * 屏幕共享视频发送的最大像素值，kNERtcScreenProfileCustom下生效。
        * @endif
        */
        public RtcVideoDimensions dimensions { get; set; }
        /**
        * @if English
        * The frame rate of the shared video.The value is valid in kNERtcScreenProfileCustom, and the unit is fps. The default value
        * is 5. A value more than 15 is not recommended.
        * @endif
        * @if Chinese
        * 共享视频的帧率，kNERtcScreenProfileCustom下生效，单位为 fps；默认值为 5，建议不要超过 15。
        * @endif
        */
        public int frameRate { get; set; } = 0;
        /**
        * @if English
        * The bitrate of the shared video in kbps. The default value is 0, which indicates that the SDK calculates a reasonable value
        * based on the resolution of the current shared screen.
        * @endif
        * @if Chinese
        * 共享视频的码率，单位为 kbps；默认值为 0，表示 SDK 根据当前共享屏幕的分辨率计算出一个合理的值。
        * @endif
        */
        public int bitrate { get; set; } = 0;
        /**
        * @if English
        * Determines whether to capture the mouse during screen sharing.
        * @endif
        * @if Chinese
        * 是否采集鼠标用于屏幕共享。
        * @endif
        */
        public bool captureMouseCursor { get; set; } = true;
        /**
        * @if English
        * Determing whether to bing the window to the front when you call the startScreenCaptureByWindowId method to share a window.
        * @endif
        * @if Chinese
        * 调用 startScreenCaptureByWindowId 方法共享窗口时，是否将该窗口前置。
        * @endif
        */
        public bool windowFocus { get; set; } = true;
        /**
        * @if English
        * ID list of windows to be blocked.
        * @endif
        * @if Chinese
        * 待屏蔽窗口的 ID 列表。
        * @endif
        */
        public IntPtr[] excludedWindowList { get; set; }
        /**
        * @if English
        * Encoding strategy preference.
        * @endif
        * @if Chinese
        * 编码策略倾向。
        * @endif
        */
        public RtcSubStreamContentPrefer prefer { get; set; } = RtcSubStreamContentPrefer.kNERtcSubStreamContentPreferDetails;
    }

    /**
    * @if English
    * Configuration of the video display.
    * @endif
    * @if Chinese
    * 视频显示设置
    * @endif
    */
    public class RtcVideoCanvas
    {
        /**
        * @if English
        * Data callbacks.
        * @endif
        * @if Chinese
        * 数据回调。
        * @endif
        */
        public IVideoFrameCallback callback { get; set; }
        /**
        * @if English
        * Rendering window handle.
        * @endif
        * @if Chinese
        * 渲染窗口句柄。
        *
        * @endif
        */
        public IntPtr window { get; set; }
        /**
        * @if English
        * Video display mode.
        * @endif
        * @if Chinese
        * 视频显示模式。
        * @endif
        */
        public RtcVideoScalingMode scalingMode { get; set; }
    }

    /**
    * @if English
    * Recording type.
    * @endif
    * @if Chinese
    * 录制类型。
    * @endif
    */
    public enum RtcRecordType : int
    {
        /**
        * @if English
        * Composite and individual stream recording.
        * @endif
        * @if Chinese
        * 参与合流+单流录制。
        * @endif
        */
        kNERtcRecordTypeAll = 0,
        /**
        * @if English
        * Composite recording mode.
        * @endif
        * @if Chinese
        * 参与合流录制模式。
        * @endif
        */
        kNERtcRecordTypeMix = 1,
        /**
        * @if English
        * individual recording mode.
        * @endif
        * @if Chinese
        * 参与单流录制模式。
        * @endif
        */
        kNERtcRecordTypeSingle = 2,
    }

    /**
    * @if English
    * Audio type.
    * @endif
    * @if Chinese
    * 音频类型。
    * @endif
    */
    public enum RtcAudioType : int
    {
        /**
        * @if English
        * PCM audio format.
        * @endif
        * @if Chinese
        * PCM 音频格式。
        * @endif
        */
        kNERtcAudioTypePCM16 = 0,
    }
    /**
    * @if English
    * Audio frame request data read and write mode.
    * @endif
    * @if Chinese
    * 音频帧请求数据的读写模式。
    * @endif
    */
    public enum RtcRawAudioFrameOpModeType : int
    {
        /**
        * @if English
        * Read-only mode
        * @endif
        * @if Chinese
        * 返回数据只读模式
        * @endif
        */
        kNERtcRawAudioFrameOpModeReadOnly = 0,
        /**
        * @if English
        * Read and write mode
        * @endif
        * @if Chinese
        * 返回数据可读写
        * @endif
        */
        kNERtcRawAudioFrameOpModeReadWrite,
    }

    /**
    * @if English
    * The audio frame request format.
    * @endif
    * @if Chinese
    *  音频帧请求格式。
    * @endif
    */
    public struct RtcAudioFrameRequestFormat
    {
        /**
        * @if English
        * the number of channels. If the audio is a stereo sound, the data is interleaved. mono: 1. stereo: 2.
        * @endif
        * @if Chinese
        * 音频声道数量。如果是立体声，数据是交叉的。单声道: 1；双声道 : 2。
        * @endif
        */
        public uint channels;
        /**
        * @if English
        * The sample rate.
        * @endif
        * @if Chinese
        * 采样率。
        * @endif
        */
        public uint sampleRate;
        /**
        * @if English
        * Read and write mode.
        * @endif
        * @if Chinese
        * 读写模式
        * @endif
        */
        public RtcRawAudioFrameOpModeType mode;
    }

    /**
    * @if English
    * The audio format.
    * @endif
    * @if Chinese
    * 音频格式。
    * @endif
    */
    public struct RtcAudioFormat
    {
        /**
        * @if English
        * Audio type.
        * @endif
        * @if Chinese
        * 音频类型。
        * @endif
        */
        public RtcAudioType type;
        /**
        * @if English
        * the number of channels. If the audio is a stereo sound, the data interleaved. mono: 1. stereo: 2.
        * @endif
        * @if Chinese
        * 音频声道数量。如果是立体声，数据是交叉的。单声道: 1；双声道 : 2。
        * @endif
        */
        public uint channels;
        /**
        * @if English
        * The sample rate.
        * @endif
        * @if Chinese
        * 采样率。
        * @endif
        */
        public uint sampleRate;
        /**
        * @if English
        * The number of bytes per sample. For PCM, 16 bits are used, which means 2 bytes.
        * @endif
        * @if Chinese
        * 每个采样点的字节数。对于 PCM 来说，一般使用 16 bit，即两个字节。
        * @endif
        */
        public uint bytesPerSample;
        /**
        * @if English
        * The number of samples per room.
        * @endif
        * @if Chinese
        * 每个房间的样本数量。
        * @endif
        */
        public uint samplesPerChannel;
    }

    /**
    * @if English
    * The audio frame.
    * @endif
    * @if Chinese
    * 音频帧。
    * @endif
    */
    public struct RtcAudioFrame
    {
        /**
        * @if English
        * Audio format.
        * @endif
        * @if Chinese
        * 音频格式。
        * @endif
        */
        [MarshalAs(UnmanagedType.Struct)]
        public RtcAudioFormat format;
        /**
        * @if English
        * Data buffer. The valid data length: samplesPerChannel * channels * bytesPerSample.
        * @endif
        * @if Chinese
        * 数据缓冲区。有效数据长度为：samplesPerChannel * channels * bytesPerSample。
        * @endif
        */
        public IntPtr data;
    }

    /**
    * @if English
    * The video type.
    * @endif
    * @if Chinese
    * 视频类型。
    * @endif
    */
    public enum RtcVideoType : int
    {
        /**
        * @if English
        * I420 video format.
        * @endif
        * @if Chinese
        * I420 视频格式。
        * @endif
        */
        kNERtcVideoTypeI420 = 0,
        /**
        * @if English
        * NV12 video format.
        * @endif
        * @if Chinese
        * NV12 视频格式。
        * @endif
        */
        kNERtcVideoTypeNV12 = 1,
        /**
        * @if English
        * NV21 video format.
        * @endif
        * @if Chinese
        * NV21 视频格式。
        * @endif
        */
        kNERtcVideoTypeNV21 = 2,
        /**
        * @if English
        * BGRA video format.
        * @endif
        * @if Chinese
        * BGRA 视频格式。
        * @endif
        */
        kNERtcVideoTypeBGRA = 3,
        /**
        * @if English
        * ARGB video format.
        * @endif
        * @if Chinese
        * BGRA 视频格式。
        * @endif
        */
        kNERtcVideoTypeARGB = 4,
        /**
        * @if English
        * oc capture native video format. External video input is not allowed.
        * @endif
        * @if Chinese
        * oc capture native视频格式。不支持外部视频输入
        * @endif
        */
        kNERtcVideoTypeCVPixelBuffer = 5,
    }
    
    /**
    * @if English
    * The angle to which the video rotates.
    * @endif
    * @if Chinese
    * 视频旋转角度。
    * @endif
    */
    public enum RtcVideoRotation : int
    {
        /**
        * @if English
        * 0 度。
        * @endif
        * @if Chinese
        * 0°
        * @endif
        */
        kNERtcVideoRotation0 = 0,
        /**
        * @if English
        * 90°
        * @endif
        * @if Chinese
        * 90 度。
        * @endif
        */
        kNERtcVideoRotation90 = 90,
        /**
        * @if English
        * 180°
        * @endif
        * @if Chinese
        * 180 度。
        * @endif
        */
        kNERtcVideoRotation180 = 180,
        /**
        * @if English
        * 270°
        * @endif
        * @if Chinese
        * 270 度。
        * @endif
        */
        kNERtcVideoRotation270 = 270,
    }
    
    /**
    * @if English
    * Video frame of external input.
    * @endif
    * @if Chinese
    * 外部输入的视频帧。
    * @endif
    */
    public struct RtcExternalVideoFrame
    {
        /**
        * @if English
        * The video frame format. For more information, see #RtcVideoType .
        * @endif
        * @if Chinese
        * 视频帧格式，详细信息请参考 #RtcVideoType 。
        * @endif
        */
        public RtcVideoType format;
        /**
        * @if English
        * The video timestamp. Unit: milliseconds.
        * @endif
        * @if Chinese
        * 视频时间戳，单位为毫秒。
        * @endif
        */
        public ulong timestamp;
        /**
        * @if English
        * Video frame width.
        * @endif
        * @if Chinese
        * 视频桢宽度
        * @endif
        */
        public uint width;
        /**
        * @if English
        * Video frame height.
        * @endif
        * @if Chinese
        * 视频桢宽高
        * @endif
        */
        public uint height;
        /**
        * @if English
        * For more information about video rotation angle, see #RtcVideoRotation.
        * @endif
        * @if Chinese
        * 视频旋转角度 详见: #RtcVideoRotation
        * @endif
        */
        public RtcVideoRotation rotation;
        /**
        * @if English
        * Video frame data.
        * @endif
        * @if Chinese
        * 视频桢数据
        * @endif
        */
        public IntPtr buffer;
    }
    /**
   * @if English
   * Video frame of render.
   * @endif
   * @if Chinese
   * 渲染视频帧。
   * @endif
   */
    public struct RtcVideoFrame
    {
        /**
        * @if English
        * The video frame format. For more information, see #RtcVideoType .
        * @endif
        * @if Chinese
        * 视频帧格式，详细信息请参考 #RtcVideoType 。
        * @endif
        */
        public RtcVideoType format;
        /**
        * @if English
        * Video frame width.
        * @endif
        * @if Chinese
        * 视频桢宽度
        * @endif
        */
        public uint width;
        /**
        * @if English
        * Video frame height.
        * @endif
        * @if Chinese
        * 视频桢宽高
        * @endif
        */
        public uint height;
        /**
        * @if English
        * For more information about video rotation angle, see #RtcVideoRotation.
        * @endif
        * @if Chinese
        * 视频旋转角度 详见: #RtcVideoRotation
        * @endif
        */
        public RtcVideoRotation rotation;
        /**
        * @if English
        * Video frame data.
        * @endif
        * @if Chinese
        * 视频桢数据
        * @endif
        */
        public IntPtr buffer;
        /**
        * @if English
        * offset of Video frame data .
        * @endif
        * @if Chinese
        * 每类数据偏移
        * @endif
        */
        public uint[] offsets;
        /**
        * @if English
        * stride of Video frame data .
        * @endif
        * @if Chinese
        * 每类数据步进
        * @endif
        */
        public uint[] strides;
    }


    /**
    * @if English
    * The reasons why the user leaves.
    * @endif
    * @if Chinese
    * 用户离开原因。
    * @endif
    */
    public enum RtcSessionLeaveReason : int
    {
        /**
        * @if English
        * A user leaves the room normally.
        * @endif
        * @if Chinese
        * 正常离开。
        * @endif
        */
        kNERtcSessionLeaveNormal = 0,
        /**
        * @if English
        * The user is disconnected and leaves the room.
        * @endif
        * @if Chinese
        * 用户断线导致离开。
        * @endif
        */
        kNERtcSessionLeaveForFailOver = 1,
        /**
        * @if English
        * The user leaves the room because the session fails over.
        * @endif
        * @if Chinese
        * 用户 Failover 过程中产生的 leave。
        * @endif
        */
        kNERtcSessionLeaveUpdate = 2,
        /**
        * @if English
        * The user is removed from the room.
        * @endif
        * @if Chinese
        * 用户被踢导致离开。
        * @endif
        */
        kNERtcSessionLeaveForKick = 3,
        /**
        * @if English
        * The user is disconnected due to connection timeout.
        * @endif
        * @if Chinese
        * 用户超时导致离开。
        * @endif
        */
        kNERtcSessionLeaveTimeOut = 4,
    }

    /**
    * @if English
    * The playback state of the music file.
    * @endif
    * @if Chinese
    * 音乐文件播放状态。
    *
    * @endif
    */
    public enum RtcAudioMixingState : int
    {
        /**
        * @if English
        * The playback ends.
        * @endif
        * @if Chinese
        * 音乐文件播放结束。
        * @endif
        */
        kNERtcAudioMixingStateFinished = 0,
        /**
        * @if English
        * The playback fails because an error occurs. For more information, see #RtcAudioMixingErrorCode.
        * @endif
        * @if Chinese
        * 音乐文件报错。详见: #RtcAudioMixingErrorCode
        * @endif
        */
        kNERtcAudioMixingStateFailed = 1,
    }
    
    /**
    * @if English
    * Configuration items for audio mixing.
    * @endif
    * @if Chinese
    * 创建混音的配置项
    * @endif
    */
    public struct RtcCreateAudioMixingOption
    {
        /**
        * @if English
        * The path of the audio file. The local absolute paths or URL addresses are supported.
        * - The path must include the file name and extension, such as "D:\\audioFiles\\test.mp3".
        * - Supported audio formats: MP3, M4A, AAC, 3GP, WMA, and WAV.
        * @endif
        * @if Chinese
        * 待播放的音乐文件路径，支持本地绝对路径或 URL 地址。
        * - 需精确到文件名及后缀，例如 “D:\\audioFiles\\test.mp3”。
        * - 支持的音乐文件类型包括 MP3、M4A、AAC、3GP、WMA 和 WAV 格式。
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst =256)]
        public string path;
        /**
        * @if English
        * The number of loops for mixing audio playback:
        * -1: (Default) plays the audio effect for one time.
        * -≤ 0: plays in an infinite loop, until stops by calling pauseAudioMixing or stopAudioMixing.
        * @endif
        * @if Chinese
        * 伴音循环播放的次数：
        * - 1：（默认）播放音效一次。
        * - ≤ 0：无限循环播放，直至调用 pauseAudioMixing 后暂停，或调用 stopAudioMixing 后停止。
        * @endif
        */
        public int loopCount;
        /**
        * @if English
        * Specifies whether to send the mixing audio to the remote client. The default value is true. The remote user can hear the
        * mixing audio after the remote user subscribes to the local audio stream.
        * @endif
        * @if Chinese
        * 是否将伴音发送远端，默认为 true，即远端用户订阅本端音频流后可听到该伴音。
        * @endif
        */
        [MarshalAs(UnmanagedType.I1)]
        public bool sendEnabled;
        /**
        * @if English
        * Indicates the publishing volume of a music file. Valid values: 0 to 100. The default value is 100, which indicates that the
        * original volume of the file is used.
        * @note If you modify the volume setting during a call, this setting will be used by default when you call the method again
        * during the current call.
        * @endif
        * @if Chinese
        * 乐文件的发送音量，取值范围为 0~100。默认为 100，表示使用文件的原始音量。
        * @note 若您在通话中途修改了音量设置，则当前通话中再次调用时默认沿用此设置。
        * @endif
        */
        public uint sendVolume;
        /**
        * @if English
        * Specifies whether to play back the mixing audio on the local client. The default value is true. The local users can hear
        * the mixing audio.
        * @endif
        * @if Chinese
        * 是否本地播放伴音。默认为 true，即本地用户可以听到该伴音。
        * @endif
        */
        [MarshalAs(UnmanagedType.I1)]
        public bool playbackEnabled;
        /**
        * @if English
        * Indicates the playback volume of a music file. Valid values: 0 to 100. The default value is 100, which indicates that the
        * original volume of the file is used.
        * @note If you modify the volume setting during a call, this setting will be used by default when you call the method again
        * during the current call.
        * @endif
        * @if Chinese
        * 音乐文件的播放音量，取值范围为 0~100。默认为 100，表示使用文件的原始音量。
        * @note 若您在通话中途修改了音量设置，则当前通话中再次调用时默认沿用此设置。
        * @endif
        */
        public uint playbackVolume;
    }

    /**
    * @if English
    * Configuration items for audio effects.
    * @endif
    * @if Chinese
    * 创建音效的配置项
    * @endif
    */
    public struct RtcCreateAudioEffectOption
    {
        /**
        * @if English
        * The path of the audio effect file. The local absolute paths or URL addresses are supported.
        * - The path must include the file name and extension, such as "D:\\audioFiles\\test.mp3".
        * - Supported audio formats: MP3, M4A、AAC, 3GP, WMA, and WAV.
        * @endif
        * @if Chinese
        * 待播放的音效文件路径，支持本地绝对路径或 URL 地址。
        * - 需精确到文件名及后缀，例如 “D:\\audioFiles\\test.mp3”。
        * - 支持的音效文件类型包括 MP3、M4A、AAC、3GP、WMA 和 WAV 格式。
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string path;
        /**
        * @if English
        * The number of loops the audio effect is played:
        * -1: (Default) plays the audio effect for one time.
        * -≤ 0: Play sound effects in an infinite loop until you stop the playback by calling stopEffect or stopAllEffects.
        * @endif
        * @if Chinese
        * 音效循环播放的次数：
        * - 1：（默认）播放音效一次。
        * - ≤ 0：无限循环播放音效，直至调用 stopEffect 或 stopAllEffects 后停止。
        * @endif
        */
        public int loopCount;
        /**
        * @if English
        * Specifies whether to send the mixing audio to the remote client. The default value is true. The remote user can hear the
        * mixing audio after the remote user subscribes to the local audio stream.
        * @endif
        * @if Chinese
        * 是否将伴音发送远端，默认为 true，即远端用户订阅本端音频流后可听到该伴音。
        * @endif
        */
        [MarshalAs(UnmanagedType.I1)]
        public bool sendEnabled;
        /**
        * @if English
        * Indicates the publishing volume of a music file. Valid values: 0 to 100. The default value is 100, which indicates that the
        * original volume of the file is used.
        * @note If you modify the volume setting during a call, this setting will be used by default when you call the method again
        * during the current call.
        * @endif
        * @if Chinese
        * 音乐文件的发送音量，取值范围为 0~100。默认为 100，表示使用文件的原始音量。
        * @note 若您在通话中途修改了音量设置，则当前通话中再次调用时默认沿用此设置。
        * @endif
        */
        public uint sendVolume;
        /**
        * @if English
        * Specifies whether to play back. The default value is true. You can play back the local audio file.
        * @endif
        * @if Chinese
        * 是否可播放。默认为 true，即可在本地播放该音效。
        * @endif
        */
        [MarshalAs(UnmanagedType.I1)]
        public bool playbackEnabled;
        /**
        * @if English
        * Indicates the playback volume of a music file. Valid values: 0 to 100. The default value is 100, which indicates that the
        * original volume of the file is used.
        * @note If you modify the volume setting during a call, this setting will be used by default when you call the method again
        * during the current call.
        * @endif
        * @if Chinese
        * 音乐文件的播放音量，取值范围为 0~100。默认为 100，表示使用文件的原始音量。
        * @note 若您在通话中途修改了音量设置，则当前通话中再次调用时默认沿用此设置。
        * @endif
        */
        public uint playbackVolume;
    }

    /**
    * @if English
    * The video stream type.
    * @endif
    * @if Chinese
    * 视频流类型
    * @endif
    */
    public enum RtcVideoStreamType : int
    {
        /**
        * @if English
        * mainstream.
        * @endif
        * @if Chinese
        * 主流
        * @endif
        */
        kNERTCVideoStreamMain = 0,
        /**
        * @if English
        * Substream.
        * @endif
        * @if Chinese
        * 辅流
        * @endif
        */
        kNERTCVideoStreamSub = 1,
        /**
        * @if English
        * Reserved parameter. Ignore this parameter.
        * @endif
        * @if Chinese
        * 预留参数，无需关注。
        * @endif
        */
        kNERTCVideoStreamCount,
    }
    
    /**
    * @if English
    * Parameters for text watermarks.
    * <br>You can add up to 10 text watermarks.
    * @endif
    * @if Chinese
    * 文字水印设置参数。
    * <br>最多可添加 10 个文字水印。
    * @endif
    */
    public struct RtcTextWatermarkConfig
    {
        /**
        * @if English
        * The text content.
        * @note
        * - The length of the string is unlimited. The final display is affected by the font size and the size of the watermark
        * frame. The part beyond the watermark frame is not displayed.
        * - If the width of the watermark frame is set, when the length of the text content exceeds the width of the watermark frame,
        * the text automatically wraps. If the text exceeds the height of the watermark frame, the excess part is not displayed.
        * - When the width and height of the watermark frame are not set, the text does not wrap, and the part beyond the watermark
        * frame is not be displayed.
        * @endif
        * @if Chinese
        * 文字内容。
        * @note
        * - 字符串长度无限制。最终显示受字体大小和水印框大小的影响。超出水印框的部分不显示。
        * - 如果设置了水印框宽度，当文字内容长度超过水印框宽度时，会自动换行，如果超出水印框高度，超出部分不显示。
        * - 未设置水印框宽度和高度时，文字不换行，超出水印框的部分不显示。
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string content;
        /**
        * @if English
        * The font path. If this setting is left empty, the default system font is used.
        * @endif
        * @if Chinese
        * 字体路径，设置为空时，表示使用程序默认字体。
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string fontPath;
        /**
        * @if English
        * The font size. The default value is 10, equivalent to 10 x 15 lb on a 144 dpi device.
        * @endif
        * @if Chinese
        * 字体大小。默认值为 10，相当于 144 dpi 设备上的 10 x 15 磅。
        * @endif
        */
        public int fontSize;
        /**
        * @if English
        * The font color. ARGB format.
        * @endif
        * @if Chinese
        * 字体颜色。ARGB 格式。
        * @endif
        */
        public int fontColor;
        /**
        * @if English
        * The horizontal distance between the upper left corner of the watermark and the upper left corner of the video canvas. Unit:
        * pixels.
        * @endif
        * @if Chinese
        * 水印左上角与视频画布左上角的水平距离。单位为像素（pixel）。
        * @endif
        */
        public int offsetX;
        /**
        * @if English
        * The vertical distance between the upper left corner of the watermark and the upper left corner of the video canvas. Unit:
        * pixels.
        * @endif
        * @if Chinese
        * 水印左上角与视频画布左上角的垂直距离。单位为像素（pixel）。
        * @endif
        */
        public int offsetY;
        /**
        * @if English
        * The background color in the watermark frame. ARGB format. Transparency setting is supported.
        * @endif
        * @if Chinese
        * 水印框内背景颜色。ARGB格式，支持透明度设置。
        * @endif
        */
        public int wmColor;
        /**
        * @if English
        * The width of the watermark frame. Unit: pixels. The default value is 0, which indicates no watermark frame.
        * @endif
        * @if Chinese
        * 水印框的宽度。单位为像素（pixel），默认值为 0，表示没有水印框。
        * @endif
        */
        public int wmWidth;
        /**
        * @if English
        * The height of the watermark frame. Unit: pixels. The default value is 0, which indicates no watermark frame.
        * @endif
        * @if Chinese
        * 水印框的高度。单位为像素（pixel），默认值为 0，表示没有水印框。
        * @endif
        */
        public int wmHeight;
    }

    /**
    * @if English
    * Sets a timestamp watermark.
    * - You can add only 1 timestamp watermark.
    * - The time of the timestamp watermark is the same as the current time and changes in real time.
    * @endif
    * @if Chinese
    * 时间戳水印设置。
    * - 只能添加 1 个时间戳水印。
    * - 时间戳水印的时间和当前时间相同，且实时变化。
    * @endif
    */
    public struct RtcTimestampWatermarkConfig
    {
        /**
        * @if English
        * The font path. If this setting is left empty, the default system font is used.
        * @endif
        * @if Chinese
        * 字体大小。默认值为 10，相当于 144 dpi 设备上的 10 x 15 磅。
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string fontPath;
        /**
        * @if English
        * The font size. The default value is 10, equivalent to 10 x 15 lb on a 144 dpi device.
        * @endif
        * @if Chinese
        * 字体颜色。ARGB 格式。
        * @endif
        */
        public int fontSize;
        /**
        * @if English
        * The font color. ARGB format.
        * @endif
        * @if Chinese
        * 水印左上角与视频画布左上角的水平距离。单位为像素（pixel）。
        * @endif
        */
        public int fontColor;
        /**
        * @if English
        * The horizontal distance between the upper left corner of the watermark and the upper left corner of the video canvas. Unit:
        * pixels.
        * @endif
        * @if Chinese
        * 水印左上角与视频画布左上角的水平距离。单位为像素（pixel）。
        * @endif
        */
        public int offsetX;
        /**
        * @if English
        * The vertical distance between the upper left corner of the watermark and the upper left corner of the video canvas. Unit:
        * pixels.
        * @endif
        * @if Chinese
        * 水印左上角与视频画布左上角的垂直距离。单位为像素（pixel）。
        * @endif
        */
        public int offsetY;
        /**
        * @if English
        * The background color in the watermark frame. ARGB format. Transparency setting is supported.
        * @endif
        * @if Chinese
        * 水印框内背景颜色。ARGB格式，支持透明度设置。
        * @endif
        */
        public int wmColor;
        /**
        * @if English
        * The width of the watermark frame. Unit: pixels. The default value is 0, which indicates no watermark frame.
        * @endif
        * @if Chinese
        * 水印框的宽度。单位为像素（pixel），默认值为 0，表示没有水印框。
        * @endif
        */
        public int wmWidth;
        /**
        * @if English
        * The height of the watermark frame. Unit: pixels. The default value is 0, which indicates no watermark frame.
        * @endif
        * @if Chinese
        * 水印框的高度。单位为像素（pixel），默认值为 0，表示没有水印框。
        * @endif
        */
        public int wmHeight;
        /**
        * @if English
        * Timestamp type. Valid values:
        * - 1: yyyy-MM-dd HH:mm:ss.
        * - 2: yyyy-MM-dd HH:mm:ss.SSS. Unit: milliseconds.
        * @endif
        * @if Chinese
        * 时间戳类型，支持设置为：
        * - 1：yyyy-MM-dd HH:mm:ss。
        * - 2：yyyy-MM-dd HH:mm:ss.SSS。精确到毫秒。
        * @endif
        */
        public int tsType;
    }

    /**
    * @if English
    * Status during media stream relay.
    * @endif
    * @if Chinese
    * 媒体流转发状态
    * @endif
    */
    public enum RtcChannelMediaRelayState : int
    {
        /**
        * @if English
        * Initial state. After a successful call of stopChannelMediaRelay method to stop cross-room media streaming.
        * @endif
        * @if Chinese
        * 初始状态。在成功调用 stopChannelMediaRelay 停止跨房间媒体流转发后， onMediaRelayStateChanged 会回调该状态。
        * @endif
        */
        kNERtcChannelMediaRelayStateIdle = 0,
        /**
        * @if English
        * The SDK tries to relay cross-room media streams.
        * @endif
        * @if Chinese
        * SDK 尝试跨房间转发媒体流。
        * @endif
        */
        kNERtcChannelMediaRelayStateConnecting = 1,
        /**
        * @if English
        * Sets the host role of source channel into the target room.
        * @endif
        * @if Chinese
        * 源房间主播角色成功加入目标房间。
        * @endif
        */
        kNERtcChannelMediaRelayStateRunning = 2,
        /**
        * @if English
        * Failure occurs. See the error messages prompted by error of onMediaRelayEvent.
        * @endif
        * @if Chinese
        * 发生异常，详见 onMediaRelayEvent 的 error 中提示的错误信息。
        * @endif
        */
        kNERtcChannelMediaRelayStateFailure = 3,
    }

    /**
    * @if English
    * Events related to the media stream relay.
    * @endif
    * @if Chinese
    * 媒体流转发回调事件。
    * @endif
    */
    public enum RtcChannelMediaRelayEvent : int
    {
        /**
        * @if English
        * Current media stream relay gets disconnected.
        * @endif
        * @if Chinese
        * 媒体流转发停止。
        * @endif
        */
        kNERtcChannelMediaRelayEventDisconnect = 0,
        /**
        * @if English
        * Starts to relay media streams.
        * @endif
        * @if Chinese
        * SDK 正在连接服务器，开始尝试转发媒体流。
        * @endif
        */
        kNERtcChannelMediaRelayEventConnecting = 1,
        /**
        * @if English
        * The media stream relay gets connected to the server.
        * @endif
        * @if Chinese
        * 连接服务器成功。
        * @endif
        */
        kNERtcChannelMediaRelayEventConnected = 2,
        /**
        * @if English
        * The video stream is relayed to the destination room.
        * @endif
        * @if Chinese
        * 视频音频媒体流成功转发到目标房间。
        * @endif
        */
        kNERtcChannelMediaRelayEventVideoSentToDestChannelSuccess = 3,
        /**
        * @if English
        * The audio stream is relayed to the destination room.
        * @endif
        * @if Chinese
        * 音频媒体流成功转发到目标房间。
        * @endif
        */
        kNERtcChannelMediaRelayEventAudioSentToDestChannelSuccess = 4,
        /**
        * @if English
        * Other streams such as screen sharing stream are relayed to the destination room.
        * @endif
        * @if Chinese
        * 媒体流屏幕共享等其他流成功转发到目标房间。
        * @endif
        */
        kNERtcChannelMediaRelayEventOtherStreamSentToDestChannelSuccess = 5,
        /**
        * @if English
        * Fails to relay media streams. Possible reasons：
        * - kNERtcErrChannelReserveErrorParam(414)
        * - kNERtcErrChannelMediaRelayInvalidState(30110)
        * - kNERtcErrChannelMediaRelayPermissionDenied(30111)
        * - kNERtcErrChannelMediaRelayStopFailed(30112)
        * @endif
        * @if Chinese
        * 媒体流转发失败。原因包括：
        * - kNERtcErrChannelReserveErrorParam(414)：请求参数错误。
        * - kNERtcErrChannelMediaRelayInvalidState(30110)：重复调用 startChannelMediaRelay。
        * - kNERtcErrChannelMediaRelayPermissionDenied(30111)：媒体流转发权限不足。例如调用 startChannelMediaRelay
        * 的房间成员为主播角色、或房间为双人通话房间，不支持转发媒体流。
        * - kNERtcErrChannelMediaRelayStopFailed(30112)：调用 stopChannelMediaRelay 前，未调用 startChannelMediaRelay。
        * @endif
        */
        kNERtcChannelMediaRelayEventFailure = 100,
    }

    /**
    * @if English
    * Data structure related to media stream relay.
    * @endif
    * @if Chinese
    * 媒体流转发相关的数据结构。
    * @endif
    */
    public struct RtcChannelMediaRelayInfo
    {
        /**
        * @if English
        * The name of the destination room to which the media stream is relayed.
        * @endif
        * @if Chinese
        * 房间名。
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string channelName;
        /**
        * @if English
        * The token used to connect to the destination room.
        * @endif
        * @if Chinese
        * 能加入房间的 Token。
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string channelToken;
        /**
        * @if English
        * The user ID used in the destination room. This ID can be different from the ID used in the current room.
        * @endif
        * @if Chinese
        * 用户 ID。
        * @endif
        */
        public ulong uid;
    }

    /**
    * @if English
    * Configurations for media stream relay.
    * @endif
    * @if Chinese
    * 跨房间媒体流转发相关参数配置。
    * @endif
    */
    public class RtcChannelMediaRelayConfig
    {
        /**
        * @if English
        * The information about the current room.
        * - `channelName`: Source channel name.
        * - `channelToken`: Token with access to source channel.
        * - `uid`: Identifies the UID of relaying media streams in the source channel.
        * @endif
        * @if Chinese
        * 源房间信息，包括：
        * - `channelName`：源房间名。默认值为 nil，表示 SDK 填充当前的房间名。
        * - `channelToken`：能加入源房间的 Token。
        * - `uid`：标识源房间中的转发媒体流的 UID。
        * @endif
        */
        public RtcChannelMediaRelayInfo srcInfos { get; set; }
        /**
        * @if English
        * The configuration of the destination room.
        * - `channelName`：Destination channel names.
        * - `channelToken`：Token with access to target channels.
        * - `uid`：Identifies the UID of relaying media stream in the target channel. Do not set this parameter as the UID of the
        * host in the destination room. The parameter is different from all UIDs in the target channel.
        * @endif
        * @if Chinese
        * 目标房间信息，包括：
        * - `channelName`：目标房间的房间名。
        * - `channelToken`：可以加入目标房间的 Token。
        * - `uid`：标识目标房间中的转发媒体流的 UID。请确保不要将该参数设为目标房间的主播的 UID，并与目标房间中的 所有 UID 都不同。
        * @endif
        */
        public RtcChannelMediaRelayInfo[] destInfos { get; set; }
    }

    /**
    * @if English
    * Sets the parameters for image watermarks.
    * <br>You can add up to 4 picture watermarks.
    * @endif
    * @if Chinese
    * 图片水印设置参数。
    * <br>最多可以添加 4 个图片水印。
    * @endif
    */
    public struct RtcImageWatermarkConfig
    {
        /**
        * @if English
        * Watermark image path. The setting is invalid if left empty.
        * @endif
        * @if Chinese
        * 水印图片路径。空时无效。
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValArray,ArraySubType = UnmanagedType.LPStr, SizeConst = 10)]
        public string[] imagePaths;
        /**
        * @if English
        * The horizontal distance between the upper left corner of the watermark and the upper left corner of the video canvas. Unit:
        * pixels. The default value is 0.
        * @endif
        * @if Chinese
        * 水印图片左上角与视频画布左上角的水平距离。单位为像素（pixel），默认值为 0。
        * @endif
        */
        public int offsetX;
        /**
        * @if English
        * The vertical distance between the upper left corner of the watermark and the upper left corner of the video canvas. Unit:
        * pixels. The default value is 0.
        * @endif
        * @if Chinese
        * 水印图片左上角与视频画布左上角的垂直距离。单位为像素（pixel），默认值为 0。
        * @endif
        */
        public int offsetY;
        /**
        * @if English
        * The width of the watermark image. Unit: pixels. The default value is 0, which indicates that the width of the original
        * image is applied.
        * @endif
        * @if Chinese
        * 水印图片的宽度。单位为像素（pixel），默认值为 0 表示按原始图宽。
        * @endif
        */
        public int imageWidth;
        /**
        * @if English
        * The height of the watermark image. Unit: pixels. The default value is 0, which indicates that the height of the original
        * image is applied.
        * @endif
        * @if Chinese
        * 水印图片的高度。单位为像素（pixel），默认值为 0 表示按原始图高。
        * @endif
        */
        public int imageHeight;
        /**
        * @if English
        * The frame rate. The default value is 0 fps, which indicates that the images are not flipped automatically. Images are
        * displayed in static single frames. Note: The frame rate for clients on Windows does not exceed 20 fps.
        * @endif
        * @if Chinese
        * 播放帧率。默认 0 帧/秒，即不自动切换图片，图片单帧静态显示。注意：Windows端帧率不超过 20 fps。
        * @endif
        */
        public int fps;
        /**
        * @if English
        * Specifies whether to loop. By default, loop is enabled. If the value is set to false, the watermarks disappear when the
        * playback is complete.
        * @endif
        * @if Chinese
        * 是否设置循环。默认循环，设置为 false 后水印数组播放完毕后消失。
        * @endif
        */
        [MarshalAs(UnmanagedType.I1)]
        public bool loop;
    }

    /**
    * @if English
    * Canvas watermark settings.
    * @note You can set text, timestamp, and image watermarks at the same time. If different types of watermarks overlay, the
    * layers overlay previous layers in the image, text, and timestamp sequence.
    * @endif
    * @if Chinese
    * 画布水印设置。
    * @note 同时设置文字、时间戳或图片水印时，如果不同类型的水印位置有重叠，会按照图片、文本、时间戳的顺序进行图层覆盖。
    * @endif
    */
    public class RtcCanvasWatermarkConfig
    {
        /**
        * @if English
        * Image watermark array pointer.
        * @endif
        * @if Chinese
        * 图片水印数组指针。
        * @endif
        */
        public RtcImageWatermarkConfig[] imageWatermarks { get; set; }
        /**
        * @if English
        * Text watermark array pointer.
        * @endif
        * @if Chinese
        * 文字水印数组指针。
        * @endif
        */
        public RtcTextWatermarkConfig[] textWatermarks { get; set; }
        /**
        * @if English
        * Timestamp watermark pointer. Only one timestamp watermark is supported.
        * @endif
        * @if Chinese
        * 时间戳水印指针，仅一个。
        * @endif
        */
        public RtcTimestampWatermarkConfig? timestampWatermark { get; set; }
    }

    /**
    * @if English
    * Returns the screenshot result.
    * @param errorCode The error code. For more information, see {@link RtcErrorCode}.
    * @param image The screenshot. Images on macOS are in CGImageRef format.
    * @endif
    * @if Chinese
    * 截图结果回调。
    * @param errorCode 错误码。详细信息请参考 {@link RtcErrorCode}。
    * @param image 截图图片。macOS 为 CGImageRef 格式，win平台为图片文件所在路径。
    * @endif
    */
    public delegate void RtcTakeSnapshotCallback(RtcErrorCode errorCode, string image);

    /**
    * @if English
    * Log levels.
    * @endif
    * @if Chinese
    * 日志级别。
    * @endif
    * */
    public enum RtcLogLevel : int
    {
        /**
        * @if English
        * Fatal.
        * @endif
        * @if Chinese
        * Fatal 级别日志信息。
        * @endif
        */
        kNERtcLogLevelFatal = 0,
        /**
        * @if English
        * Error.
        * @endif
        * @if Chinese
        * Error 级别日志信息。
        * @endif
        */
        kNERtcLogLevelError = 1,
        /**
        * @if English
        * Warning. The default log level.
        * @endif
        * @if Chinese
        * Warning 级别日志信息。默认级别
        * @endif
        */
        kNERtcLogLevelWarning = 2,
        /**
        * @if English
        * Info.
        * @endif
        * @if Chinese
        * Info 级别日志信息。
        * @endif
        */
        kNERtcLogLevelInfo = 3,
        /**
        * @if English
        * Detail Info.
        * @endif
        * @if Chinese
        * Detail Info 级别日志信息。
        * @endif
        */
        kNERtcLogLevelDetailInfo = 4,
        /**
        * @if English
        * Verbos.
        * @endif
        * @if Chinese
        * Verbos 级别日志信息。
        * @endif
        */
        kNERtcLogLevelVerbos = 5,
        /**
        * @if English
        * Debug. To get the complete log file, set the log level to this option.
        * @endif
        * @if Chinese
        * Debug 级别日志信息。如果你想获取最完整的日志，可以将日志级别设为该等级。
        * @endif
        */
        kNERtcLogLevelDebug = 6,
        /**
        * @if English
        * No logs.
        * @endif
        * @if Chinese
        * 不输出日志信息。
        * @endif
        */
        kNERtcLogLevelOff = 7,
    }
    

    /**
    * @if English
    * Video delivery strategy after publishing.
    * @endif
    * @if Chinese
    * 视频推流后发送策略。
    * @endif
    * */
    public enum RtcSendOnPubType : int
    {
        /**
        * @if English
        * The client does not actively send the data stream. The stream is sent if the stream is subscribed.
        * @endif
        * @if Chinese
        * 不主动发送数据流，被订阅后发送。
        * @endif
        */
        kNERtcSendOnPubNone = 0,
        /**
        * @if English
        * The client actively sends the mainstream.
        * @endif
        * @if Chinese
        * 主动发送大流。
        * @endif
        */
        kNERtcSendOnPubHigh = 1,
        /**
        * @if English
        * The client actively sends the substream.
        * @endif
        * @if Chinese
        * 主动发送小流。
        * @endif
        */
        kNERtcSendOnPubLow = 1 << 1,
        /**
        * @if English
        * The client actively sends the mainstream and the substream.
        * @endif
        * @if Chinese
        * 主动发送大小流。
        * @endif
        */
        kNERtcSendOnPubAll = kNERtcSendOnPubLow | kNERtcSendOnPubHigh,
    }
    

    /**
    * @if English
    * Configures private servers.
    * @note To use private servers, contact technical support for help.
    * @endif
    * @if Chinese
    * 私有化服务器配置项
    * @note 如需启用私有化功能，请联系技术支持获取详情。
    * @endif
    */
    public struct RtcServerAddresses
    {
        /**
        * @if English
        * 获取通道信息服务器
        * @endif
        * @if Chinese
        * The channel server.
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst = 256)]
        public string channelServer;
        /**
        * @if English
        * The stats server.
        * @endif
        * @if Chinese
        * 统计上报服务器
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string statisticsServer;
        /**
        * @if English
        * The roomServer server.
        * @endif
        * @if Chinese
        * roomServer服务器
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string roomServer;
        /**
        * @if English
        * The compatibility configuration server.
        * @endif
        * @if Chinese
        * 兼容性配置服务器
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string compatServer;
        /**
        * @if English
        * The NOS domain name resolution server.
        * @endif
        * @if Chinese
        * nos 域名解析服务器
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string nosLbsServer;
        /**
        * @if English
        * The default NOS upload server.
        * @endif
        * @if Chinese
        * 默认nos 上传服务器
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string nosUploadSever;
        /**
        * @if English
        * The NOS token server.
        * @endif
        * @if Chinese
        * 获取NOS token 服务器
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string nosTokenServer;
        /**
        * @if English
        * Specifies whether to use Ipv6. The default value is false.
        * @endif
        * @if Chinese
        * 是否使用IPv6（默认false)
        * @endif
        */
        bool useIpv6;
    }

    /**
    * @if English
    * Recording audio quality.
    * @endif
    * @if Chinese
    * 录音音质
    * @endif
    */
    public enum RtcAudioRecordingQuality : int
    {
        /**
        * @if English
        * Low quality
        * @endif
        * @if Chinese
        * 低音质
        * @endif
        */
        kNERtcAudioRecordingQualityLow = 0,
        /**
        * @if English
        * medium quality
        * @endif
        * @if Chinese
        * 中音质
        * @endif
        */
        kNERtcAudioRecordingQualityMedium = 1,
        /**
        * @if English
        * High quality
        * @endif
        * @if Chinese
        * 高音质
        * @endif
        */
        kNERtcAudioRecordingQualityHigh = 2,
    }
    
    /**
    * @if English
    * The error code of recording callbacks.
    * @endif
    * @if Chinese
    * 录音回调事件错误码
    * @endif
    */
    public enum RtcAudioRecordingCode : int
    {
        /**
        * @if English
        * Unsupported recording file format.
        * @endif
        * @if Chinese
        * 不支持的录音文件格式。
        * @endif
        */
        kNERtcAudioRecordErrorSuffix = 1,
        /**
        * @if English
        * fails to create a recording file. Reasons:
        * - The application does not have the write permissions.
        * - The file path does not exist.
        * @endif
        * @if Chinese
        * 无法创建录音文件，原因通常包括：
        * - 应用没有磁盘写入权限。
        * - 文件路径不存在。
        * @endif
        */
        kNERtcAudioRecordOpenFileFailed = 2,
        /**
        * @if English
        * Starts recording.
        * @endif
        * @if Chinese
        * 开始录制。
        * @endif
        */
        kNERtcAudioRecordStart = 3,
        /**
        * @if English
        * An error occurs during recording. The typical reason is that the disk space is full and cannot be written.
        * @endif
        * @if Chinese
        * 录制错误。原因通常为磁盘空间已满，无法写入。
        * @endif
        */
        kNERtcAudioRecordError = 4,
        /**
        * @if English
        * Recording is complete.
        * @endif
        * @if Chinese
        * 完成录制。
        * @endif
        */
        kNERtcAudioRecordFinish = 5,
    }
    

    /**
    * @if English
    * Fallback options when the uplink and downlink connections are weak.
    * @endif
    * @if Chinese
    * 上行、下行弱网时的回退选项。
    * @endif
    */
    public enum RtcStreamFallbackOption : int
    {
        /**
        * @if English
        * If the uplink or downlink network is unstable, the audio and video streams will not fall back, but the quality of the audio
        * and video streams cannot be guaranteed.
        * @note This option is only valid for the setLocalPublishFallbackOption method, and invalid for the
        * setRemoteSubscribeFallbackOption method.
        * @endif
        * @if Chinese
        * 上行或下行网络较弱时，不对音视频流作回退处理，但不能保证音视频流的质量。
        * @note 该选项只对 setLocalPublishFallbackOption 方法有效，对 setRemoteSubscribeFallbackOption 方法无效。
        * @endif
        */
        kNERtcStreamFallbackDisabled = 0,

        /**
        * @if English
        * In an unstable downlink network, the SDK only receives low-definition streams that have low resolution and bitrate.
        * @note This option is only valid for the setRemoteSubscribeFallbackOption method, and invalid for the
        * setLocalPublishFallbackOption method.
        * @endif
        * @if Chinese
        * 在下行网络条件较差的情况下，SDK 将只接收视频小流，即低分辨率、低码率视频流。
        * @note 该选项只对 setRemoteSubscribeFallbackOption 方法有效，对 setLocalPublishFallbackOption 方法无效。
        * @endif
        */
        kNERtcStreamFallbackVideoStreamLow = 1,

        /**
        * @if English
        * - In an unstable uplink network, only the audio stream is published.
        * - In an unstable downlink network, first try to receive only low-definition streams, which have low resolution and bitrate.
        * If the video stream cannot be displayed due to network quality, then the stream falls back to the audio stream.
        * @endif
        * @if Chinese
        * - 上行网络较弱时，只发布音频流。
        * - 下行网络较弱时，先尝试只接收视频小流，即低分辨率、低码率视频流。如果网络环境无法显示视频，则再回退到只接收音频流。
        * @endif
        */
        kNERtcStreamFallbackAudioOnly = 2,
    }
    

    /**
    * @if English
    * Media stream encryption mode.
    * @endif
    * @if Chinese
    * 媒体流加密模式。
    * @endif
    * */
    public enum RtcEncryptionMode : int
    {
        /**
        * @if English
        * 128-bit SM4 encryption, ECB mode.
        * @endif
        * @if Chinese
        * 128 位 SM4 加密，ECB 模式。
        * @endif
        */
        kNERtcGMCryptoSM4ECB = 0,
    }
    

    /**
    * @if English
    * Media stream encryption scheme.
    * @endif
    * @if Chinese
    * 媒体流加密方案。
    * @endif
    */
    public struct RtcEncryptionConfig
    {
        /**
        * @if English
        * Media stream encryption mode. For more information, see #RtcEncryptionMode .
        * @endif
        * @if Chinese
        * 媒体流加密模式。详细信息请参考 #RtcEncryptionMode 。
        * @endif
        */
        public RtcEncryptionMode mode;
        /**
        * @if English
        * Media stream encryption key. The key is of string type. We recommend that you set the key to a string that contains only
        * letters.
        * @endif
        * @if Chinese
        * 媒体流加密密钥。字符串类型，推荐设置为英文字符串。
        * @endif
        */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string key;
    }

    /**
    * @if English
    * Configurations of the last-mile network probe test.
    * @endif
    * @if Chinese
    * Last mile 网络探测配置。
    * @endif
    */
    public struct RtcLastmileProbeConfig
    {
        /**
        * @if English
        * Sets whether to test the uplink network.
        * <br>Some users, for example, the audience in a kNERtcChannelProfileLiveBroadcasting channel, do not need such a test。
        * - true: test.
        * - false: do not test.
        * @endif
        * @if Chinese
        * 是否探测上行网络。
        * <br>不发流的用户，例如直播房间中的普通观众，无需进行上行网络探测。
        * - true: 探测。
        * - false: 不探测。
        * @endif
        */
        [MarshalAs(UnmanagedType.I1)]
        public bool probeUplink;
        /**
        * @if English
        * Sets whether to test the downlink network:
        * - true: test.
        * - false: do not test.
        * @endif
        * @if Chinese
        * 是否探测下行网络。
        * - true: 探测。
        * - false: 不探测。
        * @endif
        */
        [MarshalAs(UnmanagedType.I1)]
        public bool probeDownlink;
        /**
        * @if English
        * The expected maximum sending bitrate (bps) of the local user.
        * <br>The value ranges between 100000 and 5000000.
        * <br>We recommend setting this parameter according to the bitrate value set by setVideoConfig.
        * @endif
        * @if Chinese
        * 本端期望的最高发送码率。
        * <br>单位为 bps，范围为 [100000, 5000000]。
        * <br>推荐参考 setVideoConfig 中的码率值设置该参数的值。
        * @endif
        */
        public uint expectedUplinkBitratebps;
        /**
        * @if English
        * The expected maximum receiving bitrate (bps) of the local user. The value ranges between 100000 and 5000000.
        * @endif
        * @if Chinese
        * 本端期望的最高接收码率。
        * <br>单位为 bps，范围为 [100000, 5000000]。
        * @endif
        */
        public uint expectedDownlinkBitratebps;
    }

    /**
    * @if English
    * States of the last-mile network probe test.
    * @endif
    * @if Chinese
    * Last mile 质量探测结果的状态。
    * @endif
    */
    public enum RtcLastmileProbeResultState : int
    {
        /**
        * @if English
        * The last-mile network probe test is complete.
        * @endif
        * @if Chinese
        * 表示本次 last mile 质量探测的结果是完整的。
        * @endif
        */
        kNERtcLastmileProbeResultComplete = 1,
        /**
        * @if English
        * The last-mile network probe test is incomplete and the bandwidth estimation is not available, probably due to limited test
        * resources.
        * @endif
        * @if Chinese
        * 表示本次 last mile 质量探测未进行带宽预测，因此结果不完整。通常原因为测试资源暂时受限。
        * @endif
        */
        kNERtcLastmileProbeResultIncompleteNoBwe = 2,
        /**
        * @if English
        * The last-mile network probe test is not carried out, probably due to poor network conditions.
        * @endif
        * @if Chinese
        * 未进行 last mile 质量探测。通常原因为网络连接中断。
        * @endif
        */
        kNERtcLastmileProbeResultUnavailable = 3,
    }
    

    /**
    * @if English
    * The uplink or downlink last-mile network probe test result.
    * @endif
    * @if Chinese
    * 单向 Last mile 网络质量探测结果报告。
    * @endif
    */
    public struct RtcLastmileProbeOneWayResult
    {
        /**
        * @if English
        * The network jitter (ms).
        * @endif
        * @if Chinese
        * 网络抖动，单位为毫秒 (ms)。
        * @endif
        */
        public uint jitter;
        /**
        * @if English
        * The packet loss rate (%).
        * @endif
        * @if Chinese
        * 丢包率（%）。
        * @endif
        */
        public uint packetLossRate;
        /**
        * @if English
        * The available band width (bps).
        * @endif
        * @if Chinese
        * 可用网络带宽预估，单位为 bps。
        * @endif
        */
        public uint availableBandWidth;
    }

    /**
    * @if English
    * The uplink and downlink last-mile network probe test result.
    * @endif
    * @if Chinese
    * 上下行 Last mile 网络质量探测结果。
    * @endif
    */
    public struct RtcLastmileProbeResult
    {
        /**
        * @if English
        * The round-trip delay time (ms).
        * @endif
        * @if Chinese
        * 往返时延，单位为毫秒（ms）。
        * @endif
        */
        public uint rtt;
        /**
        * @if English
        * The state of the probe test.
        * @endif
        * @if Chinese
        * Last mile 质量探测结果的状态。
        * @endif
        */
        public RtcLastmileProbeResultState state;
        /**
        * @if English
        * The uplink last-mile network probe test result.
        * @endif
        * @if Chinese
        * 上行网络质量报告。
        * @endif
        */
        [MarshalAs(UnmanagedType.Struct)]
        public RtcLastmileProbeOneWayResult uplinkReport;
        /**
        * @if English
        * The downlink last-mile network probe test result.
        * @endif
        * @if Chinese
        * 下行网络质量报告。
        * @endif
        */
        [MarshalAs(UnmanagedType.Struct)]
        public RtcLastmileProbeOneWayResult downlinkReport;
    }
    
     /**
     * @if English
     * Room capacity for spatializer.
     * @endif
     * @if Chinese
     * 空间音效房间大小
     * @endif
     */
    public enum RtcSpatializerRoomCapacity : int
    {
        /**
         * @if English
         * Small room.
         * @endif
         * @if Chinese
         * 小房间
         * @endif
         */
        kNERtcSpatializerRoomCapacitySmall = 0,

        /**
         * @if English
         * Medium-size room.
         * @endif
         * @if Chinese
         * 中等大小房间
         * @endif
         */
        kNERtcSpatializerRoomCapacityMedium = 1,

        /**
         * @if English
         * Large room.
         * @endif
         * @if Chinese
         * 大房间
         * @endif
         */
        kNERtcSpatializerRoomCapacityLarge = 2,

        /**
         * @if English
         * Extra large room.
         * @endif
         * @if Chinese
         * 巨大房间
         * @endif
         */
        kNERtcSpatializerRoomCapacityHuge = 3,

        /**
         * @if English
         * No room effect.
         * @endif
         * @if Chinese
         * 无房间效果
         * @endif
         */
        kNERtcSpatializerRoomCapacityNone = 4
    }

    /**
     * @if English
     * Spatializer material name.
     * @endif
     * @if Chinese
     * 空间音效中房间材质名称
     * @endif
     */
    public enum RtcSpatializerMaterialName : int
    {
        /**
         * @if English
         * Transparent.
         * @endif
         * @if Chinese
         * 透明的
         * @endif
         */
        kNERtcSpatializerMaterialTransparent = 0,
        /**
         * @if English
         * Acoustic ceiling tiles. unvailable
         * @endif
         * @if Chinese
         * 声学天花板，未开放
         * @endif
         */
        kNERtcSpatializerMaterialAcousticCeilingTiles,
        /**
         * @if English
         * Bare brick. unvailable
         * @endif
         * @if Chinese
         * 砖块，未开放
         * @endif
         */
        kNERtcSpatializerMaterialBrickBare,
        /**
         * @if English
         * Painted brick. unvailable
         * @endif
         * @if Chinese
         * 涂漆的砖块，未开放
         * @endif
         */
        kNERtcSpatializerMaterialBrickPainted,
        /**
         * @if English
         * Coarse concrete block . unvailable
         * @endif
         * @if Chinese
         * 粗糙的混凝土块，未开放
         * @endif
         */
        kNERtcSpatializerMaterialConcreteBlockCoarse,
        /**
         * @if English
         * Concrete block painted. unvailable
         * @endif
         * @if Chinese
         * 涂漆的混凝土块，未开放
         * @endif
         */
        kNERtcSpatializerMaterialConcreteBlockPainted,
        /**
         * @if English
         * Heavy curtain. unvailable
         * @endif
         * @if Chinese
         * 厚重的窗帘
         * @endif
         */
        kNERtcSpatializerMaterialCurtainHeavy,
        /**
         * @if English
         * Fiber glass insulation. unvailable
         * @endif
         * @if Chinese
         * 隔音的玻璃纤维，未开放
         * @endif
         */
        kNERtcSpatializerMaterialFiberGlassInsulation,
        /**
         * @if English
         * Thin glass. unvailable
         * @endif
         * @if Chinese
         * 薄的的玻璃，未开放
         * @endif
         */
        kNERtcSpatializerMaterialGlassThin,
        /**
         * @if English
         * Thick glass. unvailable
         * @endif
         * @if Chinese
         * 茂密的草地，未开放
         * @endif
         */
        kNERtcSpatializerMaterialGlassThick,
        /**
         * @if English
         * Grass. unvailable
         * @endif
         * @if Chinese
         * 草地
         * @endif
         */
        kNERtcSpatializerMaterialGrass,
        /**
         * @if English
         * Linoleum on concrete. unvailable
         * @endif
         * @if Chinese
         * 铺装了油毡的混凝土，未开放
         * @endif
         */
        kNERtcSpatializerMaterialLinoleumOnConcrete,
        /**
         * @if English
         * Marble. unvailable
         * @endif
         * @if Chinese 
         * 大理石
         * @endif
         */
        kNERtcSpatializerMaterialMarble,
        /**
         * @if English
         * Metal. unvailable
         * @endif
         * @if Chinese 
         * 金属，未开放
         * @endif
         */
        kNERtcSpatializerMaterialMetal,
        /**
         * @if English
         * Parquet on concrete. unvailable
         * @endif
         * @if Chinese 
         * 镶嵌木板的混凝土，未开放
         * @endif
         */
        kNERtcSpatializerMaterialParquetOnConcrete,
        /**
         * @if English
         * Plaster rough. unvailable
         * @endif
         * @if Chinese 
         * 石膏，未开放
         * @endif
         */
        kNERtcSpatializerMaterialPlasterRough,
        /**
         * @if English
         * Plaster smooth. unvailable
         * @endif
         * @if Chinese 
         * 粗糙石膏，未开放
         * @endif
         */
        kNERtcSpatializerMaterialPlasterSmooth,
        /**
         * @if English
         * Plywood panel. unvailable
         * @endif
         * @if Chinese 
         * 光滑石膏，未开放
         * @endif
         */
        kNERtcSpatializerMaterialPlywoodPanel,
        /**
         * @if English
         * Polished concrete or tile. unvailable
         * @endif
         * @if Chinese 
         * 木板，未开放
         * @endif
         */
        kNERtcSpatializerMaterialPolishedConcreteOrTile,
        /**
         * @if English
         * Sheet rock. unvailable
         * @endif
         * @if Chinese 
         * 石膏灰胶纸板，未开放
         * @endif
         */
        kNERtcSpatializerMaterialSheetrock,
        /**
         * @if English
         * Water or ice surface. unvailable
         * @endif
         * @if Chinese 
         * 水面或者冰面，未开放
         * @endif
         */
        kNERtcSpatializerMaterialWaterOrIceSurface,
        /**
         * @if English
         * Wood ceiling. unvailable
         * @endif
         * @if Chinese 
         * 木头天花板，未开放
         * @endif
         */
        kNERtcSpatializerMaterialWoodCeiling,
        /**
         * @if English
         * Wood panel. unvailable
         * @endif
         * @if Chinese 
         * 木头枪板，未开放
         * @endif
         */
        kNERtcSpatializerMaterialWoodPanel,
        /**
         * @if English
         * Uniform. unvailable
         * @endif
         * @if Chinese 
         * 均匀分布，未开放
         * @endif
         */
        kNERtcSpatializerMaterialUniform
    }

    /**
     * @if English
     * Spatializer rendering mode.
     * @endif
     * @if Chinese 
     * 空间音效渲染模式
     * @endif
     */
    public enum RtcSpatializerRenderMode : int
     {
        /**
         * @if English
         * Stereo panning
         * @endif
         * @if Chinese 
         * 立体声 panning
         * @endif
         */
        kNERtcSpatializerRenderStereoPanning = 0,
        /**
         * @if English
         * Low-quality binaural
         * @endif
         * @if Chinese 
         * 低复杂度双耳渲染(Binaural)
         * @endif
         */
        kNERtcSpatializerRenderBinauralLowQuality,
        /**
         * @if English
         * Medium-quality binaural
         * @endif
         * @if Chinese 
         * 中复杂度双耳渲染(Binaural)
         * @endif
         */
        kNERtcSpatializerRenderBinauralMediumQuality,
        /**
         * @if English
         * High-quality binaural
         * @endif
         * @if Chinese 
         * 高复杂度双耳渲染(Binaural)
         * @endif
         */
        kNERtcSpatializerRenderBinauralHighQuality,
        /**
         * @if English
         * Room effects only
         * @endif
         * @if Chinese 
         * 仅房间音效
         * @endif
         */
        kNERtcSpatializerRenderRoomEffectsOnly
    }
    /**
     * @if English
     * Distance rolloff mode
     * @endif
     * @if Chinese 
     * 空间音效衰减模式
     * @endif
     */
    public enum RtcDistanceRolloffModel : int
    {
        /**
         * @if English
         * Logarithmic rolloff
         * @endif
         * @if Chinese 
         * 指数模式
         * @endif
         */
        kNERtcDistanceRolloffLogarithmic = 0,
        /**
         * @if English
         * Linear rolloff
         * @endif
         * @if Chinese 
         * 线性模式
         * @endif
         */
        kNERtcDistanceRolloffLinear,
        /**
         * @if English
         * None rolloff
         * @endif
         * @if Chinese 
         * 无衰减
         * @endif
         */
        kNERtcDistanceRolloffNone,
    }

    /**
     * @if English
     * Spatializer position info.
     * @endif
     * @if Chinese 
     * 3D音效算法中坐标信息。
     * @endif
     */
    public struct RtcSpatializerPositionInfo
    {
        /**
         * @if English
         * Speaker position
         * @endif
         * @if Chinese 
         * 发声坐标
         * @endif
         */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] speakerPosition;
        /**
         * @if English
         * speaker quaternion
         * @endif
         * @if Chinese 
         * 发声旋转角度四元数
         * @endif
         */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] speakerQuaternion;
        /**
         * @if English
         * head position
         * @endif
         * @if Chinese 
         * 头部听觉坐标
         * @endif
         */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] headPosition;
        /**
         * @if English
         * Head quaternion
         * @endif
         * @if Chinese 
         * 头部听觉旋转角度四元数
         * @endif
         */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] headQuaternion;
    };

    /**
     * @if English
     * Spatializer room property.
     * @endif
     * @if Chinese 
     * 3D音效房间属性设置。
     * @endif
     */
    public struct RtcSpatializerRoomProperty
    {
        /**
         * @if English
         * Room capacity #RtcSpatializerRoomCapacity. 默认值Default value: \ref RtcSpatializerRoomCapacity::kNERtcSpatializerRoomCapacitySmall
         * @endif
         * @if Chinese 
         * 房间大小 #RtcSpatializerRoomCapacity ，默认值 \ref RtcSpatializerRoomCapacity::kNERtcSpatializerRoomCapacitySmall
         * @endif
         */
        public RtcSpatializerRoomCapacity roomCapacity;
        /**
         * @if English
         * Room material #RtcSpatializerMaterialName. Default value: \ref RtcSpatializerMaterialName::kNERtcSpatializerMaterialTransparent
         * @endif
         * @if Chinese 
         * 房间材质 #RtcSpatializerMaterialName ，默认值 \ref RtcSpatializerMaterialName::kNERtcSpatializerMaterialTransparent
         * @endif
         */
        public RtcSpatializerMaterialName material;
        /**
         * @if English
         * Reflection scalar, the default value of 1.0, the range of the value [1.0 30]
         * @endif
         * @if Chinese 
         * 反射系数的比例因子，默认值1.0, 取值范围[1.0 30]
         * @endif
         */
        public float reflectionScalar;
        /**
         * @if English
         * The proportion factor of the reverb gain, the default value of 1.0, the value range [1.0 10]
         * @endif
         * @if Chinese 
         * 混响增益比例因子，默认值1.0, 取值范围[1.0 10]
         * @endif
         */
        public float reverbGain;
        /**
         * @if English
         * The reverb time ratio factor, RT60 will be multiplied with this value, the default value is 1.0 (no effect), and the value range [1.0 30]
         * @endif
         * @if Chinese 
         * 混响时间比例因子，RT60会和该值相乘，默认值1.0(无效果), 取值范围[1.0 30]
         * @endif
         */
        public float reverbTime;
         /**
         * @if English
         * Reverb brightness. When this value is positive and increases, the high-frequency component increases. 0.0 is used by default value (no effect), and the value range [-30 30]
         * @endif
         * @if Chinese 
         * 混响亮度，该值为正且增加时，增加高频成分，该值为负数时衰减高频成分，默认值0.0(无效果), 取值范围[-30 30]
         * @endif
         */
        public float reverbBrightness;
    };

    /**
     * @if English
     * Audio device error.
     * @endif
     * @if Chinese 
     * 音频设备错误码
     * @endif
     */
    public enum RtcAudioDeviceError : int
    {
        /** 
         * to be add
         */
        kNERtcAudioDeviceNoError = 0,
        /** 
         * to be add
         */
        kNERtcAudioDeviceErrorInitRecording,
        /** 
         * to be add
         */
        kNERtcAudioDeviceErrorStartRecording,
        /** 
         * to be add
         */
        kNERtcAudioDeviceErrorStopRecording,
        /** 
         * to be add
         */
        kNERtcAudioDeviceErrorInitPlayout,
        /** 
         * to be add
         */
        kNERtcAudioDeviceErrorStartPlayout,
        /** 
         * to be add
         */
        kNERtcAudioDeviceErrorStopplayout,
        /** 
         * to be add
         */
        kNERtcAudioDeviceErrorCaptureThreadStop,
        /** 
         * to be add
         */
        kNERtcAudioDeviceErrorPlayoutThreadStop,
        /** 
         * to be add
         */
        kNERtcAudioDeviceErrorCaptureSampleRate,
        /** 
         * to be add
         */
        kNERtcAudioDeviceErrorPlayoutSampleRate,
        /** 
         * to be add
         */
        kNERtcAudioDeviceErrorConfigSession,
        /** 
         * to be add
         */
        kNERtcAudioDeviceErrorCodeReporter
    }
    
    /**
     * @if English
     * Video device error.
     * @endif
     * @if Chinese 
     * 视频设备错误码
     * @endif
     */
    public enum RtcVideoDeviceError : int
    {
        /** 
         * to be add
         */
        kNERtcVideoDeviceErrorNoFrame = 0,
        /** 
         * to be add
         */
        kNERtcVideoDeviceErrorNotAvailableInBackground,
        /** 
         * to be add
         */
        kNERtcVideoDeviceErrorUsingByAnotherClient,
        /** 
         * to be add
         */
        kNERtcVideoDeviceErrorNotAvailableWithMultipleForegroundApps,
    }
    

    /**
     * @if English
     * Audio output routing for iOS and Android.
     * @endif
     * @if Chinese 
     * 音频路由 仅iOS和Android有效
     * @endif
     */
    public enum RtcAudioOutputRouting : int
    {
        /**
         * @if English
         * Default
         * @endif
         * @if Chinese 
         * 系统默认
         * @endif
         */
        kNERtcAudioOutputRoutingDefault = 0,
        /**
         * @if English
         * Headset
         * @endif
         * @if Chinese 
         * 耳机
         * @endif
         */
        kNERtcAudioOutputRoutingHeadset,
        /**
         * @if English
         * Earpiece
         * @endif
         * @if Chinese 
         * 听筒
         * @endif
         */
        kNERtcAudioOutputRoutingEarpiece,
        /**
         * @if English
         * Loudspeaker
         * @endif
         * @if Chinese 
         * 扬声器
         * @endif
         */
        kNERtcAudioOutputRoutingLoudspeaker,
        /**
         * @if English
         * Bluetooth
         * @endif
         * @if Chinese 
         * 蓝牙外设
         * @endif
         */
        kNERtcAudioOutputRoutingBluetooth,   
    }
    

    /**
     * @if English
     * Network type.
     * @endif
     * @if Chinese 
     * 网络类型 
     * @endif
     */
    public enum RtcNetworkType
    {
        /** 
         * to be add
         */
        kNERtcNetworkTypeUnknown = 0,
        /** 
         * to be add
         */
        kNERtcNetworkTypeEthernet,
        /** 
         * to be add
         */
        kNERtcNetworkTypeWifi,
        /** 
         * to be add
         */
        kNERtcNetworkType2G,
        /** 
         * to be add
         */
        kNERtcNetworkType3G,
        /** 
         * to be add
         */
        kNERtcNetworkType4G,
        /** 
         * to be add
         */
        kNERtcNetworkType5G,
        /** 
         * to be add
         */
        kNERtcNetworkTypeWWAN,
        /** 
         * to be add
         */
        kNERtcNetworkTypeBluetooth,
        /** 
         * to be add
         */
        kNERtcNetworkTypeNone
    }

    /**
     * @if English
     * Camera focus and exposure info.
     * @endif
     * @if Chinese 
     * 摄像头焦点或曝光位置信息
     * @endif
     */
    public struct RtcCameraFocusAndExposureInfo
    {
        /** 
         * to be add
         */
        public float centerX;
        /** 
         * to be add
         */
        public float centerY;
        /** 
         * to be add
         */
        public int left;
        /** 
         * to be add
         */
        public int top;
        /** 
         * to be add
         */
        public int right;
        /** 
         * to be add
         */
        public int bottom;
    }
    /**
    * @if English
    * Audio session control permissions
    * <br>The SDK has the permissions of Audio Session.
    * @endif
    * @if Chinese
    * 音频会话控制权限。
    * <br>SDK 对 Audio Session 的控制权限。
    * @endif
    */
    public enum RtcAudioSessionOperationRestriction
    {
        /**
        * @if English
        * The SDK has full permissions and can control the Audio Session
        * @endif
        * @if Chinese
        * 没有限制，SDK 可以完全控制 Audio Session 操作。
        * @endif
        */
        kNERtcAudioSessionOperationRestrictionNone = 0,
        /**
        * @if English
        * If you restrict the SDK to perform operations on the Audio Session, the SDK cannot configure the Audio Session
        * @endif
        * @if Chinese
        * 限制 SDK 对 Audio Session 进行任何操作，SDK 将不能再对 Audio Session 进行任何配置。
        * @endif
        */
        kNERtcAudioSessionOperationRestrictionAll,
        /**
        * @if English
        * When a user leaves the room, the SDK will keep the Audio Session active.
        * @endif
        * @if Chinese
        * 离开房间时，SDK 会保持 Audio Session 处于活动状态。
        * @endif
        */
        kNERtcAudioSessionOperationRestrictionDeactivateSession,
    }
    ;
}
