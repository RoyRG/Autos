using API.Data;
using API.Entidades.Entidades;
using API.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Negocios.Negocios
{
    public class NegocioEstado : INegocioEstado
    {
        //Inyección de la interfaz de contexto
        private readonly Contexto _db;
        public NegocioEstado(Contexto db)
        {
            _db = db;
        }
        //Negocio Delete
        public void Delete(Guid Id)
        {
            var rEstado = _db.Estado.Where(c => c.Activo == true && c.Id_Estado == Id).FirstOrDefault();
            rEstado.Activo = false;
            _db.SaveChanges();
        }
        //Negocio Get
        public List<Estado> Get()
        {
            var rEstado = _db.Estado.Where(c => c.Activo == true).ToList();
            return rEstado;
        }

        public Estado GetT(Guid Id)
        {
            var rEstado = _db.Estado.Where(c => c.Activo == true && c.Id_Estado == Id).ToList().FirstOrDefault();
            return rEstado;
        }
        //Negocio Post
        public void Post(Estado entidad)
        {
            var estado = new Estado
            {
                Id_Estado = entidad.Id_Estado,
                Nombre = entidad.Nombre,
                Fecha_Movimiento = DateTime.Now,
                Usuario = "Usuario1",
                Fecha_Actualizacion = null,
                Usuario_Activo = "Verdadero",
                Activo = true,
            };
            _db.Add(estado);
            _db.SaveChanges();
        }
        //Negocio Put
        public void Put(Estado entidad)
        {
            var rEstado = _db.Estado.Where(c => c.Activo == true && c.Id_Estado == entidad.Id_Estado).ToList().FirstOrDefault();
            rEstado.Nombre = entidad.Nombre;
            rEstado.Fecha_Actualizacion = DateTime.Now;
            _db.Update(rEstado);
            _db.SaveChanges();
        }
    }
}
