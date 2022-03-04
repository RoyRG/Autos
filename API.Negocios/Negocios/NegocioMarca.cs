using API.Data;
using API.Entidades.Entidades;
using API.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Negocios.Negocios
{
    public class NegocioMarca : INegocioMarca
    {
        //Inyección de la interfaz de contexto
        private readonly Contexto _db;
        public NegocioMarca(Contexto db)
        {
            _db = db;
        }
        //Negocio Delete
        public void Delete(Guid Id)
        {
            var rMarca = _db.Marcas.Where(c => c.Id_Marca == Id && c.Activo == true).FirstOrDefault();
            rMarca.Activo = false;
            _db.SaveChanges();
        }
        //Negocio Get
        public List<Marcas> Get()
        {
            var rMarca = _db.Marcas.Where(c => c.Activo == true).ToList();
            return rMarca;
        }

        public Marcas GetT(Guid Id)
        {
            var rMarca = _db.Marcas.Where(c => c.Activo == true && c.Id_Marca == Id).ToList().FirstOrDefault();
            return rMarca;
        }
        //Negocio Post
        public void Post(Marcas entidad)
        {
            var marca = new Marcas()
            {
                Id_Marca = entidad.Id_Marca,
                Nombre = entidad.Nombre,
                Fecha_Movimiento = DateTime.Now,
                Fecha_Actualizacion = null,
                Usuario = "Usuario1",
                Usuario_Activo = "Verdadero",
                Activo = true
            };
            _db.Marcas.Add(marca);
            _db.SaveChanges();
        }
        //Negocio Put
        public void Put(Marcas entidad)
        {
            var rMarca = _db.Marcas.Where(c => c.Id_Marca == entidad.Id_Marca && c.Activo == true).ToList().FirstOrDefault();
            rMarca.Nombre = entidad.Nombre;
            rMarca.Fecha_Actualizacion = DateTime.Now;
            _db.Update(rMarca);
            _db.SaveChanges();
        }
    }
}
