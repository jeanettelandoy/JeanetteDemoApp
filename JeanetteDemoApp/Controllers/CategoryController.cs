using JeanetteDemoApp.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using static DataLibrary.Logic.CategoryProcessor;

namespace JeanetteDemoApp.Controllers
{

    public class CategoryController : ApiController
    {

        public CategoryController()
        {

        }

        /// <summary>
        /// Gets a list of all categories
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="active">active</param>
        // GET api/values
        [AllowAnonymous]
        [HttpGet]
        public List<Category> Get()
        {
            var list = new List<Category>();

            var result = LoadCategories();
            if (result.Any())
            {
                foreach (var item in result)
                {
                    var cat = new Category
                    {
                        Active = item.Active,
                        Id = item.Id,
                        CategoryTitle = item.CategoryTitle                      
                    };
                    list.Add(cat);
                }
            }
            return list;
      
        }

        /// <summary>
        /// Gets a category by id
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="title">title</param>
        // GET api/values/5
        public Category Get(int id)
        {
            var result = LoadCategories();
            result.Where(i => i.Id == id).FirstOrDefault();
            return new Category {
                Active = result.FirstOrDefault().Active,
                CategoryTitle = result.FirstOrDefault().CategoryTitle,
          
            }; 
        }

        /// <summary>
        /// Gets a category by id
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="title">title</param>
        // GET api/values/5
        [Route("api/category/GetClipsByCategory/{id}")]
        [HttpGet]
        public Clip GetClipsByCategory(int id)
        {
            return new Clip { };
            //return clip.Where(i => i.CategoryId == id);         
        }

        // POST api/values
        //public void Post([FromBody] string value)
        //{
        //}

        public void Post(Category value)
        {       
           
            var clip = new DataLibrary.Models.ClipModel
            {
                CategoryId = value.Id,
                Hidden = value.Clip.Hidden,
                Title = value.Clip.Title
            };

            CreateCategory(value.Id,
            value.CategoryTitle, value.Active, clip);           
                     
        }

    }
}
