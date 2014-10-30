using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualStudio.QualityTools.UnitTestFramework;

/**
 * @author alumno
 * @version 1.0
 * @created 16-Sep-2014 12:40:55 p.m.
 */
public abstract class CriterioDivision
{
    public Equipo[] m_Equipo = new Equipo[2];
    public abstract Equipo[] dividirEnEquipos(List<Jugador> _jugadores);

}