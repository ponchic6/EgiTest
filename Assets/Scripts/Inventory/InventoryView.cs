using System;
using System.Collections.Generic;
using System.Linq;
using SaveSystem;
using UnityEngine;
using Zenject;

namespace Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private List<CellView> cells;
        
        private IInventoryService _inventoryService;
        private ISaveLoadSystem _saveLoadSystem;

        [Inject]
        public void Constructor(IInventoryService inventoryService, ISaveLoadSystem saveLoadSystem)
        {
            _saveLoadSystem = saveLoadSystem;
            _inventoryService = inventoryService;
            _inventoryService.OnItemCountChanged += OnItemCountChanged;
        }

        private void OnDestroy()
        {
            _inventoryService.OnItemCountChanged -= OnItemCountChanged;
            _saveLoadSystem.SaveInventory();
        }

        private void OnApplicationQuit() => _saveLoadSystem.SaveInventory();

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                _saveLoadSystem.SaveInventory();
            }
        }

        private void OnItemCountChanged(string itemId, int count)
        {
            var cell = cells.FirstOrDefault(cell => cell.ItemId == itemId);

            if (cell != null)
            {
                cell.SetNewCount(count);
                return;
            }

            var emptyCell = cells.FirstOrDefault(cell => cell.IsEmpty);

            if (emptyCell != null)
            {
                emptyCell.AddNewItem(itemId, count);
            }
        }
    }
}