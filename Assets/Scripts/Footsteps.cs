using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private AudioSource runSound, runSound2;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] aS = GetComponentsInChildren<AudioSource>();
        runSound = aS[0];
        runSound2 = aS[1];

        Animator anim = GetComponent<Animator>();
        AnimationClip clip;
        AnimationEvent ev = new AnimationEvent(),
            ev2 = new AnimationEvent();

        ev.intParameter = 0;
        ev.time = 3 / 8;
        ev.functionName = "Footstep";

        ev2.intParameter = 1;
        ev2.time = 3 / 4;
        ev2.functionName = "Footstep";

        clip = anim.runtimeAnimatorController.animationClips[1];
        clip.AddEvent(ev);
        clip.AddEvent(ev2);
    }
    public void Footstep(int n)
    {
        if (n == 0)
            runSound.Play();
        else
            runSound2.Play();
    }
}
