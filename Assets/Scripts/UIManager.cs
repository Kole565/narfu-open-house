using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    public GameObject uiRoot;
    public GameObject xrRoot;

    public GameObject[] uiWindows;

    private GameObject[] lastOpened;

    public GameObject detailsWindow;
    public GameObject menuWindow;

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

    public void ShowUI()
    {
        uiRoot.SetActive(true);
        xrRoot.SetActive(false);
    }

    public void ShowXR()
    {
        uiRoot.SetActive(false);
        xrRoot.SetActive(true);
    }

    public void SwitchUIWindow(GameObject switchTo)
    {
        if (!uiRoot.activeInHierarchy) return;

        foreach (var uiWindow in uiWindows)
        {
            uiWindow.SetActive(false);
        }
        switchTo.SetActive(true);
    }

    public void SwitchToDetails()
    {
        if (xrRoot.activeSelf)
        {
            ShowUI();
        }
        SwitchUIWindow(detailsWindow);
    }

    public void SwitchToMenu()
    {
        if (xrRoot.activeSelf)
        {
            ShowUI();
        }
        SwitchUIWindow(menuWindow);
    }

    public void ShowDialog(GameObject dialog)
    {
        dialog.SetActive(true);
    }

    public void HideDialog(GameObject dialog)
    {
        dialog.SetActive(false);
    }
}
