using Dapper;
using DB1ChallangeFiapAPI.Model;
using DB1ChallangeFiapAPI.Repository.Interface;
using System.Data;
using System.Data.SqlClient;

namespace DB1ChallangeFiapAPI.Repository
{
    public class InterestRepository : IInterestRepository
    {
        private string getConnectionString()
        {
            return "Server=fiap-activities-server.database.windows.net;Database=db1challange;User Id=admindb;Password=Fiap@123;";
        }

        public async Task<int> CreateUserInterestsAsync(Interest interest)
        {
            using IDbConnection db = new SqlConnection(getConnectionString());
            const string sql = @"INSERT INTO tb_interest (userid, interest_name, interest_description,interest_category,interest_teach,interest_learn)
                                VALUES (@UserId, @InterestName, @InterestDescription,@InterestCategory,@InterestTeach,@InterestLearn);
                                SELECT CAST(SCOPE_IDENTITY() as int)";
            return await db.ExecuteScalarAsync<int>(sql, interest);

        }
    }
}
