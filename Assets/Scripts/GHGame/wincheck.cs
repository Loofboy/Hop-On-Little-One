using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wincheck : MonoBehaviour
{
    public GameObject MusicPlayer;
    public GameObject SceneManager;
    public GameObject GameOverUI;
    public int beatnow;
    public int beatend = 124;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        beatnow = (int)(MusicPlayer.GetComponent<Composer>().songposb);
        if(beatnow >= beatend && GameOverUI.activeInHierarchy == false)
        {
            SceneManager.GetComponent<SceneM>().EnterStage00();
            PlayerPrefs.SetInt("end5", 1);
        }
    }
}
