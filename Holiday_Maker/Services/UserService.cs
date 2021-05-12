using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holiday_Maker.Models;
using Holiday_Maker.Repository;

namespace Holiday_Maker.Services
{
    public class UserService
    {
        private IGenericRepository<UserFavorite> _ufRepo;
        private IGenericRepository<Room> _roomRepo;
        public UserService()
        {
            _ufRepo = new GenericRepository<UserFavorite>();
            _roomRepo = new GenericRepository<Room>();
        }
        public async Task<IEnumerable<Room>> GetUserFavorites(int id)
        {
            var userFavorites = await _ufRepo.GetAll();
            var rooms = await _roomRepo.GetAll();

            var favoriteList = new List<UserFavorite>();
            var favoriteRooms = new List<Room>();

            foreach (var favorite in userFavorites)
            {
                if (favorite.UserId == id)
                {
                    favoriteList.Add(favorite);
                }
            }

            foreach(var favoriteRoom in favoriteList)
            {
                var favRoom = rooms.FirstOrDefault(r => r.Id.Equals(favoriteRoom.RoomId));
                favoriteRooms.Add(favRoom);
            }
            return favoriteRooms;
        }
        public void AddUserFavorite(UserFavorite userFavorite)
        {
            _ufRepo.Insert(userFavorite);
        }
    }
}
