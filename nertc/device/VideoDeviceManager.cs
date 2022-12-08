using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nertc
{
    /**
    * @if English
    * Video device management method.
    * <br>The interface class provides related interfaces for video device management. Gets IVideoDeviceManager
    * interface by the IRtcEngine class. The interface class is supported on Windows and macOS only and unavailable for Android and iOS.
    * @endif
    * @if Chinese
    * 视频设备管理方法。
    * <br>此接口类提供用于管理视频设备的相关接口。 可通过 IRtcEngine 类来获取 IVideoDeviceManager
    * 接口。该接口类只支持 Windows 和 macOS 系统，不支持 Android 和 iOS 系统。
    * @endif
    */
    public abstract class IVideoDeviceManager : IVideoDeviceNative
    {
        /**
        * @if English
        * Gets the list of all video capturing devices in the system.
        * <br>The method returns an IDeviceCollection object that includes all Video capturing devices in the system. Enumerates
        * capturing devices with the App through the IDeviceCollection object.
        * @note
        * After the method is used, the App needs to destroy the returned object.
        * @return
        * - Success: An IDeviceCollection object includes all Video capturing devices.
        * - Failure: Null.
        * @endif
        * @if Chinese
        * 获取系统中所有的视频采集设备列表。
        * <br>该方法返回一个 IDeviceCollection 对象，包含系统中所有的音频采集设备。通过 IDeviceCollection 对象，App
        * 可以枚举视频采集设备。
        * @note
        * 在使用结束后，App 需调用 \ref IDeviceCollection::Destroy "Destroy" 方法销毁返回的对象。
        * @return
        * - 方法调用成功：一个 IDeviceCollection 对象，包含所有的视频采集设备。
        * - 方法调用失败：NULL 。
        * @endif
        */
        public abstract IDeviceCollection EnumerateCaptureDevices();
        /**
        * @if English
        * Specifies the video capturing device.
        * @param deviceId     The ID of video capturing devices. You can get the ID through the \ref IVideoDeviceManager::EnumerateCaptureDevices "EnumerateCaptureDevices" method.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 指定视频采集设备。
        * @param deviceId     视频采集设备的设备 ID。可以通过 \ref IVideoDeviceManager::EnumerateCaptureDevices "EnumerateCaptureDevices" 获取。
        * @return
        * - 0：方法调用成功；
        * - 其他： 方法调用失败。
        * @endif
        */
        public abstract int SetDevice(string deviceId);

        /**
        * @if English
        * Gets the ID of the Video capturing device that is currently used.
        * @param deviceId     The audio capture device.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 获取当前使用的视频采集设备信息。
        * @param deviceId     视频采集设备的设备 ID。
        * @return
        * - 0：方法调用成功；
        * - 其他： 方法调用失败。
        * @endif
        */
        public abstract int GetDevice(out string deviceId);
    }
    internal sealed class VideoDeviceManager : IVideoDeviceManager
    {
        RtcEngine _rtcEngine = null;
        IntPtr _nativeSelf = IntPtr.Zero;
        public VideoDeviceManager(RtcEngine rtcEngine, IntPtr native)
        {
            _rtcEngine = rtcEngine;
            _nativeSelf = native;
        }
        public override IDeviceCollection EnumerateCaptureDevices()
        {
            var native = IVideoDeviceNative.enumerateCaptureDevices(_nativeSelf);
            return new DeviceCollection(_rtcEngine, native);
        }

        public override int GetDevice(out string deviceId)
        {
            var device_id = new StringBuilder(256);
            int result = IVideoDeviceNative.getDevice(_nativeSelf, device_id);
            deviceId = device_id.ToString();
            return result;
        }

        public override int SetDevice(string deviceId)
        {
            return IVideoDeviceNative.setDevice(_nativeSelf, deviceId??string.Empty);
        }
    }
}
