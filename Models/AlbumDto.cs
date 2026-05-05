using System.ComponentModel.DataAnnotations;

namespace RecordShop.Models
{
    public class AlbumDto
    {
        public string Title { get; set; }

        public string Artist { get; set; }

        public Genre? Genre { get; set; }

        public int? ReleaseYear { get; set; }

        public decimal? Price { get; set; }

        public AlbumDto(string title, string artist, Genre? genre, int? releaseYear, decimal? price)
        {
            Title = title;
            Artist = artist;
            Genre = genre;
            ReleaseYear = releaseYear;
            Price = price;
        }
    }
}
