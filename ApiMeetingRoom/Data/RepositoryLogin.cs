using ApiMeetingRoom.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMeetingRoom.Data
{
    public class RepositoryLogin
    {
        private readonly string _connectionString;

        public RepositoryLogin(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<LoginDto>> GetUser(string userName, string password)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ConsultarUsuario", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UserName", userName));
                    cmd.Parameters.Add(new SqlParameter("@Password", password));
                    var response = new List<LoginDto>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToLogin(reader));
                        }
                    }
                    return response;
                }
            }
        }

        private LoginDto MapToLogin(SqlDataReader reader)
        {
            return new LoginDto()
            {

                UserName = reader["UserName"].ToString(),
                Password = reader["Password"].ToString(),
                Name = reader["Name"].ToString(),
                LastName = reader["LastName"].ToString(),
                RoleName = reader["RoleName"].ToString(),
                Status = (bool)reader["Status"],
                RoleId = (Guid)reader["RoleId"],
                UserId = (Guid)reader["UserId"],
            };
        } 
    }
}
