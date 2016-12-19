using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

namespace WindowsFormsApplication2
{
    class Triangle
    {
        private Point a;
        private Point b;
        private Point c;
        private Point center;
        public Point A
        {
            get { return a; }
            set {; }
        }
        public Point B
        {
            get { return b; }
            set {; }
        }
        public Point C
        {
            get { return c; }
            set {; }
        }
        public Point Center
        {
            get { return center; }
            set {; }
        }
        public bool UpdateCenter(Point Center, int RndX, int RndY)
        {
            this.center = Center;
            this.a = new Point(Center.X - RndX, Center.Y - RndY);
            this.b = Graphs.RotatePoint(A, Center, 120);
            this.c = Graphs.RotatePoint(A, Center, -120);
            if (this.Center == Center)
            {
                return true;
            }
            else return false;
        }
        public Triangle(Point A, Point B, Point C, Point Center)
        {
            this.a = A; this.b = B; this.c = C; this.center = Center;
        }
    }
    class SuperTriangle
    {
        private Point a;
        private Point b;
        private Point c;
        private Point center;
        private Triangle Last_NotS_Triangle;
        private SuperTriangle Last_S_Triangle;
        public SuperTriangle Link_STriangle
        {
            get { return Last_S_Triangle; }
            set {; }
        }
        public Triangle Link_Triangle
        {
            get { return Last_NotS_Triangle; }
            set {; }
        }
        public Point A
        {
            get { return a; }
            set {; }
        }
        public Point B
        {
            get { return b; }
            set {; }
        }
        public Point C
        {
            get { return c; }
            set {; }
        }
        public Point Center
        {
            get { return center; }
            set {; }
        }
        public bool UpdateCenter(Point Center)
        {
            this.center = Center;
            if (this.Last_NotS_Triangle != null)
            {
                if (A.X != 0 && A.Y != 0)
                {
                    this.a = Graphs.RotatePoint(Center, Last_NotS_Triangle.A, 180);
                }
                if (B.X != 0 && B.Y != 0)
                {
                    this.b = Graphs.RotatePoint(Center, Last_NotS_Triangle.B, 180);
                }
                if (C.X != 0 && C.Y != 0)
                {
                    this.c = Graphs.RotatePoint(Center, Last_NotS_Triangle.C, 180);
                }
                return true;
            }
            else if (this.Last_S_Triangle != null && this.Last_S_Triangle.Last_NotS_Triangle != null)
            {
                if (A.X != 0 && A.Y != 0)
                {
                    this.a = Graphs.RotatePoint(Last_S_Triangle.Last_NotS_Triangle.A, Last_S_Triangle.A, 180);
                }
                if (B.X != 0 && B.Y != 0)
                {
                    this.b = Graphs.RotatePoint(Last_S_Triangle.Last_NotS_Triangle.B, Last_S_Triangle.B, 180);
                }
                if (C.X != 0 && C.Y != 0)
                {
                    this.c = Graphs.RotatePoint(Last_S_Triangle.Last_NotS_Triangle.C, Last_S_Triangle.C, 180);
                }
                return true;
            }
            else if(this.Last_S_Triangle != null && this.Last_S_Triangle.Last_S_Triangle != null)
            {
                if (A.X != 0 && A.Y != 0)
                {
                    this.a = Graphs.RotatePoint(Last_S_Triangle.Last_S_Triangle.A, Last_S_Triangle.A, 180);
                }
                if (B.X != 0 && B.Y != 0)
                {
                    this.b = Graphs.RotatePoint(Last_S_Triangle.Last_S_Triangle.B, Last_S_Triangle.B, 180);
                }
                if (C.X != 0 && C.Y != 0)
                {
                    this.c = Graphs.RotatePoint(Last_S_Triangle.Last_S_Triangle.C, Last_S_Triangle.C, 180);
                }
                return true;
            }
            else return false;

        }
        public SuperTriangle(Point A, Point B, Point C,Triangle _Triangle)
        {
            this.a = A; this.b = B; this.c = C;
            this.Last_NotS_Triangle = _Triangle;
            this.center = _Triangle.Center;
        }
        public SuperTriangle(Point A, Point B, Point C, SuperTriangle S_Triangle)
        {
            this.a = A; this.b = B; this.c = C;
            this.Last_S_Triangle = S_Triangle;
            this.center = S_Triangle.Center;
        }
        public SuperTriangle(Point point, char wich_point, Triangle _Triangle)
        {
            this.Link_Triangle = _Triangle;
            if (wich_point == 'A')
            {
                this.a = point;
            }
            else if (wich_point == 'B')
            {
                this.b = point;
            }
            else if (wich_point == 'C')
            {
                this.c = point;
            }
            else
            {
                throw new Exception("Неверное обозначение точки");
            }
        }
        public SuperTriangle(Point point, char wich_point, SuperTriangle S_Triangle)
        {
            this.Last_S_Triangle = S_Triangle;
            if (wich_point == 'A')
            {
                this.a = point;
            }
            else if (wich_point == 'B')
            {
                this.b = point;
            }
            else if (wich_point == 'C')
            {
                this.c = point;
            }
            else
            {
                throw new Exception("Неверное обозначение точки");
            }
        }
        public SuperTriangle(Triangle _Triangle)
        {
            this.Last_NotS_Triangle = _Triangle;
        }
        public SuperTriangle(SuperTriangle S_Triangle)
        {
            this.Last_S_Triangle = S_Triangle;
        }
        public void AddPoint(Point point, char wich_point)
        {
            if (wich_point == 'A')
            {
                this.a = point;
            }
            else if (wich_point == 'B')
            {
                this.b = point;
            }
            else if (wich_point == 'C')
            {
                this.c = point;
            }
            else
            {
                throw new Exception("Неверное обозначение точки");
            }
        }
        public Point[] Exist()
        {
            Point[] points = new Point[] { A,B,C };
            return points;
        }
        public bool IsFull()
        {
            if (A.X != 0 && B.X != 0 && C.X != 0) return true;
            else return false;
        }

    }
}
