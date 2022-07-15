using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NormalEcs
{
    public class Filter
    {
        public World world;
        public List<Entity> entities => FilterEntities();
        public QueryOperator queryOperator;
        public Filter(World world)
        {
            this.world = world;
            queryOperator = new QueryOperator(world);
        }

        public Filter ExcludeComponent<U>()
            where U:struct,INormalComponent
        {
            queryOperator.ExcludeComponent<U>();
            return this;
        }

        public Filter IncludeLabel<L>()
            where L:struct,INormalLabel
        {
            queryOperator.IncludeLabel<L>();
            return this;
        }

        public Filter ExcludeLabel<L>()
            where L: struct,INormalLabel
        {
            queryOperator.ExcludeLabel<L>();
            return this;
        }
        
        public virtual List<Entity> FilterEntities()
        {
            return new List<Entity>();
        }
    }
    
    public class Filter<NormalComponent0> : Filter 
        where NormalComponent0 : struct, INormalComponent
    {
        public Filter(World world) : base(world)
        {
            queryOperator.IncludeComponent<NormalComponent0>();
        }

        public new Filter<NormalComponent0> ExcludeComponent<U>()
            where U :struct,INormalComponent
        {
            queryOperator.ExcludeComponent<U>();
            return this;
        }

        public new Filter<NormalComponent0> IncludeLabel<L>()
            where L:struct,INormalLabel
        {
            queryOperator.IncludeLabel<L>();
            return this;
        }

        public new Filter<NormalComponent0> ExcludeLabel<L>()
            where L: struct,INormalLabel
        {
            queryOperator.ExcludeLabel<L>();
            return this;
        }
        
        public override List<Entity> FilterEntities()
        {
            int entityCount = 0;
            List<Entity> entitiesCatched = new List<Entity>();
            foreach (var entity in world.entityData.entities.array)
            {
                if (entity != null && queryOperator.Query(entity.componentBitMask,entity.labelBitMask))
                {
                    entityCount++;
                    entitiesCatched.Add(entity);
                }
            }
            return entitiesCatched;
        }
    }
    
    public class Filter<NormalComponent0,NormalComponent1> : Filter 
        where NormalComponent0 : struct, INormalComponent
        where NormalComponent1: struct, INormalComponent
    {
        public Filter(World world) : base(world)
        {
            queryOperator.IncludeComponent<NormalComponent0>();
            queryOperator.IncludeComponent<NormalComponent1>();
        }

        public new Filter<NormalComponent0,NormalComponent1>ExcludeComponent<U>()
            where U :struct,INormalComponent
        {
            queryOperator.ExcludeComponent<U>();
            return this;
        }

        public new Filter<NormalComponent0,NormalComponent1> IncludeLabel<L>()
            where L:struct,INormalLabel
        {
            queryOperator.IncludeLabel<L>();
            return this;
        }

        public new Filter<NormalComponent0,NormalComponent1> ExcludeLabel<L>()
            where L: struct,INormalLabel
        {
            queryOperator.ExcludeLabel<L>();
            return this;
        }
        
        public override List<Entity> FilterEntities()
        {
            int entityCount = 0;
            List<Entity> entitiesCatched = new List<Entity>();
            foreach (var entity in world.entityData.entities.array)
            {
                if (entity != null && queryOperator.Query(entity.componentBitMask,entity.labelBitMask))
                {
                    entityCount++;
                    entitiesCatched.Add(entity);
                }
            }
            return entitiesCatched;
        }
    }
    
    public class Filter<NormalComponent0,NormalComponent1,NormalComponent2> : Filter 
        where NormalComponent0 : struct, INormalComponent
        where NormalComponent1: struct, INormalComponent
        where NormalComponent2: struct,INormalComponent
    {
        public Filter(World world) : base(world)
        {
            queryOperator.IncludeComponent<NormalComponent0>();
            queryOperator.IncludeComponent<NormalComponent1>();
            queryOperator.IncludeComponent<NormalComponent2>();
        }

        public new Filter<NormalComponent0,NormalComponent1,NormalComponent2>ExcludeComponent<U>()
            where U :struct,INormalComponent
        {
            queryOperator.ExcludeComponent<U>();
            return this;
        }

        public new Filter<NormalComponent0,NormalComponent1,NormalComponent2>IncludeLabel<L>()
            where L:struct,INormalLabel
        {
            queryOperator.IncludeLabel<L>();
            return this;
        }

        public new Filter<NormalComponent0,NormalComponent1,NormalComponent2> ExcludeLabel<L>()
            where L: struct,INormalLabel
        {
            queryOperator.ExcludeLabel<L>();
            return this;
        }
        
        public override List<Entity> FilterEntities()
        {
            int entityCount = 0;
            List<Entity> entitiesCatched = new List<Entity>();
            foreach (var entity in world.entityData.entities.array)
            {
                if (entity != null && queryOperator.Query(entity.componentBitMask,entity.labelBitMask))
                {
                    entityCount++;
                    entitiesCatched.Add(entity);
                }
            }
            return entitiesCatched;
        }
    }
    
    public class Filter<NormalComponent0,NormalComponent1,NormalComponent2,NormalComponent3> : Filter 
        where NormalComponent0 : struct, INormalComponent
        where NormalComponent1: struct, INormalComponent
        where NormalComponent2: struct,INormalComponent
        where NormalComponent3: struct, INormalComponent
    {
        public Filter(World world) : base(world)
        {
            queryOperator.IncludeComponent<NormalComponent0>();
            queryOperator.IncludeComponent<NormalComponent1>();
            queryOperator.IncludeComponent<NormalComponent2>();
            queryOperator.IncludeComponent<NormalComponent3>();
        }

        public new Filter<NormalComponent0,NormalComponent1,NormalComponent2,NormalComponent3>ExcludeComponent<U>()
            where U :struct,INormalComponent
        {
            queryOperator.ExcludeComponent<U>();
            return this;
        }

        public new Filter<NormalComponent0,NormalComponent1,NormalComponent2,NormalComponent3>IncludeLabel<L>()
            where L:struct,INormalLabel
        {
            queryOperator.IncludeLabel<L>();
            return this;
        }

        public new Filter<NormalComponent0,NormalComponent1,NormalComponent2,NormalComponent3> ExcludeLabel<L>()
            where L: struct,INormalLabel
        {
            queryOperator.ExcludeLabel<L>();
            return this;
        }
        
        public override List<Entity> FilterEntities()
        {
            int entityCount = 0;
            List<Entity> entitiesCatched = new List<Entity>();
            foreach (var entity in world.entityData.entities.array)
            {
                if (entity != null && queryOperator.Query(entity.componentBitMask,entity.labelBitMask))
                {
                    entityCount++;
                    entitiesCatched.Add(entity);
                }
            }
            return entitiesCatched;
        }
    }
    
    public class Filter<NormalComponent0,NormalComponent1,NormalComponent2,NormalComponent3,NormalComponent4> : Filter 
        where NormalComponent0 : struct, INormalComponent
        where NormalComponent1: struct, INormalComponent
        where NormalComponent2: struct,INormalComponent
        where NormalComponent3: struct, INormalComponent
        where NormalComponent4: struct,INormalComponent
    {
        public Filter(World world) : base(world)
        {
            queryOperator.IncludeComponent<NormalComponent0>();
            queryOperator.IncludeComponent<NormalComponent1>();
            queryOperator.IncludeComponent<NormalComponent2>();
            queryOperator.IncludeComponent<NormalComponent3>();
            queryOperator.IncludeComponent<NormalComponent4>();
        }

        public new Filter<NormalComponent0,NormalComponent1,NormalComponent2,NormalComponent3,NormalComponent4>ExcludeComponent<U>()
            where U :struct,INormalComponent
        {
            queryOperator.ExcludeComponent<U>();
            return this;
        }

        public new Filter<NormalComponent0,NormalComponent1,NormalComponent2,NormalComponent3,NormalComponent4>IncludeLabel<L>()
            where L:struct,INormalLabel
        {
            queryOperator.IncludeLabel<L>();
            return this;
        }

        public new Filter<NormalComponent0,NormalComponent1,NormalComponent2,NormalComponent3,NormalComponent4> ExcludeLabel<L>()
            where L: struct,INormalLabel
        {
            queryOperator.ExcludeLabel<L>();
            return this;
        }
        
        public override List<Entity> FilterEntities()
        {
            int entityCount = 0;
            List<Entity> entitiesCatched = new List<Entity>();
            foreach (var entity in world.entityData.entities.array)
            {
                if (entity != null && queryOperator.Query(entity.componentBitMask,entity.labelBitMask))
                {
                    entityCount++;
                    entitiesCatched.Add(entity);
                }
            }
            return entitiesCatched;
        }
    }
}