using System;
using Inventory;
using PlayerStats;
using SaveSystem;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        private IGameFactory _gameFactory;
        private IPlayerStatsService _playerStatsService;
        private IHealth _health;
        private ISaveLoadSystem _saveLoadSystem;
        private IInventoryService _inventoryService;

        [Inject]
        public void Constructor(IGameFactory gameFactory, IPlayerStatsService playerStatsService,
            IHealth health, ISaveLoadSystem saveLoadSystem, IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
            _saveLoadSystem = saveLoadSystem;
            _health = health;
            _playerStatsService = playerStatsService;
            _gameFactory = gameFactory;
        }

        private void Start()
        {
            _gameFactory.CreatePlayer();
            _gameFactory.CreateHud();
            _playerStatsService.SetInitialStats();
            _health.SetInitialHealth();
            _inventoryService.AddItemsFromSaveModel(_saveLoadSystem.LoadLastInventory());
        }
    }
}