using System;
using System.Collections.Generic;
using System.Text;

namespace API.Entidades.Entidades
{
    //Entidades de la tabla con clases para la muestra de datos
    public class Modelo
    {
        public Guid Id_Modelo { get; set; }
        public Guid Id_Marca { get; set; }
        public string Nombre { get; set; }
        public DateTime? Fecha_Movimiento { get; set; }
        public string Usuario { get; set; }
        public DateTime? Fecha_Actualizacion { get; set; }
        public string Usuario_Activo { get; set; }
        public bool Activo { get; set; }
        public Marcas Marca { get; set; }
    }
}
