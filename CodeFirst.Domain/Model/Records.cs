using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Domain.Model
{
    public class Records
    {
        public Records()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// PK
        /// </summary>
        [Key]
        [DataType("char")]
        [StringLength(36, MinimumLength = 36)]
        public string Id { get; set; }

        /// <summary>
        /// 使用者Id
        /// </summary>
        [Required]
        [StringLength(50)]
        public string UserId { get; set; }

        /// <summary>
        /// 使用者主檔
        /// </summary>
        [ForeignKey("UserId")]
        public virtual Users User { get; set; }
    }
}
