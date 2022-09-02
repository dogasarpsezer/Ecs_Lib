using System;
using UnityEngine;

namespace NormalEcs
{
    public class CoreNormalECS : MonoBehaviour
    {
        private World world;
        private SystemManager systemManager;
        private void Awake()
        {
            world = new World();
            systemManager = gameObject.GetComponent<SystemManager>();
        }
        
        public World GetWorld()
        {
            return world;
        }
    }
}