using System;
using UnityEngine;


[Serializable]
public class BoneChain
{
    [SerializeField] private Transform[] bonesInOrder;
    [SerializeField] private Transform endEffectorTarget;
    [SerializeField] private Vector3 pivotOffset;

    private float[] lengths;
    private float totalLength;
    public void InitBoneChain()
    {
        lengths = new float[bonesInOrder.Length - 1];
        totalLength = 0f;
        for (int i = 0; i < bonesInOrder.Length - 1; i++)
        {
            var length = Vector3.Distance(bonesInOrder[i+1].position,bonesInOrder[i].position);
            lengths[i] = length;
            totalLength += length;
        }
    }

    public int BoneCount()
    {
        return bonesInOrder.Length;
    }
    public Transform GetBone(int index)
    {
        return bonesInOrder[index];
    }
    public Vector3 GetTargetPos()
    {
        return endEffectorTarget.position;
    }
    public Vector3 GetPivotPos()
    {
        return pivotOffset;
    }
    public float GetBoneIntervalLength(int index)
    {
        return lengths[index];
    }
    public bool IsTargetCloseToChain()
    {
        return ((endEffectorTarget.position - bonesInOrder[0].position).sqrMagnitude <= totalLength * totalLength);
    }
}

public static class IKUtility
{
    public static void Fabrik(ref BoneChain boneChain, float tolerance = 0.001f,int iterations = 20)
    {
        var rootToTarget = boneChain.GetTargetPos() - boneChain.GetBone(0).position;
        var distanceSqrTarget = rootToTarget.sqrMagnitude;

        if (!boneChain.IsTargetCloseToChain())
        {
            rootToTarget.Normalize();
            for (int i = 1; i < boneChain.BoneCount(); i++)
            {
                boneChain.GetBone(i).position = boneChain.GetBone(i-1).position + 
                                            rootToTarget * boneChain.GetBoneIntervalLength(i-1);
            }
        }
        else
        {
            for (int i = 1; i < boneChain.BoneCount(); i++)
            {
                boneChain.GetBone(i).position += boneChain.GetPivotPos() * i;
            }
            
            for (int i = 0; i < iterations; i++)
            {
                for (int f = boneChain.BoneCount() - 1; f > 0; f--)
                {
                    if (f == boneChain.BoneCount() - 1)
                    {
                        boneChain.GetBone(f).position = boneChain.GetTargetPos();
                        continue;
                    }

                    boneChain.GetBone(f).position = boneChain.GetBone(f+1).position +
                                                    ( boneChain.GetBone(f).position -  boneChain.GetBone(f+1).position).normalized *
                                                    boneChain.GetBoneIntervalLength(f);
                }

                for (int b = 1; b < boneChain.BoneCount(); b++)
                {
                    boneChain.GetBone(b).position = boneChain.GetBone(b-1).position +
                                                ( boneChain.GetBone(b).position - boneChain.GetBone(b-1).position).normalized
                                                * boneChain.GetBoneIntervalLength(b - 1);
                }
            }
        }
        
        for (int i = 0; i < boneChain.BoneCount() - 1; i++)
        {
            var dir = (boneChain.GetBone(i+1).position - boneChain.GetBone(i).position).normalized;
            boneChain.GetBone(i).rotation = Quaternion.LookRotation(dir);
        }
        var dirLast = (boneChain.GetBone(boneChain.BoneCount() - 2).position - boneChain.GetBone(boneChain.BoneCount() - 1).position)
            .normalized;
        boneChain.GetBone(boneChain.BoneCount() - 1).rotation = Quaternion.LookRotation(dirLast);
    }
}
