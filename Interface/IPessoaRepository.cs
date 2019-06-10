using MgnWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MgnWebApi.Interface
{
    public interface IPessoaRepository
    {
        IEnumerable<Pessoa> GetAll();
        Pessoa GetById(Int32 id);
        void Insert(Pessoa pessoa);
        void Update(Pessoa pessoa);
        void Delete(Int32 id);
        void Save();
    }
}
