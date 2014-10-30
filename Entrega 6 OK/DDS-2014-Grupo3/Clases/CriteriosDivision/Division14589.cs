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
public class Division14589 : CriterioDivision
{
    public override Equipo[] dividirEnEquipos(List<Jugador> _jugadores) {
        m_Equipo[0] = new Equipo();
        m_Equipo[1] = new Equipo();
    for (int i = 1; i <= _jugadores.Count;i++ )
        if (i==1 || i==4||i==5||i==8||i==9)
        {
            m_Equipo[1].agregarJugador(_jugadores.ElementAt(i-1));
        }
        else
        {
            m_Equipo[0].agregarJugador(_jugadores.ElementAt(i-1));
        }
        return m_Equipo;
}
}