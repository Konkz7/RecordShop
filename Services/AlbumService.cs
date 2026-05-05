using RecordShop.Models;
using RecordShop.Repository;

namespace RecordShop.Services
{
    public interface IAlbumService
    {
        public List<Album> GetAllAlbums();
        public Album GetAlbumById(int id);
        public Album AddAlbum(Album album);

        public Album UpdateAlbum(int id,AlbumDto album);
        public bool DeleteAlbum(int id);
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

        public List<Album> GetAllAlbums()
        {
            return _albumModel.GetAllAlbums();  
        }

        public Album UpdateAlbum(int id, AlbumDto album)
        {
            return _albumModel.UpdateAlbum(id,album);
        }
    }
}
