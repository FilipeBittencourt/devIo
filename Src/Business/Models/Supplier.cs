using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{

    //Fornecedor/Supplier
    public class Supplier : BaseEntity
    { 
        

        public string Name { get; set; }
  
        public string Document { get; set; }
  
        public TypeSupplier TypeSupplier { get; set; }
       
        public Address Address { get; set; }

        public IEnumerable<Product> Product { get; set; }
    }

    public enum TypeSupplier
    {
        F = 1, // Phisical
        J = 2  // Juridical
    }

}