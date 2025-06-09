using System.Collections.Generic;
using UnityEngine;

public class PokemonManager : MonoBehaviour
{
    private static PokemonManager _instance;
    public static PokemonManager Instance { get { return _instance; } }

    public List<Pokemon> allPokemons;
    public List<Pokemon> catchedPokemons = new List<Pokemon>();

    public Pokemon currentPokemonForGalleryDetails;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Reset()
    {
        catchedPokemons.Clear();
    }

    public void SetCatched(Pokemon pokemon)
    {
        if (!catchedPokemons.Contains(pokemon)) {
            catchedPokemons.Add(pokemon);
        }
    }

    public void UpdatePokemonForDetails(Pokemon pokemon)
    {
        currentPokemonForGalleryDetails = pokemon;
    }
}
