using System;

namespace Business.Models
{
    public class Product  : BaseEntity
    {        

        public Guid SupplierId { get; set; }        
        
        public string Name { get; set; }
       
        public string Description { get; set; }
   
        public string Image { get; set; }
 
        public decimal Price { get; set; }

        /*EF Relation*/
        public Supplier Supplier { get; set; } 

    }
}