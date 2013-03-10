using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelfDrivingCar
{
    class PhysicCar
    {
        public PhysicCar(Communicator com)
        {
            _com = com;
        }

        Communicator _com;



        public int _Speed;

        public int _Distance;

        public void ExecuteCommand(char command, Int32 speed)
        {
            string str = command + speed.ToString();
            while (str.Length < 4)
            {
                str += "0";
            }
            if (str != _OldCommand)
            {
                _com.write(str);
            }
            _OldCommand = str;
        }

        private string _OldCommand;

        private const char _FORWARD = 'w';
        private const char _BACKWARD = 's';

        private const char _LEFT_ROTATE = 'a';
        private const char _RIGHT_ROTATE = 'd';

        private const char _FRONT_WHEELS_FORWARD = 'f';
        private const char _FRONT_WHEELS_BACKWARD = 'v';
        private const char _REAR_WHEELS_FORWARD = 'r';
        private const char _REAR_WHEELS_BACKWARD = 't';

        private const char _LEFT_WHEELS_FORWARD = 'q';
        private const char _LEFT_WHEELS_BACKWARD = 'z';
        private const char _RIGHT_WHEELS_FORWARD = 'e';
        private const char _RIGHT_WHEELS_BACKWARD = 'c';
    }
}
