using ECommerceWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ECommerceWebsite.Controllers.API
{
    public class ProductController : ApiController
    {
        MyDbContext DbContext;

        public ProductController()
        {
            DbContext = new MyDbContext();
        }


        [HttpGet]
        
        public List<Product> getAllProducts()
        {
            return DbContext.Products.ToList();
        }

        [HttpGet]
        public List<Product> getProductBySubCategory(SubCatagory subCatagory)
        {
            return DbContext.Products.Where(p => p.SubCatagory == subCatagory).ToList();
        }

        [HttpGet]
        public List<Product> searchProduct(String name)
        {
            var foundProducts = DbContext.Products.Where(a => a.Name.Contains(name)).ToList();

            if (foundProducts.Any())
            {
                return foundProducts;
            }
            return null;

        }

    }
}
