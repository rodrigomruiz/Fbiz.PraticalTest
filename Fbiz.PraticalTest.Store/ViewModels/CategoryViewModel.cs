using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fbiz.PraticalTest.Store.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        [DisplayName("Categoria")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Preencher o Nome")]
        [MaxLength(200, ErrorMessage ="Máximo {0} caracteres")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Data Cadastro")]
        public DateTime RegistrationDate { get; set; }

        [DisplayName("Ativo?")]
        public bool Active { get; set; }

        public virtual IEnumerable<ProductViewModel> Product { get; set; }

        public virtual ICollection<CategoryViewModel> Itens { get; set; }
    }
}