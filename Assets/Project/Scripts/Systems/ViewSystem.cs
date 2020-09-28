using Leopotam.Ecs;
using Project.Scripts.Components;
using Project.Scripts.Events;
using UnityEngine;

namespace Project.Scripts.Systems
{
    
    
    public class ViewSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CreateGameObjectEvent> createEvents = null;

        public void Run()
        {
            foreach (int i in createEvents)
            {
                EcsEntity entity = createEvents.GetEntity(i);

                GameObject newInstance = Object.Instantiate(entity.Get<CreateGameObjectEvent>().Prefab);
                entity.Get<ViewComponent>().GameObjectRef = newInstance;
                entity.Del<CreateGameObjectEvent>();
                entity.Replace(new MovementComponent()
                {
                    Rigidbody2D = newInstance.GetComponent<Rigidbody2D>(),
                    Speed = 3f
                });
                entity.Replace(new PlayerInputComponent()
                {
                    InputMaster = new InputMaster()
                });
                ref PlayerInputComponent playerInputComponent = ref entity.Get<PlayerInputComponent>();
                playerInputComponent.InputMaster.Enable();
                entity.Replace(new InputComponent());
            }
        }
    }
}