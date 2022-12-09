using NormalEcs;
using UnityEngine;

namespace Ecs_Lib.Extensions
{
    public static class Collider2DExtensions
    {
        public static Entity GetColliderEntity(this Collider2D collider)
        {
            if (collider.TryGetComponent(out UnityEntity unityEntity))
            {
                return unityEntity.entity;
            }

            return collider.GetComponentsInParent<UnityEntity>()[0].entity;
        }
    }
}