using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Coomeva.Common;
using Cravings.DataAccess;
using Cravings.BusinessLogic.Model;
using System.Linq;

namespace Cravings.BusinessLogic.Manager
{
    /// <summary>
    ///Copyright ©Antojitos - Colombia
    ///Clase Utilizada para cargar Manejar tabla Detalle Venta
    ///Autor		:	Alex Castillo Ortiz
    ///Fecha		:	03-Mayo-2022
    /// </summary>
    public class CravinsDetailSaleMgr : IDisposable
    {
        public CravinsDetailSaleMgr()
        {
        }
        public void Dispose()
        { }
        public void Add(string consSale, string consProduct, string amount, string unitValue, string iva, string state)
        {
            AntoDetalleVentum antoDetalleVentum = null;
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos
                using (Validator validator = new Validator())
                {
                    validator.Add("Id Venta", consSale, ValType.REQ, ValType.INTPOS);
                    validator.Add("Id Producto", consProduct, ValType.REQ, ValType.INTPOS);
                    validator.Add("Id Cantidad", amount, ValType.REQ, ValType.INTPOS);
                    validator.Add("Id Valor Unitario", unitValue, ValType.REQ, ValType.INTPOS);
                    validator.Add("Iva", iva, ValType.INTPOS);
                    validator.Add("Estado", state, ValType.REQ, ValType.INTPOS);
                    validator.Validate();
                }
                #endregion

                #region Cargar Objeto
                antoDetalleVentum = new AntoDetalleVentum();
                antoDetalleVentum.ConsVenta = int.Parse(consSale);
                antoDetalleVentum.ConsProducto = int.Parse(consProduct);
                antoDetalleVentum.Cantidad = int.Parse(amount);
                antoDetalleVentum.ValorUnitario = int.Parse(unitValue);
                antoDetalleVentum.Iva = int.Parse(iva);
                antoDetalleVentum.Estado = Int32.Parse(state);
                #endregion

                cravingsDbContext.AntoDetalleVenta.Add(antoDetalleVentum);
                cravingsDbContext.SaveChanges();
            }
        }
        public void Update(string consSale, string consProduct, string amount, string unitValue, string iva, string state)
        {
            AntoDetalleVentum antoDetalleVentum = null;
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos
                using (Validator validator = new Validator())
                {
                    validator.Add("Id Venta", consSale, ValType.REQ, ValType.INTPOS);
                    validator.Add("Id Producto", consProduct, ValType.REQ, ValType.INTPOS);
                    validator.Add("Id Cantidad", amount, ValType.REQ, ValType.INTPOS);
                    validator.Add("Id Valor Unitario", unitValue, ValType.REQ, ValType.INTPOS);
                    validator.Add("Iva", iva, ValType.INTPOS);
                    validator.Add("Estado", state, ValType.REQ, ValType.INTPOS);
                    validator.Validate();
                }
                #endregion

                #region Cargar Objeto
                antoDetalleVentum = new AntoDetalleVentum();
                antoDetalleVentum.ConsVenta = int.Parse(consSale);
                antoDetalleVentum.ConsProducto = int.Parse(consProduct);
                antoDetalleVentum.Cantidad = int.Parse(amount);
                antoDetalleVentum.ValorUnitario = int.Parse(unitValue);
                antoDetalleVentum.Iva = int.Parse(iva);
                antoDetalleVentum.Estado = Int32.Parse(state);
                #endregion

                cravingsDbContext.AntoDetalleVenta.Update(antoDetalleVentum);
                cravingsDbContext.SaveChanges();
            }
        }
        public ArrayList Find(string consSale, string consProduct)
        {
            List<AntoDetalleVentum> detailSale;
            AntoDetalleVentum antoDetalleVentum = null;
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos
                using (Validator validator = new Validator())
                {
                    validator.Add("Id Venta", consSale, ValType.REQ, ValType.INTPOS);
                    validator.Add("Id Producto", consProduct, ValType.REQ, ValType.INTPOS);
                    validator.Validate();
                }
                #endregion

                #region Cargar Objeto
                antoDetalleVentum = new AntoDetalleVentum();
                antoDetalleVentum.ConsVenta = int.Parse(consSale);
                antoDetalleVentum.ConsProducto = int.Parse(consProduct);
                #endregion

                
                detailSale = cravingsDbContext.AntoDetalleVenta.Where(p => p.ConsVenta == int.Parse(consSale)
                                                && p.ConsProducto == int.Parse(consProduct)).ToList();

                return PutDetalleVenta(detailSale);
            }
        }
        public ArrayList Find(string consSale)
        {
            List<AntoDetalleVentum> detailSale;
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos
                using (Validator validator = new Validator())
                {
                    validator.Add("Id Venta", consSale, ValType.REQ, ValType.INTPOS);
                    validator.Validate();
                }
                #endregion

                detailSale = cravingsDbContext.AntoDetalleVenta.Where(p => p.ConsVenta == int.Parse(consSale)).ToList();

                return PutDetalleVenta(detailSale);
            }
        }
        public ArrayList FindAll()
        {
            Task<List<AntoDetalleVentum>> listResult = null;
            ArrayList detaiSales = null;

            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                listResult = cravingsDbContext.AntoDetalleVenta.ToListAsync();
                detaiSales = new ArrayList();
                if (listResult! != null)
                {
                    foreach (AntoDetalleVentum regAntoVentum in listResult.Result)
                    {
                        return PutDetalleVenta(listResult.Result);
                    }
                }
                return detaiSales;
            }
        }
        public void Delete(string consSale, string consProduct)
        {
            ValueTask<AntoDetalleVentum> detalleVenta;
            ArrayList arrayDetalleVenta = null;
            throw new Exception("En Contruccion");
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos
                using (Validator validator = new Validator())
                {
                    validator.Add("Id Venta", consSale, ValType.REQ, ValType.INTPOS);
                    validator.Add("Id Producto", consProduct, ValType.REQ, ValType.INTPOS);
                    validator.Validate();
                }
                #endregion

                #region Cargar Objeto
                //arrayDetalleVenta = Find(pConsClient);
                //cravingsDbContext.Remove(,);
                //detalleVenta = (ValueTask<AntoDetalleVentum>)arrayDetalleVenta[0];
                #endregion
            }
        }
        public ArrayList PutDetalleVenta(List<AntoDetalleVentum> listResult)
        {
            ArrayList detailSales = null;
            SaleDetailModel detailSaleModel = null;

            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                detailSales = new ArrayList();
                if (listResult! != null)
                {
                    foreach (AntoDetalleVentum regAntoDetalleVentum in listResult)
                    {
                        #region Cargar Objeto
                        detailSaleModel = new SaleDetailModel();
                        detailSaleModel.ConsSale = regAntoDetalleVentum.ConsVenta;
                        detailSaleModel.ConsProduct = regAntoDetalleVentum.ConsProducto;
                        detailSaleModel.Amount = regAntoDetalleVentum.Cantidad;
                        detailSaleModel.UnitValue = regAntoDetalleVentum.ValorUnitario;
                        detailSaleModel.State = regAntoDetalleVentum.Estado;

                        detailSaleModel.DateRegister = regAntoDetalleVentum.FechaRegistro;
                        detailSales.Add(detailSaleModel);

                        #endregion
                    }
                }
                return detailSales;
            }
        }

        public void Delete(int consVenta)
        {
            throw new NotImplementedException();
        }
    }
}