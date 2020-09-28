using Project.Scripts.Components;
using UnityEngine;

namespace Project.Scripts.Systems
{
    public class PlayerAnimatorSystem : SystemMonoBehaviour
    {
        private Components.Input input;
        private SpriteRenderer spriteRenderer;
        private AnimatorData animatorData;
        private Animator animator;

        protected override void SystemAwake()
        {
            base.SystemAwake();

            TryGetEntityComponent(out input);
            TryGetEntityComponent(out spriteRenderer);
            TryGetEntityComponent(out animatorData);
            TryGetEntityComponent(out animator);
        }

        protected override void SystemEnabled()
        {
            base.SystemEnabled();
            
            input.AttackPerformed += OnAttackPerformed;
        }

        protected override void SystemDisabled()
        {
            base.SystemDisabled();
            
            input.AttackPerformed -= OnAttackPerformed;
        }

        protected override void SystemUpdate()
        {
            base.SystemUpdate();
            
            UpdateMovementAnimation();
        }

        private void UpdateMovementAnimation()
        {
            if (animatorData.AnimatorState == AnimatorState.Attack)
            {
                return;
            }

            if (input.Movement != Vector2.zero)
            {
                spriteRenderer.flipX = input.Movement.x >= 0;
                animator.Play(animatorData.RunAnimation.name);
            }
            else
            {
                animator.Play(animatorData.IdleAnimation.name);
            }
        }

        private void OnAttackPerformed()
        {
            if (animatorData.AnimatorState != AnimatorState.Attack)
            {
                spriteRenderer.flipX = input.Movement.x < 0;
                if (Time.time - animatorData.LastAttackAnimationTime > animatorData.AttackAnimationInterruptTime)
                {
                    animatorData.CurrentAttackAnimationIndex = 0;
                }
                
                animator.Play(animatorData.AttackAnimations[animatorData.CurrentAttackAnimationIndex].name);
                animatorData.CurrentAttackAnimationIndex = (animatorData.CurrentAttackAnimationIndex + 1) %
                                                           animatorData.AttackAnimations.Length;
                animatorData.AnimatorState = AnimatorState.Attack;
            }
        }
        
        public void AttackFinished()
        {
            animatorData.AnimatorState = AnimatorState.Idle;
            animatorData.LastAttackAnimationTime = Time.time;
        }
    }
}
