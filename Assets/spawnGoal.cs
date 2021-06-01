using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnGoal : MonoBehaviour {
    private bool goal;
    [SerializeField]
    private GameObject GoalPrefab;

	// Use this for initialization
	void Start () {
        goal = false; 
		
	}
	
	// Update is called once per frame
	void Update () {
        if(collection.count == 15 && goal == false)
        {
            Instantiate(GoalPrefab);
            goal = true;
        }
		
	}
}
