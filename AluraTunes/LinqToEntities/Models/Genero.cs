using System;
using System.Collections.Generic;

namespace LinqToEntities.Models
{
    public partial class Genero
    {
        public Genero()
        {
            Faixas = new HashSet<Faixa>();
        }

        public int GeneroId { get; set; }
        public string? Nome { get; set; }

        public virtual ICollection<Faixa> Faixas { get; set; }
    }
}
