using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject Bullet;

    private float facingDirx = 1;
    public float prevDirx;
    public bool shoot = false;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");

        if (dirX != 0)
        {
            facingDirx = dirX;
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("IsShooting", true);
        }



        if (shoot)
        {
            GameObject spawnedBullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<BulletMovement>().dirX = facingDirx;
            shoot = false;
            animator.SetBool("IsShooting", false);
        }
    }

    private void FixedUpdate()
    {

    }
}
