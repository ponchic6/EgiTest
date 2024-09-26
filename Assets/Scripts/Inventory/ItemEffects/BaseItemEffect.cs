using Zenject;

namespace Inventory.ItemEffects
{
    public abstract class BaseItemEffect
    {
        [Inject] private IInventoryService _inventoryService;
        protected string ID;
     
        //Числовые значения эффектов захардкодил для экономии времени, но никто не мешает вынести их в GlobalConfig
        public virtual void UseItem()
        {
            if (!_inventoryService.RemoveItem(ID, 1))
            {
                return;
            }
        }
    }
}