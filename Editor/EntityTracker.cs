using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NormalEcs;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

[CustomEditor(typeof(UnityEntity))]
public class EntityTracker : Editor
{

    public override void OnInspectorGUI()
    {
        #if UNITY_EDITOR
        UnityEntity unityEntity = (UnityEntity) target;
        if (Application.isPlaying)
        {
            GUILayout.Label("Entity ID: " + unityEntity.entity.entityId);
            GUILayout.Label("Entity Creation ID: " + unityEntity.entity.creationId);
            EditorGUILayout.LabelField("********************************************");
                                        
            EditorGUILayout.LabelField("LABELS");
            bool hasTrigger = false;
            foreach (var labelType in unityEntity.entity.GetAllLabel())
            {
                hasTrigger = true;
                EditorGUILayout.LabelField("* " + labelType.Name);
            }

            if (!hasTrigger)
            {
                EditorGUILayout.LabelField("HAS NO LABELS",new GUIStyle()
                {
                    normal = new GUIStyleState()
                    {
                        textColor = Color.red
                    }
                });
            }
            EditorGUILayout.LabelField("********************************************");
            EditorGUILayout.LabelField("COMPONENTS");
            for (int i = 0; i < unityEntity.entity.componentBitMask.Length; i++)
            {
                if (unityEntity.entity.componentBitMask[i])
                {
                    var compType = ComponentManager.GetComponentType(i);
                    var comp = Convert.ChangeType(ComponentManager.componentPools[i].componentPool
                        .array[unityEntity.entity.entityId],compType);
                    FieldInfo[] fieldInfo = compType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    
                    EditorGUILayout.LabelField("* " + compType.Name);



                    foreach (var info in fieldInfo)
                    {
                        if (info.FieldType == typeof(int))
                        {
                            int newValue = EditorGUILayout.IntField("" + info.Name,(int)info.GetValue(comp));
                            info.SetValue(comp,newValue);
                        }
                        else if (info.FieldType == typeof(float))
                        {
                            float newValue = EditorGUILayout.FloatField("" + info.Name,(float)info.GetValue(comp));
                            info.SetValue(comp,newValue);
                        }
                        else if(info.FieldType == typeof(Vector2))
                        {
                            Vector2 newValue =
                                EditorGUILayout.Vector2Field("" + info.Name, (Vector2) info.GetValue(comp));
                            info.SetValue(comp,newValue);
                        }
                        else if (info.FieldType == typeof(Vector3))
                        {
                            Vector3 newValue = EditorGUILayout.Vector3Field("" + info.Name, (Vector3) info.GetValue(comp));
                            info.SetValue(comp,newValue);
                        }
                        else if (info.FieldType == typeof(Transform))
                        {
                            Transform newValue =
                                (Transform) EditorGUILayout.ObjectField("" + info.Name,(Transform)info.GetValue(comp),typeof(Transform));
                            info.SetValue(comp,newValue);
                        }
                        else
                        {
                            Type typeOfVar = info.GetValue(comp).GetType();
                            EditorGUILayout.LabelField("" + info.Name + ":\t" + typeOfVar.Name);
                        }
                        
                    }
                    EditorGUILayout.LabelField("--------------------------------------------");
                }
            }
        }
        #endif
    }
}
