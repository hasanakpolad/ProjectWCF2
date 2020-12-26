using Data;
using Data.Dtoes;
using DataAccess.UnitOfWork;
using ProjectWCF2.Interfaces;
using System;
using System.Net;
using System.ServiceModel.Web;
using Newtonsoft.Json;

namespace ProjectWCF2.Services
{
    public class CustomerService : ICustomerService
    {
        WebOperationContext webOperationContext = WebOperationContext.Current;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Customer Dto alıp veri tabanına kayıt edilecek
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>HttpStatusCode</returns>
        public string AddCustomer(CustomerDto dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    if (dto != null)
                    {
                        var customer = new Customer()
                        {
                            Id = dto.Id,
                            UserName = dto.UserName,
                            Password = dto.Password,
                            Mail = dto.Mail
                        };

                        uow.Repository<Customer>().Add(customer);

                        if (uow.Save() > 0)
                        {
                            webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                            log.Info("İşlem Başarılı" + " " + HttpStatusCode.OK);
                            return webOperationContext.OutgoingResponse.StatusDescription;
                        }
                        else
                        {
                            webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                            log.Warn("İşlem Başarısız", new WebFaultException(HttpStatusCode.InternalServerError));
                            return webOperationContext.OutgoingResponse.StatusDescription;
                        }
                    }
                    else
                    {
                        webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                        log.Warn("İşlem Başarısız", new WebFaultException(HttpStatusCode.NotFound));
                        return webOperationContext.OutgoingResponse.StatusDescription;
                    }
                }
                catch (Exception ex)
                {
                    log.Error("İşlem Başarısız", new WebFaultException(HttpStatusCode.BadRequest));
                    throw new WebFaultException(HttpStatusCode.BadRequest);
                }

            }
        }

        /// <summary>
        /// CustomerDto alıp eşleşen kaydı güncelleyecek
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>HttpStatusCode</returns>
        public string UpdateCustomer(CustomerDto dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var customer = uow.Repository<Customer>().Get(dto.Id);
                    if (customer != null)
                    {

                        customer.Id = dto.Id;
                        customer.UserName = dto.UserName;
                        customer.Password = dto.Password;
                        customer.Mail = dto.Mail;

                        uow.Repository<Customer>().Update(customer);

                        if (uow.Save() > 0)
                        {
                            webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                            log.Info("İşlem Başarılı" + " " + HttpStatusCode.OK);
                            return webOperationContext.OutgoingResponse.StatusDescription;
                        }
                        else
                        {
                            webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                            log.Warn("İşlem Başarısız", new WebFaultException(HttpStatusCode.InternalServerError));
                            return webOperationContext.OutgoingResponse.StatusDescription;
                        }
                    }
                    else
                    {
                        webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                        log.Warn("İşlem Başarısız", new WebFaultException(HttpStatusCode.NotFound));
                        return webOperationContext.OutgoingResponse.StatusDescription;
                    }
                }
                catch (Exception)
                {
                    log.Error("İşlem Başarısız", new WebFaultException(HttpStatusCode.BadRequest));
                    throw new WebFaultException(HttpStatusCode.BadRequest);
                }

            }
        }

        /// <summary>
        /// Auth Key alıp kayıt dönecek
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Model HttpStatusCode</returns>
        public string GetCustomer(int id) //Authentication uygulanacak (basicAuthentication with AuthKey)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var model = uow.Repository<Customer>().Get(id);
                    if (model != null)
                    {
                        webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                        log.Info("İşlem Başarılı" + " " + HttpStatusCode.OK);
                        return JsonConvert.SerializeObject(model);
                    }
                    else
                    {
                        webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                        log.Warn("İşlem Başarısız", new WebFaultException(HttpStatusCode.NotFound));
                        return webOperationContext.OutgoingResponse.StatusDescription;
                    }
                }
                catch (Exception ex)
                {
                    log.Error("İşlem Başarısız", new WebFaultException(HttpStatusCode.BadRequest));
                    throw new WebFaultException(HttpStatusCode.BadRequest);
                }
            }
        }

        /// <summary>
        /// CustomerDto alıp eşleşen kaydı silecek
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>HttpStatusCode</returns>
        public string DeleteCustomer(CustomerDto dto)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var customer = uow.Repository<Customer>().Get(dto.Id);
                    if (customer != null)
                    {
                        uow.Repository<Customer>().Delete(uow.Repository<Customer>().Get(dto.Id));
                        if (uow.Save() > 0)
                        {
                            webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                            log.Info("İşlem Başarılı" + " " + HttpStatusCode.OK.GetTypeCode().ToString());
                            return webOperationContext.OutgoingResponse.StatusDescription;
                        }
                        else
                        {
                            webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                            log.Warn("İşlem Başarısız", new WebFaultException(HttpStatusCode.InternalServerError));
                            return webOperationContext.OutgoingResponse.StatusDescription;
                        }
                    }
                    else
                    {
                        webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                        log.Warn("İşlem Başarısız", new WebFaultException(HttpStatusCode.NotFound));
                        return webOperationContext.OutgoingResponse.StatusDescription;
                    }
                }
            }
            catch (Exception)
            {
                log.Error("İşlem Başarısız", new WebFaultException(HttpStatusCode.BadRequest));
                throw new WebFaultException(HttpStatusCode.BadRequest);
            }
        }
    }
}