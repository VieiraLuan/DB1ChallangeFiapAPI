﻿using Dapper;
using DB1ChallangeFiapAPI.Model;
using DB1ChallangeFiapAPI.Repository.Interface;
using System.Data;
using System.Data.SqlClient;

namespace DB1ChallangeFiapAPI.Repository
{
    public class BackgroundRepository : IBackgroundRepository
    {
      

        private string getConnectionString()
        {
            return "Server=fiap-activities-server.database.windows.net;Database=db1challange;User Id=admindb;Password=Fiap@123;";
        }

        public async Task<int> CreateBackgroundAsync(Background background)
        {
            using IDbConnection db = new SqlConnection(getConnectionString());
            
            const string sql = @"INSERT INTO tb_background (userid, background_name, background_description, universityname)
                                VALUES (@UserId, @Name, @Description, @UniversityName);
                                SELECT CAST(SCOPE_IDENTITY() as int)";

            return await db.ExecuteScalarAsync<int>(sql, background);
        }
    }
}
