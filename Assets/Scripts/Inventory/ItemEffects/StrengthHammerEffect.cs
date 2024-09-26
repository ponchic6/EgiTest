using Enums;
using PlayerStats;
using Zenject;

namespace Inventory.ItemEffects
{
    public class StrengthHammerEffect : BaseItemEffect
    {
        [Inject] private IPlayerStatsService _playerStatsService;
        
        public StrengthHammerEffect() => ID = ItemsEnum.StrengthHammer.ToString();

        public override void UseItem()
        {
            base.UseItem();
            _playerStatsService.ChangeStat(StatEnum.Strength, 1);
        }
    }
}