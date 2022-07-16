using System;
using System.Collections;
using System.Collections.Generic;
using NormalEcs;
using UnityEngine;

[Serializable]
public struct TransformComp : INormalComponent
{
    public Transform transform;
}

public class TransformSerialized : InspectorComponent<TransformComp>
{
    public override object SetComponent()
    {
        return component;
    }
}
