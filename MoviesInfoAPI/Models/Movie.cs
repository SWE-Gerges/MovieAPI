using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesInfoAPI.Models
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(2500)]
        public string Description { get; set; }

        public string Category { get; set; }

        public double Rate { get; set; }

        public byte[] Poster { get; set; }
        public byte PublisherId { get; set; }

        public Publisher publisher { get; set; }


    }
}
