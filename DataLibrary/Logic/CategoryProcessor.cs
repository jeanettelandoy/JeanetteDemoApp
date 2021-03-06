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


namespace DataLibrary.Logic
{
    public static class CategoryProcessor
    {
        public static int CreateCategory(int id, string title, bool active, ClipModel clip)
        {
            var clippy = new ClipModel 
            {
                CategoryId = id,
                Hidden = clip.Hidden,
                Title = clip.Title,
                Id = clip.Id
            };         
                              
         
            CategoryModel data = new CategoryModel
            {
                Id = id,
                CategoryTitle = title,
                Active = active,                
                Clip = clippy
            };

            string sql = @"insert into dbo.Category (Id, CategoryTitle, Active, Clips)
                          values (@Id, @CategoryTitle, @Active, @Clips);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<CategoryModel> LoadCategories()
        {
            string sql = @"select Id, CategoryTitle, Active, Clips
                        from dbo.Category;";

            return SqlDataAccess.LoadData<CategoryModel>(sql);
        }
    }
}
