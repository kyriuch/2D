using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Components
{
    public class EntityComponentsCache : MonoBehaviour
    {
        public Dictionary<Type, Component> Cache { get; private set; }

        private bool wasPopupalted;
        
        public void PopulateCache()
        {
            if (wasPopupalted)
            {
                return;
            }
            
            AddGameObjectComponentsToCache(gameObject);
            AddGameObjectComponentsToCache(transform.parent.gameObject);

            wasPopupalted = true;
        }

        private void AddGameObjectComponentsToCache(GameObject go)
        {
            List<Component> tempList = new List<Component>();

            go.GetComponents(tempList);

            if (Cache == null)
            {
                Cache = new Dictionary<Type, Component>();
            }
            
            for (int i = 0; i < tempList.Count; i++)
            {
                Cache[tempList[i].GetType()] = tempList[i];
            }
        }
    }
}
