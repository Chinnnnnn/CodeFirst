using CodeFirst.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Data.Service
{
    public class UsersService : DemoRepository<Users>
    {
        public UsersService()
            : base()
        {
        }

        public UsersService(DbContext db)
            : base(db)
        {
        }
    }
}
