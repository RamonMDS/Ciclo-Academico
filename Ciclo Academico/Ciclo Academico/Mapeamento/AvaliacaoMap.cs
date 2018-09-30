using Ciclo_Academico.Models;
using System.Data.Entity.ModelConfiguration;

namespace Ciclo_Academico.Mapeamento
{
    public class AvaliacaoMap : EntityTypeConfiguration<Avaliacao>
    {
        public AvaliacaoMap()
        {
            ToTable("Avaliacao");
            HasKey(x => x.Id);
            HasRequired(x => x.Aluno);
            HasRequired(x => x.Prova);
            HasRequired(x => x.Turma);
        }
    }
}