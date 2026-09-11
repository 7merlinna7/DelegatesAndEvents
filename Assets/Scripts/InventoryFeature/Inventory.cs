using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    private List<Item> _items = new();

    public int MaxÑapacity { get; private set; }
    public int CurrentSize => _items.Sum(item => item.Value);

    public Inventory(List<Item> items, int maxÑapacity)
    {
        _items = items;
        MaxÑapacity = maxÑapacity;
    }

    public void Add(Item item)
    {
        if (CurrentSize + item.Value >= MaxÑapacity)
            return;

        _items.Add(item);
    }

    public List<Item> GetItemsBy(string name, int count)
    {
        List<Item> filtredItems = new List<Item>();

        for (int i = 0; i < count; i++)
        {
            Item item = _items.First(item => item.Name == name);
            _items.Remove(item);
            filtredItems.Add(item);
        }

        return filtredItems;
    }

    public IReadOnlyList<Item> ShowInventory() => _items;
}

public class Item
{
    public string Name { get; private set;}
    public int Value { get; private set; }
}