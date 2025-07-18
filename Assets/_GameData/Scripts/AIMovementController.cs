using Assets._GameData.Scripts;
using UnityEngine;

namespace _GameData.Scripts
{
    public class AIMovementController : CarMovementController
    {
        private const float CarMass = 50f;
        
        private CarRecordData _carRecordData;
        
        private int _frameCounter;
        private bool _isReplaying;
        
        private void OnEnable()
        {
            EventManager.Instance.OnStageInitialized += OnStageInitializedHandler;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnStageInitialized -= OnStageInitializedHandler;
        }

        public void Init(CarRecordData carRecordData, GameObject carVisualPrefab)
        {
            carProperty = GetComponent<CarProperty>();

            _carRecordData = carRecordData;
            rb = carProperty.rb;
            rb.mass = CarMass;

            Instantiate(carVisualPrefab, carProperty.carVisualRoot);

            carProperty.arrow.SetVisibility(false);
        }

        public void Stop()
        {
            rb.isKinematic = true;
        }

        private void FixedUpdate()
        {
            if(!_isReplaying) return;
            
            Replay();
        }

        private void Replay()
        {
            if (_frameCounter < _carRecordData.recordedData.Count)
            {
                transform.position = _carRecordData.recordedData[_frameCounter].position;
                transform.eulerAngles = _carRecordData.recordedData[_frameCounter].rotation;
                rb.velocity = _carRecordData.recordedData[_frameCounter].velocity;
                
                _frameCounter++;
            }
        }

        private void OnStageInitializedHandler()
        {
            _isReplaying = true;
        }
    }
}