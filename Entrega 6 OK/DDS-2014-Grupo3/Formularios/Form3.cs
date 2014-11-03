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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;";

            SqlConnection conn = new SqlConnection(ConnStr);
            string sSel = string.Format(@"SELECT * FROM [GD2C2014].[dbo].[Jugador] j, 
                [GD2C2014].[dbo].[Persona] p 
                where j.ID_Persona = p.ID_Persona");
            if (textBox1.Text != "")
            {
                sSel = string.Format("{0} and Nombre like '{1}%'", sSel, textBox1.Text);
            }
            if (textBox3.Text != "")
            {
                sSel = string.Format("{0} and Apodo like '{1}%'", sSel, textBox3.Text);
            }
            if (radioButton1.Checked && textBox4.Text != "" && textBox5.Text != "")
            {
                sSel = string.Format("{0} and Handicap between {1} and {2}", sSel, textBox4.Text, textBox5.Text);
            }
            sSel = string.Format("{0} and Fecha_Nacimiento < '{1}'", sSel, dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            if (checkBox1.Checked && !checkBox2.Checked)
            {
                sSel = string.Format(@"{0} and ((SELECT COUNT (*) 
                    from [GD2C2014].[dbo].[Penalizacion] pen
					WHERE j.ID_Jugador = pen.ID_Jugador) > 0)", sSel);
            }
            if (!checkBox1.Checked && checkBox2.Checked)
            {
                sSel = string.Format(@"{0} and ((SELECT COUNT (*) 
                    from [GD2C2014].[dbo].[Penalizacion] pen
					WHERE j.ID_Jugador = pen.ID_Jugador) = 0)", sSel);
            }

            SqlCommand cmd = new SqlCommand(sSel, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Form f = new Form4(reader, conn);
            f.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                checkBox2.Checked = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox2.Checked && !checkBox1.Checked)
            {
                checkBox1.Checked = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
