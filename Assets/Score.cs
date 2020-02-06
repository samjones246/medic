using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    public int lives = 20;
    public GUIStyle style;
    public GameObject gameOver;
    public bool paused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
        if(Input.GetKeyDown("escape") || Input.GetKeyDown("space")){
            if(paused){
                Time.timeScale = 1;
            }else{
                Time.timeScale = 0;
            }
            paused = !paused;
            
        }
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 150, 60), "Score: " + score, style);
        GUI.Label(new Rect(10, 75, 150, 60), "Lives:  " + lives, style);
    }
}
