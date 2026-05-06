using RecordShop.Models;
using RecordShop.Repository;

namespace RecordShop.Services
{
    public interface IAlbumService
    {
        public List<Album> GetAllAlbums();
        public Album GetAlbumById(int id);
        public Album AddAlbum(Album album);

        public Album UpdateAlbum(int id,Album album);
        public bool DeleteAlbum(int id);

        public List<Album> GetAllAlbumsByArtist(string artist);

        public List<Album> GetAllAlbumsByReleaseYear(int year);

        public List<Album> GetAllAlbumsByGenre(Genre genre);

        public Album GetAlbumByName(string name);

    }
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumModel _albumModel;

        public AlbumService(IAlbumModel albumModel)
        {
            _albumModel = albumModel;
        }

        public Album AddAlbum(Album album)
        {
            return _albumModel.AddAlbum(album);
        }

        public bool DeleteAlbum(int id)
        {
            return _albumModel.DeleteAlbum(id);
        }

        public Album GetAlbumById(int id)
        {
            return _albumModel.GetAlbumById(id);
        }

        public Album GetAlbumByName(string name)
        {
            return _albumModel.GetAlbumByName(name);
        }

        public List<Album> GetAllAlbums()
        {
            return _albumModel.GetAllAlbums();  
        }

        public List<Album> GetAllAlbumsByArtist(string artist)
        {
            return _albumModel.GetAllAlbumsByArtist(artist);
        }

        public List<Album> GetAllAlbumsByGenre(Genre genre)
        {
            return _albumModel.GetAllAlbumsByGenre(genre);
        }

        public List<Album> GetAllAlbumsByReleaseYear(int year)
        {
            return _albumModel.GetAllAlbumsByReleaseYear(year);
        }

        public Album UpdateAlbum(int id, Album album)
        {
            return _albumModel.UpdateAlbum(id,album);
        }
    }
}
