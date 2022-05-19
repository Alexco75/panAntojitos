using System;
using System.Collections.Generic;
using System.Text;

namespace Cravings.BusinessLogic.Model
{
    /// <summary>
    ///Copyright ©Antojitos - Colombia
    ///Clase Utilizada para dar respuesta al a quien llamaó el servicio.
    ///Autor		:	Alex Castillo Ortiz
    ///Fecha		:	28-Abril-2022
    /// </summary>
    public class ResponseService
    {

        #region Costructors

        public ResponseService()
        {
            this.Code = "1";
            /* Valores:  Cero(0)=Error
                         Uno(1)=Ok
            [0] :  Se presento Error
            [1]:   Ejecución Satisfactoria.
            */
            this.Message = "OK";
        }
        public void Dispose()
        {
        }
        #endregion

        #region Propiedades
        public int ConsElemento { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        #endregion
    }
}
