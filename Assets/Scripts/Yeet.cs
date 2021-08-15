using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeet : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
	{
        collision.collider.GetComponent<Rigidbody>().AddForce(10000 * Vector3.up);
	}
}
