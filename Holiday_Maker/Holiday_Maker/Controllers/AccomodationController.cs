using Holiday_Maker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holiday_Maker.Repository;

namespace Holiday_Maker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccomodationController : ControllerBase
    {
        private IGenericRepository<Accomodation> _aRepo;
        public AccomodationController()
        {
            _aRepo = new GenericRepository<Accomodation>();

        }
        [HttpGet]
        public IEnumerable<Accomodation> GetAccomodations()
        {
            return _aRepo.Get();
        }
    }
}
