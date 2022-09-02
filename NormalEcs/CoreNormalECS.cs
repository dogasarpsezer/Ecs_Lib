using System;
using UnityEngine;

namespace NormalEcs
{
    public class CoreNormalECS : MonoBehaviour
    {
        World world;
        SystemManager systemManager;
        void Awake()
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