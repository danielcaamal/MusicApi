using Microsoft.AspNetCore.Mvc;
using MusicApi.Data;
using MusicApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private ApiDbContext _dbContext;

        public SongsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<SongsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Songs);
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var song = _dbContext.Songs.Find(id);
            if (song == null)
            {
                return NotFound();
            }
            return Ok(song);
        }

        // POST api/<SongsController>
        [HttpPost]
        public IActionResult Post([FromBody] Song song)
        {
            _dbContext.Songs.Add(song);
            _dbContext.SaveChanges();
            return Ok(song);
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Song newSong)
        {
            var oldSong = _dbContext.Songs.Find(id);
            if (oldSong == null)
            {
                return NotFound();
            }
            oldSong.Title = newSong.Title;
            oldSong.Language = newSong.Language;
            _dbContext.SaveChanges();
            return Ok(newSong);
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var song = _dbContext.Songs.Find(id);
            if (song == null)
            {
                return NotFound();
            }
            _dbContext.Songs.Remove(song);
            _dbContext.SaveChanges();
            return Ok(song);
        }
    }
}
