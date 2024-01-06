using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandNumGen : MonoBehaviour
{

    public GameObject MusicPlayer;
    public string[] gennednums = new string[4];
    public AudioClip[] clips = new AudioClip[10];
    public int[] clipper = new int[5];
    int slot = 0;
    int played = 0;
    int maxbeat = 204;

    Composer composer;
    AudioSource VolPick;



    // Start is called before the first frame update
    void Start()
    {
        composer = MusicPlayer.GetComponent<Composer>();
        VolPick = MusicPlayer.GetComponent<AudioSource>();
        for(int i = 0; i < 4; i++)
        {
            gennednums[i] = Random.Range(0, 9).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)(composer.songposb) == clipper[slot] && played == 0 && slot < 4)
        {
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(clips[int.Parse(gennednums[slot])], VolPick.volume);
            played = 1;
            slot++;
        }
        if ((int)(composer.songposb) != clipper[slot]) played = 0;

        if ((int)(composer.songposb) == maxbeat)
        {
            for(int i = 0; i < 5; i++)
            {
                clipper[i] += 192;
            }
            maxbeat += 192;
            slot = 0;
        }
    }
}
