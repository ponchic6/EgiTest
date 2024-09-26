using System.Collections;
using Enums;
using Infrastructure;
using PlayerStats;
using UnityEngine;
using Zenject;

namespace Inventory.ItemEffects
{
    public class PoisonEffect : BaseItemEffect
    {
        [Inject] private ICoroutineRunner _coroutineRunner;
        [Inject] private IHealth _health;

        public PoisonEffect() => ID = ItemsEnum.Poison.ToString();

        public override void UseItem()
        {
            base.UseItem();
            _coroutineRunner.StartMyCoroutine(PoisonCoroutine());
        }

        private IEnumerator PoisonCoroutine()
        {
            float time = 0;
            
            while (time < 10)
            {
                _health.RemoveHealth(5);
                yield return new WaitForSeconds(1);
                time++;
            }
        }
    }
}