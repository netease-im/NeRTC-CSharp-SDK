using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nertc
{
    /**
    * @if English
    * Audio device management method.
    * <br>The interface class provides related interfaces for audio device management. Gets IAudioDeviceManager
    * interface by the IRtcEngine class. The interface class is supported on Windows and macOS only and unavailable for Android and iOS.
    * @endif
    * @if Chinese
    * 音频设备管理方法。
    * <br>此接口类提供用于管理音频设备的相关接口。可以通过 IRtcEngine 类来获取 IAudioDeviceManager
    * 接口。该接口类只支持 Windows 和 macOS 系统，不支持 Android 和 iOS 系统。
    * @endif
    */
    public abstract class IAudioDeviceManager :IAudioDeviceNative
    {
        /**
        * @if English
        * Gets the list of all the audio capture devices in the system.
        * <br>The method returns an IDeviceCollection object that includes all the audio capture devices in the system. Enumerates
        * capturing devices with the App through the IDeviceCollection object.
        * @note After the method is used, the App needs to destroy the returned object by calling \ref IDeviceCollection::Destroy "Destroy" 
        * method.
        * @return
        * - Success: IDeviceCollection object including all audio capture devices.
        * - Failure: Null.
        * @endif
        * @if Chinese
        * 获取系统中所有的音频采集设备列表。
        * <br>该方法返回一个 IDeviceCollection 对象，包含系统中所有的音频采集设备。通过 IDeviceCollection 对象，App
        * 可以枚举音频采集设备。
        * @note 在使用结束后，App 需调用  \ref IDeviceCollection::Destroy "Destroy"  方法销毁返回的对象。
        * @return
        * - 方法调用成功：一个 IDeviceCollection 对象，包含所有的音频采集设备。
        * - 方法调用失败：NULL。
        * @endif
        * */
        public abstract IDeviceCollection EnumerateRecordDevices();
        /**
        * @if English
        * Specifies the audio capture device.
        * @param deviceId The device ID of the audio capture devices. Gets the ID through EnumerateRecordDevices. Device swapping or
        * plugging does not affect deviceId.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 指定音频采集设备。
        * @param deviceId 音频采集设备的设备 ID。可通过 \ref IAudioDeviceManager::EnumerateRecordDevices "EnumerateRecordDevices"获取。插拔设备不会影响 deviceId。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        * */
        public abstract int SetRecordDevice(string deviceId);
        /**
        * @if English
        * Gets the ID of the audio capture device that is currently used.
        * @param deviceId The device ID of the audio capture devices.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 获取当前使用的音频采集设备 ID。
        * @param deviceId 音频采集设备的设备 ID。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        * */
        public abstract int GetRecordDevice(out string deviceId);
        /**
        * @if English
        * Gets the list of all playback devices in the system.
        * <br>The method returns an IDeviceCollection object that includes all audio playback devices in the system. Enumerates
        * playback devices with the App through the IDeviceCollection object. After the method is used, the App needs to destroy the
        * returned object by calling the \ref IDeviceCollection::Destroy "Destroy"  method.
        * @note The system must destroy the returned value by calling \ref IDeviceCollection::Destroy "Destroy" method.
        * @return
        * - Success: Gets an IDeviceCollection object that includes all audio playback devices.
        * - Failure: Null.
        * @endif
        * @if Chinese
        * 获取系统中所有的播放设备列表。
        * <br>该方法返回一个 IDeviceCollection 对象，包含系统中所有的播放设备。通过 IDeviceCollection 对象，App
        * 可以枚举播放设备。在使用结束后，App 需调用 \ref IDeviceCollection::Destroy "Destroy"  方法销毁返回的对象。
        * @note 程序必须调用 \ref IDeviceCollection::Destroy "Destroy" 方法销毁返回的值。
        * @return
        * - 方法调用成功：一个 IDeviceCollection 对象，包含所有的音频播放设备。
        * - 方法调用失败：NULL。
        * @endif
        * */
        public abstract IDeviceCollection EnumeratePlayoutDevices();
        /**
        * @if English
        * Specifies the audio playback device.
        * @param deviceId The device ID of audio playback devices. Gets the ID through \ref
        * IAudioDeviceManager::EnumeratePlayoutDevices "EnumeratePlayoutDevices". Device swapping or plugging does not affect
        * deviceId.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 指定播放设备。
        * @param deviceId 音频播放设备的设备 ID。可以通过 \ref IAudioDeviceManager::EnumeratePlayoutDevices
        * "EnumeratePlayoutDevices" 获取。插拔设备不会影响 deviceId。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        * */
        public abstract int SetPlayoutDevice(string deviceId);
        /**
        * @if English
        * Gets the ID of the audio playback device that is currently used.
        * @param deviceId The ID of audio playback devices.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 获取当前使用的音频播放设备 ID。
        * @param deviceId 音频播放设备的设备 ID。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        * */
        public abstract int GetPlayoutDevice(out string deviceId);

        /**
        * @if English
        * Sets the volume of the audio capture device.
        * @param volume The volume of the audio capture device. Valid values: 0 to 255.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置音频采集设备音量。
        * @param volume 音频采集设备音量。取值范围为 0~255。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        * */
        public abstract int SetRecordDeviceVolume(uint volume);
        /**
        * @if English
        * Gets the volume of the audio capture device.
        * @param volume The volume of the audio capture device.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 获取音频采集设备音量。
        * @param volume 音频采集设备音量。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        * */
        public abstract int GetRecordDeviceVolume(ref uint volume);
        /**
        * @if English
        * Sets the volume of audio playback device.
        * @param volume The volume of audio playback device. Valid values: 0 to 255.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 设置音频播放设备音量。
        * @param volume 音频播放设备音量。取值范围为 0~255。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        * */
        public abstract int SetPlayoutDeviceVolume(uint volume);
        /**
        * @if English
        * Gets the volume of audio playback device.
        * @param volume The volume of audio playback device.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 获取音频播放设备音量。
        * @param volume 音频播放设备音量。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        * */
        public abstract int GetPlayoutDeviceVolume(ref uint volume);
        /**
        * @if English
        * Specifies to mute or unmute the audio playback device.
        * @param mute indicates whether to unmute the audio playback device.
        * - true: Specifies to mute the audio playback device.
        * - false: Specifies to unmute the audio playback device.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 静音或取消静音音频播放设备。
        * @param mute 是否静音音频播放设备。
        * - true：静音音频播放设备。
        * - false：取消静音音频播放设备。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        * */
        public abstract int SetPlayoutDeviceMute(bool mute);

        /**
        * @if English
        * Confirms whether the audio playback device is muted.
        * @param mute indicates the audio playback device is muted.
        * - true: The device is muted.
        * - false: The device is unmuted.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 获取音频播放设备静音状态。
        * @param mute 音频播放设备静音状态。
        * - true：静音状态。
        * - false：非静音状态。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        * */
        public abstract int GetPlayoutDeviceMute(ref bool mute);

        /**
        * @if English
        * Specifies to mute or unmute the audio playback device.
        * @param mute indicates whether to unmute the audio playback device.
        * - true: Specifies to mute the audio playback device.
        * - false: Specifies to unmute the audio playback device.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        *  @endif
        *  @if Chinese
        * 静音或取消静音音频采集设备。
        * @param mute 是否静音音频采集设备。
        * - true：静音音频采集设备。
        * - false：取消静音音频采集设备。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        * */
        public abstract int SetRecordDeviceMute(bool mute);

        /**
        * @if English
        * Confirms whether the audio playback device is muted.
        * @param mute indicates the audio playback device is muted.
        * - true: The device is muted.
        * - false: The device is unmuted.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 获取音频采集设备静音状态。
        * @param mute 音频采集设备静音状态。
        * - true: 静音状态。
        * - false: 非静音状态。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        * */
        public abstract int GetRecordDeviceMute(ref bool mute);

        /**
        * @if English
        * Starts the test of the audio capture device.
        * <br>The method tests whether the audio capture device can work properly.
        * <br>After calling the method, the SDK triggers \ref OnLocalAudioVolumeIndication
        * "OnLocalAudioVolumeIndication"  callback at the time interval set in this method, which reports the volume information of
        * the capturing device.
        * @note
        * - Calls the method before a user needs to join a room.
        * - The test of the audio capture device can automatically stop after a call starts. You can also manually stop the test by
        * calling \ref IAudioDeviceManager::StopRecordDeviceTest "StopRecordDeviceTest" .
        * @param indicationInterval indicates the time interval that SDK returns \ref
        * OnLocalAudioVolumeIndication "OnLocalAudioVolumeIndication" callback. Unit: milliseconds.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 启动音频采集设备测试。
        * <br>该方法测试音频采集设备是否能正常工作。
        * <br>调用该方法后，SDK 会按设置的时间间隔触发 \ref OnLocalAudioVolumeIndication
        * "OnLocalAudioVolumeIndication"  回调， 报告采集设备的音量信息。
        * @note
        * - 该方法需在加入房间前调用。
        * - 音频采集设备测试会在通话开始后自动结束，您也可以手动调用 \ref IAudioDeviceManager::StopRecordDeviceTest "StopRecordDeviceTest" 停止音频采集设备测试。
        * @param indicationInterval SDK 返回 \ref OnLocalAudioVolumeIndication
        * "OnLocalAudioVolumeIndication"  回调的时间间隔，单位为毫秒。
        * @return
        * - 0: Success.
        * - other: Failure.
        * @endif
        * */
        public abstract int StartRecordDeviceTest(ulong indicationInterval);

        /**
        * @if English
        * Stops the test of the audio capture device.
        * <br>Uses the method to stop the test of the audio capture device.
        * @note
        * - Calls the method before a user needs to join a room.
        * - The test of the audio capture device can automatically stop after a call starts. You can also manually stop the test by
        * calling \ref IAudioDeviceManager::StopRecordDeviceTest "StopRecordDeviceTest".
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 停止音频采集设备测试。
        * <br>该方法停止音频采集设备测试。
        * @note
        * - 该方法需在加入房间前调用。
        * - 音频采集设备测试会在通话开始后自动结束，您也可以手动调用 \ref IAudioDeviceManager::StopRecordDeviceTest "StopRecordDeviceTest" 停止音频采集设备测试。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        * */
        public abstract int StopRecordDeviceTest();

        /**
        * @if English
        * Starts the test of the audio capture device.
        * The method tests whether the audio capture device can work properly. After the test is started, SDK plays the specified
        * audio files. If the sound is successfully played, the playback device can work properly. After calling the method, the SDK
        * triggers \ref OnLocalAudioVolumeIndication "OnLocalAudioVolumeIndication"  callback per 100 ms,
        * which reports the volume information of the playback device.
        * @note
        * - Calls the method before a user needs to join a room.
        * - The test of the audio playback device can automatically stop after a call starts. You can also manually stop the test by
        * calling \ref IAudioDeviceManager::StopPlayoutDeviceTest "StopPlayoutDeviceTest".
        * - Supported file formats: wav, mp3, aac.
        * @param testAudioFilePath The absolute path of audio files. The path string is encoded in UTF-8.
        * @return
        * - 0: Success. You can hear the audio of the set files.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 启动音频播放设备测试。
        * 该方法测试音频播放设备是否能正常工作。启动测试后，SDK 播放指定的音频文件，测试者如果能听到声音，说明播放设备能正常工作。
        * 调用该方法后，SDK 会每隔 100 ms 触发一次 \ref OnLocalAudioVolumeIndication
        * "OnLocalAudioVolumeIndication" 回调，报告播放设备的音量信息。
        * @note
        * - 该方法需在加入房间前调用。
        * - 音频播放设备测试会在通话开始后自动结束，您也可以手动调用 \ref IAudioDeviceManager::StopPlayoutDeviceTest "StopPlayoutDeviceTest" 停止音频播放设备测试。
        * - 支持文件格式包括 wav、mp3、aac。
        * @param testAudioFilePath 音频文件的绝对路径，路径字符串使用 UTF-8 编码格式。
        * @return
        * - 0: 成功，并且可以听到所设置文件的声音。
        * - 其他：失败。
        * @endif
        * */
        public abstract int StartPlayoutDeviceTest(string testAudioFilePath);

        /**
        * @if English
        * Stops the test of the audio capture device.
        * @note
        * - Calls the method before a user needs to join a room.
        * - The test of the audio playback device can automatically stop after a call starts. You can also manually stop the test by
        calling \ref IAudioDeviceManager::StopPlayoutDeviceTest "StopPlayoutDeviceTest".
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 停止播放设备测试。
        * @note
        * - 该方法需在加入房间前调用。
        * - 播放设备测试会在通话开始后自动结束，您也可以手动调用 \ref IAudioDeviceManager::StopPlayoutDeviceTest "StopPlayoutDeviceTest" 停止播放设备测试。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        * */
        public abstract int StopPlayoutDeviceTest();

        /**
        * @if English
        * Starts the test of the audio device circuit.
        * <br>The method tests whether the audio capturing and playback device can work properly. Once the test starts, the audio
        * capture device captures local audio, and then plays the local audio. The SDK triggers \ref  nertc::OnLocalAudioVolumeIndication "onLocalAudioVolumeIndication"  
        * callback at the time interval set in
        * this method,  which reports the volume information of the audio.
        * @note
        * - Calls the method before a user needs to join a room.
        * - The test of the audio device circuit can automatically stop after a call starts. You can also manually stop the test by
        * calling \ref IAudioDeviceManager::StopAudioDeviceLoopbackTest "StopAudioDeviceLoopbackTest" .
        * - You can use the method locally to test the audio device, which does not require an Internet connection.
        * @param indicationInterval The time interval that SDK returns \ref nertc::OnLocalAudioVolumeIndication "onLocalAudioVolumeIndication"  
        * callback. Unit: milliseconds.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 开始音频设备回路测试。
        * <br>该方法测试音频采集和播放设备是否能正常工作。一旦测试开始，音频采集设备会采集本地音频，然后使用音频播放设备播放出来。
        * SDK 会按设置的时间间隔触发  nertc::OnLocalAudioVolumeIndication "onLocalAudioVolumeIndication"  回调，
        * 报告音量信息。
        * @note
        * - 该方法需在加入房间前调用。
        * - 音频设备回路测试会在通话开始后自动结束，您也可以手动调用 \ref IAudioDeviceManager::StopAudioDeviceLoopbackTest "StopAudioDeviceLoopbackTest" 停止音频设备回路测试。
        * - 该方法仅在本地进行音频设备测试，不涉及网络连接。
        * @param indicationInterval SDK 返回  \ref nertc::OnLocalAudioVolumeIndication "onLocalAudioVolumeIndication" 
        * 回调的 时间间隔，单位为毫秒。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        * */
        public abstract int StartAudioDeviceLoopbackTest(ulong indicationInterval);
        /**
        * @if English
        * Stops the test of the audio device circuit.
        * @note
        * - Calls the method before a user needs to join a room.
        * - The test of the audio device circuit can automatically stop after a call starts. You can also manually stop the test by
        calling \ref IAudioDeviceManager::StopAudioDeviceLoopbackTest "StopAudioDeviceLoopbackTest".
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 停止音频设备回路测试。
        * @note
        * - 该方法需在加入房间前调用。
        * - 音频设备回路测试会在通话开始后自动结束，您也可以手动调用 \ref IAudioDeviceManager::StopAudioDeviceLoopbackTest "StopAudioDeviceLoopbackTest" 停止音频设备回路测试。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        * */
        public abstract int StopAudioDeviceLoopbackTest();

    }
    internal sealed class AudioDeviceManager : IAudioDeviceManager
    {
        RtcEngine _rtcEngine = null;
        IntPtr _nativeSelf = IntPtr.Zero;
        public AudioDeviceManager(RtcEngine rtcEngine,IntPtr native)
        {
            _rtcEngine = rtcEngine;
            _nativeSelf = native;
        }
        public override IDeviceCollection EnumeratePlayoutDevices()
        {
            IntPtr native = IAudioDeviceNative.enumeratePlayoutDevices(_nativeSelf);
            return new DeviceCollection(_rtcEngine, native);
        }

        public override IDeviceCollection EnumerateRecordDevices()
        {
            IntPtr native = IAudioDeviceNative.enumerateRecordDevices(_nativeSelf);
            return new DeviceCollection(_rtcEngine, native);
        }

        public override int GetPlayoutDevice(out string deviceId)
        {
            var device_id = new StringBuilder(256);
            int result = IAudioDeviceNative.getPlayoutDevice(_nativeSelf, device_id);
            deviceId = device_id.ToString();
            return result;
        }

        public override int GetPlayoutDeviceMute(ref bool mute)
        {
            return IAudioDeviceNative.getPlayoutDeviceMute(_nativeSelf, ref mute);
        }

        public override int GetPlayoutDeviceVolume(ref uint volume)
        {
            return IAudioDeviceNative.getPlayoutDeviceVolume(_nativeSelf, ref volume);
        }

        public override int GetRecordDevice(out string deviceId)
        {
            var device_id = new StringBuilder(256);
            int result = IAudioDeviceNative.getRecordDevice(_nativeSelf, device_id);
            deviceId = device_id.ToString();
            return result;
        }

        public override int GetRecordDeviceMute(ref bool mute)
        {
            return IAudioDeviceNative.getRecordDeviceMute(_nativeSelf, ref mute);
        }

        public override int GetRecordDeviceVolume(ref uint volume)
        {
            return IAudioDeviceNative.getRecordDeviceVolume(_nativeSelf, ref volume);
        }

        public override int SetPlayoutDevice(string deviceId)
        {
            return IAudioDeviceNative.setPlayoutDevice(_nativeSelf, deviceId ?? string.Empty);
        }

        public override int SetPlayoutDeviceMute(bool mute)
        {
            return IAudioDeviceNative.setPlayoutDeviceMute(_nativeSelf, mute);
        }

        public override int SetPlayoutDeviceVolume(uint volume)
        {
            return IAudioDeviceNative.setPlayoutDeviceVolume(_nativeSelf, volume);
        }

        public override int SetRecordDevice(string deviceId)
        {
            return IAudioDeviceNative.setRecordDevice(_nativeSelf, deviceId ?? string.Empty);
        }

        public override int SetRecordDeviceMute(bool mute)
        {
            return IAudioDeviceNative.setRecordDeviceMute(_nativeSelf, mute);
        }

        public override int SetRecordDeviceVolume(uint volume)
        {
            return IAudioDeviceNative.setRecordDeviceVolume(_nativeSelf, volume);
        }

        public override int StartAudioDeviceLoopbackTest(ulong indicationInterval)
        {
            return IAudioDeviceNative.startAudioDeviceLoopbackTest(_nativeSelf, indicationInterval);
        }

        public override int StartPlayoutDeviceTest(string testAudioFilePath)
        {
            return IAudioDeviceNative.startPlayoutDeviceTest(_nativeSelf, testAudioFilePath ?? string.Empty);
        }

        public override int StartRecordDeviceTest(ulong indicationInterval)
        {
            return IAudioDeviceNative.startRecordDeviceTest(_nativeSelf, indicationInterval);
        }

        public override int StopAudioDeviceLoopbackTest()
        {
            return IAudioDeviceNative.stopAudioDeviceLoopbackTest(_nativeSelf);
        }

        public override int StopPlayoutDeviceTest()
        {
            return IAudioDeviceNative.stopPlayoutDeviceTest(_nativeSelf);
        }

        public override int StopRecordDeviceTest()
        {
            return IAudioDeviceNative.stopRecordDeviceTest(_nativeSelf);
        }
    }
}
