using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Fbiz.PraticalTest.Store.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        [DisplayName("Produto")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Preencher o Nome")]
        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Nome")]
        public string Name { get; set; }
        
        [AllowHtml]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [DisplayName("Categoria")]
        public int CategoryId { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Data de Registro")]
        public DateTime RegistrationDate { get; set; }

        [DisplayName("Ativo?")]
        public bool Active { get; set; }

        public virtual CategoryViewModel Category { get; set; }
    }
}