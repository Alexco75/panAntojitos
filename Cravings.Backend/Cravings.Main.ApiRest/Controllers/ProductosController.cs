using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cravings.BusinessLogic;

namespace Cravings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
        /// <summary>
        ///Copyright ©Antojitos - Colombia
        ///Metodo que se encarga de la admon Productos en la BD
        ///Autor		:	Alex Castillo Ortiz
        ///Fecha		:	01-Abril-2022
        /// </summary>
        /// <param name="requestJsonParam">Objeto con parametros de entrada en formato Json.</param>
        /// <returns>Retorna Objeto con listado respuesta.</returns>
        [HttpPost]
        [Consumes("application/json")]
        public object Post([FromBody]object requestJsonParam)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.AddProduct(requestJsonParam);
            }
        }

        [HttpPut]
        public object Put([FromBody]object requestJsonParam)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.UpdateProduct(requestJsonParam);
            }
        }
        [HttpGet("{consProducto}")]
        public object Get(int consProducto)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.GetProduct(consProducto.ToString());
            }
        }
        [HttpGet]
        public object Get()
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.GetProducts();
            }
        }
        [HttpDelete("{consProducto}")]
        public object Delete(int consProducto)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.DeleteProduct(consProducto);
            }
        }
    }
}
