using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull : MonoBehaviour
{
	[SerializeField] Transform headTransform;
	Vector3 _headBaseLocalPosition;
	[SerializeField] Transform beakTip;
	[SerializeField] GameObject explosions;
	[SerializeField] SeagullSides side = SeagullSides.Left;

	enum States { Incoming, Fighting, Dying };
	States _state = States.Incoming;

	Vector3 _fightingPosition = Vector3.zero;
	float _xPosition;
	float _yPosition;
	float _zPosition;
	float _baseYRotation;
	private int _health = 0;

	[Header("Incoming Settings")]
	[SerializeField] float _incomingSpeed = 2.5f;

	[Header("Fighting Settings")]
	[SerializeField] float _secondsPerPeck = 1.2f;
	[SerializeField] float _peckSpeed = 38;
	[SerializeField] Vector3 _hitBoxHalfExtends = new Vector3(2, 2, 100);

	GameObject[] _breakableObjects;
	GameObject[] _playerCharacters;
	float _fightingTimer = 0;
	bool _isPecking = false;

	[Header("Dying Settings")]
	public float _dyingDuration = 5;
	public float secondsBetweenExplosions = .25f;
	public delegate void RemovalEventHandler (SeagullSides side);
	public event RemovalEventHandler IsRemoved;
	float _explosionTimer = 0;

	private void Awake ()
	{
		Debug.Log(_headBaseLocalPosition);
	}

	public void Init (Vector3 spawnPosition, Vector3 fightingPosition, int startingHealth, GameObject[] breakableObjects, GameObject[] playerCharacters)
	{
		explosions.SetActive(false);
		_state = States.Incoming;
		_fightingPosition = fightingPosition;
		transform.position = spawnPosition;
		_headBaseLocalPosition = headTransform.localPosition;
		_xPosition = spawnPosition.x;
		_yPosition = spawnPosition.y;
		_zPosition = spawnPosition.z;
		_baseYRotation = side == SeagullSides.Left ? 0 : 180;
		_health = startingHealth;
		_breakableObjects = breakableObjects;
		_playerCharacters = playerCharacters;
		Debug.Log("startingHealth: " + startingHealth);
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
			case States.Dying:
				_explosionTimer += Time.deltaTime;
				if (_explosionTimer >= secondsBetweenExplosions) {
					AudioManager.PlayAudioClip(AudioManager.AudioClips.DeathExplosion);
					_explosionTimer = 0;
				}
				break;
		}

		transform.position = new Vector3(_xPosition, _yPosition + SeagullWaterBob.waterBobHeight, _zPosition);
		transform.rotation = Quaternion.Euler(0, _baseYRotation, SeagullWaterBob.waterBobZRotation);
	}

	void Incoming ()
	{
		_xPosition = Mathf.MoveTowards(_xPosition, _fightingPosition.x, _incomingSpeed * Time.deltaTime);
		_yPosition = _fightingPosition.y;
		_zPosition = _fightingPosition.z;

		if (Mathf.Abs(_xPosition - _fightingPosition.x) < 0.05f) {
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
			}
		} else {

		}
	}

	IEnumerator PerformPeck ()
	{
		//FIND RANDOM TARGET
		List<GameObject> possibleTargets = new List<GameObject>();
		foreach (GameObject go in _breakableObjects) {
			IBreakable breakable = go.GetComponent<IBreakable>();
			if (breakable != null) {
				if (!breakable.GetIsBroken()) {
					possibleTargets.Add(go);
				}
			}
		}
		foreach (GameObject go in _playerCharacters) {
			IBreakable breakable = go.GetComponent<IBreakable>();
			if (breakable != null) {
				if (!breakable.GetIsBroken()) {
					possibleTargets.Add(go);
				}
			}
		}

		if (possibleTargets.Count <= 0) {
			yield break;
		}

		GameObject target = possibleTargets[UnityEngine.Random.Range(0, possibleTargets.Count)];

		//MOVE BEAK IN
		Vector3 oldBeakPosition;
		Vector3 newBeakPosition;
		AudioManager.PlayAudioClip(AudioManager.AudioClips.SeagullAttack);
		while (true) {
			oldBeakPosition = beakTip.position;
			newBeakPosition = Vector3.MoveTowards(beakTip.position, target.transform.position, _peckSpeed * Time.deltaTime);
			headTransform.position += newBeakPosition - oldBeakPosition;

			if (Vector3.Distance(beakTip.position, target.transform.position) < 0.05f) {
				break;
			}

			yield return null;
		}

		//BEAK HAS ARRIVED
		bool hasHitIce = false;
		bool hasHitPlayer = false;
		Collider[] hitColliders = Physics.OverlapBox(beakTip.position, _hitBoxHalfExtends);
		foreach (Collider col in hitColliders) {
			IBreakable breakable = col.GetComponent<IBreakable>();
			if (breakable != null) {
				breakable?.Break();
				if (col.CompareTag("Interactable")) {
					hasHitIce = true;
				} else {
					hasHitPlayer = true;
				}
				Debug.Log(col.name);
			}
			if (hasHitIce) {
				AudioManager.PlayAudioClip(AudioManager.AudioClips.BreakingIce);
			}
			if (hasHitPlayer) {
				AudioManager.PlayAudioClip(AudioManager.AudioClips.Land);
			}
		}

		//MOVE BEAK OUT
		while (true) {
			headTransform.localPosition = Vector3.MoveTowards(headTransform.localPosition, _headBaseLocalPosition, _peckSpeed * 0.006f * Time.deltaTime);

			if (Vector3.Distance(headTransform.localPosition, _headBaseLocalPosition) < 0.0005f) {
				break;
			}

			yield return null;
		}

		_isPecking = false;
	}

	private IEnumerator Dying ()
	{
		Debug.Log("Started dying");
		StopCoroutine(PerformPeck());
		Vector3 dyingStartPosition = transform.position;
		headTransform.localPosition = _headBaseLocalPosition;
		explosions.SetActive(true);
		float elapsed = 0.0f;

		float intensity = 0.5f;
		float fallDistance = 20;

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

		gameObject.SetActive(false);
		Debug.Log("Finished dying");
		TriggerRemovalEvent();
	}

	public void ReceiveDamage (int damage)
	{
		Debug.Log("Health before: " + _health);
		_health -= damage;
		Debug.Log("Health after: " + _health);
		if (_health <= 0) {
			_state = States.Dying;
			StopCoroutine(PerformPeck());
			StartCoroutine(Dying());
		}
	}

	protected virtual void TriggerRemovalEvent ()
	{
		IsRemoved?.Invoke(side);
	}
}
