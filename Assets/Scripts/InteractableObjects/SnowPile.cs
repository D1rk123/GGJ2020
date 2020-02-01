using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPile : MonoBehaviour, IInteractable
{
	public ParticleSystem _snowPickedUpParticles;

	void Awake ()
	{
		_snowPickedUpParticles.Stop();
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.A))
			Interact();
	}

	public void Interact ()
	{
		_snowPickedUpParticles.Stop();
		_snowPickedUpParticles.Play();
	}
}
