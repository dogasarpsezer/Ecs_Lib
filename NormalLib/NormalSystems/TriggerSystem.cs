using Ecs_Lib.NormalComponents;
using NormalEcs;

namespace NormalLib.NormalSystems
{
    public class TriggerSystem : NormalEcs.System
    {
        private Filter<TriggerComp> triggerListenerFilter = new Filter<TriggerComp>().ExcludeComponent<TriggerExitComp>().ExcludeComponent<TriggerEnteredComp>();
        private Filter<TriggerEnteredComp> triggerEnteredFilter = null;
        private Filter<TriggerExitComp> triggerExitFilter = null;
        public override void Update()
        {
            triggerEnteredFilter.Iterate((Entity entity, ref TriggerEnteredComp component) =>
            {
                entity.RemoveComponent<TriggerEnteredComp>();
            });
            
            triggerExitFilter.Iterate((Entity entity, ref TriggerExitComp component) =>
            {
                entity.RemoveComponent<TriggerExitComp>();
            });
            
            triggerListenerFilter.Iterate((Entity entity, ref TriggerComp triggerComp) =>
            {
                var enteredCollider = triggerComp.triggerListener.GetTriggerEnteredCollider();
                var exitCollider = triggerComp.triggerListener.GetTriggerExitedCollider();
                
                if (enteredCollider)
                {
                    entity.AddComponent(new TriggerEnteredComp()
                    {
                        enteredCollider = enteredCollider
                    });
                    triggerComp.triggerListener.ResetTriggerEnteredCollider();
                }

                if (exitCollider)
                {
                    entity.AddComponent(new TriggerExitComp()
                    {
                        exitedCollider = exitCollider
                    });
                    triggerComp.triggerListener.ResetTriggerExitedCollider();
                }
            });
        }
    }
}