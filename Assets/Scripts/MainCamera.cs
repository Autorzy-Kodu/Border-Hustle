using UnityEngine;
using UnityEngine.InputSystem;

public class MainCamera : Singleton<MainCamera>
{
	private Vector2 direction;

	[SerializeField] private Transform cameraPivot;
	[SerializeField] private Camera cameraComponent;
	[SerializeField] private float cameraSensitivity;
	[SerializeField] private float leftLimit;
	[SerializeField] private float upLimit;
	[SerializeField] private float rightLimit;
	[SerializeField] private float downLimit;

	private void Update()
	{
		Vector3 nextCameraPosition = cameraPivot.transform.position + new Vector3(direction.x, 0f, direction.y) * cameraSensitivity;

		if (nextCameraPosition.x > leftLimit && nextCameraPosition.x < rightLimit && nextCameraPosition.z < upLimit && nextCameraPosition.z > downLimit) 
			cameraPivot.transform.position = nextCameraPosition;
	}

	public Camera GetCamera => cameraComponent;

	public void MoveCamera(InputAction.CallbackContext context)
	{
		if (context.canceled)
			direction = Vector2.zero;
		
		if (!context.performed)
			return;

		direction = context.ReadValue<Vector2>();
	}

	public void ZoomCamera(InputAction.CallbackContext context)
	{
		// TODO?
	}
}