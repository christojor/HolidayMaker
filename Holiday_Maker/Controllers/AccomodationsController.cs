using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holiday_Maker.Models;
using Holiday_Maker.Repository;

namespace Holiday_Maker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccomodationsController : ControllerBase
    {
        private IGenericRepository<Accomodation> _accomodationRepo;

        public AccomodationsController()
        {
            _accomodationRepo = new GenericRepository<Accomodation>();
        }


        [HttpGet]
        public IEnumerable<Accomodation> GetAll()
        {
            return _accomodationRepo.Get();
        }


    }
}
