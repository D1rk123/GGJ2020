using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetExtended;

public class PlayerInputs : MonoBehaviour
{
	public float MovementInput { get; private set; } = 0;
	public bool JumpInputDown { get; private set; } = false;
	public bool InteractInputDown { get; private set; } = false;

	[Header("Keyboard Settings")]
	[SerializeField] bool _allowKeyboardInputs = false;
	[SerializeField] KeyCode _moveLeftKey = KeyCode.A;
	[SerializeField] KeyCode _moveRightKey = KeyCode.D;
	[SerializeField] KeyCode _jumpKey = KeyCode.W;
	[SerializeField] KeyCode _interactKey = KeyCode.F;

	[Header("Controller Settings")]
	[SerializeField] PlayerIndex _playerIndex = PlayerIndex.One;
	[SerializeField] Axis _movementAxis = Axis.LeftStickHorizontal;
	[SerializeField] Button _jumpButton = Button.A;
	[SerializeField] Button _interactButton = Button.B;

	private void Update ()
	{
		//Movement Value
		float keyboardMovementValue = 0;
		if (_allowKeyboardInputs) {
			keyboardMovementValue = (Input.GetKey(_moveLeftKey) ? -1 : 0) + (Input.GetKey(_moveRightKey) ? 1 : 0);
		}
		MovementInput = Mathf.Clamp(keyboardMovementValue + XInputEX.GetAxis(_playerIndex, _movementAxis), -1, 1);

		//Buttons
		JumpInputDown = false;
		InteractInputDown = false;
		if (_allowKeyboardInputs) {
			JumpInputDown = Input.GetKeyDown(_jumpKey);
			InteractInputDown = Input.GetKeyDown(_interactKey);
		}
		if (XInputEX.GetButtonDown(_playerIndex, _jumpButton))
			JumpInputDown = true;
		if (XInputEX.GetButtonDown(_playerIndex, _interactButton))
			InteractInputDown = true;
	}
}
