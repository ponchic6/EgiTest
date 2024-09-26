using Enums;
using TMPro;
using UnityEngine;
using Zenject;

namespace PlayerStats
{
    public class StatsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text healthTmp;
        [SerializeField] private TMP_Text strengthTmp;
        [SerializeField] private TMP_Text enduranceTmp;
        [SerializeField] private TMP_Text wisdomTmp;
        
        private IHealth _health;
        private IPlayerStatsService _playerStatsService;

        [Inject]
        private void Constructor(IHealth health, IPlayerStatsService playerStatsService)
        {
            _health = health;
            _health.OnHealthChanged += SetHealth; 
            _playerStatsService = playerStatsService;
            _playerStatsService.OnStatChanged += SetPlayerStats;
        }

        private void OnDestroy()
        {
            _health.OnHealthChanged -= SetHealth;
            _playerStatsService.OnStatChanged -= SetPlayerStats;
        }

        private void SetHealth(float newHealth)
        {
            healthTmp.text = "Здоровье: " + newHealth;
        }

        private void SetPlayerStats((StatEnum, int) tuple)
        {
            switch (tuple.Item1)
            {
                case StatEnum.Strength:
                    strengthTmp.text = "Сила: " + tuple.Item2;
                    break;
                
                case StatEnum.Endurance:
                    enduranceTmp.text = "Выносливость: " + tuple.Item2;
                    break;
                
                case StatEnum.Wisdom:
                    wisdomTmp.text = "Мудрость: " + tuple.Item2;
                    break;
            }
        }
    }
}
