using RW.Mechanics.Movement;
using UnityEngine;

namespace RW.Mechanics.Controllers
{
	[DisallowMultipleComponent, RequireComponent(typeof(Rigidbody))]
	public sealed class PCTestController : MonoBehaviour, IController
	{
		[SerializeField] private Rigidbody _trackedBody;
		[SerializeField] private float _speed;
		[SerializeField] private float _rotationSpeed;
		[SerializeField] private float _jumpHeight;

		private bool _isGrounded = false;
		private Vector3 _previousMousePosition;
		private Vector3 _moveDirection;
		private Motor _motor;
		private bool _jumpRequired;

		public Vector3 DesiredMoveDirection => _moveDirection;

		private void Start()
		{
			_motor = new Motor(_trackedBody, ForceFactory.CreateMovementForce(this), _speed);
			_previousMousePosition = Input.mousePosition;
		}

		private void Update()
		{
			_moveDirection = Vector3.zero;

			if (Input.GetKey(KeyCode.W))
			{
				_moveDirection += _trackedBody.transform.forward;
			}
			if (Input.GetKey(KeyCode.S))
			{
				_moveDirection -= _trackedBody.transform.forward;
			}
			if (Input.GetKey(KeyCode.D))
			{
				_moveDirection += _trackedBody.transform.right;
			}
			if (Input.GetKey(KeyCode.A))
			{
				_moveDirection -= _trackedBody.transform.right;
			}
			_jumpRequired = Input.GetButton("Jump") && _isGrounded;
			
		}

		private void OnCollisionEnter(Collision collision)
		{
			EvaluateCollision(collision);
		}
		private void OnCollisionStay(Collision collision)
		{
			EvaluateCollision(collision);
		}

		private void EvaluateCollision(Collision collision)
		{
			for (int i = 0; i < collision.contactCount; i++)
			{
				Vector3 normal = collision.GetContact(i).normal;
				_isGrounded |= normal.y > 0.9f;
			}
		}

		private void FixedUpdate()
		{
			if (_jumpRequired)
				//_trackedBody.AddForce(Vector3.up * _jumpHeight * _trackedBody.mass, ForceMode.Impulse);

			_isGrounded = false;
			_motor.Update();
		}
	}
}
