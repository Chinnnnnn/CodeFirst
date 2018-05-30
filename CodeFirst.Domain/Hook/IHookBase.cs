using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Domain.Hook
{
    public interface IHookBase
    {
        string CreateUser { get; set; }
        DateTime? CreateTime { get; set; }
        string UpdateUser { get; set; }
        DateTime? UpdateTime { get; set; }
    }
}
