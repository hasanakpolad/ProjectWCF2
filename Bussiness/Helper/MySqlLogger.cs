using Data;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Helper
{
    public class MySqlLogger
    {
        #region Singleton Section
        private static readonly Lazy<MySqlLogger> _instance = new Lazy<MySqlLogger>(() => new MySqlLogger());
        public MySqlLogger()
        {

        }
        public static MySqlLogger Instance = _instance.Value;
        #endregion


        public void Error(Exception exception, string text)
        {
            using (var uow = new UnitOfWork())
            {
                uow.Repository<Log>().Add(new Log()
                {
                    FirstDatetime = DateTime.UtcNow,
                    LastDatetime = DateTime.UtcNow,
                    Text = text + exception.Message

                });
                uow.Save();
            }
        }

        public void Info(string text)
        {
            using (var uow = new UnitOfWork())
            {
                uow.Repository<Log>().Add(new Log()
                {
                    FirstDatetime = DateTime.UtcNow,
                    LastDatetime = DateTime.UtcNow,
                    Text = text

                });
                uow.Save();
            }
        }
    }
}
