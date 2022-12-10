using System.Collections.Generic;
using UnityEngine;

namespace NormalLib.Library
{
    public static class Extensions
    {
        public static void DrawGizmos(this List<Vector3> path,Color color)
        {
            if (path.Count == 0)
            {
                return;
            }
            Gizmos.color = color;

            for (int i = 0; i < path.Count - 1; i++)
            {
                Gizmos.DrawLine(path[i],path[i+1]);
            }
        }

    }
}