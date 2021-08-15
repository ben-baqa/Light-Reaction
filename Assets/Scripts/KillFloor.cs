using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    public Transform player;
    public Transform respawn_point;


    private void OnTriggerEnter(Collider other)
    {
	if(other.GetComponent<PlayerController>())
	{
 	 player.transform.position = respawn_point.transform.position;
	}
        
    }
}
