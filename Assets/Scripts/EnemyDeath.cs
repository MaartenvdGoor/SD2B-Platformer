using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public bool animComplete;
    public List<Transform> respawnPoints = new List<Transform>();

    private Animator animator;
    private EnemyMovement enemyMovement;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyMovement = GetComponent<EnemyMovement>();
        enemyMovement.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (animComplete)
        {
            animComplete = false;
            SpawnEnemy();           
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void SpawnEnemy()
    {
        Instantiate(gameObject, respawnPoints[Random.Range(0,respawnPoints.Count)].position,Quaternion.identity);
    }

    public void Die()
    {
        enemyMovement.enabled = false;
        animator.SetBool("EnemyDeath", true);
    }

}
