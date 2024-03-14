namespace MoviesInfoAPI.Dtos
{
    public class PublisherDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
    } 
}
