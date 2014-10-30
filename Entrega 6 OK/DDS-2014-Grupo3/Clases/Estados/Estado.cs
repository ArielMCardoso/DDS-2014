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
public class Estado {
    public virtual bool esConfirmado() { return false; }
    public virtual bool esNoConfirmado() { return false; }
    public virtual bool esJugado() { return false; }
    public virtual bool estaJugando() { return false; }
    public virtual bool estaSuperConfirmado() { return false; }
    }
   


	/**
	 * 
	 * @param Condición
	 * @param TipoInscripcion
	 */
    