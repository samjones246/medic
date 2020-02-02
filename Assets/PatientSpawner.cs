using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientSpawner : MonoBehaviour
{
    public GameObject soldierPrefab;
    public List<GameObject> beds;
    public float minDelay;
    public float maxDelay;
    public float limbMissingChance;
    public float score;
    public bool inverted = false;
    float lastSpawn;
    float delay;
    // Start is called before the first frame update
    void Start()
    {
        lastSpawn = Time.time;
        delay = Random.Range(minDelay, maxDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastSpawn >= delay)
        {
            GameObject targetBed = beds[Random.Range(0, beds.Count)];
            Vector3 offset;
            Quaternion spawnRotation;
            Vector3 spawnLocation;
            if (inverted)
            {
                offset = new Vector3(80, 4, 0);
                spawnRotation = Quaternion.Euler(0, -90, 0);
            }
            else
            {
                offset = new Vector3(-80, 4, 0);
                spawnRotation = Quaternion.Euler(0, 90, 0);
            }
            spawnLocation = targetBed.transform.position + offset;
            GameObject soldier = Instantiate<GameObject>(soldierPrefab, spawnLocation, spawnRotation);
            PrepareLimbs(soldier);
            lastSpawn = Time.time;
            delay = Random.Range(minDelay, maxDelay);
        }
    }

    void PrepareLimbs(GameObject soldier)
    {
        string[] limbNames = { "ArmL", "ArmR", "LegL", "LegR" };
        foreach (string limbName in limbNames)
        {
            bool missing;
            if(Random.value < limbMissingChance)
            {
                missing = true;
            }
            else
            {
                missing = false;
            }
            soldier.transform.Find(limbName).gameObject.SetActive(missing);
        }
    }
}
