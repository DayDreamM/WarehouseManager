using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutApp.utill
{
    class PortConfig
    {
        public static bool IsOpen;
        public static SerialPort serialPort1 = new SerialPort();
    }
}
