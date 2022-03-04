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
    public class NegocioModelo : INegocioModelo
    {
        //Inyección de la interfaz de contexto
        private readonly Contexto _db;
        public NegocioModelo(Contexto db)
        {
            _db = db;
        }
        //Negocio Delete
        public void Delete(Guid Id)
        {
            var rModelo = _db.Modelos.Where(c => c.Activo == true && c.Id_Modelo == Id).FirstOrDefault();
            rModelo.Activo = false;
            _db.SaveChanges();
        }
        //Negocio Get con inclusión de modelos
        public List<Modelo> Get()
        {
            var rModelo = _db.Modelos.Include(i => i.Marca).Where(c => c.Activo == true && c.Marca.Activo == true)
                .Select(s => new Modelo { Id_Modelo = s.Id_Modelo, Nombre = s.Nombre, Marca = new Marcas { Nombre = s.Marca.Nombre } })
                .ToList();
            return rModelo;
        }

        public Modelo GetT(Guid Id)
        {
            var rModelo = _db.Modelos.Include(i => i.Marca).Where(c => c.Id_Modelo == Id && c.Activo == true && c.Marca.Activo == true)
                .Select(s => new Modelo { Id_Modelo = s.Id_Modelo, Marca = new Marcas { Nombre = s.Marca.Nombre } })
                .ToList().FirstOrDefault();
            return rModelo;
        }

        //Negocio Post
        public void Post(Modelo entidad)
        {
            var modelo = new Modelo
            {
                Id_Modelo = entidad.Id_Modelo,
                Id_Marca = entidad.Id_Marca,
                Nombre = entidad.Nombre,
                Fecha_Movimiento = DateTime.Now,
                Usuario = "Usuario1",
                Fecha_Actualizacion = null,
                Usuario_Activo = "Verdadero",
                Activo = true,
            };
            _db.Add(modelo);
            _db.SaveChanges();
        }
        //Negocio Put
        public void Put(Modelo entidad)
        {
            var rModelo = _db.Modelos.Where(c => c.Activo == true & c.Id_Modelo == entidad.Id_Modelo).ToList().FirstOrDefault();
            rModelo.Id_Marca = entidad.Id_Marca;
            rModelo.Fecha_Actualizacion = DateTime.Now;
            rModelo.Nombre = entidad.Nombre;
            _db.Update(rModelo);
            _db.SaveChanges();
        }
    }
}
