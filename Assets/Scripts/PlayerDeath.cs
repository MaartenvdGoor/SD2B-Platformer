using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDying()
    {
        animator.SetBool("IsDying", true);
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
    }

    public void Die()
    {         
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
