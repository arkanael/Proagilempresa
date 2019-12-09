using System;
using System.Collections.Generic;
using System.Text;

namespace ProAgilEmpresa.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }


        public int QtdeItensProduto { get; set; }

        public double ValorUnitario { get; set; }

        public void AtualizarDados(Produto produto)
        {
            Nome = produto.Nome;
            QtdeItensProduto = produto.QtdeItensProduto;
            ValorUnitario = produto.ValorUnitario;

        }

    }
}
