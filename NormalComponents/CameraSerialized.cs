using System;
using NormalEcs;
using UnityEngine;

namespace Ecs_Lib.NormalComponents
{

    [Serializable]
    public struct CameraComponent : INormalComponent
    {
        [NonSerialized]public Camera camera;
        public string GetValuesString()
        {
            return camera.ToString();
        }
    }
    
    public class CameraSerialized : InspectorComponent<CameraComponent>
    {
        public override object SetComponent()
        {
            component.camera = GetComponent<Camera>();
            return component;
        }
    }
}