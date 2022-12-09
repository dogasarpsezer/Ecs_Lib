using System;
using UnityEngine;

namespace NormalEcs
{

    public abstract class InspectorComponent : MonoBehaviour
    {
        public abstract object SetComponent();
    }

    public abstract class InspectorLabel : MonoBehaviour
    {
        
    }
    
    [RequireComponent(typeof(UnityEntity))]
    public abstract class InspectorComponent<T> : InspectorComponent
        where T: struct,INormalComponent
    {
        public T component;
        private void Awake()
        {
            var entity = gameObject.GetComponent<UnityEntity>().entity;
            entity.AddComponent((T)SetComponent());
        }
        
        public override object SetComponent()
        {
            return component;
        }
        
    }
    
    [RequireComponent(typeof(UnityEntity))]
    public abstract class InspectorLabel<T> : InspectorLabel
        where T: struct,INormalLabel
    {
        private void Awake()
        {
            var entity = gameObject.GetComponent<UnityEntity>().entity;
            entity.AddLabel<T>();
        }
    }
}