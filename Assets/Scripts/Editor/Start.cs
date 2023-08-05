using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoadAttribute]
public static class Start
{
    static Start()
    {
        EditorApplication.playModeStateChanged += LoadDefaultScene;
    }

    public static void LoadDefaultScene(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        }

        if (state == PlayModeStateChange.EnteredPlayMode)
        {
            EditorSceneManager.LoadScene(0);
        }
    }
}
#endif