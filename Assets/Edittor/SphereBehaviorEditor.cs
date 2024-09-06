using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(SphereBehavior)), CanEditMultipleObjects]
public class SphereBehaviorEditor : Editor
{
    public bool disabled = false;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        var size = serializedObject.FindProperty("size");

        var originalColor = GUI.backgroundColor;

        EditorGUILayout.PropertyField(size);

        serializedObject.ApplyModifiedProperties();

        if (size.floatValue != 1)
        {
            EditorGUILayout.HelpBox("The size has been changed!",MessageType.Warning);
        }

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

        if (disabled == true)
        {
            GUI.backgroundColor = originalColor;
        }
        else
        {
            GUI.backgroundColor = Color.green;
        }

        if (GUILayout.Button("Disable/Enable All Spheres", GUILayout.Height(20)))
        {
            foreach (var sphere in GameObject.FindObjectsOfType<SphereBehavior>(true))
            {
                sphere.gameObject.SetActive(!sphere.gameObject.activeSelf);
            }

            if (disabled == false)
            {
                disabled = true;
            }
            else
            {
                disabled = false;
            }
        }

        EditorGUILayout.EndHorizontal();
    }
}
