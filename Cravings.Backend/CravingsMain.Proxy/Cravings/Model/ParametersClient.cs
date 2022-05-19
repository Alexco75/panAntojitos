using System;

namespace Cravings.BusinessLogic.Model
{
    /// <summary>
    ///Copyright ©Antojitos - Colombia
    ///Clase Utilizada para cargar parametros definidos en Json.
    ///Autor		:	Alex Castillo Ortiz
    ///Fecha		:	29-Abril-2022
    /// </summary>
    [Serializable()]
    class ParametersClient
    {
        #region Costructors

        public ParametersClient()
        {
        }

        public ParametersClient(string consClient, string typeIdentification, 
                                string identificationNumber, string firtsName, 
                                string secondName, string firtsLastName, 
                                string secondLastName, string email, 
                                string residentialAddress,  string workAddress,
                                string cellPhone, string permanentPhone, string state)
        {
            ConsCliente = consClient;
            TipoIdentificacion = typeIdentification;
            NumeroIdentificacion = identificationNumber;
            PrimerNombre = firtsName;
            SegundoNombre = secondName;
            PrimerApellido = firtsLastName;
            SegundoApellido = secondLastName;
            Email = email;
            DireccionResidencial = residentialAddress;
            DireccionTrabajo = workAddress;
            TelefonoCelular = cellPhone;
            TelefonoFijo = permanentPhone;
            Estado = state;
        }

        #endregion

        #region Members
        public string ConsCliente { get; set; }
        public string TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Email { get; set; }
        public string DireccionResidencial { get; set; }
        public string DireccionTrabajo { get; set; }
        public string TelefonoCelular { get; set; }
        public string TelefonoFijo { get; set; }
        public string Estado { get; set; }

        #endregion
       
    }
}