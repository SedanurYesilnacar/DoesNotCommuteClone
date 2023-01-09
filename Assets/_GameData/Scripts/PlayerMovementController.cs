using UnityEngine;

namespace _GameData.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 10f;
        [SerializeField] private float rotationSpeed = 270f;

        private Quaternion _deltaRotation;

        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            _rb.velocity = transform.forward * movementSpeed;
        }

        private void Rotate()
        {
            _deltaRotation = Quaternion.Euler(Vector3.up * (InputManager.Instance.GetInput * rotationSpeed * Time.fixedDeltaTime));
            _rb.MoveRotation(_rb.rotation * _deltaRotation);
        }
    }
}
