using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public GameObject Heart01;
    public GameObject Heart02;
    public GameObject Heart03;
    public GameObject LossUI;

    int health = 2;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        switch (health){
            case 2:
                Heart03.SetActive(false);
                break;
            case 1:
                Heart02.SetActive(false);
                break;
            case 0:
                Heart01.SetActive(false);
                LossUI.SetActive(true);
                LossUI.GetComponent<GameOverScript>().GameOverActive = 1;
                break;
        }
        health--;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
