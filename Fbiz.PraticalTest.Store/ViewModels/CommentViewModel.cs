using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fbiz.PraticalTest.Store.ViewModels
{
    public class CommentViewModel
    {
        [Key]
        [DisplayName("Comentario")]
        public int CommentId { get; set; }

        [DisplayName("Produto")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Preencher o Nome")]
        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Preencher o Titulo")]
        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Titulo")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Preencher o Texto")]
        [DisplayName("Texto")]
        public string Text { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Data Cadastro")]
        public DateTime RegistrationDate { get; set; }

        [DisplayName("Ativo?")]
        public bool Active { get; set; }

        public virtual ProductViewModel Product { get; set; }
    }
}