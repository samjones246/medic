using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public int sceneBuildIndex;

    public void StartGameF()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(sceneBuildIndex, LoadSceneMode.Single);
        
    }
    public void QuitGameF()
    {
        Application.Quit();
    }
}
