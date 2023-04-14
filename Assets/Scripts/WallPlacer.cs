using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPlacer : MonoBehaviour
{
	private void Awake()
	{
		PlaceWallOnGround();
	}

	// TODO napisać jako custom editor
	void PlaceWallOnGround()
	{
		if (Physics.Raycast(transform.position, -transform.up, out RaycastHit rHit, 100f))
		{
			transform.position = rHit.point + Vector3.down;
		}
	}
}
