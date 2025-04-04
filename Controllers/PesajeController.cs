using Parcial2.Clases;
using Parcial2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Parcial2.Controllers
{
    [RoutePrefix("api/Pesaje")]
    public class PesajeController : ApiController
    {
        [HttpPut]
        [Route("Insertar")]
        public string Insertar([FromBody] Pesaje pesaje, string placa, int nroEjes, string marca)
        {
            clsPesaje pesajes = new clsPesaje();
            pesajes.pesaje = pesaje;         
            return pesajes.Insertar(placa, nroEjes, marca);
        }

        [HttpGet]
        [Route("ConsultarImagenes")]
        public IQueryable ConsultarImagenes(string PlacaCamion)
        {
            clsPesaje pesaje = new clsPesaje();
            return pesaje.ListarImagenes(PlacaCamion);
        }

    }
}