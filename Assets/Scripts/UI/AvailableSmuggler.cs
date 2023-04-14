using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableSmuggler : MonoBehaviour
{
	private Smuggler smuggler;
	
	// TODO aktywowane przyciskami z zewnątrz
	public void Hire()
	{
		GameManager.Instance.HireSmuggler(smuggler);
		Destroy(gameObject);
	}
	
	// TODO aktywowane przyciskami z zewnątrz
	public void Reject()
	{
		Destroy(gameObject);
	}
}
