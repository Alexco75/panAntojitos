using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Coomeva.Common;
using Cravings.DataAccess;
using Cravings.BusinessLogic.Model;
using System.Linq;
using Cravings.Common;

namespace Cravings.BusinessLogic.Manager
{
    /// <summary>
    ///Copyright ©Antojitos - Colombia
    ///Clase Utilizada para cargar Manejar tabla INventario
    ///Autor		:	Alex Castillo Ortiz
    ///Fecha		:	03-Mayo-2022
    /// </summary>
    public class CravinsInventoryMgr : IDisposable
    {
        public CravinsInventoryMgr()
        {
        }
        public void Dispose()
        { }
        public void Add(string consProduct, string stock, string state)
        {
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos
                using (Validator validator = new Validator())
                {
                    validator.Add("Id Producto", consProduct, ValType.REQ, ValType.INTPOS);
                    validator.Add("stock", stock, ValType.REQ, ValType.INTPOS);
                    validator.Add("Estado", state, ValType.REQ, ValType.INTPOS);
                    validator.Validate();
                }
                #endregion

                #region Cargar Objeto
                AntoInventario antoInventario = new AntoInventario();
                antoInventario.ConsProducto = int.Parse(consProduct);
                antoInventario.Stock = int.Parse(stock);
                antoInventario.Estado = Int32.Parse(state);
                #endregion

                cravingsDbContext.AntoInventarios.Add(antoInventario);
                cravingsDbContext.SaveChanges();

            }
        }
        public void Update(string consInventory, string consProduct, string stock, string state)
        {
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos
                using (Validator validator = new Validator())
                {
                    validator.Add("Id Inventario", consInventory, ValType.REQ, ValType.INTPOS);
                    validator.Add("Id Producto", consProduct, ValType.REQ, ValType.INTPOS);
                    validator.Add("stock", stock, ValType.REQ, ValType.INTPOS);
                    validator.Add("Estado", state, ValType.REQ, ValType.INTPOS);
                    validator.Validate();
                }
                #endregion

                #region Cargar Objeto
                AntoInventario antoInventario = new AntoInventario();
                antoInventario.ConsInventario = int.Parse(consInventory);
                antoInventario.ConsProducto = int.Parse(consProduct);
                antoInventario.Stock = int.Parse(stock);
                antoInventario.Estado = Int32.Parse(state);
                #endregion

                cravingsDbContext.AntoInventarios.Update(antoInventario);
                cravingsDbContext.SaveChanges();
            }
        }
        public ArrayList Find(string consInventory)
        {
            List<AntoInventario> listInventory;
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos
                using (Validator validator = new Validator())
                {
                    validator.Add("Id Inventario", consInventory, ValType.REQ, ValType.INTPOS);
                    validator.Validate();
                }
                #endregion


                listInventory = cravingsDbContext.AntoInventarios.Where(p => p.ConsInventario == int.Parse(consInventory)).ToList();

                return PutInventario(listInventory);
            }
        }
        public ArrayList FindByProduct(string consProducto, string estado)
        {
            List<AntoInventario> listInventory;
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos
                using (Validator validator = new Validator())
                {
                    validator.Add("Id Producto", consProducto, ValType.REQ, ValType.INTPOS);

                    estado = string.IsNullOrEmpty(estado) ? Utilities.CONS_CERO.ToString() : estado;
                    validator.Add("estado Inventario", estado, ValType.INTPOS);
                    validator.Validate();
                }
                #endregion

                if (int.Parse(estado) == Utilities.CONS_CERO)
                {
                    listInventory = cravingsDbContext.AntoInventarios.Where(p => p.ConsProducto == int.Parse(consProducto)).ToList();
                }
                else
                {
                    listInventory = cravingsDbContext.AntoInventarios.Where(p => p.ConsProducto == int.Parse(consProducto)
                                                                                && p.Estado == int.Parse(estado)).ToList();
                }

                return PutInventario(listInventory);
            }
        }
        public ArrayList FindAll()
        {
            Task<List<AntoInventario>> listResult = null;
            ArrayList inventory = null;
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                listResult = cravingsDbContext.AntoInventarios.ToListAsync();
                inventory = new ArrayList();
                if (listResult! != null)
                {
                    return PutInventario(listResult.Result);
                }
                return inventory;
            }
        }
        public void Delete(string consInventory)
        {
            ValueTask<AntoInventario> inventory;
            ArrayList arrayInventory = null;
            throw new Exception("En Contruccion");
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos

                using (Validator validator = new Validator())
                {
                    validator.Add("Id Inventario", consInventory, ValType.INTPOS);
                    validator.Validate();
                }
                #endregion

                #region Cargar Objeto
                //arrayProducte = Find(pConsProduct);
                //cravingsDbContext.Remove(,);
                //inventory = (ValueTask<AntoProducte>)arrayInventory[0];
                #endregion
            }
        }
        public ArrayList PutInventario(List<AntoInventario> listResult)
        {
            ArrayList inventory = null;
            InventoryModel inventoryModel = null;

            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                inventory = new ArrayList();
                if (listResult! != null)
                {
                    foreach (AntoInventario regAntoInventario in listResult)
                    {
                        #region Cargar Objeto
                        inventoryModel = new InventoryModel();
                        inventoryModel.ConsInventario = regAntoInventario.ConsInventario;
                        inventoryModel.ConsProducto = regAntoInventario.ConsProducto;
                        inventoryModel.Stock = regAntoInventario.Stock;
                        inventoryModel.Estado = regAntoInventario.Estado;
                        inventoryModel.FechaRegistro = regAntoInventario.FechaRegistro;
                        inventory.Add(inventoryModel);

                        #endregion
                    }
                }
                return inventory;
            }
        }
    }
}