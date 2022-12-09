using Ecs_Lib.NormalComponents;
using NormalEcs;

namespace NormalLib.NormalSystems
{
    public class TriggerSystem2D : NormalEcs.System
    {
        private Filter<Trigger2DComp> triggerListenerFilter = new Filter<Trigger2DComp>().ExcludeComponent<TriggerExited2DComp>().
            ExcludeComponent<TriggerEntered2DComp>();
        private Filter<TriggerEntered2DComp> triggerEnteredFilter = null;
        private Filter<TriggerExited2DComp> triggerExitFilter = null;
        public override void Update()
        {
            triggerEnteredFilter.Iterate((Entity entity, ref TriggerEntered2DComp component) =>
            {
                entity.RemoveComponent<TriggerEntered2DComp>();
            });
            
            triggerExitFilter.Iterate((Entity entity, ref TriggerExited2DComp component) =>
            {
                entity.RemoveComponent<TriggerExited2DComp>();
            });
            
            triggerListenerFilter.Iterate((Entity entity, ref Trigger2DComp triggerComp) =>
            {
                var enteredCollider = triggerComp.triggerListener2D.GetTriggerEnteredCollider();
                var exitCollider = triggerComp.triggerListener2D.GetTriggerExitedCollider();
                
                if (enteredCollider)
                {
                    entity.AddComponent(new TriggerEntered2DComp()
                    {
                        colliderEntered2D = enteredCollider
                    });
                    triggerComp.triggerListener2D.ResetTriggerEnteredCollider();
                }

                if (exitCollider)
                {
                    entity.AddComponent(new TriggerExited2DComp()
                    {
                        colliderExited2D = exitCollider
                    });
                    triggerComp.triggerListener2D.ResetTriggerExitedCollider();
                }
            });
        }
    }
}