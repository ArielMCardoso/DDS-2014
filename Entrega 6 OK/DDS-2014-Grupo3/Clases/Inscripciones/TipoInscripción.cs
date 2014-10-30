using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualStudio.QualityTools.UnitTestFramework;

/**
 * @author alumno
 * @version 1.0
 * @created 16-Ago-2014 12:40:55 p.m.
 */
public abstract class TipoInscripción {
    public string condicion;
    public virtual void agregarCondicion(string condicion) { }
    public virtual bool esEstandar()
    {
        return false;
    }
    public virtual bool esSolidario()
    {
        return false;
    }
    public virtual bool esCondicional()
    {
        return false;
    }
}