using System;
using System.Collections.Generic;
using Enums;
using Infrastructure;

namespace PlayerStats
{
    public class PlayerStatsService : IPlayerStatsService
    {
        public event Action<(StatEnum, int)> OnStatChanged;
        
        private readonly Dictionary<StatEnum, int> _stats = new();
        private readonly GlobalConfig _globalConfig;

        public PlayerStatsService(GlobalConfig globalConfig)
        {
            _globalConfig = globalConfig;
        }

        public void SetInitialStats()
        {
            _stats[StatEnum.Strength] = _globalConfig.GetInitialValueStat(StatEnum.Strength);
            _stats[StatEnum.Endurance] = _globalConfig.GetInitialValueStat(StatEnum.Endurance);
            _stats[StatEnum.Wisdom] = _globalConfig.GetInitialValueStat(StatEnum.Wisdom);
            
            OnStatChanged?.Invoke((StatEnum.Strength, _globalConfig.GetInitialValueStat(StatEnum.Strength)));
            OnStatChanged?.Invoke((StatEnum.Endurance, _globalConfig.GetInitialValueStat(StatEnum.Endurance)));
            OnStatChanged?.Invoke((StatEnum.Wisdom, _globalConfig.GetInitialValueStat(StatEnum.Wisdom)));
        }

        public void SetStat(StatEnum statEnum, int count)
        {
            _stats[statEnum] = count;
            OnStatChanged?.Invoke((statEnum, count));
        }

        public void ChangeStat(StatEnum statEnum, int delta)
        {
            _stats[statEnum] += delta;
            OnStatChanged?.Invoke((statEnum, _stats[statEnum]));
        }
    }
}