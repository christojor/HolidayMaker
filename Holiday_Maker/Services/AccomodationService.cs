using Holiday_Maker.Models;
using Holiday_Maker.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holiday_Maker.Services
{
    public class AccomodationService
    {
        private readonly IGenericRepository<Accomodation> _accomodationRepo = null;
        private readonly IGenericRepository<Room> _roomRepo = null;
        private readonly IGenericRepository<RoomType> _roomTypeRepo = null;
        private readonly IGenericRepository<Amenity> _amenityRepo = null;
        private readonly IGenericRepository<Extra> _extraRepo = null;
        private readonly IGenericRepository<AccomodationType> _accomodationTypeRepo = null;

        public AccomodationService()
        {
            _accomodationRepo = new GenericRepository<Accomodation>();
            _roomRepo = new GenericRepository<Room>();
            _roomTypeRepo = new GenericRepository<RoomType>();
            _amenityRepo = new GenericRepository<Amenity>();
            _extraRepo = new GenericRepository<Extra>();
            _accomodationTypeRepo = new GenericRepository<AccomodationType>();
        }

        public async Task<IEnumerable<Accomodation>> NestedAccomodations()
        {
            var accommodationList = await _accomodationRepo.GetAll();
            var roomList = await _roomRepo.GetAll();
            var roomTypes = await _roomTypeRepo.GetAll();
            var amenityList = await _amenityRepo.GetAll();
            var extrasList = await _extraRepo.GetAll();

            foreach (var accommodation in accommodationList)
            {
                var rooms = roomList.Where(r => r.AccomodationId == accommodation.Id);
                var amenities = amenityList.FirstOrDefault(a => a.AccomodationId == accommodation.Id);
                var extras = extrasList.FirstOrDefault(a => a.AccomodationId == accommodation.Id);

                accommodation.Amenities.Add(amenities);
                accommodation.Extras.Add(extras);

                foreach (var room in rooms)
                {
                    room.RoomType = roomTypes.FirstOrDefault(rt => rt.Id == room.RoomTypeId);
                    accommodation.Rooms.Add(room);
                }
            }

            return accommodationList;
        }

    }
}
