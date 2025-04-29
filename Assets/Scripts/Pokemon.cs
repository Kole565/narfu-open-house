using UnityEngine;

[System.Serializable]
public class Pokemon
{
    public static string localizationTableName = "PokemonsLocalization";

    public string nameKey;
    public string descriptionKey;
    public Sprite image;
    public Sprite hiddenImage;
}
