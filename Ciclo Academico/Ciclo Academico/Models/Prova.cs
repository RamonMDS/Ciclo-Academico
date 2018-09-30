using System;

namespace Ciclo_Academico.Models
{
    public class Prova : Entidade
    {
        public Prova()
        {
                
        }
        public String Descricao { get; set; }
        public int Peso { get; set; }
        public double Nota { get; set; }
    }
}