using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(SphereBehavior)), CanEditMultipleObjects]
public class SphereBehaviorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Select All Spheres"))
        {
            var allSphereBehavior = GameObject.FindObjectsOfType<SphereBehavior>();
            var allSphereObjects = allSphereBehavior.Select(sphere => sphere.gameObject).ToArray();
            Selection.objects = allSphereObjects;
        }
        if (GUILayout.Button("Clear Selection"))
        {
            Selection.objects = new Object[] { (target as SphereBehavior).gameObject };
        }

        EditorGUILayout.EndHorizontal();
    }
}
