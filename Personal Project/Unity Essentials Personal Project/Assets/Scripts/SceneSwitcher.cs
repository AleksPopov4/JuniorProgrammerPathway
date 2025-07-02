using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string minigameSceneName = "MinigameScene";
    [SerializeField] private string mainMenuSceneName = "MainScene";

    public void PlayMinigame()
    {
        LoadSceneAsync(minigameSceneName);
    }

    public void ReturnToMain()
    {
        LoadSceneAsync(mainMenuSceneName);
    }

    private void LoadSceneAsync(string sceneName)
    {
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
        else
        {
            Debug.LogError($"Scene '{sceneName}' cannot be loaded. Check if the scene is added to the build settings.");
        }
    }
}
