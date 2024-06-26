﻿using Dapper;
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

        public async Task<int> CreateUserFirstStepAsync(User user)
        {
            using IDbConnection db = new SqlConnection(getConnectionString());

            const string sql = @"INSERT INTO tb_user (fullname, email, born_dt, cellphone, country, city, u_state, u_type_mentee,u_type_mentor, u_description)
                                VALUES (@Fullname, @Email, @BornDate, @Cellphone,@Country, @City, @State, @UserTypeMenteeFlag, @UserTypeMentorFlag, @UserDescription);
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

        public async Task<int> SetUserDetails(User user)
        {
            using IDbConnection db = new SqlConnection(getConnectionString());

            const string sql = @"UPDATE tb_user SET u_password = @Password , u_mentee_max = @MenteeMax, u_mentee_number = @MenteeeNumber, image_url = @ImageUrl WHERE id=@Id;";
            return await db.ExecuteAsync(sql, user);
        }
    }
}
