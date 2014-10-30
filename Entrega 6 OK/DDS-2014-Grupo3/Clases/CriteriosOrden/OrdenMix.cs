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
public class OrdenMix : CriterioOrden
{
    OrdenHandicap handy=new OrdenHandicap();
    public OrdenHandicap handicap {
        get { return handy; }
        set { handy = value; }
    }
    OrdenPromedioUltimoPartido prome = new OrdenPromedioUltimoPartido();
    public OrdenPromedioUltimoPartido promedioUltimoPartido
    {
        get { return prome; }
        set { prome = value; }
    }
    OrdenPromedioUltimosNPartidos promeN = new OrdenPromedioUltimosNPartidos();
    public OrdenPromedioUltimosNPartidos promedioNPartidos
    {
        get { return promeN; }
        set { promeN = value; }
    }
    public override int valorJugador(Jugador _jugador)
    { 
        List<CriterioOrden> criterios = new List<CriterioOrden>();
        criterios.Add(promedioNPartidos);
        criterios.Add(promedioUltimoPartido);
        criterios.Add(handicap);
        return (criterios.Sum(x=>x.valorJugador(_jugador))) / criterios.Count;
    }
}