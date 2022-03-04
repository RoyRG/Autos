using API.Entidades.Entidades;
using API.Entidades.Modelos;
using API.Negocios.Interfaces;
using API.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Servicios.Servicios
{
    public class ServicioMarca : IServicioMarca
    {
        //Inyección de la interfaz de negocio
        private readonly INegocioMarca _negocioMarca;
        public ServicioMarca(INegocioMarca negocioMarca)
        {
            _negocioMarca = negocioMarca;
        }
        //Servicio Delete
        public void Delete(Guid Id)
        {
            _negocioMarca.Delete(Id);
        }
        //Servicio Get
        public List<MarcaModelo> Get()
        {
            var respuesta = new List<MarcaModelo>();
            var rMarca = _negocioMarca.Get();
            foreach (var marca in rMarca)
            {
                var Marca = new MarcaModelo()
                {
                    Id = marca.Id_Marca,
                    Nombre = marca.Nombre,
                };
                respuesta.Add(Marca);
            }
            return respuesta;
        }

        public MarcaModelo GetT(Guid Id)
        {
            var rMarca = _negocioMarca.GetT(Id);
            var marca = new MarcaModelo()
            {
                Id = rMarca.Id_Marca,
                Nombre = rMarca.Nombre,

            };
            return marca;
        }
        //Servicio Post
        public void Post(MarcaModelo entidad)
        {
            var marca = new Marcas
            {
                Id_Marca = entidad.Id,
                Nombre = entidad.Nombre,
                Fecha_Movimiento = DateTime.Now,
                Usuario = "Usuario1",
                Fecha_Actualizacion = null,
                Usuario_Activo = "Verdadero",
                Activo = true,
            };
            _negocioMarca.Post(marca);
        }
        //Servicio Put
        public void Put(MarcaModelo entidad)
        {
            var marca = new Marcas
            {
                Id_Marca = entidad.Id,
                Nombre = entidad.Nombre,
                Fecha_Movimiento = DateTime.Now,
                Usuario = "Usuario1",
                Fecha_Actualizacion = DateTime.Now,
                Usuario_Activo = "Verdadero",
                Activo = true,
            };
            _negocioMarca.Put(marca);
        }
    }
}
