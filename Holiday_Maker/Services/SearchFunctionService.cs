using Holiday_Maker.Models;
using Holiday_Maker.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holiday_Maker.Services
{
    public class SearchFunctionService
    {
        private ApplicationDbContext _ctx;
        private GenericRepository<Accomodation> _accomodationRepository;

        public SearchFunctionService()
        {
            _ctx = new ApplicationDbContext();
            _accomodationRepository = new GenericRepository<Accomodation>();
        }
        public IQueryable<Accomodation>SearchAccomodationById(int Id)
        {
            var accomodations = _accomodationRepository.GetAllRaw();

            if(accomodations.Any(s=>s.AccomodationTypeId.Equals(Id)))
            {
                accomodations = accomodations.Where(s => s.AccomodationTypeId.Equals(Id));
            }
            else
            {
                accomodations = null;
            }
            return accomodations;
        }
        public IQueryable<Accomodation>SearchAccomodationByName(string keyWord)
        {
            var accomodations = _accomodationRepository.GetAllRaw();

            if(accomodations.Any(s=>s.Name.Contains(keyWord)))
            {
                accomodations = accomodations.Where(s => s.Name.Contains(keyWord));
            }
            else
            {
                accomodations = null;
            }
            return accomodations;
        }
        public IQueryable<Accomodation>SearchAccomodationByCountryAndCity(string country)
        {
            var accomodations = _accomodationRepository.GetAllRaw();

            if(accomodations.Any(s=>s.Country.Equals(country)))
            {
                //if(accomodations.Any(s=>s.City.Equals(city)))
                //{
                    accomodations = accomodations.Where(s => s.Country.Contains(country));
               // }
            }
            else
            {
                accomodations = null;
            }
            return accomodations;
        }
    }
}
