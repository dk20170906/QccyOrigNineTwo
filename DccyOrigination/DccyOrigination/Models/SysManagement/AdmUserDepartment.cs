using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DccyOrigination.Models.SysManagement
{
    [Table("admUserDep")]
    public class AdmUserDepartment:AdmRelationModel
    {
        public int AdmUserId { get; set; }
        public int AdmDepId { get; set; }
    }
}
