using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DailyJokesApp.Models;

namespace DailyJokesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly SampleDBContext _context;

        public JokesController(SampleDBContext context)
        {
            _context = context;
        }

        // GET: api/Jokes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jokes>>> GetJokes()
        {
            //return await _context.Jokes.ToListAsync();
            List<Jokes> list = new List<Jokes>();
            var model = await _context.Jokes.ToListAsync();
            foreach (var item in model) 
            { 
                list.Add(new Jokes { JokeId = item.JokeId, Question = item.Question, Username = item.Username, Answer = item.Answer, DateCreated = item.DateCreated, NumberOfLikes = item.NumberOfLikes });
            }
            return Ok(list);
        }

        // GET: api/Jokes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jokes>> GetJokes(int id)
        {
            var jokes = await _context.Jokes.FindAsync(id);

            if (jokes == null)
            {
                return NotFound();
            }

            return jokes;
        }

        // PUT: api/Jokes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJokes(int id, Jokes jokes)
        {
            if (id != jokes.JokeId)
            {
                return BadRequest();
            }

            _context.Entry(jokes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JokesExists(id))
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

        // POST: api/Jokes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jokes>> PostJokes(Jokes jokes)
        {
            _context.Jokes.Add(jokes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJokes", new { id = jokes.JokeId }, jokes);
        }

        // DELETE: api/Jokes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJokes(int id)
        {
            var jokes = await _context.Jokes.FindAsync(id);
            if (jokes == null)
            {
                return NotFound();
            }

            _context.Jokes.Remove(jokes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JokesExists(int id)
        {
            return _context.Jokes.Any(e => e.JokeId == id);
        }
    }
}
