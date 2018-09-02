using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DccyOrigination.Models
{
    [Table("admUser")]
    public class AdmUser
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public string Guid { get; set; }
        /// <summary>
        /// 用户帐号
        /// </summary>
        public string UserAccounts { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }
        /// <summary>
        /// 角色id
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>
        public int DepId { get; set; }
         /// <summary>
         /// 性别 0女1男
         /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string DetailedAddress { get; set; }
        /// <summary>
        /// 登录次数 
        /// </summary>
        public int NumOfLogins { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        public string ThumbnailImage { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        [Timestamp]
        [ConcurrencyCheck]
        public byte[] TimestampV { get; set; }
    }
}
