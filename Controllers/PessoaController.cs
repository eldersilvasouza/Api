using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using MgnWebApi.Interface;
using MgnWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MgnWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _PessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            this._PessoaRepository = pessoaRepository;
        }

        // GET: Api/Pessoa
        /// <summary>
        /// Retorna uma lista de todas as pessoas cadastradas no banco de dados.
        /// </summary>
        /// <returns>Lista de objetos do tipo Pessoa</returns>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Pessoa> pessoas = this._PessoaRepository.GetAll();

            return new OkObjectResult(pessoas);
        }

        // GET: Api/Pessoa/5
        /// <summary>
        /// Filtra as pessoas através do ID informado.
        /// </summary>
        /// <param name="id">ID da Pessoa</param>
        /// <returns>Objeto do tipo Pessoa</returns>
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Int32 id)
        {
            Pessoa pessoa = this._PessoaRepository.GetById(id);

            return new OkObjectResult(pessoa);
        }

        // POST: Api/Pessoa
        /// <summary>
        /// Efetua o cadastro de uma nova pessoa no banco de dados.
        /// </summary>
        /// <param name="pessoa">Objeto do tipo Pessoa</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                this._PessoaRepository.Insert(pessoa);
                scope.Complete();

                return this.CreatedAtAction(nameof(Get), new { id = pessoa.IdPessoa }, pessoa);
            }
        }

        // PUT: Api/Pessoa/5
        /// <summary>
        /// Atualiza os dados de uma pessoa no banco de dados.
        /// </summary>
        /// <param name="pessoa">Objeto do tipo Pessoa</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Pessoa pessoa)
        {
            if (pessoa != null)
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    this._PessoaRepository.Update(pessoa);
                    scope.Complete();

                    return new OkResult();
                }
            }

            return new NoContentResult();
        }

        // DELETE: Api/ApiWithActions/5
        /// <summary>
        /// Exclui uma pessoa do banco de dados.
        /// </summary>
        /// <param name="id">IP da pessoa a ser excluída</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Int32 id)
        {
            this._PessoaRepository.Delete(id);

            return new OkResult();
        }



    }
}