using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Domain.Model
{
    public class Users : ModelBase
    {
        /// <summary>
        /// 使用者Id
        /// </summary>
        [Key]
        [DataType("varchar")]
        [StringLength(50)]
        public string UserId { get; set; }

        /// <summary>
        /// 使用者名稱
        /// </summary>
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        /// <remarks>用MD5加密</remarks>
        [Required]
        [StringLength(32, MinimumLength = 32)]
        public string Password { get; set; }

        /// <summary>
        /// FK
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ICollection<Records> Records { get; set; }
    }
}
