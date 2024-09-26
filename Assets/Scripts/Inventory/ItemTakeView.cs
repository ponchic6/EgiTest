using Enums;
using PlayerControl;
using UnityEngine;
using Zenject;

namespace Inventory
{
    public class ItemTakeView : MonoBehaviour
    {
        [SerializeField] private ItemsEnum itemEnum;
        
        private IInventoryService _inventoryService;

        [Inject]
        public void Constructor(IInventoryService inventoryService) => _inventoryService = inventoryService;

        public void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(typeof(PlayerMover), out Component playerMover))
            {
                _inventoryService.AddItem(itemEnum.ToString(), 1);
                Destroy(gameObject);
            }
        }
    }
}
