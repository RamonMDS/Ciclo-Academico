using Ciclo_Academico.Models;
using System.Data.Entity.ModelConfiguration;

namespace Ciclo_Academico.Mapeamento
{
    public class TurmaMap : EntityTypeConfiguration<Turma>
    {
        public TurmaMap()
        {
            ToTable("Turma");
            Property(x => x.Descricao).IsRequired();
            HasMany(x => x.Aluno);
        }
    }
}