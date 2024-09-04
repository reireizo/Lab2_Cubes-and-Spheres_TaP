using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(CubeBehavior))]
public class CubeBehaviorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Select All Cubes"))
        {
            var allCubeBehavior = GameObject.FindObjectsOfType<CubeBehavior>();
            var allCubeGameObjects = allCubeBehavior.Select(cube => cube.gameObject).ToArray();
            Selection.objects = allCubeGameObjects;
        }

    }
}
