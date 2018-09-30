using Ciclo_Academico.Mapeamento;
using Ciclo_Academico.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ciclo_Academico.Context
{
    public class Ciclo_AcademicoContext : DbContext
    {
        public Ciclo_AcademicoContext() : base("name=Ciclo_AcademicoContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<Prova> Prova { get; set; }
        public DbSet<Turma> Turma { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlunoMap());
            modelBuilder.Configurations.Add(new TurmaMap());
            modelBuilder.Configurations.Add(new ProvaMap());
            modelBuilder.Configurations.Add(new AvaliacaoMap());
        }
    }
}
