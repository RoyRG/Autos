using API.Entidades.Modelos;
using API.Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Autos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly IServicioMarca _servicioMarca;
        public MarcasController(IServicioMarca servicioMarca)
        {
            _servicioMarca = servicioMarca;
        }
        [HttpGet]
        public List<MarcaModelo> Get()
        {

            var rMarca = _servicioMarca.Get();
            if (rMarca == null)
            {
                return null;

            }
            else
            {
                var respuesta = rMarca;
                return respuesta;
            }
        }
        [HttpPost]
        public string Post([FromBody] MarcaModelo marcaModelo)
        {
            _servicioMarca.Post(marcaModelo);
            if (_servicioMarca == null)
            {
                return "Hubo un error";
            }
            else
            {
                return "Ok";
            }
        }
        [HttpPut]
        public string Put([FromBody] MarcaModelo marcaModelo)
        {
            _servicioMarca.Put(marcaModelo);
            if (_servicioMarca == null)
            {
                return "Hubo un error";
            }
            else
            {
                return "Ok";
            }
        }
        [HttpDelete]
        public string Delete([FromQuery] Guid Id)
        {
            _servicioMarca.Delete(Id);
            if (_servicioMarca == null)
            {
                return "Hubo un error";
            }
            else
            {
                return "Ok";
            }
        }
    }
}