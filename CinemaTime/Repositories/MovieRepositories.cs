using CinemaTime.DataAccess;
using CinemaTime.Models;
using CinemaTime.Repositories.IRepositories;

namespace CinemaTime.IRepositories
{
    public class MovieRepositories :Repository<Movie>, IMovieRepositories
    {
        private ApplicationDbContext _context = new();
        public async Task AddRangeAsync(List<Movie>movies)
        {
            await _context.Movies.AddRangeAsync(movies);
        }
    }
}
