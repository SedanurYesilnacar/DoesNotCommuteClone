using UnityEngine;

namespace _GameData.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class CarMovementController : MonoBehaviour
    {
        [SerializeField] protected float movementSpeed = 10f;
        [SerializeField] private float rotationSpeed = 270f;

        protected int input;
        
        private Quaternion _deltaRotation;

        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        protected virtual void FixedUpdate()
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
            _deltaRotation = Quaternion.Euler(Vector3.up * (input * rotationSpeed * Time.fixedDeltaTime));
            _rb.MoveRotation(_rb.rotation * _deltaRotation);
        }
    }
}