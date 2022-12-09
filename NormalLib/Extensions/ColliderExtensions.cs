using NormalEcs;
using UnityEngine;

namespace Ecs_Lib.Extensions
{
    public static class ColliderExtensions
    {
        public static Entity GetColliderEntity(this Collider collider)
        {
            if (collider.TryGetComponent(out UnityEntity unityEntity))
            {
                return unityEntity.entity;
            }

            return collider.GetComponentsInParent<UnityEntity>()[0].entity;
        }
    }
}