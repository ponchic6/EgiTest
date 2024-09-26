using Enums;
using PlayerStats;
using Zenject;

namespace Inventory.ItemEffects
{
    public class HealthPotionEffect : BaseItemEffect
    {
        [Inject] private IHealth _health;
        [Inject] private IInventoryService _inventoryService;
        
        public HealthPotionEffect() => ID = ItemsEnum.HealthPotion.ToString();

        public override void UseItem()
        {
            base.UseItem();
            _health.AddHealth(30);
        }
    }
}