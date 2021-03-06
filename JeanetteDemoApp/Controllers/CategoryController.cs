using JeanetteDemoApp.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static DataLibrary.Logic.CategoryProcessor;

namespace JeanetteDemoApp.Controllers
{
    public class CategoryController : ApiController
    {

        List<Category> category = new List<Category>();
        List<Clip> clip = new List<Clip>();
        public CategoryController()
        {

            //clip.Add(new Clip
            //{
            //    Title = "klipp tittel",
            //    CategoryId = 1,
            //    Hidden = false,
            //    Id = 1,
            //});
            //category.Add(new Category
            //{
            //    Title = "Tittelen",
            //    Id = 1,
            //    Active = true,
            //    Clip = clip
            //});
        }

        /// <summary>
        /// Gets a list of all categories
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="active">active</param>
        // GET api/values
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

          //  return category;
            //CreateCategory

            //try
            //{
            //    DataAccess.Access.SqlDataAccess db = new DataAccess.Access.SqlDataAccess()
            //    {
            //        category = db.();
            //        return category;
            //    }                
            //}
            //catch (Exception e)
            //{
            //    return null;
            //}
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
          
            }; result.FirstOrDefault();
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
            var listClips = new List<DataLibrary.Models.ClipModel>();
            if(value.Clip != null)
            {
                foreach (var cl in value.Clip)
                {
                    var clipp = new DataLibrary.Models.ClipModel()
                    {
                        CategoryId = value.Id,
                        Title = cl.Title,
                        Hidden = cl.Hidden,
                    };
                    listClips.Add(clipp);
                }
                    int created = CreateCategory(value.Id,
                value.CategoryTitle, value.Active, listClips);
            }
            else
            {
                int created = CreateCategory(value.Id,
                                value.CategoryTitle, value.Active, null);
            }
            
            //category.Add(value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
