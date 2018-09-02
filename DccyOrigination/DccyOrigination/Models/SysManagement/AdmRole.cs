using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DccyOrigination.Models.SysManagement
{
    /// <summary>
    /// 角色表
    /// </summary>
    [Table("admRole")]
    public class AdmRole  :AdmModel
    {  
        public string RoleName { get; set; }
        /// <summary>
        /// 菜单Guid
        /// </summary>
        public string MenuGuid { get; set; }
    }
}
