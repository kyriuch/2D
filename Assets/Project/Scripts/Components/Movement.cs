using UnityEngine;

namespace Project.Scripts.Components
{
    public class Movement : EntityComponent
    {
        [SerializeField] private float speed;

        public float Speed => speed;
    }
}
