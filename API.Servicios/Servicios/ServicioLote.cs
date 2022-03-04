using API.Entidades.Entidades;
using API.Entidades.Modelos;
using API.Negocios.Interfaces;
using API.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Servicios.Servicios
{
    public class ServicioLote : IServicioLote
    {
        //Inyección de la interfaz de negocio
        private readonly INegocioLote _negocioLote;
        public ServicioLote(INegocioLote negocioLote)
        {
            _negocioLote = negocioLote;
        }
        //Servicio Delete
        public void Delete(Guid Id)
        {
            _negocioLote.Delete(Id);
        }
        //Servicio Get
        public List<LoteModelo> Get()
        {
            var respuesta = new List<LoteModelo>();
            var rLot = _negocioLote.Get();
            foreach (var lot in rLot)
            {
                var Lot = new LoteModelo()
                {
                    Id = lot.Id_Lote,
                    Nombre = lot.Nombre,
                };
                respuesta.Add(Lot);
            }

            return respuesta;
        }

        public LoteModelo GetT(Guid Id)
        {
            var rLot = _negocioLote.GetT(Id);
            var lot = new LoteModelo()
            {
                Id = rLot.Id_Lote,
                Nombre = rLot.Nombre,
            };
            return lot;
        }
        //Servicio Post
        public void Post(LoteModelo entidad)
        {
            var lot = new Lote
            {
                Id_Lote = entidad.Id,
                Nombre = entidad.Nombre,
                Fecha_Movimiento = DateTime.Now,
                Usuario = "Usuario1",
                Usuario_Activo = "Verdadero",
                Activo = true,
                Fecha_Actualizacion = null,
            };
            _negocioLote.Post(lot);
        }
        //Servicio Put
        public void Put(LoteModelo entidad)
        {
            var lot = new Lote
            {
                Id_Lote = entidad.Id,
                Nombre = entidad.Nombre,
                Fecha_Movimiento = DateTime.Now,
                Usuario = "Usuario1",
                Usuario_Activo = "Verdadero",
                Activo = true,
                Fecha_Actualizacion = null,
            };
            _negocioLote.Put(lot);
        }
    }
}
