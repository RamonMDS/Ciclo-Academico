using System.Collections.Generic;

namespace Ciclo_Academico.Models
{
    public class Turma : Entidade
    {
        public Turma()
        {
            Aluno = new List<Aluno>();
        }

        public string Descrição { get; set; }
        public ICollection<Aluno> Aluno { get; set; }
    }

}
