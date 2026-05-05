using System.ComponentModel.DataAnnotations;

namespace RecordShop.Models
{
    public class Album
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public Genre Genre { get; set; }

        [Range(1000, 9999, ErrorMessage = "Release year must be a 4-digit number.")]
        public int ReleaseYear { get; set; }

        public decimal Price{ get; set; }

    }
}
