using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emblcontrol : MonoBehaviour
{
    public GameObject[] emblems = new GameObject[6];
    public GameObject sceneMan;
    int cEnds = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            if(PlayerPrefs.GetInt("end"+i) == 1)
            {
                emblems[i].SetActive(true);
                cEnds++;
            }
            else
                emblems[i].SetActive(false);
        }
        if (cEnds == 5) sceneMan.GetComponent<SceneM>().SceneName = "GHGame";
    }
}
