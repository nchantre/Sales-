using SalesCannon.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Configuration;
using System.Net.Http;
using System.Web.Http;

namespace SalesApi.Controllers
{
    public class PersonaController : ApiController
    {

        Personaconection bd = new Personaconection();
        public IEnumerable<Persona> Get()
        {
            var listado = bd.Persona.ToList();
            return listado;
        }
    }
}
