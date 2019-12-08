using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Finder
{
	public static T Find<T>(string name) where T : UnityEngine.Object
	{
		T[] results = (T[])Resources.FindObjectsOfTypeAll(typeof(T));
		
		foreach (var result in results)
			if (result.name == name)
				return result;
		return null;
	}
}