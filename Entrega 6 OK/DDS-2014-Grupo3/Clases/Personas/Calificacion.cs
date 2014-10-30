using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualStudio.QualityTools.UnitTestFramework;

/**
 * @author alumno
 * @version 1.0
 * @created 16-Ago-2014 12:40:32 p.m.
 */
public class Calificacion {

    public Jugador _calificador;
    public Partido _partido;
    public int _puntaje;
    public string _critica;

    public Jugador calificador
    {
        get { return _calificador; }
        set { _calificador = value; }
    }
    public Partido partido
    {
        get { return _partido; }
        set { _partido = value; }
    }
    public int puntaje
    {
        get { return _puntaje; }
        set { _puntaje = value; }
    }
    public string critica
    {
        get { return _critica; }
        set { _critica = value; }
    }
}