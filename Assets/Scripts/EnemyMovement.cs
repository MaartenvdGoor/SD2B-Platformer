using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    private float dirX = 1f;
    private Rigidbody2D rigidbody2D;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D= GetComponent<Rigidbody2D>();
        int rng = Random.Range(0, 2);
        if (rng == 1)
        {
            
            dirX = 1f;
        }
        else
        {
            dirX = -1f;
        }
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetBool("EnemyRun", dirX != 0);

        if (dirX < 0)
        {
            transform.eulerAngles = Vector3.up * 180;
            
        }
        else if (dirX > 0)
        {
            transform.eulerAngles = Vector3.up * 0;
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(dirX * speed, rigidbody2D.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {

        }
        else if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Skelly hit wall");
            dirX = dirX * -1;
        }
    }
}
