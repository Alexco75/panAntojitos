using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cravings.BusinessLogic.Model
{
    /// <summary>
    ///Copyright ©Antojitos - Colombia
    ///Clase Utilizada para dar respuesta al a quien llamaó el servicio.
    ///Autor		:	Alex Castillo Ortiz
    ///Fecha		:	28-Abril-2022
    /// </summary>
    [Serializable()]
    public class ResponseServiceClient : ResponseService
    {

        #region Costructors

        public ResponseServiceClient()
        {
        }
        #endregion

        #region Propiedades
        public ArrayList Clientes { get; set; }
        
        #endregion
    }
}
