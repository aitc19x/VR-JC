using System.IO;
using Config;
using Library;
using UnityEngine;

namespace Welcome
{
    public class Options : MonoBehaviour
    {
        public Canvas mainCanvas, optionsCanvas;

        public void LocaleSelected(int index)
        {
            AppSettings appSettings = gameObject.AddComponent<AppSettings>();
            switch (index) {
                case 0:
                    appSettings.Set("locale", "ja");
                    break;
                case 1:
                    appSettings.Set("locale", "zh");
                    break;
                case 2:
                    appSettings.Set("locale", "en");
                    break;
            }
            
            Localization localization = Utility.FindObjectsOfTypeAll<Localization>()[0];
            localization.Awake();
        }

        public void CleanData()
        {
            DirectoryInfo dataDir = new DirectoryInfo(Application.persistentDataPath);
            dataDir.Delete(true);
            ExitApp();
        }

        public void ExitApp()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
