using UnityEngine;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private GameObject confirmationDialog;

    public void ShowConfirmationDialog()
    {
        confirmationDialog.SetActive(true);
    }
    public void ResetPokemonsState()
    {
        PokemonManager.Instance.ResetPokemonsState();
    }
    public void HideConfirmationDialog()
    {
        confirmationDialog.SetActive(false);
    }
}
