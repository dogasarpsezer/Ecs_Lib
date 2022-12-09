using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace NormalEcs
{
    [RequireComponent(typeof(CoreNormalECS))]
    public class SystemManager : MonoBehaviour
    {
        private List<System> systems = new List<System>();
        private World systemWorld;

        public SystemManager()
        {
            systems = new List<System>();
        }
        
        public SystemManager(World world)
        {
            systems = new List<System>();
            systemWorld = world;
        }
        
        public void HandleInjection(object o)
        {
            foreach (var system in systems)
            {
                var fieldInfo = system.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (var info in fieldInfo)
                {
                    if (info.FieldType == o.GetType())
                    {
                        info.SetValue(system,o);
                    }
                }
            }
        }

        public void HandleInjection()
        {
            foreach (var system in systems)
            {
                var fieldInfo = system.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (var info in fieldInfo)
                {
                    if (info.FieldType.IsSubclassOf(typeof(Filter)))
                    {
                        if (info.GetValue(system) == null)
                        {
                            info.SetValue(system,Activator.CreateInstance(info.FieldType));
                        }
                        Filter filter = (Filter) info.GetValue(system);
                        var val = (Filter)Activator.CreateInstance(info.FieldType,systemWorld, filter.queryOperator);
                        
                        info.SetValue(system,val);
                    }
                }
            }
        }
        
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

        public void SetWorld(ref World world)
        {
            systemWorld = world;
        }
        
        public void AddSystem<T>(T system) where T: System
        {
            system.SetWorld(ref systemWorld);
            
            systems.Add(system);
        }
    }
}