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
            return "Server=fiap-activities-server.database.windows.net;Database=db1challange;User Id=admindb;Password=Blablabal;";
        }

        public async Task<int> CreateUserAsync(User user)
        {
            using IDbConnection db = new SqlConnection(getConnectionString());

            const string sql = @"INSERT INTO tb_user (fullname, email, born_dt, cellphone, city, u_state, u_type_mentee,u_type_mentor, u_password, u_description)
                                VALUES (@Fullname, @Email, @BornDate, @Cellphone, @City, @State, @UserTypeMenteeFlag, @UserTypeMentorFlag, @Password, @UserDescription);
                                SELECT CAST(SCOPE_IDENTITY() as int)";
            return await db.ExecuteScalarAsync<int>(sql, user);
        }      

        public async Task<int> AuthUserAsync(User user)
        {
            using IDbConnection db = new SqlConnection(getConnectionString());
            //Change count for 1
            const string sql = @"SELECT COUNT(*) FROM tb_user WHERE email = @Email AND 
            u_password = @Password AND (u_type_mentee = @UserTypeMenteeFlag OR u_type_mentor = @UserTypeMentorFlag)";

            return await db.ExecuteScalarAsync<int>(sql, user);


        }
    }
}
