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
            systemManager = new SystemManager(world);            
            systemManager.Awake();
        }

        private void Start()
        {
            systemManager.Start();
        }

        private void Update()
        {
            systemManager.Update();
        }

        private void LateUpdate()
        {
            systemManager.LateUpdate();
        }

        private void FixedUpdate()
        {
            systemManager.FixedUpdate();
        }
        
        public World GetWorld()
        {
            return world;
        }
    }
}