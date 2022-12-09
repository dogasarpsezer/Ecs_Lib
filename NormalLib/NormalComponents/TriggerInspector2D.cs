using System;
using NormalEcs;
using UnityEngine;

namespace Ecs_Lib.NormalComponents
{
    public struct Trigger2DComp : INormalComponent
    {
        public TriggerListener2D triggerListener2D;
    }

    public struct TriggerEntered2DComp : INormalComponent
    {
        public Collider2D colliderEntered2D;
    }

    public struct TriggerExited2DComp : INormalComponent
    {
        public Collider2D colliderExited2D;
    }
    
    public class TriggerInspector2D : InspectorComponent<Trigger2DComp>
    {
        public override object SetComponent()
        {
            component.triggerListener2D = gameObject.AddComponent<TriggerListener2D>();
            return base.SetComponent();
        }
    }
    
    public class TriggerListener2D : MonoBehaviour
    {
        private Collider2D triggeredEnteredCollider = null;
        private Collider2D triggeredExitedCollider = null;

        private void OnTriggerEnter2D(Collider2D other)
        {
            triggeredEnteredCollider = other;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            triggeredExitedCollider = other;
        }

        public Collider2D GetTriggerEnteredCollider()
        {
            return triggeredEnteredCollider;
        }
        
        public Collider2D GetTriggerExitedCollider()
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