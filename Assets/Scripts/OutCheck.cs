using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutCheck : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            this.gameObject.GetComponent<SceneM>().EnterStage00();
        }
    }
}
