using System;
using NormalEcs;
using UnityEngine;

namespace Ecs_Lib.NormalComponents
{
    [Serializable]
    public struct MeshComp : INormalComponent
    {
        public MeshRenderer meshRenderer;
        public MeshFilter meshFilter;
    }
    
    public class MeshInspector : InspectorComponent<MeshComp>
    {
        
    }
}