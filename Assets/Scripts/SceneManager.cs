using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SceneManager : MonoBehaviour {
    private int currentScene;
    public static SceneManager instance;

    private void Awake()
    {
        instance = this;
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadScene(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
    public void ReloadCurrentScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene);
    }
    public void LoadNextLevel()
    {
        int lastScene = UnityEngine.SceneManagement.SceneManager.sceneCount;
        int nextScene = currentScene + 1;
        if(nextScene > lastScene)
        {
            nextScene = 0;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
    }
}
