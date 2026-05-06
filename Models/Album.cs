using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecordShop.Models
{
    public class Album
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public Genre Genre { get; set; }

        public int ReleaseYear { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price{ get; set; }

        public int Stock { get; set; }

        public Album(int id, string title, string artist, Genre genre, int releaseYear, decimal price,int stock)
        {
            Id = id;
            Title = title;
            Artist = artist;
            Genre = genre;
            ReleaseYear = releaseYear;
            Price = price;
            Stock = stock;
        }

    }
}
