using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Utility : MonoBehaviour
{
    public static T[] FindObjectsOfTypeAll<T>()
    {
        return SceneManager.GetActiveScene().GetRootGameObjects()
            .SelectMany(g => g.GetComponentsInChildren<T>(true))
            .ToArray();
    }

    public static string ReadAllText(string path) {
        if (Application.platform == RuntimePlatform.Android) {
            UnityWebRequest www = UnityWebRequest.Get(path);
            www.SendWebRequest();
            while (!www.isDone);
            return www.downloadHandler.text;
        } else {
            return File.ReadAllText(path);
        }
    }
}
