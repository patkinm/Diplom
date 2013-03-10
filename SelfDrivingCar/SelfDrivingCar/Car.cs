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
        private Graphics gc;
        private Image carImg;
        private const int initialX = 15;
        private const int initialY = 10;
        private int currentX;
        private int currentY;
        private Map map;
        private CurrentPosition pos;
        private Bitmap bmp;

        private enum Way
        {
            LEFT, UP, RIGHT, DOWN
        };
        private Way way;

        public Car(Graphics model, Graphics gc, Map map, CurrentPosition pos, Bitmap bmp)
        {
            this.model = model;
            this.gc = gc;
            this.map = map;
            carImg = Image.FromFile("menti.gif");
            currentX = initialX - 1;
            currentY = initialY - 1;
            this.pos = pos;
            this.pos.X = 1;
            this.pos.Y = 1;
            this.pos.VelocityX = 100;
            this.pos.VelocityY = 0;
            this.bmp = bmp;
            way = Way.LEFT;
            move();
        }

        public void move()
        {
            while (true)
            {
                switch (way)
                {
                    case Way.LEFT:
                        {
                            while (isNotObstacle(currentX, currentY))
                            {
                                moveByOneStep(currentX, currentY, Way.LEFT);
                            }
                            break;
                        }
                    case Way.UP:
                        {
                            while (isNotObstacle(currentX, currentY))
                            {
                                moveByOneStep(currentX, currentY, Way.UP);
                            }
                            break;
                        }
                    case Way.RIGHT:
                        {
                            while (isNotObstacle(currentX, currentY))
                            {
                                moveByOneStep(currentX, currentY, Way.RIGHT);
                            }
                            break;
                        }
                    case Way.DOWN:
                        {
                            while (isNotObstacle(currentX, currentY))
                            {
                                moveByOneStep(currentX, currentY, Way.DOWN);
                            }
                            break;
                        }
                }
                randomTurn();
                remove(currentX, currentY);
            }
        }

        private void randomTurn()
        {
            Random rnd = new Random();
            if (rnd.Next(100) % 2 == 0) turnRight();
            else turnLeft();
        }

        private void turnLeft()
        {
            switch (way)
            {
                case Way.UP:
                    {
                        way = Way.LEFT;
                        this.pos.VelocityX = 100;
                        this.pos.VelocityY = 0;
                        bmp.SetPixel((int)(pos.X), (int)(pos.Y) + 1, Color.Red);
                        break;
                    }
                case Way.LEFT:
                    {
                        way = Way.DOWN;
                        this.pos.VelocityX = 0;
                        this.pos.VelocityY = -100;
                        bmp.SetPixel((int)(pos.X) + 1, (int)(pos.Y), Color.Red);
                        break;
                    }
                case Way.DOWN:
                    {
                        way = Way.RIGHT;
                        this.pos.VelocityX = -100;
                        this.pos.VelocityY = 0;
                        bmp.SetPixel((int)(pos.X), (int)(pos.Y) - 1, Color.Red);
                        break;
                    }
                case Way.RIGHT:
                    {
                        way = Way.UP;
                        this.pos.VelocityX = 0;
                        this.pos.VelocityY = 100;
                        bmp.SetPixel((int)(pos.X) - 1, (int)(pos.Y), Color.Red);
                        break;
                    }
            }
            for (int i = 0; i < 9; i++)
            {
                model.TranslateTransform(currentX * 50 + 25, currentY * 50 + 25);
                model.RotateTransform(-10);
                model.TranslateTransform(-currentX * 50 - 25, -currentY * 50 - 25);
                Thread.Sleep(30);
                remove(currentX, currentY);
                model.DrawImage(carImg, currentX * 50, currentY * 50);
            }
            remove(currentX, currentY);
            model.TranslateTransform(currentX * 50 + 25, currentY * 50 + 25);
            model.RotateTransform(90);
            model.TranslateTransform(-currentX * 50 - 25, -currentY * 50 - 25);
            carImg.RotateFlip(RotateFlipType.Rotate90FlipXY);
            model.DrawImage(carImg, currentX * 50, currentY * 50);
        }

        private void turnRight()
        {
            switch (way)
            {
                case Way.UP:
                    {
                        way = Way.RIGHT;
                        pos.VelocityX = -100;
                        pos.VelocityY = 0;
                        bmp.SetPixel((int)(pos.X), (int)(pos.Y) + 1, Color.Red);
                        break;
                    }
                case Way.LEFT:
                    {
                        way = Way.UP;
                        pos.VelocityX = 0;
                        pos.VelocityY = 100;
                        bmp.SetPixel((int)(pos.X) + 1, (int)(pos.Y), Color.Red);
                        break;
                    }
                case Way.DOWN:
                    {
                        way = Way.LEFT;
                        pos.VelocityX = 100;
                        pos.VelocityY = 0;
                        bmp.SetPixel((int)(pos.X), (int)(pos.Y) - 1, Color.Red);
                        break;
                    }
                case Way.RIGHT:
                    {
                        way = Way.DOWN;
                        pos.VelocityX = 0;
                        pos.VelocityY = -100;
                        bmp.SetPixel((int)(pos.X) - 1, (int)(pos.Y), Color.Red);
                        break;
                    }
            }
            for (int i = 0; i < 9; i++)
            {
                model.TranslateTransform(currentX * 50 + 25, currentY * 50 + 25);
                model.RotateTransform(10);
                model.TranslateTransform(-currentX * 50 - 25, -currentY * 50 - 25);
                Thread.Sleep(30);
                remove(currentX, currentY);
                model.DrawImage(carImg, currentX * 50, currentY * 50);
            }
            remove(currentX, currentY);
            model.TranslateTransform(currentX * 50 + 25, currentY * 50 + 25);
            model.RotateTransform(-90);
            model.TranslateTransform(-currentX * 50 - 25, -currentY * 50 - 25);
            carImg.RotateFlip(RotateFlipType.Rotate90FlipNone);
            model.DrawImage(carImg, currentX * 50, currentY * 50);
        }

        private void moveByOneStep(int x, int y, Way way)
        {
            int i = 0;
            switch (way)
            {
                case Way.LEFT:
                    {
                        currentX--;
                        while (i < map.SquareSize)
                        {
                            if (i % 4 == 0) remove(x, y);
                            model.DrawImage(carImg, x * Map.SQUARE_SIZE - i, y * Map.SQUARE_SIZE);
                            Thread.Sleep(10);
                            i += 2;
                        }
                        break;
                    }
                case Way.RIGHT:
                    {
                        currentX++;
                        while (i < map.SquareSize)
                        {
                            if (i % 4 == 0) remove(x, y);
                            model.DrawImage(carImg, x * Map.SQUARE_SIZE + i, y * Map.SQUARE_SIZE);
                            Thread.Sleep(10);
                            i += 2;
                        }
                        break;
                    }
                case Way.UP:
                    {
                        currentY--;
                        while (i < map.SquareSize)
                        {
                            if (i % 4 == 0) remove(x, y);
                            model.DrawImage(carImg, x * Map.SQUARE_SIZE, y * Map.SQUARE_SIZE - i);
                            Thread.Sleep(10);
                            i += 2;
                        }
                        break;
                    }
                case Way.DOWN:
                    {
                        currentY++;
                        while (i < map.SquareSize)
                        {
                            if (i % 4 == 0) remove(x, y);
                            model.DrawImage(carImg, x * Map.SQUARE_SIZE, y * Map.SQUARE_SIZE + i);
                            Thread.Sleep(10);
                            i += 2;
                        }
                        break;
                    }
            }

            pos.getNewX();
            pos.getNewY();
            bmp.SetPixel((int)(pos.X), (int)(pos.Y), Color.Green);
        }

        private void remove(int x, int y)
        {
            gc.FillRectangle(Brushes.White, x * Map.SQUARE_SIZE, y * Map.SQUARE_SIZE, Map.SQUARE_SIZE, Map.SQUARE_SIZE);
        }

        private bool isNotObstacle(int x, int y)
        {
            switch (way)
            {
                case Way.LEFT:
                    {
                        if (x >= 1)
                        {
                            return !map[x - 1, y].IsObstacle;
                        }
                        break;
                    }
                case Way.RIGHT:
                    {
                        if (x < 14)
                        {
                            return !map[x + 1, y].IsObstacle;
                        }
                        break;
                    }
                case Way.UP:
                    {
                        if (y >= 1)
                        {
                            return !map[x, y - 1].IsObstacle;
                        }
                        break;
                    }
                case Way.DOWN:
                    {
                        if (y < 9)
                        {
                            return !map[x, y + 1].IsObstacle;
                        }
                        break;
                    }
            }
            return false;
        }
    }
}
