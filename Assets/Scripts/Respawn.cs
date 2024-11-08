using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{

    public GameObject player;
    public Transform SpawnPoint;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            player.transform.position = SpawnPoint.transform.position;
        }
    }
}