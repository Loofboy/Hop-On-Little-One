using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVoice : MonoBehaviour
{
    public AudioClip voice;
    public GameObject MusicPlayer;
    public float vol = 0;

    // Start is called before the first frame update
    private void Start()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(voice);

    }
    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<AudioSource>().volume = MusicPlayer.GetComponent<AudioSource>().volume * vol;
    }
}
