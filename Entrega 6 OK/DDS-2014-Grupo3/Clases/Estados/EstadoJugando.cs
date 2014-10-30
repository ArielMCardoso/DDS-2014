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
public class EstadoJugando:Estado {
    public override bool estaJugando() { return true; }
    public override bool estaSuperConfirmado() { return true; }
    public override bool esConfirmado() { return true; }
    }
   


	/**
	 * 
	 * @param Condición
	 * @param TipoInscripcion
	 */
    