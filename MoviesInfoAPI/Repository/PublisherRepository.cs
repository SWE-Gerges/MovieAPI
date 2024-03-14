


using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MoviesInfoAPI.Repository
{
    public class PublisherRepository : IRepository<Publisher>
    {
        private readonly ApplicationDbContext _context;

        public PublisherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Publisher>> GetAll()
        {
            var publishers = await _context.Publishers.OrderBy(p => p.Name).ToListAsync();

            return publishers;
        }

        public async Task<Publisher> FindById(byte id)
        {
            var publisher = await _context.Publishers.SingleOrDefaultAsync(p => p.Id == id);

            return publisher;
        }


        public async Task<Publisher> Add(Publisher publisher)
        {
          await _context.Publishers.AddAsync(publisher);
            _context.SaveChanges();
            return publisher;
        }

        public Publisher Update(Publisher publisher)
        {
            _context.Publishers.Update(publisher);
            _context.SaveChanges();
            return  publisher;
        }


        public Publisher Remove(Publisher publisher)
        {

            _context.Publishers.Remove(publisher);
            _context.SaveChanges();
            return publisher;
        }

        public Task<Publisher> FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
