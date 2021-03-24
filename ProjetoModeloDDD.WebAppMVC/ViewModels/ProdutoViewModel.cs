using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.WebAppMVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        [DisplayName("ID")]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Campo {0} deve ser informado")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} deve ser informado")]

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999", ErrorMessage = "{0} dever ter entre {1} e {2}")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal Valor { get; set; }

        [DisplayName("Disponível?")]
        public bool Disponivel { get; set; }
        
        [DisplayName("Cliente")]
        public int ClienteId { get; set; }
        public virtual ClienteViewModel Cliente { get; set; }

        public string NomeCLiente { get; set; }
        public IEnumerable<SelectListItem> Clientes { get; set; }

    }
}
