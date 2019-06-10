using MgnWebApi.Context;
using MgnWebApi.Interface;
using MgnWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MgnWebApi.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly PessoaContext _DbContext;

        public PessoaRepository(PessoaContext dbContext)
        {
            this._DbContext = dbContext;
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return this._DbContext.Pessoas.ToList();
        }

        public Pessoa GetById(Int32 id)
        {
            return this._DbContext.Pessoas.Find(id);
        }

        public void Insert(Pessoa pessoa)
        {
            this._DbContext.Add(pessoa);

            this.Save();
        }

        public void Update(Pessoa pessoa)
        {
            this._DbContext.Entry(pessoa).State = EntityState.Modified;

            this.Save();
        }

        public void Delete(Int32 id)
        {
            Pessoa pessoa = this._DbContext.Pessoas.Find(id);
            this._DbContext.Pessoas.Remove(pessoa);

            this.Save();
        }

        public void Save()
        {
            this._DbContext.SaveChanges();
        }
    }
}
