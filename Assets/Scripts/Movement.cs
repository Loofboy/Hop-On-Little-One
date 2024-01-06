using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private float horiz;
    private float speed = 10f;
    public float jumpingPower = 16f;
    private bool FacingRight = true;
    private float beat;
    //int jumped;
    int completed = 0;
    int animated = 0;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public GameObject music;
    public GameObject slowmotimer;
    public GameObject Blastparticle;
    public Animator animator;
    AudioSource charSFX;
    public AudioClip goodJumpSound;
    public AudioClip badJumpSound;
    //public AudioClip landSound;
    Composer composer;

    double maxtime, mintime;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "StageFast")
        {
            maxtime = .5; mintime = 0.85;
        }
        else
        {
            maxtime = 0.35; mintime = 0.9;
        }
        composer = music.GetComponent<Composer>();
        charSFX = GetComponent<AudioSource>();
        //jumped = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.y > 0.5 && completed == 0) animator.SetBool("IsJumping", true);
        else animator.SetBool("IsJumping", false);
        
        beat = composer.songposb;
        horiz = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") && IsGrounded() && this.gameObject.GetComponent<PauseMenu>().disableInput == false)
        {
            if ((beat % 1 < maxtime || beat % 1 > mintime) && rb.position.y < 0 && completed == 0)
            {
                charSFX.PlayOneShot(goodJumpSound, 0.5f);
                Debug.Log("GOOD JUMP - " + beat);
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
               // jumped = 1;
            }
            else if (completed == 0)
            {
                charSFX.PlayOneShot(badJumpSound, 0.5f);
                Debug.Log("BAD JUMP - " + beat);
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower / 2);
            }
        }

        //if (jumped == 1 && IsGrounded() && rb.velocity.y < 1)
        //{
        //    charSFX.PlayOneShot(landSound, 0.5f);
        //    Debug.Log("Played sound");
        //    jumped = 0;
       // }
        /*if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }*/
        Flip();

        if (slowmotimer.GetComponent<SlowMotionTimer>().vict == 1)
            completed = 1;

        if(completed == 1 && animated == 0)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0, 0);
            this.GetComponent<BoxCollider2D>().enabled = false;
                animator.SetTrigger("Finish");
            Blastparticle.SetActive(true);
            animated = 1;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horiz * speed, rb.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
    }


    private void Flip()
    {
        if ((FacingRight && horiz < 0f || !FacingRight && horiz > 0f) && completed == 0 && this.gameObject.GetComponent<PauseMenu>().disableInput == false)
        {
            FacingRight = !FacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }


    }
}
