using UnityEngine;

public class PokemonGridController : MonoBehaviour
{
    [SerializeField] private GameObject detailsWindow;
    [SerializeField] private GameObject pokemonCardPrefab;
    [SerializeField] private Transform gridLayoutGroupTransform;

    public void Awake()
    {
        gridLayoutGroupTransform = GameObject.FindWithTag("PokemonsGrid").transform;
        DisplayPokemons();
    }

    public void DisplayPokemons()
    {
        foreach (Transform child in gridLayoutGroupTransform)
        {
            Destroy(child.gameObject);
        }

        foreach (Pokemon pokemon in PokemonManager.Instance.allPokemons)
        {
            GameObject pokemonCardGO = Instantiate(pokemonCardPrefab, gridLayoutGroupTransform);

            PokemonCard pokemonCard = pokemonCardGO.GetComponent<PokemonCard>();

            if (pokemonCard != null)
            {
                if (!PokemonManager.Instance.catchedPokemons.Contains(pokemon))
                {
                    pokemon.image = pokemon.hiddenImage;
                }

                pokemonCard.SetPokemon(pokemon);
                pokemonCard.detailsWindow = detailsWindow;
            }
            else
            {
                Debug.LogError("PokemonCard script not found on the Pokemon card prefab!");
                Destroy(pokemonCardGO);
            }
        }
    }
}
