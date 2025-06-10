using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleDropdown : MonoBehaviour
{
    private TMP_Dropdown dropdown;

    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        int currentLocaleIndex = LocalizationSettings.AvailableLocales.Locales.IndexOf(LocalizationSettings.SelectedLocale);
        dropdown.value = currentLocaleIndex;
    }

    public void SetNewLocale()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[dropdown.value];
    }
}
