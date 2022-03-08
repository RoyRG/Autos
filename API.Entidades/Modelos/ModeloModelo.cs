using System;
using System.Collections.Generic;
using System.Text;

namespace API.Entidades.Modelos
{
    //DTO de la tabla
    public class ModeloModelo
    {
        public Guid Id { get; set; }
        public Guid Id_Marca { get; set; }
        public string Marca { get; set; }
        public string Nombre { get; set; }
    }
}
