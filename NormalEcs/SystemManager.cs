using System;
using System.Collections.Generic;
using UnityEngine;

namespace NormalEcs
{
    [RequireComponent(typeof(CoreNormalECS))]
    public class SystemManager : MonoBehaviour
    {
        private List<System> systems = new List<System>();

        public void Awake()
        {
            foreach (var system in systems)
            {
                system.Awake();
            }
        }

        public void Start()
        {
            foreach (var system in systems)
            {
                system.Start();
            }
        }

        public void Update()
        {
            foreach (var system in systems)
            {
                system.Update();
            }
        }

        public void LateUpdate()
        {
            foreach (var system in systems)
            {
                system.LateUpdate();
            }
        }

        public void FixedUpdate()
        {
            foreach (var system in systems)
            {
                system.FixedUpdate();
            }
        }

        public void AddSystem<T>(T system,World world) where T: System
        {
            system.world = world;
            systems.Add(system);
        }
    }
}