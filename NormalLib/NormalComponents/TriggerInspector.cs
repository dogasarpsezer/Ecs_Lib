using System;
using NormalEcs;
using UnityEngine;

namespace Ecs_Lib.NormalComponents
{
    public struct TriggerComp : INormalComponent
    {
        public TriggerListener triggerListener;
    }

    public struct TriggerEnteredComp : INormalComponent
    {
        public Collider enteredCollider;
    }

    public struct TriggerExitComp : INormalComponent
    {
        public Collider exitedCollider;
    }
    
    public class TriggerInspector : InspectorComponent<TriggerComp>
    {
        public override object SetComponent()
        {
            component.triggerListener = gameObject.AddComponent<TriggerListener>();
            return component;
        }
        
    }

    public class TriggerListener : MonoBehaviour
    {
        private Collider triggeredEnteredCollider = null;
        private Collider triggeredExitedCollider = null;
        private void OnTriggerEnter(Collider other)
        {
            triggeredEnteredCollider = other;
        }

        private void OnTriggerExit(Collider other)
        {
            triggeredExitedCollider = other;
        }

        public Collider GetTriggerEnteredCollider()
        {
            return triggeredEnteredCollider;
        }
        
        public Collider GetTriggerExitedCollider()
        {
            return triggeredExitedCollider;
        }

        public void ResetTriggerExitedCollider()
        {
            triggeredExitedCollider = null;
        }
        
        public void ResetTriggerEnteredCollider()
        {
            triggeredEnteredCollider = null;
        }
        
    }
}