using Data;
using Data.Dtoes;
using DataAccess.UnitOfWork;
using Newtonsoft.Json;
using ProjectWCF2.Interfaces;
using System;
using System.Net;
using System.ServiceModel.Web;

namespace ProjectWCF2.Services
{
    public class ProductService : IProductService
    {
        WebOperationContext webOperationContext = WebOperationContext.Current;

        /// <summary>
        /// ProductDto alıp Product tablosuna kayıt yapacak
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>HttpStatusCode</returns>
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
                            Stock = dto.Stock,
                            ProductName = dto.ProductName
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

        /// <summary>
        /// ProductDto alıp eşleşen kaydı güncelleyecek
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>HttpStatusCode</returns>
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
                        product.ProductName = dto.ProductName;
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

        /// <summary>
        /// SearchDto alıp eşleşen kayıtlar dönecek
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Model veya Modeller</returns>
        public string GetProduct(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var product = uow.Repository<Product>().Get(id);
                    if (product != null)
                    {
                        webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                        return JsonConvert.SerializeObject(product);
                    }
                    else
                    {
                        webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                        return webOperationContext.OutgoingResponse.StatusDescription;
                    }
                }
                catch (Exception ex)
                {
                    throw new WebFaultException(HttpStatusCode.BadRequest);
                }
            }
        }

        /// <summary>
        /// ProductDto alıp eşleşen kaydı silecek
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>HttpStatusCode</returns>
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