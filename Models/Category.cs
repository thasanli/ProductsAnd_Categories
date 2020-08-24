using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace ProductsAndCategories.Models
{
    public class Category
    {
        [Key]
        public int CategoryId{get;set;}
        public string CategoryName {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public List<Association> Associations {get;set;}

        
    }
}