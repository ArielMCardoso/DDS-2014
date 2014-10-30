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
public class Persona:Observador,Mail {

	public int _DNI = 0;
	public string _nombre = "";
    public struct _mail{ 
        public string cuerpo;
        public DateTime fecha;
        public Persona remitente;
        public Persona destinatario;
    }
    public List<_mail> _mails = new List<_mail>();
    public virtual void enviarMail(string mail, Persona _destinatario) { }
    public virtual bool sosJugador() { return false; }
    public void recibirMail(string mail, Persona _remitente) { 
      _mail mailsRecibidos=new _mail();
      mailsRecibidos.cuerpo = mail;
      mailsRecibidos.remitente = _remitente;
      mailsRecibidos.fecha = DateTime.Today;
      mailsRecibidos.destinatario = this;
      _mails.Add(mailsRecibidos);
    }
    public void actualizar() { }

    public void recibirNotificacion(Jugador unJugador) { 
    
    
    }
}