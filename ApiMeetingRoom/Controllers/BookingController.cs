using ApiMeetingRoom.Data;
using ApiMeetingRoom.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMeetingRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        //Creamos una variable global de tipo BookingRepository para acceder a la misma
        //por medio de Dependencias
        private readonly BookingRepository _bookingRepository;

        //Creamos el constructor y desde el mismo detectamos alguna exepcion en la data 
        public BookingController(BookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
        }

        // Obtenemos la informacion de las reservas
        [HttpGet("{UserId}/{RoleId}")]
        public async Task<List<BookingDto>> ListBooking(Guid UserId, Guid RoleId)
        {
            return await _bookingRepository.GetListBooking(UserId, RoleId);
        }

        // Este api crea una nueva reserva
        [HttpPost]
        public async Task CreateBooking([FromBody] BookingDto booking)
        {
            try
            {
                await _bookingRepository.CreateBooking(booking);
            }
            catch (Exception ex)
            {

            }
        }
        // Actualizamos la informacion de la reserva
        [HttpPut]
        public async Task UpdateBooking([FromBody] BookingDto booking)
        {
            try
            {
                await _bookingRepository.UpdateBooking(booking);
            }
            catch (Exception ex)
            {

            }
        }

        // Actualizamos el estado de State a 0 desde el front
        [HttpDelete]
        public async Task DeleteBooking([FromBody] BookingDto booking)
        {
            try
            {
                await _bookingRepository.UpdateBooking(booking);
            }
            catch (Exception ex)
            {

            }
        }
    }
}

