using System.Collections.Generic;

namespace Inventory.ItemEffects
{
    public interface IItemEffectService
    {
        public Dictionary<string, BaseItemEffect> EffectsDict { get; }
    }
}