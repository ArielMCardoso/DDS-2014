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
                string source = reader["Fecha_Nacimiento"].ToString();
                string[] stringSeparators = new string[] { "/" };
                string[] result;
                result = source.Split(stringSeparators,
                            StringSplitOptions.RemoveEmptyEntries);
                result[2] = result[2].Substring(0, 4);
                dateTimePicker1.Value = new DateTime(int.Parse(result[2]), 
                    int.Parse(result[1]), int.Parse(result[0]));
                ID_Jugador = reader["ID_Jugador"].ToString();
            }
            
            
            reader.Close();
            conn.Close();
            
            
            string sSel = string.Format(@"select * from [GD2C2014].[dbo].[Persona] p, 
                [GD2C2014].[dbo].[Jugador] j1, [GD2C2014].[dbo].[Amigo] a 
                where j1.ID_Jugador = {0} 
                and j1.ID_Jugador = a.ID_jugador 
                and a.ID_Persona = p.ID_Persona", ID_Jugador);
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


            conn = new SqlConnection(ConnStr);
            sSel = string.Format(@"SELECT TOP 9 *
                FROM [GD2C2014].[dbo].[Calificacion]
                where ID_Calificado = '{0}'
                order by ID_Partido desc", ID_Jugador);
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

            conn = new SqlConnection(ConnStr);
            sSel = string.Format(@"SELECT *
                FROM [GD2C2014].[dbo].[Calificacion]
                where ID_Calificado = '{0}'", ID_Jugador);
            cmd = new SqlCommand(sSel, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            sumatoria = 0;
            contador = 0;
            while (reader.Read())
            {
                sumatoria = sumatoria + int.Parse(reader["Puntaje"].ToString());
                contador++;
            }
            if (contador == 0)
            {
                textBox5.Text = "0";
                
            }
            else
            {
                textBox5.Text = string.Format("{0}", sumatoria / contador);
            }
            textBox7.Text = string.Format("{0}", contador / 9);
            reader.Close();
            conn.Close();

            conn = new SqlConnection(ConnStr);
            sSel = string.Format(@"SELECT *
                FROM [GD2C2014].[dbo].[PENALIZACION]
                where ID_JUGADOR = '{0}'", ID_Jugador);
            cmd = new SqlCommand(sSel, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            sumatoria = 0;
            contador = 0;
            string descripcion = "";
            while (reader.Read())
            {
                descripcion = string.Format("{0}", reader["Descripcion"].ToString());
                listBox2.Items.Add(descripcion);
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
