using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Components;

public class PokemonCard : MonoBehaviour
{
    public GameObject detailsWindow;

    public Image pokemonImage;
    public LocalizeStringEvent pokemonName;
    public Button pokemonButton;

    private Pokemon pokemon;

    public void SetPokemon(Pokemon pokemon)
    {
        this.pokemon = pokemon;
        if (pokemonImage != null)
        {
            pokemonImage.sprite = pokemon.image;
        }
        if (pokemonName != null)
        {
            pokemonName.StringReference.SetReference(Pokemon.localizationTableName, pokemon.nameKey);
        }
    }

    public void UpdateAndSwithToPokemonDetails()
    {
        PokemonManager.Instance.UpdatePokemonForDetails(pokemon);
        UIManager.Instance.SwitchUIWindow(detailsWindow);
    }
}
