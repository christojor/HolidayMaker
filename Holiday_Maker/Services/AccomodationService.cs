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

        public async Task<Accomodation> NestedAccomodation(int id)
        {
            var accommodation = await _accomodationRepo.GetById(id);

            var roomList = await _roomRepo.GetAll();
            var rooms = roomList.Where(r => r.AccomodationId == accommodation.Id);

            var amenities = await _amenityRepo.GetAll();
            var extras = await _extraRepo.GetAll();
            accommodation.Amenities.Add(amenities.FirstOrDefault(a => a.AccomodationId == accommodation.Id));
            accommodation.Extras.Add(extras.FirstOrDefault(a => a.AccomodationId == accommodation.Id));

            foreach (var room in rooms)
            {
                room.RoomType = await _roomTypeRepo.GetById(room.RoomTypeId);
                accommodation.Rooms.Add(room);
            }

            return accommodation;

        }
        public IQueryable<Accomodation> SearchAccomodationById(int Id)
        {
            var accomodations = _accomodationRepo.GetAllRaw();

            if (accomodations.Any(s => s.AccomodationTypeId.Equals(Id)))
            {
                accomodations = accomodations.Where(s => s.AccomodationTypeId.Equals(Id));
            }
            else
            {
                accomodations = null;
            }
            return accomodations;
        }
        public IQueryable<Accomodation> SearchAccomodationByName(string keyWord)
        {
            var accomodations = _accomodationRepo.GetAllRaw();

            if (accomodations.Any(s => s.Name.Contains(keyWord)))
            {
                accomodations = accomodations.Where(s => s.Name.Contains(keyWord));
            }
            else
            {
                accomodations = null;
            }
            return accomodations;
        }
        public IQueryable<Accomodation> SearchAccomodationByCountryAndCity(string country, string city)
        {
            var accomodations = _accomodationRepo.GetAllRaw();

            if (accomodations.Any(s => s.Country.Equals(country)))
            {
                accomodations = accomodations.Where(s => s.Country.Contains(country));

                if (accomodations.Any(s => s.City.Equals(city)))
                {
                    accomodations = accomodations.Where(s => s.City.Contains(city));
                }
            }
            else
            {
                accomodations = null;
            }
            return accomodations;
        }

    }
}
