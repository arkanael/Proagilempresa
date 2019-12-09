using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProagilEmpresa.Application.Dtos
{
    public class ProdutoCadastroDto
    {
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "O campo {0} deve possuir no mínimo 2 caractérie e no máximo 500 caractéries")]
        public string Nome { get; set; }


        [Range(1, 120000, ErrorMessage = "O campo {0} de possuir no minimo 1 produto e no máximo 120000 produtos")]
        public int QtdeItensProduto { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        public double ValorUnitario { get; set; }

    }
}
