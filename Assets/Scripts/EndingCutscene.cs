using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCutscene : MonoBehaviour
{
    int endnum;
    float mvol;
    float svol;
    int playing = 0;
    int leaving = 0;
    public AudioClip[] rants = new AudioClip[5];
    public AudioClip eyepop;
    public AudioClip eating;
    AudioSource aud;
    public Animator anim;
   // public Animator tanim;
    public Animator manim;
    public Animator canim;

    // Start is called before the first frame update
    void Start()
    {
        mvol = PlayerPrefs.GetFloat("musicvol");
        svol = PlayerPrefs.GetFloat("sfxvol");
        endnum = PlayerPrefs.GetInt("ending");
        StartCoroutine(PlayEnding(endnum));
        aud = this.gameObject.GetComponent<AudioSource>();
    }


    IEnumerator PlayEnding(int endnum)
    {
        yield return new WaitForSeconds(5);

        anim.SetTrigger("ActivateEyes");
        aud.PlayOneShot(eyepop, svol * .3f);

        yield return new WaitForSeconds(2);

        aud.PlayOneShot(rants[endnum], mvol*.4f);

        playing = 1;
    }

    IEnumerator PlayEatingAnims()
    {
        manim.SetTrigger("Mouth");
        canim.SetTrigger("shake");

        yield return new WaitForSeconds(2);

        this.gameObject.GetComponent<SceneM>().EnterStage00();
    }
    // Update is called once per frame
    void Update()
    {
        if(playing == 1 && aud.isPlaying != true && leaving == 0)
        {
            leaving = 1;
            GameObject.Find("EerieMusicPlayer").GetComponent<AudioSource>().Stop();
            aud.PlayOneShot(eating, svol * .5f);
            PlayerPrefs.SetInt("end" + endnum, 1);
            StartCoroutine(PlayEatingAnims());

        }
    }
}
