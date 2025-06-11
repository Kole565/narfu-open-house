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
    public Button nextMessage;
    public Button toDetails;

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
            pokemonImage.sprite = pokemon.conturedImage;
        }

        var loc = LocalizationSettings.StringDatabase.GetLocalizedStringAsync(Pokemon.localizationTableName, pokemon.shortDescriptionKey);
        loc.Completed += LocalizedString_Completed;

        nextMessage.onClick.AddListener(OnPanelClicked);
        toDetails.onClick.AddListener(OnDetailsClicked);

        UpdateText();

        PokemonManager.Instance.SetCatched(pokemon);

        AudioManager.Instance.PlaySFX("Scan");
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

    void OnDetailsClicked()
    {
        PokemonManager.Instance.UpdatePokemonForDetails(pokemon);
        UIManager.Instance.SwitchToDetails();
    }

    private void OnDialogueEnd()
    {
        imageManager.RemoveARObject(gameObject);
    }
}
