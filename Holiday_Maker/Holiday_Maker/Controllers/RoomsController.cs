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
    public class RoomsController : ControllerBase
    {
        private IGenericRepository<Room> _rRepo;


        public RoomsController()
        {
            _rRepo = new GenericRepository<Room>();
        }



        [HttpGet]
        public IEnumerable<Room> GetRooms()
        {
            return _rRepo.Get();
        }
    }
}
