using API.Data;
using API.Entidades.Entidades;
using API.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Negocios.Negocios
{
    //Inyección de la interfaz de contexto
    public class NegocioLote : INegocioLote
    {
        private readonly Contexto _db;
        public NegocioLote(Contexto db)
        {
            _db = db;
        }
        //Negocio Delete
        public void Delete(Guid Id)
        {
            var rLote = _db.Lote.Where(c => c.Id_Lote == Id && c.Activo == true).FirstOrDefault();
            rLote.Activo = false;
            _db.SaveChanges();
        }
        //Negocio Get
        public List<Lote> Get()
        {
            var rLote = _db.Lote.Where(c => c.Activo == true).ToList();
            return rLote;
        }

        public Lote GetT(Guid Id)
        {
            var rLote = _db.Lote.Where(c => c.Activo == true && c.Id_Lote == Id).ToList().FirstOrDefault();
            return rLote;
        }
        //Negocio Post
        public void Post(Lote entidad)
        {
            var lote = new Lote()
            {
                Id_Lote = entidad.Id_Lote,
                Nombre = entidad.Nombre,
                Fecha_Movimiento = DateTime.Now,
                Usuario = "Usuario1",
                Fecha_Actualizacion = null,
                Usuario_Activo = "Verdadero",
                Activo = true,
            };
            _db.Add(lote);
            _db.SaveChanges();
        }
        //Negocio Put
        public void Put(Lote entidad)
        {
            var rLote = _db.Lote.Where(c => c.Id_Lote == entidad.Id_Lote && c.Activo == true).ToList().FirstOrDefault();
            rLote.Nombre = entidad.Nombre;
            rLote.Fecha_Actualizacion = DateTime.Now;
            _db.Update(rLote);
            _db.SaveChanges();
        }
    }
}
