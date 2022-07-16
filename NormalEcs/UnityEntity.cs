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
            entity = CreateGameObjectEntity(coreNormalEcs.GetWorld(), gameObject);
            entity.AddComponent(new TransformComp()
            {
                transform = transform
            });
        }
        
        public static Entity CreateGameObjectEntity(World world, GameObject unityGameObject)
        {
            if(!unityGameObject.TryGetComponent(out UnityEntity unityEntity)) Debug.LogError("Trying to create an object that is not an entity");
            int id = world.entityData.entities.arrayVolume;
            if (world.entityData.entityIDRecycleQueue.Count > 0)
            {
                id = world.entityData.entityIDRecycleQueue.Dequeue();
                Entity newEntityRecycled = new Entity(id, world.entityData.entities.arrayVolume,world,unityGameObject);
                world.entityData.entities.AddAtIndex(newEntityRecycled,id);
                return newEntityRecycled;
            }

            Entity newEntity = new Entity(id, id,world,unityGameObject);
            world.entityData.entities.Add(newEntity);
            return newEntity;
        }
    }
}