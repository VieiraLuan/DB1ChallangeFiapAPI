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

            const string sql = @"INSERT INTO tb_user (fullname, email, born_dt, cellphone, city, u_state, u_type_mentee,u_type_mentor, u_password, u_description)
                                VALUES (@Fullname, @Email, @BornDate, @Cellphone, @City, @State, @UserTypeMenteeFlag, @UserTypeMentorFlag, @Password, @UserDescription);
                                SELECT CAST(SCOPE_IDENTITY() as int)";
            return await db.ExecuteScalarAsync<int>(sql, user);
        }

        public async Task<int> UpdateMenteeAsync(User user)
        {
            using IDbConnection db = new SqlConnection(getConnectionString());

            const string sql = @"UPDATE tb_user SET interest_id = @InterestId WHERE id = @Id";

            return await db.ExecuteAsync(sql, user);
        }

        public async Task<int> UpdateMentorAsync(User user)
        {
            using IDbConnection db = new SqlConnection(getConnectionString());

            const string sql = @"UPDATE tb_user SET interest_id = @InterestId, skill_id = @SkillId,
            experience_id = @ExperienceId, background_id = @BackgroundId, mentee_max = @MenteeMax WHERE id = @Id";

            return await db.ExecuteAsync(sql, user);
        }
    }
}
