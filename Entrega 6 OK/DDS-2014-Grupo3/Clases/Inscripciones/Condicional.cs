using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualStudio.QualityTools.UnitTestFramework;


/**
 * @author alumno
 * @version 1.0
 * @created 16-Ago-2014 12:40:11 p.m.
 */
public class Condicional: TipoInscripci�n {
    public string condicion;
    public override bool esCondicional()
    {
        return true;
    }
    public override void agregarCondicion(string condicion2) {
        condicion = condicion2;
    }
}