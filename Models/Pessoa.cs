using System;
using System.Collections.Generic;

namespace MgnWebApi.Models
{
    public class Pessoa
    {
        public Int32 IdPessoa { get; set; }
        public String Nome { get; set; }
        public String Cpf { get; set; }
        public String Rg { get; set; }
        public IEnumerable<Telefone> Telefones { get; set; }
        public Endereco Endereco { get; set; }


    }
}
