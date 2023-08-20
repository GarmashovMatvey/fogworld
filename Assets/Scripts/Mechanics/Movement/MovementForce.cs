using UnityEngine;
using RW.Mechanics.Controllers;

namespace RW.Mechanics.Movement.Low
{
	public sealed class MovementForce : Force
	{
		private readonly IController _controller;

		public MovementForce(IController controller)
		{
			_controller = controller;
			SetFunc(Force);
		}

		private Vector3 Force(Vector3 worldPosition)
		{
			return _controller.DesiredMoveDirection;
		}
	}
}
