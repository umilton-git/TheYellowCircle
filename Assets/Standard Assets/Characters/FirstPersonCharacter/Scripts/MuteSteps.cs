using UnityEngine;
using System.Collections;

public class MuteSteps : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            audioSource.Play();
        }
        else if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical") && audioSource.isPlaying)
        {
            audioSource.Stop(); // or Pause()
        }



    }

}
