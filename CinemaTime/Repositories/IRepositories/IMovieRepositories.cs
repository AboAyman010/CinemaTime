using CinemaTime.Models;

namespace CinemaTime.Repositories.IRepositories
{
    public interface IMovieRepositories: IRepository<Movie>
    {
        Task AddRangeAsync(List<Movie> movies);
    }
}
