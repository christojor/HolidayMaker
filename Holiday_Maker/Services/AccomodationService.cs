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
        private readonly IGenericRepository<Accomodation> _accomodationRepo;
        private readonly IGenericRepository<Room> _roomRepo;
        private readonly IGenericRepository<RoomType> _roomTypeRepo;
        private readonly IGenericRepository<Amenity> _amenityRepo;
        private readonly IGenericRepository<Extra> _extraRepo;
        private readonly IGenericRepository<AccomodationType> _accomodationTypeRepo;

        public AccomodationService()
        {
            var _accomodationRepo = new GenericRepository<Accomodation>();
            var _roomRepo = new GenericRepository<Room>();
            var roomTypeRepo = new GenericRepository<RoomType>();
            var amentityRepo = new GenericRepository<Amenity>();
            var _extraRepo = new GenericRepository<Extra>();
            var _acommodationTypeRepo = new GenericRepository<AccomodationType>();
        }

        public void ExampleMethod()
        {
            var somethingHappens = _accomodationRepo.GetAll();
        }

    }
}
