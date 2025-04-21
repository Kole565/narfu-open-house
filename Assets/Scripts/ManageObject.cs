using UnityEngine;

public class ManageObject : MonoBehaviour
{
    [SerializeField]
    private GameObject @object;

    public void Toggle()
    {
        @object.SetActive(!@object.activeSelf);
    }
}
