using System.Collections.Generic;
using Configs;
using Enums;
using Inventory;
using UnityEngine;

namespace Infrastructure
{
    [CreateAssetMenu(menuName = "ScriptableObject/GlobalConfig", fileName = "GlobalConfig")]
    public class GlobalConfig : ScriptableObject
    {
        [Range(0, 10)][SerializeField] private int strength;
        [Range(0, 10)][SerializeField] private int endurance;
        [Range(0, 10)][SerializeField] private int wisdom;
        
        [SerializeField] private float maxHealth;
        [SerializeField] private List<ItemViewConfig> itemInfos;
        [SerializeField] private Sprite defaultCell;
        [SerializeField] private float baseSpeed;
        
        private HashSet<ItemViewConfig> _hashSet = new();

        public float MaxHealth => maxHealth;
        public float BaseSpeed => baseSpeed;

        public int GetInitialValueStat(StatEnum statEnum)
        {
            switch (statEnum)
            {
                case StatEnum.Strength:
                    return strength;
                
                case StatEnum.Endurance:
                    return endurance;
                
                case StatEnum.Wisdom:
                    return wisdom;
            }

            return -1;
        }

        public Sprite GetDefaultBackground() => defaultCell;
        public ItemViewConfig GetItemInfo(string itemId) => itemInfos.Find(info => info.id.ToString() == itemId);

        private void OnValidate()
        {
            RejectAddingSameItem();
        }

        private void RejectAddingSameItem()
        {
            _hashSet.Clear();
            for (int i = 0; i < itemInfos.Count; i++)
            {
                if (!_hashSet.Add(itemInfos[i]))
                {
                    itemInfos.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}