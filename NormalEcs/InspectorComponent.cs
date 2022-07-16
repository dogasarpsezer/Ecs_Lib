using System;
using UnityEngine;

namespace NormalEcs
{

    public abstract class InspectorComponent : MonoBehaviour
    {
        public abstract object SetComponent();
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
}