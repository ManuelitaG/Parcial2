using Parcial2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Parcial2.Controllers
{
    [RoutePrefix("api/Fotos")]
    public class FotosController : ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> CargarArchivo(HttpRequestMessage request, string Datos, string Proceso)
        {           
            clsFotos fotos = new clsFotos();
            fotos.Datos = Datos;
            fotos.Proceso = Proceso;
            fotos.request = request;
            return await fotos.GrabarArchivo(false);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> ActualizarArchivo(HttpRequestMessage request)
        {
            clsFotos fotos = new clsFotos();
            fotos.request = request;
            return await fotos.GrabarArchivo(true);
        }
    }
}