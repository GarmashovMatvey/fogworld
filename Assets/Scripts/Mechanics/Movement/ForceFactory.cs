using RW.Mechanics.Controllers;
using RW.Mechanics.Movement.Low;

namespace RW.Mechanics.Movement
{
	public static class ForceFactory
	{
		public static Force CreateMovementForce(IController controller)
		{
			return new MovementForce(controller);
		}
	}
}
