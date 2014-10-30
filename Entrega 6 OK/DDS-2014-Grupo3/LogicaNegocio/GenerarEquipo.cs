using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace DDS_2014_Grupo4.LogicaNegocio
{
    public class GenerarEquipo
    {
        public Partido generar(string fecha, int seleccion, int orden)
        {
            Administrador admin = new Administrador();

            string[] stringSeparators = new string[] { "/" , "-" };
            string[] result = fecha.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            result[3] = result[3].Substring(0, 4);
            Partido partido = admin.nuevoPartido(new DateTime(int.Parse(result[3]),int.Parse(result[2]),int.Parse(result[1])));
            partido.ID_Partido = int.Parse(result[0]);
            string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;";
            SqlConnection conn = new SqlConnection(ConnStr);
            string sSel = string.Format("SELECT * FROM [GD2C2014].[dbo].[Inscripcion] i, [GD2C2014].[dbo].[Jugador] j where i.ID_Partido = '{0}' and j.ID_Jugador = i.ID_Jugador", partido.ID_Partido);
            SqlCommand cmd = new SqlCommand(sSel, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Jugador jugador = admin.nuevoJugador(reader["APODO"].ToString());
                TipoInscripción inscripcion = null;
                switch (int.Parse(reader["ID_Inscripcion"].ToString()))
                {
                    case 1: 
                        inscripcion = new Estándar();
                        break;
                    case 2:
                        inscripcion = new Solidaria();
                        break;
                    case 3:
                        inscripcion = new Condicional();
                        break;
                }
                jugador.Inscribirse("", inscripcion, partido);
                jugador.confirmarInscripcion(jugador.inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));

            }
            reader.Close();
            conn.Close(); 
            CriterioOrden criterio = null;
            switch (orden)
            {
                case 0:
                    criterio = new OrdenHandicap();
                    break;
                case 1:
                    criterio = new OrdenPromedioUltimoPartido();
                    break;
                case 2:
                    criterio = new OrdenPromedioUltimosNPartidos(5);
                    break;
                case 3  :
                    criterio = new OrdenMix(5);
                    break;
            }
            CriterioDivision division = null;
            switch (orden)
            {
                case 0:
                    division = new DivisionParidad();
                    break;
                case 1:
                    division = new Division14589();
                    break;
            }
            admin.ordenarJugadores(partido, criterio);
            admin.dividirJugadores(partido, division);
            return partido;
        }
    }
}
