using JeanetteDemoApp.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JeanetteDemoApp.Controllers
{
    public class CategoryController : ApiController
    {

        List<Category> category = new List<Category>();
        List<Clip> clip = new List<Clip>();
        public CategoryController()
        {
          
            clip.Add(new Clip
            {
                Title = "klipp tittel",
                CategoryId = 1,
                Hidden = false,
                Id = 1,
            });
            category.Add(new Category
            {
                Title = "Tittelen",
                Id = 1,
                Active = true,
                Clip = clip
            });
        }

        /// <summary>
        /// Gets a list of all categories
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="active">active</param>
        // GET api/values
        public List<Category> Get()
        {
            return category;
        }

        /// <summary>
        /// Gets a category by id
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="title">title</param>
        // GET api/values/5
        public Category Get(int id)
        {
            return category.Where(i => i.Id == id).FirstOrDefault();
            //try
            //{
            //    DataAccess.DataAccess.SqlDataAccess db = new DataAccess.DataAccess.SqlDataAccess();
            //    {
            //        category = db.GetCategories();
            //    }

            //    return category;
            //}
            //catch (Exception e)
            //{
            //    _logger.LogError("Error getting categories " + e.Message);
            //    return null;
            //}
        }

        /// <summary>
        /// Gets a category by id
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="title">title</param>
        // GET api/values/5
        [Route("api/category/GetClipsByCategory/{id}")]
        [HttpGet]
        public List<Clip> GetClipsByCategory(int id)
        {
            return clip.Where(i => i.CategoryId == id).ToList();         
        }

        // POST api/values
        //public void Post([FromBody] string value)
        //{
        //}

        public void Post(Category value)
        {
            category.Add(value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
