using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Point Center;
        Random rnd = new Random();

        private void Form2_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked)
            {

                Point A = new Point(Center.X - rnd.Next(pictureBox1.Size.Width / 20, pictureBox1.Size.Width / 9), Center.Y + rnd.Next(pictureBox1.Size.Height / 20, pictureBox1.Size.Height / 10));
                Point B = Graphs.RotatePoint(A, Center, 120);
                Point C = Graphs.RotatePoint(B, Center, 120);
                e.Graphics.DrawLine(Pens.Black, A, B);
                e.Graphics.DrawLine(Pens.Black, B, C);
                e.Graphics.DrawLine(Pens.Black, C, A);
                e.Graphics.DrawLine(Pens.White, Center, A);
                e.Graphics.DrawLine(Pens.White, Center, B);
                e.Graphics.DrawLine(Pens.White, Center, C);
                BonusLines(A, B, C, e);
            }
        }
        private void BonusLines(Point A, Point B, Point C, PaintEventArgs e)
        {
            int w = rnd.Next(1, 4);

            if (checkBox1.Checked)
            {
                int procent = rnd.Next(1, 21);
                if (w == 1)
                {
                    Point T = Graphs.RotatePoint(Center, A, 180);

                    e.Graphics.DrawLine(Pens.Black, A, T);
                    e.Graphics.DrawLine(Pens.Black, B, T);
                    e.Graphics.DrawLine(Pens.Black, C, T);
                }
                else if (w == 2)
                {
                    Point T = Graphs.RotatePoint(Center, B, 180);
                    e.Graphics.DrawLine(Pens.Black, A, T);
                    e.Graphics.DrawLine(Pens.Black, B, T);
                    e.Graphics.DrawLine(Pens.Black, C, T);
                }
                else if (w == 3)
                {
                    Point T = Graphs.RotatePoint(Center, C, 180);
                    e.Graphics.DrawLine(Pens.Black, A, T);
                    e.Graphics.DrawLine(Pens.Black, B, T);
                    e.Graphics.DrawLine(Pens.Black, C, T);
                }
            }
            else if (checkBox2.Checked)
            {
                if (w == 1)
                {
                    Point T = Graphs.RotatePoint(Center, A, 180);
                    e.Graphics.DrawLine(Pens.Black, A, T);
                    e.Graphics.DrawLine(Pens.Black, B, T);
                    e.Graphics.DrawLine(Pens.Black, C, T);
                    Point R = Graphs.RotatePoint(Center, B, 180);
                    e.Graphics.DrawLine(Pens.Black, A, R);
                    e.Graphics.DrawLine(Pens.Black, B, R);
                    e.Graphics.DrawLine(Pens.Black, C, R);

                    e.Graphics.DrawLine(Pens.Black, T, R);
                }
                else if (w == 2)
                {
                    Point T = Graphs.RotatePoint(Center, B, 180);
                    e.Graphics.DrawLine(Pens.Black, A, T);
                    e.Graphics.DrawLine(Pens.Black, B, T);
                    e.Graphics.DrawLine(Pens.Black, C, T);
                    Point R = Graphs.RotatePoint(Center, C, 180);
                    e.Graphics.DrawLine(Pens.Black, A, R);
                    e.Graphics.DrawLine(Pens.Black, B, R);
                    e.Graphics.DrawLine(Pens.Black, C, R);

                    e.Graphics.DrawLine(Pens.Black, T, R);
                }
                else if (w == 3)
                {
                    Point T = Graphs.RotatePoint(Center, C, 180);
                    e.Graphics.DrawLine(Pens.Black, A, T);
                    e.Graphics.DrawLine(Pens.Black, B, T);
                    e.Graphics.DrawLine(Pens.Black, C, T);
                    Point R = Graphs.RotatePoint(Center, A, 180);
                    e.Graphics.DrawLine(Pens.Black, A, R);
                    e.Graphics.DrawLine(Pens.Black, B, R);
                    e.Graphics.DrawLine(Pens.Black, C, R);

                    e.Graphics.DrawLine(Pens.Black, T, R);
                }
            }
            else if (checkBox3.Checked)
            {
                Point T = Graphs.RotatePoint(Center, A, 180);
                e.Graphics.DrawLine(Pens.Black, A, T);
                e.Graphics.DrawLine(Pens.Black, B, T);
                e.Graphics.DrawLine(Pens.Black, C, T);
                Point R = Graphs.RotatePoint(Center, B, 180);
                e.Graphics.DrawLine(Pens.Black, A, R);
                e.Graphics.DrawLine(Pens.Black, B, R);
                e.Graphics.DrawLine(Pens.Black, C, R);
                Point U = Graphs.RotatePoint(Center, C, 180);
                e.Graphics.DrawLine(Pens.Black, A, U);
                e.Graphics.DrawLine(Pens.Black, B, U);
                e.Graphics.DrawLine(Pens.Black, C, U);

                e.Graphics.DrawLine(Pens.Black, T, R);
                e.Graphics.DrawLine(Pens.Black, U, R);
                e.Graphics.DrawLine(Pens.Black, T, U);

            }
        }
        private void pictureBox_MouseDown(object sender, MouseEventArgs e = null)
        {
            Center = new Point(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2);
            pictureBox1.Refresh();
        }

        private void checkBox_MouseDown(object sender, MouseEventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            Center = new Point(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2);
            pictureBox1.Refresh();
        }
    }
}
