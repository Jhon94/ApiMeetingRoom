using ApiMeetingRoom.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMeetingRoom.Data
{
    public class BookingRepository
    {
        private readonly string _connectionString;

        public BookingRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<BookingDto>> GetListBooking(Guid userId, Guid roleId)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ConsultBooking", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UserId", userId.ToString()));
                    cmd.Parameters.Add(new SqlParameter("@RoleId", roleId.ToString()));
                    var response = new List<BookingDto>();
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

        public async Task CreateBooking(BookingDto booking)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CrearReserva", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@DateOfAdmission", booking.DateOfAdmission));
                    cmd.Parameters.Add(new SqlParameter("@DeapertureDate", booking.DeapertureDate));
                    cmd.Parameters.Add(new SqlParameter("@RoomsId", booking.RoomsId));
                    cmd.Parameters.Add(new SqlParameter("@Status", booking.Status));
                    cmd.Parameters.Add(new SqlParameter("@UserId", booking.UserId));
                    cmd.Parameters.Add(new SqlParameter("@Catering", booking.Catering));
                    ;
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }

        public async Task UpdateBooking(BookingDto booking)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {

                using (SqlCommand cmd = new SqlCommand("sp_UpdateBooking", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@DateOfAdmission", booking.DateOfAdmission));
                    cmd.Parameters.Add(new SqlParameter("@DeapertureDate", booking.DeapertureDate));
                    cmd.Parameters.Add(new SqlParameter("@RoomsId", booking.RoomsId));
                    cmd.Parameters.Add(new SqlParameter("@Status", booking.Status));
                    cmd.Parameters.Add(new SqlParameter("@Catering", booking.Catering));
                    cmd.Parameters.Add(new SqlParameter("@BookingId", booking.BookingId));
                    ;
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }

        private BookingDto MapToLogin(SqlDataReader reader)
        {
            return new BookingDto()
            {
                BookingId = (Guid)reader["BookingId"],
                Catering = (bool)reader["Catering"],
                DateOfAdmission = (DateTime)reader["DateOfAdmission"],
                DeapertureDate = (DateTime)reader["DeapertureDate"],
                RoomsId = (Guid)reader["RoomsId"],
                Status = (bool)reader["Status"],
                UserId = (Guid)reader["UserId"]

            };
        }
    }
}
