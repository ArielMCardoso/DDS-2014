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
public class DivisionParidad : CriterioDivision
{

    public override Equipo[] dividirEnEquipos(List<Jugador> _jugadores)
    {
        m_Equipo[0] = new Equipo();
        m_Equipo[1] = new Equipo();
        for (int i = 1; i <= _jugadores.Count; i++)
            if (i % 2 == 0)
            {
                m_Equipo[0].agregarJugador(_jugadores.ElementAt(i-1));
            }
            else
            {
                m_Equipo[1].agregarJugador(_jugadores.ElementAt(i-1));
            }
        return m_Equipo;
    }
}