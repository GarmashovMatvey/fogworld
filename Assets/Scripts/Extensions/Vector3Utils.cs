using UnityEngine;

namespace RW.Extensions
{
	public static class Vector3Utils
	{
		public static Vector3 UpperRight => new Vector3(1, 0, 1);
		public static Vector3 Multiplicate(this Vector3 v1, Vector3 v2)
		{
			return new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
		}
	}
}
