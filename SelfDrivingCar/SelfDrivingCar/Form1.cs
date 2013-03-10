using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SelfDrivingCar
{
    public partial class Form1 : Form
    {
        private const int GRID_WIDTH = 15;
        private const int GRID_HEIGHT = 10;
        private Map map;
        private Thread carThread;
        private Bitmap mapBmp;

        public Form1()
        {
            InitializeComponent();
            initWorldMap();
        }

        private void initWorldMap()
        {
            map = new Map(GRID_WIDTH, GRID_HEIGHT);
            Bitmap bmp = new Bitmap(GRID_WIDTH * map.SquareSize + 1, GRID_HEIGHT * map.SquareSize + 1);
            /*for (int i = 0; i < worldMap.Size.Width; i++)
            {
                for (int j = 0; j < worldMap.Size.Height; j++)
                {
                    if (i % 50 == 0 || j % 50 == 0)
                    {
                        bmp.SetPixel(i, j, Color.Black);
                    }
                }
            }*/
            worldMap.Image = bmp;
            carThread = new Thread(new ThreadStart(moveCar));
            carThread.IsBackground = true;
            pictureBox1.Image = null;
            mapBmp = new Bitmap(GRID_WIDTH + 2, GRID_HEIGHT + 2);
        }

        private void worldMap_Click(object sender, EventArgs e)
        {
            int i = ((MouseEventArgs)e).Y / map.SquareSize;
            int j = ((MouseEventArgs)e).X / map.SquareSize;

            if (map[j, i].IsObstacle)
            {
                setObstacle(i, j, false);
            }
            else
            {
                setObstacle(i, j, true);
            }
            
        }

        private void setObstacle(int x, int y, bool obstacle)
        {
            Bitmap bmp = (Bitmap) worldMap.Image;
            map[y, x].IsObstacle = obstacle;
            for (int i = 1; i < map.SquareSize; i++)
            {
                for (int j = 1; j < map.SquareSize; j++)
                {
                    if(obstacle)
                    {
                        bmp.SetPixel(y * map.SquareSize + j, x * map.SquareSize + i, Color.Black);
                    }
                    else
                    {
                        bmp.SetPixel(y * map.SquareSize + j, x * map.SquareSize + i, Color.White);
                    }
                }
            }

            worldMap.Image = bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private Graphics createGraphics()
        {
            return worldMap.CreateGraphics();
        }

        private void moveCar()
        {
            CurrentPosition pos = new CurrentPosition();
            Car car = new Car(createGraphics(), createGraphics(), map, pos, mapBmp);
            constructMap();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            String portName = comPortName.Text;
            int portRate = int.Parse(comPortRate.Text);
            Communicator communicator = new Communicator(portName, portRate);
            carThread.Start();
            startCar.Enabled = false;
            stopCar.Enabled = true;
        }

        private void stopCar_Click(object sender, EventArgs e)
        {
            carThread.Suspend();
            constructMap();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            initWorldMap();
            stopCar.Enabled = false;
            startCar.Enabled = true;
        }

        private void constructMap()
        {
            Bitmap result = new Bitmap(mapBmp.Width * 4, mapBmp.Height * 4);
            for (int i = 0; i < mapBmp.Width; i++)
            {
                for (int j = 0; j < mapBmp.Height; j++)
                {
                    for (int ii = 0; ii < 4; ii++)
                    {
                        for (int jj = 0; jj < 4; jj++)
                        {
                            result.SetPixel(result.Width - 1 - (4 * i + ii), result.Height - 1 - (4 * j + jj), mapBmp.GetPixel(i, j));
                        }
                    }
                }
            }

            Bitmap bmp2Scale = new Bitmap(400, 400);
            using (Graphics graphics = Graphics.FromImage(bmp2Scale))
            {
                graphics.DrawImage(result, new Rectangle(0, 0, bmp2Scale.Width, bmp2Scale.Height));
            }
            pictureBox1.Image = bmp2Scale;
        }
    }
}
