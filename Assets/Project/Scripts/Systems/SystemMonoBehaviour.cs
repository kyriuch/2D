using Project.Scripts.Components;
using UnityEngine;

namespace Project.Scripts.Systems
{
    public partial class SystemMonoBehaviour : MonoBehaviour
    {
        private EntityComponentsCache entityComponentsCache;

        private void Awake()
        {
            SystemAwake();
        }

        private void Update()
        {
            SystemUpdate();
        }

        private void OnEnable()
        {
            SystemEnabled();
        }

        private void OnDisable()
        {
            SystemDisabled();
        }

        protected virtual void SystemAwake()
        {
            if (name.Contains("Systems"))
            {
                entityComponentsCache = transform.parent.GetComponentInChildren<EntityComponentsCache>();
            }
            else
            {
                entityComponentsCache = transform.GetComponentInChildren<EntityComponentsCache>();
            }
            
            entityComponentsCache.PopulateCache();
        }

        protected virtual void SystemUpdate() { }

        protected virtual void SystemEnabled() { }

        protected virtual void SystemDisabled() { }
    }
}
