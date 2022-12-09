using System;
using UnityEngine;

namespace NormalEcs
{
    public class NormalArray<T>
    {
        public T[] array;
        public int arrayVolume;

        public NormalArray(int size)
        {
            array = new T[size];
            arrayVolume = 0;
        }

        public void Add(T item)
        {
            if (arrayVolume >= array.Length)
            {
                Array.Resize(ref array,array.Length << 1);
            }
            array[arrayVolume] = item;
            arrayVolume++;
        }

        public void AddAtIndex(T item,int index)
        {
            if(index >= array.Length) return;
            array[index] = item;
        }
    
        public void RemoveLast()
        {
            arrayVolume--;
        }

        public void Pop(int index)
        {
            if (index >= array.Length)
            {
                #if UNITY_EDITOR
                Debug.LogError("Component Pool Index Out of Bounds");
                #endif
                
                return;
            };
            array[index] = default(T);
        }
    }

}