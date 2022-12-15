using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public bool animComplete;
    public List<Transform> respawnPoints = new List<Transform>();
    public bool IsDead;
    public int pointsValue;
    public Score scoreKeeper;
    

    private Animator animator;
    private EnemyMovement enemyMovement;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animComplete)
        {
            animComplete = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void Die()
    {
        scoreKeeper.ScorePoints(pointsValue);
        enemyMovement.enabled = false;
        animator.SetBool("EnemyDeath", true);
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        IsDead = true;
    }

}
