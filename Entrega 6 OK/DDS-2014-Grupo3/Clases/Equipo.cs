using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualStudio.QualityTools.UnitTestFramework;

/**
 * @author alumno
 * @version 1.0
 * @created 16-Ago-2014 12:40:21 p.m.
 */
public class Equipo {
    public List<Jugador> _jugadores= new List<Jugador>();

    public void agregarJugador(Jugador _unJugador)
    {
        _jugadores.Add(_unJugador);
    }
    public bool estaVacio() { return _jugadores.Count == 0; }

}