using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{

	public bool IsActive { get; private set; }

	public void Show()
	{
		gameObject.SetActive(true);
		IsActive = true;
		InputManager.Instance.allowSceneMouseClicks = false;
	}

	public void Hide()
	{
		gameObject.SetActive(false);
		IsActive = false;
		InputManager.Instance.allowSceneMouseClicks = true;
	}
}
