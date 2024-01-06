using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip highblip;
    public AudioClip lowblip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    public void playhighblip()
    {
        audioSource.PlayOneShot(highblip, .05f);
    }
    public void playlowblip()
    {
        audioSource.PlayOneShot(lowblip, .05f);
    }
}
