using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace ProductsAndCategories.Models
{
    public class Product
    {

        [Key]
        public int ProductId{get;set;}
        public string ProductName {get;set;}
        public string Description {get;set;}
        public float Price {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public List<Association> Associations {get;set;}

        [NotMapped]
        public int CategoryId{get;set;}
        
    }
}