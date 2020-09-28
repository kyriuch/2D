using System;
using UnityEngine;

namespace Project.Scripts.Components
{
    public class Input : EntityComponent
    {
        public Vector2 Movement { get; set; }
        public event Action AttackPerformed;

        public void DispatchAttackPerformed()
        {
            AttackPerformed?.Invoke();
        }
    }
}
