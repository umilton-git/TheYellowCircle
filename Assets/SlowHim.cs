using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowHim : MonoBehaviour {
    public int time = 10;



    void OnTriggerEnter(Collider other)
    {
        //first we make sure that the object that hit the banana is the player.
        if (other.tag == "enemy")
        {
            Debug.Log("Enemy entered slow zone");
            EnemyFollowPlayer.movementSpeed -= 2;
            float timecount = time;
        }
    }
            
    
}
