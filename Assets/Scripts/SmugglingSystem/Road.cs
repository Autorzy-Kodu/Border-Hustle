using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Road : MonoBehaviour
{
	public string roadName;
	public Sprite sprite;
	[SerializeField] private GameObject dummyCarPrefab;
	[SerializeField] private List<Waypoint> waypoints;
	
	public void SmuggleUsingThisRoad(GameObject vehiclePrefab, IllegalTransport illegalTransport)
	{
		StartCoroutine(EDriving(vehiclePrefab, illegalTransport));
	}

	private IEnumerator EDriving(GameObject vehiclePrefab, IllegalTransport illegalTransport)
	{
		Transform vehicle = Instantiate(vehiclePrefab, waypoints[0].transform.position, waypoints[0].transform.rotation, transform).transform;
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
				vehicle.transform.position += vehicle.transform.forward * (illegalTransport.vehicle.speed * Time.deltaTime * currentWaypointObject.speedModifier);
				yield return null;
			}
			
			if (waypoints[currentWaypoint] is BorderCrossing)
			{
				Debug.Log("border crossing");
				BorderCrossing borderCrossing = (BorderCrossing)waypoints[currentWaypoint];
				yield return new WaitForSeconds(borderCrossing.checkInTime);

				// TODO
				float skillCheck = Random.Range(0f, 1f);
				if (skillCheck < borderCrossing.baseFailPercentage)
				{
					Destroy(gameObject);
					Debug.LogWarning("Smuggler was caught");
					yield break;
				}
			}
			
			currentWaypoint++;
		}
		
		
	}
}
