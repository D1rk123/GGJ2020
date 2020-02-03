using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullWaterBob : MonoBehaviour
{
	public static float waterBobHeight = 0;
	public static float waterBobZRotation = 0;

	[SerializeField] float musicBPM = 146;
	[SerializeField] float beatsPerBob = 4;
	[SerializeField] float waterBobVerticalAmplitude = 1;
	[SerializeField] float waterBobRotationAmplitude = 8;
	float _waterBobSpeed;

	private void Awake ()
	{
		_waterBobSpeed = Mathf.PI * 2 * (1 / (60 / musicBPM * beatsPerBob));
	}

	void Update()
    {
		waterBobHeight = Mathf.Sin(Time.timeSinceLevelLoad * _waterBobSpeed * 2) * waterBobVerticalAmplitude;
		waterBobZRotation = Mathf.Sin(Time.timeSinceLevelLoad * _waterBobSpeed) * waterBobRotationAmplitude;
    }
}
