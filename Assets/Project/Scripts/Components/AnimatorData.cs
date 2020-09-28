using UnityEngine;

namespace Project.Scripts.Components
{
    public enum AnimatorState
    {
        Idle,
        Run,
        Attack
    }
    
    public class AnimatorData : EntityComponent
    {
        [SerializeField] private AnimationClip idleAnimation;
        [SerializeField] private AnimationClip runAnimation;
        [SerializeField] private AnimationClip[] attackAnimations;
        [SerializeField] private float attackAnimationsInterruptTime;
        
        private bool animationChanged;

        public AnimationClip IdleAnimation => idleAnimation;
        public AnimationClip RunAnimation => runAnimation;
        public AnimationClip[] AttackAnimations => attackAnimations;
        public float AttackAnimationInterruptTime => attackAnimationsInterruptTime;
        public AnimatorState AnimatorState { get; set; }
        public int CurrentAttackAnimationIndex { get; set; }
        public float LastAttackAnimationTime { get; set; }
    }
}
