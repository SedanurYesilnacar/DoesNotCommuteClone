using System.Collections;
using UnityEngine;

namespace Assets._GameData.Scripts
{
    public class ArrowController : MonoBehaviour
    {
        [SerializeField] private Transform arrowRoot;
        [SerializeField] private GameObject arrow;
        [SerializeField] private float arrowDisappearRange = 2f;

        private Transform _startPoint;
        private Transform _endPoint;

        private Vector3 _direction;
        private bool _isInitialized;

        public void Init(Transform startPoint, Transform endPoint)
        {
            _startPoint = startPoint;
            _endPoint = endPoint;

            _isInitialized = true;
        }

        public void SetVisibility(bool isVisible)
        {
            arrow.gameObject.SetActive(isVisible);
        }

        private void LateUpdate()
        {
            if (!_isInitialized) return;

            _direction = _endPoint.position - _startPoint.position;
            _direction.y = 0f;

            if (_direction.sqrMagnitude <=  arrowDisappearRange)
            {
                SetVisibility( false );
            }
            else
            {
                SetVisibility( true );
            }

                transform.rotation = Quaternion.LookRotation(_direction, Vector3.up);
        }
    }
}