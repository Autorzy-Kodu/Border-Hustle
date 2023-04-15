using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, ISelectable
{

	[SerializeField] private Window windowToShow;
	
	public void Select()
	{
		Debug.Log("Building selected");
		if (!windowToShow)
		{
			Debug.LogWarning("WindowToShow not set for that building!");
			return;
		}

		windowToShow.Show();
	}

	public void Deselect()
	{
		windowToShow.Hide();
	}
}
