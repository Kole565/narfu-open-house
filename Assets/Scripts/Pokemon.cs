using UnityEngine;

[CreateAssetMenu(fileName = "PokemonData", menuName = "AR App/Pokemon Data")]
public class Pokemon : ScriptableObject
{
    public static string localizationTableName = "PokemonsLocalization";

    public string nameKey;
    public string descriptionKey;
    public Sprite image;
    public Sprite hiddenImage;
}
