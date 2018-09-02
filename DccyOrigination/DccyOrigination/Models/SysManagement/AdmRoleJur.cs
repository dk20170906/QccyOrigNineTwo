using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DccyOrigination.Models.SysManagement
{
    [Table("admRoleJur")]
    public class AdmRoleJur  :AdmRelationModel
    {
        public int AdmRoleId { get; set; }
        public string AdmJurGuid { get; set; }
    }
}
