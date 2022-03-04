using API.Entidades.Entidades;
using API.Entidades.Modelos;
using API.Negocios.Interfaces;
using API.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Servicios.Servicios
{
    public class ServicioEstado : IServicioEstado
    {
        private readonly INegocioEstado _negocioEstado;
        public ServicioEstado(INegocioEstado negocioEstado)
        {
            _negocioEstado = negocioEstado;
        }

        public void Delete(Guid Id)
        {
            _negocioEstado.Delete(Id);
        }

        public List<EstadoModelo> Get()
        {
            var respuesta = new List<EstadoModelo>();
            var rEstado = _negocioEstado.Get();
            foreach (var estado_ in rEstado)
            {
                var estado = new EstadoModelo()
                {
                    Id = estado_.Id_Estado,
                    Nombre = estado_.Nombre,

                };
                respuesta.Add(estado);
            }
            return respuesta;
        }

        public EstadoModelo GetT(Guid Id)
        {
            var rEstado= _negocioEstado.GetT(Id);
            var estado = new EstadoModelo()
            {
                Id = rEstado.Id_Estado,
                Nombre = rEstado.Nombre,
            };
            return estado;
        }

        public void Post(EstadoModelo entidad)
        {
            var estado = new Estado
            {
                Id_Estado = entidad.Id,
                Nombre = entidad.Nombre,
                Fecha_Movimiento = DateTime.Now,
                Fecha_Actualizacion = null,
                Usuario = "Usuario1",
                Usuario_Activo = "Verdadero",
                Activo = true,
            };
            _negocioEstado.Post(estado);
        }

        public void Put(EstadoModelo entidad)
        {
            var estado = new Estado
            {
                Id_Estado = entidad.Id,
                Nombre = entidad.Nombre,
                Fecha_Movimiento = DateTime.Now,
                Fecha_Actualizacion = null,
                Usuario = "Usuario1",
                Usuario_Activo = "Verdadero",
                Activo = true,
            };
            _negocioEstado.Put(estado);
        }
    }
}
