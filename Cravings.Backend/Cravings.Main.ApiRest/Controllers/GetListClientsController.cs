using System;
using Microsoft.AspNetCore.Mvc;
using Cravings.BusinessLogic;


namespace Cravings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetListClientsController : ControllerBase
    {
        #region Get Varios Parametros
        ///// <summary>
        /////Copyright ©Antojitos - Colombia
        /////Metodo que se encarga de Consultar Clientes de la BD
        /////Autor		:	Alex Castillo Ortiz
        /////Fecha		:	01-Mayo-2022
        ///// </summary>
        ///// <param name="requestJsonParam">Objeto con parametros de entrada en formato Json.</param>
        ///// <returns>Retorna Objeto con listado respuesta.</returns>
        //[HttpGet]
        //public object Get(string ConsClient, string TypeIdentification, string IdentificationNumber,
        //                    string FirtsName, string SecondName, string FirtsLastName,
        //                    string SecondLastName, string Email, string ResidentialAddress, string WorkAddress,
        //                    string CellPhone, string PermanentPhone, string State)
        //{

        //    using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
        //    {
        //        return cravingProxyMgr.GetClient(ConsClient, TypeIdentification, IdentificationNumber,
        //                                            FirtsName, SecondName, FirtsLastName, SecondLastName, Email,
        //                                            ResidentialAddress, WorkAddress, CellPhone,
        //                                            PermanentPhone, State);
        //    }
        //}
        #endregion

        /// <summary>
        ///Copyright ©Antojitos - Colombia
        ///Metodo que se encarga de Consultar Clientes de la BD
        ///Autor		:	Alex Castillo Ortiz
        ///Fecha		:	01-Mayo-2022
        /// </summary>
        /// <param name="requestJsonParam">Objeto con parametros de entrada en formato Json.</param>
        /// <returns>Retorna Objeto con listado respuesta.</returns>
        [HttpPost]
        public object Post()
        {

            using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
            {
                return cravingProxyMgr.GetClients();
            }
        }
    }
}
