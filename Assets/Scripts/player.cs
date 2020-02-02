using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float mult = 0.25f;
    float h = 0;
    float v = 0;
    float targetY = 0f;
    public float turnSpeed = 360f;
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
        if (!(h == 0) || !(v == 0))
        {
            targetY = Mathf.Rad2Deg * Mathf.Atan2(h, v);
        }
        Vector3 pos = this.transform.position;
        float moveX = h * mult;
        float moveZ = v * mult;
        transform.position = new Vector3(pos.x+moveX, pos.y, pos.z+moveZ);
        float step = turnSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, targetY, 0), step);
    }
}
