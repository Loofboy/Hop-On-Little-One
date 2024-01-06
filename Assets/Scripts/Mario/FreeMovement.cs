using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FreeMovement : MonoBehaviour
{
    private float horiz;
    private float speed = 10f;
    public float jumpingPower = 16f;
    private bool FacingRight = true;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public Animator animator;
    AudioSource charSFX;
    public AudioClip goodJumpSound;
    public AudioClip crunchsound;
    public GameObject UI;

    public int points = 0;


    // Start is called before the first frame update
    void Start()
    {
        charSFX = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Lemon")
        {
            charSFX.PlayOneShot(crunchsound, 2.5f);
            Destroy(collision.gameObject);
            points++;
            UI.GetComponent<MUIController>().Updatepoints();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y > 0.5) animator.SetBool("IsJumping", true);
        else animator.SetBool("IsJumping", false);

        horiz = Input.GetAxisRaw("Horizontal");
        if (this.gameObject.GetComponent<PauseMenu>().disableInput == true) horiz = 0;
        if (Input.GetButtonDown("Jump") && IsGrounded() && this.gameObject.GetComponent<PauseMenu>().disableInput == false)
        {
            charSFX.PlayOneShot(goodJumpSound, 0.5f);
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        Flip();
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
        if ((FacingRight && horiz < 0f || !FacingRight && horiz > 0f) && this.gameObject.GetComponent<PauseMenu>().disableInput == false)
        {
            FacingRight = !FacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }


    }
}
