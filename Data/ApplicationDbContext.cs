using System;
using System.Collections.Generic;
using System.Text;
using Desafio.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Projeto> Projetos { get; set;}
        public DbSet<Tecnologia> Tecnologias { get; set; }
        public DbSet<Daily> Dailys { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<ProgramaStarter> Programas { get; set; }
        public DbSet<Starter> Starters { get; set; }
        public DbSet<ScrumMaster> Scrums { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<ModuloGrupo> ModuloGrupos { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
