using System.Collections;
using System.Collections.Generic;

namespace NormalEcs
{
    public class QueryOperator
    {
        public List<int> includeComponents;
        public List<int> excludeComponents;
        public List<int> includeLabel;
        public List<int> excludeLabel;
        
        public QueryOperator()
        {
            includeComponents = new List<int>();
            excludeComponents = new List<int>();
            includeLabel = new List<int>();
            excludeLabel = new List<int>();
        }
        
        public void IncludeComponent<T>() where T : struct, INormalComponent
        {
            includeComponents.Add(ComponentManager.GetComponentId<T>());
        }

        public void ExcludeComponent<T>() where T : struct, INormalComponent
        {
            excludeComponents.Add(ComponentManager.GetComponentId<T>());
        }

        public void IncludeLabel<T>() where T : struct, INormalLabel
        {
            includeLabel.Add(ComponentManager.GetLabelId<T>());
        }

        public void ExcludeLabel<T>() where T : struct, INormalLabel
        {
            excludeLabel.Add(ComponentManager.GetLabelId<T>());
        }
        
        public bool Query(BitArray entityComponentMask,BitArray entityLabelMask)
        {
            foreach (var component in includeComponents)
            {
                if (!entityComponentMask[component]) return false;
            }

            foreach (var component in excludeComponents)
            {
                if (entityComponentMask[component]) return false;
            }

            foreach (var label in includeLabel)
            {
                if (!entityLabelMask[label]) return false;
            }

            foreach (var label in excludeLabel)
            {
                if (entityLabelMask[label]) return false;
            }
            return true;
        }
    }
}