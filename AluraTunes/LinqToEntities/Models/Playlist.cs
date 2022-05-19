using System;
using System.Collections.Generic;

namespace LinqToEntities.Models
{
    public partial class Playlist
    {
        public Playlist()
        {
            Faixas = new HashSet<Faixa>();
        }

        public int PlaylistId { get; set; }
        public string? Nome { get; set; }

        public virtual ICollection<Faixa> Faixas { get; set; }
    }
}
