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
	}

	public void Hide()
	{
		gameObject.SetActive(false);
		IsActive = false;
	}
}
