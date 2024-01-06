using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullets : MonoBehaviour
{

    public GameObject Bullet;
    public GameObject music;

    public Sprite spriteA;
    public Sprite spriteS;
    public Sprite spriteD;

    
    Composer composer;
    public int[] BulletPattern;

    public int xpos;
    int songBeats;
    int prevbeat = 0;
    private void Awake()
    {
        composer = music.GetComponent<Composer>();
    }

    void Start()
    {
        for(int i = 0; i < 112; i++)
        {
            BulletPattern[i] = Random.Range(1, 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        songBeats = (int)(composer.songposb);
        if(prevbeat != songBeats)
        {
            prevbeat = songBeats;
            if(prevbeat < BulletPattern.Length)
                CreateBullet(BulletPattern);
        }

    }

    void CreateBullet(int[] BP)
    {
        Vector2 spawnpos = new Vector2();
        spawnpos.x = xpos;
        switch (BP[songBeats])
        {
            case 1:
                spawnpos.y = 2;
                Bullet.GetComponent<SpriteRenderer>().sprite = spriteA;
                break;
            case 2:
                spawnpos.y = 0;
                Bullet.GetComponent<SpriteRenderer>().sprite = spriteS;
                break;
            case 3:
                spawnpos.y = -2;
                Bullet.GetComponent<SpriteRenderer>().sprite = spriteD;
                break;
            case 4:
                spawnpos.y = 2;
                Bullet.GetComponent<SpriteRenderer>().sprite = spriteA;
                Instantiate(Bullet, spawnpos, Quaternion.identity);
                spawnpos.y = 0;
                Bullet.GetComponent<SpriteRenderer>().sprite = spriteS;
                Instantiate(Bullet, spawnpos, Quaternion.identity);
                spawnpos.y = -2;
                Bullet.GetComponent<SpriteRenderer>().sprite = spriteD;
                break;
            default:
                break;
        }
        Instantiate(Bullet, spawnpos, Quaternion.identity);
    }
}
