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
    public class RoomController
    {
        //Creamos una variable global de tipo RoomRepository para acceder a la misma
        //por medio de Dependencias
        private readonly RoomRepository _roomRepository;
        //Creamos el constructor y desde el mismo detectamos alguna exepcion en la data 
        public RoomController(RoomRepository roomRepository)
        {
            _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
        }
        // Obtenemos la lista de las salas 
        [HttpGet("")]
        public async Task<List<RoomDto>> GetRooms()
        {
            return await _roomRepository.GetRooms();
        }
    }
}
