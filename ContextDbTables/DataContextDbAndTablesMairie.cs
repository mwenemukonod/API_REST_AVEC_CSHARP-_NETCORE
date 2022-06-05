using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MairieTaxeAPI.Models;
using MairieTaxeAPI.Mairie;
namespace MairieTaxeAPI.ContextDbTables
{
    public class DataContextDbAndTablesMairie:DbContext
    {
        public DataContextDbAndTablesMairie()
        {

        }
        public DataContextDbAndTablesMairie(DbContextOptions<DbContext> options) : base(options) 
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Server=.;Database=monbasededonne;user=test;password=1234;");
            }

        }
     //creation de la table via la classe ClsRole
        public virtual DbSet<ClsRole> Role { get; set; }
       

    }
}
