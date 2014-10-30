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
public class Penalizacion {

	public Jugador _jugador;
    public string _descripcion;
    public DateTime _fecha;
    public int _diasDuracion;
    public bool valida() {
        return (_fecha.AddDays(_diasDuracion) > DateTime.Today);
    }

	/**
	 * 
	 * @param Condicion
	 * @param TipoInscripcion
	 * @param IDPartido
	 */
    
}