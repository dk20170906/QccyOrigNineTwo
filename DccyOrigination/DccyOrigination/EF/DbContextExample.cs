using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace DccyOrigination.EF
{
    /// <summary>
    ///     延迟初始化数据库连接实例
    /// </summary>
    public sealed class DbContextExample
    {
        /// <summary>
        /// 延迟初始化数据库连接
        /// </summary>
       // private static readonly Lazy<DccyDbContext> lazy = new Lazy<DccyDbContext>(() =>new DccyDbContext(new DbContextOptionsBuilder().UseSqlServer("server=.;database=QccyOrig;uid=sa;pwd=123456;").Options));

        private static readonly Lazy<DccyDbContext> lazy = new Lazy<DccyDbContext>(() => new DccyDbContext(new DbContextOptionsBuilder().UseSqlServer(new  ConfigurationBuilder().AddJsonFile("appsettings.json").Build()["ConnectionStrings:SqlServerConnectiion"]).Options));


        public static  DccyDbContext _DccyDbContext { get { return lazy.Value; } }
        private DbContextExample()
        {
        }   
    }
}
