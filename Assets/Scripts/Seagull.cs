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

	//INCOMING
	float _incomingSpeed = 1.3f;

	private void Awake ()
	{
		Init(Vector3.left * 30, Vector3.left * 11, false);
	}

	public void Init (Vector3 spawnPosition, Vector3 fightingPosition, bool isLookingLeft)
	{
		_state = States.Incoming;
		_fightingPosition = fightingPosition;
		transform.localScale = new Vector3(isLookingLeft ? -1 : 1 , 1, 1);
		_xPosition = spawnPosition.x;
		_yPosition = spawnPosition.y;
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
				Dying();
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

	void Dying ()
	{

	}
}
