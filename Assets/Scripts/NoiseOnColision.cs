using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseOnColision: MonoBehaviour
{
	public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
	{
		if(other.GetComponent<PlayerController>())
		{
  		audioSource.Play();
		}
        
	}
}
