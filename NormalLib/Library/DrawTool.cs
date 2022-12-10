using System.Collections.Generic;
using UnityEngine;

namespace NormalLib.Library
{
    public static class DrawTool
    {
        public static void DrawPath(List<Vector3> points, Color pathColor)
        {
            if (points.Count <= 1)
            {
                return;
            }
            for (int i = 0; i < points.Count - 1; i++)
            {
                Debug.DrawLine(points[i],points[i+1],pathColor);
            }
        }
        
        public static void DrawPath(Vector3[] points, Color pathColor)
        {
            if (points.Length <= 1)
            {
                return;
            }
            for (int i = 0; i < points.Length - 1; i++)
            {
                Debug.DrawLine(points[i],points[i+1],pathColor);
            }
        }

        public static void DrawCircle(List<Vector3> points, Color pathColor)
        {
            DrawPath(points,pathColor);
            Debug.DrawLine(points[0],points[^1],pathColor);
        }
        
        
        public static void DrawSquareOnXZGizmos(Vector3 center, Vector2 size)
        {
            var p1 = center - (Vector3.right * size.x / 2f) + (Vector3.forward * size.y / 2f);
            var p2 = center + (Vector3.right * size.x / 2f) + (Vector3.forward * size.y / 2f);
            var p3 = center - (Vector3.right * size.x / 2f) - (Vector3.forward * size.y / 2f);
            var p4 = center + (Vector3.right * size.x / 2f) - (Vector3.forward * size.y / 2f);
            
            Gizmos.DrawLine(p1,p2);
            Gizmos.DrawLine(p2,p4);
            Gizmos.DrawLine(p4,p3);
            Gizmos.DrawLine(p3,p1);
        }
    }
}