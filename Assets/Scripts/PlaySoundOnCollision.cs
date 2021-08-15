using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    public float velocityThreshold = 1;
    public float angularVelocityThreshold = .5f;

    public AudioSource[] dominoCollisionSounds,
        floorCollisionSounds;

    private Rigidbody rb;
    private AudioSource sfx;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!rb)
            return;

        float mag = rb.velocity.magnitude;
        float aMag = rb.angularVelocity.magnitude;
        if (mag > velocityThreshold || aMag > angularVelocityThreshold)
            PlaySound(!collision.gameObject.GetComponent<DominoInstance>(), 1);
        else
            PlaySound(!collision.gameObject.GetComponent<DominoInstance>(),
                Mathf.Max(mag / velocityThreshold,
                aMag / angularVelocityThreshold));
    }

    private void PlaySound(bool ground, float v)
    {
        AudioSource s;
        if (ground)
            s = RandomSound(floorCollisionSounds);
        else
            s = RandomSound(dominoCollisionSounds);
        s.volume = v;
        s.Play();
    }

    private AudioSource RandomSound(AudioSource[] a)
    {
        return a[Random.Range(0, a.Length)];
    }
}
