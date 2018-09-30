using Ciclo_Academico.Query;
using System.Collections.Generic;
using System.Linq;

namespace Ciclo_Academico.Models
{
    public class Avaliacao: Entidade
    {
        public Avaliacao()
        {

        }

        public double Media()
        {
            return Prova.Average(x => x.Nota);
        }

        public List<RankAkunoQuery> Rank(ICollection<Avaliacao> avaliacoes)
        {
            var listaRank = new List<RankAkunoQuery>();

            foreach (var avaliacao in avaliacoes)
            {
                var rank = new RankAkunoQuery();
                rank.Nome = avaliacao.Aluno.Nome;
                rank.Media = avaliacao.Media();
                rank.Turma = avaliacao.Turma.Descricao;

                listaRank.Add(rank);
            }
            return listaRank.OrderByDescending(x => x.Media).Take(5).ToList();
        }

        public Aluno Aluno { get; set; }
        public ICollection<Prova> Prova { get; set; }
        public Turma Turma { get; set; }
    }
}