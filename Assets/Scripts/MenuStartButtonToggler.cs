using UnityEngine;
using UnityEngine.Localization.Components;

public class MenuStartButtonToggler : MonoBehaviour
{
    [SerializeField] private string tableName;
    [SerializeField] private string defaultKey;
    [SerializeField] private string atleastOneCatchedKey;

    [SerializeField] private LocalizeStringEvent textField;

    private void OnEnable()
    {
        if (PokemonManager.Instance != null && PokemonManager.Instance.atleastOneCatched)
        {
            textField.StringReference.SetReference(tableName, atleastOneCatchedKey);
        }
        else
        {
            textField.StringReference.SetReference(tableName, defaultKey);
        }
    }
}
