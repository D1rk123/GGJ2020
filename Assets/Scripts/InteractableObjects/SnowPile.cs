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

	public void Interact ()
	{
		_snowPickedUpParticles.Stop();
		_snowPickedUpParticles.Play();
	}
}
