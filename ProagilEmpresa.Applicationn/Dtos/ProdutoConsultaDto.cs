using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProAgilEmpresa.Application.Dtos
{
    public class ProdutoConsultaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int QtdeItensProduto { get; set; }
        public double ValorUnitario { get; set; }

    }
}
