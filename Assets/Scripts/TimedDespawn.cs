using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDespawn : MonoBehaviour
{
    private float born;

    public float lifetime = 20;
    public float warningFrac = 0.85f;

    // Start is called before the first frame update
    void Start()
    {
        born = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        float age = (Time.timeSinceLevelLoad - born) / lifetime;

        if (GetComponent<limb>().IsPickedUp)
        {
            born = Time.timeSinceLevelLoad;
        }

        if (age >= 1f)
        {
            Destroy(gameObject);
        }
        else if (age >= warningFrac)
        {
            float freq = 1 + (1 - age) / (1 - warningFrac);
            gameObject.GetComponent<Renderer>().enabled = Mathf.Repeat(Time.time, freq) >= (freq / 2f);
        }
    }
}
