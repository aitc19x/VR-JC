using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Canvas MainCanvas, OptionsCanvas;
    public Dropdown dropdown;
    public bool generateMenu = false;

    IEnumerator Start()
    {
        yield return LocalizationSettings.InitializationOperation;

        int selected = 0;

        if (generateMenu) {
            var options = new List<Dropdown.OptionData>();
            for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; ++i)
            {
                var locale = LocalizationSettings.AvailableLocales.Locales[i];
                if (LocalizationSettings.SelectedLocale == locale)
                    selected = i;
                options.Add(new Dropdown.OptionData(locale.name));
            }
            dropdown.options = options;
        } else {
            
            for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; ++i)
            {
                var locale = LocalizationSettings.AvailableLocales.Locales[i];
                if (LocalizationSettings.SelectedLocale == locale)
                    selected = i;
            }
        }

        dropdown.value = selected;
        dropdown.onValueChanged.AddListener(LocaleSelected);
    }

    private static void LocaleSelected(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
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
