using Holiday_Maker.Models;
using Holiday_Maker.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holiday_Maker.Services
{
    public class AccomodationsService
    {
        private IGenericRepository<Accomodation> _accomodationRepo;
        public AccomodationsService()
        {
            _accomodationRepo = new GenericRepository<Accomodation>();
        }
        public async Task<IEnumerable<Accomodation>> GetAllByTheme(string theme)
        {
            var accommodationList = await _accomodationRepo.GetAll();
            return accommodationList.Where(a => a.ThemeType == theme);
        }
    }
}
