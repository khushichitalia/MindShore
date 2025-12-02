using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
/// When the scene is played, run some specific functionality
/// </summary>
public class OnSceneLoad : MonoBehaviour
{
    // When scene is loaded and play begins
    public UnityEvent OnLoad = new UnityEvent();

    private void Awake()
    {
        SceneManager.sceneLoaded += PlayEvent;
        Debug.Log("OnSceneLoad subscribed to sceneLoaded event.");
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= PlayEvent;
    }

    private void PlayEvent(Scene scene, LoadSceneMode mode)
    {
        OnLoad.Invoke();
        Debug.Log("SCENE LOADED EVENT FIRED: " + scene.name);
    }
}
