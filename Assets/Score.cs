using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    public int lives = 20;
    public GUIStyle style;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 150, 60), "Score: " + score, style);
        GUI.Label(new Rect(10, 75, 150, 60), "Lives:  " + lives, style);
    }
}
