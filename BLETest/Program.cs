using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using BLECode;

namespace BLETest
{
    class Program
    {
        BluetoothLECode bluetooth;

        private string _serviceGuid = "0000ffe0-0000-1000-8000-00805f9b34fb";
        private string _writeCharacteristicGuid = "0000ffe1-0000-1000-8000-00805f9b34fb";
        private string _notifyCharacteristicGuid = "0000ffe1-0000-1000-8000-00805f9b34fb";

        static void Main(string[] args)
        {
            Program p = new Program();
            p.BLETest();
            p.Write();

            Console.ReadKey();
        }

        private void BLETest()
        {
            string MAC = "a8:10:87:6a:f7:e8";

            bluetooth = new BluetoothLECode(_serviceGuid, _writeCharacteristicGuid, _notifyCharacteristicGuid);
            bluetooth.ValueChanged += Bluetooth_ValueChanged;
            bluetooth.SelectDeviceFromIdAsync(MAC);
        }

        private void Bluetooth_ValueChanged(MsgType type, string str, byte[] data)
        {
            Console.WriteLine(str);

            if (str.Contains('-'))
            {
                str = str.Replace('-', ' ').Trim();
                Console.WriteLine(HexToStr(str));
            }
        }

        private void Write()
        {
            string cmd = "*00AE0000#";
            byte[] msg = System.Text.Encoding.Default.GetBytes(cmd);

            //bluetooth.Write(msg);

            Thread.Sleep(3000);

            bluetooth.Write(msg);
        }

        private static string HexToStr(string mHex)
        {
            mHex = mHex.Replace(" ", "");
            if (mHex.Length <= 0) return "";
            byte[] vBytes = new byte[mHex.Length / 2];
            for (int i = 0; i < mHex.Length; i += 2)
                if (!byte.TryParse(mHex.Substring(i, 2), NumberStyles.HexNumber, null, out vBytes[i / 2]))
                    vBytes[i / 2] = 0;
            return ASCIIEncoding.Default.GetString(vBytes);
        }
    }
}
