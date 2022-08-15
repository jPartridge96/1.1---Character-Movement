using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemHandler : MonoBehaviour
{
    // public Item CreateItem(int id, string name, float buyPrice)
    // {
    //     Item newItem = newItem(id, name, buyPrice);
    //     return newItem;
    // }

    // public Item UpdateItem()
    // {
    //     // find index of item given, update with value
    //     return item;
    // }

    public void DeleteItem(Item item)
    {
        // Delete item from _items list
    }

    public int GetNextId()
    {
        int nextId = 0;
        // Use LINQ to find next available Id in list
        return nextId;
    }

    public void WriteToFile() { }
    public void ReadFromFile() { }

    // Arrays will match 1:1
    // Sprites taken from order of sprite sheet
    private List<Sprite> _sprites = new List<Sprite>();
    private List<Item> _items = new List<Item>();
}