using System;
using System.Collections.Generic;
using SaveSystem;

namespace Inventory
{
    public interface IInventoryService
    {
        public event Action<string, int> OnItemCountChanged;
        public Dictionary<string, int> ItemDict { get; }
        public void AddItem(string itemId, int count);
        public bool RemoveItem(string itemId, int i);
        public void AddItemsFromSaveModel(InventoryModel inventoryModel);
    }
}