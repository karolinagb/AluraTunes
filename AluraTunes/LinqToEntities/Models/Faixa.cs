using System;
using System.Collections.Generic;

namespace LinqToEntities.Models
{
    public partial class Faixa
    {
        public Faixa()
        {
            ItemNotaFiscals = new HashSet<ItemNotaFiscal>();
            Playlists = new HashSet<Playlist>();
        }

        public int FaixaId { get; set; }
        public string Nome { get; set; } = null!;
        public int? AlbumId { get; set; }
        public int TipoMidiaId { get; set; }
        public int? GeneroId { get; set; }
        public string? Compositor { get; set; }
        public int Milissegundos { get; set; }
        public int? Bytes { get; set; }
        public decimal PrecoUnitario { get; set; }

        public virtual Album? Album { get; set; }
        public virtual Genero? Genero { get; set; }
        public virtual TipoMidium TipoMidia { get; set; } = null!;
        public virtual ICollection<ItemNotaFiscal> ItemNotaFiscals { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
