using UnityEngine;

namespace Project.Scripts.Components
{
    public class Health : EntityComponent
    {
        [SerializeField] private float maxHealth;
        
        private float currentHealth;

        public float CurrentHealth => currentHealth;
    }
}
