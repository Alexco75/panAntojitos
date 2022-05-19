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
    ///Clase Utilizada para cargar Manejar tabla Productos
    ///Autor		:	Alex Castillo Ortiz
    ///Fecha		:	01-Mayo-2022
    /// </summary>
    public class CravinsProductMgr : IDisposable
    {
        public CravinsProductMgr()
        {
        }
        public void Dispose()
        { }
        public void Add(string name, string description, string unitValue, string state)

        {
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos
                using (Validator validator = new Validator())
                {
                    validator.Add("Nombre", name, ValType.REQ, ValType.ALPHA);
                    validator.Add("Descripción", description, ValType.ALPHA);
                    validator.Add("Valor Unitario", unitValue, ValType.REQ, ValType.INTPOS);
                    validator.Add("Estado", state, ValType.REQ, ValType.INTPOS);
                    validator.Validate();
                }
                #endregion

                #region Cargar Objeto
                AntoProducto antoProducto = new AntoProducto();
                antoProducto.Nombre = name;
                antoProducto.Descripcion = description;
                antoProducto.ValorUnidad = decimal.Parse(unitValue);
                antoProducto.Estado = Int32.Parse(state);
                #endregion

                cravingsDbContext.AntoProductos.Add(antoProducto);
                cravingsDbContext.SaveChanges();

            }
        }
        public void Update(string consProduct, string name, string description, string unitValue, string state)

        {
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos
                using (Validator validator = new Validator())
                {
                    validator.Add("Id Producto", consProduct, ValType.REQ, ValType.INTPOS);
                    validator.Add("Nombre", name, ValType.REQ, ValType.ALPHA);
                    validator.Add("Descripción", description, ValType.ALPHA);
                    validator.Add("Valor Unitario", unitValue, ValType.REQ, ValType.INTPOS);
                    validator.Add("Estado", state, ValType.REQ, ValType.INTPOS);
                    validator.Validate();
                }
                #endregion

                #region Cargar Objeto
                AntoProducto antoProducto = new AntoProducto();
                antoProducto.ConsProducto = int.Parse(consProduct);
                antoProducto.Nombre = name;
                antoProducto.Descripcion = description;
                antoProducto.ValorUnidad = decimal.Parse(unitValue);
                antoProducto.Estado = Int32.Parse(state);
                #endregion

                cravingsDbContext.AntoProductos.Update(antoProducto);
                cravingsDbContext.SaveChanges();

            }
        }
        public ArrayList Find(string pConsProduct)
        {
            List<AntoProducto> listProduct;
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos

                using (Validator validator = new Validator())
                {
                    validator.Add("Id Producto", pConsProduct, ValType.INTPOS, ValType.REQ);
                    validator.Validate();
                }
                #endregion

                listProduct = cravingsDbContext.AntoProductos.Where(p => p.ConsProducto == int.Parse(pConsProduct)).ToList();

                return PutProducto(listProduct);
            }
        }
        public ArrayList FindAll()
        {
            Task<List<AntoProducto>> listResult = null;
            ArrayList products = null;

            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                listResult = cravingsDbContext.AntoProductos.ToListAsync();
                products = new ArrayList();
                if (listResult! != null)
                {
                    return PutProducto(listResult.Result);
                }
                return products;
            }
        }
        public void Delete(string pConsProduct)
        {
            ValueTask<AntoProducto> product;
            ArrayList arrayProduct = null;
            throw new Exception("En Contruccion");
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos

                using (Validator validator = new Validator())
                {
                    validator.Add("Id Producto", pConsProduct, ValType.INTPOS);
                    validator.Validate();
                }
                #endregion

                #region Cargar Objeto
                //arrayProducte = Find(pConsProduct);
                //cravingsDbContext.Remove(,);
                //product = (ValueTask<AntoProducte>)arrayProduct[0];
                #endregion
            }
        }
        public ArrayList PutProducto(List<AntoProducto> listResult)
        {
            ArrayList products = null;
            ProdutModel produtModel = null;

            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                products = new ArrayList();
                if (listResult! != null)
                {
                    foreach (AntoProducto regAntoProduct in listResult)
                    {
                        #region Cargar Objeto
                        produtModel = new ProdutModel();
                        produtModel.ConsProduct = regAntoProduct.ConsProducto;
                        produtModel.Name = regAntoProduct.Nombre;
                        produtModel.Description = regAntoProduct.Descripcion;
                        produtModel.UnitValue = regAntoProduct.ValorUnidad;
                        produtModel.State = regAntoProduct.Estado;
                        produtModel.DateRegister = regAntoProduct.FechaRegistro;
                        products.Add(produtModel);
                        #endregion
                    }
                }
                return products;
            }
        }
    }
}