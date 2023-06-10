using ECommerceWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace ECommerceWebsite.Controllers.API
{
    public class CategoryController : ApiController
    {
        MyDbContext DbContext;

        public CategoryController()
        {
            DbContext = new MyDbContext();
        }

        [HttpGet]
        public List<Catagory> GetCatagories()
        {
            return DbContext.Catagories.ToList();
        }

        [HttpGet]
        public List<SubCatagory> GetSubCatagories(int catagoryId)
        {
            return DbContext.SubCatagories.Include(a => a.Catagory).Where(s => s.Catagory.Id == catagoryId).ToList();
        }
    }
}
