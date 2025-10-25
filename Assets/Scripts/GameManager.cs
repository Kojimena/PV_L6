using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                _instance = go.AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    public int currentLevel = 1;
    public int totalLevels = 3;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel(int levelIndex)
    {
        currentLevel = levelIndex;
        LoadSceneAsync(levelIndex + 1); 
    }

    public void LoadNextLevel()
    {
        if (currentLevel < totalLevels)
        {
            currentLevel++;
            LoadSceneAsync(currentLevel + 1);
        }
        else
        {
            LoadMainMenu();
        }
    }

    public void LoadMainMenu()
    {
        LoadSceneAsync(0);
    }
    
    public void LoadSceneByName(string sceneName)
    {
        StartCoroutine(LoadSceneByNameCoroutine(sceneName));
    }

    private IEnumerator LoadSceneByNameCoroutine(string sceneName)
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(1);
        yield return new WaitUntil(() => loadingOperation.isDone);

        AsyncOperation targetOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!targetOperation.isDone)
        {
            float progress = Mathf.Clamp01(targetOperation.progress / 0.9f);
            LoadingScreen.Instance?.UpdateProgress(progress);
            yield return null;
        }
    }

    private void LoadSceneAsync(int sceneIndex)
    {
        StartCoroutine(LoadSceneCoroutine(sceneIndex));
    }

    private IEnumerator LoadSceneCoroutine(int sceneIndex)
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(1);
        yield return new WaitUntil(() => loadingOperation.isDone);

        AsyncOperation targetOperation = SceneManager.LoadSceneAsync(sceneIndex);
        
        while (!targetOperation.isDone)
        {
            float progress = Mathf.Clamp01(targetOperation.progress / 0.9f);
            LoadingScreen.Instance?.UpdateProgress(progress);
            yield return null;
        }
    }
}