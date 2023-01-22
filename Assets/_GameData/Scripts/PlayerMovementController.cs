using System;
using UnityEngine;

namespace _GameData.Scripts
{
    public class PlayerMovementController : CarMovementController
    {
        [SerializeField] private float movementSpeed = 10f;
        [SerializeField] private float rotationSpeed = 270f;
        
        private int _input;
        private Quaternion _deltaRotation;
        
        private CarRecordData _carRecordData;
        private RecordData _recordData;

        private bool _isRecording;

        private void OnEnable()
        {
            EventManager.Instance.OnStageInitialized += OnStageInitializedHandler;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnStageInitialized -= OnStageInitializedHandler;
        }

        private void Update()
        {
            _input = InputManager.Instance.GetInput;
        }

        private void FixedUpdate()
        {
            if(!_isRecording) return;
            
            Move();
            Rotate();
            
            SaveData();
        }

        private void Move()
        {
            rb.MovePosition(rb.position + transform.forward * (movementSpeed * Time.fixedDeltaTime));
        }

        private void Rotate()
        {
            _deltaRotation = Quaternion.Euler(Vector3.up * (_input * rotationSpeed * Time.fixedDeltaTime));
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

        private void OnStageInitializedHandler()
        {
            SetCarRecordData(StageManager.Instance.CurrentStageCarRecordData);
            _isRecording = true;
        }
    }
}
