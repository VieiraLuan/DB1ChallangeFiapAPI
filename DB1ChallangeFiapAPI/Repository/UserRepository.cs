using Dapper;
using DB1ChallangeFiapAPI.Model;
using DB1ChallangeFiapAPI.Repository.Interface;
using System.Data;
using System.Data.SqlClient;

namespace DB1ChallangeFiapAPI.Repository
{
    public class UserRepository : IUserRepository
    {

        private string getConnectionString()
        {
            return "Server=fiap-activities-server.database.windows.net;Database=db1challange;User Id=admindb;Password=Fiap@123;";
        }

        public async Task<int> CreateUserAsync(User user)
        {
            using IDbConnection db = new SqlConnection(getConnectionString());

            const string sql = @"INSERT INTO tb_user (fullname, email, born_dt, cellphone, city, u_state, u_type, u_password)
                                VALUES (@Fullname, @Email, @BornDate, @Cellphone, @City, @State, @UserType, @Password);
                                SELECT CAST(SCOPE_IDENTITY() as int)";
            return await db.ExecuteScalarAsync<int>(sql, user);
        }



    }
}
