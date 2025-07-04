using UnityEngine;

namespace _GameData.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;
        [SerializeField] private float leftBound;
        [SerializeField] private float rightBound;
        [SerializeField] private float topBound;
        [SerializeField] private float bottomBound;

        private Transform _target;

        private Vector3 _desiredPosition;

        private void OnEnable()
        {
            EventManager.Instance.OnStageInitialized += OnStageInitializedHandler;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnStageInitialized -= OnStageInitializedHandler;
        }

        private void OnStageInitializedHandler()
        {
            _target = StageManager.Instance.CurrentStageCar;
        }

        private void LateUpdate()
        {
            if(_target == null) return;

            _desiredPosition = _target.position + offset;
            float finalXPosition = Mathf.Clamp(_desiredPosition.x, leftBound, rightBound);
            float finalZPosition = Mathf.Clamp(_desiredPosition.z, bottomBound, topBound);

            transform.position = new Vector3(finalXPosition, _desiredPosition.y, finalZPosition);

        }
    }
}