using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace MgnWebApi.Models
{
	public class Telefone
	{   
        public Int32 TelefoneId { get; set; }
        public String Tipo { get; set; }
        public String Numero { get; set; }
        public Int32 PessoaId { get; set; }

    }
}
