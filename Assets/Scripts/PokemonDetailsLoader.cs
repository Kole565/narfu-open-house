using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class PokemonDetailsLoader : MonoBehaviour
{
    [SerializeField] private LocalizeStringEvent pokemonName;
    [SerializeField] private Image pokemonImage;
    [SerializeField] private LocalizeStringEvent pokemonDescription;

    public void UpdatePokemonDetails(Pokemon pokemon)
    {
        pokemonName.StringReference.SetReference(Pokemon.localizationTableName, pokemon.nameKey);
        pokemonImage.sprite = pokemon.image;
        pokemonDescription.StringReference.SetReference(Pokemon.localizationTableName, pokemon.descriptionKey);
    }
}
