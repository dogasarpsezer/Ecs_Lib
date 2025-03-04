﻿using NormalLib.NormalSystems;
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
            systemManager.HandleInjection();
        }
        
        public World GetWorld()
        {
            return world;
        }
        
        public void SetSystems()
        {
            systemManager.AddSystem(new TriggerSystem()); // THIS SHOULD BE ADDED BEFORE ANY SYSTEM THAT USES 3D TRIGGER 
            systemManager.AddSystem(new TriggerSystem2D()); // THIS SHOULD BE ADDED BEFORE ANY SYSTEM THAT USES 2D TRIGGER 
        }
    }
}