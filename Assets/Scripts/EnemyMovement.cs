using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    private float dirX = 1f;



    // Start is called before the first frame update
    void Start()
    {
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
        transform.Translate(transform.right * dirX * speed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
        else if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Enemy"))
        {
            dirX = dirX * -1;
        }
    }
}
