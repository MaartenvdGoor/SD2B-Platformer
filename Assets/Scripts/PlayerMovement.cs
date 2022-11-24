using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalSpeed = 10f;
    public float jumpForce = 10f;


    bool jumpRelease = false;
    [SerializeField]
    bool isJumping = false;
    [SerializeField]
    bool doubleJumpAvailable = true;
    float dirX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        dirX = Input.GetAxis("Horizontal");
        

        transform.Translate(transform.right * dirX * horizontalSpeed * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && (!isJumping || doubleJumpAvailable))
        {
            if (isJumping)
            {
                Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
                doubleJumpAvailable = false;

            }
            jumpRelease = true;
        }



    }

    private void FixedUpdate()
    {
        
        if (jumpRelease)
        {
            Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpRelease = false;
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
     {
        if (collision.gameObject.layer == 3)
        {
            Debug.Log("Entered Trigger");
            isJumping = false;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Debug.Log("Entered false");
            isJumping = true;
            doubleJumpAvailable = true;
        }
    }
}
