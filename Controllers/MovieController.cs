using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace modul10_103022300160.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> daftarFilm = new List<Movie>
        {
            new Movie("The Shawshank Redemption","Francis Ford Coppola",new List<string> {"Tim Robbins", "Morgan Freeman", "Bob Gunton"},"A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."),
            new Movie( "The Godfather","Frank Darabont",new List<string> {"Marlon Brando", "Al Pacino", "James Caan"},"The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."),
            new Movie("The Dark Knight","Christopher Nolan",new List<string> { "Christian Bale", "Heath Ledger", "Aaron Eckhart"},"When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness.")
        };
        [HttpGet]
        public ActionResult<List<Movie>> Get()
        { 
           return daftarFilm;
        }

        [HttpGet("{index}")]
        public ActionResult<Movie> Get(int index)
        {
            if (index < 0 || index >= daftarFilm.Count)
                return NotFound();
            return daftarFilm[index];
        }
        [HttpPost]
        public ActionResult<List<Movie>> Post([FromBody]Movie mv) 
        {
            daftarFilm.Add(mv);
            return Ok("Berhasil ditambahkan");
        }
        [HttpDelete("{index}")]
        public ActionResult<List<Movie>> Delete (int index)
        {
            if (index < 0 || index >= daftarFilm.Count)
                return NotFound();
            daftarFilm.RemoveAt(index);
            return Ok("Berhasil dihapus");
        }
    }
        
}