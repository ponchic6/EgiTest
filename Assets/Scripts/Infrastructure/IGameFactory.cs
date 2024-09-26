using UnityEngine;

namespace Infrastructure
{
    public interface IGameFactory
    {
        public void CreatePlayer();
        public void CreateHud();
        public GameObject Player { get; }
        public void CreateItemModelAroundPlayer(string itemId);
    }
}