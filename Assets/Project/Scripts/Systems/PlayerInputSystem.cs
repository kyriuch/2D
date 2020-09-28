using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Scripts.Systems
{
    public class PlayerInputSystem : SystemMonoBehaviour
    {
        private InputMaster inputMaster;
        private Components.Input input;
    
        protected override void SystemAwake()
        {
            base.SystemAwake();

            inputMaster = new InputMaster();
            TryGetEntityComponent(out input);
        }

        protected override void SystemEnabled()
        {
            base.SystemEnabled();
            
            inputMaster.Enable();
            inputMaster.PlayerActions.AttackAction.performed += OnAttackPerformed;
        }

        protected override void SystemDisabled()
        {
            base.SystemDisabled();
            
            inputMaster.PlayerActions.AttackAction.performed -= OnAttackPerformed;
            inputMaster.Disable();
        }
        
        private void OnAttackPerformed(InputAction.CallbackContext obj)
        {
            input.DispatchAttackPerformed();
        }

        protected override void SystemUpdate()
        {
            base.SystemUpdate();
            
            input.Movement = inputMaster.PlayerActions.MovementAction.ReadValue<Vector2>();
        }
    }
}
