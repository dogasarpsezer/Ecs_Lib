using System;
using PlayerInput;
using UnityEngine;
using WorldBuilder;

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
            systemManager.AddSystem(new WorldBuildingSystem(),world);
        }
        
        public World GetWorld()
        {
            return world;
        }
    }
}