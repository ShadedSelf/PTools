using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoolExtensions
{
	public static int ToInt(this bool b)	=> b ? 1  : 0;
	public static uint ToUint(this bool b)	=> b ? 1U : 0;
}
