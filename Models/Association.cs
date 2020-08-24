using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace ProductsAndCategories.Models
{
    public class Association
    {
        [Key]
        public int AssociationId{get;set;}
        public int ProductId{get;set;}
        public int CategoryId{get;set;}
        public Product product {get;set;}
        public Category category {get;set;}

    }
}