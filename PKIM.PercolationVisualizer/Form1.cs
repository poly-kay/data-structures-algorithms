using PKIM.DynamicConnectivity;
using PKIM.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PKIM.PercolationVisualizer
{
    public partial class Form1 : Form
    {
        private Percolation Percolation { get; set; }
        private const int N = 100;
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(3000, 3000);
            this.Percolation = new Percolation(N);
            this.Paint += Draw2DArray;
        }

        private void Draw2DArray(object sender, PaintEventArgs e)
        {
            draw(Percolation, N);

            while (!Percolation.Percolates())
            {
                int row = StdRandom.Uniform(0, N);
                int col = StdRandom.Uniform(0, N);
                if (!Percolation.IsOpen(row, col))
                {
                    Percolation.Open(row, col);
                }
                //  System.Threading.Thread.Sleep(1);
            }
            draw(Percolation, N);

            var tt = (Percolation.OpenedSites * 1.00) / (N * N);
        }

        public void draw(Percolation perc, int N)
        {
            int step = 8;
            int width = 8; 
            int height = 8;



            // draw N-by-N grid
            using (Graphics g = this.CreateGraphics())
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    for (int row = 0; row < N; row++)
                    {
                        for (int col = 0; col < N; col++)
                        {
                            var boxColor = System.Drawing.Brushes.Black;

                            if (perc.IsFull(row, col))
                            {
                                boxColor = Brushes.LightBlue;
                            }

                            else if (perc.IsOpen(row, col))
                            {
                                boxColor = Brushes.White;
                            }
                            else
                            {
                                boxColor = Brushes.Black;
                            }

                            Rectangle rect = new Rectangle(new Point(3 + step * col, 3 + step * row), new Size(width, height));
                            g.DrawRectangle(pen, rect);
                            g.FillRectangle(boxColor, rect);
                        }
                    }
                }
            }
        }
    }
}
