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
<<<<<<< HEAD
            optionsBuilder.UseSqlite("Data Source=D:\\ISPM\\L3 (2023-2024)\\IS\\Projet\\Application_Gestion_Compte\\Gestion_Compte_App\\intervenant.db");
=======
            optionsBuilder.UseSqlite("Data Source= **Copier le chemin de intervenant.db dans votre machine et le coller ici pour pouvoir lier la BDD au code**");
>>>>>>> 08655642c418054642eda1e417763d5e655ffe44
        }
    }
}
