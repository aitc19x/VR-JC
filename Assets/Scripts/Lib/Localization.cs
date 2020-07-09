using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Localization : MonoBehaviour
{
    public static string get() {
        string locale;
        AppSettings.init();
        if (AppSettings.get("locale") != null) {
            locale = AppSettings.get("locale");
        } else {
            switch (Application.systemLanguage) {
                case SystemLanguage.Japanese:
                    locale = "ja";
                    break;
                case SystemLanguage.Chinese:
                    locale = "zh";
                    break;
                default:
                    locale = "en";
                    break;
            }
            AppSettings.set("locale", locale);
        }
        return locale;
    }

    public static void init() {
        string sceneName = SceneManager.GetActiveScene().name;
        string locale = get();
        var json = JsonConvert.DeserializeObject<Dictionary<string, string>>(Utility.ReadAllText(Application.streamingAssetsPath + "/Locales/" + sceneName + "-" + locale + ".json"));
        Text[] labels = Utility.FindObjectsOfTypeAll<Text>();
        foreach (Text label in labels) {
            if (json.ContainsKey(label.name))
                label.text = json[label.name];
        }
    }

    public void Start()
    {
        init();
    }
}
