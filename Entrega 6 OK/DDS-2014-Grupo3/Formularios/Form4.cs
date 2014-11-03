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
    public partial class Form4 : Form
    {
        int[] id = new int[50];
        public Form4()
        {
            InitializeComponent();
        }

        public Form4(SqlDataReader reader, SqlConnection conn)
        {
            InitializeComponent();
            int i = 0;
            while (reader.Read())
            {
                listBox1.Items.Add(reader["Apodo"].ToString());
                id[i] = int.Parse(reader["ID_Jugador"].ToString());
                i++;
            }
            reader.Close();
            conn.Close(); 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox2.Text = listBox1.SelectedItems[0].ToString();
            string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;";

            SqlConnection conn = new SqlConnection(ConnStr);
            string sSel = string.Format("SELECT * FROM [GD2C2014].[dbo].[Jugador] j, [GD2C2014].[dbo].[Persona] p where j.ID_Jugador = '{0}' and j.ID_Persona = p.ID_Persona", id[listBox1.SelectedIndex]);
            
            
            SqlCommand cmd = new SqlCommand(sSel, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader["Nombre"].ToString();
                textBox3.Text = reader["Handicap"].ToString();
            }
            reader.Close();
            conn.Close();


            conn = new SqlConnection(ConnStr);
            sSel = string.Format("SELECT * FROM [GD2C2014].[dbo].[Calificacion] where ID_Calificado = '{0}'", id[listBox1.SelectedIndex]);
            cmd = new SqlCommand(sSel, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            int sumatoria = 0;
            int contador = 0;
            while (reader.Read())
            {
                sumatoria = sumatoria + int.Parse(reader["Puntaje"].ToString());
                contador++;
            }
            if (contador == 0)
            {
                textBox4.Text = "0";
            }
            else
            {
                textBox4.Text = string.Format("{0}", sumatoria / contador);
            }
            reader.Close();
            conn.Close(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.textBox2.Text = listBox1.SelectedItems[0].ToString();
            string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;";

            SqlConnection conn = new SqlConnection(ConnStr);
            string sSel = string.Format(@"SELECT * FROM [GD2C2014].[dbo].[Jugador] j, 
                [GD2C2014].[dbo].[Persona] p 
                where j.ID_Jugador = '{0}' 
                and j.ID_Persona = p.ID_Persona", id[listBox1.SelectedIndex]);


            SqlCommand cmd = new SqlCommand(sSel, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Form f = new Form5(reader, conn);
            f.Show();
            
        }
    }
}
