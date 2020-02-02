using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimedSpawner : MonoBehaviour
{
    private float deltaTime;
    private float nextDelay;

    public float delayMin;
    public float delayMax;

    // Start is called before the first frame update
    void Start()
    {
        nextDelay = Random.Range(delayMin, delayMax);
        deltaTime = 0;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;

        if (deltaTime >= nextDelay)
        {
            Spawn();

            deltaTime -= nextDelay;
            nextDelay = Random.Range(delayMin, delayMax);
        }
    }

    protected abstract void Spawn();
}
