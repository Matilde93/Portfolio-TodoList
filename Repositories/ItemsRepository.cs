using ToDoList.Models;

namespace ToDoList.Repositories
{
    public class ItemsRepository
    {
        private int _nextId;
        private List<Item> _items;

        public ItemsRepository()
        {
            _nextId = 1;
            _items = new List<Item>() { 
                new Item() { Id = _nextId++, Name = "Handle", Description = "Smør"},
                new Item() { Id = _nextId++, Name = "Lektier", Description = "Matematik"},
                new Item() { Id = _nextId++, Name = "Skrive", Description = "Ansøgning"}
            };
        }

        public List<Item> GetAll()
        {
            List<Item> items = new List<Item>(_items);
            return items;
        }
        
        public Item Add(Item item)
        {
            item.Id = _nextId++;
            _items.Add(item);
            return item;
        }

        public Item Delete(int id)
        {
            Item? itemToBeDeleted = GetById(id);
            if (itemToBeDeleted == null)
            {
                return null;
            }
            _items.Remove(itemToBeDeleted);
            return itemToBeDeleted;
        }

        public Item GetById(int id)
        {
            return _items.Find(item => item.Id == id);
        }

        public Item Update(int id, Item itemUpdates)
        {
            Item? itemToBeUpdated = GetById(id);
            if (itemToBeUpdated == null)
            {
                return null;
            }
            itemToBeUpdated.Name = itemUpdates.Name;
            itemToBeUpdated.Description = itemUpdates.Description;
            return itemToBeUpdated;
        }
    }

}
