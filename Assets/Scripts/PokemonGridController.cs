using UnityEngine;

public class PokemonGridController : MonoBehaviour
{
    [SerializeField] private GameObject pokemonCardPrefab;
    [SerializeField] private Transform gridLayoutGroupTransform;

    public void OnEnable()
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
            GameObject galleryItemGO = Instantiate(pokemonCardPrefab, gridLayoutGroupTransform);
            GalleryItem galleryItem = galleryItemGO.GetComponent<GalleryItem>();

            if (galleryItem != null)
            {
                galleryItem.isVisible = PokemonManager.Instance.catchedPokemons.Contains(pokemon);

                galleryItem.Load(pokemon);
            }
            else
            {
                Debug.LogError("PokemonCard script not found on the Pokemon card prefab!");
                Destroy(galleryItemGO);
            }
        }
    }
}
