using Microsoft.IdentityModel.Tokens;
using RecordShop.Data;
using RecordShop.Models;
using Microsoft.EntityFrameworkCore;



namespace RecordShop.Repository
{

    public interface IAlbumModel
    {
        public List<Album> GetAllAlbums();
        public Album GetAlbumById(int id);
        public Album AddAlbum(Album album);
        public Album UpdateAlbum(int id, AlbumDto album);
        public bool DeleteAlbum(int id);

    }
    public class AlbumModel : IAlbumModel
    {
        private MyDbContext _dbContext;
        public AlbumModel(MyDbContext db)
        {
            _dbContext = db;
        }

        public List<Album> GetAllAlbums()
        {
            return _dbContext.Albums.ToList();
        }

        public Album GetAlbumById(int id)
        {
            return _dbContext.Albums.FirstOrDefault(x => x.Id == id);
        }

        public Album AddAlbum(Album album)
        {
            DbSet<Album> albums = _dbContext.Albums;
            int newId = albums.Any() ? albums.Max(x => x.Id) + 1 : 1;

            if (album.ReleaseYear < 1000 || album.ReleaseYear > 2026)
                throw new ArgumentException("Invalid year");

            album.Id = newId;   

            albums.Add(album);

            _dbContext.SaveChanges();

            return album;
        }

        public bool DeleteAlbum(int id)
        {
            DbSet<Album> albums = _dbContext.Albums;
            if(!albums.Where(x => x.Id == id).Any())
            {
                return false;
            }
            albums.Remove(GetAlbumById(id));
            
            
            _dbContext.SaveChanges();

            return true ;
        }

        public Album UpdateAlbum(int id , AlbumDto album)
        {
            Album updated = GetAlbumById(id);

            if (album.ReleaseYear < 1000 || album.ReleaseYear > 2026)
                throw new ArgumentException("Invalid year");

            updated.Artist = album.Artist.IsNullOrEmpty() ? updated.Artist : album.Artist;
            updated.Title = album.Title.IsNullOrEmpty() ? updated.Title : album.Title;
            updated.Price = album.Price.GetValueOrDefault(updated.Price);
            updated.ReleaseYear = album.ReleaseYear.GetValueOrDefault(updated.ReleaseYear);
            updated.Genre = album.Genre.GetValueOrDefault(updated.Genre);


            _dbContext.SaveChanges();

            return updated;
        }
    }
}
