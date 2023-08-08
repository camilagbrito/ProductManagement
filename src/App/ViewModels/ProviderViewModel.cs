using Business.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace App.ViewModels
{
    public class ProviderViewModel
    {
        [Key]
        public Guid Id {  get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = " O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; }

        [DisplayName("Documento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = " O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string IdentityCard { get; set; }

        [DisplayName("Tipo")]
        public ProviderType Type { get; set; }

        [DisplayName("Endereço")]
        public AddressViewModel Address { get; set; }

        [DisplayName("Ativo?")]
        public bool IsActive { get; set; }
        [DisplayName("Produtos")]
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
