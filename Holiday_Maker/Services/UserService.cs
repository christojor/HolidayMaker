using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holiday_Maker.Models;
using Holiday_Maker.Repository;
using Microsoft.AspNetCore.Mvc;
using Holiday_Maker.Helper;

namespace Holiday_Maker.Services
{
    public class UserService : ControllerBase
    {
        private IGenericRepository<UserFavorite> _ufRepo;
        private IGenericRepository<Accomodation> _accomodationRepo;
        private IGenericRepository<User> _userRepo;
        public UserService()
        {
            _ufRepo = new GenericRepository<UserFavorite>();
            _accomodationRepo = new GenericRepository<Accomodation>();
            _userRepo = new GenericRepository<User>();
        }

        public async Task<ActionResult<User>> GetUserById(int id)
        {

            var user = await _userRepo.GetById(id);
            if (user != null)
            {
                user.Password = null;
                return user;
            }
            return NotFound();
        }

        public async Task<bool> RemoveUser(int id)
        {
            var user = await _userRepo.GetById(id);
            if (user == null)
            {
                return false;
            }
            await _userRepo.Delete(id);
            return true;
        }

        public async Task<ActionResult<User>> UpdateMemberPoints(int id, int? memberPoints)
        {
            var getUser = await _userRepo.GetById(id);
            if (getUser == null)
            {
                return NotFound();
            }
            getUser.MemberPoints = memberPoints;

            await _userRepo.Update(getUser);

            return getUser;
        }

        public async Task<ActionResult<IEnumerable<Accomodation>>> GetUserFavorites(int id)
        {
            var userFavorites = await _ufRepo.GetAll();
            var rooms = await _accomodationRepo.GetAll();

            var favoriteList = new List<UserFavorite>();
            var favoriteAccomodations = new List<Accomodation>();

            foreach (var favorite in userFavorites)
            {
                if (favorite.UserId == id)
                {
                    favoriteList.Add(favorite);
                }
            }

            foreach (var favoriteAccomodation in favoriteList)
            {
                var favRoom = rooms.FirstOrDefault(r => r.Id.Equals(favoriteAccomodation.AccomodationId));
                favoriteAccomodations.Add(favRoom);
            }
            return favoriteAccomodations;
        }


        public async Task<ActionResult> AddUserFavorite(UserFavorite userFavorite)
        {
            var getUserFavorites = await _ufRepo.GetAll();
            var userFavorites = getUserFavorites.Where(favorite => favorite.UserId == userFavorite.UserId).ToList();

            var result = userFavorites.Exists(u => u.AccomodationId.Equals(userFavorite.AccomodationId));
            if (!result)
            {
                await _ufRepo.Insert(userFavorite);
            }
            return NotFound();
        }

        public async Task<ActionResult> RemoveUserFavorite(UserFavorite userFavorite)
        {
            var favorites = await _ufRepo.GetAll();
            var favorite = favorites.FirstOrDefault(f => f.UserId.Equals(userFavorite.UserId) && f.AccomodationId.Equals(userFavorite.AccomodationId));
            if (favorite != null)
            {
                await _ufRepo.Delete(favorite.Id);
            }
            return NotFound();
        }


        public async Task<string> RegisterUser(User user)
        {
            var checkUserList = await _userRepo.GetAll();

            if (checkUserList.Any(checkUser => checkUser.Email != user.Email))
            {
                user.MemberPoints = 100;
                await _userRepo.Insert(user);
                return "User successfully added!";
            }

            return "A user with this Email already exists! Try to login instead!";
        }
        internal async Task<LoginHelper> Login(string email, string password)
        {
            var users = await _userRepo.GetAll();
            var user = users.FirstOrDefault(u => u.Email.Equals(email) && u.Password.Equals(password));

            if (user != null)
            {
                return new LoginHelper() { LoggedInMessage = "You logged in successfully!", IsLoggedIn = true, UserId = user.Id };
            }

            return new LoginHelper() { LoggedInMessage = "User not found!", IsLoggedIn = false };
        }
    }
}
