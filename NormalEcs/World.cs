using System;
using System.Collections.Generic;
using NormalEcs;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;


//TODO: System, Data Injection, UnityEntityIntegration, Visual Debugging
public struct EntityData
{
    private Queue<int> entityIDRecycleQueue;
    private NormalArray<Entity> entities;
    
    public EntityData(int initArrayLength)
    {
        entityIDRecycleQueue = new Queue<int>();
        entities = new NormalArray<Entity>(initArrayLength);
    }
    
    public Queue<int> GetDeadEntities()
    {
        return entityIDRecycleQueue;
    }
    public NormalArray<Entity> GetEntityArray()
    {
        return entities;
    }
}

public class World
{
    private static int componentCounter = 0;
    private static int labelCounter = 0;
    
    
    public EntityData entityData = new EntityData(64);
    /*public Entity CreateEntity(GameObject unityGameObject)
    {
        int id = entityData.GetEntityArray().arrayVolume;
        if (entityData.GetDeadEntities().Count > 0)
        {
            id = entityData.GetDeadEntities().Dequeue();
            Entity newEntityRecycled = new Entity(id, entityData.GetEntityArray().arrayVolume,this,unityGameObject);
            entityData.GetEntityArray().AddAtIndex(newEntityRecycled,id);
            return newEntityRecycled;
        }

        Entity newEntity = new Entity(id, id,this,unityGameObject);
        entityData.GetEntityArray().Add(newEntity);
        return newEntity;
    }*/
}

