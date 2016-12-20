using System.Collections.Generic;

namespace LeakHand.Model
{
    public interface ITodoRepository
    {
        void Add(Item item);
        IEnumerable<Item> GetAll();
        Item Find(int id);
        Item Remove(int id);
        void Update(Item item);
    }
}