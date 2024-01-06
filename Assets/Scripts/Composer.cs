using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Composer : MonoBehaviour
{
    public float songBPM;
    public float spb;
    public float songpos;
    public float songposb;
    public float songt;
    public AudioSource musicSource;
    public float beatsperLoop;
    public float timenow;
    public int completedLoops = 0;
    public float loopPositionInBeats;
    public float loopPositionInAnalog;
    public static Composer instance;
    public Metronome metr;
    public int js = 0;

    int playedBlip = 0;
    int baseb = 0;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        spb = 60f / songBPM;
        timenow = (float)Time.time;
        songt = (float)Time.time - timenow;
        //Debug.Log(songt);
    }


    // Update is called once per frame
    void Update()
    {
        if ((((int)(songposb) == js*4+4 && songposb > js*4+4)  || (int)(songposb) == js*4+8) && playedBlip == 0)
        {
            metr.playhighblip();
            playedBlip = 1;
        }
        if(((int)(songposb) >= js*4+5 && (int)(songposb) <= js*4+7 || (int)(songposb) >= js*4+9 && (int)(songposb) <= js*4+11) && playedBlip == 0)
        {
            metr.playlowblip();
            playedBlip = 1;
        }
        if (musicSource.isPlaying == false && songposb > js*4+12)
        {
            musicSource.Play();
        }
        musicSource.pitch = Time.timeScale;
        songpos = (float)(Time.time - timenow - .35);
        songposb = songpos / spb;
        if (songposb >= (completedLoops + 1) * beatsperLoop) completedLoops++;
        loopPositionInBeats = songposb - completedLoops * beatsperLoop;
        loopPositionInAnalog = loopPositionInBeats / beatsperLoop;

        if(baseb != (int)(songposb))
        {
            baseb = (int)(songposb);
            playedBlip = 0;
        }

    }
    void Awake()
    {
        instance = this;
    }
}
