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
        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        //Gets a user with a specific user id.
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return await _userService.GetUserById(id);
        }

        //Gets a user favorite with a specific Id.
        [HttpGet("favorites")]
        public async Task<ActionResult<FavoriteHelper>> GetFavorites(int userId)
        {

            return await _userService.GetUserFavorites(userId);
        }
        
        //Login method to login the user. Takes a user object.
        [HttpPost("login")]
        public async Task<LoginHelper> Login(User user)
        {
            return await _userService.Login(user.Email, user.Password);
        }

        //Registers a new user, with a user object.
        [HttpPost("register")]
        public async Task<bool> PostRegister(User user)
        {
           return await _userService.RegisterUser(user);
        }

        //Adds a user favorite to the Db, with a favorite object.
        [HttpPost("favorites")]
        public async void PostFavorite(UserFavorite userFavorite)
        {
            await _userService.AddUserFavorite(userFavorite);
        }

        //Deletes a user favorite..
        [HttpDelete("favorites")]
        public async void Delete(UserFavorite userFavorite)
        {
            await _userService.RemoveUserFavorite(userFavorite);
        }

        [HttpDelete("favorites/removelist")]
        public async Task<bool> DeleteFavoriteList(int userId, string groupName)
        {
            return await _userService.RemoveUserFavoriteList(userId, groupName);
        }

        //Deletes user from db with a specific userId..
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
