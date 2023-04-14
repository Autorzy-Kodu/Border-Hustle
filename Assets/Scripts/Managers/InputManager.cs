using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
	
	[SerializeField] Vector2 mousePosition;

	public void MousePosition (InputAction.CallbackContext context) {
		mousePosition = context.ReadValue<Vector2>();
		Debug.DrawRay(MainCamera.Instance.GetCamera.ScreenPointToRay(mousePosition).origin,
			MainCamera.Instance.GetCamera.ScreenPointToRay(mousePosition).direction * 100f, Color.blue, 1f);
	}
	
	public void MouseClick(InputAction.CallbackContext context)
	{
		if (!context.performed)
			return;
		
		// FIXME ScreenToWorldPoint nie działa, raycast jest zawsze ze środka kamery
		if (Physics.Raycast(MainCamera.Instance.GetCamera.ScreenPointToRay(mousePosition), out RaycastHit rHit, 500f))
		{
			Debug.DrawRay(MainCamera.Instance.GetCamera.ScreenPointToRay(mousePosition).origin,
				MainCamera.Instance.GetCamera.ScreenPointToRay(mousePosition).direction * 100f, Color.red, 1f);
			rHit.collider.GetComponent<ISelectable>()?.Select();
		}
	}
}
