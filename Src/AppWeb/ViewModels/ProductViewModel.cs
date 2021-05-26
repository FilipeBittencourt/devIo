using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWeb.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [DisplayName("Fornecedor")]
        public Guid SupplierId { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa se entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa se entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        
        [NotMapped]
        public IFormFile ImageUpload { get; set; }

        [DisplayName("Imagem")]
        public string Image { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [DisplayName("Preço")]
        public decimal Price { get; set; }

        
        [DisplayName("Ativo?")]
        public bool Active { get; set; }


        /*EF Relation*/
        [NotMapped]
        public SupplierViewModel Supplier { get; set; }

        [NotMapped]
        public IEnumerable<SupplierViewModel> Suppliers { get; set; }
    }
}