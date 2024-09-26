using System;
using Infrastructure;

namespace PlayerStats
{
    public class Health : IHealth
    {
        public event Action<float> OnHealthChanged;
        
        private readonly GlobalConfig _globalConfig;

        private float _currentHealth;
        
        public float CurrentHealth => _currentHealth;

        public Health(GlobalConfig globalConfig)
        {
            _globalConfig = globalConfig;
        }

        public void SetInitialHealth()
        {
            _currentHealth = _globalConfig.MaxHealth;
            OnHealthChanged?.Invoke(_currentHealth);
        }

        public void AddHealth(float health)
        {
            _currentHealth += health;
            
            if (_currentHealth > _globalConfig.MaxHealth)
            {
                _currentHealth = _globalConfig.MaxHealth;
            }
            
            OnHealthChanged?.Invoke(_currentHealth);
        }

        public void RemoveHealth(float damage)
        {
            _currentHealth -= damage;
            OnHealthChanged?.Invoke(_currentHealth);
        }
    }
}