using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagementScript : MonoBehaviour
{

    public static AudioClip walksound;
    static AudioSource audioSrc;

    // Use this for initialization
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        walksound = Resources.Load<AudioClip>("walk");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "walk":
                audioSrc.PlayOneShot(walksound);
                break;
        }
    }
}
