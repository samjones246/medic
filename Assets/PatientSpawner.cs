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
                offset = new Vector3(80, 0, 0);
                spawnRotation = Quaternion.Euler(0, -90, 0);
            }
            else
            {
                offset = new Vector3(-80, 0, 0);
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
        int numMissing = Random.Range(1, 4);
        List<string> missingLimbNames = new List<string>();
        for(int i = 0; i < numMissing; i++)
        {
            missingLimbNames.Add(limbNames[Random.Range(0, 4)]);
        }
        foreach (string limbName in missingLimbNames)
        {
            soldier.transform.Find(limbName).gameObject.SetActive(false);
            if(limbName == "LegR" || limbName == "LegL")
            {
                soldier.GetComponent<patient>().missingLegs = true;
            }
        }
    }
}
