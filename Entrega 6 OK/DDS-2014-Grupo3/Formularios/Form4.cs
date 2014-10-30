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
        public Form4()
        {
            InitializeComponent();
        }

        public Form4(SqlDataReader reader, SqlConnection conn)
        {
            InitializeComponent();
            while (reader.Read())
            {
                listBox1.Items.Add(reader["Apodo"].ToString());
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
            string sSel = string.Format("SELECT * FROM [GD2C2014].[dbo].[Jugador] j, [GD2C2014].[dbo].[Persona] p where j.Apodo = '{0}' and j.ID_Persona = p.ID_Persona", textBox2.Text);
            
            
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
            string sSel = string.Format("SELECT * FROM [GD2C2014].[dbo].[Jugador] j, [GD2C2014].[dbo].[Persona] p where j.Apodo = '{0}' and j.ID_Persona = p.ID_Persona", textBox2.Text);


            SqlCommand cmd = new SqlCommand(sSel, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Form f = new Form5(reader, conn);
            f.Show();
            
        }
    }
}
