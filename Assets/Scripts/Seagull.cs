using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull : MonoBehaviour
{
	[SerializeField] Transform headTransform;
	Vector3 _headBaseLocalPosition;
	[SerializeField] Transform beakTip;

	enum States { Incoming, Fighting, Dying };
	States _state = States.Incoming;

	Vector3 _fightingPosition = Vector3.zero;
	bool _isLookingLeft = false;
	float _xPosition;
	float _yPosition;
	private int _health = 0;

	[Header("Incoming Settings")]
	[SerializeField] float _incomingSpeed = 2.5f;

	[Header("Fighting Settings")]
	[SerializeField] float _secondsPerPeck = 1.2f;
	[SerializeField] float _peckSpeed = 30;
	[SerializeField] float _hitBoxHalfExtends = 2;

	GameObject[] _breakableObjects;
	GameObject[] _playerCharacters;
	float _fightingTimer = 0;
	bool _isPecking = false;
	bool _peckMovingIn = true;

	[Header("Dying Settings")]
	public float _dyingDuration = 3;
	public delegate void RemovalEventHandler (bool isLookingLeft);
	public event RemovalEventHandler IsRemoved;

	private void Awake ()
	{
		//Init(new Vector3(-40, -10, 0), new Vector3(-24, -10, 0), false);
	}

	public void Init (Vector3 spawnPosition, Vector3 fightingPosition, bool isLookingLeft, int startingHealth, GameObject[] breakableObjects, GameObject[] playerCharacters)
	{
		_state = States.Incoming;
		_headBaseLocalPosition = headTransform.localPosition;
		_fightingPosition = fightingPosition;
		transform.localScale = new Vector3(isLookingLeft ? -1 : 1, 1, 1);
		transform.position = spawnPosition;
		_xPosition = spawnPosition.x;
		_yPosition = spawnPosition.y;
		_health = startingHealth;
		_breakableObjects = breakableObjects;
		_playerCharacters = playerCharacters;
		Debug.Log("startingHealth: " + startingHealth);
		gameObject.SetActive(true);
	}

	private void Update ()
	{
		Debug.Log(_state);

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
		if (!_isPecking) {
			_fightingTimer += Time.deltaTime;
			if (_fightingTimer >= _secondsPerPeck) {
				_isPecking = true;
				_fightingTimer = 0;
				StartCoroutine(PerformPeck());
				Debug.Log("performing peck");
			}
		} else {

		}
	}

	IEnumerator PerformPeck ()
	{
		//Find random target
		GameObject target;
		int maxRoll = _breakableObjects.Length + _playerCharacters.Length;
		int roll = UnityEngine.Random.Range(0, maxRoll);
		if (roll < _breakableObjects.Length) {
			target = _breakableObjects[roll];
		} else {
			target = _playerCharacters[roll - _breakableObjects.Length];
		}

		Debug.Log("target: " + target.name);

		Vector3 oldBeakPosition;
		Vector3 newBeakPosition;

		//Move beak in
		while (true) {
			oldBeakPosition = beakTip.position;
			newBeakPosition = Vector3.MoveTowards(beakTip.position, target.transform.position, _peckSpeed * Time.deltaTime);
			headTransform.Translate(newBeakPosition - oldBeakPosition);
			Debug.Log(newBeakPosition - oldBeakPosition);
			Debug.Log(beakTip.position);

			if (Vector3.Distance(beakTip.position, target.transform.position) < 0.05f) {
				Debug.Log(Vector3.Distance(beakTip.position, target.transform.position));
				break;
			}

			Debug.Log("moving in");
			yield return null;
		}

		//Moving back
		while (true) {
			oldBeakPosition = beakTip.position;
			newBeakPosition = Vector3.MoveTowards(beakTip.position, headTransform.position - _headBaseLocalPosition, _peckSpeed * Time.deltaTime);
			headTransform.Translate(newBeakPosition - oldBeakPosition);

			if (Vector3.Distance(beakTip.position, headTransform.position - _headBaseLocalPosition) < 0.05f) {
				break;
			}

			Debug.Log("moving out");
			yield return null;
		}

		_isPecking = false;
	}

	private IEnumerator Dying ()
	{
		Debug.Log("Started dying");
		Vector3 dyingStartPosition = transform.position;
		float elapsed = 0.0f;

		float intensity = 0.5f;
		float fallDistance = 30;

		while (elapsed < _dyingDuration) {
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

	public void ReceiveDamage (int damage)
	{
		Debug.Log("Health before: " + _health);
		_health -= damage;
		Debug.Log("Health after: " + _health);
		if (_health <= 0) {
			StopCoroutine(PerformPeck());
			StartCoroutine(Dying());
		}
	}

	protected virtual void TriggerRemovalEvent ()
	{
		IsRemoved?.Invoke(_isLookingLeft);
	}
}
