using Infrastructure;
using Inventory.ItemEffects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Inventory
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private TMP_Text countTmp;
        [SerializeField] private Image itemIcon;
        
        private GlobalConfig _globalConfig;
        private IItemEffectService _itemEffectService;
        private IInventoryService _inventoryService;
        private IGameFactory _gameFactory;

        private string _itemId;
        private int _count;
        private bool _isEmpty = true;

        public string ItemId => _itemId;
        public bool IsEmpty => _isEmpty;

        [Inject]
        public void Constructor(GlobalConfig globalConfig, IItemEffectService itemEffectService,
            IInventoryService inventoryService, IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _inventoryService = inventoryService;
            _itemEffectService = itemEffectService;
            _globalConfig = globalConfig;
        }

        private void Start()
        {
            countTmp.text = _count.ToString();
        }

        public void UseItem()
        {
            if (_isEmpty)
            {
                return;
            }

            _itemEffectService.EffectsDict[_itemId].UseItem();
        }

        public void DropItem()
        {
            if (_isEmpty)
            {
                return;
            }

            _gameFactory.CreateItemModelAroundPlayer(_itemId);
            _inventoryService.RemoveItem(_itemId, 1);
        }

        public void SetNewCount(int count)
        {
            _count = count;
            countTmp.text = _count.ToString();
            
            if (_count <= 0)
            {
                _isEmpty = true;
                _itemId = null;
                itemIcon.sprite = _globalConfig.GetDefaultBackground();
            }
        }
        
        public void AddNewItem(string itemId, int count)
        {
            _isEmpty = false;
            _itemId = itemId;
            _count = count;
            itemIcon.sprite = _globalConfig.GetItemInfo(itemId).icon;
            countTmp.text = _count.ToString();
        }
    }
}