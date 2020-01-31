using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    float mult = 0.25f;
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
        Vector3 pos = this.transform.position;
        float moveX = Input.GetAxis("Horizontal") * mult;
        float moveZ = Input.GetAxis("Vertical") * mult;
        this.transform.position = new Vector3(pos.x+moveX, pos.y, pos.z+moveZ);
    }
}
