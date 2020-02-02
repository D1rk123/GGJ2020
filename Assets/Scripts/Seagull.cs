using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull : MonoBehaviour
{
	[SerializeField] Transform headTransform;
	[SerializeField] Transform beakTip;

	enum States { Incoming, Fighting, Dying };
	States _state = States.Incoming;

	Vector3 _fightingPosition = Vector3.zero;
	bool _isLookingLeft = false;
	float _xPosition;
	float _yPosition;
	private int _health = 0;
	
	[Header ("Incoming Settings")]
	[SerializeField] float _incomingSpeed = 2.5f;

	public delegate void RemovalEventHandler(bool isLookingLeft);

	public event RemovalEventHandler IsRemoved;

	public float _dyingDuration = 3;

	private void Awake ()
	{
		//Init(new Vector3(-40, -10, 0), new Vector3(-24, -10, 0), false);
	}

	public void Init (Vector3 spawnPosition, Vector3 fightingPosition, bool isLookingLeft)
	{
		_state = States.Incoming;
		_fightingPosition = fightingPosition;
		transform.localScale = new Vector3(isLookingLeft ? -1 : 1 , 1, 1);
		transform.position = spawnPosition;
		_xPosition = spawnPosition.x;
		_yPosition = spawnPosition.y;
		_health = 1;
		gameObject.SetActive(true);
	}

	private void Update ()
	{
		switch (_state) {
			case States.Incoming:
				Incoming();
				break;
			case States.Fighting:
				Fighting();
				break;
		}

		transform.position = new Vector3(_xPosition, _yPosition + SeagullWaterBob.waterBobHeight, 0);
		transform.rotation = Quaternion.Euler(0, 0, SeagullWaterBob.waterBobZRotation);
	}

	void Incoming ()
	{
		Vector3 newPosition = Vector3.MoveTowards(new Vector3(_xPosition, _yPosition, 0), _fightingPosition, _incomingSpeed * Time.deltaTime);
		_xPosition = newPosition.x;
		_yPosition = newPosition.y;

		if (Vector3.Distance(transform.position, _fightingPosition) < 0.05f) {
			_state = States.Fighting;
		}
	}

	void Fighting ()
	{

	}

	private IEnumerator Dying()
	{
		Debug.Log("Started dying");
		Vector3 dyingStartPosition = transform.position;
		float elapsed = 0.0f;

		float intensity = 0.5f;
		float fallDistance = 30;

		while (elapsed < _dyingDuration)
		{
			Vector3 shake = new Vector3(
				UnityEngine.Random.Range(-intensity, intensity),
				UnityEngine.Random.Range(-intensity, intensity),
				0
			);
			Vector3 fallDown = new Vector3(0, -fallDistance * (elapsed / _dyingDuration), 0);

			transform.position = dyingStartPosition + shake + fallDown;
			elapsed += Time.deltaTime;
			yield return null;
		}

		this.gameObject.SetActive(false);
		Debug.Log("Finished dying");
		TriggerRemovalEvent();
	}

	public void ReceiveDamage(int damage)
	{
		_health -= damage;
		if (_health <= 0)
		{
			StartCoroutine(Dying());
		}
	}

	protected virtual void TriggerRemovalEvent()
	{
		IsRemoved?.Invoke(_isLookingLeft);
	}
}
