using System;

namespace Ciclo_Academico.Models
{
    public abstract class Entidade
    {
        public Entidade()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
    }
}