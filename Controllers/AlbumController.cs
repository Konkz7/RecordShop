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



    }
}
