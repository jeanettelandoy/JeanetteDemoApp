using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DataLibrary.Models;
using System.IO;

namespace DataLibrary.Access
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

           public static int CreateCategory(int id, string title, bool active, ClipModel clip)
        {
            CategoryModel data = new CategoryModel
            {
                Id = id,
                Active = active,
                CategoryTitle = title,
                Clips = clip
            };

            string sql = @"insert into dbo.Category (CategoryId, CategoryTitle, Active, Clips)
                          values (@CategoryId, @CategoryTitle, @Active, @Clips);";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {               
                return cnn.Execute(sql, data);
            }
        }
        public static void SaveRecord(CategoryModel model)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(model.Clips);

                SqlCommand command = new SqlCommand("dbo.Category", cnn);
                command.CommandType = CommandType.Text;
                command.CommandText = @"INSERT INTO dbo.Category(CategoryTitle,Active, Clips) 
                            VALUES(@CategoryTitle,@Active,@Clips)";


                command.Parameters.AddWithValue("@CategoryTitle", model.CategoryTitle);
                command.Parameters.AddWithValue("@Active", model.Active);
                command.Parameters.AddWithValue("@Clips", jsonString);

                try
                {
                    cnn.Open();
                    command.ExecuteNonQuery();
                    cnn.Close();
                }
                catch(SqlException ex)
                {

                }
            
                
            }
            
        }
    }
}
