using System;
using System.Collections.Generic;
using System.Text;

namespace API.Negocios.Interfaces
{
    public interface INegocioBase <T>
    {
        List<T> Get();
        T GetT(Guid Id);
        void Post(T entidad);
        void Put(T entidad);
        void Delete(Guid Id);
    }
}
