using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualStudio.QualityTools.UnitTestFramework;

/**
 * @author alumno
 * @version 1.0
 * @created 16-Ago-2014 12:40:38 p.m.
 */
public class Inscripcion
{

    #region Atributos
    public Jugador jugador=new Jugador();
    public Partido _partido=new Partido();
    public TipoInscripción m_TipoInscripción=new Estándar();
    public Estado _estadoInscripcion=new EstadoNoConfirmada();
    #endregion
    #region MetodosPublicos
    public bool esConfirmado() { return _estadoInscripcion.esConfirmado(); }

    public bool confirmarInscripcion() {
        if (_estadoInscripcion.esConfirmado())
            return false;
        else
        {
            _estadoInscripcion = new EstadoConfirmada();
            _partido.estaConfirmado();
            return true;
        }
    }
    public bool desConfirmarInscripcion()
    {
        if (_estadoInscripcion.esConfirmado())
        {
            _estadoInscripcion = new EstadoNoConfirmada();
            return true;
        }
        else return false;
        
    }

	public void CambiarJugador(Jugador _jugador)
	{
	jugador=_jugador;
	}
    public global::TipoInscripción TipoInscripción
    {
        get
        {
            throw new System.NotImplementedException();
        }
        set
        {
        }
    }
    #endregion


    /**
	 * 
	 * @param Condición
	 * @param TipoInscripcion
	 */
    

}