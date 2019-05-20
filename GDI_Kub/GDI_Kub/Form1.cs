using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDI_Kub
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            List<Rectangle> rects = new List<Rectangle>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    rects.Add(new Rectangle(200 + (100 * j), 200 + (100 * i), 100, 100));
                }
            }
            List<Brush> brushes = new List<Brush>();
            brushes.Add(Brushes.HotPink);
            brushes.Add(new HatchBrush(HatchStyle.Vertical, Color.White, Color.Blue));
            brushes.Add(Brushes.Violet);
            brushes.Add(new LinearGradientBrush(rects[6], Color.Pink, Color.LightBlue, 0.0f));
            brushes.Add(Brushes.DarkViolet);
            brushes.Add(Brushes.Orange);
            brushes.Add(new LinearGradientBrush(rects[6], Color.Violet, Color.DarkViolet, 0.0f));
            brushes.Add(new TextureBrush(Image.FromFile("texture1.jpg"), rects[7]));
            brushes.Add(new TextureBrush(Image.FromFile("texture2.jpg"), rects[8]));
            for (int i = 0; i < 9; i++)
            {
                g.FillRectangle(brushes[i], rects[i]);
            }
            Pen pen = new Pen(Brushes.White, 2);
            g.DrawLine(pen, 300, 200, 300, 500);
            g.DrawLine(pen, 400, 200, 400, 500);
            pen.DashStyle = DashStyle.Dash;
            g.DrawLine(pen, 200, 300, 500, 300);
            g.DrawLine(pen, 200, 400, 500, 400);
        }
    }
}