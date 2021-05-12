using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Holiday_Maker.Models;
using Holiday_Maker.Repository;
using Holiday_Maker.Services;

namespace Holiday_Maker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccomodationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IGenericRepository<Accomodation> _accomodationRepo;
        private readonly IGenericRepository<Room> _roomRepo;
        private readonly IGenericRepository<RoomType> _roomTypeRepo;

        private readonly AccomodationService _accomodationService;

        public AccomodationsController(ApplicationDbContext context)
        {
            _context = context;

            // Repos
            _accomodationRepo = new GenericRepository<Accomodation>();
            _roomRepo = new GenericRepository<Room>();
            _roomTypeRepo = new GenericRepository<RoomType>();

            // Services
            _accomodationService = new AccomodationService();
            
        }

        // GET: api/Accomodations
        [HttpGet]
        public async Task<IEnumerable<Accomodation>> GetAccomodations()
        {
            return await _accomodationService.NestedAccomodations();
        }

        // GET: api/Accomodations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accomodation>> GetAccomodation(int id)
        {
            var accomodation = await _accomodationService.NestedAccomodation(id);

            if (accomodation == null)
            {
                return NotFound();
            }

            return accomodation;
        }

        // PUT: api/Accomodations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccomodation(int id, Accomodation accomodation)
        {
            if (id != accomodation.Id)
            {
                return BadRequest();
            }

            _context.Entry(accomodation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccomodationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Accomodations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Accomodation>> PostAccomodation(Accomodation accomodation)
        {
            _context.Accomodations.Add(accomodation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccomodation", new { id = accomodation.Id }, accomodation);
        }

        // DELETE: api/Accomodations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccomodation(int id)
        {
            var accomodation = await _context.Accomodations.FindAsync(id);
            if (accomodation == null)
            {
                return NotFound();
            }

            _context.Accomodations.Remove(accomodation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccomodationExists(int id)
        {
            return _context.Accomodations.Any(e => e.Id == id);
        }

        private SearchFunctionService _searchFunctionService = new SearchFunctionService();

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Accomodation>>> Search(string country, string city)
        {
            var accomodation = _searchFunctionService.SearchAccomodationByCountryAndCity(country, city);
            if(accomodation !=null)
            {
                return await accomodation.ToListAsync();
            }
            return NotFound();
        }
    }
}
