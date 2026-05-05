using RecordShop.Data;
using RecordShop.Models;


namespace RecordShop.Repository
{

    public interface IAlbumModel
    {
        public List<Album> GetAllAlbums();
        public Album GetAlbumById(int id);
        public Album AddAlbum(Album album);
        public Album UpdateAlbum(Album album);
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

            album.Id = newId;   

            albums.Add(album);

            return album;
        }

        public bool DeleteAlbum(int id)
        {
            List<Album> albums = GetAllAlbums();
            return albums.Remove(GetAlbumById(id));
        }

        public Album UpdateAlbum(int id, Album album)
        {
            Album updated = GetAlbumById(album.Id);
            
            updated.Artist = album.Artist;
            updated.Title = album.Title;
            updated.Price = album.Price;
            updated.ReleaseYear = album.ReleaseYear;
            updated.Genre = album.Genre;

            return updated;
        }
    }
}
