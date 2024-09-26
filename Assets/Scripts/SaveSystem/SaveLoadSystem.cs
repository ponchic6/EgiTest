using System.IO;
using Inventory;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveSystem
{
    public class SaveLoadSystem : ISaveLoadSystem
    {
        private readonly IInventoryService _inventoryService;

        public SaveLoadSystem(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        
        public InventoryModel LoadLastInventory()
        {
            string path = Application.persistentDataPath + "/lastInventory.json";

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                InventoryModel inventoryModel = JsonConvert.DeserializeObject<InventoryModel>(json);

                Debug.Log("Данные загружены из файла.");

                return inventoryModel;
            }

            Debug.LogWarning("Файл данных не найден.");
            return null;
        }

        public void SaveInventory()
        {
            var inventoryModel = new InventoryModel();
            inventoryModel.Inventory = _inventoryService.ItemDict;
            string json = JsonConvert.SerializeObject(inventoryModel, Formatting.Indented);
            string path = Application.persistentDataPath + "/lastInventory.json";
            File.WriteAllText(path, json);
            Debug.Log("Данные сохранены: " + path);
        }
    }
}