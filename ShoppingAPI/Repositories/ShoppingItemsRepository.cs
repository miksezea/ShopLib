using ShopLib.Models;

namespace ShoppingAPI.Repositories
{
    public class ShoppingItemsRepository
    {
        private int _nextID;
        public List<ShoppingItem> items;
        public ShoppingItemsRepository()
        {
            _nextID = 1;
            items = new List<ShoppingItem>()
            {
                new ShoppingItem { Id = _nextID++, Name = "Milk", Price = 14, Quantity = 4 },
                new ShoppingItem { Id = _nextID++, Name = "Eggs", Price = 12, Quantity = 2 },
                new ShoppingItem { Id = _nextID++, Name = "Bread", Price = 20, Quantity = 1 },
            };
        }

        public List<ShoppingItem> GetAll()
        {
            return new List<ShoppingItem>(items);
        }
        public ShoppingItem Add(ShoppingItem newItem)
        {
            newItem.Id = _nextID++;
            if (items != null)
            {
                items.Add(newItem);
            }
            return newItem;
        }
        public ShoppingItem Delete(int id)
        {
            if (!items.Exists(i => i.Id == id))
            {
                throw new ArgumentException($"No Item with the Id: {nameof(id)}");
            }
            ShoppingItem? deleteItem = items.Find(i => i.Id == id);
            if (deleteItem != null)
            {
                items.Remove(deleteItem);
            }
            return deleteItem;
        }
        public double TotalPrice()
        {
            double result = items.Sum(item => item.Price);
            return result;
        }
    }
}
