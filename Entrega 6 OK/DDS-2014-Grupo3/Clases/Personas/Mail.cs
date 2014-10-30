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
public interface Mail
{

   void enviarMail(string _cuerpo, Persona _destinatario);
   void recibirMail(string _cuerpo, Persona _remitente);
}
   


	/**
	 * 
	 * @param Condición
	 * @param TipoInscripcion
	 */
    