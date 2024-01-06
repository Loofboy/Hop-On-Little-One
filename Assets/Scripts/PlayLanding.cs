using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLanding : MonoBehaviour
{
    public AudioClip LandingSound;
    public float svol;
    int playedsound = 0;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && playedsound == 0)
        {
            float vol = PlayerPrefs.GetFloat("sfxvol");
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(LandingSound, svol*vol);
            //playedsound = 1;
        }
    }
}