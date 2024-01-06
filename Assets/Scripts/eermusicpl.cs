using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eermusicpl : MonoBehaviour
{
    public float musvol;

    // Start is called before the first frame update
    void Start()
    {
        float mvol = PlayerPrefs.GetFloat("musicvol");
        this.gameObject.GetComponent<AudioSource>().volume = mvol * musvol;
        this.gameObject.GetComponent<AudioSource>().Play();  
    }

    // Update is called once per frame
}
