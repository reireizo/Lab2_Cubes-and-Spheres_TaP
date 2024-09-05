using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(CubeBehavior)), CanEditMultipleObjects]
public class CubeBehaviorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        var size = serializedObject.FindProperty("size");

        EditorGUILayout.PropertyField(size);

        serializedObject.ApplyModifiedProperties();

        if (size.floatValue != 1)
        {
            EditorGUILayout.HelpBox("The size has been changed!",MessageType.Warning);
        }
        
        EditorGUILayout.BeginHorizontal();
        

        if (GUILayout.Button("Select All Cubes"))
        {
            var allCubeBehavior = GameObject.FindObjectsOfType<CubeBehavior>();
            var allCubeGameObjects = allCubeBehavior.Select(cube => cube.gameObject).ToArray();
            Selection.objects = allCubeGameObjects;
        }
        if (GUILayout.Button("ClearSelection"))
        {
            Selection.objects = new Object[] { (target as CubeBehavior).gameObject };
        }

        EditorGUILayout.EndHorizontal();

    }
}
