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
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    using (project2dbEntities entities = new project2dbEntities())
                    {
                        if (dto != null)
                        {
                            BuyHistory history = new BuyHistory()
                            {
                                Id = dto.Id,
                                CustomerId = Convert.ToInt32(from c in entities.Customer
                                                             where dto.CustomerName == c.UserName
                                                             select c.Id),
                                ProductName = dto.ProductName,
                                Price = dto.Price,
                                Count = Convert.ToInt32(from p in entities.Product
                                                        select p.Stock - 1)
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
                catch (Exception)
                {
                    throw new WebFaultException(HttpStatusCode.BadRequest);
                }
            }
        }

        public string DeleteSales(BuyHistoryDto dto)
        {
            throw new NotImplementedException();
        }

        public string GetSales(int id)
        {
            throw new NotImplementedException();
        }

        public string UpdateSales(BuyHistoryDto dto)
        {
            throw new NotImplementedException();
        }
    }
}