using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.WebAppMVC.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        [DisplayName("ID")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Campo {0} deve ser informado")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} deve ser informado")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Campo {0} deve ser informado")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        [EmailAddress(ErrorMessage ="Preencha um E-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Data Cadastro")]
        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }
        
        public virtual IEnumerable<ProdutoViewModel> Produtos { get; set; }

        [DisplayName("Nome Completo")]
        public string NomeCompleto
        {
            get
            {
                return $"{Nome} { Sobrenome}";
            }
            set
            {
                value = $"{Nome} { Sobrenome}";
            }
        }
    }
}
