using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
	[SerializeField] private Transform testCar;
	[SerializeField] private List<Waypoint> waypoints;

	private void Start()
	{
		StartDriving(testCar, 5f);
	}

	public void StartDriving(Transform vehicle, float speed)
	{
		StartCoroutine(IDriving(vehicle, speed));
	}

	IEnumerator IDriving(Transform vehicle, float speed)
	{
		vehicle.transform.position = waypoints[0].transform.position;
		Debug.Log("start driving");
		int currentWaypoint = 1;

		while (currentWaypoint < waypoints.Count)
		{
			Vector3 targetPosition = waypoints[currentWaypoint].transform.position;
			Waypoint currentWaypointObject = waypoints[currentWaypoint].GetComponent<Waypoint>();

			while (Vector3.Distance(vehicle.transform.position, targetPosition) > 1f)
			{
				Vector3 direction = waypoints[currentWaypoint].transform.position - vehicle.transform.position;
				Quaternion targetRotation = Quaternion.LookRotation(direction);
				
				// FIXME dostosować szybkość skręcania
				vehicle.transform.rotation = Quaternion.Lerp(vehicle.transform.rotation, targetRotation, Time.deltaTime * 2f);
				vehicle.transform.position += vehicle.transform.forward * (speed * Time.deltaTime * currentWaypointObject.speedModifier);
				yield return null;
			}
			currentWaypoint++;
		}
	}
}
