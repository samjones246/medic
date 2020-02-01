using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    float mult = 0.25f;
    float h = 0;
    float v = 0;
    float targetY = 0f;
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
        if(h > 0)
        {
            if(v > 0)
            {
                targetY = -45;
            }else if (v < 0)
            {
                targetY = 45;
            }
            else
            {
                targetY = 0;
            }
        }else if (h < 0)
        {
            if (v > 0)
            {
                targetY = -135;
            }
            else if (v < 0)
            {
                targetY = 135;
            }
            else
            {
                targetY = 180;
            }
        }
        else
        {
            if (v > 0)
            {
                targetY = -90;
            }
            else if (v < 0)
            {
                targetY = 90;
            }
        }
        Vector3 pos = this.transform.position;
        float moveX = h * mult;
        float moveZ = v * mult;
        transform.position = new Vector3(pos.x+moveX, pos.y, pos.z+moveZ);
        transform.rotation = Quaternion.Euler(0, targetY, 0);
    }
}
