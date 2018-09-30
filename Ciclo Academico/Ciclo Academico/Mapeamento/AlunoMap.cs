using Ciclo_Academico.Models;
using System.Data.Entity.ModelConfiguration;

namespace Ciclo_Academico.Mapeamento
{
    public class AlunoMap : EntityTypeConfiguration<Aluno>
    {
        public AlunoMap()
        {
            ToTable("Aluno");
            HasKey(x => x.Id);
            Property(x => x.Nome).IsRequired();
        }

    }
}