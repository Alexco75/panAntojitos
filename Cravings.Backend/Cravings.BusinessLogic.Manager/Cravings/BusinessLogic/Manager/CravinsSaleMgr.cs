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
    ///Clase Utilizada para cargar Manejar tabla Venta
    ///Autor		:	Alex Castillo Ortiz
    ///Fecha		:	17-Mayo-2022
    /// </summary>
    public class CravinsSaleMgr : IDisposable
    {
        public CravinsSaleMgr()
        {
        }
        public void Dispose()
        { }
        public void Add(string consClient, string state)
        {
            AntoVentum antoSale = null;
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos
                using (Validator validator = new Validator())
                {
                    validator.Add("Id Cliente", consClient, ValType.REQ, ValType.INTPOS);
                    validator.Add("Estado", state, ValType.REQ, ValType.INTPOS);
                    validator.Validate();
                }
                #endregion

                #region Cargar Objeto
                antoSale = new AntoVentum();
                antoSale.ConsCliente = int.Parse(consClient);
                antoSale.Estado = Int32.Parse(state);
                #endregion

                cravingsDbContext.AntoVenta.Add(antoSale);
                cravingsDbContext.SaveChanges();

            }
        }
        public void Update(string consSale, string consClient, string state)
        {
            AntoVentum antoVenta = null;
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos
                using (Validator validator = new Validator())
                {
                    validator.Add("Id Venta", consSale, ValType.REQ, ValType.INTPOS);
                    validator.Add("Id Cliente", consClient, ValType.REQ, ValType.INTPOS);
                    validator.Add("Estado", state, ValType.REQ, ValType.INTPOS);
                    validator.Validate();
                }
                #endregion

                #region Cargar Objeto
                antoVenta = new AntoVentum();
                antoVenta.ConsVenta = int.Parse(consSale);
                antoVenta.ConsCliente = int.Parse(consClient);
                antoVenta.Estado = Int32.Parse(state);
                #endregion

                cravingsDbContext.AntoVenta.Update(antoVenta);
                cravingsDbContext.SaveChanges();

            }
        }
        public ArrayList Find(string consSale)
        {
            List<AntoVentum> listVentas;

            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos
                using (Validator validator = new Validator())
                {
                    validator.Add("Id Venta", consSale, ValType.REQ, ValType.INTPOS);
                    validator.Validate();
                }
                #endregion

                listVentas = cravingsDbContext.AntoVenta.Where(p => p.ConsVenta == int.Parse(consSale)).ToList();
                return PutVentas(listVentas);
            }
        }
        public ArrayList Find(string consClient, string state)
        {
            List<AntoVentum> listVentas;
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos
                using (Validator validator = new Validator())
                {
                    validator.Add("Id Cliente", consClient, ValType.REQ, ValType.INTPOS);
                    validator.Add("Estado", state, ValType.REQ, ValType.INTPOS);
                    validator.Validate();
                }
                #endregion
                listVentas = cravingsDbContext.AntoVenta.Where(p => p.ConsCliente == int.Parse(consClient) 
                                                                &&  p.Estado == int.Parse(state)).ToList();
                return PutVentas(listVentas);
            }
        }
        public ArrayList FindAll()
        {
            Task<List<AntoVentum>> listResult = null;
            ArrayList sales = null;
            SaleModel saleModel = null;

            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                listResult = cravingsDbContext.AntoVenta.ToListAsync();
                sales = new ArrayList();
                if (listResult! != null)
                {
                    return PutVentas(listResult.Result);
                }
                return sales;
            }
        }
        public void Delete(string pConsVenta)
        {
            ValueTask<AntoCliente> cliente;
            ArrayList arrayCliente = null;
            throw new Exception("En Contruccion");
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos

                using (Validator validator = new Validator())
                {
                    validator.Add("Id Venta", pConsVenta, ValType.INTPOS);
                    validator.Validate();
                }
                #endregion

                #region Cargar Objeto
                //arrayCliente = Find(pConsClient);
                //cravingsDbContext.Remove(,);
                //cliente = (ValueTask<AntoCliente>)arrayCliente[0];
                #endregion
            }
        }
        private ArrayList PutVentas(List<AntoVentum> listVentas)
        {
            ArrayList sales = null;
            SaleModel saleModel = null;

            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                sales = new ArrayList();
                if (listVentas! != null)
                {
                    foreach (AntoVentum regAntoVentum in listVentas)
                    {
                        #region Cargar Objeto
                        saleModel = new SaleModel();
                        saleModel.ConsSale = regAntoVentum.ConsVenta;
                        saleModel.ConsClient = regAntoVentum.ConsCliente;
                        saleModel.State = regAntoVentum.Estado;
                        saleModel.DateRegister = regAntoVentum.FechaRegistro;
                        sales.Add(saleModel);

                        #endregion
                    }
                }
                return sales;
            }
        }
    }
}