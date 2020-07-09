using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Canvas MainCanvas, OptionsCanvas;

    public void LocaleSelected(int index)
    {
        switch (index) {
            case 0:
                AppSettings.set("locale", "ja");
                break;
            case 1:
                AppSettings.set("locale", "zh");
                break;
            case 2:
                AppSettings.set("locale", "en");
                break;
        }
        Localization.init();
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
