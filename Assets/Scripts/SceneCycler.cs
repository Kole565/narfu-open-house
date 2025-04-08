using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class SceneCycler : MonoBehaviour
{

    [RuntimeInitializeOnLoadMethod]
    static void Init()
    {
        SceneManager.sceneUnloaded += (scene) => {
            LoaderUtility.Deinitialize();
            LoaderUtility.Initialize();
        };
    }

    [SerializeField]
    private float sceneInterval = 10.0f;
    private float time = 0;

    void Update()
    {
        time += Time.deltaTime;

        if (time > sceneInterval)
        {
            time = 0f;
            int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene(nextSceneIndex);
        }

    }
}
