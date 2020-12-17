using DataAccess.UnitOfWork;
using ProjectWCF2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWCF2.Services
{
    public class BuyService : IBuyService
    {
        public string AddSales()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    return "";
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public string DeleteSales()
        {
            throw new NotImplementedException();
        }

        public string GetSales()
        {
            throw new NotImplementedException();
        }

        public string UpdateSales()
        {
            throw new NotImplementedException();
        }
    }
}