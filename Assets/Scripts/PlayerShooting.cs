using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject Bullet;

    private float facingDirx = 1;
    private float facingDiry = 1;
    public float prevDirx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");

        if (dirX == -1 || dirX == 1)
        {
            prevDirx = dirX;
            Debug.Log(dirX);
            facingDirx = dirX;
        }
        if (dirY == -1 || dirY == 1)
        {
            facingDirx = 0;
            facingDiry = 1;

        }
        else if (dirY == 0)
        {
            facingDirx = prevDirx;
            facingDiry = 0;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject spawnedBullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<BulletMovement>().dirX = facingDirx;
            spawnedBullet.GetComponent<BulletMovement>().dirY = facingDiry;
            
        }
    }
}
