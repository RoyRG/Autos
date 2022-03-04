﻿using System;
using System.Collections.Generic;
using System.Text;

namespace API.Entidades.Entidades
{
    public class Lote
    {
        public Guid Id_Lote { get; set; }
        public string Nombre { get; set; }
        public DateTime? Fecha_Movimiento { get; set; }
        public string Usuario { get; set; }
        public DateTime? Fecha_Actualizacion { get; set; }
        public string Usuario_Activo { get; set; }
        public bool Activo { get; set; }
    }
}
