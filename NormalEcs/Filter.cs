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
        
        public Filter(World world, QueryOperator queryOperator)
        {
            this.world = world;
            this.queryOperator = queryOperator;
        }
        
        public Filter()
        {
            queryOperator = new QueryOperator();
        }
        
        public void Iterate(){}
        
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
        
        protected virtual List<Entity> FilterEntities()
        {
            return new List<Entity>();
        }
    }
    
    public class Filter<NormalComponent0> : Filter 
        where NormalComponent0 : struct, INormalComponent
    {
        public Filter(World world,QueryOperator queryOperator) : base(world,queryOperator)
        {
            
        }
        public Filter()
        {
            queryOperator.IncludeComponent<NormalComponent0>();
        }
        
        public delegate void LoopDelComp(ref NormalComponent0 normalComponent0);

        public delegate void LoopDelEntity(Entity entity, ref NormalComponent0 normalComponent);

        public void Iterate(LoopDelEntity loopDelEntity)
        {
            List<Entity> entitiesCatched = new List<Entity>();
            foreach (var entity in world.entityData.GetEntityArray().array)
            {
                if (entity != null && queryOperator.Query(entity.componentBitMask,entity.labelBitMask))
                {
                    entitiesCatched.Add(entity);
                }
            }

            foreach (var entity in entitiesCatched)
            {
                NormalComponent0 comp0 = entity.GetComponent<NormalComponent0>();
                loopDelEntity(entity,ref comp0);
            }
        }
        
        public void Iterate(LoopDelComp delComp)
        {
            List<Entity> entitiesCatched = new List<Entity>();
            foreach (var entity in world.entityData.GetEntityArray().array)
            {
                if (entity != null && queryOperator.Query(entity.componentBitMask,entity.labelBitMask))
                {
                    entitiesCatched.Add(entity);
                }
            }

            foreach (var entity in entitiesCatched)
            {
                NormalComponent0 comp0 = entity.GetComponent<NormalComponent0>();
                delComp(ref comp0);
            }
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
        
        protected override List<Entity> FilterEntities()
        {
            int entityCount = 0;
            List<Entity> entitiesCatched = new List<Entity>();
            foreach (var entity in world.entityData.GetEntityArray().array)
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
        public delegate void LoopDelComp(ref NormalComponent0 normalComponent0, ref NormalComponent1 normalComponent1);

        public delegate void LoopDelEntity(Entity entity, ref NormalComponent0 normalComponent,
            ref NormalComponent1 normalComponent1);

        public void Iterate(LoopDelEntity loopDelEntity)
        {
            List<Entity> entitiesCatched = new List<Entity>();
            foreach (var entity in world.entityData.GetEntityArray().array)
            {
                if (entity != null && queryOperator.Query(entity.componentBitMask,entity.labelBitMask))
                {
                    entitiesCatched.Add(entity);
                }
            }

            foreach (var entity in entitiesCatched)
            {
                NormalComponent0 comp0 = entity.GetComponent<NormalComponent0>();
                NormalComponent1 comp1 = entity.GetComponent<NormalComponent1>();
                loopDelEntity(entity,ref comp0,ref comp1);
            }
        }
        
        public void Iterate(LoopDelComp delComp)
        {
            List<Entity> entitiesCatched = new List<Entity>();
            foreach (var entity in world.entityData.GetEntityArray().array)
            {
                if (entity != null && queryOperator.Query(entity.componentBitMask,entity.labelBitMask))
                {
                    entitiesCatched.Add(entity);
                }
            }

            foreach (var entity in entitiesCatched)
            {
                NormalComponent0 comp0 = entity.GetComponent<NormalComponent0>();
                NormalComponent1 comp1 = entity.GetComponent<NormalComponent1>();
                delComp(ref comp0,ref comp1);
            }
        }
        
        public Filter(World world,QueryOperator queryOperator) : base(world,queryOperator)
        {
            
        }
        
        public Filter()
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
        
        protected override List<Entity> FilterEntities()
        {
            int entityCount = 0;
            List<Entity> entitiesCatched = new List<Entity>();
            foreach (var entity in world.entityData.GetEntityArray().array)
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
        
        public Filter(World world,QueryOperator queryOperator) : base(world,queryOperator)
        {
            
        }
        
        public Filter()
        {
            queryOperator.IncludeComponent<NormalComponent0>();
            queryOperator.IncludeComponent<NormalComponent1>();
            queryOperator.IncludeComponent<NormalComponent2>();
        }

        public delegate void LoopDelComp(ref NormalComponent0 normalComponent0, ref NormalComponent1 normalComponent1, ref NormalComponent2 normalComponent2);

        public delegate void LoopDelEntity(Entity entity, ref NormalComponent0 normalComponent,
            ref NormalComponent1 normalComponent1, ref NormalComponent2 normalComponent2);

        public void Iterate(LoopDelEntity loopDelEntity)
        {
            List<Entity> entitiesCatched = new List<Entity>();
            foreach (var entity in world.entityData.GetEntityArray().array)
            {
                if (entity != null && queryOperator.Query(entity.componentBitMask,entity.labelBitMask))
                {
                    entitiesCatched.Add(entity);
                }
            }

            foreach (var entity in entitiesCatched)
            {
                NormalComponent0 comp0 = entity.GetComponent<NormalComponent0>();
                NormalComponent1 comp1 = entity.GetComponent<NormalComponent1>();
                NormalComponent2 comp2 = entity.GetComponent<NormalComponent2>();
                loopDelEntity(entity,ref comp0,ref comp1,ref comp2);
            }
        }
        
        public void Iterate(LoopDelComp delComp)
        {
            List<Entity> entitiesCatched = new List<Entity>();
            foreach (var entity in world.entityData.GetEntityArray().array)
            {
                if (entity != null && queryOperator.Query(entity.componentBitMask,entity.labelBitMask))
                {
                    entitiesCatched.Add(entity);
                }
            }

            foreach (var entity in entitiesCatched)
            {
                NormalComponent0 comp0 = entity.GetComponent<NormalComponent0>();
                NormalComponent1 comp1 = entity.GetComponent<NormalComponent1>();
                NormalComponent2 comp2 = entity.GetComponent<NormalComponent2>();
                delComp(ref comp0,ref comp1,ref comp2);
            }
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
        
        protected override List<Entity> FilterEntities()
        {
            int entityCount = 0;
            List<Entity> entitiesCatched = new List<Entity>();
            foreach (var entity in world.entityData.GetEntityArray().array)
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
        public Filter(World world,QueryOperator queryOperator) : base(world,queryOperator)
        {
            
        }
        
        public Filter()
        {
            queryOperator.IncludeComponent<NormalComponent0>();
            queryOperator.IncludeComponent<NormalComponent1>();
            queryOperator.IncludeComponent<NormalComponent2>();
            queryOperator.IncludeComponent<NormalComponent3>();
        }

        
        public delegate void LoopDelComp(ref NormalComponent0 normalComponent0, ref NormalComponent1 normalComponent1, 
            ref NormalComponent2 normalComponent2,ref NormalComponent3 normalComponent3);

        public delegate void LoopDelEntity(Entity entity, ref NormalComponent0 normalComponent,
            ref NormalComponent1 normalComponent1, ref NormalComponent2 normalComponent2, ref NormalComponent3 normalComponent3);

        public void Iterate(LoopDelEntity loopDelEntity)
        {
            List<Entity> entitiesCatched = new List<Entity>();
            foreach (var entity in world.entityData.GetEntityArray().array)
            {
                if (entity != null && queryOperator.Query(entity.componentBitMask,entity.labelBitMask))
                {
                    entitiesCatched.Add(entity);
                }
            }

            foreach (var entity in entitiesCatched)
            {
                NormalComponent0 comp0 = entity.GetComponent<NormalComponent0>();
                NormalComponent1 comp1 = entity.GetComponent<NormalComponent1>();
                NormalComponent2 comp2 = entity.GetComponent<NormalComponent2>();
                NormalComponent3 comp3 = entity.GetComponent<NormalComponent3>();
                loopDelEntity(entity,ref comp0,ref comp1,ref comp2,ref comp3);
            }
        }
        
        public void Iterate(LoopDelComp delComp)
        {
            List<Entity> entitiesCatched = new List<Entity>();
            foreach (var entity in world.entityData.GetEntityArray().array)
            {
                if (entity != null && queryOperator.Query(entity.componentBitMask,entity.labelBitMask))
                {
                    entitiesCatched.Add(entity);
                }
            }

            foreach (var entity in entitiesCatched)
            {
                NormalComponent0 comp0 = entity.GetComponent<NormalComponent0>();
                NormalComponent1 comp1 = entity.GetComponent<NormalComponent1>();
                NormalComponent2 comp2 = entity.GetComponent<NormalComponent2>();
                NormalComponent3 comp3 = entity.GetComponent<NormalComponent3>();
                delComp(ref comp0,ref comp1,ref comp2,ref comp3);
            }
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
        
        protected override List<Entity> FilterEntities()
        {
            int entityCount = 0;
            List<Entity> entitiesCatched = new List<Entity>();
            foreach (var entity in world.entityData.GetEntityArray().array)
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
        public Filter(World world,QueryOperator queryOperator) : base(world,queryOperator)
        {
            
        }
        
        public Filter()
        {
            queryOperator.IncludeComponent<NormalComponent0>();
            queryOperator.IncludeComponent<NormalComponent1>();
            queryOperator.IncludeComponent<NormalComponent2>();
            queryOperator.IncludeComponent<NormalComponent3>();
            queryOperator.IncludeComponent<NormalComponent4>();
        }

        public delegate void LoopDelComp(ref NormalComponent0 normalComponent0, ref NormalComponent1 normalComponent1, 
            ref NormalComponent2 normalComponent2,ref NormalComponent3 normalComponent3, ref NormalComponent4 normalComponent4);

        public delegate void LoopDelEntity(Entity entity, ref NormalComponent0 normalComponent,
            ref NormalComponent1 normalComponent1, ref NormalComponent2 normalComponent2, ref NormalComponent3 normalComponent3,
            ref NormalComponent4 normalComponent4);

        public void Iterate(LoopDelEntity loopDelEntity)
        {
            List<Entity> entitiesCatched = new List<Entity>();
            foreach (var entity in world.entityData.GetEntityArray().array)
            {
                if (entity != null && queryOperator.Query(entity.componentBitMask,entity.labelBitMask))
                {
                    entitiesCatched.Add(entity);
                }
            }

            foreach (var entity in entitiesCatched)
            {
                NormalComponent0 comp0 = entity.GetComponent<NormalComponent0>();
                NormalComponent1 comp1 = entity.GetComponent<NormalComponent1>();
                NormalComponent2 comp2 = entity.GetComponent<NormalComponent2>();
                NormalComponent3 comp3 = entity.GetComponent<NormalComponent3>();
                NormalComponent4 comp4 = entity.GetComponent<NormalComponent4>();
                loopDelEntity(entity,ref comp0,ref comp1,ref comp2,ref comp3, ref comp4);
            }
        }
        
        public void Iterate(LoopDelComp delComp)
        {
            List<Entity> entitiesCatched = new List<Entity>();
            foreach (var entity in world.entityData.GetEntityArray().array)
            {
                if (entity != null && queryOperator.Query(entity.componentBitMask,entity.labelBitMask))
                {
                    entitiesCatched.Add(entity);
                }
            }

            foreach (var entity in entitiesCatched)
            {
                NormalComponent0 comp0 = entity.GetComponent<NormalComponent0>();
                NormalComponent1 comp1 = entity.GetComponent<NormalComponent1>();
                NormalComponent2 comp2 = entity.GetComponent<NormalComponent2>();
                NormalComponent3 comp3 = entity.GetComponent<NormalComponent3>();
                NormalComponent4 comp4 = entity.GetComponent<NormalComponent4>();
                delComp(ref comp0,ref comp1,ref comp2,ref comp3,ref comp4);
            }
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
        
        protected override List<Entity> FilterEntities()
        {
            int entityCount = 0;
            List<Entity> entitiesCatched = new List<Entity>();
            foreach (var entity in world.entityData.GetEntityArray().array)
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