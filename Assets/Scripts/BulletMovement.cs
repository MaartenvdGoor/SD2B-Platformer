using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 15f;
    public float lifetime = 3f;
    public float dirX = 1f;



    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        if (dirX < 0)
        {
            transform.eulerAngles = Vector3.up * 180;
        }
        transform.Translate(transform.right * dirX * speed * Time.deltaTime);
    }
}
