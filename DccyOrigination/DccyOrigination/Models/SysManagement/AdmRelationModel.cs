using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DccyOrigination.Models.SysManagement
{
    /// <summary>
    /// 关联父类
    /// </summary>
    public class AdmRelationModel : Entity
    {
        /// <summary>
        /// 权限类型
        /// </summary>
        public int JurType { get; set; }

    }
}
