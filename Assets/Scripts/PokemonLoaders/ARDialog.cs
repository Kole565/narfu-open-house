using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class ARDialog : MonoBehaviour, IPokemonLoadable
{
    public MultipleImagesTrackingManager imageManager;

    public Pokemon pokemon;

    public TMP_Text dialogueText;
    public Button nextMessageButton;

    public LocalizeStringEvent pokemonName;
    public Image pokemonImage;

    private string[] monologueSegments;
    private int currentSegmentIndex = 0;

    public void Load(Pokemon pokemonData)
    {
        if (pokemonData != null)
        {
            pokemon = pokemonData;
        }
        else
        {
            Debug.LogError("No pokemon object provided");
            return;
        }

        if (pokemonName != null)
        {
            pokemonName.StringReference.SetReference(Pokemon.localizationTableName, pokemon.nameKey);
        }
        if (pokemonImage != null)
        {
            pokemonImage.sprite = pokemon.image;
        }

        var loc = LocalizationSettings.StringDatabase.GetLocalizedStringAsync(Pokemon.localizationTableName, pokemon.descriptionKey);
        loc.Completed += LocalizedString_Completed;

        nextMessageButton.onClick.AddListener(OnPanelClicked);
    }

    private void LocalizedString_Completed(AsyncOperationHandle<string> obj)
    {
        monologueSegments = obj.Result.Split(new string[] { "\n" }, System.StringSplitOptions.None);
        UpdateText();
    }
    void UpdateText()
    {
        if (dialogueText != null && monologueSegments != null && monologueSegments.Length > 0)
        {
            dialogueText.text = monologueSegments[currentSegmentIndex];
        }
    }

    void OnPanelClicked()
    {
        currentSegmentIndex++;

        if (currentSegmentIndex >= monologueSegments.Length)
        {
            currentSegmentIndex = monologueSegments.Length - 1;
            OnDialogueEnd();
        }

        UpdateText();
    }

    private void OnDialogueEnd()
    {
        PokemonManager.Instance.SetCatched(pokemon);
        imageManager.RemoveARObject(gameObject);
    }
}
