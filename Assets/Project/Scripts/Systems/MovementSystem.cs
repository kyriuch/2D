using Project.Scripts.Components;
using UnityEngine;

namespace Project.Scripts.Systems
{
    public class MovementSystem : SystemMonoBehaviour
    {
        private Components.Input input;
        private Movement movement;
        private Rigidbody2D rb;

        protected override void SystemAwake()
        {
            base.SystemAwake();

            TryGetEntityComponent(out input);
            TryGetEntityComponent(out movement);
            TryGetEntityComponent(out rb);
        }

        private void Update()
        {
            Vector3 movementVector = new Vector3(input.Movement.x, input.Movement.y, 0);

            rb.velocity = movementVector * movement.Speed;
        }
    }
}
