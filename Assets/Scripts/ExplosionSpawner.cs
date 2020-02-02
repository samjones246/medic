using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawner : TimedSpawner
{
    public float radius;
    public GameObject explosion;

    protected override void Spawn()
    {
        Vector3 position = gameObject.transform.position + Random.insideUnitSphere * radius;
        Instantiate(explosion, position, Quaternion.identity);
    }
}
