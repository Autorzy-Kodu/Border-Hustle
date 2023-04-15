using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OrganisationsData", menuName = "ScriptableObjects/OrganisationsData", order = 1)]
public class OrganisationsData : ScriptableObject
{
	[SerializeField] List<Organization> organisationsList;
	public Dictionary<string, Organization> organisationsDictionary = new ();

	private void OnEnable()
	{
		organisationsDictionary.Clear();
		foreach (Organization organisation in organisationsList)
		{
			organisationsDictionary.Add(organisation.organizationName, organisation);
		}
	}
}