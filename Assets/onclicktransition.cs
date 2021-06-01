using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class onclicktransition : MonoBehaviour {

    public Button m_YourButton;
    public string nextScene;

    // Use this for initialization
    void Start ()
    {
        m_YourButton.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {  
            SceneManager.LoadScene(nextScene);       
    }
}
