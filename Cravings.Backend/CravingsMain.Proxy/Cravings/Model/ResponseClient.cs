using System;
using System.Collections;
using System.Threading.Tasks;
using Cravings.DataAccess;

namespace Cravings.BusinessLogic.Model
{
    /// <summary>
    ///Copyright ©Antojitos - Colombia
    ///Clase Utilizada para dar respuesta al a quien llamaó el servicio.
    ///Autor		:	Alex Castillo Ortiz
    ///Fecha		:	28-Abril-2022
    /// </summary>
    [Serializable()]
    public class ResponseClient : ResponseService
    {

        #region Costructors

        public ResponseClient()
        {
        }
        #endregion

        #region Propiedades
        public ArrayList Clients { get; set; }
        
        #endregion
    }
}
