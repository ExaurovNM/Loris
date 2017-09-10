using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lori.Domain.DataAccess
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base(Environment.GetEnvironmentVariable("DB"))
        {
        }

        public IDbSet<RequestLog> RequestLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DataBaseContext>(null);
        }
    }
}
