using System;
using Microsoft.AspNetCore.Mvc;
using Cravings.BusinessLogic;

namespace Cravings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UpdateProductsController : ControllerBase
    {
        /// <summary>
        ///Copyright ©Antojitos - Colombia
        ///Metodo que se encarga de registrar Producto en la BD
        ///Autor		:	Alex Castillo Ortiz
        ///Fecha		:	01-Mayo-2022
        /// </summary>
        /// <param name="requestJsonParam">Objeto con parametros de entrada en formato.</param>
        /// <returns>Retorna Objeto con listado respuesta.</returns>
        [HttpPost]
        public object Post(string ConsProduct, string Name, string Description,
                            string UnitValue, string State)
        {
            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.UpdateProduct(ConsProduct, Name, Description,
                                                       UnitValue, State);
            }
        }
    }
}
