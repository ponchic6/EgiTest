using Enums;
using PlayerStats;
using Zenject;

namespace Inventory.ItemEffects
{
    public class WisdomBookEffect : BaseItemEffect
    {
        [Inject] private IPlayerStatsService _playerStatsService;
        
        public WisdomBookEffect() => ID = ItemsEnum.WisdomBook.ToString();
        
        public override void UseItem()
        {
            base.UseItem();
            _playerStatsService.ChangeStat(StatEnum.Wisdom, 1);
        }
    }
}