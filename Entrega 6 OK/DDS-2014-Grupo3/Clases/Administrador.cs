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
public class Administrador {
    public List<Partido> partidos=new List<Partido>();
    public List<Jugador> jugadores=new List<Jugador>();
    public List<Persona> solicitudesPendientes = new List<Persona>();
    public struct Rechazo {
       public Persona persona;
       public DateTime fecha;
       public string motivo;
    }
    public List<Rechazo> solicitudesRechazadas = new List<Rechazo>();
    public Rechazo rechazo(Persona _unaPersona, string _motivo)
    {
        Rechazo _nuevoRechazo = new Rechazo();
        _nuevoRechazo.fecha = DateTime.Today;
        _nuevoRechazo.persona = _unaPersona;
        _nuevoRechazo.motivo = _motivo;
        return _nuevoRechazo;

    }
    public void actualizar(Partido unPartido) { 
        /*codigo de actualizacion
         * 
         */
    }

    public void cargarPropuesta(Persona _amigo) {
        solicitudesPendientes.Add(_amigo);
    }
    public void rechazarPropuesta(Persona _amigo,string _motivo) {
        Rechazo nuevoRechazo=rechazo(_amigo,_motivo);
        solicitudesRechazadas.Add(nuevoRechazo);
        solicitudesPendientes.Remove(_amigo);
    }
	public Partido nuevoPartido(DateTime fecha){
        int maximo = 1;
        if(partidos.Count>0){
         maximo = partidos.Max(X => X.ID_Partido);
        }
        Partido nuevo= new Partido();
        nuevo.ID_Partido = maximo+1;
        nuevo._admin = this;
        nuevo.fecha = fecha;
        partidos.Add(nuevo);
        return nuevo;
	}

    public Jugador nuevoJugador(string nombre) {
        int maximo = 1;
        if (jugadores.Count > 0)
        {
            maximo = jugadores.Max(X => X.ID_Jugador);
        }
        Jugador nuevo = new Jugador();
        nuevo.ID_Jugador = maximo + 1;
        nuevo._nombre = nombre;
        nuevo._admin = this;
        jugadores.Add(nuevo);
        return nuevo;
    }
    public Jugador nuevoJugador(Persona unAmigo)
    {
        Jugador _nuevoAmigo = new Jugador();
        int maximo = 1;
        if (jugadores.Count > 0)
        {
            maximo = jugadores.Max(X => X.ID_Jugador);
        }
        _nuevoAmigo.IDJugador = maximo;
        _nuevoAmigo.SetJugador(unAmigo);
        _nuevoAmigo._admin = this;
        solicitudesPendientes.Remove(unAmigo);
        List<Jugador> _listaJugadoresIntermedia = jugadores.FindAll( X => X.amigos.Exists(i=>i==unAmigo));
        _listaJugadoresIntermedia.ForEach(x => x.amigos.Add(_nuevoAmigo));
        _listaJugadoresIntermedia.ForEach(x => x.amigos.Remove(unAmigo));
        jugadores.Add(_nuevoAmigo);
        return _nuevoAmigo;
    }
    public List<Jugador> ordenarJugadores(Partido _unPartido, CriterioOrden _unCriterio)
    {
        _unPartido.criterio = _unCriterio;
        return _unPartido.ordenarJugadores();
    }
    public void dividirJugadores(Partido _unPartido, CriterioDivision _unCriterio)
    { 
        List<Jugador> jugadores=new List<Jugador>();
        _unPartido.inscripciones.ForEach(x=>jugadores.Add(x.jugador));
        _unPartido.m_Equipo = _unCriterio.dividirEnEquipos(jugadores);
    }
    public void confirmarEquipos(Partido _unPartido)
    {
        if (_unPartido.estaConfirmado() && _unPartido.tieneEquipos())
        {
            _unPartido.superConfirmar();
        }
    }
}