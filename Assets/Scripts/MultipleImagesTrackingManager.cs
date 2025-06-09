using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class MultipleImagesTrackingManager : MonoBehaviour
{
    private ARTrackedImageManager _trackedImageManager;

    public GameObject prefabToInstantiate;
    public List<Pokemon> pokemonDataList;

    private Dictionary<string, GameObject> _arObjects = new Dictionary<string, GameObject>();
    private Dictionary<string, Pokemon> pokemonDataDict = new Dictionary<string, Pokemon>();

    public List<GameObject> _hiddenObjects;


    void Start()
    {
        _trackedImageManager = GetComponent<ARTrackedImageManager>();
        if (_trackedImageManager == null) return;
        _trackedImageManager.trackablesChanged.AddListener(OnImageTrackedChanged);

        FillInitialPokemonData();
    }

    private void OnDestroy()
    {
        _trackedImageManager.trackablesChanged.RemoveListener(OnImageTrackedChanged);
    }

    private void FillInitialPokemonData()
    {
        foreach (var data in pokemonDataList)
        {
            pokemonDataDict[data.nameKey] = data;
        }
    }

    private void OnImageTrackedChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            HandleImageDetected(trackedImage);
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                HandleImageDetected(trackedImage);
            }
            else
            {
                HandleImageLost(trackedImage);
            }
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            HandleImageLost(trackedImage.Value);
        }
    }

    void HandleImageDetected(ARTrackedImage trackedImage)
    {
        string imageName = trackedImage.referenceImage.name;

        if (!_arObjects.ContainsKey(imageName))
        {
            GameObject newObject = Instantiate(prefabToInstantiate, trackedImage.transform);
            _arObjects[imageName] = newObject;

            LoadDataIntoPrefab(imageName, newObject);
        }

        if (!_hiddenObjects.Contains(_arObjects[imageName]))
        {
            _arObjects[imageName].SetActive(true);
            _arObjects[imageName].transform.SetParent(trackedImage.transform);
        }
    }

    void HandleImageLost(ARTrackedImage trackedImage)
    {
        string imageName = trackedImage.referenceImage.name;

        if (_arObjects.ContainsKey(imageName))
        {
            _arObjects[imageName].SetActive(false);
        }
    }

    void LoadDataIntoPrefab(string imageName, GameObject instantiatedObject)
    {
        if (pokemonDataDict.ContainsKey(imageName))
        {
            Pokemon data = pokemonDataDict[imageName];

            ARDialog pokemonDetailsLoader = instantiatedObject.GetComponent<ARDialog>();

            pokemonDetailsLoader.Load(data);

            pokemonDetailsLoader.imageManager = this;
        }
        else
        {
            Debug.LogError("No ScriptableObject found for image: " + imageName);
        }
    }

    public void RemoveARObject(GameObject toHide)
    {
        if (!_hiddenObjects.Contains(toHide)) _hiddenObjects.Add(toHide);
        toHide.SetActive(false);
    }

    public void Reset()
    {
        _hiddenObjects.Clear();
    }
}
