//C# Example (LookAtPointEditor.cs)

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WallPlacer))]
public class WallPlacerEditor : Editor 
{
	WallPlacer wallPlacer;
    
	void OnEnable()
	{
		wallPlacer = (WallPlacer)target;
	}

	public override void OnInspectorGUI()
	{
		if (GUILayout.Button("Place on ground"))
		{
			PlaceWall();
		}
	}

	void PlaceWall()
	{
		List<WallPlacer> walls = FindObjectsOfType<WallPlacer>().ToList();
		foreach (WallPlacer wp in walls)
		{
			if (Physics.Raycast(wp.transform.position, -wp.transform.up, out RaycastHit rHit, 100f))
			{
				wp.transform.position = rHit.point + Vector3.down;
				EditorUtility.SetDirty(wp.transform);
			}			
		}
	}
}