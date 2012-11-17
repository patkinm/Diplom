using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading;

namespace SelfDrivingCar
{
    class Car
    {
        private Graphics model;
        private Image carImg;
        private const int initialX = 15;
        private const int initialY = 10;
        private int currentX;
        private int currentY;

        public Car(Graphics model)
        {
            this.model = model;
            carImg = Image.FromFile("menti.gif");
            currentX = initialX - 1;
            currentY = initialY - 1;
            draw(currentX, currentY);
        }

        public void move()
        {
            currentX -= 1;
            draw(currentX, currentY);
        }

        private void draw(int x, int y)
        {
            int i = 0;
            while (i < 50)
            {
                model.DrawImage(carImg, x * Map.SQUARE_SIZE - i, y * Map.SQUARE_SIZE);
                Thread.Sleep(10);
                model.FillRectangle(Brushes.White, x * Map.SQUARE_SIZE + (Map.SQUARE_SIZE - i) - 4, y * Map.SQUARE_SIZE, 2, Map.SQUARE_SIZE);
                i += 2;
            }

        }

        public bool needDraw()
        {
            return (currentX > 0) && (currentY > 0);
        }
    }
}
