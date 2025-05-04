using System.Collections.Generic;
using UnityEngine;

public class PokemonManager : MonoBehaviour
{
    private static PokemonManager _instance;
    public static PokemonManager Instance { get { return _instance; } }

    public List<Pokemon> allPokemons;
    public List<Pokemon> catchedPokemons = new List<Pokemon>();

    public bool showAllPokemons = false;
    public PokemonDetailsLoader pokemonDetailsLoader;

    private void Start()
    {
        catchedPokemons.Add(allPokemons[0]); // TODO: Remove this, it's for testing only.
    }

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

    public void ResetPokemonsState()
    {
        catchedPokemons.Clear();
    }

    public void UpdatePokemonForDetails(Pokemon pokemon)
    {
        pokemonDetailsLoader.UpdatePokemonDetails(pokemon);
    }

}
