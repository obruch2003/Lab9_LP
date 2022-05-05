using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Lab9_LP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double X0 = double.Parse(textBox1.Text);
            double Xk = double.Parse(textBox2.Text);
            double dx = double.Parse(textBox3.Text);
            double b = double.Parse(textBox4.Text);
            if (X0 > Xk) { (X0, Xk) = (Xk, X0); }
            int count = (int)Math.Ceiling((Xk - X0) / dx) + 1;
            double[] x = new double[count];
            double[] y1 = new double[count];
            double[] y2 = new double[count];
            for (int i = 0; i < count; i++)
            {
                x[i] = X0 + dx * i;
                y1[i] = x[i] * Math.Sin(Math.Sqrt(x[i] + b - 0.0084));
                y2[i] = b * Math.Cos(x[i]);
            }
            chart1.ChartAreas[0].AxisX.Minimum = X0;
            chart1.ChartAreas[0].AxisX.Maximum = Xk;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = dx;
            chart1.Series[0].Points.DataBindXY(x, y1);
            chart1.Series[1].Points.DataBindXY(x, y2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "-2,05";
            textBox2.Text = "-3,05";
            textBox3.Text = "0,2";
            textBox4.Text = "3,4";
        }
    }
}
