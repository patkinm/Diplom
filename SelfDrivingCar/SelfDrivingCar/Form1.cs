using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SelfDrivingCar
{
    public partial class Form1 : Form
    {
        private const int GRID_WIDTH = 15;
        private const int GRID_HEIGHT = 10;
        private Map map;

        public Form1()
        {
            InitializeComponent();
            map = new Map(GRID_WIDTH, GRID_HEIGHT);
            initWorldMap();
        }

        private void initWorldMap()
        {
            Bitmap bmp = new Bitmap(GRID_WIDTH * map.SquareSize + 1, GRID_HEIGHT * map.SquareSize + 1);
            for (int i = 0; i < worldMap.Size.Width; i++)
            {
                for (int j = 0; j < worldMap.Size.Height; j++)
                {
                    if (i % 50 == 0 || j % 50 == 0)
                    {
                        bmp.SetPixel(i, j, Color.Black);
                    }
                }
            }
            worldMap.Image = bmp;
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

    }
}
