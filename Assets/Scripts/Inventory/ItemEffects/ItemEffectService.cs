using System.Collections.Generic;
using Enums;
using Zenject;

namespace Inventory.ItemEffects
{
    public class ItemEffectService : IItemEffectService
    {
        private Dictionary<string, BaseItemEffect> _effectsDict = new();
        public Dictionary<string, BaseItemEffect> EffectsDict => _effectsDict;
        
        public ItemEffectService(DiContainer diContainer)
        {
            _effectsDict[ItemsEnum.HealthPotion.ToString()] = diContainer.Instantiate<HealthPotionEffect>();
            _effectsDict[ItemsEnum.Poison.ToString()] = diContainer.Instantiate<PoisonEffect>();
            _effectsDict[ItemsEnum.SpeedPotion.ToString()] = diContainer.Instantiate<SpeedPotionEffect>();
            _effectsDict[ItemsEnum.StrengthHammer.ToString()] = diContainer.Instantiate<StrengthHammerEffect>();
            _effectsDict[ItemsEnum.WisdomBook.ToString()] = diContainer.Instantiate<WisdomBookEffect>();
        }
    }
}