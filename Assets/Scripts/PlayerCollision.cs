using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update

    PlayerDeath playerDeath;
    void Start()
    {
        playerDeath = GetComponent<PlayerDeath>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerDeath.StartDying();
            collision.gameObject.GetComponent<EnemyMovement>().enabled = false;
        }
    }
}
