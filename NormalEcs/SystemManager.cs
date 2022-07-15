using System;
using System.Collections.Generic;
using UnityEngine;

namespace NormalEcs
{
    public class SystemManager
    {
        private List<System> systems = new List<System>();
        private World world = new World();

        public SystemManager(World world)
        {
            this.world = world;
        }
        
        public void Awake()
        {
            foreach (var system in systems)
            {
                system.world = world;
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

        public void AddSystem<T>(T system) where T: System
        {
            system.world = world;
            systems.Add(system);
        }
    }
}