using System;
using System.Collections.Generic;

namespace LinqToEntities.Models
{
    public partial class Album
    {
        public Album()
        {
            Faixas = new HashSet<Faixa>();
        }

        public int AlbumId { get; set; }
        public string Titulo { get; set; } = null!;
        public int ArtistaId { get; set; }

        public virtual Artistum Artista { get; set; } = null!;
        public virtual ICollection<Faixa> Faixas { get; set; }
    }
}
