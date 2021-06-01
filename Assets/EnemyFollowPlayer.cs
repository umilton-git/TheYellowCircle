using UnityEngine;
public class EnemyFollowPlayer : MonoBehaviour
{
    public GameObject Player;
    public static float movementSpeed = 23;

    void Start()
    {
        movementSpeed = 23;
    }

    void Update()
    {
        transform.LookAt(Player.transform);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
        Debug.Log("EnemySpeed = " + movementSpeed);
    }
}
