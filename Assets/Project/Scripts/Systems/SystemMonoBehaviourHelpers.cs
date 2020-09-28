using UnityEngine;

namespace Project.Scripts.Systems
{
    public partial class SystemMonoBehaviour
    {
        protected bool TryGetEntityComponent<T>(out T component) where T : Component
        {
            if(entityComponentsCache.Cache.TryGetValue(typeof(T), out Component entityComponent))
            {
                component = (T) entityComponent;
                
                return true;
            }

            component = default;
            return false;
        }
    }
}
