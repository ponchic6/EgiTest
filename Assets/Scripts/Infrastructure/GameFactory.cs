using Cinemachine;
using PlayerControl;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameFactory : IGameFactory
    {
        private const string PlayerPath = "Prefabs/Player";
        private const string MainHudPath = "Prefabs/UI/MainHud";
        
        private readonly DiContainer _diContainer;
        private readonly GlobalConfig _globalConfig;

        private GameObject _player;

        public GameObject Player => _player;

        public GameFactory(DiContainer diContainer, GlobalConfig globalConfig)
        {
            _diContainer = diContainer;
            _globalConfig = globalConfig;
        }

        public void CreateItemModelAroundPlayer(string itemId)
        {
            Vector3 itemPos = GetRandomPositionAroundPlayer();
            _diContainer.InstantiatePrefabResource(_globalConfig.GetItemInfo(itemId).pathToPrefab, itemPos,
                Quaternion.identity, null);
        }

        public void CreatePlayer()
        {
            _player = _diContainer.InstantiatePrefabResource(PlayerPath);
            GameObject virtualCameraGo = new GameObject();
            CreatePlayerVirtualCamera(virtualCameraGo, _player);
        }

        public void CreateHud() => _diContainer.InstantiatePrefabResource(MainHudPath);

        private static void CreatePlayerVirtualCamera(GameObject virtualCameraGo, GameObject player)
        {
            virtualCameraGo.name = "PlayerVirtualCamera";
            var virtualCamera = virtualCameraGo.AddComponent<CinemachineVirtualCamera>();
            var playerCameraPos = player.GetComponentInChildren<PlayerMover>().PlayerCameraPos;
            virtualCameraGo.transform.position = playerCameraPos.position;
            virtualCameraGo.transform.rotation = playerCameraPos.rotation;
            virtualCamera.Follow = player.transform;
            virtualCamera.LookAt = player.transform;
            virtualCamera.AddCinemachineComponent<CinemachineFramingTransposer>();
        }
        
        private Vector3 GetRandomPositionAroundPlayer()
        {
            float randomAngle = Random.Range(0f, Mathf.PI * 2);
            float randomDistance = Random.Range(0f, 6f);
            float xOffset = Mathf.Cos(randomAngle) * randomDistance;
            float zOffset = Mathf.Sin(randomAngle) * randomDistance;
            return new Vector3(_player.transform.position.x + xOffset, 3, _player.transform.position.z + zOffset);
        }
    }
}
