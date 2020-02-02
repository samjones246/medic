using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public int sceneBuildIndex;

    public void StartGameF()
    {
        SceneManager.LoadSceneAsync(sceneBuildIndex, LoadSceneMode.Single);
    }
}
