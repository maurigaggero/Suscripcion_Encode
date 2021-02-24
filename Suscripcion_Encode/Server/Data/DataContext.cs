using Microsoft.EntityFrameworkCore;
using Suscripcion_Encode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace Suscripcion_Encode.Server.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = revista; Integrated Security = True;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Suscripcion> Suscripciones { get; set; }
        public DbSet<Suscriptor> Suscriptores { get; set; }
    }
}
