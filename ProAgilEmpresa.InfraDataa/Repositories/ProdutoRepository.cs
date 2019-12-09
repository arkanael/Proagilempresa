using ProAgilEmpresa.Domain.Entities;
using ProAgilEmpresa.Domain.Interfaces.IRepositories;
using ProAgilEmpresa.InfraData.Context;
using System.Collections.Generic;
using System.Linq;

namespace ProAgilEmpresa.InfraData.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {

        private readonly ProAgilEmpresaContext context;

        public ProdutoRepository(ProAgilEmpresaContext context) : base(context)
        {
            this.context = context;
        }

        public override IEnumerable<Produto> ObterPorNome(string nome)
        {
            return context.Produtos.Where(x => x.Nome.Contains(nome));
        }
    }
}