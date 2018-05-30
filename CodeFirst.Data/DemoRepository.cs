using CodeFirst.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Data
{
    public class DemoRepository<TEntity> : RepositoryBase<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// 建構EF一個Entity的Repository，需傳入此Entity的Context。
        /// </summary>
        /// <param name="dbContext">Entity所在的Context</param>
        public DemoRepository():base(new DemoContext())
        {
        }

        public DemoRepository(DbContext db)
            : base(db)
        {
        }
    }
}
