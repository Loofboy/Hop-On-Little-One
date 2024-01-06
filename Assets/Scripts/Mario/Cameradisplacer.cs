using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameradisplacer : MonoBehaviour
{
    public GameObject Player;
    Vector3 campos;

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.x < -21.56)
        {
            campos.x = Player.transform.position.x + (-21.56f - Player.transform.position.x);
            campos.y = Player.transform.position.y + 0.9f;
            campos.z = -10;
            this.gameObject.transform.position = campos;
        }

        else if (Player.transform.position.x > 101.08)
        {
            campos.x = Player.transform.position.x + (101.08f - Player.transform.position.x);
            campos.y = Player.transform.position.y + 0.9f;
            campos.z = -10;
            this.gameObject.transform.position = campos;
        }

        else
        {
            campos.x = Player.transform.position.x;
            campos.y = Player.transform.position.y + 0.9f;
            campos.z = -10;
            this.gameObject.transform.position = campos;

        }
    }
}

