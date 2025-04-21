using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SceneController")]
public class SceneController : ScriptableObject
{
    private Stack<int> loadedLevels;

    [System.NonSerialized]
    private bool initialized;

    private void Init()
    {
        loadedLevels = new Stack<int>();
        initialized = true;
    }
    
    public void LoadScene(int buildIndex)
    {
        if (!initialized) Init();

        loadedLevels.Push(SceneManager.GetActiveScene().buildIndex);

        SceneManager.LoadScene(buildIndex);
    }

    public void LoadScene(string sceneName)
    {
        if (!initialized) Init();

        loadedLevels.Push(SceneManager.GetActiveScene().buildIndex);

        SceneManager.LoadScene(sceneName);
    }

    public void LoadPreviousScene()
    {
        if (!initialized)
        {
            Debug.LogError( "You haven't used the LoadScene functions of the scriptable object. Use them instead of the LoadScene functions of Unity's SceneManager." );
        }
        if (loadedLevels.Count > 0)
        {
            SceneManager.LoadScene(loadedLevels.Pop());
        }
        else
        {
            Debug.LogError("No previous scene loaded");
        }
    }
}
