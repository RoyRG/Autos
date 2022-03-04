using API.Data;
using API.Entidades.Entidades;
using API.Negocios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Negocios.Negocios
{
    public class NegocioCarro : INegocioCarro
    {
        //Inyección de la interfaz de contexto
        private readonly Contexto _db;
        public NegocioCarro(Contexto db)
        {
            _db = db;
        }
        //Negocio Delete
        public void Delete(Guid Id)
        {
            var rCarro = _db.Autos.Where(c => c.Id_Auto == Id && c.Activo == true).FirstOrDefault();
            rCarro.Activo = false;
            _db.SaveChanges();
        }
        //Negocio Get con inclusión de modelos
        public List<Autos> Get()
        {
            var rCarro = _db.Autos.Include(i => i.Lote).Include(i => i.Modelo).Include(i => i.Estado)/*.Where(c => c.Activo == true && c.Lote.Activo == true && c.Modelo.Activo == true && c.Estado.Activo == true)*/.Where(c => c.Activo == true)
                .Select(s => new Autos { Id_Auto = s.Id_Auto, Lote = new Lote { Nombre = s.Lote.Nombre }, Modelo = new Modelo { Nombre = s.Modelo.Nombre }, Estado = new Estado { Nombre = s.Estado.Nombre } })
                .ToList();
            return rCarro;
        }

        public Autos GetT(Guid Id)
        {
            var rCarro = _db.Autos.Include(i => i.Lote).Include(i => i.Modelo).Include(i => i.Estado).Where(c => c.Id_Auto == Id && c.Activo == true && c.Lote.Activo == true && c.Modelo.Activo == true && c.Estado.Activo == true)
              .Select(s => new Autos { Id_Auto = s.Id_Auto, Lote = new Lote { Nombre = s.Lote.Nombre }, Modelo = new Modelo { Nombre = s.Modelo.Nombre }, Estado = new Estado { Nombre = s.Estado.Nombre } })
               .ToList().FirstOrDefault();
            return rCarro;
        }
        //Negocio Post
        public void Post(Autos entidad)
        {
            var carro = new Autos()
            {
                Id_Auto = entidad.Id_Auto,
                Id_Estado = entidad.Id_Estado,
                Id_Lote = entidad.Id_Lote,
                Id_Modelo = entidad.Id_Modelo,
                Año = entidad.Año,
                Fecha_Ingreso = DateTime.Now,
                Fecha_Movimiento = DateTime.Now,
                Usuario = "Usuario1",
                Usuario_Activo = "Verdadero",
                Fecha_Actualizacion = null,
                Activo = true,
            };
            _db.Add(carro);
            _db.SaveChanges();
        }
        //Negocio Put
        public void Put(Autos entidad)
        {
            var rCarro = _db.Autos.Where(c => c.Id_Auto == entidad.Id_Auto && c.Activo == true).ToList().FirstOrDefault();
            rCarro.Id_Estado = entidad.Id_Estado;
            rCarro.Id_Lote = entidad.Id_Lote;
            rCarro.Id_Modelo = entidad.Id_Modelo;
            rCarro.Año = entidad.Año;
            rCarro.Fecha_Actualizacion = entidad.Fecha_Actualizacion;
            _db.Update(rCarro);
            _db.SaveChanges();
        }
    }
}
