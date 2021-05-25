using Holiday_Maker.Models;
using Holiday_Maker.Repository;
using Microsoft.EntityFrameworkCore;
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
        private readonly IGenericRepository<WifiQuality> _wifiQualityRepo = null;

        public AccomodationService()
        {
            _accomodationRepo = new GenericRepository<Accomodation>();
            _roomRepo = new GenericRepository<Room>();
            _roomTypeRepo = new GenericRepository<RoomType>();
            _amenityRepo = new GenericRepository<Amenity>();
            _extraRepo = new GenericRepository<Extra>();
            _accomodationTypeRepo = new GenericRepository<AccomodationType>();
            _wifiQualityRepo = new GenericRepository<WifiQuality>();
        }

        public async Task<IEnumerable<Accomodation>> NestedAccomodations()
        {
            var accommodationList = await _accomodationRepo.GetAll();
            var roomList = await _roomRepo.GetAll();
            var roomTypes = await _roomTypeRepo.GetAll();
            var amenityList = await _amenityRepo.GetAll();
            var extrasList = await _extraRepo.GetAll();
            var wifiQualities = await _wifiQualityRepo.GetAll();

            foreach (var amenity in amenityList)
            {
                var wifi = wifiQualities.FirstOrDefault(a => a.AmenityId == amenity.Id);
                if (wifi != null)
                {
                    amenity.WifiQualities.Add(wifi);
                }
                
            }


            foreach (var accommodation in accommodationList)
            {
                var amenities = amenityList.FirstOrDefault(a => a.AccomodationId == accommodation.Id);
                var extras = extrasList.FirstOrDefault(a => a.AccomodationId == accommodation.Id);

                var rooms = roomList.Where(r => r.AccomodationId == accommodation.Id);

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
            var wifiQuality = await _wifiQualityRepo.GetAll();

            foreach (var amenity in amenities)
            {
                var wifi = wifiQuality.FirstOrDefault(a => a.AmenityId == amenity.Id);
                if (wifi != null)
                {
                    amenity.WifiQualities.Add(wifi);
                }
            }


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
        public IQueryable<Accomodation> SearchAccomodationByCountryAndCity(string searchQuery)
        {
            var accomodations = _accomodationRepo.GetAllRaw();

            if (accomodations.Any(s => s.Country.Equals(searchQuery)))
            {
                accomodations = accomodations.Where(s => s.Country.Contains(searchQuery));
                accomodations = NestChildren(accomodations);
            }

            else if (accomodations.Any(s => s.City.Equals(searchQuery)))
                {
                    accomodations = accomodations.Where(s => s.City.Contains(searchQuery));
                    accomodations = NestChildren(accomodations);
                }
            else
            {
                accomodations = null;
            }

            return accomodations;
        }
        public async Task<IEnumerable<Accomodation>> NestedAccomodationsByTheme(string theme)
        {
            var accommodationList = await GetAllByTheme(theme);
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
        public async Task<IEnumerable<Accomodation>> GetAllByTheme(string theme)
        {
            var accommodationList = await _accomodationRepo.GetAll();
            return accommodationList.Where(a => a.ThemeType == theme);
        }

        public IQueryable<Accomodation> NestChildren(IQueryable<Accomodation> accomodations)
        {
            var accommodationList = accomodations;
            var roomList = _roomRepo.GetAllRaw();
            var roomTypes = _roomTypeRepo.GetAllRaw();
            var amenityList = _amenityRepo.GetAllRaw();
            var extrasList = _extraRepo.GetAllRaw();

            foreach (var accommodation in accommodationList)
            {
                var amenities = amenityList.FirstOrDefault(a => a.AccomodationId == accommodation.Id);
                var extras = extrasList.FirstOrDefault(a => a.AccomodationId == accommodation.Id);

                var rooms = roomList.Where(r => r.AccomodationId == accommodation.Id);

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
