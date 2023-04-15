//C# Example (LookAtPointEditor.cs)

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Waypoint))]
public class WaypointPlacerEditor : Editor 
{
	Waypoint waypoint;
    
	void OnEnable()
	{
		waypoint = (Waypoint)target;
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		if (GUILayout.Button("Place on ground"))
		{
			PlaceWall();
		}
	}

	void PlaceWall()
	{
		List<Waypoint> waypoints = FindObjectsOfType<Waypoint>().ToList();
		foreach (Waypoint wp in waypoints)
		{
			if (Physics.Raycast(wp.transform.position + Vector3.up * 100f, -wp.transform.up, out RaycastHit rHit, 400f))
			{
				wp.transform.position = rHit.point + Vector3.up * 0.5f;
				EditorUtility.SetDirty(wp.transform);
			}			
		}
	}
}