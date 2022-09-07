using System;
using System.Collections.Generic;
using DefaultNamespace;
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
            systemManager.SetWorld(ref world);
            
            SetSystems();
        }
        
        public World GetWorld()
        {
            return world;
        }


        public void SetSystems()
        {
            systemManager.AddSystem(new MoveSystem());
        }
    }
}