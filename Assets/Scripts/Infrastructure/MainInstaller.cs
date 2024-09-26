using Inventory;
using Inventory.ItemEffects;
using PlayerStats;
using SaveSystem;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private GlobalConfig globalConfig;
        
        public override void InstallBindings()
        {
            RegisterGlobalConfig();
            RegisterCoroutineRunner();
            RegisterGameFactory();
            RegisterPlayerStatsService();
            RegisterHealth();
            RegisterInventoryService();
            RegisterItemEffectService();
            RegisterSaveLoadSystem();
        }

        private void RegisterSaveLoadSystem()
        {
            var saveLoadSystem = Container.Instantiate<SaveLoadSystem>();
            Container.Bind<ISaveLoadSystem>().FromInstance(saveLoadSystem).AsSingle();
        }

        private void RegisterItemEffectService()
        {
            var itemEffectService = Container.Instantiate<ItemEffectService>();
            Container.Bind<IItemEffectService>().FromInstance(itemEffectService).AsSingle();
        }

        private void RegisterCoroutineRunner()
        {
            GameObject obj = new GameObject("CoroutineRunner");
            var instance = obj.AddComponent<CoroutineRunner>();
            DontDestroyOnLoad(obj);
            Container.Bind<ICoroutineRunner>().FromInstance(instance).AsSingle();
        }

        private void RegisterInventoryService()
        {
            var inventoryService = Container.Instantiate<InventoryService>();
            Container.Bind<IInventoryService>().FromInstance(inventoryService).AsSingle();
        }

        private void RegisterHealth()
        {
            var health = Container.Instantiate<Health>();
            Container.Bind<IHealth>().FromInstance(health).AsSingle();
        }

        private void RegisterGlobalConfig()
        {
            Container.Bind<GlobalConfig>().FromInstance(globalConfig).AsSingle();
        }

        private void RegisterPlayerStatsService()
        {
            var playerStatsService = Container.Instantiate<PlayerStatsService>();
            Container.Bind<IPlayerStatsService>().FromInstance(playerStatsService).AsSingle();
        }

        private void RegisterGameFactory()
        {
            var gameFactory = Container.Instantiate<GameFactory>();
            Container.Bind<IGameFactory>().FromInstance(gameFactory).AsSingle();
        }
    }
}