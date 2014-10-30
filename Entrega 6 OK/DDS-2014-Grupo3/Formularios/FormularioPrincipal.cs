using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DDS_2014_Grupo4.Formularios
{
    public partial class FormularioPrincipal : Form
    {
        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new BusquedaDeJugadores() ;
             f.Show();
        }

        private void Boton_generar_equipo_Click(object sender, EventArgs e)
        {
            Form f = new GenerarEquipos();
            f.Show();
            
        }
    }
}
