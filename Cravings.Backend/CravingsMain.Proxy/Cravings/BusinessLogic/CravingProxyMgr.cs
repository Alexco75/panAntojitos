using System;
using System.Collections;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using Cravings.BusinessLogic.Manager;
using Cravings.BusinessLogic.Model;
using Cravings.Common;


namespace Cravings.BusinessLogic
{
    public class CravingProxyMgr:IDisposable
    {
        public CravingProxyMgr()
        { }
        public void Dispose() { }

        #region Methods Client

        /// <summary>
        ///Copyright ©Antojitos - Colombia
        ///Metodo que se encarga de registrar Cliente en la BD
        ///Autor		:	Alex Castillo Ortiz
        ///Fecha		:	28-Abril-2022
        /// </summary>
        /// <param name="pRequestJsonParam">Objeto con parametros de entrada en formato Json.</param>
        /// <param name="pParam">Objeto con parametros de entrada en formato .Net.</param>
        /// <returns>Retorna Objeto con listado respuesta.</returns>
        public ResponseService AddClient(object pRequestJsonParam)
        {
            #region Atributos
            ParametersClient param = null;
            ResponseService responseService = null;
            #endregion

            responseService = new ResponseService();

            using (CravinsClientMgr cravinsClientMgr = new CravinsClientMgr())
            {
                try
                {
                    if ((pRequestJsonParam != null && !string.IsNullOrEmpty(pRequestJsonParam.ToString())))
                    {
                        param = (ParametersClient)DeserializeJsonGeneric(pRequestJsonParam.ToString(), TypeParametersApiRest.ParametersClient);
                        //Guarda Datos
                        cravinsClientMgr.Add(param.NumeroIdentificacion, param.TipoIdentificacion,
                            param.PrimerNombre, param.SegundoNombre,
                            param.PrimerApellido, param.SegundoApellido,
                            param.Email, param.DireccionResidencial, param.DireccionTrabajo,
                            param.TelefonoCelular, param.TelefonoFijo
                            );
                        responseService.Code = Utilities.CONS_UNO.ToString();

                        responseService.Message = "Registro Creado.";
                    }
                    else
                    {
                        responseService.Code = Utilities.CONS_CERO.ToString();
                        responseService.Message = Utilities.PARAMETERS_JSON_NULS;
                    }
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return responseService;
            }
        }
        /// <summary>
        ///Copyright ©Antojitos - Colombia
        ///Metodo que se encarga de actualizar en la BD datos cliente
        ///Autor		:	Alex Castillo Ortiz
        ///Fecha		:	28-Abril-2022
        /// </summary>
        /// <param name="pRequestJsonParam">Objeto con parametros de entrada en formato Json.</param>
        /// <param name="pParam">Objeto con parametros de entrada en formato .Net.</param>
        /// <returns>Retorna Objeto con listado respuesta.</returns>
        public ResponseService UpdateClient(object pRequestJsonParam, object pParam = null)
        {
            #region Atributos
            ParametersClient param = null;
            ResponseService responseService = null;
            #endregion

            responseService = new ResponseService();

            using (CravinsClientMgr cravinsClientMgr = new CravinsClientMgr())
            {
                try
                {
                    if ((pParam != null) || (pRequestJsonParam != null && !string.IsNullOrEmpty(pRequestJsonParam.ToString())))
                    {
                        if (pParam == null)
                        {
                            param = (ParametersClient)DeserializeJsonGeneric(pRequestJsonParam.ToString(), TypeParametersApiRest.ParametersClient);
                        }
                        else
                        {
                            param = (ParametersClient)pParam;
                        }

                        //Guarda Datos
                        cravinsClientMgr.Update(param.ConsCliente, param.NumeroIdentificacion, param.TipoIdentificacion,
                            param.PrimerNombre, param.SegundoNombre,
                            param.PrimerApellido, param.SegundoApellido,
                            param.Email, param.DireccionResidencial, param.DireccionTrabajo,
                            param.TelefonoCelular, param.TelefonoFijo, param.Estado.ToString()
                            );
                        responseService.Code = Utilities.CONS_UNO.ToString();

                        responseService.Message = "Registro Actualizado.";
                    }
                    else
                    {
                        responseService.Code = Utilities.CONS_CERO.ToString();
                        responseService.Message = Utilities.PARAMETERS_JSON_NULS;
                    }
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return responseService;
            }
        }
        public ResponseService GetClient(string ConsClient)
        {
            #region Atributos
            ResponseService responseService = null;
            ArrayList result;
            #endregion

            responseService = new ResponseService();

            using (CravinsClientMgr cravinsClientMgr = new CravinsClientMgr())
            {
                try
                {
                    //Busca Datos
                    result = cravinsClientMgr.Find(ConsClient);
                    responseService.Data = result;
                    responseService.Code = Utilities.CONS_UNO.ToString();

                    responseService.Message = "Registros Recuperados. [" + result.Count + "]";
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return responseService;
            }
        }
        public ResponseService GetClient(string numIentificacion, string tipoIdentificacion)
        {
            #region Atributos
            ResponseService responseService = null;
            ArrayList result = null;
            #endregion

            responseService = new ResponseService();

            using (CravinsClientMgr cravinsClientMgr = new CravinsClientMgr())
            {
                try
                {
                    //Busca Datos
                    result = cravinsClientMgr.Find(numIentificacion.ToString(), tipoIdentificacion.ToString());
                    responseService.Data = result;
                    responseService.Code = Utilities.CONS_UNO.ToString();

                    responseService.Message = "Registros Recuperados. [" + result.Count + "]";
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return responseService;
            }
        }
        public ResponseService GetClients()
        {
            #region Atributos
            ResponseService responseService = null;
            ArrayList result=null;
            #endregion

            responseService = new ResponseService();

            using (CravinsClientMgr cravinsClientMgr = new CravinsClientMgr())
            {
                try
                {
                    //Guarda Datos
                    result = cravinsClientMgr.FindAll();
                    responseService.Data = result;
                    responseService.Code = Utilities.CONS_UNO.ToString();

                    responseService.Message = "Registros Recuperados. [" + result.Count + "]";
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return responseService;
            }
        }
        public ResponseService DeleteClient(int consCliente)
        {
            #region Atributos
            ResponseService responseService = null;
            #endregion

            responseService = new ResponseService();

            using (CravinsClientMgr cravinsClientMgr = new CravinsClientMgr())
            {
                try
                {
                    //Guarda Datos
                    cravinsClientMgr.Delete(consCliente.ToString());
                    responseService.Code = Utilities.CONS_UNO.ToString();

                    responseService.Message = "Registro Borrado.";
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }
                return responseService;
            }
        }
        #endregion

        #region Methods Product
        /// <summary>
        ///Copyright ©Antojitos - Colombia
        ///Metodo que se encarga de registrar Productos en la BD
        ///Autor		:	Alex Castillo Ortiz
        ///Fecha		:	01-Mayo-2022
        /// </summary>
        /// <returns>Retorna Objeto con listado respuesta.</returns>
        public ResponseService AddProduct(object pRequestJsonParam)
        {
            #region Atributos
            ResponseService responseService = null;
            ParametersProduct param = null;
            #endregion

            responseService = new ResponseService();
            using (CravinsProductMgr cravinsProductMgr = new CravinsProductMgr())
            {
                try
                {
                    if ((pRequestJsonParam != null && !string.IsNullOrEmpty(pRequestJsonParam.ToString())))
                    {
                        param = (ParametersProduct)DeserializeJsonGeneric(pRequestJsonParam.ToString(), TypeParametersApiRest.ParametersProduct);
                        //Guarda Datos
                        cravinsProductMgr.Add(param.Nombre, param.Descripcion,
                                                param.ValorUnitario, param.Estado);
                        responseService.Code = Utilities.CONS_UNO.ToString();

                        responseService.Message = "Registro Creado.";
                    }
                    else
                    {
                        responseService.Code = Utilities.CONS_CERO.ToString();
                        responseService.Message = Utilities.PARAMETERS_JSON_NULS;
                    }
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }
                return responseService;
            }
        }
        public ResponseService UpdateProduct(object pRequestJsonParam)
        {
            #region Atributos
            ResponseService responseService = null;
            ParametersProduct param = null;
            #endregion

            responseService = new ResponseService();
            using (CravinsProductMgr cravinsProductMgr = new CravinsProductMgr())
            {
                try
                {
                    if ((pRequestJsonParam != null && !string.IsNullOrEmpty(pRequestJsonParam.ToString())))
                    {
                        param = (ParametersProduct)DeserializeJsonGeneric(pRequestJsonParam.ToString(), TypeParametersApiRest.ParametersProduct);
                        //Guarda Datos
                        cravinsProductMgr.Update(param.ConsProducto, param.Nombre, param.Descripcion,
                                                param.ValorUnitario, param.Estado);
                        responseService.Code = Utilities.CONS_UNO.ToString();

                        responseService.Message = "Registro Guardado.";
                    }
                    else
                    {
                        responseService.Code = Utilities.CONS_CERO.ToString();
                        responseService.Message = Utilities.PARAMETERS_JSON_NULS;
                    }
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }
                return responseService;
            }
        }
        public ResponseService GetProduct(string ConsProduct)
        {
            #region Atributos
            ResponseService responseService = null;
            ArrayList result;
            #endregion

            responseService = new ResponseService();

            using (CravinsProductMgr cravinsProductMgr = new CravinsProductMgr())
            {
                try
                {
                    //Busca Datos
                    result = cravinsProductMgr.Find(ConsProduct);
                    responseService.Data = result;
                    responseService.Code = Utilities.CONS_UNO.ToString();

                    responseService.Message = "Registros Recuperados. [" + result.Count + "]";
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return responseService;
            }
        }
        public ResponseService GetProducts()
        {
            #region Atributos
            ResponseService responseService = null;
            ArrayList result = null;
            #endregion

            responseService = new ResponseService();

            using (CravinsProductMgr cravinsProductMgr = new CravinsProductMgr())
            {
                try
                {
                    //Guarda Datos
                    result = cravinsProductMgr.FindAll();
                    responseService.Data = result;
                    responseService.Code = Utilities.CONS_UNO.ToString();

                    responseService.Message = "Registros Recuperados. [" + result.Count + "]";
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return responseService;
            }
        }
        public ResponseService DeleteProduct(int consProducte)
        {
            #region Atributos
            ResponseService responseService = null;
            #endregion

            responseService = new ResponseService();

            using (CravinsProductMgr cravinsProductMgr = new CravinsProductMgr())
            {
                try
                {
                    //Guarda Datos
                    cravinsProductMgr.Delete(consProducte.ToString());
                    responseService.Code = Utilities.CONS_UNO.ToString();

                    responseService.Message = "Registro Borrado.";
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }
                return responseService;
            }
        }
        #endregion

        #region Methods Inventory
        /// <summary>
        ///Copyright ©Antojitos - Colombia
        ///Metodo que se encarga de registrar Inventorios en la BD
        ///Autor		:	Alex Castillo Ortiz
        ///Fecha		:	18-Mayo-2022
        /// </summary>
        /// <returns>Retorna Objeto con listado respuesta.</returns>
        public ResponseService AddInventory(object pRequestJsonParam)
        {
            #region Atributos
            ResponseService responseService = null;
            ParametersInventory param = null;
            #endregion

            responseService = new ResponseService();
            using (CravinsInventoryMgr cravinsInventoryMgr = new CravinsInventoryMgr())
            {
                try
                {
                    if ((pRequestJsonParam != null && !string.IsNullOrEmpty(pRequestJsonParam.ToString())))
                    {
                        param = (ParametersInventory)DeserializeJsonGeneric(pRequestJsonParam.ToString(), TypeParametersApiRest.ParametersInventory);
                        //Guarda Datos
                        cravinsInventoryMgr.Add(param.ConsProducto, param.Stock,param.Estado);
                        responseService.Code = Utilities.CONS_UNO.ToString();

                        responseService.Message = "Registro Creado.";
                    }
                    else
                    {
                        responseService.Code = Utilities.CONS_CERO.ToString();
                        responseService.Message = Utilities.PARAMETERS_JSON_NULS;
                    }
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }
                return responseService;
            }
        }
        public ResponseService UpdateInventory(object pRequestJsonParam)
        {
            #region Atributos
            ResponseService responseService = null;
            ParametersInventory param = null;
            #endregion

            responseService = new ResponseService();
            using (CravinsInventoryMgr cravinsInventoryMgr = new CravinsInventoryMgr())
            {
                try
                {
                    if ((pRequestJsonParam != null && !string.IsNullOrEmpty(pRequestJsonParam.ToString())))
                    {
                        param = (ParametersInventory)DeserializeJsonGeneric(pRequestJsonParam.ToString(), TypeParametersApiRest.ParametersInventory);
                        //Guarda Datos
                        cravinsInventoryMgr.Update(param.ConsInventario, param.ConsProducto, param.Stock, param.Estado);
                        responseService.Code = Utilities.CONS_UNO.ToString();

                        responseService.Message = "Registro Guardado.";
                    }
                    else
                    {
                        responseService.Code = Utilities.CONS_CERO.ToString();
                        responseService.Message = Utilities.PARAMETERS_JSON_NULS;
                    }
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }
                return responseService;
            }
        }
        public ResponseService GetInventory(string ConsInventory)
        {
            #region Atributos
            ResponseService responseService = null;
            ArrayList result;
            #endregion

            responseService = new ResponseService();

            using (CravinsInventoryMgr cravinsInventoryMgr = new CravinsInventoryMgr())
            {
                try
                {
                    //Busca Datos
                    result = cravinsInventoryMgr.Find(ConsInventory);
                    responseService.Data = result;
                    responseService.Code = Utilities.CONS_UNO.ToString();

                    responseService.Message = "Registros Recuperados. [" + result.Count + "]";
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return responseService;
            }
        }
        public ResponseService GetInventoryByProduct(string pConsProduct, string pState)
        {
            #region Atributos
            ResponseService responseService = null;
            ArrayList result;
            #endregion

            responseService = new ResponseService();

            using (CravinsInventoryMgr cravinsInventoryMgr = new CravinsInventoryMgr())
            {
                try
                {
                    //Busca Datos
                    result = cravinsInventoryMgr.FindByProduct(pConsProduct,pState);
                    responseService.Data = result;
                    responseService.Code = Utilities.CONS_UNO.ToString();

                    responseService.Message = "Registros Recuperados. [" + result.Count + "]";
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return responseService;
            }
        }
        public ResponseService GetInventories()
        {
            #region Atributos
            ResponseService responseService = null;
            ArrayList result = null;
            #endregion

            responseService = new ResponseService();

            using (CravinsInventoryMgr cravinsInventoryMgr = new CravinsInventoryMgr())
            {
                try
                {
                    //Guarda Datos
                    result = cravinsInventoryMgr.FindAll();
                    responseService.Data = result;
                    responseService.Code = Utilities.CONS_UNO.ToString();

                    responseService.Message = "Registros Recuperados. [" + result.Count + "]";
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return responseService;
            }
        }
        public ResponseService DeleteInventory(int consInventorye)
        {
            #region Atributos
            ResponseService responseService = null;
            #endregion

            responseService = new ResponseService();

            using (CravinsInventoryMgr cravinsInventoryMgr = new CravinsInventoryMgr())
            {
                try
                {
                    //Guarda Datos
                    cravinsInventoryMgr.Delete(consInventorye.ToString());
                    responseService.Code = Utilities.CONS_UNO.ToString();

                    responseService.Message = "Registro Borrado.";
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }
                return responseService;
            }
        }
        #endregion
        
        #region Methods Sale

        /// <summary>
        ///Copyright ©Antojitos - Colombia
        ///Metodo que se encarga de registrar Venats en la BD
        ///Autor		:	Alex Castillo Ortiz
        ///Fecha		:	17-Mayo-2022
        /// </summary>
        /// <param name="pRequestJsonParam">Objeto con parametros de entrada en formato Json.</param>
        /// <param name="pParam">Objeto con parametros de entrada en formato .Net.</param>
        /// <returns>Retorna Objeto con listado respuesta.</returns>
        public ResponseService AddSale(object pRequestJsonParam, object pParam = null)
        {
            #region Atributos
            ParametersSale param = null;
            ResponseService responseService = null;
            #endregion

            responseService = new ResponseService();

            using (CravinsSaleMgr cravinsSaleMgr = new CravinsSaleMgr())
            {
                try
                {
                    if ((pParam != null) || (pRequestJsonParam != null && !string.IsNullOrEmpty(pRequestJsonParam.ToString())))
                    {
                        if (pParam == null)
                        {
                            param = (ParametersSale)DeserializeJsonGeneric(pRequestJsonParam.ToString(), TypeParametersApiRest.ParametersSale);
                        }
                        else
                        {
                            param = (ParametersSale)pParam;
                        }
                        //Guarda Datos
                        cravinsSaleMgr.Add(param.ConsCliente,param.Estado);
                        responseService.Code = Utilities.CONS_UNO.ToString();

                        responseService.Message = "Registro Creado.";
                    }
                    else
                    {
                        responseService.Code = Utilities.CONS_CERO.ToString();
                        responseService.Message = Utilities.PARAMETERS_JSON_NULS;
                    }
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return responseService;
            }
        }
        /// <summary>
        ///Copyright ©Antojitos - Colombia
        ///Metodo que se encarga de actualizar en la BD datos Ventas
        ///Autor		:	Alex Castillo Ortiz
        ///Fecha		:	17-Mayo-2022
        /// </summary>
        /// <param name="pRequestJsonParam">Objeto con parametros de entrada en formato Json.</param>
        /// <param name="pParam">Objeto con parametros de entrada en formato .Net.</param>
        /// <returns>Retorna Objeto con listado respuesta.</returns>
        public ResponseService UpdateSale(object pRequestJsonParam, object pParam = null)
        {
            #region Atributos
            ParametersSale param = null;
            ResponseService responseService = null;
            #endregion

            responseService = new ResponseService();

            using (CravinsSaleMgr cravinsSaleMgr = new CravinsSaleMgr())
            {
                try
                {
                    if ((pParam != null) || (pRequestJsonParam != null && !string.IsNullOrEmpty(pRequestJsonParam.ToString())))
                    {
                        if (pParam == null)
                        {
                            param = (ParametersSale)DeserializeJsonGeneric(pRequestJsonParam.ToString(), TypeParametersApiRest.ParametersSale);
                        }
                        else
                        {
                            param = (ParametersSale)pParam;
                        }
                        //Guarda Datos
                        cravinsSaleMgr.Update(param.ConsVenta, param.ConsCliente, param.Estado);
                        responseService.Code = Utilities.CONS_UNO.ToString();

                        responseService.Message = "Registro Actualizado.";
                    }
                    else
                    {
                        responseService.Code = Utilities.CONS_CERO.ToString();
                        responseService.Message = Utilities.PARAMETERS_JSON_NULS;
                    }
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return responseService;
            }
        }
        public ResponseService GetSale(string ConsSale)
        {
            #region Atributos
            ResponseService responseService = null;
            ArrayList result=null;
            #endregion

            responseService = new ResponseService();

            using (CravinsSaleMgr cravinsSaleMgr = new CravinsSaleMgr())
            {
                try
                {
                    //Busca Datos
                    result = cravinsSaleMgr.Find(ConsSale);
                    responseService.Data = result;
                    responseService.Code = Utilities.CONS_UNO.ToString();

                    responseService.Message = "Registros Recuperados. [" + result.Count + "]";
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return responseService;
            }
        }
        public ResponseService GetSales()
        {
            #region Atributos
            ResponseService responseService = null;
            ArrayList result = null;
            #endregion

            responseService = new ResponseService();

            using (CravinsSaleMgr cravinsSaleMgr = new CravinsSaleMgr())
            {
                try
                {
                    //Guarda Datos
                    result = cravinsSaleMgr.FindAll();
                    responseService.Data = result;
                    responseService.Code = Utilities.CONS_UNO.ToString();

                    responseService.Message = "Registros Recuperados. [" + result.Count + "]";
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return responseService;
            }
        }
        public ResponseService DeleteSale(int consSalee)
        {
            #region Atributos
            ResponseService responseService = null;
            #endregion

            responseService = new ResponseService();

            using (CravinsSaleMgr cravinsSaleMgr = new CravinsSaleMgr())
            {
                try
                {
                    //Guarda Datos
                    cravinsSaleMgr.Delete(consSalee.ToString());
                    responseService.Code = Utilities.CONS_UNO.ToString();

                    responseService.Message = "Registro Borrado.";
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }
                return responseService;
            }
        }
        #endregion

        #region Methods Fetail Sale

        /// <summary>
        ///Copyright ©Antojitos - Colombia
        ///Metodo que se encarga de registrar Detalle Venatas en la BD
        ///Autor		:	Alex Castillo Ortiz
        ///Fecha		:	19-Mayo-2022
        /// </summary>
        /// <param name="pRequestJsonParam">Objeto con parametros de entrada en formato Json.</param>
        /// <param name="pParam">Objeto con parametros de entrada en formato .Net.</param>
        /// <returns>Retorna Objeto con listado respuesta.</returns>
        public ResponseService AddDetailSale(object pRequestJsonParam)
        {
            #region Atributos
            ParametersDetailSale param = null;
            ResponseService responseService = null;
            #endregion

            responseService = new ResponseService();

            using (CravinsDetailSaleMgr cravinsDetailSaleMgr = new CravinsDetailSaleMgr())
            {
                try
                {
                    if ((pRequestJsonParam != null && !string.IsNullOrEmpty(pRequestJsonParam.ToString())))
                    {
                        param = (ParametersDetailSale)DeserializeJsonGeneric(pRequestJsonParam.ToString(), TypeParametersApiRest.ParametersDetailSale);
                        //Guarda Datos
                        cravinsDetailSaleMgr.Add(param.ConsVenta, param.ConsProducto,param.Cantidad,param.ValorUnitario,param.Iva, param.Estado);
                        responseService.Code = Utilities.CONS_UNO.ToString();

                        responseService.Message = "Registro Creado.";
                    }
                    else
                    {
                        responseService.Code = Utilities.CONS_CERO.ToString();
                        responseService.Message = Utilities.PARAMETERS_JSON_NULS;
                    }
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return responseService;
            }
        }
        /// <summary>
        ///Copyright ©Antojitos - Colombia
        ///Metodo que se encarga de actualizar en la BD datos Detalle Ventas
        ///Autor		:	Alex Castillo Ortiz
        ///Fecha		:	19-Mayo-2022
        /// </summary>
        /// <param name="pRequestJsonParam">Objeto con parametros de entrada en formato Json.</param>
        /// <param name="pParam">Objeto con parametros de entrada en formato .Net.</param>
        /// <returns>Retorna Objeto con listado respuesta.</returns>
        public ResponseService UpdateDetailSale(object pRequestJsonParam)
        {
            #region Atributos
            ParametersDetailSale param = null;
            ResponseService responseService = null;
            #endregion

            responseService = new ResponseService();

            using (CravinsDetailSaleMgr cravinsDetailSaleMgr = new CravinsDetailSaleMgr())
            {
                try
                {
                    if ((pRequestJsonParam != null && !string.IsNullOrEmpty(pRequestJsonParam.ToString())))
                    {
                        param = (ParametersDetailSale)DeserializeJsonGeneric(pRequestJsonParam.ToString(), TypeParametersApiRest.ParametersDetailSale);
                        //Guarda Datos
                        cravinsDetailSaleMgr.Update(param.ConsVenta, param.ConsProducto, param.Cantidad, param.ValorUnitario, param.Iva, param.Estado);
                        responseService.Code = Utilities.CONS_UNO.ToString();

                        responseService.Message = "Registro Actualizado.";
                    }
                    else
                    {
                        responseService.Code = Utilities.CONS_CERO.ToString();
                        responseService.Message = Utilities.PARAMETERS_JSON_NULS;
                    }
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return responseService;
            }
        }
        public ResponseService GetDetailSaleProduct(string ConsVenta, string consProducto)
        {
            #region Atributos
            ResponseService responseService = null;
            ArrayList result = null;
            #endregion

            responseService = new ResponseService();

            using (CravinsDetailSaleMgr cravinsDetailSaleMgr = new CravinsDetailSaleMgr())
            {
                try
                {
                    //Busca Datos
                    result = cravinsDetailSaleMgr.Find(ConsVenta, consProducto);
                    responseService.Data = result;
                    responseService.Code = Utilities.CONS_UNO.ToString();

                    responseService.Message = "Registros Recuperados. [" + result.Count + "]";
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return responseService;
            }
        }
        public ResponseService GetDetailSale(string ConsVenta)
        {
            #region Atributos
            ResponseService responseService = null;
            ArrayList result = null;
            #endregion

            responseService = new ResponseService();

            using (CravinsDetailSaleMgr cravinsDetailSaleMgr = new CravinsDetailSaleMgr())
            {
                try
                {
                    //Busca Datos
                    result = cravinsDetailSaleMgr.Find(ConsVenta);
                    responseService.Data = result;
                    responseService.Code = Utilities.CONS_UNO.ToString();

                    responseService.Message = "Registros Recuperados. [" + result.Count + "]";
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return responseService;
            }
        }
        public ResponseService GetDetailSales()
        {
            #region Atributos
            ResponseService responseService = null;
            ArrayList result = null;
            #endregion

            responseService = new ResponseService();

            using (CravinsDetailSaleMgr cravinsDetailSaleMgr = new CravinsDetailSaleMgr())
            {
                try
                {
                    //Guarda Datos
                    result = cravinsDetailSaleMgr.FindAll();
                    responseService.Data = result;
                    responseService.Code = Utilities.CONS_UNO.ToString();

                    responseService.Message = "Registros Recuperados. [" + result.Count + "]";
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return responseService;
            }
        }
        public ResponseService DeleteDetailSale(string ConsVenta, string consProducto)
        {
            #region Atributos
            ResponseService responseService = null;
            #endregion

            responseService = new ResponseService();

            using (CravinsDetailSaleMgr cravinsDetailSaleMgr = new CravinsDetailSaleMgr())
            {
                try
                {
                    //Guarda Datos
                    cravinsDetailSaleMgr.Delete(ConsVenta.ToString(), consProducto);
                    responseService.Code = Utilities.CONS_UNO.ToString();

                    responseService.Message = "Registro Borrado.";
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }
                return responseService;
            }
        }
        public ResponseService DeleteDetailSale(int ConsVenta)
        {
            #region Atributos
            ResponseService responseService = null;
            #endregion

            responseService = new ResponseService();

            using (CravinsDetailSaleMgr cravinsDetailSaleMgr = new CravinsDetailSaleMgr())
            {
                try
                {
                    //Guarda Datos
                    cravinsDetailSaleMgr.Delete(ConsVenta);
                    responseService.Code = Utilities.CONS_UNO.ToString();

                    responseService.Message = "Registro Borrado.";
                }
                catch (Exception ex)
                {
                    responseService.Code = Utilities.CONS_CERO.ToString();
                    responseService.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }
                return responseService;
            }
        }
        #endregion

        #region Methods Json
        /// <summary>
        ///Copyright ©Antojitos - Colombia
        ///Metodo que se encarga desserializar Objeto JSon, cargandolo en un ObjetoModel
        ///Autor		:	Alex Castillo Ortiz
        ///Fecha		:	29-Abril-2022
        /// </summary>
        /// <param name="requestJsonParam">Objeto con parametros de entrada en formato Json.</param>
        /// <param name="pTypeParameters">ObjetoModel en el que se cargará objeto Json</param>
        /// <returns>Retorna Tipo ObjetoModel con información del objeto json</returns>
        private object DeserializeJsonGeneric(string requestJsonParam, TypeParametersApiRest pTypeParameters)
        {
            object objParameters = null;
            switch (pTypeParameters)
            {
                case TypeParametersApiRest.ParametersProduct:
                    {
                        objParameters = JsonSerializer.Deserialize<ParametersProduct>(requestJsonParam);
                        break;
                    }
                case TypeParametersApiRest.ParametersInventory:
                    {
                        objParameters = JsonSerializer.Deserialize<ParametersInventory>(requestJsonParam);
                        break;
                    }
                case TypeParametersApiRest.ParametersClient:
                    {
                        objParameters = JsonSerializer.Deserialize<ParametersClient>(requestJsonParam);
                        break;
                    }
                case TypeParametersApiRest.ParametersSale:
                    {
                        objParameters = JsonSerializer.Deserialize<ParametersSale>(requestJsonParam);
                        break;
                    }
                case TypeParametersApiRest.ParametersDetailSale:
                    {
                        objParameters = JsonSerializer.Deserialize<ParametersDetailSale>(requestJsonParam);
                        break;
                    }
                default:
                    {
                        throw new Exception($"El Parámetro {pTypeParameters} aún no ha sido implementado.");
                    }

            }
            ValParametersJsonFile(requestJsonParam, objParameters);

            return objParameters;
        }
        /// <summary>
        ///Copyright ©Antojitos - Colombia
        ///Metodo que se encarga desserializar Objeto JSon, cargandolo en un ObjetoModel
        ///Autor		:	Alex Castillo Ortiz
        ///Fecha		:	29-Abril-2022
        /// </summary>
        /// <param name="requestJsonParam">Objeto con parametros de entrada en formato Json.</param>
        /// <param name="objParameters">Typo ObjetoModel en el que se cargará objeto Json</param>
        /// <returns>Retorna Objeto con listado respuesta.</returns>
        private void ValParametersJsonFile(string requestJsonParam, object objParameters)
        {
            MemberInfo[] members = null;
            string msgError = "";
            try
            {
                if (string.IsNullOrEmpty(requestJsonParam) || objParameters == null)
                {
                    throw new Exception("Parámetros enviados No válidos.");
                }
                members = objParameters.GetType().GetMembers();
                object CustomAttribute = objParameters.GetType().GetCustomAttributes();
                object propertyInfo = objParameters.GetType().GetRuntimeProperties();
                foreach (MemberInfo regMember in members)
                {
                    if (regMember.MemberType.ToString().ToUpper() == "PROPERTY" ||
                        regMember.MemberType.ToString().ToUpper() == "PROPIEDAD")
                    {
                        if (!requestJsonParam.Contains("\"" + regMember.Name + "\""))
                        {
                            msgError = $"Parámetros enviados No válidos.  Se espera parámetro [{regMember.Name}]";
                            throw new Exception(msgError);
                        }
                    }
                }
            }
            finally
            {
                members = null;
            }
        }
        public static object SerializeJson(object pObject)
        {
            string jsonString;
            jsonString = JsonSerializer.Serialize(pObject);
            return jsonString;
        }
        #endregion

        #region Validate Cors
        public void GetCorsPolicyAsync(HttpRequestMessage request)
        {
            using (AccessPolicyCors accessPolicyCors = new AccessPolicyCors())
            {
                CancellationToken cancellationToken = new CancellationToken(true);
                accessPolicyCors. GetCorsPolicyAsync(request, cancellationToken);
            }
        }
        #endregion
    }
}
