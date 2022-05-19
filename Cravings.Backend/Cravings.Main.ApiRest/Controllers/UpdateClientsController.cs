using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cravings.BusinessLogic;

namespace Cravings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UpdateClientsController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ClientesController> _logger;

        public UpdateClientsController(ILogger<ClientesController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///Copyright ©Antojitos - Colombia
        ///Metodo que se encarga de registrar Cliente en la BD
        ///Autor		:	Alex Castillo Ortiz
        ///Fecha		:	01-Mayo-2022
        /// </summary>
        /// <param name="requestJsonParam">Objeto con parametros de entrada en formato Json.</param>
        /// <returns>Retorna Objeto con listado respuesta.</returns>
        //[HttpPost]
        //public object Post(string ConsClient, string TypeIdentification, string IdentificationNumber,
        //                    string FirtsName, string SecondName, string FirtsLastName,
        //                    string SecondLastName, string Email, string ResidentialAddress, string WorkAddress,
        //                    string CellPhone, string PermanentPhone, string State)
        //{

        //    using (CravingProxyMgr cravingProxyMgr = new CravingProxyMgr())
        //    {
        //        //return cravingProxyMgr.UpdateClient(ConsClient, TypeIdentification, IdentificationNumber,
        //        //                                    FirtsName, SecondName, FirtsLastName, SecondLastName, Email,
        //        //                                    ResidentialAddress, WorkAddress, CellPhone,
        //        //                                    PermanentPhone, State);
        //    }
        //}
    }
}
