using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DDS_2014_Grupo4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new Clases.Pantallitas.FGenerarEquipos()).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (new Clases.Pantallitas.Form2()).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            (new Clases.Pantallitas.Form3()).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            (new Clases.Pantallitas.Form4()).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            (new Clases.Pantallitas.Form5()).Show();
        }
    }
}
