using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualStudio.QualityTools.UnitTestFramework;

/**
 * @author alumno
 * @version 1.0
 * @created 16-Ago-2014 12:40:44 p.m.
 */
public class Partido
{
    #region Atributos
    public int ID_Partido=0;
    public Administrador _admin;
    public List<Inscripcion> inscripciones=new List<Inscripcion>();
	public Equipo[] m_Equipo = new Equipo[2];
    public Estado _estado=new EstadoNoConfirmada();
    public DateTime fecha = DateTime.Today.Date;
    public CriterioOrden criterio = new OrdenHandicap();
    public CriterioDivision _division = new DivisionParidad();
    #endregion
    #region MetodosJugadores
    public List<Jugador> obtenerJugadores()
    {
        List<Jugador> listaJugadores=new List<Jugador>();
        inscripciones.ForEach(x => listaJugadores.Add(x.jugador));
        return listaJugadores;
    }

    public List<Jugador> ordenarJugadores() {
        return obtenerJugadores().OrderByDescending(x => this.criterio.valorJugador(x)).ToList();
    }

    public bool estaConfirmado() {
        if (!hayLugar())
            return (inscripciones.TrueForAll(i => i.esConfirmado()));
        else return false;
    }
    #endregion
    public void actualizarConfirmacion() {
        if (!estaSuperConfirmada())
        {
            if (estaConfirmado()) _estado = new EstadoConfirmada();
            else _estado = new EstadoNoConfirmada();
        }
    }
    public void superConfirmar() { _estado = new EstadoSuperConfirmada(); }
    public bool estaSuperConfirmada() { return _estado.estaSuperConfirmado(); }
    public void avisarConfirmacion() {
        _admin.actualizar(this);
    }
    public bool tieneEquipos() {
        return (!m_Equipo[0].estaVacio() && !m_Equipo[1].estaVacio());
    }
    /**
     * 
     * @param ID Jugador
     */

    #region Inscripciones
    public bool estaJugador(Inscripcion _unaInscripcion)
{
return inscripciones.Exists(x=> x.jugador==_unaInscripcion.jugador);
}
    public void darDeBaja(Inscripcion _inscripcion) {
        if(!estaSuperConfirmada())
        inscripciones.Remove(_inscripcion); }
    public bool Inscribir(Inscripcion inscripcion)
    {
    if(!estaSuperConfirmada())
	if(!estaJugador(inscripcion)){
        desplazarSiEsNecesario();
        inscripciones.Add(inscripcion);
	return true;
	}
    return false;
    }
    public void desplazarSiEsNecesario() {
        if (hayLugar()==false)
            if (cantidadCondicional() > 0) inscripciones.Remove(inscripciones.Find(x => x.m_TipoInscripción.esCondicional()));
            else if (cantidadSolidario() > 0) inscripciones.Remove(inscripciones.Find(x => x.m_TipoInscripción.esSolidario()));
    }
	public bool PuedeInscribir(TipoInscripción tipoInscripcion){
        if (!estaConfirmado())
            if (hayLugar())
                return true;
            else if (tipoInscripcion.esEstandar() && hayLugarParaEstandar())
                return true;
            else if (tipoInscripcion.esSolidario() && hayLugarParaSolidario())
                return true;
            else if (tipoInscripcion.esCondicional() && hayLugarParaCondicional())
                return true;
            else return false;
        else return false;
	}
    public int cantidadEstandar(){
        int estandar = inscripciones.Count(x => x.m_TipoInscripción.esEstandar());
        return estandar;
    }
     public int cantidadSolidario(){
        int solidario = inscripciones.Count(x=>x.m_TipoInscripción.esSolidario());
        return solidario;
    }
     public int cantidadCondicional()
     {
         int condicional = inscripciones.Count(x => x.m_TipoInscripción.esCondicional());
         return condicional;
     }

    public bool hayLugar(){
        if(!estaSuperConfirmada())
        if (inscripciones.Count < 10) return true;
        return false;
    }
    public bool hayLugarParaEstandar() {
        if (!estaSuperConfirmada())
        if (cantidadEstandar() < 10) return true;
        return false;
    }
    public bool hayLugarParaSolidario() {
        if (!estaSuperConfirmada())
        if (cantidadEstandar()+cantidadSolidario() < 10) return true;
        return false;
    }
    public bool hayLugarParaCondicional()
    {
        if (!estaSuperConfirmada())
        if (cantidadEstandar() + cantidadSolidario() + cantidadCondicional() < 10) return true;
        return false;
    }
    #endregion
}