using XInputDotNetPure;
using UnityEngine;
using UnityEditor;

namespace XInputDotNetExtended
{
	public static class XInputEX
	{
		private static GamePadState[] prevStates = new GamePadState[4], currentStates = new GamePadState[4];

		static XInputEX ()
		{
			GameObject updaterGO = new GameObject("XInputDotNetUpdater", typeof(XInputDotNetUpdater));
			updaterGO.hideFlags = HideFlags.HideInHierarchy;
			XInputDotNetUpdater.OnUpdate += Update;
		}

		private static void Update ()
		{
			for (int i = 0; i < 4; i++) {
				prevStates[i] = currentStates[i];
				currentStates[i] = GamePad.GetState((XInputDotNetPure.PlayerIndex) i);
			}
		}

		#region GetButton functions
		/// <summary>
		/// Returns true if the given button is pressed, false if it's not.
		/// </summary>
		/// <param name="playerIndex">Which controller would you like to check?</param>
		/// <param name="button">Which button should be checked?</param>
		public static bool GetButton (PlayerIndex playerIndex, Button button)
		{
			switch (button.value) {
				default:
					return false;
				case Button.Buttons.A:
					if (currentStates[playerIndex].Buttons.A == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.B:
					if (currentStates[playerIndex].Buttons.B == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.X:
					if (currentStates[playerIndex].Buttons.X == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.Y:
					if (currentStates[playerIndex].Buttons.Y == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.Start:
					if (currentStates[playerIndex].Buttons.Start == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.Back:
					if (currentStates[playerIndex].Buttons.Back == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.LeftBumper:
					if (currentStates[playerIndex].Buttons.LeftShoulder == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.RightBumper:
					if (currentStates[playerIndex].Buttons.RightShoulder == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.LeftStick:
					if (currentStates[playerIndex].Buttons.LeftStick == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.RightStick:
					if (currentStates[playerIndex].Buttons.RightStick == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.Guide:
					if (currentStates[playerIndex].Buttons.Guide == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.DPadUp:
					if (currentStates[playerIndex].DPad.Up == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.DPadRight:
					if (currentStates[playerIndex].DPad.Right == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.DPadDown:
					if (currentStates[playerIndex].DPad.Down == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.DPadLeft:
					if (currentStates[playerIndex].DPad.Left == ButtonState.Pressed)
						return true;
					else
						return false;

			}
		}
		/// <summary>
		/// Returns true if the given button is pressed and wasn't pressed the previous frame.
		/// </summary>
		/// <param name="playerIndex">Which controller would you like to check?</param>
		/// <param name="button">Which button should be checked?</param>
		public static bool GetButtonDown (PlayerIndex playerIndex, Button button)
		{
			switch (button.value) {
				default:
					return false;
				case Button.Buttons.A:
					if (prevStates[playerIndex].Buttons.A == ButtonState.Released && currentStates[playerIndex].Buttons.A == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.B:
					if (prevStates[playerIndex].Buttons.B == ButtonState.Released && currentStates[playerIndex].Buttons.B == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.X:
					if (prevStates[playerIndex].Buttons.X == ButtonState.Released && currentStates[playerIndex].Buttons.X == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.Y:
					if (prevStates[playerIndex].Buttons.Y == ButtonState.Released && currentStates[playerIndex].Buttons.Y == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.Start:
					if (prevStates[playerIndex].Buttons.Start == ButtonState.Released && currentStates[playerIndex].Buttons.Start == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.Back:
					if (prevStates[playerIndex].Buttons.Back == ButtonState.Released && currentStates[playerIndex].Buttons.Back == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.LeftBumper:
					if (prevStates[playerIndex].Buttons.LeftShoulder == ButtonState.Released && currentStates[playerIndex].Buttons.LeftShoulder == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.RightBumper:
					if (prevStates[playerIndex].Buttons.RightShoulder == ButtonState.Released && currentStates[playerIndex].Buttons.RightShoulder == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.LeftStick:
					if (prevStates[playerIndex].Buttons.LeftStick == ButtonState.Released && currentStates[playerIndex].Buttons.LeftStick == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.RightStick:
					if (prevStates[playerIndex].Buttons.RightStick == ButtonState.Released && currentStates[playerIndex].Buttons.RightStick == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.Guide:
					if (prevStates[playerIndex].Buttons.Guide == ButtonState.Released && currentStates[playerIndex].Buttons.Guide == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.DPadUp:
					if (prevStates[playerIndex].DPad.Up == ButtonState.Released && currentStates[playerIndex].DPad.Up == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.DPadRight:
					if (prevStates[playerIndex].DPad.Right == ButtonState.Released && currentStates[playerIndex].DPad.Right == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.DPadDown:
					if (prevStates[playerIndex].DPad.Down == ButtonState.Released && currentStates[playerIndex].DPad.Down == ButtonState.Pressed)
						return true;
					else
						return false;
				case Button.Buttons.DPadLeft:
					if (prevStates[playerIndex].DPad.Left == ButtonState.Released && currentStates[playerIndex].DPad.Left == ButtonState.Pressed)
						return true;
					else
						return false;

			}
		}
		/// <summary>
		/// Returns true if the given button is released and was pressed the previous frame.
		/// </summary>
		/// <param name="playerIndex">Which controller would you like to check?</param>
		/// <param name="button">Which button should be checked?</param>
		public static bool GetButtonUp (PlayerIndex playerIndex, Button button)
		{
			switch (button.value) {
				default:
					return false;
				case Button.Buttons.A:
					if (prevStates[playerIndex].Buttons.A == ButtonState.Pressed && currentStates[playerIndex].Buttons.A == ButtonState.Released)
						return true;
					else
						return false;
				case Button.Buttons.B:
					if (prevStates[playerIndex].Buttons.B == ButtonState.Pressed && currentStates[playerIndex].Buttons.B == ButtonState.Released)
						return true;
					else
						return false;
				case Button.Buttons.X:
					if (prevStates[playerIndex].Buttons.X == ButtonState.Pressed && currentStates[playerIndex].Buttons.X == ButtonState.Released)
						return true;
					else
						return false;
				case Button.Buttons.Y:
					if (prevStates[playerIndex].Buttons.Y == ButtonState.Pressed && currentStates[playerIndex].Buttons.Y == ButtonState.Released)
						return true;
					else
						return false;
				case Button.Buttons.Start:
					if (prevStates[playerIndex].Buttons.Start == ButtonState.Pressed && currentStates[playerIndex].Buttons.Start == ButtonState.Released)
						return true;
					else
						return false;
				case Button.Buttons.Back:
					if (prevStates[playerIndex].Buttons.Back == ButtonState.Pressed && currentStates[playerIndex].Buttons.Back == ButtonState.Released)
						return true;
					else
						return false;
				case Button.Buttons.LeftBumper:
					if (prevStates[playerIndex].Buttons.LeftShoulder == ButtonState.Pressed && currentStates[playerIndex].Buttons.LeftShoulder == ButtonState.Released)
						return true;
					else
						return false;
				case Button.Buttons.RightBumper:
					if (prevStates[playerIndex].Buttons.RightShoulder == ButtonState.Pressed && currentStates[playerIndex].Buttons.RightShoulder == ButtonState.Released)
						return true;
					else
						return false;
				case Button.Buttons.LeftStick:
					if (prevStates[playerIndex].Buttons.LeftStick == ButtonState.Pressed && currentStates[playerIndex].Buttons.LeftStick == ButtonState.Released)
						return true;
					else
						return false;
				case Button.Buttons.RightStick:
					if (prevStates[playerIndex].Buttons.RightStick == ButtonState.Pressed && currentStates[playerIndex].Buttons.RightStick == ButtonState.Released)
						return true;
					else
						return false;
				case Button.Buttons.Guide:
					if (prevStates[playerIndex].Buttons.Guide == ButtonState.Pressed && currentStates[playerIndex].Buttons.Guide == ButtonState.Released)
						return true;
					else
						return false;
				case Button.Buttons.DPadUp:
					if (prevStates[playerIndex].DPad.Up == ButtonState.Pressed && currentStates[playerIndex].DPad.Up == ButtonState.Released)
						return true;
					else
						return false;
				case Button.Buttons.DPadRight:
					if (prevStates[playerIndex].DPad.Right == ButtonState.Pressed && currentStates[playerIndex].DPad.Right == ButtonState.Released)
						return true;
					else
						return false;
				case Button.Buttons.DPadDown:
					if (prevStates[playerIndex].DPad.Down == ButtonState.Pressed && currentStates[playerIndex].DPad.Down == ButtonState.Released)
						return true;
					else
						return false;
				case Button.Buttons.DPadLeft:
					if (prevStates[playerIndex].DPad.Left == ButtonState.Pressed && currentStates[playerIndex].DPad.Left == ButtonState.Released)
						return true;
					else
						return false;

			}
		}
		#endregion

		#region GetDirection functions
		/// <summary>
		/// Returns true if the given directional input is held.
		/// </summary>
		/// <param name="playerIndex">Which controller would you like to check?</param>
		/// <param name="directionalInput">Which input would you like to check?</param>
		/// <param name="direction">Which direction would you like to check?</param>
		/// <param name="stickDeadzone">How much of a deadzone should be applied? (sticks only)</param>
		public static bool GetDirection (PlayerIndex playerIndex, DirectionalInput directionalInput, Direction direction, float stickDeadzone = .12f)
		{
			switch (directionalInput.value) {
				default:
					return false;
				case DirectionalInput.DirectionalInputs.LeftStick:
					switch (direction.value) {
						default:
							return false;
						case Direction.Directions.Up:
							if (currentStates[playerIndex].ThumbSticks.Left.Y >= stickDeadzone)
								return true;
							else
								return false;
						case Direction.Directions.Right:
							if (currentStates[playerIndex].ThumbSticks.Left.X >= stickDeadzone)
								return true;
							else
								return false;
						case Direction.Directions.Down:
							if (currentStates[playerIndex].ThumbSticks.Left.Y <= -stickDeadzone)
								return true;
							else
								return false;
						case Direction.Directions.Left:
							if (currentStates[playerIndex].ThumbSticks.Left.X <= -stickDeadzone)
								return true;
							else
								return false;
					}
				case DirectionalInput.DirectionalInputs.RightStick:
					switch (direction.value) {
						default:
							return false;
						case Direction.Directions.Up:
							if (currentStates[playerIndex].ThumbSticks.Right.Y >= stickDeadzone)
								return true;
							else
								return false;
						case Direction.Directions.Right:
							if (currentStates[playerIndex].ThumbSticks.Right.X >= stickDeadzone)
								return true;
							else
								return false;
						case Direction.Directions.Down:
							if (currentStates[playerIndex].ThumbSticks.Right.Y <= -stickDeadzone)
								return true;
							else
								return false;
						case Direction.Directions.Left:
							if (currentStates[playerIndex].ThumbSticks.Right.X <= -stickDeadzone)
								return true;
							else
								return false;
					}
				case DirectionalInput.DirectionalInputs.DPad:
					switch (direction.value) {
						default:
							return false;
						case Direction.Directions.Up:
							if (currentStates[playerIndex].DPad.Up == ButtonState.Pressed)
								return true;
							else
								return false;
						case Direction.Directions.Right:
							if (currentStates[playerIndex].DPad.Right == ButtonState.Pressed)
								return true;
							else
								return false;
						case Direction.Directions.Down:
							if (currentStates[playerIndex].DPad.Down == ButtonState.Pressed)
								return true;
							else
								return false;
						case Direction.Directions.Left:
							if (currentStates[playerIndex].DPad.Left == ButtonState.Pressed)
								return true;
							else
								return false;
					}
			}
		}
		/// <summary>
		/// Returns true if the given directional input is held and wasn't held the previous frame.
		/// </summary>
		/// <param name="playerIndex">Which controller would you like to check?</param>
		/// <param name="directionalInput">Which input would you like to check?</param>
		/// <param name="direction">Which direction would you like to check?</param>
		/// <param name="stickDeadzone">How much of a deadzone should be applied? (sticks only)</param>
		public static bool GetDirectionDown (PlayerIndex playerIndex, DirectionalInput directionalInput, Direction direction, float stickDeadzone = .12f)
		{
			switch (directionalInput.value) {
				default:
					return false;
				case DirectionalInput.DirectionalInputs.LeftStick:
					switch (direction.value) {
						default:
							return false;
						case Direction.Directions.Up:
							if (prevStates[playerIndex].ThumbSticks.Left.Y < stickDeadzone && currentStates[playerIndex].ThumbSticks.Left.Y >= stickDeadzone)
								return true;
							else
								return false;
						case Direction.Directions.Right:
							if (prevStates[playerIndex].ThumbSticks.Left.X < stickDeadzone && currentStates[playerIndex].ThumbSticks.Left.X >= stickDeadzone)
								return true;
							else
								return false;
						case Direction.Directions.Down:
							if (prevStates[playerIndex].ThumbSticks.Left.Y > -stickDeadzone && currentStates[playerIndex].ThumbSticks.Left.Y <= -stickDeadzone)
								return true;
							else
								return false;
						case Direction.Directions.Left:
							if (prevStates[playerIndex].ThumbSticks.Left.X > -stickDeadzone && currentStates[playerIndex].ThumbSticks.Left.X <= -stickDeadzone)
								return true;
							else
								return false;
					}
				case DirectionalInput.DirectionalInputs.RightStick:
					switch (direction.value) {
						default:
							return false;
						case Direction.Directions.Up:
							if (prevStates[playerIndex].ThumbSticks.Right.Y < stickDeadzone && currentStates[playerIndex].ThumbSticks.Right.Y >= stickDeadzone)
								return true;
							else
								return false;
						case Direction.Directions.Right:
							if (prevStates[playerIndex].ThumbSticks.Right.X < stickDeadzone && currentStates[playerIndex].ThumbSticks.Right.X >= stickDeadzone)
								return true;
							else
								return false;
						case Direction.Directions.Down:
							if (prevStates[playerIndex].ThumbSticks.Right.Y > -stickDeadzone && currentStates[playerIndex].ThumbSticks.Right.Y <= -stickDeadzone)
								return true;
							else
								return false;
						case Direction.Directions.Left:
							if (prevStates[playerIndex].ThumbSticks.Right.X > -stickDeadzone && currentStates[playerIndex].ThumbSticks.Right.X <= -stickDeadzone)
								return true;
							else
								return false;
					}
				case DirectionalInput.DirectionalInputs.DPad:
					switch (direction.value) {
						default:
							return false;
						case Direction.Directions.Up:
							if (prevStates[playerIndex].DPad.Up == ButtonState.Released && currentStates[playerIndex].DPad.Up == ButtonState.Pressed)
								return true;
							else
								return false;
						case Direction.Directions.Right:
							if (prevStates[playerIndex].DPad.Right == ButtonState.Released && currentStates[playerIndex].DPad.Right == ButtonState.Pressed)
								return true;
							else
								return false;
						case Direction.Directions.Down:
							if (prevStates[playerIndex].DPad.Down == ButtonState.Released && currentStates[playerIndex].DPad.Down == ButtonState.Pressed)
								return true;
							else
								return false;
						case Direction.Directions.Left:
							if (prevStates[playerIndex].DPad.Left == ButtonState.Released && currentStates[playerIndex].DPad.Left == ButtonState.Pressed)
								return true;
							else
								return false;
					}
			}
		}
		/// <summary>
		/// Returns true if the given directional input is released and was held the previous frame.
		/// </summary>
		/// <param name="playerIndex">Which controller would you like to check?</param>
		/// <param name="directionalInput">Which input would you like to check?</param>
		/// <param name="direction">Which direction would you like to check?</param>
		/// <param name="stickDeadzone">How much of a deadzone should be applied? (sticks only)</param>
		public static bool GetDirectionUp (PlayerIndex playerIndex, DirectionalInput directionalInput, Direction direction, float stickDeadzone = .12f)
		{
			switch (directionalInput.value) {
				default:
					return false;
				case DirectionalInput.DirectionalInputs.LeftStick:
					switch (direction.value) {
						default:
							return false;
						case Direction.Directions.Up:
							if (prevStates[playerIndex].ThumbSticks.Left.Y >= stickDeadzone && currentStates[playerIndex].ThumbSticks.Left.Y < stickDeadzone)
								return true;
							else
								return false;
						case Direction.Directions.Right:
							if (prevStates[playerIndex].ThumbSticks.Left.X >= stickDeadzone && currentStates[playerIndex].ThumbSticks.Left.X < stickDeadzone)
								return true;
							else
								return false;
						case Direction.Directions.Down:
							if (prevStates[playerIndex].ThumbSticks.Left.Y <= -stickDeadzone && currentStates[playerIndex].ThumbSticks.Left.Y > -stickDeadzone)
								return true;
							else
								return false;
						case Direction.Directions.Left:
							if (prevStates[playerIndex].ThumbSticks.Left.X <= -stickDeadzone && currentStates[playerIndex].ThumbSticks.Left.X > -stickDeadzone)
								return true;
							else
								return false;
					}
				case DirectionalInput.DirectionalInputs.RightStick:
					switch (direction.value) {
						default:
							return false;
						case Direction.Directions.Up:
							if (prevStates[playerIndex].ThumbSticks.Right.Y >= stickDeadzone && currentStates[playerIndex].ThumbSticks.Right.Y < stickDeadzone)
								return true;
							else
								return false;
						case Direction.Directions.Right:
							if (prevStates[playerIndex].ThumbSticks.Right.X >= stickDeadzone && currentStates[playerIndex].ThumbSticks.Right.X < stickDeadzone)
								return true;
							else
								return false;
						case Direction.Directions.Down:
							if (prevStates[playerIndex].ThumbSticks.Right.Y <= -stickDeadzone && currentStates[playerIndex].ThumbSticks.Right.Y > -stickDeadzone)
								return true;
							else
								return false;
						case Direction.Directions.Left:
							if (prevStates[playerIndex].ThumbSticks.Right.X <= -stickDeadzone && currentStates[playerIndex].ThumbSticks.Right.X > -stickDeadzone)
								return true;
							else
								return false;
					}
				case DirectionalInput.DirectionalInputs.DPad:
					switch (direction.value) {
						default:
							return false;
						case Direction.Directions.Up:
							if (prevStates[playerIndex].DPad.Up == ButtonState.Pressed && currentStates[playerIndex].DPad.Up == ButtonState.Released)
								return true;
							else
								return false;
						case Direction.Directions.Right:
							if (prevStates[playerIndex].DPad.Right == ButtonState.Pressed && currentStates[playerIndex].DPad.Right == ButtonState.Released)
								return true;
							else
								return false;
						case Direction.Directions.Down:
							if (prevStates[playerIndex].DPad.Down == ButtonState.Pressed && currentStates[playerIndex].DPad.Down == ButtonState.Released)
								return true;
							else
								return false;
						case Direction.Directions.Left:
							if (prevStates[playerIndex].DPad.Left == ButtonState.Pressed && currentStates[playerIndex].DPad.Left == ButtonState.Released)
								return true;
							else
								return false;
					}
			}
		}
		#endregion

		#region GetTrigger functions
		/// <summary>
		/// Returns true if the given trigger is held.
		/// </summary>
		/// <param name="playerIndex">Which controller would you like to check?</param>
		/// <param name="trigger">Which trigger would you like to check?</param>
		/// <param name="deadzone">How much of a deadzone should be applied?</param>
		public static bool GetTrigger (PlayerIndex playerIndex, Trigger trigger, float deadzone = .08f)
		{
			switch (trigger.value) {
				default:
					return false;
				case Trigger.Triggers.Left:
					if (currentStates[playerIndex].Triggers.Left >= deadzone)
						return true;
					else
						return false;
				case Trigger.Triggers.Right:
					if (currentStates[playerIndex].Triggers.Right >= deadzone)
						return true;
					else
						return false;
			}
		}
		/// <summary>
		/// Returns true if the given trigger is held and wasn't held the previous frame.
		/// </summary>
		/// <param name="playerIndex">Which controller would you like to check?</param>
		/// <param name="trigger">Which trigger would you like to check?</param>
		/// <param name="deadzone">How much of a deadzone should be applied?</param>
		public static bool GetTriggerDown (PlayerIndex playerIndex, Trigger trigger, float deadzone = .08f)
		{
			switch (trigger.value) {
				default:
					return false;
				case Trigger.Triggers.Left:
					if (prevStates[playerIndex].Triggers.Left < deadzone && currentStates[playerIndex].Triggers.Left >= deadzone)
						return true;
					else
						return false;
				case Trigger.Triggers.Right:
					if (prevStates[playerIndex].Triggers.Right < deadzone && currentStates[playerIndex].Triggers.Right >= deadzone)
						return true;
					else
						return false;
			}
		}
		/// <summary>
		/// Returns true if the given trigger is released and was held the previous frame.
		/// </summary>
		/// <param name="playerIndex">Which controller would you like to check?</param>
		/// <param name="trigger">Which trigger would you like to check?</param>
		/// <param name="deadzone">How much of a deadzone should be applied?</param>
		public static bool GetTriggerUp (PlayerIndex playerIndex, Trigger trigger, float deadzone = .08f)
		{
			switch (trigger.value) {
				default:
					return false;
				case Trigger.Triggers.Left:
					if (prevStates[playerIndex].Triggers.Left >= deadzone && currentStates[playerIndex].Triggers.Left < deadzone)
						return true;
					else
						return false;
				case Trigger.Triggers.Right:
					if (prevStates[playerIndex].Triggers.Right >= deadzone && currentStates[playerIndex].Triggers.Right < deadzone)
						return true;
					else
						return false;
			}
		}
		#endregion

		#region GetAxis functions
		/// <summary>
		/// Returns a value from -1.0 through 1.0 for the given axis.
		/// </summary>
		/// <param name="playerIndex">Which controller would you like to check?</param>
		/// <param name="axis">Which axis would you like to check?</param>
		/// <returns></returns>
		public static float GetAxis (PlayerIndex playerIndex, Axis axis)
		{
			float result = 0;

			switch (axis.value) {
				default:
					return 0;
				case Axis.Axes.LeftStickHorizontal:
					return currentStates[playerIndex].ThumbSticks.Left.X;
				case Axis.Axes.LeftStickVertical:
					return currentStates[playerIndex].ThumbSticks.Left.Y;
				case Axis.Axes.RightStickHorizontal:
					return currentStates[playerIndex].ThumbSticks.Right.X;
				case Axis.Axes.RightStickVertical:
					return currentStates[playerIndex].ThumbSticks.Right.Y;
				case Axis.Axes.DPadHorizontal:
					if (currentStates[playerIndex].DPad.Left == ButtonState.Pressed)
						result += -1;
					if (currentStates[playerIndex].DPad.Right == ButtonState.Pressed)
						result += 1;
					return result;
				case Axis.Axes.DPadVertical:
					if (currentStates[playerIndex].DPad.Down == ButtonState.Pressed)
						result += 1;
					if (currentStates[playerIndex].DPad.Up == ButtonState.Pressed)
						result += 1;
					return result;
				case Axis.Axes.Triggers:
					result += currentStates[playerIndex].Triggers.Right;
					result -= currentStates[playerIndex].Triggers.Left;
					return result;
			}
		}
		/// <summary>
		/// Returns the value of the given axis snapped to -1, 0 or 1.
		/// </summary>
		/// <param name="playerIndex">Which controller would you like to check?</param>
		/// <param name="axis">Which axis would you like to check?</param>
		/// <returns></returns>
		public static float GetAxisRaw (PlayerIndex playerIndex, Axis axis, float deadzone = .08f)
		{
			float axisValue = GetAxis(playerIndex, axis);

			if (axisValue > deadzone) {
				return 1;
			} else if (axisValue < -deadzone) {
				return -1;
			} else {
				return 0;
			}
		}
		#endregion

		#region GetAnyButton functions
		/// <summary>
		/// Returns true if A, B, X, Y, Start, Back, Bumpers, Stick presses or the Guide button is pressed.
		/// </summary>
		/// <param name="playerIndex">Which controller would you like to check?</param>
		public static bool GetAnyButton (PlayerIndex playerIndex)
		{
			if (currentStates[playerIndex].Buttons.A == ButtonState.Pressed)
				return true;
			if (currentStates[playerIndex].Buttons.B == ButtonState.Pressed)
				return true;
			if (currentStates[playerIndex].Buttons.X == ButtonState.Pressed)
				return true;
			if (currentStates[playerIndex].Buttons.Y == ButtonState.Pressed)
				return true;
			if (currentStates[playerIndex].Buttons.Start == ButtonState.Pressed)
				return true;
			if (currentStates[playerIndex].Buttons.Back == ButtonState.Pressed)
				return true;
			if (currentStates[playerIndex].Buttons.RightShoulder == ButtonState.Pressed)
				return true;
			if (currentStates[playerIndex].Buttons.LeftShoulder == ButtonState.Pressed)
				return true;
			if (currentStates[playerIndex].Buttons.LeftStick == ButtonState.Pressed)
				return true;
			if (currentStates[playerIndex].Buttons.RightStick == ButtonState.Pressed)
				return true;
			if (currentStates[playerIndex].Buttons.Guide == ButtonState.Pressed)
				return true;

			return false;
		}
		/// <summary>
		/// Returns true if A, B, X, Y, Start, Back, Bumpers, Stick presses or the Guide button is pressed while non of them were pressed the previous frame.
		/// </summary>
		/// <param name="playerIndex">Which controller would you like to check?</param>
		public static bool GetAnyButtonDown (PlayerIndex playerIndex)
		{
			if (prevStates[playerIndex].Buttons.A == ButtonState.Released && currentStates[playerIndex].Buttons.A == ButtonState.Pressed)
				return true;
			if (prevStates[playerIndex].Buttons.B == ButtonState.Released && currentStates[playerIndex].Buttons.B == ButtonState.Pressed)
				return true;
			if (prevStates[playerIndex].Buttons.X == ButtonState.Released && currentStates[playerIndex].Buttons.X == ButtonState.Pressed)
				return true;
			if (prevStates[playerIndex].Buttons.Y == ButtonState.Released && currentStates[playerIndex].Buttons.Y == ButtonState.Pressed)
				return true;
			if (prevStates[playerIndex].Buttons.Start == ButtonState.Released && currentStates[playerIndex].Buttons.Start == ButtonState.Pressed)
				return true;
			if (prevStates[playerIndex].Buttons.Back == ButtonState.Released && currentStates[playerIndex].Buttons.Back == ButtonState.Pressed)
				return true;
			if (prevStates[playerIndex].Buttons.RightShoulder == ButtonState.Released && currentStates[playerIndex].Buttons.RightShoulder == ButtonState.Pressed)
				return true;
			if (prevStates[playerIndex].Buttons.LeftShoulder == ButtonState.Released && currentStates[playerIndex].Buttons.LeftShoulder == ButtonState.Pressed)
				return true;
			if (prevStates[playerIndex].Buttons.LeftStick == ButtonState.Released && currentStates[playerIndex].Buttons.LeftStick == ButtonState.Pressed)
				return true;
			if (prevStates[playerIndex].Buttons.RightStick == ButtonState.Released && currentStates[playerIndex].Buttons.RightStick == ButtonState.Pressed)
				return true;
			if (prevStates[playerIndex].Buttons.Guide == ButtonState.Released && currentStates[playerIndex].Buttons.Guide == ButtonState.Pressed)
				return true;

			return false;
		}
		/// <summary>
		/// Returns true if A, B, X, Y, Start, Back, Bumpers, Stick presses or the Guide button are released while any of them were pressed the previous frame.
		/// </summary>
		/// <param name="playerIndex">Which controller would you like to check?</param>
		public static bool GetAnyButtonUp (PlayerIndex playerIndex)
		{
			if (prevStates[playerIndex].Buttons.A == ButtonState.Pressed && currentStates[playerIndex].Buttons.A == ButtonState.Released)
				return true;
			if (prevStates[playerIndex].Buttons.B == ButtonState.Pressed && currentStates[playerIndex].Buttons.B == ButtonState.Released)
				return true;
			if (prevStates[playerIndex].Buttons.X == ButtonState.Pressed && currentStates[playerIndex].Buttons.X == ButtonState.Released)
				return true;
			if (prevStates[playerIndex].Buttons.Y == ButtonState.Pressed && currentStates[playerIndex].Buttons.Y == ButtonState.Released)
				return true;
			if (prevStates[playerIndex].Buttons.Start == ButtonState.Pressed && currentStates[playerIndex].Buttons.Start == ButtonState.Released)
				return true;
			if (prevStates[playerIndex].Buttons.Back == ButtonState.Pressed && currentStates[playerIndex].Buttons.Back == ButtonState.Released)
				return true;
			if (prevStates[playerIndex].Buttons.RightShoulder == ButtonState.Pressed && currentStates[playerIndex].Buttons.RightShoulder == ButtonState.Released)
				return true;
			if (prevStates[playerIndex].Buttons.LeftShoulder == ButtonState.Pressed && currentStates[playerIndex].Buttons.LeftShoulder == ButtonState.Released)
				return true;
			if (prevStates[playerIndex].Buttons.LeftStick == ButtonState.Pressed && currentStates[playerIndex].Buttons.LeftStick == ButtonState.Released)
				return true;
			if (prevStates[playerIndex].Buttons.RightStick == ButtonState.Pressed && currentStates[playerIndex].Buttons.RightStick == ButtonState.Released)
				return true;
			if (prevStates[playerIndex].Buttons.Guide == ButtonState.Pressed && currentStates[playerIndex].Buttons.Guide == ButtonState.Released)
				return true;

			return false;
		}
		#endregion

		#region GetAnyInput functions
		/// <summary>
		/// Returns true if any button, trigger or directional input is pressed or held in any direction.
		/// </summary>
		/// <param name="playerIndex">Which controller would you like to check?</param>
		/// <param name="stickDeadzone">How much of a deadzone should be applied? (sticks only)</param>
		public static bool GetAnyInput (PlayerIndex playerIndex, float stickDeadzone = .12f)
		{
			if (GetAnyButtonDown(playerIndex))
				return true;
			if (Mathf.Abs(GetAxis(playerIndex, Axis.LeftStickHorizontal)) >= stickDeadzone)
				return true;
			if (Mathf.Abs(GetAxis(playerIndex, Axis.LeftStickVertical)) >= stickDeadzone)
				return true;
			if (Mathf.Abs(GetAxis(playerIndex, Axis.RightStickHorizontal)) >= stickDeadzone)
				return true;
			if (Mathf.Abs(GetAxis(playerIndex, Axis.RightStickVertical)) >= stickDeadzone)
				return true;
			if (GetAxis(playerIndex, Axis.DPadHorizontal) != 0)
				return true;
			if (GetAxis(playerIndex, Axis.DPadVertical) != 0)
				return true;
			if (GetAxis(playerIndex, Axis.Triggers) != 0) {
				return true;
			}

			return false;
		}
		/// <summary>
		/// Returns true if any button, trigger or directional input is pressed or held in any direction while none were pressed or held the previous frame.
		/// </summary>
		/// <param name="playerIndex">Which controller would you like to check?</param>
		/// <param name="stickDeadzone">How much of a deadzone should be applied? (sticks only)</param>
		public static bool GetAnyInputDown (PlayerIndex playerIndex, float stickDeadzone = .12f)
		{
			if (GetAnyButtonDown(playerIndex))
				return true;
			if (GetDirectionDown(playerIndex, DirectionalInput.LeftStick, Direction.Up))
				return true;
			if (GetDirectionDown(playerIndex, DirectionalInput.LeftStick, Direction.Right))
				return true;
			if (GetDirectionDown(playerIndex, DirectionalInput.LeftStick, Direction.Down))
				return true;
			if (GetDirectionDown(playerIndex, DirectionalInput.LeftStick, Direction.Left))
				return true;
			if (GetDirectionDown(playerIndex, DirectionalInput.RightStick, Direction.Up))
				return true;
			if (GetDirectionDown(playerIndex, DirectionalInput.RightStick, Direction.Right))
				return true;
			if (GetDirectionDown(playerIndex, DirectionalInput.RightStick, Direction.Down))
				return true;
			if (GetDirectionDown(playerIndex, DirectionalInput.RightStick, Direction.Left))
				return true;
			if (GetDirectionDown(playerIndex, DirectionalInput.DPad, Direction.Up))
				return true;
			if (GetDirectionDown(playerIndex, DirectionalInput.DPad, Direction.Right))
				return true;
			if (GetDirectionDown(playerIndex, DirectionalInput.DPad, Direction.Down))
				return true;
			if (GetDirectionDown(playerIndex, DirectionalInput.DPad, Direction.Left))
				return true;
			if (GetTriggerDown(playerIndex, Trigger.Left))
				return true;
			if (GetTriggerDown(playerIndex, Trigger.Right))
				return true;

			return false;
		}
		/// <summary>
		/// Returns true if all button, trigger or directional input are released while any were pressed or held the previous frame.
		/// </summary>
		/// <param name="playerIndex">Which controller would you like to check?</param>
		/// <param name="stickDeadzone">How much of a deadzone should be applied? (sticks only)</param>
		public static bool GetAnyInputUp (PlayerIndex playerIndex, float stickDeadzone = .12f)
		{
			if (GetAnyButtonUp(playerIndex))
				return true;
			if (GetDirectionUp(playerIndex, DirectionalInput.LeftStick, Direction.Up, stickDeadzone))
				return true;
			if (GetDirectionUp(playerIndex, DirectionalInput.LeftStick, Direction.Right, stickDeadzone))
				return true;
			if (GetDirectionUp(playerIndex, DirectionalInput.LeftStick, Direction.Down, stickDeadzone))
				return true;
			if (GetDirectionUp(playerIndex, DirectionalInput.LeftStick, Direction.Left, stickDeadzone))
				return true;
			if (GetDirectionUp(playerIndex, DirectionalInput.RightStick, Direction.Up, stickDeadzone))
				return true;
			if (GetDirectionUp(playerIndex, DirectionalInput.RightStick, Direction.Right, stickDeadzone))
				return true;
			if (GetDirectionUp(playerIndex, DirectionalInput.RightStick, Direction.Down, stickDeadzone))
				return true;
			if (GetDirectionUp(playerIndex, DirectionalInput.RightStick, Direction.Left, stickDeadzone))
				return true;
			if (GetDirectionUp(playerIndex, DirectionalInput.DPad, Direction.Up))
				return true;
			if (GetDirectionUp(playerIndex, DirectionalInput.DPad, Direction.Right))
				return true;
			if (GetDirectionUp(playerIndex, DirectionalInput.DPad, Direction.Down))
				return true;
			if (GetDirectionUp(playerIndex, DirectionalInput.DPad, Direction.Left))
				return true;
			if (GetTriggerUp(playerIndex, Trigger.Left))
				return true;
			if (GetTriggerUp(playerIndex, Trigger.Right))
				return true;

			return false;
		}
		#endregion
	}

	#region Argument Classes
	[System.Serializable]
	public class PlayerIndex
	{
		[SerializeField]
		public int index;

		public PlayerIndex (int index)
		{
			if (index >= 0 && index <= 3) {
				this.index = index;
			} else {
				throw new System.ArgumentOutOfRangeException("index", index, "The PlayerIndex must be a value from 0 through 3.");
			}
		}

		#region Shorthand Properties
		public static PlayerIndex One
		{
			get {
				return 0;
			}
		}
		public static PlayerIndex Two
		{
			get {
				return 1;
			}
		}
		public static PlayerIndex Three
		{
			get {
				return 2;
			}
		}
		public static PlayerIndex Four
		{
			get {
				return 3;
			}
		}
		#endregion

		#region Operators
		public static implicit operator PlayerIndex (int value)
		{
			return new PlayerIndex(value);
		}
		public static implicit operator int (PlayerIndex rhs)
		{
			return rhs.index;
		}
		public static implicit operator XInputDotNetPure.PlayerIndex (PlayerIndex rhs)
		{
			return (XInputDotNetPure.PlayerIndex) rhs.index;
		}
		#endregion
	}

	public class Button
	{
		public enum Buttons { A, B, X, Y, Start, Back, LeftBumper, RightBumper, LeftStick, RightStick, Guide, DPadUp, DPadRight, DPadDown, DPadLeft };
		public Buttons value;

		public Button (Buttons button)
		{
			value = button;
		}

		#region Shorthand Properties
		public static Button A
		{
			get {
				return new Button(Buttons.A);
			}
		}
		public static Button B
		{
			get {
				return new Button(Buttons.B);
			}
		}
		public static Button X
		{
			get {
				return new Button(Buttons.X);
			}
		}
		public static Button Y
		{
			get {
				return new Button(Buttons.Y);
			}
		}
		public static Button Start
		{
			get {
				return new Button(Buttons.Start);
			}
		}
		public static Button Back
		{
			get {
				return new Button(Buttons.Back);
			}
		}
		public static Button LeftBumper
		{
			get {
				return new Button(Buttons.LeftBumper);
			}
		}
		public static Button RightBumper
		{
			get {
				return new Button(Buttons.RightBumper);
			}
		}
		public static Button LeftStick
		{
			get {
				return new Button(Buttons.LeftStick);
			}
		}
		public static Button RightStick
		{
			get {
				return new Button(Buttons.RightStick);
			}
		}
		public static Button Guide
		{
			get {
				return new Button(Buttons.Guide);
			}
		}
		public static Button DPadUp
		{
			get {
				return new Button(Buttons.DPadUp);
			}
		}
		public static Button DPadRight
		{
			get {
				return new Button(Buttons.DPadRight);
			}
		}
		public static Button DPadDown
		{
			get {
				return new Button(Buttons.DPadDown);
			}
		}
		public static Button DPadLeft
		{
			get {
				return new Button(Buttons.DPadLeft);
			}
		}
		#endregion
	}

	public class DirectionalInput
	{
		public enum DirectionalInputs { LeftStick, RightStick, DPad };
		public DirectionalInputs value;

		public DirectionalInput (DirectionalInputs directionalInput)
		{
			value = directionalInput;
		}

		#region Shorthand Properties
		public static DirectionalInput LeftStick
		{
			get {
				return new DirectionalInput(DirectionalInputs.LeftStick);
			}
		}
		public static DirectionalInput RightStick
		{
			get {
				return new DirectionalInput(DirectionalInputs.RightStick);
			}
		}
		public static DirectionalInput DPad
		{
			get {
				return new DirectionalInput(DirectionalInputs.DPad);
			}
		}

		#endregion
	}

	public class Trigger
	{
		public enum Triggers { Left, Right };
		public Triggers value;

		public Trigger (Triggers trigger)
		{
			value = trigger;
		}

		#region Shorthand Properties
		public static Trigger Left
		{
			get {
				return new Trigger(Triggers.Left);
			}
		}
		public static Trigger Right
		{
			get {
				return new Trigger(Triggers.Right);
			}
		}
		#endregion
	}

	public class Direction
	{
		public enum Directions { Up, Right, Down, Left };
		public Directions value;

		public Direction (Directions direction)
		{
			value = direction;
		}

		#region Shorthand Properties
		public static Direction Up
		{
			get {
				return new Direction(Directions.Up);
			}
		}
		public static Direction Right
		{
			get {
				return new Direction(Directions.Right);
			}
		}
		public static Direction Down
		{
			get {
				return new Direction(Directions.Down);
			}
		}
		public static Direction Left
		{
			get {
				return new Direction(Directions.Left);
			}
		}
		#endregion
	}

	public class Axis
	{
		public enum Axes { LeftStickHorizontal, LeftStickVertical, RightStickHorizontal, RightStickVertical, DPadHorizontal, DPadVertical, Triggers };
		public Axes value;

		public Axis (Axes axis)
		{
			value = axis;
		}

		#region Shorthand Properties
		public static Axis LeftStickHorizontal
		{
			get {
				return new Axis(Axes.LeftStickHorizontal);
			}
		}
		public static Axis LeftStickVertical
		{
			get {
				return new Axis(Axes.LeftStickVertical);
			}
		}
		public static Axis RightStickHorizontal
		{
			get {
				return new Axis(Axes.RightStickHorizontal);
			}
		}
		public static Axis RightStickVertical
		{
			get {
				return new Axis(Axes.RightStickVertical);
			}
		}
		public static Axis DPadHorizontal
		{
			get {
				return new Axis(Axes.DPadHorizontal);
			}
		}
		public static Axis DPadVertical
		{
			get {
				return new Axis(Axes.DPadVertical);
			}
		}
		public static Axis Triggers
		{
			get {
				return new Axis(Axes.Triggers);
			}
		}
		#endregion
	}
	#endregion
}