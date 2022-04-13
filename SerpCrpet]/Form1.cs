using System;
using System.Drawing;
using System.Windows.Forms;

namespace SerpCrpet_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void DrawRectangle(Graphics gr, int level, RectangleF rect)
        {
            if (level == 0)
            {
                gr.FillRectangle(Brushes.Blue, rect);
            }
            else
            {
                float wid = rect.Width / 3;
                float x0 = rect.Left;
                float x1 = x0 + wid;
                float x2 = x0 + wid * 2;

                float hgt = rect.Height / 3;
                float y0 = rect.Top;
                float y1 = y0 + hgt;
                float y2 = y0 + hgt * 2;

                level--;
                DrawRectangle(gr, level, new RectangleF(x0, y0, wid, hgt));
                DrawRectangle(gr, level, new RectangleF(x1, y0, wid, hgt));
                DrawRectangle(gr, level, new RectangleF(x2, y0, wid, hgt));
                DrawRectangle(gr, level, new RectangleF(x0, y1, wid, hgt));
                DrawRectangle(gr, level, new RectangleF(x2, y1, wid, hgt));
                DrawRectangle(gr, level, new RectangleF(x0, y2, wid, hgt));
                DrawRectangle(gr, level, new RectangleF(x1, y2, wid, hgt));
                DrawRectangle(gr, level, new RectangleF(x2, y2, wid, hgt));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
            DrawRectangle(this.CreateGraphics(), Convert.ToInt32(textBox1.Text), new RectangleF(new Point(130, 10), new Size(this.Width - 160, this.Height - 50)));
        }

        private void DrawTriangle(Graphics gr, int level, PointF[] points)
        {
            if (level == 0)
            {
                gr.FillPolygon(Brushes.Blue, new PointF[3] { points[0], points[1], points[2] });
            }
            else
            {
                float wid = Math.Abs(points[1].X - points[2].X) / 4;
                float x0 = points[2].X;
                float x1 = points[2].X + wid;
                float x2 = points[2].X + wid * 2;
                float x3 = points[2].X + wid * 3;
                float x4 = points[2].X + wid * 4;

                float hgt = Math.Abs(points[0].Y - points[1].Y) / 2;
                float y0 = points[0].Y;
                float y1 = points[0].Y + hgt;
                float y2 = points[0].Y + hgt * 2;

                level--;
                DrawTriangle(gr, level, new PointF[3] { new PointF(x2, y0), new PointF(x3, y1), new PointF(x1, y1) });
                DrawTriangle(gr, level, new PointF[3] { new PointF(x1, y1), new PointF(x2, y2), new PointF(x0, y2) });
                DrawTriangle(gr, level, new PointF[3] { new PointF(x3, y1), new PointF(x4, y2), new PointF(x2, y2) });

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Refresh();
            DrawTriangle(this.CreateGraphics(), Convert.ToInt32(textBox2.Text), new PointF[3] { new PointF(this.Width / 2, 10), new PointF(this.Width-10, this.Height-40), new PointF(10, this.Height - 40) });
        }
    }
}
