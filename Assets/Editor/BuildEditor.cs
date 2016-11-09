using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;

public class BuildEditor
{
    static string[] sceneNames = FindEnabledEditorScenes();
    static string buildDir = "Build";

    // Create a menu item for our function
    [MenuItem("Build/Windows(x86)")]

    static void PerformWindowsx86Build()
    {
        string targetDir = buildDir + "/Windows(x86)/" + PlayerSettings.productName + ".exe";
        // Run generic build for windows x86
        GenericBuild(targetDir, BuildTarget.StandaloneWindows,
                        BuildOptions.None);
    }

    static void GenericBuild(string targetDir, BuildTarget buildTarget,
                             BuildOptions buildOptions)
    {
        // Switch the active build target
        EditorUserBuildSettings.SwitchActiveBuildTarget(buildTarget);
        // Perform the build
        string result = BuildPipeline.BuildPlayer(sceneNames, targetDir,
                             buildTarget, buildOptions);
        // Check if there were any errors
        if (result.Length > 0)
        {
            string error = "BuildPlayer Failure: " + result;
            // Log the error in Unity
            Debug.LogError(error);
            // Log the error in the Console
            System.Console.WriteLine(error);
        }
    }

    static string[] FindEnabledEditorScenes()
    {
        List<string> editorScenes = new List<string>();
        // Loop through all editor scenes
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            // Check if the scene is enabled
            if (scene.enabled)
            {
                // Add it to the list
                editorScenes.Add(scene.path);
            }
        }

        // Return the scenes
        return editorScenes.ToArray();
    }
}
#endif
