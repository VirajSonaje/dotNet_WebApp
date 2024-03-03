using AutoMapper;
using dotnet_webapp.Data;
using dotnet_webapp.Models;
using dotNet_WebApp.Interfaces;

namespace dotNet_WebApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReviewRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

         public Review GetReview(int reviewId)
        {
            return _context.Reviews.Where(r => r.id == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsOfAPokemon(int pokeId)
        {
            return _context.Reviews.Where(r => r.Pokemon.id == pokeId).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return _context.Reviews.Any(r => r.id == reviewId);
        }

    }
}