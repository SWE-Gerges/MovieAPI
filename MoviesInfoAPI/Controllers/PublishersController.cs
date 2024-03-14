
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MoviesInfoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IRepository<Publisher> _publisherRepository;


        public PublishersController(IRepository<Publisher> publisherRepository)
        {
           
            _publisherRepository = publisherRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var publishers = await _publisherRepository.GetAll();

            return Ok(publishers);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(PublisherDto createPublisherDto)
        {
            var publisher = new Publisher
            {
                Name = createPublisherDto.Name
            };
            await _publisherRepository.Add(publisher);
            

            return Ok(publisher);
        }

        [HttpPut("{Id}")]

        public async Task<IActionResult> UpdateAsync(byte Id, [FromBody] PublisherDto publisherDto)
        {
            var publisher = await _publisherRepository.FindById(Id);
            if(publisher == null)
            {
                return NotFound($"No Publisher was found with ID: {Id}");
            }

            publisher.Name = publisherDto.Name;

            _publisherRepository.Update(publisher);

            return Ok(publisher);
        }

        [HttpDelete("{Id}")]

        public async Task<IActionResult> DeleteAsync(byte Id)
        {
            var publisher = await _publisherRepository.FindById(Id);
            if(publisher == null)
            {
                return NotFound($"No Publisher was found with ID: {Id}");
            }
            _publisherRepository.Remove(publisher);
            return Ok();
        }
    }
}
