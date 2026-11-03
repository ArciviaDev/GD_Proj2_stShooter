using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;
		public bool lookFromTouch;

        [Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				lookFromTouch = false;
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}
		
		
		private bool gameEnded = false;

		// Called when the player dies or wins
		public void UnlockCursor()
		{
			gameEnded = true;

			cursorLocked = false;
			cursorInputForLook = false;

			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;

			look = Vector2.zero;
			move = Vector2.zero;
		}

		// Called when restarting the game
		public void LockCursor()
		{
			gameEnded = false;

			cursorLocked = true;
			cursorInputForLook = true;

			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		// Prevents cursor locking after death/victory
		private void OnApplicationFocus(bool hasFocus)
		{
			if (hasFocus && !gameEnded)
			{
				SetCursorState(cursorLocked);
			}
		}

		private void SetCursorState(bool newState)
		{
			if (gameEnded)
				return;

			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
			Cursor.visible = !newState;
		}
	}
}