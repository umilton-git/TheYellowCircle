using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class CollectObj : MonoBehaviour
{
    public AudioSource AudioP;
    public AudioClip clip;

    public void OnCollisionEnter(Collision node)
    {
        if (node.gameObject.tag == "collectible")
        {
            Destroy(node.gameObject);
            EnemyFollowPlayer.movementSpeed += 1;
            collection.count += 1;
            AudioP.PlayOneShot(clip,  1.0F);
        }
    }

}