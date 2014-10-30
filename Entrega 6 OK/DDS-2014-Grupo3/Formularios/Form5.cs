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
    public partial class Form5 : Form
    {
        public Form5(SqlDataReader reader, SqlConnection conn)
        {
            InitializeComponent();
            string ID_Jugador = null;
            while (reader.Read())
            {
                textBox1.Text = reader["Nombre"].ToString();
                textBox2.Text = reader["Apodo"].ToString();
                textBox3.Text = reader["Handicap"].ToString();
                textBox6.Text = reader["Fecha_Nacimiento"].ToString();
                ID_Jugador = reader["ID_Jugador"].ToString();
            }
            
            
            reader.Close();
            conn.Close();
            
            
            string sSel = string.Format("select p.Nombre, p.Apellido from [GD2C2014].[dbo].[Persona] p, [GD2C2014].[dbo].[Jugador] j1, [GD2C2014].[dbo].[Amigo] a where "+
                "j1.ID_Jugador = {0} and j1.ID_Jugador = a.ID_jugador and a.ID_Persona = p.ID_Persona",ID_Jugador);
            string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;";

            conn = new SqlConnection(ConnStr);
           
            SqlCommand cmd = new SqlCommand(sSel, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            string nombreApellido;
            while (reader.Read())
            {
                nombreApellido = string.Format("{0}, {1}", reader["Apellido"].ToString(), reader["Nombre"].ToString());
                listBox1.Items.Add(nombreApellido);
            }
            reader.Close();
            conn.Close(); 
        }
        public Form5()
        {
            InitializeComponent();
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
