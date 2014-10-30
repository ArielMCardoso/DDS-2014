using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualStudio.QualityTools.UnitTestFramework;

/**
 * @author alumno
 * @version 1.0
 * @created 16-Ago-2014 12:40:28 p.m.
 */
public class Estándar: TipoInscripción {
    public override bool esEstandar()
    {
        return true;
    }

}