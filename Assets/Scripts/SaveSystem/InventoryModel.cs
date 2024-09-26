using System;
using System.Collections.Generic;

namespace SaveSystem
{
    [Serializable]
    public class InventoryModel
    {
        public Dictionary<string, int> Inventory = new();
    }
}