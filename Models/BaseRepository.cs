using LeakHand.Context;

namespace LeakHand.Model
{
    public class BaseRepository<T> where T : class
    {
        protected IDbContext _dbContext;
        public BaseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }
    }
}