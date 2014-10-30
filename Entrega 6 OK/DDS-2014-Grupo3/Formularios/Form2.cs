using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DDS_2014_Grupo4.Clases.Pantallitas
{
    public partial class Form2 : Form
    {
        Partido partido = null;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Partido part)
        {
            InitializeComponent();
            partido = part;
            for (int i = 0; i < partido.m_Equipo[0]._jugadores.Count; i++)
            {
                listBox1.Items.Add(partido.m_Equipo[0]._jugadores[i]._nombre);
            }
            for (int i = 0; i < partido.m_Equipo[1]._jugadores.Count; i++)
            {
                listBox2.Items.Add(partido.m_Equipo[1]._jugadores[i]._nombre);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
