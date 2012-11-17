using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelfDrivingCar
{
    class Map
    {
        public static int SQUARE_SIZE = 50;
        private int width;
        private int height;
        private WorldElement[,] worldElements;

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            worldElements = new WorldElement[width, height];
            initWorldElements();
        }

        public int SquareSize
        {
            get
            {
                return SQUARE_SIZE;
            }
        }

        public WorldElement this[int i, int j]
        {
            get
            {
                if (i >= 0 && i < width && j >= 0 && j < height)
                {
                    return worldElements[i, j];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (i >= 0 && i < width && j >= 0 && j < height)
                {
                    worldElements[i, j] = value;
                }
            }
        }

        private void initWorldElements()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    worldElements[i, j] = new WorldElement();
                }
            }
        }
    }
}
