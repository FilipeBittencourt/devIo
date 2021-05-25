using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class Address : BaseEntity
    {

      

        public Guid SupplierId { get; set; }
 
        public string Information { get; set; }

    
        public string Number { get; set; }

       
        public string Complement { get; set; }
 
        public string ZipCode { get; set; }


   
        public string Neighborhood { get; set; }

       
        public string City { get; set; }

    
        public string State { get; set; }


        /*EF Relation*/
        public Supplier Supplier { get; set; }
    }
}