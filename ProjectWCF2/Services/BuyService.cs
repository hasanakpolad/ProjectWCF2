using Data;
using Data.Dtoes;
using DataAccess.UnitOfWork;
using ProjectWCF2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Web;

namespace ProjectWCF2.Services
{
    public class BuyService : IBuyService
    {
        WebOperationContext webOperationContext = WebOperationContext.Current;
        public string AddSales(BuyHistoryDto dto)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    using (project2dbEntities entities = new project2dbEntities())
                    {
                        if (dto != null)
                        {
                            var deneme = (from p in entities.Product
                                          where dto.ProductName.Equals(p.ProductName)
                                          select p.ProductName).ToList();
                            var history = new BuyHistory
                            {
                                Id = dto.Id,
                                //ProductName = (from p in entities.Product
                                //               select p.ProductName).ToString(),
                                Price = dto.Price,
                                //ProductId = Convert.ToInt32(from p in entities.Product
                                //                            where p.ProductName.Equals(dto.ProductName)
                                //                            select p.Id),
                                //CustomerId = Convert.ToInt32(from c in entities.Customer
                                //                             where c.UserName.Equals(dto.CustomerName)
                                //                             select c.Id)                               
                            };
                            uow.Repository<BuyHistory>().Add(history);
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
                catch (Exception ex)
                {
                    throw new WebFaultException(HttpStatusCode.BadRequest);
                }
            }
        }

        public string UpdateSales(BuyHistoryDto dto)
        {
            throw new NotImplementedException();
        }

        public string GetSales(int id)
        {
            throw new NotImplementedException();
        }

        public string DeleteSales(BuyHistoryDto dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var history = uow.Repository<BuyHistory>().Get(dto.Id);
                    if (history != null)
                    {
                        uow.Repository<BuyHistory>().Delete(history);
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
    }
}