using Ciclo_Academico.Models;
using System.Data.Entity.ModelConfiguration;

namespace Ciclo_Academico.Mapeamento
{
    public class ProvaMap: EntityTypeConfiguration<Prova> 
    {
        public ProvaMap()
        {
            ToTable("Prova");
            HasKey(x => x.Id);
            Property(x => x.Descricao).IsRequired();
            Property(x => x.Peso);
            Property(x => x.Nota);
        }
    }
}