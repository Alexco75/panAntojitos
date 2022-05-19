using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cravings.BusinessLogic;
using System.Net.Http;
using System.Threading;

namespace Cravings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentasController : ControllerBase
    {
        /// <summary>
        ///Copyright ©Antojitos - Colombia
        ///Metodo que se encarga de la admon Ventas en la BD
        ///Autor		:	Alex Castillo Ortiz
        ///Fecha		:	17-Mayo-2022
        /// </summary>
        /// <param name="requestJsonParam">Objeto con parametros de entrada en formato Json.</param>
        /// <returns>Retorna Objeto con listado respuesta.</returns>
        [HttpPost]
        [Consumes("application/json")]
        public object Post([FromBody]object requestJsonParam)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.AddSale(requestJsonParam);
            }
        }

        [HttpPut]
        public object Put([FromBody]object requestJsonParam)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.UpdateSale(requestJsonParam);
            }
        }
        [HttpGet("{consSale}")]
        public object Get(int consSale)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.GetSale(consSale.ToString());
            }
        }
        [HttpGet]
        public object Get()
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.GetSales();
            }
        }
        [HttpDelete("{consSale}")]
        public object Delete(int consSale)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.DeleteSale(consSale);
            }
        }
    }
}
