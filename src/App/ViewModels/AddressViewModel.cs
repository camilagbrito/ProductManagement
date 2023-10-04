using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class AddressViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Logradouro")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = " O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Street { get; set; }

        [DisplayName("Número")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = " O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Number { get; set; }

        [DisplayName("Complemento")]
        public string AddressSupplement { get; set; }

        [DisplayName("Código Postal")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(8, ErrorMessage = " O campo {0} precisa ter {2} caracteres", MinimumLength = 7)]
        public string ZipCode { get; set; }

        [DisplayName("Localidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = " O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string District { get; set; }

        [DisplayName("Concelho")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = " O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string City { get; set; }

        [DisplayName("Distrito")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = " O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string State { get; set; }

        [HiddenInput]
        public Guid SupplierId { get; set; }
    }
}
