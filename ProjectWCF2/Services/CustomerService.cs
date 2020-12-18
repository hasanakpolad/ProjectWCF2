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
                            return webOperationContext.OutgoingResponse.StatusDescription;
                        }
                        else
                        {
                            webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                            return webOperationContext.OutgoingResponse.StatusDescription;
                        }
                    }
                    else
                    {
                        webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                        return webOperationContext.OutgoingResponse.StatusDescription;
                    }
                }
                catch (Exception)
                {
                    throw new WebFaultException(HttpStatusCode.BadRequest);
                }

            }
        }

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
                            return webOperationContext.OutgoingResponse.StatusDescription;
                        }
                        else
                        {
                            webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                            return webOperationContext.OutgoingResponse.StatusDescription;
                        }
                    }
                    else
                    {
                        webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                        return webOperationContext.OutgoingResponse.StatusDescription;
                    }
                }
                catch (Exception)
                {

                    throw new WebFaultException(HttpStatusCode.BadRequest);
                }

            }
        }

        public string GetCustomer(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var model = uow.Repository<Customer>().Get(id);
                    return JsonConvert.SerializeObject(model);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

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
                            return webOperationContext.OutgoingResponse.StatusDescription;
                        }
                        else
                        {
                            webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                            return webOperationContext.OutgoingResponse.StatusDescription;
                        }
                    }
                    else
                    {
                        webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                        return webOperationContext.OutgoingResponse.StatusDescription;
                    }
                }
            }
            catch (Exception)
            {

                throw new WebFaultException(HttpStatusCode.BadRequest);
            }
        }
    }
}