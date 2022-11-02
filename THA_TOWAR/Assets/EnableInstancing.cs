using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnableInstancing : MonoBehaviour
{
    static void EnableGpuInstancing()
    {
        SetGpuInstancing(true);
    }

    [MenuItem("Example/Disable GPU Instancing")]
    static void DisableGpuInstancing()
    {
        SetGpuInstancing(false);
    }
    static void SetGpuInstancing(bool value)
    {
        foreach (var guid in AssetDatabase.FindAssets("t:Material", new[] { "Assets/MyMaterials" }))
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var material = AssetDatabase.LoadAssetAtPath<Material>(path);
            if (material != null)
            {
                material.enableInstancing = value;
                EditorUtility.SetDirty(material);
            }
        }
    }
}
