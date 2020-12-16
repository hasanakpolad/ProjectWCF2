//using Data;
using DataAccess.UnitOfWork;
using ProjectWCF2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

namespace ProjectWCF2.Services
{
    public class CustomerService : ICustomerService
    {
        public string AddCustomer()
        {
            //using (UnitOfWork uow = new UnitOfWork())
            //{
            //    uow.Repository<Customer>().Add( dto);
            //    if (uow.Save() > 0)
            //        return null;
            //}
            return "";
        }

        public string DeleteCustomer()
        {
            throw new NotImplementedException();
        }

        public string GetCustomer()
        {
            throw new NotImplementedException();
        }

        public string UpdateCustomer()
        {
            throw new NotImplementedException();
        }
    }
}