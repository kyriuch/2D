using System;
using UnityEngine;

namespace Project.Scripts
{
    public class DestroySelf : MonoBehaviour
    {
        private void Awake()
        {
            Destroy(gameObject);
        }
    }
}
