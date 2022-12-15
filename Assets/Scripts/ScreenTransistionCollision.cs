using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTransistionCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public CameraMovement cameraMovement;
    public Door door;

    bool hasEnteredBefore = false;


    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (hasEnteredBefore)
            {
                hasEnteredBefore = false;
                cameraMovement.MoveBackward();
                door.isActive = true;
            }
            else
            {
                hasEnteredBefore = true;
                cameraMovement.MoveForward();
                door.isActive = false;
            }
           
        }
    }
}
