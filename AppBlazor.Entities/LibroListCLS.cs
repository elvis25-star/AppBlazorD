﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlazor.Entities
{
    public class LibroListCLS
    {
        public int idlibro { get; set; }
        public string titulo { get; set; } = null!;
        public string resumen {  get; set; }=null!;
        public string tipoLibro {  get; set; } = string.Empty;
        public string imagen {  get; set; } = "/img/nophoto.jpg";
    }
}
