using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace WindowsFormsApplication2
{
    class Graphs
    {
        Random rnd = new Random();
        private char[] characters = new char[3] { 'A', 'B', 'C' };
        private PictureBox pb;
        private Point Center;
        int RndX;
        int RndY;
        private Triangle Main;
        private SuperTriangle Current;
        public Graphs(PictureBox pb)
        {
            RndX = rnd.Next(-pb.Size.Width / 30, pb.Size.Width / 9);
            RndY = rnd.Next(-pb.Size.Height / 30, pb.Size.Height / 10);
            this.pb = pb;
            Center = new Point(pb.Size.Width / 2, pb.Size.Height / 2);
            Point FirstPoint = new Point(Center.X - RndX, Center.Y - RndY);// Первая рандомная точка треугольника
            Main = new Triangle(FirstPoint, RotatePoint(FirstPoint, Center, 120), RotatePoint(FirstPoint, Center, -120), Center);
        }
        public void DrawMain_T(PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Green, Main.A, Main.B);
            e.Graphics.DrawLine(Pens.Green, Main.B, Main.C);
            e.Graphics.DrawLine(Pens.Green, Main.C, Main.A);
            e.Graphics.DrawLine(Pens.Teal, Center, Main.A);
            e.Graphics.DrawLine(Pens.Teal, Center, Main.B);
            e.Graphics.DrawLine(Pens.Teal, Center, Main.C);
            DrawPoint(Main.A, e);
            DrawPoint(Main.B, e);
            DrawPoint(Main.C, e);
        }
        public void DrawAll_ST(PaintEventArgs e)
        {
            SuperTriangle current = this.Current;
            while (current != null)
            {
                DrawCurrent_ST(e, current);
                current = current.Link_STriangle;
            }
        }
        private void DrawCurrent_ST(PaintEventArgs e, SuperTriangle st)
        {
            SuperTriangle ST = st;
            Point[] points = ST.Exist();
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i].X != 0 && points[i].Y != 0)
                {
                    if (ST.Link_STriangle != null)
                    {
                        if (i == 0)
                        {
                            e.Graphics.DrawLine(Pens.Teal, ST.Link_STriangle.A, points[i]);
                            e.Graphics.DrawLine(Pens.Black, ST.Link_STriangle.B, points[i]);
                            e.Graphics.DrawLine(Pens.Black, ST.Link_STriangle.C, points[i]);
                        }
                        else if (i == 1)
                        {
                            e.Graphics.DrawLine(Pens.Black, ST.Link_STriangle.A, points[i]);
                            e.Graphics.DrawLine(Pens.Teal, ST.Link_STriangle.B, points[i]);
                            e.Graphics.DrawLine(Pens.Black, ST.Link_STriangle.C, points[i]);
                        }
                        else if (i == 2)
                        {
                            e.Graphics.DrawLine(Pens.Black, ST.Link_STriangle.A, points[i]);
                            e.Graphics.DrawLine(Pens.Black, ST.Link_STriangle.B, points[i]);
                            e.Graphics.DrawLine(Pens.Teal, ST.Link_STriangle.C, points[i]);
                        }
                        DrawPoint(points[i], e);
                    }
                    else if (ST.Link_Triangle != null)
                    {
                        if (i == 0)
                        {
                            e.Graphics.DrawLine(Pens.Teal, ST.Link_Triangle.A, points[i]);
                            e.Graphics.DrawLine(Pens.Black, ST.Link_Triangle.B, points[i]);
                            e.Graphics.DrawLine(Pens.Black, ST.Link_Triangle.C, points[i]);
                        }
                        else if (i == 1)
                        {
                            e.Graphics.DrawLine(Pens.Black, ST.Link_Triangle.A, points[i]);
                            e.Graphics.DrawLine(Pens.Teal, ST.Link_Triangle.B, points[i]);
                            e.Graphics.DrawLine(Pens.Black, ST.Link_Triangle.C, points[i]);
                        }
                        else if (i == 2)
                        {
                            e.Graphics.DrawLine(Pens.Black, ST.Link_Triangle.A, points[i]);
                            e.Graphics.DrawLine(Pens.Black, ST.Link_Triangle.B, points[i]);
                            e.Graphics.DrawLine(Pens.Teal, ST.Link_Triangle.C, points[i]);
                        }
                        DrawPoint(points[i], e);
                    }
                    else throw new Exception("Нету прошлого треугольника");
                }
            }
            if(st.IsFull())
            {
                e.Graphics.DrawLine(Pens.Teal, st.A,st.B);
                e.Graphics.DrawLine(Pens.Teal, st.B, st.C);
                e.Graphics.DrawLine(Pens.Teal, st.C, st.A);
            }

        }
        private void DrawPoint(Point p, PaintEventArgs e)
        {
            int radius = pb.Size.Height / 200;
            e.Graphics.DrawEllipse(Pens.Teal, p.X - radius, p.Y - radius, radius+radius, radius+radius);
            e.Graphics.FillEllipse(Brushes.Teal, p.X - radius, p.Y - radius, radius + radius, radius + radius);
        }
        public static Point RotatePoint(Point pointtoRotate, Point centerPoint, double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * (Math.PI / 180);
            double cos = Math.Cos(angleInRadians);
            double sin = Math.Sin(angleInRadians);
            return new Point
            {
                X =
                (int)
                (cos * (pointtoRotate.X - centerPoint.X) -
                sin * (pointtoRotate.Y - centerPoint.Y) + centerPoint.X),
                Y =
                (int)
                (sin * (pointtoRotate.X - centerPoint.X) +
                cos * (pointtoRotate.Y - centerPoint.Y) + centerPoint.Y)
            };
        }
        public void UpdateCenter()
        {
            Center = new Point(pb.Size.Width / 2, pb.Size.Height / 2);
            if (!Main.UpdateCenter(Center, RndX, RndY)) return;
            if (Current != null)
            {
                List <SuperTriangle> S_Triangles = new List<SuperTriangle>();
                SuperTriangle current = Current;
                while (current  != null)
                {
                    S_Triangles.Add(current);
                    current = current.Link_STriangle;
                }
                for(int i = S_Triangles.Count;i>0;i--)
                {
                    S_Triangles[i - 1].UpdateCenter(Center);
                }
            }
        }
        public void AddNewTop()
        {
            if (Current == null)
            {
                Current = new SuperTriangle(Main);
            }
            else if (Current.IsFull())
            {
                Current = new SuperTriangle(Current);
            }
            Point[] points = Current.Exist();
            ArrayList exist = new ArrayList();
            ArrayList not_exist = new ArrayList();
            int b = 0;
            foreach (Point p in points)
            {
                
                if (p.X != 0 && p.Y != 0)
                {
                    exist.Add(p);
                }
                else { not_exist.Add(b); }
                b++;
            }
            if (Current.Link_Triangle != null)
            {
                if (exist.Count == 0)
                {
                    int i = rnd.Next(1, 4);
                    if (i == 1)
                    {
                        Current.AddPoint(RotatePoint(Center, Main.A, 180), 'A');
                    }
                    else if (i == 2)
                    {
                        Current.AddPoint(RotatePoint(Center, Main.B, 180), 'B');
                    }
                    else if (i == 3)
                    {
                        Current.AddPoint(RotatePoint(Center, Main.C, 180), 'C');
                    }
                }
                else
                {
                    int k = rnd.Next(0, not_exist.Count-1);
                    int index = (int)not_exist[k];
                    if (characters[index] == 'A')
                    {
                        Current.AddPoint(RotatePoint(Center, Main.A, 180), characters[index]);
                    }
                    else if (characters[index] == 'B')
                    {
                        Current.AddPoint(RotatePoint(Center, Main.B, 180), characters[index]);
                    }
                    else if (characters[index] == 'C')
                    {
                        Current.AddPoint(RotatePoint(Center, Main.C, 180), characters[index]);
                    }
                }
            }
            else if(Current.Link_STriangle != null && Current.Link_STriangle.Link_Triangle != null)
            {
                if (exist.Count == 0)
                {
                    int i = rnd.Next(1, 4);
                    if (i == 1)
                    {
                        Current.AddPoint(RotatePoint(Current.Link_STriangle.Link_Triangle.A, Current.Link_STriangle.A, 180), 'A');
                    }
                    else if (i == 2)
                    {
                        Current.AddPoint(RotatePoint(Current.Link_STriangle.Link_Triangle.B, Current.Link_STriangle.B, 180), 'B');
                    }
                    else if (i == 3)
                    {
                        Current.AddPoint(RotatePoint(Current.Link_STriangle.Link_Triangle.C, Current.Link_STriangle.C, 180), 'C');
                    }
                }
                else
                {
                    int k = rnd.Next(0, not_exist.Count - 1);
                    int index = (int)not_exist[k];
                    if (characters[index] == 'A')
                    {
                        Current.AddPoint(RotatePoint(Current.Link_STriangle.Link_Triangle.A, Current.Link_STriangle.A, 180), characters[index]);
                    }
                    else if (characters[index] == 'B')
                    {
                        Current.AddPoint(RotatePoint(Current.Link_STriangle.Link_Triangle.B, Current.Link_STriangle.B, 180), characters[index]);
                    }
                    else if (characters[index] == 'C')
                    {
                        Current.AddPoint(RotatePoint(Current.Link_STriangle.Link_Triangle.C, Current.Link_STriangle.C, 180), characters[index]);

                    }
                }
            }
            else if (Current.Link_STriangle != null && Current.Link_STriangle.Link_STriangle != null)
            {
                if (exist.Count == 0)
                {
                    int i = rnd.Next(1, 4);
                    if (i == 1)
                    {
                        Current.AddPoint(RotatePoint(Current.Link_STriangle.Link_STriangle.A, Current.Link_STriangle.A, 180), 'A');
                    }
                    else if (i == 2)
                    {
                        Current.AddPoint(RotatePoint(Current.Link_STriangle.Link_STriangle.B, Current.Link_STriangle.B, 180), 'B');
                    }
                    else if (i == 3)
                    {
                        Current.AddPoint(RotatePoint(Current.Link_STriangle.Link_STriangle.C, Current.Link_STriangle.C, 180), 'C');
                    }
                }
                else
                {
                    int k = rnd.Next(0, not_exist.Count - 1);
                    int index = (int)not_exist[k];
                    if (characters[index] == 'A')
                    {
                        Current.AddPoint(RotatePoint(Current.Link_STriangle.Link_STriangle.A, Current.Link_STriangle.A, 180), characters[index]);
                    }
                    else if (characters[index] == 'B')
                    {
                        Current.AddPoint(RotatePoint(Current.Link_STriangle.Link_STriangle.B, Current.Link_STriangle.B, 180), characters[index]);
                    }
                    else if (characters[index] == 'C')
                    {
                        Current.AddPoint(RotatePoint(Current.Link_STriangle.Link_STriangle.C, Current.Link_STriangle.C, 180), characters[index]);
                    }
                }
            }
            pb.Refresh();
        }
    }
}
