using System;
using Enums;

namespace PlayerStats
{
    public interface IPlayerStatsService
    {
        public event Action<(StatEnum, int)> OnStatChanged;
        public void SetInitialStats();
        public void SetStat(StatEnum statEnum, int count);
        public void ChangeStat(StatEnum statEnum, int delta);
    }
}