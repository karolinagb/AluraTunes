﻿using System;
using System.Collections.Generic;

namespace LinqToEntities.Models
{
    public partial class Artistum
    {
        public Artistum()
        {
            Albums = new HashSet<Album>();
        }

        public int ArtistaId { get; set; }
        public string? Nome { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
