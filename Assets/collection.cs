using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collection : MonoBehaviour {
    public static int count;
    public Text countText;

	// Use this for initialization
	void Start () {
        count = 0;
        
		
	}
	
	// Update is called once per frame
	void Update () {
        SetCountText();
	}

    void SetCountText()
    {
        countText.text = "x" + count.ToString();
    }

}
