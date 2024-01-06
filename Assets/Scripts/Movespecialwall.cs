using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movespecialwall : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;
    public GameObject MusicPlayer;
    public GameObject Player;
    public AudioClip complaining;
    int beatsnow;
    int triggered = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        beatsnow = (int)(MusicPlayer.GetComponent<Composer>().songposb);
        if (beatsnow >= 100 && transform.position.y > -15)
            Movewalls();
        if(beatsnow >= 120 && Player.transform.position.x < -5 && Player.transform.position.y > 0 && triggered == 0)
        {
            StartCoroutine(activateMario());
            triggered = 1;
        }
    }

    IEnumerator activateMario()
    {
        Player.GetComponent<PauseMenu>().disableInput = true;
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(complaining, MusicPlayer.GetComponent<AudioSource>().volume);
        MusicPlayer.GetComponent<AudioSource>().volume = 0;
        yield return new WaitForSeconds(35);
        this.gameObject.GetComponent<SceneM>().EnterStage00();
    }

    void Movewalls()
    {
        transform.position += (velocity * Time.deltaTime);
    }
}
