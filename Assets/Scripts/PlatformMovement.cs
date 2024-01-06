using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;
    //public AudioSource blip;
    //public GameObject musicpl;
    //Composer composer;
    //private int x = 0;

    private void Start()
    {
        //blip = GetComponent<AudioSource>();
        //composer = musicpl.GetComponent<Composer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
    private void FixedUpdate()
    {
        if(transform.position.x > -16)
            transform.position += (velocity * Time.deltaTime);
    }
    private void Update()
    {
        //if (transform.position.y <= -1f && x == 0)
        //{
            //    blip.Play();
            //Debug.Log("Block hits!" + composer.songposb);
           // x = 1;
        //}
    }
}
