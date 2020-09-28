using Leopotam.Ecs;
using Project.Scripts.Events;
using Project.Scripts.Systems;
using UnityEngine;

namespace Project.Scripts
{
    public class Entities : MonoBehaviour
    {
        [SerializeField] private GameObject barbarianGameObject = default;
        
        private EcsWorld ecsWorld;
        private EcsSystems ecsUpdateSystems;
        private EcsSystems ecsFixedUpdateSystems;

        private void Awake()
        {
            ecsWorld = new EcsWorld();
            
            ecsUpdateSystems = new EcsSystems(ecsWorld)
                .Add(new WorldObjectSystem())
                .OneFrame<CreateWorldObjectEvent>()
                .Add(new PlayerInputSystem());
            
            ecsFixedUpdateSystems = new EcsSystems(ecsWorld)
                .Add(new MovementSystem());

            ecsUpdateSystems.ProcessInjects();
            ecsFixedUpdateSystems.ProcessInjects();
            
            ecsUpdateSystems.Init();
            ecsFixedUpdateSystems.Init();

            ecsWorld.NewEntity().Replace(new CreateWorldObjectEvent()
            {
                Prefab = barbarianGameObject
            });
        }

        private void Update()
        {
            ecsUpdateSystems.Run();
        }

        private void FixedUpdate()
        {
            ecsFixedUpdateSystems.Run();
        }

        private void OnDestroy()
        {
            ecsUpdateSystems.Destroy();
            ecsFixedUpdateSystems.Destroy();
            ecsWorld.Destroy();
        }
    }
}
