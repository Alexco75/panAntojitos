using System;

namespace Cravings.BusinessLogic.Model
{
    /// <summary>
    ///Copyright ©Antojitos - Colombia
    ///Clase Utilizada para cargar Información encontrada.
    ///Autor		:	Alex Castillo Ortiz
    ///Fecha		:	01-Mayo-2022
    /// </summary>
    [Serializable()]
    public class ClientModel
    {
        #region Members
        public int ConsCliente { get; set; }
        public int TipoIdentificacion { get; set; }
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
        public int Estado { get; set; }
        public DateTime FechaRegistro { get; set; }

        #endregion
    }
}
