using System;

namespace PlayerStats
{
    public interface IHealth
    {
        public event Action<float> OnHealthChanged;
        public float CurrentHealth { get; }
        public void SetInitialHealth();
        public void AddHealth(float health);
        public void RemoveHealth(float damage);
    }
}