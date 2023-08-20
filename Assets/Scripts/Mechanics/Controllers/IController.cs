using UnityEngine;

namespace RW.Mechanics.Controllers
{
	public interface IController
	{
		Vector3 DesiredMoveDirection { get; }
	}
}
