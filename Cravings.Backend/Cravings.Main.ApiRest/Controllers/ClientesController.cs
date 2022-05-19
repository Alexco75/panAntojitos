using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cravings.BusinessLogic;
using System.Net.Http;
using System.Threading;
using Cravings.BusinessLogic;
namespace Cravings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        /// <summary>
        ///Copyright ©Antojitos - Colombia
        ///Metodo que se encarga de la admon Clientes en la BD
        ///Autor		:	Alex Castillo Ortiz
        ///Fecha		:	28-Abril-2022
        /// </summary>
        /// <param name="requestJsonParam">Objeto con parametros de entrada en formato Json.</param>
        /// <returns>Retorna Objeto con listado respuesta.</returns>
        [HttpPost]
        [Consumes("application/json")]
        public object Post([FromBody]object requestJsonParam)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.AddClient(requestJsonParam);
            }
        }

        [HttpPut]
        public object Put([FromBody]object requestJsonParam)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.UpdateClient(requestJsonParam);
            }
        }
        [HttpGet("{consCliente}")]
        public object Get(int consCliente)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.GetClient(consCliente.ToString());
            }
        }
        [HttpGet("{numIentificacion}/{tipoIdentificacion}")]
        public object Get(int numIentificacion, int tipoIdentificacion)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.GetClient(numIentificacion.ToString(), tipoIdentificacion.ToString());
            }
        }
        [HttpGet]
        public object Get()
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.GetClients();
            }
        }
        [HttpDelete("{consCliente}")]
        public object Delete(int consCliente)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.DeleteClient(consCliente);
            }
        }
    }
}
