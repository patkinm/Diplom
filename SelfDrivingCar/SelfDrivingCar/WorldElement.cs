using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelfDrivingCar
{
    class WorldElement
    {
        private int x;
        private int y;
        private bool isObstacle;

        public WorldElement()
        {
            isObstacle = false;
        }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public bool IsObstacle
        {
            get
            {
                return isObstacle;
            }
            set
            {
                isObstacle = value;
            }
        }
    }
}
