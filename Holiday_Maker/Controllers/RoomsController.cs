using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holiday_Maker.Repository;
using Holiday_Maker.Models;

namespace Holiday_Maker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private IGenericRepository<Room> _roomRepo;

        public RoomsController()
        {
            _roomRepo = new GenericRepository<Room>();
        }

        [HttpGet]
        public async Task<IEnumerable<Room>> GetAll()
        {
            return await _roomRepo.GetAll();
        }
        

    }
}
