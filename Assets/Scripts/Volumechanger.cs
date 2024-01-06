using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumechanger : MonoBehaviour
{
    public GameObject Composer;
    public GameObject Player;
    public GameObject Lyrics;
    public Toggle SubsToggle;
    public float MusicvolumeMultiplier;
    public float SFXvolumeMultiplier;

    [SerializeField] private Slider MusicvolumeSlider = null;
    [SerializeField] private Slider SFXvolumeSlider = null;


    private void Start()
    {
        LoadValues();
    }


    // Start is called before the first frame update
    public void changeMusicVol(float musicvolvalue)
    {
        musicvolvalue = MusicvolumeSlider.value;
        PlayerPrefs.SetFloat("musicvol", musicvolvalue);
        Composer.GetComponent<AudioSource>().volume = (float)(musicvolvalue * MusicvolumeMultiplier);
    }

    public void changeSFXVol(float sfxvolvalue)
    {
        sfxvolvalue = SFXvolumeSlider.value;
        PlayerPrefs.SetFloat("sfxvol", sfxvolvalue);
        Player.GetComponent<AudioSource>().volume = (float)(sfxvolvalue * SFXvolumeMultiplier);
    }

    public void changesubs()
    {
        bool value = SubsToggle.isOn;;
        if(value == true)
        {
            PlayerPrefs.SetInt("subs", 1);
        }
        else
        {
            PlayerPrefs.SetInt("subs", 0);
        }
        LoadValues();


    }

    void LoadValues()
    {
        int subbool = PlayerPrefs.GetInt("subs");
        if (subbool > 0)
        {
            Lyrics.SetActive(true);
            SubsToggle.isOn = true;
        }
        else
        {
            Lyrics.SetActive(false);
            SubsToggle.isOn = false;
        }
        float musicvolvalue = PlayerPrefs.GetFloat("musicvol");
        float sfxvolvalue = PlayerPrefs.GetFloat("sfxvol");
        MusicvolumeSlider.value = musicvolvalue;
        Composer.GetComponent<AudioSource>().volume = (float)(musicvolvalue * MusicvolumeMultiplier);
        SFXvolumeSlider.value = sfxvolvalue;
        Player.GetComponent<AudioSource>().volume = (float)(sfxvolvalue * SFXvolumeMultiplier);
    }
}
