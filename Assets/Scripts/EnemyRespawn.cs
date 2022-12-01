using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{

    public List<Transform> respawnPoints = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RespawnTrigger"))
        {
            int rng = Random.Range(0, 4);
            if (rng == 3)
            {
                Invoke("SpawnEnemy", 1f);
            }
            else if (rng <= 1)
            {
                EnemyMovement enemyMovement = GetComponent<EnemyMovement>();
                enemyMovement.speed *= 1.5f;
            }
            Respawn();
        }
    }


    private void Respawn()
    {
        Transform respawnPoint = respawnPoints[Random.Range(0, respawnPoints.Count)];
        transform.position = respawnPoint.position;
    }

    private void SpawnEnemy()
    {
        Transform respawnPoint = respawnPoints[Random.Range(0, respawnPoints.Count)];
        Instantiate(gameObject,respawnPoint.position,Quaternion.identity);
    }

}
