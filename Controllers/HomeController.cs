using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsAndCategories.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ProductsAndCategories.Controllers
{
    public class HomeController : Controller
    {

        private MyContext db;
        public HomeController(MyContext database)
        {
            db =database;
        }

        [HttpGet("products")]
        public IActionResult Products()
        {
            List<Product> allProducts = db.Products.ToList();
            ViewBag.AllProducts = allProducts;
            return View();
        }

        [HttpGet("categories")]

        public IActionResult Categories()
        {
            List<Category> AllCategories = db.Categories.ToList();
            ViewBag.AllCategories = AllCategories;
            return View();
        }

        [HttpPost("addcategory")]
        public IActionResult AddCategory(Category data)
        {

            db.Categories.Add(data);
            db.SaveChanges();
            return RedirectToAction("categories");
        }

        [HttpPost("addproduct")]
        public IActionResult AddProduct(Product data)
        {
            db.Products.Add(data);
            db.SaveChanges();
            return RedirectToAction("products");
        }

        [HttpGet("product/{ProductId}")]
        public IActionResult Product(int productId)
        {

            var product = db.Products
            .Include(x => x.Associations)
            .ThenInclude(x => x.category)
            .FirstOrDefault(x => x.ProductId == productId);

            List<Category> AllCategories = db.Categories.ToList();
            ViewBag.AllCategories = AllCategories;
            return View(product);
        }

        [HttpPost("addnewcategory")]
        public IActionResult AddNewCategory(Product data,  int id)
        {
        Association newAssociation = new Association();
        newAssociation.ProductId = id;
        newAssociation.CategoryId = data.CategoryId;
        db.Associations.Add(newAssociation);
        db.SaveChanges();

            
        return RedirectToAction("Products"); 
        }
    }
}
