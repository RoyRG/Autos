using API.Entidades.Entidades;
using API.Entidades.Modelos;
using API.Negocios.Interfaces;
using API.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Servicios.Servicios
{
    public class ServicioCarro : IServicioCarro
    {
        //Inyección de la interfaz de negocio
        private readonly INegocioCarro _negocioCarro;
        public ServicioCarro(INegocioCarro negocioCarro)
        {
            _negocioCarro = negocioCarro;
        }
        //Servicio Delete
        public void Delete(Guid Id)
        {
            _negocioCarro.Delete(Id);
        }
        //Servicio Get
        public List<AutoModelo> Get()
        {
            var respuesta = new List<AutoModelo>();
            var rCarro = _negocioCarro.Get();
            foreach (var car in rCarro)
            {
                var carro = new AutoModelo()
                {
                    Id_Auto = car.Id_Auto,
                    Estado = car.Estado.Nombre,
                    Lote = car.Lote.Nombre,
                    Año = car.Año,
                    //Fecha_Ingreso = car.Fecha_Ingreso,
                    Modelo = car.Modelo.Nombre,
                };
                respuesta.Add(carro);
            }
            return respuesta;
        }

        public AutoModelo GetT(Guid Id)
        {
            var rCarro = _negocioCarro.GetT(Id);
            var carro = new AutoModelo()
            {
                Id_Auto = rCarro.Id_Auto,
                Estado = rCarro.Estado.Nombre,
                Lote = rCarro.Lote.Nombre,
                Año = rCarro.Año,
               /* Fecha_Ingreso = rCarro.Fecha_Ingreso*/
                Modelo = rCarro.Modelo.Nombre,
            };
            return carro;
        }
        //Servicio Post
        public void Post(AutoModelo entidad)
        {
            var carro = new Autos()
            {
                Id_Auto = entidad.Id_Auto,
                Id_Estado = Guid.Parse(entidad.Estado),
                Id_Lote = Guid.Parse(entidad.Lote),
                Id_Modelo = Guid.Parse(entidad.Modelo),
                Fecha_Ingreso = DateTime.Now,
                Año = entidad.Año,
                Activo = true,
            };
            _negocioCarro.Post(carro);
        }
        //Servicio Put
        public void Put(AutoModelo entidad)
        {
            var carro = new Autos()
            {
                Id_Auto = entidad.Id_Auto,
                Id_Estado = Guid.Parse(entidad.Estado),
                Id_Lote = Guid.Parse(entidad.Lote),
                Id_Modelo = Guid.Parse(entidad.Modelo),
                Fecha_Ingreso = DateTime.Now,
                Año = entidad.Año,
                Activo = true,
            };
            _negocioCarro.Put(carro);
        }
    }
}
