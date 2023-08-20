using RW.Extensions;
using System.Collections.Generic;
using UnityEngine;

namespace RW.Mechanics.Movement
{
	public sealed class Motor
	{
		private readonly Rigidbody _body;
		private readonly LinkedList<Force> _forces;
		private readonly Force _movementForce;
		private readonly float _movementForceSpeed;
		private Vector3 _rigidbodyMask = Vector3.up;

		public Motor(Rigidbody body)
		{
			_body = body;
			_forces = new LinkedList<Force>();
		}

		public Motor(Rigidbody body, Force movementForce, float speed) : this(body) 
		{
			_movementForce = movementForce;
			_movementForceSpeed = speed;
		}

		public void SetRigidbodyMask(Vector3 mask)
		{
			_rigidbodyMask = mask;
		}

		public void Update()
		{
			Vector3 summerized = Vector3.zero;

			foreach (var force in _forces)
			{
				summerized += force.ForceFunc(_body.position);
			}

			if (_movementForce != null)
			{
				summerized += _movementForce.ForceFunc(_body.position) * _movementForceSpeed;
			}

			_body.velocity = summerized + _body.velocity.Multiplicate(_rigidbodyMask);
		}

		public void AddForce(Force force)
		{
			_forces.AddLast(force);
		}

		public void RemoveForce(Force force)
		{
			_forces.Remove(force);
		}
	}
}
