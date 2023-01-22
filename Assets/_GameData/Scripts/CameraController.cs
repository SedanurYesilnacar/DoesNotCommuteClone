using UnityEngine;

namespace _GameData.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;

        private Transform _target;

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
            
            transform.position = _target.position + offset;
        }
    }
}