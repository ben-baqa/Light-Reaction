using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    public float velocityThreshold = 1;

    private Rigidbody rb;
    private AudioSource sfx;
    // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!rb)
            return;

        float mag = rb.velocity.magnitude;
        if (mag > velocityThreshold)
        {
            sfx.volume = 1;
            sfx.Play();
        }
        else
        {
            sfx.volume = mag / velocityThreshold;
            sfx.Play();
        }
    }
}
