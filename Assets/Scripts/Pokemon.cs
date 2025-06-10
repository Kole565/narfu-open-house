using UnityEngine;

[CreateAssetMenu(fileName = "PokemonData", menuName = "AR App/Pokemon Data")]
public class Pokemon : ScriptableObject
{
    public static string localizationTableName = "PokemonsLocalization";

    public string nameKey;
    public string shortDescriptionKey;
    public string detailedDescriptionKey;

    public Sprite image;
    public Sprite hiddenImage;
    public Sprite conturedImage;
}
