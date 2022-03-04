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
    public class LotesController : ControllerBase
    {
        private readonly IServicioLote _servicioLote;
        public LotesController(IServicioLote servicioLote)
        {
            _servicioLote = servicioLote;
        }
        [HttpGet]
        public List<LoteModelo> Get()
        {
            var rLote = _servicioLote.Get();
            if (rLote == null)
            {
                return null;
            }
            else
            {
                return rLote;
            }
        }
        [HttpPost]
        public string Post([FromBody] LoteModelo loteModelo)
        {
            _servicioLote.Post(loteModelo);
            if (_servicioLote == null)
            {
                return "Hubo un error";
            }
            else
            {
                return "Ok";
            }
        }
        [HttpPut]
        public string Put([FromBody] LoteModelo loteModelo)
        {
            _servicioLote.Put(loteModelo);
            if (_servicioLote == null)
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
            _servicioLote.Delete(Id);
            if (_servicioLote == null)
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
