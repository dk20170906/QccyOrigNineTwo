using DccyOrigination.Models;
using DccyOrigination.Models.SysManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DccyOrigination.EF
{
    public class DccyDbContext:DbContext 
    {
 
        public DccyDbContext(DbContextOptions options)
           : base(options)
        {
        }

        #region code first 数据库生成       非泛型
        public DbSet<AdmDepartment> AdmDepartment { get; set; }
        public DbSet<AdmDepRole> AdmDepRole { get; set; }
        public DbSet<AdmJurisdiction> AdmJurisdiction { get; set; }
        public DbSet<AdmLog> AdmLog { get; set; }
        public DbSet<AdmRole> AdmRole { get; set; }
        public DbSet<AdmRoleJur> AdmRoleJur { get; set; }
        public DbSet<AdmUser> AdmUser { get; set; }
        public DbSet<AdmUserDepartment> AdmUserDepartment { get; set; }
        #endregion

    }
}
