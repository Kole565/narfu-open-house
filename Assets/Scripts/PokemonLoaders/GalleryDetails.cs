using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class GalleryDetails : MonoBehaviour, IPokemonLoadable
{
    public Pokemon pokemon;

    public LocalizeStringEvent pokemonName;
    public Image pokemonImage;
    public LocalizeStringEvent pokemonDescription;

    public void OnEnable()
    {
        Load(PokemonManager.Instance.currentPokemonForGalleryDetails);
    }

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
        if (pokemonDescription != null)
        {
            pokemonDescription.StringReference.SetReference(Pokemon.localizationTableName, pokemon.detailedDescriptionKey);
        }
    }
}
