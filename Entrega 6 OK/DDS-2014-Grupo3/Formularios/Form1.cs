using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace DDS_2014_Grupo4.Clases.Pantallitas
{
    public partial class FGenerarEquipos : Form
    {
        Partido partido = null;
        public FGenerarEquipos()
        {
            InitializeComponent();
        }

        private void FGenerarEquipos_Load(object sender, EventArgs e)
        {
            string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;";

            SqlConnection conn = new SqlConnection(ConnStr);
            string sSel = string.Format(@"SELECT * FROM [GD2C2014].[dbo].[Partido] 
                    where ID_Estado in (1, 2)");


            SqlCommand cmd = new SqlCommand(sSel, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            string IDFecha = "";
            while (reader.Read())
            {
                IDFecha = string.Format("{0} - {1}", reader["ID_Partido"].ToString(), reader["Fecha"].ToString());
                comboBox1.Items.Add(IDFecha);
            }
            reader.Close();
            conn.Close(); 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar partido");
                return;
            }
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar criterio de seleccion");
                return;
            }
            if (listBox2.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar criterio de ordenamiento");
                return;
            }
            LogicaNegocio.GenerarEquipo f = new LogicaNegocio.GenerarEquipo();
            partido = f.generar(comboBox1.Text,listBox1.SelectedIndex,listBox2.SelectedIndex);
            new Form2(this, partido).Show();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
