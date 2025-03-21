﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Università.DataModel
{
    internal class MainEnumerators
    {
        internal enum Genere
        {
            None,
            Maschio,
            Femmina,
            Altro
        }
        internal enum Facolta
        {
            None,
            Ingegneria,
            Medicina,
            Lettere,
            Economia,
            Scienze
        }

        internal enum TipoCorso
        {
            None,
            Triennale,
            Magistrale,
            Dottorato
        }
    }
}
