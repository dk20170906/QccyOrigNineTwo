using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DccyOrigination.Models.SysManagement
{
    [Table("admDepartment")]
    public class AdmDepartment :AdmModel
    {
        /// <summary>
        /// 部门名称
        /// </summary>
         public string DepName { get; set; }
    }
}
