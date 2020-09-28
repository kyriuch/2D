using Leopotam.Ecs;
using Project.Scripts.Components;
using UnityEngine;

namespace Project.Scripts.Systems
{
    public class PlayerInputSystem : IEcsDestroySystem, IEcsRunSystem
    {
        private readonly EcsFilter<PlayerInputComponent, InputComponent> playerInputFilter = null;

        public void Destroy()
        {
            foreach (int i in playerInputFilter)
            {
                playerInputFilter.Get1(i).InputMaster.Disable();
            }
        }

        public void Run()
        {
            foreach (int i in playerInputFilter)
            {
                ref InputComponent inputComponent = ref playerInputFilter.Get2(i);
                inputComponent.MovementVector = playerInputFilter.Get1(i).InputMaster.PlayerActions.MovementAction
                    .ReadValue<Vector2>();
            }
        }
    }
}