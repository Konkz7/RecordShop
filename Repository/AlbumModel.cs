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
        public Album UpdateAlbum(int id, Album album);
        public bool DeleteAlbum(int id);

        public List<Album> GetAllAlbumsByArtist(string artist);

        public List<Album> GetAllAlbumsByReleaseYear(int year);

        public List<Album> GetAllAlbumsByGenre(Genre genre);

        public Album GetAlbumByName(string name);

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

        public List<Album> GetAllAlbumsByArtist(string artist)
        {
            return _dbContext.Albums.Where(x => x.Artist == artist).ToList();
        }

        public List<Album> GetAllAlbumsByReleaseYear(int year)
        {
            return _dbContext.Albums.Where(x => x.ReleaseYear == year).ToList();
        }

        public List<Album> GetAllAlbumsByGenre(Genre genre)
        {
            return _dbContext.Albums.Where(x => x.Genre == genre).ToList();
        }

        public Album GetAlbumByName(string name)
        {
            return _dbContext.Albums.FirstOrDefault(x => x.Title == name);
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

            //Only for Development
            //album.Id = newId;   

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

        public Album UpdateAlbum(int id , Album album)
        {
            Album updated = GetAlbumById(id);

            if (album.ReleaseYear < 1000 || album.ReleaseYear > 2026)
                throw new ArgumentException("Invalid year");

            if (id != album.Id) throw new ArgumentException("Inorrect id, cannot update this entry");

            updated.Artist =  album.Artist;
            updated.Title = album.Title;
            updated.Price = album.Price;
            updated.ReleaseYear = album.ReleaseYear;
            updated.Genre = album.Genre;


            _dbContext.SaveChanges();

            return updated;
        }
    }
}
