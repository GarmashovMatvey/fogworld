using System;
using UnityEngine;

namespace RW.Mechanics.Movement
{
	public class Force
	{
		/// <summary>
		/// Parameter is world position
		/// </summary>
		public Func<Vector3, Vector3> ForceFunc {get; private set; }

		protected Force SetFunc(Func<Vector3, Vector3> forceFunc)
		{
			ForceFunc = forceFunc; return this;
		}
	}
}
