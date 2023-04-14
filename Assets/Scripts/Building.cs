using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, ISelectable
{

	[SerializeField] private Window windowToShow;
	
	public void Select()
	{
		Debug.Log("Building selected");
		windowToShow.Show();
	}

	public void Deselect()
	{
		windowToShow.Hide();
	}
}
