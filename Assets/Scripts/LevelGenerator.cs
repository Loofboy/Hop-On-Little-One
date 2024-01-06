using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public GameObject platform;
    public GameObject player;
    public GameObject music;
    Composer composer;

    public int numPlatf;
    public float levelWidth = 5f;
    public float Yval = 11f;
    public float waittime = 1;
    int songBeats;
    float Y;
    int spawned = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        composer = music.GetComponent<Composer>();
    }
    void Start()
    {
        StartCoroutine(levelgen());
    }

    IEnumerator levelgen()
    {
        Vector3 spawnpos = new Vector3();
        while (player != null)
        {

           // Y = Yval;
            for (int i = 0; i < numPlatf; i++)
            {
                if (songBeats % 2 == 0 && songBeats > 1 && spawned == 0)
                {
                    spawnpos.y = Yval + (float)(0.01);
                    spawnpos.x = Random.Range(-levelWidth, levelWidth);
                    Instantiate(platform, spawnpos, Quaternion.identity);
                    //Y = Y + 3;
                    spawned = 1;
                    //Debug.Log("block" + composer.songposb);
                }
                else if (songBeats % 2 != 0) spawned = 0;
            }
            yield return new WaitForSeconds(waittime);

        }
    }
    // Update is called once per frame
    void Update()
    {
        songBeats = (int)(composer.songposb);
    }
}
