using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestEditorExpansion : EditorWindow
{
    [MenuItem("Editor/Test/TestEditorWindow")]
    static public void CreateWindow()
    { 
        EditorWindow.GetWindow<TestEditorExpansion>();
    }

    private void OnGUI()
    {
        GUILayout.Label("ƒeƒXƒg");
    }
}
