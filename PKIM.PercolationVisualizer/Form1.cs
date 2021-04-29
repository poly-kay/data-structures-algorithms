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
        private HashSet<int> FullSites { get; set; }
        private int ClosedSites { get; set; }
        private HashSet<int> OpenSites { get; set; }
        private Percolation Percolation { get; set; }
        private const int N = 20;
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(3000, 3000);
            this.Percolation = new Percolation(N);
            this.OpenSites = new HashSet<int>();
            this.FullSites = new HashSet<int>();
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
                    draw(Percolation, N);
                }
                //  System.Threading.Thread.Sleep(1);
            }

            var tt = (Percolation.OpenedSites * 1.00) / (N * N);
        }

        public void draw(Percolation perc, int N)
        {
            //StdDraw.clear();
            //StdDraw.setPenColor(StdDraw.BLACK);
            //StdDraw.setXscale(-.05 * N, 1.05 * N);
            //StdDraw.setYscale(-.05 * N, 1.05 * N);   // leave a border to write text
            //StdDraw.filledSquare(N / 2.0, N / 2.0, N / 2.0);

            int step = 15; //distance between the rows and columns
            int width = 14; //the width of the rectangle
            int height = 14; //the height of the rectangle



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
                                FullSites.Add(row * N + col);
                                boxColor = Brushes.LightBlue;
                            }

                            else if (perc.IsOpen(row, col))
                            {
                                OpenSites.Add(row * N + col);
                                boxColor = Brushes.White;
                            }
                            else
                            {
                                ClosedSites++;
                                boxColor = Brushes.Black;
                            }

                            Rectangle rect = new Rectangle(new Point(3 + step * col, 3 + step * row), new Size(width, height));
                            g.DrawRectangle(pen, rect);
                            g.FillRectangle(boxColor, rect);
                        }
                    }
                }
            }





            //// write status text
            //StdDraw.setFont(new Font("SansSerif", Font.PLAIN, 12));
            //StdDraw.setPenColor(StdDraw.BLACK);
            //StdDraw.text(.25 * N, -N * .025, opened + " open sites");
            //if (perc.percolates()) StdDraw.text(.75 * N, -N * .025, "percolates");
            //else StdDraw.text(.75 * N, -N * .025, "does not percolate");

        }
    }
}
