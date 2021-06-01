using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownToSceneChange : MonoBehaviour {
    private float count;

	// Use this for initialization
	void Start () {
        StartCoroutine(Wait());

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("mainmenu");
    }
}
