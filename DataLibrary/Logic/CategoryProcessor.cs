using DataLibrary.Access;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace DataLibrary.Logic
{
    public static class CategoryProcessor
    {
        public static void CreateCategory(int id, string title, bool active, ClipModel clip)
        {           

            CategoryModel data = new CategoryModel
            {
                Id = id,
                CategoryTitle = title,
                Active = active,     
                  Clips = new ClipModel
                  {
                      CategoryId = id,
                      Hidden = clip.Hidden,
                      Title = clip.Title
                  }
            };

            string sql = @"insert into dbo.Category (Id, CategoryTitle, Active, Clips)
                          values (@Id, @CategoryTitle, @Active, @Clips);";

            SqlDataAccess.SaveRecord(data); //.SaveData(sql, data);

        }

        public static List<CategoryModel> LoadCategories()
        {
            string sql = @"select Id, CategoryTitle, Active
                        from dbo.Category;";

            return SqlDataAccess.LoadData<CategoryModel>(sql);
        }
    }
}
