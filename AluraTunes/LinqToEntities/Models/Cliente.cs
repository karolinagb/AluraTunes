using System;
using System.Collections.Generic;

namespace LinqToEntities.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            NotaFiscals = new HashSet<NotaFiscal>();
        }

        public int ClienteId { get; set; }
        public string PrimeiroNome { get; set; } = null!;
        public string Sobrenome { get; set; } = null!;
        public string? Empresa { get; set; }
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Pais { get; set; }
        public string? Cep { get; set; }
        public string? Fone { get; set; }
        public string? Fax { get; set; }
        public string Email { get; set; } = null!;
        public int? SuporteId { get; set; }

        public virtual Funcionario? Suporte { get; set; }
        public virtual ICollection<NotaFiscal> NotaFiscals { get; set; }
    }
}
