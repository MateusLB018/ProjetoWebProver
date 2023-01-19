using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoWebProver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoWebProver.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Personagem> Personagems { get; set; }
        public DbSet<Atributo> Atributos { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<Armadura> Armaduras { get; set; }
        public DbSet<Poder> Poderes { get; set; }
    }
}
