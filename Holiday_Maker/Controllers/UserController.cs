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
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return await _userService.GetUserById(id);
        }
        [HttpGet("favorites")]
        public async Task<ActionResult<IEnumerable<Accomodation>>> GetFavorites(int userId)
        {

            return await _userService.GetUserFavorites(userId);
        }
        
        [HttpPost("login")]
        public async Task<LoginHelper> Login(User user)
        {
            return await _userService.Login(user.Email, user.Password);
        }

        [HttpPost("register")]
        public string PostRegister(User user)
        {
           return _userService.RegisterUser(user);
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

        [HttpDelete("{id}")]
        public async Task<bool> RemoveUser(int id)
        {
            return await _userService.RemoveUser(id);
        }

        [HttpPost("UpdateMemberPoints")]
        public async Task<ActionResult<User>> UpdateMemberPoints(User user)
        {
            return await _userService.UpdateMemberPoints(user.Id, user.MemberPoints);
        }
    }
}
