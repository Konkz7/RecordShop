using Microsoft.AspNetCore.Mvc;
using RecordShop.Services;
using RecordShop.Models;

namespace RecordShop.Controllers
{
    [ApiController]
    [Route("api/albums")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public IActionResult GetAlbums()
        {
            return Ok(_albumService.GetAllAlbums());
        }

        [HttpGet("{id}")]
        public IActionResult GetAlbum(int id)
        {

            Album album = _albumService.GetAlbumById(id);
            
            if(album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        [HttpPost]
        public IActionResult PostAlbum(Album album)
        {
            Album newAlbum = _albumService.AddAlbum(album);

            if(newAlbum == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetAlbum) , new { Id = newAlbum.Id } , newAlbum);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAlbum(int id)
        {
            if (!_albumService.DeleteAlbum(id))
            {
                return BadRequest();
            }

            return NoContent();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateAlbum(int id , Album album)
        {
            return Ok(_albumService.UpdateAlbum(id,album));
        }

        [HttpGet("by-name")]
        public IActionResult GetByName([FromQuery] string name)
        {
            var albums = _albumService.GetAlbumByName(name);

            if (albums == null )
                return NotFound($"No albums found for genre: {name}");

            return Ok(albums);
        }

        [HttpGet("by-artist")]
        public IActionResult GetByArtist([FromQuery] string artist)
        {
            var albums = _albumService.GetAllAlbumsByArtist(artist);

            if (albums == null || !albums.Any())
                return NotFound($"No albums found for artist: {artist}");

            return Ok(albums);
        }

        
        [HttpGet("by-genre")]
        public IActionResult GetByGenre([FromQuery] Genre genre)
        {
            var albums = _albumService.GetAllAlbumsByGenre(genre);

            if (albums == null || !albums.Any())
                return NotFound($"No albums found for genre: {genre}");

            return Ok(albums);
        }

        
        [HttpGet("by-year")]
        public IActionResult GetByReleaseYear([FromQuery] int year)
        {
            var albums = _albumService.GetAllAlbumsByReleaseYear(year);

            if (albums == null || !albums.Any())
                return NotFound($"No albums found for year: {year}");

            return Ok(albums);
        }





    }
}
