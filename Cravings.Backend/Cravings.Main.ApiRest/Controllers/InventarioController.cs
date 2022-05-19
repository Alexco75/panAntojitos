using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cravings.BusinessLogic;

namespace Cravings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventarioController : ControllerBase
    {
        /// <summary>
        ///Copyright ©Antojitos - Colombia
        ///Metodo que se encarga de la admon Inventario Inventoryos en la BD
        ///Autor		:	Alex Castillo Ortiz
        ///Fecha		:	18-Mayo-2022
        /// </summary>
        /// <param name="requestJsonParam">Objeto con parametros de entrada en formato Json.</param>
        /// <returns>Retorna Objeto con listado respuesta.</returns>
        [HttpPost]
        [Consumes("application/json")]
        public object Post([FromBody]object requestJsonParam)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.AddInventory(requestJsonParam);
            }
        }

        [HttpPut]
        public object Put([FromBody]object requestJsonParam)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.UpdateInventory(requestJsonParam);
            }
        }
        [HttpGet("{consInventario}")]
        public object Get(int consInventario)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.GetInventory(consInventario.ToString());
            }
        }
        [HttpGet("{consProducto}/{estado}")]
        public object Get(int consProducto, int estado)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.GetInventoryByProduct(consProducto.ToString(), estado.ToString());
            }
        }
        [HttpGet]
        public object Get()
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.GetInventories();
            }
        }
        [HttpDelete("{consInventorio}")]
        public object Delete(int consInventorio)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.DeleteInventory(consInventorio);
            }
        }
    }
}
