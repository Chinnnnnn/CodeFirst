using CodeFirst.Domain.Hook;
using ORMs.Infrastructure.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Domain
{
    public class ModelBase : IHookBase
    {
        public ModelBase()
        {
            this.Status = Status.Enabled;
        }

        /// <summary>
        /// 狀態
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [StringLength(50)]
        public string Remark { get; set; }

        /// <summary>
        /// 新增時間
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 新增人UserId
        /// </summary>
        [StringLength(50)]
        [DataType("varchar")]
        public string CreateUser { get; set; }

        /// <summary>
        /// 變更時間
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 變更人UserId
        /// </summary>
        [StringLength(50)]
        [DataType("varchar")]
        public string UpdateUser { get; set; }
    }
}
