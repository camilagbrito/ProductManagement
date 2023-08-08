using Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = " O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = " O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Description { get; set; }

        public IFormFile Image { get; set; }

        [DisplayName("Imagem")]
        public string ImageUpload { get; set; }

        [DisplayName("Valor")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Price { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Data de Cadastro")]
        public DateTime RegistrationDate { get; set; }

        [DisplayName("Ativo?")]
        public bool IsActive { get; set; }
        [DisplayName("Fornecedores")]
        public ProviderViewModel Provider { get; set; }
    }
}
