using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    public List<AudioClip> clips;

    public float minVolume = 0.2f;
    public float maxVolume = 1;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = Random.Range(minVolume, maxVolume);
        audioSource.clip = clips[Random.Range(0, clips.Count)];

        audioSource.Play();
    }
}
