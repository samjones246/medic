using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoKillParticle : MonoBehaviour
{
    private ParticleSystem system;

    // Start is called before the first frame update
    void Start()
    {
        system = gameObject.GetComponent<ParticleSystem>();
        if (system == null)
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!system.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
