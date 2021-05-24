using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppWeb.ViewModels
{
    public class AddressViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [HiddenInput]
        public Guid SupplierId { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa se entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Logradouro")]
        public string Information { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa se entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Numero")]
        public string Number { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa se entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Complemento")]
        public string Complement { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [StringLength(8, ErrorMessage = "O campo {0} precisa se entre {2} e {1} caracteres", MinimumLength = 8)]
        [DisplayName("CEP")]
        public string ZipCode { get; set; }


        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa se entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Bairro")]
        public string Neighborhood { get; set; }


        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa se entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Cidade")]
        public string City { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa se entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Estado")]
        public string State { get; set; }

        /*EF Relation*/
        public SupplierViewModel Supplier { get; set; }
    }
}