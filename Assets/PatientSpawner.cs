using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientSpawner : MonoBehaviour
{
    public List<GameObject> soldierPrefabs;
    public List<GameObject> leftBeds;
    public List<GameObject> rightBeds;

    public float minDelay;
    public float minMinDelay;
    public float maxDelay;
    public float minMaxDelay;
    public float delayRate = 0.01f;

    public float limbMissingChance;
    public float score;
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
            int inverted = Random.Range(0, 2);
            GameObject targetBed;
            if (inverted == 1){
                targetBed = rightBeds[Random.Range(0, rightBeds.Count)];
            }
            else
            {
                targetBed = leftBeds[Random.Range(0, leftBeds.Count)];
            }
            Vector3 offset;
            Quaternion spawnRotation;
            Vector3 spawnLocation;
            if (inverted==1)
            {
                offset = new Vector3(80, 0, 0);
                spawnRotation = Quaternion.Euler(0, -90, 0);
            }
            else
            {
                offset = new Vector3(-80, 0, 0);
                spawnRotation = Quaternion.Euler(0, 90, 0);
            }
            GameObject soldierPrefab = soldierPrefabs[Random.Range(0, soldierPrefabs.Count)];
            spawnLocation = targetBed.transform.position + offset;
            GameObject soldier = Instantiate<GameObject>(soldierPrefab, spawnLocation, spawnRotation);
            PrepareLimbs(soldier);
            lastSpawn = Time.time;

            minDelay = Mathf.Max(minDelay *= 1 - Time.timeSinceLevelLoad * delayRate, minMinDelay);
            maxDelay = Mathf.Max(maxDelay *= 1 - Time.timeSinceLevelLoad * delayRate, minMaxDelay);
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
