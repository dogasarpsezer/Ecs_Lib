using System;
using UnityEngine;

namespace NormalEcs
{
    
    public class UnityEntity : MonoBehaviour
    {
        private CoreNormalECS coreNormalEcs;
        public Entity entity;
        private void Awake()
        {
            coreNormalEcs = FindObjectOfType<CoreNormalECS>();
            if(!coreNormalEcs) Debug.LogError("There is no ECS_CORE prefab in the scene");
            entity = CreateGameObjectEntity(coreNormalEcs.GetWorld(), gameObject);
            entity.AddComponent(new TransformComp()
            {
                transform = transform
            });
        }
        
        public static Entity CreateGameObjectEntity(World world, GameObject unityGameObject)
        {
            if(!unityGameObject.TryGetComponent(out UnityEntity unityEntity)) Debug.LogError("Trying to create an object that is not an entity");
            int id = world.entityData.GetEntityArray().arrayVolume;
            if (world.entityData.GetDeadEntities().Count > 0)
            {
                id = world.entityData.GetDeadEntities().Dequeue();
                Entity newEntityRecycled = new Entity(id, world.entityData.GetEntityArray().arrayVolume,world,unityGameObject);
                world.entityData.GetEntityArray().AddAtIndex(newEntityRecycled,id);
                return newEntityRecycled;
            }

            Entity newEntity = new Entity(id, id,world,unityGameObject);
            world.entityData.GetEntityArray().Add(newEntity);
            return newEntity;
        }
    }
}