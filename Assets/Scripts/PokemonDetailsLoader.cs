using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class PokemonDetailsLoader : MonoBehaviour
{
    public LocalizeStringEvent pokemonName;
    public Image pokemonImage;
    public LocalizeStringEvent pokemonDescription;

    public void UpdatePokemonDetails(Pokemon pokemon)
    {
        pokemonName.StringReference.SetReference(Pokemon.localizationTableName, pokemon.nameKey);
        pokemonImage.sprite = pokemon.image;
        pokemonDescription.StringReference.SetReference(Pokemon.localizationTableName, pokemon.descriptionKey);
    }
}
