using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class GalleryItem : MonoBehaviour, IPokemonLoadable
{
    private Pokemon pokemon;

    public LocalizeStringEvent pokemonName;
    public Image pokemonImage;
    public Button pokemonButton;

    public bool isVisible = true;
    
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
            pokemonImage.sprite = isVisible ? pokemon.image : pokemon.hiddenImage;
        }

        if (pokemonButton != null)
        {
            if (isVisible) pokemonButton.onClick.AddListener(UpdateAndSwithToDetails);
        }
    }

    private void UpdateAndSwithToDetails()
    {
        PokemonManager.Instance.UpdatePokemonForDetails(pokemon);
        UIManager.Instance.SwitchToDetails();
    }
}
