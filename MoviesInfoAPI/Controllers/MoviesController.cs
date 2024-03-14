
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoviesInfoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IRepository<Movie> _movieRepository;


        string _allowedExtentions = FileSettings.allowedExtentions;
        int _maxFileSize = FileSettings.maxFileSizeByte;


        public MoviesController(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var movies = await _movieRepository.GetAll();
            return Ok(movies);
        }

        [HttpGet("{Id}")]

        public async Task<IActionResult>GetByIdAsync(int Id)
        {
            var movie = await _movieRepository.FindById(Id);
            if(movie == null) { return NotFound(); }

            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm]MovieDto movieDto)
        {

            if (movieDto.Poster == null)
                return BadRequest("Error: Poster is required");

            #region ValidatePosterExtentionAndSize


            if (!_allowedExtentions.Contains(Path.GetExtension(movieDto.Poster.FileName).ToLowerInvariant()))
                return BadRequest($"Error: Only {_allowedExtentions} are allowed!");

            if (movieDto.Poster.Length > _maxFileSize)
                return BadRequest($"Maximum file size allowed is: {_maxFileSize} Byte");


            #endregion

            using var dataStream = new MemoryStream();
            await movieDto.Poster.CopyToAsync(dataStream);


            var movie = new Movie
            {
                Category = movieDto.Category,
                Description = movieDto.Description,
                Name = movieDto.Name,
                PublisherId = movieDto.PublisherId,
                Rate = movieDto.Rate,
                Poster = dataStream.ToArray()
                

            };

           await _movieRepository.Add(movie);
            return Ok(movie);

        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateAsync(int Id, [FromForm] MovieDto movieDto)
        {

            var movie = await _movieRepository.FindById(Id);
            if (movie == null) { return NotFound($"Error: Movie not found with ID: {Id}");  }

            #region ValidatePosterExtentionAndSize


            if (movieDto.Poster != null)
            {

                if (!_allowedExtentions.Contains(Path.GetExtension(movieDto.Poster.FileName).ToLowerInvariant()))
                    return BadRequest($"Error: Only {_allowedExtentions} are allowed!");

                if (movieDto.Poster.Length > _maxFileSize)
                    return BadRequest($"Maximum file size allowed is: {_maxFileSize} Byte");

                using var dataStream = new MemoryStream();
                await movieDto.Poster.CopyToAsync(dataStream);

                movie.Poster = dataStream.ToArray();
            }

            #endregion


            _movieRepository.Update(movie);
            return Ok(movie);

        }
          
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var movie = await _movieRepository.FindById(Id);
            if (movie == null) return NotFound($"No movie found with ID: {Id}");
             _movieRepository.Remove(movie);

            return Ok(movie);
        }
    }
}
