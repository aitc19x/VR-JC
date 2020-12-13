using System.Collections.Generic;
using Config;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Library
{
    public class Localization : MonoBehaviour
    {
        public void Awake() {
            string sceneName = SceneManager.GetActiveScene().name;
            string locale = Get();
            var json = JsonConvert.DeserializeObject<Dictionary<string, string>>(Utility.ReadAllText(Application.streamingAssetsPath + "/Locales/" + sceneName + "-" + locale + ".json"));
            Text[] labels = Utility.FindObjectsOfTypeAll<Text>();
            foreach (Text label in labels) {
                if (json.ContainsKey(label.name))
                    label.text = json[label.name];
            }
        }
        
        private string Get() {
            string locale;
            AppSettings appSettings = gameObject.AddComponent<AppSettings>();
            if (appSettings.Get("locale") != null) {
                locale = appSettings.Get("locale");
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
                appSettings.Set("locale", locale);
            }
            return locale;
        }
    }
}
