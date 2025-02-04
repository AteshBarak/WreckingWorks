using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RenameChildObjects : EditorWindow
{
    private GameObject parentObject;
    private string baseName = "Child";
    private int startNumber = 1;

    [MenuItem("Tools/Rename Child Objects")]
    public static void ShowWindow()
    {
        GetWindow<RenameChildObjects>("Rename Child Objects");
    }

    private void OnGUI()
    {
        GUILayout.Label("Rename Child Objects", EditorStyles.boldLabel);

        parentObject = (GameObject)EditorGUILayout.ObjectField("Parent Object", parentObject, typeof(GameObject), true);
        baseName = EditorGUILayout.TextField("Base Name", baseName);
        startNumber = EditorGUILayout.IntField("Start Number", startNumber);

        if (GUILayout.Button("Rename"))
        {
            if (parentObject != null)
            {
                RenameObjects();
            }
            else
            {
                Debug.LogWarning("Please assign a parent object.");
            }
        }
    }

    private void RenameObjects()
    {
        Transform[] childObjects = parentObject.GetComponentsInChildren<Transform>(true);
        int currentNumber = startNumber;

        foreach (Transform child in childObjects)
        {
            if (child != parentObject.transform)
            {
                child.name = baseName + currentNumber.ToString();
                currentNumber++;
            }
        }

        Debug.Log("Renaming completed!");
    }
}
