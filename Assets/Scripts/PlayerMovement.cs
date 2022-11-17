using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalSpeed = 10f;
    public float horizontalJumpVelocityModifier = 10f;
    public float maxJumpForce = 20f;
    public float minJumpForce = 3f;
    public float JumpMultiplier = 10f;

    bool jumpRelease = false;
    [SerializeField]
    bool isJumping = false;
    float dirX;

    [SerializeField]
    float jumpCharge;

    [SerializeField]
    bool isCharging = false;
    // Start is called before the first frame update
    void Start()
    {
        jumpCharge = minJumpForce;
    }

    // Update is called once per frame
    void Update()
    {



        if (!isCharging && !isJumping)
        {
            transform.Translate(transform.right * dirX * horizontalSpeed * Time.deltaTime);
        }
        dirX = Input.GetAxis("Horizontal");


        if (Input.GetButton("Jump") && !isJumping)
        {
            jumpCharge += Time.deltaTime;
            isCharging = true;
        }
        if (Input.GetButtonUp("Jump") && !isJumping)
        {
            Debug.Log("Wut");
            jumpRelease = true;
            isCharging = false;
        }


    }

    private void FixedUpdate()
    {
        if (jumpRelease)
        {
            Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

            float finalJumpCharge = JumpMultiplier * jumpCharge;
            if (finalJumpCharge > maxJumpForce)
            {
                finalJumpCharge = maxJumpForce;
            }
            rigidbody2D.AddForce(new Vector2(dirX * horizontalJumpVelocityModifier, finalJumpCharge), ForceMode2D.Impulse);
            Debug.Log(finalJumpCharge);
            jumpRelease = false;
            jumpCharge = minJumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == 3)
        {
            isJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == 3)
        {
            isJumping = true;
        }
    }
}
