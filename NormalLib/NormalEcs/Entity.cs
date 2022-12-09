using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace NormalEcs
{
public class Entity
{
    public int entityId;
    public BitArray componentBitMask = new BitArray(64); //11100111010111
    public BitArray labelBitMask = new BitArray(64); //111000111001
    public World world;
    private GameObject unityGameObject;
    public Entity(int entityId,int creationId,World world, GameObject unityGameObject)
    {
        this.entityId = entityId;
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
        return "Entity ID: " + entityId;
    }

    public bool isAlive()
    {
        if (world.entityData.GetDeadEntities().Contains(entityId))
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

        var idBit = ComponentManager.GetComponentId<T>();
        componentBitMask.Set(idBit,true);
        ComponentManager.componentPools[idBit].componentPool.array[entityId] = component;
    }
    
    public bool HasComponent<T>() where T : struct,INormalComponent
    {
        return componentBitMask[ComponentManager.GetComponentId<T>()];
    }
    
    public T GetComponent<T>() where T:struct,INormalComponent
    {
        var val = (T)ComponentManager.componentPools[ComponentManager.GetComponentId<T>()].componentPool.array[entityId];
        
        return val;
    }
    
    public void RemoveComponent<T>() where T : struct, INormalComponent
    {
        var compId = ComponentManager.GetComponentId<T>();
        if (!componentBitMask[compId])
        {
            #if UNITY_EDITOR
            Type compType = typeof(T);
            Debug.LogError("There is no component on this entity of type: " + compType.FullName);
            #endif
            return;
        }
        ComponentManager.componentPools[compId].componentPool.Pop(entityId);
        componentBitMask[compId] = false;
    }

    public void AddLabel<T>() where T : struct, INormalLabel
    {
        labelBitMask[ComponentManager.GetLabelId<T>()] = true;
    }

    public bool HasLabel<T>() where T : struct, INormalLabel
    {
        return labelBitMask[ComponentManager.GetLabelId<T>()];
    }
    
    
    
    public List<Type> GetAllLabel()
    {
        List<Type> labelTypes = new List<Type>();
        for (int i = 0; i < labelBitMask.Length; i++)
        {
            if (labelBitMask[i])
            {
                labelTypes.Add(ComponentManager.GetLabelType(i));
            }
        }

        return labelTypes;
    }
    
    public void RemoveLabel<T>() where T : struct, INormalLabel
    {
        labelBitMask[ComponentManager.GetLabelId<T>()] = false;
    }

    public void RemoveAllLabels<T>() where T : struct, INormalLabel
    {
        labelBitMask.SetAll(false);
    }
    
    public void Destroy()
    {
        foreach (var compPool in ComponentManager.componentPools)
        {
            compPool.componentPool.Pop(entityId);
        }
        world.entityData.GetDeadEntities().Enqueue(entityId);
        entityId = -entityId;
        world.entityData.GetEntityArray().Pop(entityId);
    }
    
    
}

}