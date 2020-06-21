using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using s16710_KolokwiumAPBD.Models;

namespace s16710_KolokwiumAPBD.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {

        private readonly DataBaseContext _context;

        public ArtistsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var artists = await _context.Artists.Select(artist => new {
                artist.IdArtist,
                artist.NickName,
                events = artist.ArtistEvents
                .OrderByDescending(artistEvent => artistEvent.Event.StartDate)
                .Select(artistEvent => new { artistEvent.Event.IdEvent, artistEvent.Event.Name, artistEvent.Event.StartDate, artistEvent.Event.EndDate })
            }).ToListAsync();

            return Ok(artists);
        }

        // GET api/Artists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var artists = await _context.Artists
                .Where(artist => artist.IdArtist.Equals(id))
                .Select(artist => new {
                    artist.IdArtist,
                    artist.NickName,
                    events = artist.ArtistEvents
                    .OrderByDescending(artistEvent => artistEvent.Event.StartDate)
                    .Select(artistEvent => new { artistEvent.Event.IdEvent, artistEvent.Event.Name, artistEvent.Event.StartDate, artistEvent.Event.EndDate, artistEvent.Event })
                }).FirstAsync();

                return Ok(artists);
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception);
                return NotFound("Nie znaleziono artysty");
            }
        }

        // POST: api/Artists
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Artists/5
        [HttpPut("{artistId}/events/{eventId}")]
        public async Task<IActionResult> Put(int eventID, int artistID, [FromBody] UpdateArtistEventRequest request)
        {
            
            var events = await _context.Events.FindAsync(eventID);

            if (events == null)

                return NotFound("Nie można odnaleźć eventu");

            var artists = await _context.Artists.FindAsync(artistID);

            if (artists == null)

                return NotFound("Nie można odnaleźć Artysty");


            if (events.EndDate < request.PerformanceDate || events.StartDate > request.PerformanceDate)

                return BadRequest("Data wykonania musi znajdować się między datą początkową a końcową");
            

            var artistEvent = await _context.ArtistsEvents.FindAsync(artists.IdArtist, eventID);

            artistEvent.PerformanceDate = request.PerformanceDate;

            await _context.SaveChangesAsync();

            return Ok(new UpdateArtistEventResponse
            {
                IdArtist = artists.IdArtist,
                IdEvent = events.IdEvent,
                PerformanceDate = request.PerformanceDate
            });
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
