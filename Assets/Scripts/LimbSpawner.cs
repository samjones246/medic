using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbSpawner : TimedSpawner
{
    public List<GameObject> toSpawn;
    public GameObject effect;

    public GameObject target;

    public float range;

    public float speed;
    public float rotateSpeed;

    protected override void Spawn()
    {
        Vector2 offset = Quaternion.Euler(0, 0, Random.Range(0, 360)) * new Vector2(1, 0) * range;

        Vector3 position = target.transform.position + new Vector3(offset.x, Random.Range(0, 2), offset.y);
        Vector3 velocity = (target.transform.position - position) * speed;
        velocity += Random.insideUnitSphere * speed * 0.01f;

        Quaternion rotation = Random.rotationUniform;
        Vector3 rotationVelocity = Random.insideUnitSphere * rotateSpeed;

        GameObject toSpawnRef = toSpawn[Random.Range(0, toSpawn.Count)];
        GameObject obj = Instantiate(toSpawnRef, position, rotation);

        Rigidbody rigidBody = obj.GetComponent<Rigidbody>();
        rigidBody.angularVelocity = rotationVelocity;
        rigidBody.velocity = velocity;

        Instantiate(effect, position, Quaternion.identity);
    }
}
