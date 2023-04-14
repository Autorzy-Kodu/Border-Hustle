using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public abstract class Singleton<T> : Singleton where T : MonoBehaviour {
	[CanBeNull] static T instance;
	static GameObject sGameObject;

	protected virtual void Awake () {
		sGameObject = gameObject;
		
		var objs = FindObjectsOfType<T>();
		if (objs.Length > 1)
			Destroy (gameObject);
	}
    
	[NotNull]
	public static T Instance {
		get {
			if (instance)
				return instance;

			if (sGameObject) {
				instance = sGameObject.GetComponent<T>();
				if (!instance)
					instance = sGameObject.AddComponent<T>();
				return instance!;
			}
            
			var objs = FindObjectsOfType<T>();
			if (objs.Length > 0) {
				Debug.LogError($"Multiple {nameof(Singleton)}<{typeof(T)}>! Remove additional ones.");
				return objs[0];
			}

			if (!sGameObject) {
				Debug.Log ($"No instances of {nameof(Singleton)}<{typeof(T)}> found! Creating new one.");
				instance = new GameObject ($"{nameof(Singleton)}<{typeof(T)}>").AddComponent<T> ();
			}

			return instance!;
		}
	}
}

public abstract class Singleton : MonoBehaviour {}