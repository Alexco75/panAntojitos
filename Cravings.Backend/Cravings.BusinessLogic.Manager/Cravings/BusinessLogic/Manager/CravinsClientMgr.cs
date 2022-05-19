using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Coomeva.Common;
using Cravings.DataAccess;
using Cravings.BusinessLogic.Model;
using Cravings.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace Cravings.BusinessLogic.Manager
{
    /// <summary>
    ///Copyright ©Antojitos - Colombia
    ///Clase Utilizada para cargar Manejar tabla CLientes
    ///Autor		:	Alex Castillo Ortiz
    ///Fecha		:	28-Mayo-2022
    /// </summary>
    public class CravinsClientMgr : IDisposable
    {
        public CravinsClientMgr()
        {
        }
        public void Dispose()
        { }

        public int Add(string pIdentificationNumber,
                            string pTypeIdentification,
                            string FirtsName, string SecondName,
                            string FirtsLastName, string SecondLastName,
                            string Email, string ResidentialAddress, string WorkAddress,
                            string CellPhone, string PermanentPhone)
        {
            EntityEntry resultAntoCliente = null;
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos
                using (Validator validator = new Validator())
                {
                    validator.Add("Tipo Identificación", pTypeIdentification, ValType.REQ, ValType.INTPOS);
                    validator.Add("Número Identificación", pIdentificationNumber, ValType.REQ, ValType.INTPOS);
                    validator.Add("Primer Nombre", FirtsName, ValType.REQ, ValType.ALPHA);
                    validator.Add("Segundo Nombre", SecondName, ValType.ALPHA);
                    validator.Add("Primer Apellido", FirtsLastName, ValType.REQ, ValType.ALPHA);
                    validator.Add("Segundo Apellido", SecondLastName, ValType.ALPHA);
                    validator.Add("Email", Email, ValType.REQ, ValType.EMAIL);
                    validator.Add("Dirección Residencial", ResidentialAddress, ValType.REQ, ValType.ALPHA);
                    validator.Add("Dirección Trabajo", WorkAddress, ValType.ALPHA);
                    validator.Add("Número Celular", CellPhone, ValType.REQ, ValType.INTPOS);
                    validator.Add("Número Fijo", PermanentPhone, ValType.INTPOS);
                    validator.Validate();
                }
                #endregion

                #region Cargar Objeto
                AntoCliente antoCliente = new AntoCliente();
                antoCliente.NumeroIdentificacion = int.Parse(pIdentificationNumber);
                antoCliente.TipoIdentificacion = int.Parse(pTypeIdentification);
                antoCliente.PrimerNombre = FirtsName;
                antoCliente.SegundoNombre = SecondName;
                antoCliente.PrimerApellido = FirtsLastName;
                antoCliente.SegundoApellido = SecondLastName;
                antoCliente.Email = Email;
                antoCliente.DireccionResidencial = ResidentialAddress;
                antoCliente.DireccionTrabajo = WorkAddress;
                antoCliente.TelefonoCelular = CellPhone;
                antoCliente.TelefonoFijo = PermanentPhone;
                antoCliente.Estado = Utilities.CONS_UNO;
                #endregion

                resultAntoCliente = cravingsDbContext.AntoClientes.Add(antoCliente);
                PropertyValues prueba = resultAntoCliente.GetDatabaseValues();
                cravingsDbContext.SaveChanges();
                return 1;
            }
        }

        public void Update(string pConsClient, string pIdentificationNumber,
                                  string pTypeIdentification,
                                  string FirtsName, string SecondName,
                                  string FirtsLastName, string SecondLastName,
                                  string Email, string ResidentialAddress, string WorkAddress,
                                  string CellPhone, string PermanentPhone, string State)
        {
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos
                using (Validator validator = new Validator())
                {
                    validator.Add("Id Cliente", pConsClient, ValType.REQ, ValType.INTPOS);
                    validator.Add("Tipo Identificación", pTypeIdentification, ValType.REQ, ValType.INTPOS);
                    validator.Add("Número Identificación", pIdentificationNumber, ValType.REQ, ValType.INTPOS);
                    validator.Add("Primer Nombre", FirtsName, ValType.REQ, ValType.ALPHA);
                    validator.Add("Segundo Nombre", SecondName, ValType.ALPHA);
                    validator.Add("Primer Apellido", FirtsLastName, ValType.REQ, ValType.ALPHA);
                    validator.Add("Segundo Apellido", SecondLastName, ValType.ALPHA);
                    validator.Add("Email", Email, ValType.REQ, ValType.EMAIL);
                    validator.Add("Dirección Residencial", ResidentialAddress, ValType.REQ, ValType.ALPHA);
                    validator.Add("Dirección Trabajo", WorkAddress, ValType.ALPHA);
                    validator.Add("Número Celular", CellPhone, ValType.REQ, ValType.INTPOS);
                    validator.Add("Número Fijo", State, ValType.INTPOS);
                    validator.Add("Estado", State, ValType.REQ, ValType.INTPOS);
                    validator.Validate();
                }
                #endregion

                #region Cargar Objeto
                AntoCliente antoCliente = new AntoCliente();
                antoCliente.ConsCliente = int.Parse(pConsClient);
                antoCliente.NumeroIdentificacion = int.Parse(pIdentificationNumber);
                antoCliente.TipoIdentificacion = int.Parse(pTypeIdentification);
                antoCliente.PrimerNombre = FirtsName;
                antoCliente.SegundoNombre = SecondName;
                antoCliente.PrimerApellido = FirtsLastName;
                antoCliente.SegundoApellido = SecondLastName;
                antoCliente.Email = Email;
                antoCliente.DireccionResidencial = ResidentialAddress;
                antoCliente.DireccionTrabajo = WorkAddress;
                antoCliente.TelefonoCelular = CellPhone;
                antoCliente.TelefonoFijo = PermanentPhone;
                antoCliente.Estado = Int32.Parse(State);
                #endregion

                cravingsDbContext.AntoClientes.Update(antoCliente);
                cravingsDbContext.SaveChanges();
            }
        }
        public ArrayList Find(string pConsClient)
        {
            List<AntoCliente> listCliente;
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos

                using (Validator validator = new Validator())
                {
                    validator.Add("Id Cliente", pConsClient, ValType.INTPOS, ValType.REQ);
                    validator.Validate();
                }
                #endregion

                listCliente = cravingsDbContext.AntoClientes.Where(p => p.ConsCliente == int.Parse(pConsClient)).ToList();

                return PutCliente(listCliente);
            }
        }
        public ArrayList Find(string pIdentificacion, string pTipoIdentificacion)
        {
            List<AntoCliente> listCliente;
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos

                using (Validator validator = new Validator())
                {
                    validator.Add("Num. Identificación", pIdentificacion, ValType.INTPOS, ValType.REQ);
                    validator.Add("Tipo Identificación", pTipoIdentificacion, ValType.INTPOS, ValType.REQ);
                    validator.Validate();
                }
                #endregion
                
                listCliente = cravingsDbContext.AntoClientes.Where(p => p.NumeroIdentificacion == int.Parse(pIdentificacion)
                                                                   && p.TipoIdentificacion == int.Parse(pTipoIdentificacion)).ToList();

                return PutCliente(listCliente);
            }
        }
        public ArrayList FindAll()
        {
            Task<List<AntoCliente>> listResult = null;
            ArrayList Clients = null;

            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                listResult = cravingsDbContext.AntoClientes.ToListAsync();
                Clients = new ArrayList();
                if (listResult! != null)
                {
                    return PutCliente(listResult.Result);
                }
                return Clients;
            }
        }
        public void Delete(string pConsClient)
        {
            ValueTask<AntoCliente> cliente;
            ArrayList arrayCliente = null;
            throw new Exception("En Contruccion");
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                #region Validar Datos

                using (Validator validator = new Validator())
                {
                    validator.Add("Id Cliente", pConsClient, ValType.INTPOS);
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
        public ArrayList PutCliente(List<AntoCliente> listCliente)
        {
            ArrayList Clients = null;
            ClientModel clientModel = null;
            using (CravingsDbContext cravingsDbContext = new CravingsDbContext())
            {
                Clients = new ArrayList();
                if (listCliente != null)
                {
                    foreach (AntoCliente regAntoCliente in listCliente)
                    {
                        #region Cargar Objeto
                        clientModel = new ClientModel();
                        clientModel.ConsCliente = regAntoCliente.ConsCliente;
                        clientModel.TipoIdentificacion = regAntoCliente.TipoIdentificacion;
                        clientModel.NumeroIdentificacion = regAntoCliente.NumeroIdentificacion.ToString();
                        clientModel.PrimerNombre = regAntoCliente.PrimerNombre;
                        clientModel.SegundoNombre = regAntoCliente.SegundoNombre;
                        clientModel.PrimerApellido = regAntoCliente.PrimerApellido;
                        clientModel.SegundoApellido = regAntoCliente.SegundoApellido;
                        clientModel.Email = regAntoCliente.Email;
                        clientModel.DireccionResidencial = regAntoCliente.DireccionResidencial;
                        clientModel.DireccionTrabajo = regAntoCliente.DireccionTrabajo;
                        clientModel.TelefonoCelular = regAntoCliente.TelefonoCelular;
                        clientModel.TelefonoFijo = regAntoCliente.TelefonoFijo;
                        clientModel.Estado = regAntoCliente.Estado;
                        clientModel.FechaRegistro = regAntoCliente.FechaRegistro;
                        Clients.Add(clientModel);

                        #endregion
                    }
                }
                return Clients;
            }
        }
    }
}