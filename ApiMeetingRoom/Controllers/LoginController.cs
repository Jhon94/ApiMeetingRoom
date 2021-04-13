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
    public class LoginController : ControllerBase
    {
        //Creamos una variable global de tipo RepositoryLogin para acceder a la misma
        //por medio de Dependencias
        private readonly RepositoryLogin _respositoryLogin;

        //Creamos el constructor y desde el mismo detectamos alguna exepcion en la data 
        public LoginController(RepositoryLogin repositoryLoging) 
        {
            _respositoryLogin = repositoryLoging ?? throw new ArgumentNullException(nameof(repositoryLoging));
        }

        //Obtenemos el usuario logueado por medio del Username y la Password
        [HttpGet("{UsernAme}/{Password}")]
        public async Task<List<LoginDto>> GetUser(string userName, string password)
        {
            return await _respositoryLogin.GetUser(userName, password );
        }
    }
}
