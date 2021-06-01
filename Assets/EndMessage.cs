using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMessage : MonoBehaviour {
    private string endMessage = "";
    public Text TextBox;

	// Use this for initialization
	void Start () {
        endMessage = "";
        TextBox.text = endMessage;
	}
	
	// Update is called once per frame
	void Update () {
		if(collection.count == 15)
        {
            endMessage = "HEAD TO THE EXIT.";
            TextBox.text = endMessage;
        }
	}
}
