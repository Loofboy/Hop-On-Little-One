using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyObj : MonoBehaviour
{
    public Animator Fader;
    public GameObject GameOverUI;
    public GameObject SlowmotionTimer;
    //int playanim = 0;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameOverUI.SetActive(true);
            GameOverUI.GetComponent<GameOverScript>().GameOverActive = 1;
            SlowmotionTimer.SetActive(false);
            collision.gameObject.GetComponent<SlowMotion>().StopSlowMo();
        }
        Destroy(collision.gameObject);
    }
}
