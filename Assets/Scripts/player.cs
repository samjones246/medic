using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    float mult = 0.25f;
    float h = 0;
    float v = 0;
    void Awake () {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 45;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        Vector3 pos = this.transform.position;
        float moveX = h * mult;
        float moveZ = v * mult;
        this.transform.position = new Vector3(pos.x+moveX, pos.y, pos.z+moveZ);
    }
}
