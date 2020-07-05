using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Canvas MainCanvas, OptionsCanvas;
    public Dropdown dropdown;
    public bool generateMenu = false;

    public void Start()
    {
        int selected = 2;

        var options = new List<Dropdown.OptionData>();

        options.Add(new Dropdown.OptionData("日本語"));
        options.Add(new Dropdown.OptionData("中文"));
        options.Add(new Dropdown.OptionData("English"));

        dropdown.options = options;

        switch (Localization.get()) {
            case "ja":
                selected = 0;
                break;
            case "zh":
                selected = 1;
                break;
            case "en":
                selected = 2;
                break;
        }

        dropdown.value = selected;
        dropdown.onValueChanged.AddListener(LocaleSelected);
    }

    private static void LocaleSelected(int index)
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
