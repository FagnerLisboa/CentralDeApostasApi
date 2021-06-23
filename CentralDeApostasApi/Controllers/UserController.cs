using CentralDeApostasApi.ApplicationCore.Entities;
using CentralDeApostasApi.ApplicationCore.Model;
using CentralDeApostasApi.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CentralDeApostasApi.ApplicationCore.Interfaces.Service;
using CentralDeApostasApi.ApplicationCore.Models;
using CentralDeApostasApi.ApplicationCore.Entity;

namespace CentralDeApostasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost("InsertRegister")]
        public UserModel InsertRegister([FromBody] UserEntity user)
        {
            return this._userService.InsertRegister(user);
        }

        [HttpGet("GetById")]
        public UserModel GetById(int id)
        {
            return this._userService.GetById(id);
        }

        [HttpGet("GetByLogin")]
        public UserModel GetByLogin(string username)
        {
            return this._userService.GetByLogin(username);
        }

        [HttpGet("GetByEmail")]
        public UserModel GetByEmail(string email)
        {
            return this._userService.GetByEmail(email);
        }

        [HttpGet("GetByCell")]
        public UserModel GetByCell(long cell)
        {
            return this._userService.GetByCell(cell);
        }

        [HttpPut("UpdateUser")]
        public UserModel UpdateUser([FromBody] UserEntity user)
        {
            return this._userService.UpdateUser(user);
        }

        [HttpDelete("Delete")]
        public UserModel Delete(int id)
        {
            return this._userService.Delete(id);
        }
    }
}
