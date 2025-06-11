using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LocaleDropdown : MonoBehaviour
{
    private TMP_Dropdown dropdown;
    private List<TMP_Dropdown.OptionData> originalOptions = new List<TMP_Dropdown.OptionData>();
    private TMP_Dropdown.OptionData selectedOption;

    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        int currentLocaleIndex = LocalizationSettings.AvailableLocales.Locales.IndexOf(LocalizationSettings.SelectedLocale);
        dropdown.value = currentLocaleIndex;

        foreach (var option in dropdown.options)
        {
            originalOptions.Add(new TMP_Dropdown.OptionData(option.text, option.image, Color.white));
        }

        dropdown.onValueChanged.AddListener(delegate { OnDropdownClick(); });

        OnDropdownClick();
    }

    public void OnDropdownClick()
    {
        SortDropdown();
        UpdateLocale();
    }

    private void SortDropdown()
    {
        if (dropdown.options.Count == 0) return;

        int selectedIndex = dropdown.value;
        selectedOption = dropdown.options[selectedIndex];

        List<TMP_Dropdown.OptionData> sortedOptions = new List<TMP_Dropdown.OptionData>();

        for (int i = 0; i < originalOptions.Count; i++)
        {
            if (originalOptions[i].text != selectedOption.text) sortedOptions.Add(originalOptions[i]);

        }

        sortedOptions.Add(selectedOption);

        dropdown.options = sortedOptions;
        dropdown.value = 1;

        selectedOption = dropdown.options[1];

        dropdown.RefreshShownValue();
    }

    private void UpdateLocale()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[originalOptions.IndexOf(selectedOption)];
    }
}
