using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
	[SerializeField] Vector2 mousePosition;
	public bool allowSceneMouseClicks = true;

	public void MousePosition (InputAction.CallbackContext context) {
		mousePosition = context.ReadValue<Vector2>();
	}
	
	public void MouseClick(InputAction.CallbackContext context)
	{
		if (!allowSceneMouseClicks)
			return;
		
		if (!context.performed)
			return;
		
		if (Physics.Raycast(MainCamera.Instance.GetCamera.ScreenPointToRay(mousePosition), out RaycastHit rHit, 500f))
			rHit.collider.GetComponent<ISelectable>()?.Select();
        if (Physics.Raycast(MainCamera.Instance.GetCamera.ScreenPointToRay(mousePosition), out RaycastHit rHit2, 500f))
            rHit2.collider.GetComponent<IClickable>()?.Click();
    }
	public void RightMouseClick(InputAction.CallbackContext context)
	{
        if (!allowSceneMouseClicks)
            return;

        if (!context.performed)
            return;

        if (Physics.Raycast(MainCamera.Instance.GetCamera.ScreenPointToRay(mousePosition), out RaycastHit rHit2, 500f))
            rHit2.collider.GetComponent<IClickable>()?.RightClick();
    }
    }
