using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutApp.utill
{
    class PortUtil
    {
        public SerialPort GetSerialPort()
        {
            SerialPort serialPort = new SerialPort();
            return serialPort;
        }
    }
}
