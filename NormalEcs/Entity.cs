using System;
using System.Collections;
using UnityEngine;

namespace NormalEcs
{
public class Entity
{
    public int entityId;
    public int creationId;
    public BitArray componentBitMask = new BitArray(64);
    public BitArray labelBitMask = new BitArray(64);
    private World world;
    private GameObject unityGameObject;
    public Entity(int entityId,int creationId,World world, GameObject unityGameObject)
    {
        this.entityId = entityId;
        this.creationId = creationId;
        componentBitMask = new BitArray(64);
        this.world = world;
        this.unityGameObject = unityGameObject;
    }

    public bool IsNull()
    {
        return this == null;
    }

    public override string ToString()
    {
        return "Entity Creation Id: " + creationId + " Entity ID: " + entityId;
    }

    public bool isAlive()
    {
        if (world.entityData.entityIDRecycleQueue.Contains(entityId))
        {
            return false;
        }

        return true;
    }
    
    public void AddComponent<T>(T component) where T : struct, INormalComponent
    {
        if (HasComponent<T>())
        {
            #if UNITY_EDITOR
            Debug.LogError("The entity cant have more than one of the same component! Entity Id = " + entityId);
            #endif
            return;
        }

        var idBit = world.GetComponentId<T>();
        componentBitMask.Set(idBit,true);
        world.componentPools[idBit].componentPool.array[entityId] = component;
    }
    
    public bool HasComponent<T>() where T : struct,INormalComponent
    {
        return componentBitMask[world.GetComponentId<T>()];
    }
    
    public T GetComponent<T>() where T:struct,INormalComponent
    {
        return (T)world.componentPools[world.GetComponentId<T>()].componentPool.array[entityId];
    }

    public void RemoveComponent<T>() where T : struct, INormalComponent
    {
        var compId = world.GetComponentId<T>();
        if (!componentBitMask[compId])
        {
            #if UNITY_EDITOR
            Type compType = typeof(T);
            Debug.LogError("There is no component on this entity of type: " + compType.FullName);
            #endif
            return;
        }
        world.componentPools[compId].componentPool.Pop(entityId);
        componentBitMask[compId] = false;
    }

    public void AddLabel<T>() where T : struct, INormalLabel
    {
        labelBitMask[world.GetLabelId<T>()] = true;
    }

    public bool HasLabel<T>() where T : struct, INormalLabel
    {
        return labelBitMask[world.GetLabelId<T>()];
    }

    public void RemoveLabel<T>() where T : struct, INormalLabel
    {
        labelBitMask[world.GetLabelId<T>()] = false;
    }

    public void RemoveAllLabels<T>() where T : struct, INormalLabel
    {
        labelBitMask.SetAll(false);
    }
    
    public void Destroy()
    {
        foreach (var compPool in world.componentPools)
        {
            compPool.componentPool.Pop(entityId);
        }
        world.entityData.entityIDRecycleQueue.Enqueue(entityId);
        entityId = -entityId;
        world.entityData.entities.Pop(entityId);
    }
}

}