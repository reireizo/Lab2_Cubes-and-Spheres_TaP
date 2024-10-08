using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using Unity.VisualScripting;

[CustomEditor(typeof(CubeBehavior)), CanEditMultipleObjects]
public class CubeBehaviorEditor : Editor
{
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
        

        if (GUILayout.Button("Select All Cubes"))
        {
            var allCubeBehavior = GameObject.FindObjectsOfType<CubeBehavior>();
            var allCubeGameObjects = allCubeBehavior.Select(cube => cube.gameObject).ToArray();
            Selection.objects = allCubeGameObjects;
        }
        if (GUILayout.Button("Clear Selection"))
        {
            Selection.objects = new Object[] { (target as CubeBehavior).gameObject };
        }

        if ((target as CubeBehavior).gameObject.activeSelf == false)
        {
            GUI.backgroundColor = originalColor;
        }
        else
        {
            GUI.backgroundColor = Color.green;
        }

        if (GUILayout.Button("Disable/Enable All Cubes", GUILayout.Height(20)))
        {
            foreach (var cube in GameObject.FindObjectsOfType<CubeBehavior>(true))
            {
                cube.gameObject.SetActive(!cube.gameObject.activeSelf);
            }

        }

        EditorGUILayout.EndHorizontal();

    }
}
