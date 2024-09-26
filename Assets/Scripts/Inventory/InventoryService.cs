using System;
using System.Collections.Generic;
using SaveSystem;

namespace Inventory
{
    public class InventoryService : IInventoryService
    {
        public event Action<string, int> OnItemCountChanged;
        
        private Dictionary<string, int> _itemDict = new();

        public Dictionary<string, int> ItemDict => _itemDict;

        public void AddItem(string itemId, int count)
        {
            if (!_itemDict.TryAdd(itemId, count))
            {
                _itemDict[itemId] += count;
            }
            
            OnItemCountChanged?.Invoke(itemId, _itemDict[itemId]);
        }
        
        public bool RemoveItem(string itemId, int count)
        {
            if (!_itemDict.ContainsKey(itemId))
            {
                return false;
            }

            if (_itemDict[itemId] - count < 0)
            {
                return false;
            }

            _itemDict[itemId] -= count;
            OnItemCountChanged?.Invoke(itemId, _itemDict[itemId]);

            if (_itemDict[itemId] == 0)
            {
                _itemDict.Remove(itemId);
            }
            
            return true;
        }

        public void AddItemsFromSaveModel(InventoryModel inventoryModel)
        {
            if (inventoryModel == null)
            {
                return;
            }
            
            foreach (var kvp in inventoryModel.Inventory)
            {
                AddItem(kvp.Key, kvp.Value);
            }
        }
    }
}