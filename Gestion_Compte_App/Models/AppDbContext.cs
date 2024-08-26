using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Compte_App.Models
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Intervenant> Intervenants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=D:\\ISPM\\L3 (2023-2024)\\IS\\Projet\\Application_Gestion_Compte\\Gestion_Compte_App\\intervenant.db");
        }
    }
}
