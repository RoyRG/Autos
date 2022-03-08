using API.Entidades.Entidades;
using API.Entidades.Modelos;
using API.Negocios.Interfaces;
using API.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Servicios.Servicios
{
    public class ServicioModelo : IServicioModelo
    {
        //Inyección de la interfaz de negocio
        private readonly INegocioModelo _negocioModelo;
        public ServicioModelo(INegocioModelo negocioModelo)
        {
            _negocioModelo = negocioModelo;
        }
        //Servicio Delete
        public void Delete(Guid Id)
        {
            _negocioModelo.Delete(Id);
        }

        public List<ModeloModelo> Get()
        {
            var respuesta = new List<ModeloModelo>();
            var rModelo = _negocioModelo.Get();
            foreach (var modelo in rModelo)
            {
                var modelo_ = new ModeloModelo()
                {
                    Id = modelo.Id_Modelo,
                    Id_Marca = modelo.Id_Marca,
                    Marca = modelo.Marca.Nombre,
                    Nombre = modelo.Nombre,
                };
                respuesta.Add(modelo_);
            }
            return respuesta;
        }

        public ModeloModelo GetT(Guid Id)
        {
            var rModelo = _negocioModelo.GetT(Id);
            var modelo = new ModeloModelo()
            {
                Id = rModelo.Id_Modelo,
                Id_Marca = rModelo.Marca.Id_Marca,
                Marca = rModelo.Marca.Nombre,
                Nombre = rModelo.Nombre,
            };
            return modelo;
        }
        //Servicio Post
        public void Post(ModeloModelo entidad)
        {
            var modelo = new Modelo()
            {
                Id_Modelo = entidad.Id,
                Id_Marca = Guid.Parse(entidad.Marca),
                Nombre = entidad.Nombre,
                Fecha_Movimiento = DateTime.Now,
                Usuario = "Usuario1",
                Fecha_Actualizacion = null,
                Usuario_Activo = "Verdadero",
                Activo = true,
            };
            _negocioModelo.Post(modelo);
        }
        //Servicio Put
        public void Put(ModeloModelo entidad)
        {
            var modelo = new Modelo()
            {
                Id_Modelo = entidad.Id,
                Id_Marca = Guid.Parse(entidad.Marca),
                Nombre = entidad.Nombre,
                Fecha_Movimiento = DateTime.Now,
                Usuario = "Usuario1",
                Fecha_Actualizacion = null,
                Usuario_Activo = "Verdadero",
                Activo = true,
            };
            _negocioModelo.Put(modelo);
        }
    }
}
