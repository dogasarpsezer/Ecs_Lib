using UnityEngine;
using UnityEngine.PlayerLoop;

namespace NormalEcs
{
    public class System
    {
        public World world;
        public virtual void Awake(){}
        public virtual void Start(){}
        public virtual void Update(){}
        public virtual void FixedUpdate() {}
        public virtual void LateUpdate() {}
    }
}