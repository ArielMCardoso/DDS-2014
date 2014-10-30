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
public class Jugador: Persona,Sujeto,Mail{

	public int ID_Jugador;
    public int handycap=1;
    public Persona _persona=new Persona();
    
    public Administrador _admin;
    public List<Persona> amigos=new List<Persona>();
    public List<Inscripcion> inscripciones = new List<Inscripcion>();
    public List<Penalizacion> penalizaciones = new List<Penalizacion>();
    public List<Calificacion> calificaciones = new List<Calificacion>();
    public int IDJugador
    {
        get { return ID_Jugador; }
        set { ID_Jugador = value; }
    }
    public Persona persona
    {
        get { return _persona; }
        set { _persona = value; }
    }
    public void SetJugador(Persona persona)
    {
        this.persona = persona;
    }
   

    public override bool sosJugador() { return true; }
    #region calificaciones
    public void serCalificado(int _puntaje, string _critica, Partido _partido,Jugador _calificador) {
            Calificacion _nuevo = new Calificacion();
            _nuevo.puntaje = _puntaje;
            _nuevo.critica = _critica;
            _nuevo.partido = _partido;
            _nuevo.calificador = _calificador;
            calificaciones.Add(_nuevo);
    }

    public bool puedeSerCalificado(Jugador _jugador, Partido _partido)
    {
        if (_partido._estado.esJugado())
            if (_jugador.inscripciones.Exists(x => x._partido == _partido
            && x._estadoInscripcion.esJugado()))
                if ((_jugador != this) && this.inscripciones.Exists(x => x._partido == _partido
            && x._estadoInscripcion.esJugado()))
                    if (!_jugador.calificaciones.Exists(x=> x.calificador==_jugador 
                        &&  x.partido==_partido))
        return true;
        return false;
    }
    public bool calificarJugador(Jugador _jugador, int _puntaje, string _critica, Partido _partido)
    {
        if (puedeSerCalificado(_jugador,_partido))
        {
           
           _jugador.serCalificado(_puntaje, _critica, _partido,this);
           return true;
        }
        else return false;
    }
    #endregion
    #region Implementacion Interface Mail

    public override void enviarMail(string _cuerpo, Persona _destinatario){
        _destinatario.recibirMail(_cuerpo, this);
}
    #endregion
    #region Implementacion Interface Sujeto
    /**
	 * 
	 * @param Condicion
	 * @param TipoInscripcion
	 * @param IDPartido
	 */
    public void agregar(Persona _unAmigo)
    {
        amigos.Add(_unAmigo); 
    }
    public void eliminar(Persona _unAmigo)
    {
        amigos.Remove(_unAmigo);
    }
    public void notificar()
    {
        amigos.ForEach(i => enviarMail("me inscribí", i));
    }
    public void notificarAmigos() {
        notificar();
    }
    #endregion
    #region Inscripciones

    public void CambiarInscripcion(string Condicion, TipoInscripción TipoInscripcion, Partido partido)
    {
        
	}
	/**
	 * 
	 * @param Condicion
	 * @param TipoInscripcion
	 * @param IDPartido
	 */
	public bool Inscribirse(string Condicion, TipoInscripción TipoInscripcion, Partido partido){

        if (partido.PuedeInscribir(TipoInscripcion))
        {
            Inscripcion nuevo = new Inscripcion();
            nuevo.m_TipoInscripción = TipoInscripcion;
            nuevo.jugador = this;
            nuevo._estadoInscripcion = new EstadoNoConfirmada();
            nuevo._partido = partido;
            if (TipoInscripcion.esCondicional()) TipoInscripcion.agregarCondicion(Condicion);
            inscripciones.Add(nuevo);
            partido.Inscribir(nuevo);
            notificarAmigos();
            return true;
        }
        else return false;
	}
	public void DarseDeBaja(Inscripcion _inscripcion)
	{
    inscripciones.Remove(_inscripcion);
    _inscripcion._partido.darDeBaja(_inscripcion);
    _inscripcion.desConfirmarInscripcion();
    Penalizacion nuevaPenalizacion = new Penalizacion();
    nuevaPenalizacion._diasDuracion = 7;
    nuevaPenalizacion._fecha = DateTime.Today;
    nuevaPenalizacion._jugador = this;
	penalizaciones.Add(nuevaPenalizacion);
    notificarAmigos();
	}
	public void DarseDeBaja(Inscripcion _inscripcion, Jugador _suplente){
	//Acá cambia su inscripción por la del jugador suplente
	inscripciones.Remove(_inscripcion);
	_inscripcion.CambiarJugador(_suplente);
	_suplente.AsignarInscripcion(_inscripcion);
    notificarAmigos();
	}
	public void confirmarInscripcion(Inscripcion _inscripcion)
    {
    if (!_inscripcion._estadoInscripcion.esJugado() ) _inscripcion.confirmarInscripcion();
    }
public void AsignarInscripcion(Inscripcion _inscripcion){
inscripciones.Add(_inscripcion);
}
    #endregion
    #region Manejo Amigos
    public void proponerAmigo(Persona _amigo)
{
    if (amigos.Exists(i => i == _amigo)&& !_amigo.sosJugador()) {
        _admin.cargarPropuesta(_amigo);
    }

}
#endregion
public bool estaPenalizado(){
return (penalizaciones.Any(x=>x.valida()));
}
public bool tieneCalificaciones(Partido _unPartido)
{
    return calificaciones.Exists(x => x.partido == _unPartido);
}
public int promedioUltimosPartidos(int cantidad)
{   // SE HACE EL PROMEDIO DE LOS ULTIMOS N PARTIDOS QUE JUGÓ Y FUE CALIFICADO POR LO MENOS 1 VEZ
    if (calificaciones.Count == 0) return 5;
    else
    {
        int promedio = 0;
        List<Inscripcion> inscripcionesValidas = new List<Inscripcion>();
        inscripcionesValidas = inscripciones.FindAll(x => x._partido._estado.esJugado());
        inscripcionesValidas = inscripcionesValidas.FindAll(x => calificaciones.Exists(y => y.partido == x._partido));
        for (int i = 0; i < cantidad; i++)
        {
            if(inscripcionesValidas.ElementAt( inscripcionesValidas.Count - (i+1))!=null)
                promedio += promedioCalificaciones(inscripcionesValidas.ElementAt(inscripcionesValidas.Count - (i+1)));
        }
        return promedio / cantidad;
    }
}
public int promedioCalificaciones(List<Calificacion> _unasCalificaciones)
{
    return (_unasCalificaciones.Sum(x => x.puntaje))/_unasCalificaciones.Count;
}
public int promedioCalificaciones(Inscripcion _unaInscripcion)
{ 
return promedioCalificaciones(calificaciones.FindAll(x=>x.partido==_unaInscripcion._partido));
}
}