# BLETest
windows BLE编程 net winform 连接蓝牙4.0

源代码作者及博客：
![windows BLE编程 net winform 连接蓝牙4.0 - 鞪林](https://www.cnblogs.com/webtojs/p/9675956.html)

调用方法：
> bluetooth = new BluetoothLECode(_serviceGuid, _writeCharacteristicGuid, _notifyCharacteristicGuid);
> bluetooth.ValueChanged += Bluetooth_ValueChanged; 

其中三个参数：
> private string _serviceGuid = "0000ffe0-0000-1000-8000-00805f9b34fb";
> private string _writeCharacteristicGuid = "0000ffe1-0000-1000-8000-00805f9b34fb";
> private string _notifyCharacteristicGuid = "0000ffe1-0000-1000-8000-00805f9b34fb";

可以使用BLE蓝牙工具查看：
> _serviceGuid：服务UUID
> _writeCharacteristicGuid: 特征值UUID
> _notifyCharacteristicGuid: 通知UUID

