using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DataAccess.Models;

namespace DataAccess.Access
{
    public class SqlDataAccess
    {
        public static string GetConnectionString(string ConnectionName = "JeanetteDemoDB")
        {
            return ConfigurationManager.ConnectionStrings[ConnectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

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

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }
    }
}
