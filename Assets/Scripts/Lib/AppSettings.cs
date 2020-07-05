using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class AppSettings : MonoBehaviour
{
    public static Dictionary<string, string> json;

    public static void init() {
        if (!File.Exists(Application.persistentDataPath + "/vrjc-settings.json")) {
            File.Create(Application.persistentDataPath + "/vrjc-settings.json").Dispose();
            File.WriteAllText(Application.persistentDataPath + "/vrjc-settings.json", "{}");
        }
        string jsonString = File.ReadAllText(Application.persistentDataPath + "/vrjc-settings.json");
        json = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
    }

    public void Start()
    {
        init();
    }

    public static string get(string key) {
        return json.ContainsKey(key) ? json[key] : null;
    }

    public static void set(string key, string value) {
        if (json.ContainsKey(key))
            json[key] = value;
        else
            json.Add(key, value);
        File.WriteAllText(Application.persistentDataPath + "/vrjc-settings.json", JsonConvert.SerializeObject(json, Formatting.Indented));
    }

    public static void remove(string key) {
        json.Remove(key);
    }
}
