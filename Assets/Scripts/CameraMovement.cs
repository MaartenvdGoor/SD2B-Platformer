using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> Targets = new List<Transform>();
    public float Speed;

    int currentTargetIndex = 0;
    bool isMoving;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var step = Speed * Time.deltaTime;
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, Targets[currentTargetIndex].position, step);
        }
        if (transform.position == Targets[currentTargetIndex].position)
        {
            isMoving = false;
        }
    }

    public void MoveForward()
    {
        currentTargetIndex++;
        isMoving= true;
    }

    public void MoveBackward()
    {
        currentTargetIndex--;
        isMoving = true;
    }

}
