using Data;
using Data.Dtoes;
using DataAccess.UnitOfWork;
using ProjectWCF2.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Web;

namespace ProjectWCF2.Services
{
    public class ProductService : IProductService
    {
        WebOperationContext webOperationContext = WebOperationContext.Current;

        public string AddProduct(ProductDto dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    if (dto != null)
                    {
                        var product = new Product()
                        {
                            Id = dto.Id,
                            Price = dto.Price,
                            Stock = dto.Stock
                        };
                        uow.Repository<Product>().Add(product);
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

        public string UpdateProduct(ProductDto dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var product = uow.Repository<Product>().Get(dto.Id);
                    if (product != null)
                    {
                        product.Id = dto.Id;
                        product.Price = dto.Price;
                        product.Stock = dto.Stock;
                        uow.Repository<Product>().Update(product);
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

        public string GetProduct(SearchDto dto)
        {
            throw new NotImplementedException();
        }


        public string DeleteProduct(ProductDto dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var product = uow.Repository<Product>().Get(dto.Id);
                    if (product != null)
                    {
                        uow.Repository<Product>().Delete(uow.Repository<Product>().Get(dto.Id));
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