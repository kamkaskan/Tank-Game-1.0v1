using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSystem : MonoBehaviour
{
    public static LoadingSystem instance {get; private set;}
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        LoadScene("MainMenu");
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
}
