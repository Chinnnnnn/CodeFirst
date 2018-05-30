using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFHooks;
using CodeFirst.Domain.Model;
using System.Data.Entity.ModelConfiguration.Conventions;
using CodeFirst.Domain.Hook;

namespace CodeFirst.Domain
{
    public class DemoContext : HookedDbContext
    {
        public DemoContext()
            : base("name=Demo")
        {
            this.RegisterHook(new InsertHook());
            this.RegisterHook(new UpdateHook());

            //this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Users> Blogs { get; set; }
        public DbSet<Records> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
