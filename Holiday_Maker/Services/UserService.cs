using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        private readonly IGenericRepository<UserRating> _userRatingRepo;
        public UserService()
        {
            _ufRepo = new GenericRepository<UserFavorite>();
            _accomodationRepo = new GenericRepository<Accomodation>();
            _userRepo = new GenericRepository<User>();
            _userRatingRepo = new GenericRepository<UserRating>();
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

        public async Task<bool> UpdateUserInformation(User user)
        {

            var currentInfo = await _userRepo.GetById(user.Id);
            if (currentInfo != null)
            {
                currentInfo.FirstName = user.FirstName;
                currentInfo.LastName = user.LastName;
                currentInfo.Country = user.Country;
                currentInfo.City = user.City;
                currentInfo.StreetAddress = user.StreetAddress;
                currentInfo.ZipCode = user.ZipCode;
                currentInfo.Username = user.Username;
                await _userRepo.Update(currentInfo);
            }


            return true;
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

        public async Task<ActionResult<FavoriteHelper>> GetUserFavorites(int id)
        {
            var userFavorites = await _ufRepo.GetAll();
            var rooms = await _accomodationRepo.GetAll();
            var userRating = await _userRatingRepo.GetAll();

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

                var rating = userRating.Where(a => a.AccomodationId == favRoom.Id);

                var totalRating = 0;

                foreach (var rate in rating)
                {
                    totalRating += rate.Rating;
                }
                if (totalRating != 0)
                    totalRating = totalRating / rating.Count();

                favRoom.GuestRating = totalRating;

                favoriteAccomodations.Add(favRoom);
            }

            FavoriteHelper favoriteHelper = new FavoriteHelper();
            favoriteHelper.Accomodation = favoriteAccomodations;
            favoriteHelper.UserFavorite = favoriteList;

            return favoriteHelper;
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

        public async Task<bool> RemoveUserFavoriteList(UserFavorite listToRemove)
        {

            var favorites = _ufRepo.GetAll().Result.Where(u => u.UserId.Equals(listToRemove.UserId));

            foreach (var favorite in favorites)
            {
                if (favorite.GroupName == listToRemove.GroupName)
                {
                    await _ufRepo.Delete(favorite.Id);
                }
            }

            return true;
        }


        public async Task<bool> RegisterUser(User user)
        {

            var checkUser = _userRepo.GetAll().Result.FirstOrDefault(u => u.Email.Equals(user.Email));


            if (checkUser == null)
            {
                    user.MemberPoints = 100;
                    await _userRepo.Insert(user);
                    return true;
            }
            

            return false;
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
