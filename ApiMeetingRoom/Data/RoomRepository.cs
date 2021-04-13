using ApiMeetingRoom.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMeetingRoom.Data
{
    public class RoomRepository
    {
        private readonly string _connectionString;

        public RoomRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<RoomDto>> GetRooms()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ConsultRooms", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<RoomDto>();
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

        private RoomDto MapToLogin(SqlDataReader reader)
        {
            return new RoomDto()
            {
                RoomId = (Guid)reader["RoomId"],
                RoomName = reader["RoomName"].ToString() 
            };
        }
    }
}

