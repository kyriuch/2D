using Leopotam.Ecs;
using Project.Scripts.Components;

namespace Project.Scripts.Systems
{
    public class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InputComponent, MovementComponent> movementFilter = null;
        
        public void Run()
        {
            foreach (int i in movementFilter)
            {
                InputComponent inputComponent = movementFilter.Get1(i);
                MovementComponent movementComponent = movementFilter.Get2(i);

                movementComponent.Rigidbody2D.velocity = inputComponent.MovementVector * movementComponent.Speed;
            }
        }
    }
}