using Leopotam.Ecs;
using Project.Scripts.Components;
using Project.Scripts.Events;
using UnityEngine;

namespace Project.Scripts.Systems
{
    
    
    public class WorldObjectSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CreateWorldObjectEvent> createEvents = null;

        public void Run()
        {
            foreach (int i in createEvents)
            {
                EcsEntity entity = createEvents.GetEntity(i);

                GameObject newInstance = Object.Instantiate(entity.Get<CreateWorldObjectEvent>().Prefab);
                entity.Replace(new WorldObjectComponent()
                {
                    WorldObjectRef = newInstance
                }).Replace(new MovementComponent()
                {
                    Rigidbody2D = newInstance.GetComponent<Rigidbody2D>(),
                    Speed = 3f
                }).Replace(new PlayerInputComponent()
                {
                    InputMaster = new InputMaster()
                })
                    .Replace(new InputComponent());
                
                ref PlayerInputComponent playerInputComponent = ref entity.Get<PlayerInputComponent>();
                playerInputComponent.InputMaster.Enable();
            }
        }
    }
}