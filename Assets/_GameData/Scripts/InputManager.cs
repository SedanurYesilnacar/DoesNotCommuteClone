using UnityEngine;

namespace _GameData.Scripts
{
    public class InputManager : Singleton<InputManager>
    {
        public int GetInput => _input;
        private int _input;

        private InputRecordData _inputRecordData;
        private bool _isRecording;
        
        private Camera _mainCamera;
        
        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void OnEnable()
        {
            EventManager.Instance.OnStageInitialized += OnStageInitializedHandler;
            EventManager.Instance.OnStageCompleted += OnStageCompletedHandler;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnStageInitialized -= OnStageInitializedHandler;
            EventManager.Instance.OnStageCompleted -= OnStageCompletedHandler;
        }

        private void Update()
        {
            _input = Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)
                ? _mainCamera.ScreenToViewportPoint(Input.mousePosition).x <= 0.5f ? -1 : 1
                : 0;
        }

        private void FixedUpdate()
        {
            if(_isRecording) RecordInput();
        }

        private void RecordInput()
        {
            _inputRecordData.SaveData(_input);
        }

        private void OnStageInitializedHandler()
        {
            _inputRecordData = StageManager.Instance.CurrentStageInputRecordData;
            _isRecording = true;
        }

        private void OnStageCompletedHandler()
        {
            _isRecording = false;
        }
    }
}