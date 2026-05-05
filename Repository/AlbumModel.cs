using Microsoft.IdentityModel.Tokens;
using RecordShop.Data;
using RecordShop.Models;


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
            return _dbContext.Albums.ToList().Find(x => x.Id == id);
        }

        public Album AddAlbum(Album album)
        {
            List<Album> albums = GetAllAlbums();
            int newId = albums.Any() ? albums.Max(x => x.Id) + 1 : 1;

            if (album.ReleaseYear < 1000 || album.ReleaseYear > 2026)
                throw new ArgumentException("Invalid year");

            album.Id = newId;   

            albums.Add(album);

            return album;
        }

        public bool DeleteAlbum(int id)
        {
            List<Album> albums = GetAllAlbums();
            return albums.Remove(GetAlbumById(id));
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



            return updated;
        }
    }
}
