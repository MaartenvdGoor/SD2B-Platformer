using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    
    public float horizontalSpeed = 10f;
    public float jumpForce = 10f;
    new Rigidbody2D rigidbody2D;
    public AudioClip jumpAudio;

    AudioSource audioSource;
    bool jumpRelease = false;
    [SerializeField]
    bool isJumping = false;
    [SerializeField]
    bool doubleJumpAvailable = true;
    float dirX;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("quit game");
            Application.Quit();
        }
        dirX = Input.GetAxis("Horizontal");

        if (dirX < 0)
        {
            transform.eulerAngles = Vector3.up * 180;
        }
        else if (dirX > 0)
        {
            transform.eulerAngles = Vector3.up * 0;
        }

        transform.Translate(transform.right * dirX * horizontalSpeed * Time.deltaTime);
        animator.SetBool("IsRunning", dirX != 0);

        if (Input.GetButtonDown("Jump") && (!isJumping || doubleJumpAvailable))
        {
            if (isJumping)
            {
                Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
                doubleJumpAvailable = false;

            }
            jumpRelease = true;
            audioSource.clip = jumpAudio;
            audioSource.Play();
        }



    }
        
    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(dirX * horizontalSpeed, rigidbody2D.velocity.y);
        if (jumpRelease)
        {
            
            rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpRelease = false;
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
     {
        if (collision.gameObject.layer == 3)
        {
            isJumping = false;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isJumping = true;
            doubleJumpAvailable = true;
        }
    }
}
