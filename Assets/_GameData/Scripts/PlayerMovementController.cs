using Assets._GameData.Scripts;
using System.Collections;
using UnityEngine;

namespace _GameData.Scripts
{
    public class PlayerMovementController : CarMovementController
    {
        private const float MovementSpeed = 10f;
        private const float RotationSpeed = 180f;
        private const float ExtraGravity = 30f;
        
        private ParticleSystem crashParticle;

        private const float DelayBeforeFail = 1.5f;
        
        private int _input;
        private Quaternion _deltaRotation;
        
        private CarRecordData _carRecordData;
        private RecordData _recordData;

        private bool _isRecording;
        private bool _isCrashed;
        private bool _isMovementAllowed = true;

        private LayerMask _crashLayer;

        private WaitForSeconds _delayBeforeFail;

        private void OnEnable()
        {
            EventManager.Instance.OnStageInitialized += OnStageInitializedHandler;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnStageInitialized -= OnStageInitializedHandler;
        }

        public void Init(GameObject carVisualPrefab, Transform endPoint)
        {
            carProperty = GetComponent<CarProperty>();
            rb = carProperty.rb;
            crashParticle = carProperty.crashParticle;
            
            _delayBeforeFail = new WaitForSeconds(DelayBeforeFail);
            _crashLayer = (1 << LayerMask.NameToLayer("Obstacle")) | 
                                    (1 << LayerMask.NameToLayer("Car"));

            Instantiate(carVisualPrefab, carProperty.carVisualRoot);

            carProperty.arrow.Init(transform, endPoint);
            carProperty.arrow.SetVisibility(true);
        }

        private void Update()
        {
            _input = InputManager.Instance.GetInput;
        }

        private void FixedUpdate()
        {
            if(!_isRecording || !_isMovementAllowed) return;
            
            Move();
            Rotate();
            
            SaveData();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (((1 << collision.gameObject.layer) & _crashLayer) != 0)
            {
                if (!_isCrashed)
                {
                    _isCrashed = true;
                    StartCoroutine(FailRoutine());
                }
            }
        }

        private void Move()
        {
            rb.AddForce(Vector3.down * ExtraGravity);
            rb.MovePosition(rb.position + transform.forward * (MovementSpeed * Time.fixedDeltaTime));
        }

        private void Rotate()
        {
            _deltaRotation = Quaternion.Euler(Vector3.up * (_input * RotationSpeed * Time.fixedDeltaTime));
            rb.MoveRotation(rb.rotation * _deltaRotation);
        }

        private void SaveData()
        {
            _recordData.position = transform.position;
            _recordData.rotation = transform.eulerAngles;
            _recordData.velocity = rb.velocity;
            
            _carRecordData.SaveData(_recordData);
        }

        private void SetCarRecordData(CarRecordData carRecordData) => _carRecordData = carRecordData;

        private IEnumerator FailRoutine()
        {
            crashParticle.Play();
            
            _isMovementAllowed = false;
            _carRecordData.RemoveData();
            
            yield return _delayBeforeFail;
            
            EventManager.Instance.RaiseOnStageFailed();
        }

        private void OnStageInitializedHandler()
        {
            SetCarRecordData(StageManager.Instance.CurrentStageCarRecordData);
            _isRecording = true;
        }
    }
}
