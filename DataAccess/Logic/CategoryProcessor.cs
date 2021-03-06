using DataAccess.Access;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace DataAccess.Logic
{
    public static class CategoryProcessor
    {
        public static int CreateCategory(int id, string title, bool active, List<ClipModel> clip)
        {
            CategoryModel data = new CategoryModel
            {
                Id = id,
                Active = active,
                Title = title,
                Clip = clip
            };

            string sql = @"insert into dbo.Category (CategoryId, Title, Active, Clip)
                          values (@CategoryId, @Title, @Active, @Clip);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<CategoryModel> LoadCategories()
        {
            string sql = @"select CategoryId, Title, Active
                        from dbo.Category;";

            return SqlDataAccess.LoadData<CategoryModel>(sql);
        }
    }
}
