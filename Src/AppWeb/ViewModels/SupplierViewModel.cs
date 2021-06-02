using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppWeb.ViewModels
{
    public class SupplierViewModel 
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa se entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Nome")]
        public string Name { get; set; }
        
        
        [DisplayName("Nome Fantasia")]
        public string FantasyName { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa se entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Documento")]
        public string Document { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [DisplayName("Tipo")]
        public int TypeSupplier { get; set; }

        [DisplayName("Ativo?")]
        public bool Active { get; set; }

        [DisplayName("Endereço")]
        public AddressViewModel Address { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }

}
