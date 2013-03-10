using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace SelfDrivingCar
{
    class Communicator
    {
        public static SerialPort _serialPort;

        public Communicator(String name, int rate)
        {
            _serialPort = new SerialPort();
            _serialPort.BaudRate = rate;
            _serialPort.PortName = name;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
        }

        static void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort _serialPort = (SerialPort)sender;
            Console.WriteLine(_serialPort.ReadExisting());
        }

        public void write(string str)
        {
            _serialPort.WriteLine(str);
        }

    }
}
