using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holiday_Maker.Models;
using Holiday_Maker.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Holiday_Maker.Services
{
    public class UserService : ControllerBase
    {
        private IGenericRepository<UserFavorite> _ufRepo;
        private IGenericRepository<Accomodation> _accomodationRepo;
        public UserService()
        {
            _ufRepo = new GenericRepository<UserFavorite>();
            _accomodationRepo = new GenericRepository<Accomodation>();
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
            var userFavorites = await _ufRepo.GetAll();
            foreach (var favorite in userFavorites)
            {
                if (favorite.UserId == userFavorite.UserId)
                {
                    if (favorite.AccomodationId != userFavorite.AccomodationId)
                    {
                        _ufRepo.Insert(userFavorite);
                    }
                }
            }
            return NotFound();
        }
    }
}
