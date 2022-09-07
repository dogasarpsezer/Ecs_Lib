using UnityEngine.PlayerLoop;

namespace NormalEcs
{
    public abstract class System
    {
        private World world;
        
        public void SetWorld(ref World world)
        {
            this.world = world;
        }

        public World GetWorld()
        {
            return world;
        }
        
        public virtual void Awake(){}
        public virtual void Start(){}
        public virtual void Update(){}
        public virtual void FixedUpdate() {}
        public virtual void LateUpdate() {}
    }
}