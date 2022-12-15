using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isActive;
    public Vector3 InitPos;
    public Transform TargetPos;
    public int Speed;

    void Start()
    {
        InitPos= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var step = Speed * Time.deltaTime;
        if (isActive)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPos.position, step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, InitPos, step);
        }
    }
}
