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
    public class EstadoController : ControllerBase
    {
        private readonly IServicioEstado _servicioEstado;
        public EstadoController(IServicioEstado servicioEstado)
        {
            _servicioEstado = servicioEstado;
        }
        [HttpGet]
        public List<EstadoModelo> Get()
        {
            var rEstado = _servicioEstado.Get();
            if (rEstado == null)
            {
                return null;
            }
            else
            {
                return rEstado;
            }
        }
        [HttpPost]
        public string Post([FromBody] EstadoModelo estadoModelo)
        {
            _servicioEstado.Post(estadoModelo);
            if (_servicioEstado == null)
            {
                return "Hubo un error";
            }
            else
            {
                return "Ok";
            }
        }
        [HttpPut]
        public string Put([FromBody] EstadoModelo estadoModelo)
        {
            _servicioEstado.Put(estadoModelo);
            if (_servicioEstado == null)
            {
                return "Hubo un error";
            }
            else
            {
                return "Ok";
            }
        }
        public string Delete([FromQuery] Guid Id)
        {
            _servicioEstado.Delete(Id);
            if (_servicioEstado == null)
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
