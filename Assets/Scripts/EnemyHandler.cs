using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> Enemies;
    public Door DoorToOpen;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject enemy in Enemies)
        {
            if (!enemy.GetComponent<EnemyDeath>().IsDead)
            {
                return;
            }
            DoorToOpen.isActive = true;
            
        }
    }

}
