using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holiday_Maker.Models;
using Holiday_Maker.Repository;

namespace Holiday_Maker.Services
{
    public class RoomService
    {

        private readonly IGenericRepository<Room> _roomRepo;
        private readonly IGenericRepository<Accomodation> _accomodationRepo;
        private readonly IGenericRepository<AccomodationType> _accomodationTypeRepo;
        private readonly IGenericRepository<RoomType> _roomTypeRepo;

        public RoomService()
        {
            _roomRepo = new GenericRepository<Room>();
            _roomTypeRepo = new GenericRepository<RoomType>();
            _accomodationRepo = new GenericRepository<Accomodation>();
            _accomodationTypeRepo = new GenericRepository<AccomodationType>();
           
        }


        public async Task<Room> NestedRoom(int id)
        {
            var room = await _roomRepo.GetById(id);
            var roomType = await _roomTypeRepo.GetById(room.RoomTypeId);
            var accomodation = await _accomodationRepo.GetById(room.AccomodationId);
            var accomodationType = await _accomodationTypeRepo.GetById(accomodation.AccomodationTypeId);
            room.Accomodation = accomodation;
            room.RoomType = roomType;
            accomodation.AccomodationType = accomodationType;
            return room;
        }


        public async Task<IEnumerable<Room>> NestedRooms()
        {
            var rooms = await _roomRepo.GetAll();

            foreach(var room in rooms)
            {
                var accomodation = await _accomodationRepo.GetById(room.AccomodationId);
                room.Accomodation = accomodation;
                accomodation.AccomodationType = await _accomodationTypeRepo.GetById(accomodation.AccomodationTypeId);
                room.RoomType = await _roomTypeRepo.GetById(room.RoomTypeId);
            }

            return rooms;
        }

        public async Task<IEnumerable<Room>> NestedRoomsByAccomodationId(int accomodationId)
        {
            var rooms = await _roomRepo.GetAll();
            var accomodationsRooms = rooms.Where(r => r.AccomodationId.Equals(accomodationId));

            foreach(var accoRoom in accomodationsRooms)
            {
                accoRoom.RoomType = await _roomTypeRepo.GetById(accoRoom.RoomTypeId);
            }
            return accomodationsRooms;
        }
    }
}
