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
    public class DetalleVentasController : ControllerBase
    {
        /// <summary>
        ///Copyright ©Antojitos - Colombia
        ///Metodo que se encarga de la admon Detalle Ventas(Productos) en la BD
        ///Autor		:	Alex Castillo Ortiz
        ///Fecha		:	19-Mayo-2022
        /// </summary>
        /// <param name="requestJsonParam">Objeto con parametros de entrada en formato Json.</param>
        /// <returns>Retorna Objeto con listado respuesta.</returns>
        [HttpPost]
        [Consumes("application/json")]
        public object Post([FromBody]object requestJsonParam)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.AddDetailSale(requestJsonParam);
            }
        }

        [HttpPut]
        public object Put([FromBody]object requestJsonParam)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.UpdateDetailSale(requestJsonParam);
            }
        }
        [HttpGet("{consVenta}")]
        public object Get(int consVenta)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.GetDetailSale(consVenta.ToString());
            }
        }
        [HttpGet]
        public object Get()
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.GetDetailSales();
            }
        }
        [HttpDelete("{consVenta}")]
        public object Delete(int consVenta)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.DeleteDetailSale(consVenta);
            }
        }
        [HttpGet("{consVenta}/{consProducto}")]
        public object Delete(int consVenta, int consProducto)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.DeleteDetailSale(consVenta.ToString(), consProducto.ToString());
            }
        }
    }
}
