using System;

namespace Cravings.BusinessLogic.Model
{
    /// <summary>
    /// Copyright ©Antojitos - Colombia
    /// Clase Enum, utilizada para saber con que clase se debe hacer desserialización de documento Json
    /// Autor		:	Alex castillo Ortiz
    ///Fecha		:	30-Abril-2022
    /// </summary>
    public enum TypeParametersApiRest
    {
        ParametersProduct, ParametersInventory, ParametersClient,
        ParametersSale, ParametersDetailSale
    }
}
