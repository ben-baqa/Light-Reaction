using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeet : MonoBehaviour
{
    public float force = 10000;

    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.GetComponent<Rigidbody>().AddForce(force * Vector3.up);
    }
}