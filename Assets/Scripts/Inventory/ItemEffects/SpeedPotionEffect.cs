using System.Collections;
using Enums;
using Infrastructure;
using PlayerControl;
using UnityEngine;
using Zenject;

namespace Inventory.ItemEffects
{
    public class SpeedPotionEffect : BaseItemEffect
    {
        [Inject] private IGameFactory _gameFactory;
        [Inject] private ICoroutineRunner _coroutineRunner;
        
        public SpeedPotionEffect() => ID = ItemsEnum.SpeedPotion.ToString();

        public override void UseItem()
        {
            base.UseItem();
            _coroutineRunner.StartMyCoroutine(IncreaseSpeedCoroutine());
        }

        private IEnumerator IncreaseSpeedCoroutine()
        {
            _gameFactory.Player.GetComponentInChildren<ISpeedControlable>().IncreaseSpeed(3);
            yield return new WaitForSeconds(4);
            _gameFactory.Player.GetComponentInChildren<ISpeedControlable>().SetBaseSpeed();
        }
    }
}