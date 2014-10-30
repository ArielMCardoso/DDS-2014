using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualStudio.QualityTools.UnitTestFramework;

/**
 * @author alumno
 * @version 1.0
 * @created 16-Ago-2014 12:40:49 p.m.
 */
public class OrdenPromedioUltimosNPartidos : CriterioOrden
{
    public int cant_Partidos;
    public int cantPartidos
    {
        get { return cant_Partidos; }
        set { cant_Partidos = value; }
    }
    public override int valorJugador(Jugador _jugador)
    {
        return _jugador.promedioUltimosPartidos(cantPartidos);
        }

    public OrdenPromedioUltimosNPartidos(int nPartidos)
    {
        cantPartidos = nPartidos;
    }
}