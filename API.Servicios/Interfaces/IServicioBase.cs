using System;
using System.Collections.Generic;
using System.Text;

namespace API.Servicios.Interfaces
{
     //Interfaz base 
    public interface IServicioBase <T>
    {
        List<T> Get();
        T GetT(Guid Id);
        void Post(T entidad);
        void Put(T entidad);
        void Delete(Guid Id);
    }
}
