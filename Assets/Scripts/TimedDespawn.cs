using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDespawn : MonoBehaviour
{
    private float born;

    public float lifetime = 20;

    // Start is called before the first frame update
    void Start()
    {
        born = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad - born >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
