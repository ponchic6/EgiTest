using Enums;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "ScriptableObject/ItemInfo", fileName = "ItemInfo")]
    public class ItemViewConfig : ScriptableObject
    {
        public string pathToPrefab;
        public ItemsEnum id;
        public Sprite icon;
    }
}