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
    public partial class Form2 : Form
    {
        Partido partido = null;
        Form back = null;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form atras, Partido part)
        {
            InitializeComponent();
            partido = part;
            back = atras;
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (partido.m_Equipo[0]._jugadores.Count == 5 && partido.m_Equipo[1]._jugadores.Count == 5)
            {
                string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;";

                SqlConnection conn = new SqlConnection(ConnStr);
                string sSel = string.Format(@"INSERT INTO [GD2C2014].[dbo].[Equipo]
                ([ID_Jugador1]
                ,[ID_Jugador2]
                ,[ID_Jugador3]
                ,[ID_Jugador4]
                ,[ID_Jugador5])
                values({0},{1},{2},{3},{4})",
                        partido.m_Equipo[0]._jugadores[0].IDJugador,
                        partido.m_Equipo[0]._jugadores[1].IDJugador,
                        partido.m_Equipo[0]._jugadores[2].IDJugador,
                        partido.m_Equipo[0]._jugadores[3].IDJugador,
                        partido.m_Equipo[0]._jugadores[4].IDJugador);

                SqlCommand cmd = new SqlCommand(sSel, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Close();
                conn.Close();

                conn = new SqlConnection(ConnStr);
                sSel = string.Format(@"SELECT TOP 1 * from [GD2C2014].[dbo].[Equipo] order by ID_EQUIPO desc");
                cmd = new SqlCommand(sSel, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                string autonumerado1 = "";
                while (reader.Read())
                {
                    autonumerado1 = reader["ID_EQUIPO"].ToString();
                }
                reader.Close();
                conn.Close();

                conn = new SqlConnection(ConnStr);
                sSel = string.Format(@"INSERT INTO [GD2C2014].[dbo].[Equipo]
                ([ID_Jugador1]
                ,[ID_Jugador2]
                ,[ID_Jugador3]
                ,[ID_Jugador4]
                ,[ID_Jugador5])
                values({0},{1},{2},{3},{4})",
                        partido.m_Equipo[1]._jugadores[0].IDJugador,
                        partido.m_Equipo[1]._jugadores[1].IDJugador,
                        partido.m_Equipo[1]._jugadores[2].IDJugador,
                        partido.m_Equipo[1]._jugadores[3].IDJugador,
                        partido.m_Equipo[1]._jugadores[4].IDJugador);
                cmd = new SqlCommand(sSel, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                reader.Close();
                conn.Close();

                conn = new SqlConnection(ConnStr);
                sSel = string.Format(@"SELECT TOP 1 * from [GD2C2014].[dbo].[Equipo] order by ID_EQUIPO desc");
                cmd = new SqlCommand(sSel, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                string autonumerado2 = "";
                while (reader.Read())
                {
                    autonumerado2 = reader["ID_EQUIPO"].ToString();
                }
                reader.Close();
                conn.Close();

                /*conn = new SqlConnection(ConnStr);
                sSel = string.Format(@"UPDATE [GD2C2014].[dbo].[Partido] 
                SET ID_EQUIPO1 = {0}, 
                    ID_EQUIPO2 = {1}, 
                    ID_ESTADO = 5 
                where ID_PARTIDO = {2}", autonumerado1, autonumerado2, partido.ID_Partido);
                cmd = new SqlCommand(sSel, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();*/

                conn.Open();
                string comando = "update [GD2C2014].[dbo].[Partido] set ID_EQUIPO1=@id1, ID_EQUIPO2=@id2, ID_ESTADO=5 where ID_PARTIDO=@id";
                SqlCommand command = new SqlCommand(comando, conn);
                command.Parameters.AddWithValue("@id1", autonumerado1);
                command.Parameters.AddWithValue("@id2", autonumerado2);
                command.Parameters.AddWithValue("@id", partido.ID_Partido);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Equipos generados");
                this.Close();
                back.Close();
            }
            else
            {
                MessageBox.Show("Error, los equipos deben contener 5 jugadores cada uno");
            }
        }
    }
}
