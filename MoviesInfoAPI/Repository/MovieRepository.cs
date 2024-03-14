
using MoviesInfoAPI.Dtos;
using Microsoft.EntityFrameworkCore;

namespace MoviesInfoAPI.Repository
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly ApplicationDbContext _context;

       

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Movie>> GetAll()
        {
            var movies = await _context.Movies.OrderBy(m => m.Name).Include(m => m.publisher).ToListAsync();
            return movies;
        }


        public async Task<Movie> FindById(int id)
        {
            var movie = await _context.Movies.Include(m => m.publisher).SingleOrDefaultAsync(m => m.Id == id);
            return movie;
        }


        public async Task<Movie> Add(Movie movie)
        {
            await _context.AddAsync(movie);
            _context.SaveChanges();
            return movie;
        }

        

        public Movie Remove(Movie movie)
        {
            _context.Remove(movie);
            _context.SaveChanges();
            return movie;
        }

        public Movie Update(Movie movie)
        {
             _context.Update(movie);
            _context.SaveChanges();
            return movie;
        }

        public Task<Movie> FindById(byte id)
        {
            throw new NotImplementedException();
        }
    }
}
