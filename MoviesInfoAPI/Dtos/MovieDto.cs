namespace MoviesInfoAPI.Dtos
{
    public class MovieDto
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(2500)]
        public string Description { get; set; }

        public string Category { get; set; }

        public double Rate { get; set; }

        public IFormFile? Poster { get; set; }
        public byte PublisherId { get; set; }
    }
}
