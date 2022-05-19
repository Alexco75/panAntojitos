using System;
using System.Collections;
using System.Threading.Tasks;
using Cravings.DataAccess;

namespace Cravings.BusinessLogic.Model
{
    /// <summary>
    ///Copyright ©Antojitos - Colombia
    ///Clase Utilizada para dar respuesta al a quien llamó el servicio.
    ///Autor		:	Alex Castillo Ortiz
    ///Fecha		:  01-Mayo-2022
    /// </summary>
    [Serializable()]
    public class ResponseServiceProduct : ResponseService
    {

        #region Costructors

        public ResponseServiceProduct()
        {
        }
        #endregion

        #region Propiedades
        public ArrayList Products { get; set; }
        
        #endregion
    }
}
