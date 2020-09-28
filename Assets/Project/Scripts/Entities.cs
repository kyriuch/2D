using Leopotam.Ecs;
using Project.Scripts.Components;
using Project.Scripts.Events;
using Project.Scripts.Systems;
using UnityEngine;

namespace Project.Scripts
{
    public class Entities : MonoBehaviour
    {
        private EcsWorld ecsWorld;
        private EcsSystems ecsUpdateSystems;
        private EcsSystems ecsFixedUpdateSystems;

        public GameObject BarbarianGameObject;
        
        private void Awake()
        {
            ecsWorld = new EcsWorld();
            
            ecsUpdateSystems = new EcsSystems(ecsWorld)
                .Add(new ViewSystem())
                .Add(new PlayerInputSystem());
            
            ecsFixedUpdateSystems = new EcsSystems(ecsWorld)
                .Add(new MovementSystem());

            ecsUpdateSystems.ProcessInjects();
            ecsFixedUpdateSystems.ProcessInjects();
            
            ecsUpdateSystems.Init();
            ecsFixedUpdateSystems.Init();

            EcsEntity barbarianEntity = ecsWorld.NewEntity();
            barbarianEntity.Replace(new CreateGameObjectEvent()
            {
                Prefab = BarbarianGameObject
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
