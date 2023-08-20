using UnityEngine;

namespace RW.DEBUG
{
	[DisallowMultipleComponent, RequireComponent(typeof(Collider))]
	public sealed class TeleportOnTouch : MonoBehaviour
	{
		[SerializeField] private Vector3 _teleportPosition;

		private void Awake()
		{
			GetComponent<Collider>().isTrigger = true;
		}

		private void OnTriggerEnter(Collider collision)
		{
			collision.transform.position = _teleportPosition;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(_teleportPosition, 0.5f);
			Gizmos.DrawLine(transform.position, _teleportPosition);
		}
	}
}