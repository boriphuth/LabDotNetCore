using System.Collections.Generic;
using System.Linq;
using LeakHand.Context;

namespace LeakHand.Model
{
    public class TodoRepository : BaseRepository<Item>, ITodoRepository
    {
        public TodoRepository(IDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Item> GetAll()
        {
            return _dbContext.Items;
        }

        public void Add(Item item)
        {
            _dbContext.Items.Add(item);
            _dbContext.SaveChanges();
        }

        public Item Find(int id)
        {
            return _dbContext.Items.FirstOrDefault(c => c.Id == id);
        }

        public Item Remove(int id)
        {
            Item item = Find(id);
            _dbContext.Items.Remove(item);
            return item;
        }
        public void Update(Item item)
        {
            _dbContext.Items.Update(item);
        }
    }
}