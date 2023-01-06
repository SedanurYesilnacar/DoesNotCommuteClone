using UnityEngine;

namespace _GameData.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;

        private Transform _target;

        private void Awake()
        {
            _target = FindObjectOfType<PlayerInputController>().transform;
        }

        private void LateUpdate()
        {
            transform.position = _target.position + offset;
        }
    }
}