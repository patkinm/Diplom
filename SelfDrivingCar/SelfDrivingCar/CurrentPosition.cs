using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelfDrivingCar
{
    class CurrentPosition
    {
        private double x;
        private double y;
        private double velocityX;
        private double velocityY;
        private const double tick = 0.01;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double VelocityX
        {
            get { return velocityX; }
            set { velocityX = value; }
        }

        public double VelocityY
        {
            get { return velocityY; }
            set { velocityY = value; }
        }

        public double getNewX()
        {
            x += velocityX * tick;
            return x;
        }

        public double getNewY()
        {
            y += velocityY * tick;
            return y;
        }
    }
}
