using System;
using System.Collections.Generic;

namespace NormalEcs
{
    public static class ComponentManager
    {
        public static Dictionary<Type, int> componentIdCenter = new Dictionary<Type, int>();
        public static Dictionary<Type, int> labelIdCenter = new Dictionary<Type, int>();
        public static ComponentPool[] componentPools = new ComponentPool[64];
        public static int componentCounter = 0;
        public static int labelCounter = 0;
        
        public static int GetComponentId<T>() where T : INormalComponent
        {
            var componentType = typeof(T);
            if(componentIdCenter.ContainsKey(componentType)) return componentIdCenter[componentType];
        
            componentIdCenter.Add(componentType,componentCounter);
            componentPools[componentCounter] = new ComponentPool();
            componentCounter++;
            return componentCounter - 1;
        }
        
        public static Type GetComponentType(int index)
        {
            foreach (var type in componentIdCenter)
            {
                if (type.Value == index)
                {
                    return type.Key;
                }
            }

            return typeof(INormalComponent);
        }
        
        public static Type GetComponent(int index)
        {
            foreach (var component in componentIdCenter)
            {
                if (component.Value == index)
                {
                    return component.Key;
                }
            }

            return typeof(INormalComponent);
        }
        
        public static int GetLabelId<T>() where T : struct, INormalLabel
        {
            var tagType = typeof(T);
            if (labelIdCenter.ContainsKey(tagType)) return labelIdCenter[tagType];
            labelIdCenter.Add(tagType,labelCounter);
            labelCounter++;
            return labelCounter - 1;
        }

        public static Type GetLabelType(int idx)
        {
            foreach (var label in labelIdCenter)
            {
                if (label.Value == idx)
                {
                    return label.Key;
                }
            }

            return typeof(INormalLabel);
        }
    }
}