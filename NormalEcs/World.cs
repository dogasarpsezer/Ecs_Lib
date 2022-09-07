using System;
using System.Collections.Generic;
using NormalEcs;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;


//TODO: System, Data Injection, UnityEntityIntegration, Visual Debugging
public struct EntityData
{
    public Queue<int> entityIDRecycleQueue;
    public NormalArray<Entity> entities;
    
    public EntityData(int initArrayLength)
    {
        entityIDRecycleQueue = new Queue<int>();
        entities = new NormalArray<Entity>(initArrayLength);
    }
}

public class World
{
    private static int componentCounter = 0;
    private static int labelCounter = 0;
    
    private static Dictionary<Type, int> componentIdCenter = new Dictionary<Type, int>();
    private static Dictionary<Type, int> labelIdCenter = new Dictionary<Type, int>();
    
    public ComponentPool[] componentPools = new ComponentPool[64];
    public EntityData entityData = new EntityData(64);
    public Entity CreateEntity(GameObject unityGameObject)
    {
        int id = entityData.entities.arrayVolume;
        if (entityData.entityIDRecycleQueue.Count > 0)
        {
            id = entityData.entityIDRecycleQueue.Dequeue();
            Entity newEntityRecycled = new Entity(id, entityData.entities.arrayVolume,this,unityGameObject);
            entityData.entities.AddAtIndex(newEntityRecycled,id);
            return newEntityRecycled;
        }

        Entity newEntity = new Entity(id, id,this,unityGameObject);
        entityData.entities.Add(newEntity);
        return newEntity;
    }
    
    public int GetComponentId<T>() where T : struct, INormalComponent
    {
        var componentType = typeof(T);
        if(componentIdCenter.ContainsKey(componentType)) return componentIdCenter[componentType];
        
        componentIdCenter.Add(componentType,componentCounter);
        componentPools[componentCounter] = new ComponentPool();
        componentCounter++;
        return componentCounter - 1;
    }

    public Type GetComponentType(int index)
    {
        foreach (var type in componentIdCenter)
        {
            if (type.Value == index)
            {
                return type.Key;
            }
        }

        return typeof(INormalComponent);
    }
    
    public int GetLabelId<T>() where T : struct, INormalLabel
    {
        var tagType = typeof(T);
        if (labelIdCenter.ContainsKey(tagType)) return labelIdCenter[tagType];
        labelIdCenter.Add(tagType,labelCounter);
        labelCounter++;
        return labelCounter - 1;
    }

    public Type GetLabelType(int idx)
    {
        foreach (var label in labelIdCenter)
        {
            if (label.Value == idx)
            {
                return label.Key;
            }
        }

        return typeof(INormalLabel);
    }

    public Type GetComponent(int index)
    {
        foreach (var component in componentIdCenter)
        {
            if (component.Value == index)
            {
                return component.Key;
            }
        }

        return typeof(INormalComponent);
    }
}

