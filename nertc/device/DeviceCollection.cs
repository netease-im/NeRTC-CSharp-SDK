using System;
using System.Text;

namespace nertc
{
    /**
    * @if English
    * Device-related methods.
    * <br>The interface class gets device-related information.

    * @endif
    * @if Chinese
    * 设备相关方法。
    * <br>此接口类获取设备相关的信息。
    * @endif
    */
    public abstract class IDeviceCollection : IDeviceCollectionNative
    {
        /**
        * @if English
        * Gets the number of devices.
        * @note You must call \ref IAudioDeviceManager::EnumeratePlayoutDevices "EnumeratePlayoutDevices" or \ref
        * IAudioDeviceManager::EnumeratePlayoutDevices "EnumeratePlayoutDevices" before calling the method to get the number of playing
        * and capturing devices.
        * @return The number of capturing and playback devices.
        * @endif
        * @if Chinese
        * 获取设备数量。
        * @note 调用此方法之前，必须调用 \ref IAudioDeviceManager::EnumeratePlayoutDevices "EnumeratePlayoutDevices" 或 \ref
        * IAudioDeviceManager::EnumeratePlayoutDevices "EnumeratePlayoutDevices" 方法获取播放或采集设备数量。
        * @return 采集或播放设备数量。
        * @endif
        */
        public abstract ushort GetCount();

        /**
        * @if English
        * Gets the device information of the specified index.
        * @param index specifies the device information that you want to check. The value must be lower than the value returned by
        * \ref IDeviceCollection::GetCount "GetCount".
        * @param deviceName Device name.
        * @param deviceId Device ID.
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 获取指定 index 的设备信息。
        * @param index  指定想查询的设备信息。必须小于 \ref IDeviceCollection::GetCount "GetCount"返回的值。
        * @param deviceName  设备名称。
        * @param deviceId  设备 ID。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int GetDevice(ushort index, out string deviceName, out string deviceId);

        /**
        * @if English
        * Searches specified information about index-related devices.
        * @note The link method of returnable devices and the non-useful status determined by the SDK.
        * @param index specifies the device information that you want to check.
        * @param deviceInfo For information about device information, see \ref RtcDeviceInfo "RtcDeviceInfo".
        * @return
        * - 0: Success.
        * - Other values: Failure.
        * @endif
        * @if Chinese
        * 检索有关索引设备的指定信息。
        * @note 可返回设备的链接方式，和SDK判定的疑似不可用状态。
        * @param index  指定想查询的设备信息。
        * @param deviceInfo 设备信息，详细信息请参考 \ref RtcDeviceInfo "RtcDeviceInfo"。
        * @return
        * - 0: 方法调用成功；
        * - 其他: 方法调用失败。
        * @endif
        */
        public abstract int GetDeviceInfo(ushort index, ref RtcDeviceInfo deviceInfo);

        /**
        * @if English
        * Releases all IDeviceCollection resources.
        * @endif
        * @if Chinese
        * 释放所有 IDeviceCollection 资源。
        * @endif
        */
        public abstract void Destroy();
    }
    internal sealed class DeviceCollection : IDeviceCollection
    {
        RtcEngine _rtcEngine = null;
        IntPtr _nativeSelf = IntPtr.Zero;
        public DeviceCollection(RtcEngine rtcEngine,IntPtr native)
        {
            _rtcEngine = rtcEngine;
            _nativeSelf = native;
        }
        public override ushort GetCount()
        {
            return IDeviceCollectionNative.getCount(_nativeSelf);
        }

        public override int GetDevice(ushort index, out string deviceName, out string deviceId)
        {
            var device_name = new StringBuilder(256);
            var device_id = new StringBuilder(256);

            int result = IDeviceCollectionNative.getDevice(_nativeSelf, index, device_name, device_id);
            deviceName = device_name.ToString();
            deviceId = device_id.ToString();

            return result;
        }

        public override int GetDeviceInfo(ushort index, ref RtcDeviceInfo deviceInfo)
        {
            return IDeviceCollectionNative.getDeviceInfo(_nativeSelf, index, ref deviceInfo);
        }
        public override void Destroy()
        {
            IDeviceCollectionNative.destroy(_nativeSelf);
            _rtcEngine = null;
            _nativeSelf = IntPtr.Zero;
        }
    }
}
