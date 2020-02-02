using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPile : MonoBehaviour, ISnowResource
{
	public ParticleSystem _snowPickedUpParticles;

	void Awake ()
	{
		_snowPickedUpParticles.Stop();
	}

	public bool GatherSnow()
	{
		Debug.Log("Gathering snow");
		_snowPickedUpParticles.Stop();
		_snowPickedUpParticles.Play();
		return true;
	}
}
