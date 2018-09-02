using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DccyOrigination.EF
{
    public class DBHandler : IRepository ,IDisposable
    {
        public static DccyDbContext Db => DbContextExample._DccyDbContext;

        /// <summary>
        /// 数据库执行操作
        /// </summary>
        /// <returns></returns>
        public static int DbSavaChange()
        {
            try
            {
                return Db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                 //????操作失败
                throw;
            }
        }
        public void Dispose()
        {
            Db.Dispose();
        }

        public int testModel(dynamic dynamic)
        {
            throw new NotImplementedException();
        }
    }
}
