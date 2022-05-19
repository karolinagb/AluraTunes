using System;
using System.Collections.Generic;

namespace LinqToEntities.Models
{
    public partial class TipoMidium
    {
        public TipoMidium()
        {
            Faixas = new HashSet<Faixa>();
        }

        public int TipoMidiaId { get; set; }
        public string? Nome { get; set; }

        public virtual ICollection<Faixa> Faixas { get; set; }
    }
}
