using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;
    public GameObject LossUI;
    public GameObject player;

    public Animator shot1;
    public Animator shot2;
    public Animator shot3;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < 4)
            transform.position += (velocity * Time.deltaTime);
    }
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.A) && transform.position.y == 2 && transform.position.x > -2 && transform.position.x < 0 && LossUI.GetComponent<GameOverScript>().GameOverActive == 0 && player.GetComponent<PauseMenu>().disableInput == false))
        {
            Destroy(transform.gameObject);
            shot1.SetTrigger("Shoot");
            //Debug.Log("A");
        }
        if ((Input.GetKeyDown(KeyCode.S) && transform.position.y == 0 && transform.position.x > -2 && transform.position.x < 0 && LossUI.GetComponent<GameOverScript>().GameOverActive == 0 && player.GetComponent<PauseMenu>().disableInput == false))
        {
            Destroy(transform.gameObject);
            shot2.SetTrigger("Shoot");
            //Debug.Log("s");
        }
        if ((Input.GetKeyDown(KeyCode.D) && transform.position.y == -2 && transform.position.x > -2 && transform.position.x < 0 && LossUI.GetComponent<GameOverScript>().GameOverActive == 0 && player.GetComponent<PauseMenu>().disableInput == false))
        {
            Destroy(transform.gameObject);
            shot3.SetTrigger("Shoot");
            //Debug.Log("d");
        }
    }
}
