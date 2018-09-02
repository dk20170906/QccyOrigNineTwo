using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DccyOrigination.Models.SysManagement
{
    /// <summary>
    /// 部门角色
    /// </summary>
    [Table("admDepRole")]
    public class AdmDepRole :AdmRelationModel
    {
        public int DepId { get; set; }
        public int RoleId { get; set; }
    }
}
