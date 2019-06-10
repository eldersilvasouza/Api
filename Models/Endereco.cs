using System;

namespace MgnWebApi.Models
{
    public class Endereco
    {
        public Int32 EnderecoId {get; set;}
        public Int32 PessoaId {get; set;}
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
    }
}


