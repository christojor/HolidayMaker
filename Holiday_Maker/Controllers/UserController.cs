using Holiday_Maker.Models;
using Holiday_Maker.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holiday_Maker.Services;
using Holiday_Maker.Helper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Holiday_Maker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IGenericRepository<UserFavorite> _uRepo;
        private UserService _userService;

        public UserController()
        {
            _uRepo = new GenericRepository<UserFavorite>();
            _userService = new UserService();
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("favorites")]
        public async Task<ActionResult<IEnumerable<Accomodation>>> GetFavorites(int userId)
        {

            return await _userService.GetUserFavorites(userId);
        }



        //[HttpGet("login")]
        //public async Task<LoginHelper> GetStuff(string username, string password)
        //{
        //    return await _userService.Login(username, password);
        //}

        [HttpPost("login")]
        public async Task<LoginHelper> Login(string email, string password)
        {
            return await _userService.Login(email, password);
        }

        [HttpPost("register")]
        public void PostRegister(User user)
        {
           _userService.RegisterUser(user);
        }


        [HttpPost("favorites")]
        public async void PostFavorite(UserFavorite userFavorite)
        {
            await _userService.AddUserFavorite(userFavorite);
        }
        // DELETE api/<UserController>/5
        [HttpDelete("favorites")]
        public async void Delete(UserFavorite userFavorite)
        {
            await _userService.RemoveUserFavorite(userFavorite);
        }
    }
}
