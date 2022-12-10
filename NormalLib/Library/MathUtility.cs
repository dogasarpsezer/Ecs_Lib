using System.Collections.Generic;
using UnityEngine;

namespace NormalLib.Library
{
    public static class MathUtility
    {
        private static float TAU = 2 * Mathf.PI;
        
        public static float NormalizedValue01(float value, float min, float max)
        {
            return Mathf.Clamp01((value - min) / (max - min));
        }

        public static List<Vector3> GetSpherePoints3D(Vector3 center,float radius,int steps)
        {
            var positions = new List<Vector3>();
            
            for (int i = 0; i < steps; i++)
            {
                var normalizedCircum = NormalizedValue01((float) i,0,steps);
                var radian = normalizedCircum * TAU;
                positions.Add(center + new Vector3(Mathf.Cos(radian) * radius, Mathf.Sin(radian) * radius,0));
                
            }
            
            return positions;
        }

        public static Vector3 QuadraticBezierPositionAtTime(Vector3 p1, Vector3 p2, Vector3 p3, float step)
        {
            var lerpP1P2 = Vector3.Lerp(p1, p2, step);
            var lerpP2P3 = Vector3.Lerp(p2, p3, step);
            var result = Vector3.Lerp(lerpP1P2,lerpP2P3,step);

            return result;
        }

        public static List<Vector3> QuadraticBezierPositions(Vector3 p1,Vector3 p2, Vector3 p3,float step = 0.001f)
        {
            var result = new List<Vector3>();
            var currentStep = 0f;

            while (currentStep <= 1f)
            {
                result.Add(QuadraticBezierPositionAtTime(p1,p2,p3,currentStep));
                currentStep += step;
            }

            return result;
        }

        public static Vector3 CubicBezierPositionAtTime(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, float step)
        {
            var result1 = QuadraticBezierPositionAtTime(p1, p2, p3, step);
            var result2 = QuadraticBezierPositionAtTime(p2, p3, p4, step);
            var resultFinal = Vector3.Lerp(result1, result2, step);
            return resultFinal;
        }

        public static List<Vector3> CubicBezierPositions(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, float step = 0.001f)
        {
            var result = new List<Vector3>();
            var currentStep = 0f;

            while (currentStep <= 1f)
            {
                result.Add(CubicBezierPositionAtTime(p1,p2,p3,p4,currentStep));
                currentStep += step;
            }

            return result;
        }
        
    }
}