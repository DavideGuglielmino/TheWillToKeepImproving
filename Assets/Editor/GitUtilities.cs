using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;

[InitializeOnLoad]
public static class GitUtilities
{
    static GitUtilities()
    {
        if (string.IsNullOrEmpty(EditorSceneManager.GetActiveScene().name))
        {
            System.Environment.SetEnvironmentVariable(
                "UNITYYAMLMERGE",
                EditorApplication.applicationPath.Replace("Unity.exe", "Data/Tools/UnityYAMLMerge.exe"),
                System.EnvironmentVariableTarget.User);

            Prune();
            EditorApplication.quitting += Prune;
        }
    }

    static bool PruneStep(string path)
    {
        bool pruned = false;
        foreach (string subFolder in Directory.EnumerateDirectories(path))
        {
            pruned |= PruneStep(subFolder);
        }

        if (Directory.GetFiles(path).Length == 0)
        {
            Debug.Log("Pruning empty folder " + path);
            Directory.Delete(path);
            File.Delete(path + ".meta");
            return true;
        }
        else
        {
            return pruned;
        }
    }

    [MenuItem("Utilities/Prune Empty Folders")]
    static void Prune()
    {
        if (PruneStep(Application.dataPath))
        {
            AssetDatabase.Refresh();
        }
        else
        {
            Debug.Log("No empty folders to prune.");
        }
    }
}