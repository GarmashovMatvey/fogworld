using UnityEngine;

namespace RW.Mechanics.Movement
{
    public sealed class CameraControl : MonoBehaviour
    {
        [SerializeField] private float _sensivity = 100f;
        [SerializeField] private Transform _playerBody;

        private float _xRotation = 0f;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

		private void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * _sensivity;
            float mouseY = Input.GetAxis("Mouse Y") * _sensivity;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            _playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}