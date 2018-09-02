using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DccyOrigination.Models.SysManagement
{
    [Table("admLog")]
    public class AdmLog
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public int OpType { get; set; }
        /// <summary>
        /// 操作内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OpTime { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        [Timestamp]
        [ConcurrencyCheck]
        public byte[] TimestampV { get; set; }
    }
}
