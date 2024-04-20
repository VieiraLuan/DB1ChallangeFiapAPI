using Dapper;
using DB1ChallangeFiapAPI.Model;
using DB1ChallangeFiapAPI.Repository.Interface;
using System.Data;
using System.Data.SqlClient;

namespace DB1ChallangeFiapAPI.Repository
{
    public class ExperienceRepository : IExperienceRepository
    {


        private string getConnectionString()
        {
            return "Server=fiap-activities-server.database.windows.net;Database=db1challange;User Id=admindb;Password=Fiap@123;";
        }

        public async Task<int> CreateExperienceAsync(Experience experience)
        {
            using IDbConnection db = new SqlConnection(getConnectionString());

            const string sql = @"INSERT INTO tb_experience (userid, experience_name, experience_description, experience_time)
                           VALUES (@UserId, @Name, @Description, @Time);
                           SELECT CAST(SCOPE_IDENTITY() as int)";

            return await db.ExecuteScalarAsync<int>(sql, experience);

        }
    }
}
