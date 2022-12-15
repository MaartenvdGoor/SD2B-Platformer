using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource audioSource;
    private bool dying;
    private new SpriteRenderer renderer;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        renderer = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        if (dying && !audioSource.isPlaying)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            collision.gameObject.GetComponent<EnemyDeath>().Die();
        }
        audioSource.Play();
        //while (audioSource.isPlaying) ;
        renderer.enabled = false;
        dying = true;
        collision.otherCollider.enabled = false;
    }
}
