using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        Graphs g;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = new Graphs(pictureBox1);
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            g.DrawMain_T(e);
            g.DrawAll_ST(e);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e = null)
        {
            g.AddNewTop();
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            g.UpdateCenter();
            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
