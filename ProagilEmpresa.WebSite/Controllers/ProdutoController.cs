using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProagilEmpresa.Application.Dtos;
using ProAgilEmpresa.Application.Dtos;
using ProAgilEmpresa.Application.IAppServices;
using ProAgilEmpresa.Domain.Entities;
using ProAgilEmpresa.Domain.Interfaces.IRepositories;

namespace ProagilEmpresa.WebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;

        private readonly IProdutoRepository _produtoRepository;

        private readonly IMapper _mapper;


        public ProdutoController(IProdutoAppService produtoAppService, IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoAppService = produtoAppService;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        //GET api/Produto
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var produtos =  _produtoRepository.ObterTodos();

                var results = _mapper.Map<ProdutoConsultaDto[]>(produtos);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um falha ao acessar o banco de dados");
            }
        }

        // GET api/Produto/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var produtos = _produtoRepository.ObterPorId(id);
                var result = _mapper.Map<ProdutoConsultaDto>(produtos);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro no banco de dados");
            }
        }

        [HttpGet("getByNome/{nome}")]
        public IActionResult Get(string nome)
        {
            try
            {
                var produtos = _produtoRepository.ObterPorNome(nome);
                var result = _mapper.Map<IEnumerable<ProdutoConsultaDto>>(produtos);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro no banco de dados");
            }
        }


        [HttpPost]
        public  IActionResult Post(ProdutoCadastroDto model)
        {
            try
            {
                var produto = _mapper.Map<Produto>(model);
                _produtoRepository.Adicionar(produto);

                if (_produtoRepository.SaveChanges() > 0)
                {
                    return Created($"api/Produto/{produto.Id}", _mapper.Map<ProdutoConsultaDto>(produto));
                }
            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um falha ao acessar o banco de dados " + e.Message);
            }

            return StatusCode(StatusCodes.Status403Forbidden, $"Ocorreu um erro ao inserir {model}");
        }


        [HttpPut("{Id}")]
        public IActionResult Put(int Id, ProdutoEdicaoDto model)
        {
            try
            {
                var produto = _produtoRepository.ObterPorId(Id);
                if (produto == null) return NotFound();


                _mapper.Map(model, produto);
                _produtoRepository.Atualizar(produto);

                if (_produtoRepository.SaveChanges() > 0)
                {
                    return Created($"/api/Produto/{produto.Id}", _mapper.Map<ProdutoConsultaDto>(produto));
                }
            }
            catch (System.Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro no banco de dados");
            }

            return BadRequest();
        }

        [HttpDelete("{produtoid}")]
        public IActionResult Delete(int produtoid)
        {
            try
            {
                var produtoDB = _produtoRepository.ObterPorId(produtoid);
                if (produtoDB == null) return NotFound();

                _produtoRepository.Remover(produtoDB);
                if (_produtoRepository.SaveChanges() > 0) return Ok();
            }


            catch (System.Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro no banco de dados");
            }

            return BadRequest();
        }
    }
}
   
