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
        public static int CreateCategory(int id, string title, bool active, List<ClipModel> clip)
        {
            var listOfClips = new List<ClipModel>();
            if(clip != null)
            {
                foreach (var c in clip)
                {
                    ClipModel clippi = new ClipModel
                    {
                        CategoryId = id,
                        Hidden = c.Hidden,
                        Title = c.Title,
                        Id = c.Id
                    };
                    listOfClips.Add(clippi);
                }
            }        
         
            CategoryModel data = new CategoryModel
            {
                Id = id,
                CategoryTitle = title,
                Active = active,                
                Clip = listOfClips
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
